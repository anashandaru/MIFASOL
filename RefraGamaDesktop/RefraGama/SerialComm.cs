using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandMessenger;
using CommandMessenger.Transport.Serial;
using DevExpress.Data.Helpers;
using DevExpress.XtraExport.Xls;
using DevExpress.XtraGrid;
using RefraGama.Core;

namespace RefraGama
{
    // This is the list of recognized commands. These can be commands that can either be sent or received. 
    // In order to receive, attach a callback function to these events
    enum Command
    {
        CommTest, // send command to test the communication between central unit and computer
        CommReport, // receive command report from the central unit
        ChannelSearch, // send command to search all available channel
        ChannelFounded, // receive information about all availabel channel
        SetNumOfSample, // send command to set recording time
        SetSamplingRate, // send command to set sampling rate
        SetGain, // send command to set gain
        ClearMemory, // send command to clear flash memory
        SetTriggerSensitivity, // send command to trigger sensitivity
        ArmTrigger, // send command to arm trigger
        Triggered, // received if the instrument has been triggered
        RequestData, // send command to receive data
        ReceiveData, // receive data from central unit
    }

    class SerialComm
    {
        private SerialTransport _serialTransport;
        private CmdMessenger _cmdMessenger;
        private List<ISeismicTrace> _traces;
        private List<float> _traceBuffer;
        private ushort _currentChannel;
        private Form1 _form;
        public bool ChannelSearchCompleted { get; private set; }
        public bool IsTriggered { get; private set; }
        public ISeismicStream Gather => GetStream();
        public List<Channels> Channels { get; }

        public SerialComm(Form1 form)
        {
            _form = form;

            // Create Serial Port object
            _serialTransport = new SerialTransport
            {
                CurrentSerialSettings = { PortName = "COM3", BaudRate = 115200, DtrEnable = true} // object initializer
            };

            // Initialize the command messenger with the Serial Port transport layer
            // Set if it is communicating with a 16- or 32-bit Arduino board
            _cmdMessenger = new CmdMessenger(_serialTransport, BoardType.Bit16);



            // Clear queues 
            _cmdMessenger.ClearReceiveQueue();
            _cmdMessenger.ClearSendQueue();

            // Attach the callbacks to the Command Messenger
            AttachCommandCallBacks();

            IsTriggered = false;
            Channels = new List<Channels>();
            _traceBuffer = new List<float>();
            _traces = new List<ISeismicTrace>();
        }

        public void CommTest()
        {
            var command = new SendCommand((int)Command.CommTest);
            _cmdMessenger.SendCommand(command);
        }

        public void ChannelSearch()
        {
            while (Channels.Any())
            {
                Channels.Clear();
            }

            ChannelSearchCompleted = false;

            var command = new SendCommand((int)Command.ChannelSearch);
            _cmdMessenger.SendCommand(command);
        }

        public void SetNumOfSample(int npts)
        {
            var command = new SendCommand((int)Command.SetNumOfSample);
            command.AddBinArgument((UInt16)npts);
            _cmdMessenger.SendCommand(command);
        }

        public void SetSamplingRate(int samplingRate)
        {
            var command = new SendCommand((int)Command.SetSamplingRate);
            command.AddBinArgument((UInt16)samplingRate);
            _cmdMessenger.SendCommand(command);
        }

        public void SetGain(int address, int wiper)
        {
            var command = new SendCommand((int)Command.SetGain);
            command.AddBinArgument((UInt16)address);
            command.AddBinArgument((Int16)wiper);
            _cmdMessenger.SendCommand(command);
        }

        public void ClearMemory()
        {
            _form.CaptionWaitFor("Clearing Memory");
            var command = new SendCommand((int)Command.ClearMemory);
            _cmdMessenger.SendCommand(command);
        }

