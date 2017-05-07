using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using RefraGama.Seismogram;

namespace RefraGama
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private SerialComm _serialComm;
        private BindingList<Channels> _channels;
        public Form1()
        {
            InitializeComponent();
            _serialComm = new SerialComm(this);
            stateIndicatorComponent1.StateIndex = 1;
            comboBoxEditSamplingRate.SelectedIndex = 0;
            
            _channels = new BindingList<Channels>();
            gridControlChannel.DataSource = _channels;
            gridControlChannel.Refresh();
        }

        public void UpdateChannleTable(Channels channel)
        {
            _channels.Add(channel);
            gridControlChannel.Refresh();
        }

        private void simpleButtonConnect_Click(object sender, EventArgs e)
        {
            if (_serialComm.IsConnected() && _serialComm.Disconnect())
            {
                simpleButtonConnect.Text = @"Connect";
                stateIndicatorComponent1.StateIndex = 1;
            }
            else if (!_serialComm.IsConnected() && _serialComm.Connect())
            {
                simpleButtonConnect.Text = @"Disconnect";
                stateIndicatorComponent1.StateIndex = 3;
            }
            else
            {
                simpleButtonConnect.Text = @"Connect";
                stateIndicatorComponent1.StateIndex = 1;
            }

        }

        private void barButtonRequestData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _serialComm.RequestData();
        }

        private void btnAutoSearchChannel_Click(object sender, EventArgs e)
        {
            _serialComm.ChannelSearch();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (!_serialComm.ChannelSearchCompleted)
            {
                if(stopwatch.ElapsedMilliseconds>500)
                    break;
            }
            var foundedChannels = _serialComm.Channels;
            if(!foundedChannels.Any()) return;
            _channels.Clear();
            foreach (var channel in foundedChannels)
            {
                _channels.Add(channel);
            }
            gridControlChannel.DataSource = _channels;
            gridControlChannel.Refresh();
        }

        private void simpleButtonAddChannel_Click(object sender, EventArgs e)
        {
            
            gridControlChannel.Refresh();
        }

        private void simpleButtonRemoveChannel_Click(object sender, EventArgs e)
        {
            _channels.Clear();
            gridControlChannel.Refresh();
        }

        private void barButtonSetGainArmTrigg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var numberOfSamples = int.Parse(comboBoxEditSamplingRate.SelectedItem.ToString())*spinEditRecordingTime.Value/1000;
            _serialComm.SetTriggerSensitivity((int) spinEditTriggerSensitivity.Value);
            _serialComm.SetNumOfSample((int) numberOfSamples);
            _serialComm.ArmTrigger();
        }

        private void barButtonSeismogram_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var stream = _serialComm.Gather;
            var gatherViewer = new GatherViewer(stream);
            gatherViewer.Show();
        }

        private void barButtonClearMemory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _serialComm.ClearMemory();
        }
    }
}
