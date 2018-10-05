using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.Data;
using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using RefraGama.Seismogram;

namespace RefraGama
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private SerialComm _serialComm;
        private BindingList<Channels> _channels;

        public int RecordingTime => GetRecordingTime();
        public int LastChannel => GetLastChannel();
        public int NumberOfSamples => GetNumberOfSample();
        public int NumberOfChannels => GetNumberOfChannel();

        public Form1()
        {
            InitializeComponent();
            _serialComm = new SerialComm(this);
            stateIndicatorComponent1.StateIndex = 1;
            comboBoxEditSamplingRate.SelectedIndex = 0;
            
            InitGainSetting();

            _channels = new BindingList<Channels>();
            gridControlChannel.DataSource = _channels;

            // Create an in-place LookupEdit control.
            var gainLookup = new RepositoryItemLookUpEdit();
            gainLookup.DataSource = GainSettings;
            gainLookup.ValueMember = "Gain";
            gainLookup.DisplayMember = "Gain";

            // Enable the "best-fit" functionality mode in which columns have proportional widths and the popup window is resized to fit all the columns.
            gainLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            // Specify the dropdown height.
            gainLookup.DropDownRows = GainSettings.Count;
            gainLookup.ShowHeader = false;

            // Enable the automatic completion feature. In this mode, when the dropdown is closed, 
            // the text in the edit box is automatically completed if it matches a DisplayMember field value of one of dropdown rows. 
            //gainLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            // Specify the column against which an incremental search is performed in SearchMode.AutoComplete and SearchMode.OnlyInPopup modes
            //gainLookup.AutoSearchColumnIndex = 1;

            // Assign the in-place LookupEdit control to the grid's CategoryID column.
            // Note that the data types of the "ID" and "CategoryID" fields match.
            gridViewChannel.Columns["Gain"].ColumnEdit = gainLookup;
            gridViewChannel.BestFitColumns();

            gridControlChannel.Refresh();
        }

        public void ShowSeismogram()
        {
            barButtonSeismogram_ItemClick(null, null);
        }

        private int GetLastChannel()
        {
            if (_channels.Count == 0) return 0;
            var lastChannel = _channels[0].Id;
            foreach (Channels t in _channels)
            {
                if (lastChannel < t.Id)
                    lastChannel = t.Id;
            }
            return lastChannel;
        }

        private int GetNumberOfChannel()
        {
            return _channels.Count;
        }

        private int GetRecordingTime()
        {
            return (int) spinEditRecordingTime.Value;
        }

        private int GetNumberOfSample()
        {
            return (int) spinEditRecordingTime.Value/1000*(int) comboBoxEditSamplingRate.SelectedItem;
        }

        public void ShowWaitForm()
        {
            splashScreenManager1.ShowWaitForm();
            //splashScreenManager1.WaitForSplashFormClose();
        }

        public void CaptionWaitFor(string text)
        {
            if(!splashScreenManager1.IsSplashFormVisible) return;
            splashScreenManager1.SetWaitFormCaption(text);
        }

        public void CloseWaitForm()
        {
            splashScreenManager1.CloseWaitForm();
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
            gridViewChannel.AddNewRow();
            gridControlChannel.Refresh();
        }

        private void simpleButtonRemoveChannel_Click(object sender, EventArgs e)
        {
            //_channels.Clear();
            if (_channels.Count == 0) return;
            _channels.RemoveAt(gridViewChannel.GetFocusedDataSourceRowIndex());
            gridControlChannel.Refresh();
        }

        private void barButtonSetGainArmTrigg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_serialComm.IsConnected()) return;
            foreach (var channel in _channels)
            {
                var wiper = channel.Gain;
                _serialComm.SetGain(channel.Id, wiper);
            }

            var numberOfSamples = int.Parse(comboBoxEditSamplingRate.SelectedItem.ToString())*spinEditRecordingTime.Value/1000;
            _serialComm.SetTriggerSensitivity((int) spinEditTriggerSensitivity.Value);
            _serialComm.SetNumOfSample((int) numberOfSamples);
            _serialComm.ArmTrigger();
        }

        private void barButtonSeismogram_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var stream = _serialComm.Gather;

            if(checkEditDcRemoval.Checked) stream.Detrend();

            var gatherViewer = new GatherViewer(stream);
            gatherViewer.Show();
        }

        private void barButtonClearMemory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_serialComm.IsConnected()) return;
            _serialComm.ClearMemory();
        }

        private void barButtonStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!_serialComm.IsConnected()) return;
            ShowWaitForm();
            //btnAutoSearchChannel_Click(null, null);
            barButtonClearMemory_ItemClick(null,null);
            Thread.Sleep(10000);
            barButtonSetGainArmTrigg_ItemClick(null, null);
            splashScreenManager1.WaitForSplashFormClose();
            ShowSeismogram();
        }

        readonly List<GainSetting> GainSettings = new List<GainSetting>();

        private void InitGainSetting()
        {
            GainSettings.Add(new GainSetting() {  Gain = 1 });
            GainSettings.Add(new GainSetting() {  Gain = 2 });
            GainSettings.Add(new GainSetting() {  Gain = 4 });
            GainSettings.Add(new GainSetting() {  Gain = 8 });
            GainSettings.Add(new GainSetting() {  Gain = 16 });
            GainSettings.Add(new GainSetting() {  Gain = 32 });
            GainSettings.Add(new GainSetting() {  Gain = 64 });
            GainSettings.Add(new GainSetting() {  Gain = 128 });
        }

        private void barButtonCommTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _serialComm.SetGain(11,4);
        }
    }

    public class GainSetting
    {
        //public int ID { get; set; }
        public int Gain { get; set; }
    }
}