        public void SetTriggerSensitivity(int sensitivity)
        {
            var threshold = 100 - sensitivity;
            var command = new SendCommand((int)Command.SetTriggerSensitivity);
            command.AddBinArgument((UInt16)threshold);
            _cmdMessenger.SendCommand(command);
        }

        public void ArmTrigger()
        {
            _form.CaptionWaitFor("Waiting For Trigger");
            var command = new SendCommand((int)Command.ArmTrigger);
            _cmdMessenger.SendCommand(command);
        }

        public void RequestData()
        {
            _form.CaptionWaitFor("Transfering Data");

            while (_traces.Any())
            {
                _traces.Clear();
            }

            while (_traceBuffer.Any())
            {
                _traceBuffer.Clear();
            }

            var commandBinary = new SendCommand((int)Command.RequestData);
            
            // Send command 
            _cmdMessenger.SendCommand(commandBinary);
        }

        private void AttachCommandCallBacks()
        {
            _cmdMessenger.Attach(OnUnknownCommand);
            _cmdMessenger.Attach((int)Command.CommReport,OnCommReport);
            _cmdMessenger.Attach((int)Command.ChannelFounded, OnChannelFounded);
            _cmdMessenger.Attach((int)Command.Triggered, OnTriggered);
            _cmdMessenger.Attach((int)Command.ReceiveData, OnReceiveData);
        }

        private void OnTriggered(ReceivedCommand arguments)
        {
            _form.CaptionWaitFor("Recording");
            IsTriggered = true;
            Thread.Sleep(_form.RecordingTime + 100);
            RequestData();
        }

        private void OnChannelFounded(ReceivedCommand arguments)
        {
            ChannelSearchCompleted = arguments.ReadBinBoolArg();
            if (ChannelSearchCompleted) return;
            var channel = new Channels { Id = arguments.ReadBinUInt16Arg(), Channel = Channels.Count + 1 , Gain = 1};
            Channels.Add(channel);
        }

        private void OnCommReport(ReceivedCommand arguments)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when a received command has no attached function.
        /// </summary>
        /// <param name="arguments"></param>
        private void OnUnknownCommand(ReceivedCommand arguments)
        {
            Console.WriteLine(@"Command without attached callback received");
        }

        /// <summary>
        /// Callback function To receive data series from the Arduino
        /// </summary>
        /// <param name="arguments"></param>
        private void OnReceiveData(ReceivedCommand arguments)
        {
            var currentChannel = arguments.ReadBinUInt16Arg();
            if(_currentChannel != currentChannel)
            {
                if (_traceBuffer.Any())
                {
                    var trace = new SeismicTrace(_traceBuffer.ToArray());
                    trace.Header.Station = _currentChannel.ToString();
                    trace.Header.SamplingRate = 3750;
                    _traces.Add(trace);
                    _traceBuffer.Clear();
                }
                _currentChannel = currentChannel;
                if(currentChannel != 0) _form.CaptionWaitFor("Transfering Data from " + currentChannel);
            }

            // Read data packet (consist of 8 samples)
            for (int i = 0; i < 8; i++)
            {
                var receiveValue = (float) arguments.ReadBinInt32Arg();
                _traceBuffer.Add(receiveValue);
                //Debug.WriteLine(receiveValue);
            }

            if (_traces.Count != _form.NumberOfChannels) return;
            _form.CloseWaitForm();
        }

        private ISeismicStream GetStream()
        {
            var result = new SeismicStream(_traces);
            return result;
        }

        /// <summary>
        /// Set Port Number
        /// </summary>
        /// <param name="portNumber"></param>
        public void SetPortName(int portNumber)
        {
            _serialTransport.CurrentSerialSettings.PortName = String.Concat("COM",portNumber.ToString());
        }

        public bool Connect()
        {
            return _cmdMessenger.Connect();
        }

        public bool Disconnect()
        {
            return _cmdMessenger.Disconnect();
        }

        public bool IsConnected()
        {
            return _serialTransport.IsConnected();
        }
    }
}
