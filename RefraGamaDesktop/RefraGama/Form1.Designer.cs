namespace RefraGama
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState1 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState2 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState3 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            DevExpress.XtraGauges.Core.Model.IndicatorState indicatorState4 = new DevExpress.XtraGauges.Core.Model.IndicatorState();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.barManagerMain = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnInstrumentSetup = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecording = new DevExpress.XtraBars.BarButtonItem();
            this.btnGPS = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnStart = new DevExpress.XtraBars.BarButtonItem();
            this.btnStacking = new DevExpress.XtraBars.BarButtonItem();
            this.btnCommTest = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetGainArmTrigger = new DevExpress.XtraBars.BarButtonItem();
            this.btnRequestData = new DevExpress.XtraBars.BarButtonItem();
            this.btnNoiseMonitor = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.checkEditHighPass = new DevExpress.XtraEditors.CheckEdit();
            this.spinEditHighPassOrder = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditLowPassOrder = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditBandStopOrder = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditBandStopMax = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditBandStopMin = new DevExpress.XtraEditors.SpinEdit();
            this.checkEditBandStop = new DevExpress.XtraEditors.CheckEdit();
            this.spinEditTriggerSensitivity = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditRecordingTime = new DevExpress.XtraEditors.SpinEdit();
            this.gaugeControlConnectivity = new DevExpress.XtraGauges.Win.GaugeControl();
            this.stateIndicatorGaugeConnctivity = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge();
            this.stateIndicatorComponent1 = new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent();
            this.checkEditLowPass = new DevExpress.XtraEditors.CheckEdit();
            this.spinEditHighPass = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditLowPass = new DevExpress.XtraEditors.SpinEdit();
            this.checkEditApplyFilter = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditZeroPhaseFilter = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditDcRemoval = new DevExpress.XtraEditors.CheckEdit();
            this.btnAutoSearchChannel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRemoveChannel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddChannel = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditHideDisabledChannels = new DevExpress.XtraEditors.CheckEdit();
            this.spinEditEnabledChannels = new DevExpress.XtraEditors.SpinEdit();
            this.gridControlChannel = new DevExpress.XtraGrid.GridControl();
            this.gridViewChannel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnChannel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEditNumberOfChannels = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxPort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonReflection = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRefraction = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMASW = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMicrotremor = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRenameConfg = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonEditConfg = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDeleteConfg = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNewConfg = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl2 = new DevExpress.XtraEditors.ProgressBarControl();
            this.comboBoxEditSamplingRate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditConfg = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonConnect = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarBattery = new DevExpress.XtraEditors.ProgressBarControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonStart = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonStacking = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonCommTest = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSetGainArmTrigg = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRequestData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSeismogram = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonInstSetup = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRecording = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGPS = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonClearMemory = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::RefraGama.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditHighPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditHighPassOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLowPassOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBandStopOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBandStopMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBandStopMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBandStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTriggerSensitivity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditRecordingTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGaugeConnctivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLowPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditHighPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLowPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditApplyFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditZeroPhaseFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDcRemoval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditHideDisabledChannels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditEnabledChannels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumberOfChannels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSamplingRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditConfg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBattery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerMain
            // 
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManagerMain.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Commands", new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6")),
            new DevExpress.XtraBars.BarManagerCategory("Setup", new System.Guid("18fa184b-a1f2-4113-86e2-d0831df438b4"))});
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnStart,
            this.btnStacking,
            this.btnCommTest,
            this.btnSetGainArmTrigger,
            this.btnRequestData,
            this.btnNoiseMonitor,
            this.btnFile,
            this.btnConnect,
            this.btnInstrumentSetup,
            this.btnRecording,
            this.btnGPS,
            this.barSubItem1,
            this.barSubItem2});
            this.barManagerMain.MainMenu = this.bar2;
            this.barManagerMain.MaxItemId = 15;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(455, 148);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Setup";
            this.barSubItem1.Id = 13;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConnect),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInstrumentSetup),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRecording),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGPS)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnFile
            // 
            this.btnFile.Caption = "File";
            this.btnFile.CategoryGuid = new System.Guid("18fa184b-a1f2-4113-86e2-d0831df438b4");
            this.btnFile.Id = 6;
            this.btnFile.Name = "btnFile";
            // 
            // btnConnect
            // 
            this.btnConnect.Caption = "Connect";
            this.btnConnect.CategoryGuid = new System.Guid("18fa184b-a1f2-4113-86e2-d0831df438b4");
            this.btnConnect.Id = 7;
            this.btnConnect.Name = "btnConnect";
            // 
            // btnInstrumentSetup
            // 
            this.btnInstrumentSetup.Caption = "Instrument Setup";
            this.btnInstrumentSetup.CategoryGuid = new System.Guid("18fa184b-a1f2-4113-86e2-d0831df438b4");
            this.btnInstrumentSetup.Id = 8;
            this.btnInstrumentSetup.Name = "btnInstrumentSetup";
            // 
            // btnRecording
            // 
            this.btnRecording.Caption = "Recording";
            this.btnRecording.CategoryGuid = new System.Guid("18fa184b-a1f2-4113-86e2-d0831df438b4");
            this.btnRecording.Id = 9;
            this.btnRecording.Name = "btnRecording";
            // 
            // btnGPS
            // 
            this.btnGPS.Caption = "GPS";
            this.btnGPS.CategoryGuid = new System.Guid("18fa184b-a1f2-4113-86e2-d0831df438b4");
            this.btnGPS.Id = 10;
            this.btnGPS.Name = "btnGPS";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Commands";
            this.barSubItem2.Id = 14;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStart),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStacking),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCommTest),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSetGainArmTrigger),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRequestData),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNoiseMonitor)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnStart
            // 
            this.btnStart.Caption = "Start";
            this.btnStart.CategoryGuid = new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6");
            this.btnStart.Id = 0;
            this.btnStart.Name = "btnStart";
            // 
            // btnStacking
            // 
            this.btnStacking.Caption = "Stacking";
            this.btnStacking.CategoryGuid = new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6");
            this.btnStacking.Id = 1;
            this.btnStacking.Name = "btnStacking";
            // 
            // btnCommTest
            // 
            this.btnCommTest.Caption = "Communication Test";
            this.btnCommTest.CategoryGuid = new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6");
            this.btnCommTest.Id = 2;
            this.btnCommTest.Name = "btnCommTest";
            // 
            // btnSetGainArmTrigger
            // 
            this.btnSetGainArmTrigger.Caption = "Set Gain and Arm Trigger";
            this.btnSetGainArmTrigger.CategoryGuid = new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6");
            this.btnSetGainArmTrigger.Id = 3;
            this.btnSetGainArmTrigger.Name = "btnSetGainArmTrigger";
            // 
            // btnRequestData
            // 
            this.btnRequestData.Caption = "Request Data";
            this.btnRequestData.CategoryGuid = new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6");
            this.btnRequestData.Id = 4;
            this.btnRequestData.Name = "btnRequestData";
            // 
            // btnNoiseMonitor
            // 
            this.btnNoiseMonitor.Caption = "Noise Monitor";
            this.btnNoiseMonitor.CategoryGuid = new System.Guid("95e3ba39-3764-46f6-ae12-5aa770d07bd6");
            this.btnNoiseMonitor.Id = 5;
            this.btnNoiseMonitor.Name = "btnNoiseMonitor";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerMain;
            this.barDockControlTop.Size = new System.Drawing.Size(745, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 651);
            this.barDockControlBottom.Manager = this.barManagerMain;
            this.barDockControlBottom.Size = new System.Drawing.Size(745, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManagerMain;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 631);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(745, 20);
            this.barDockControlRight.Manager = this.barManagerMain;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 631);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.checkEditHighPass);
            this.layoutControl1.Controls.Add(this.spinEditHighPassOrder);
            this.layoutControl1.Controls.Add(this.spinEditLowPassOrder);
            this.layoutControl1.Controls.Add(this.spinEditBandStopOrder);
            this.layoutControl1.Controls.Add(this.spinEditBandStopMax);
            this.layoutControl1.Controls.Add(this.spinEditBandStopMin);
            this.layoutControl1.Controls.Add(this.checkEditBandStop);
            this.layoutControl1.Controls.Add(this.spinEditTriggerSensitivity);
            this.layoutControl1.Controls.Add(this.spinEditRecordingTime);
            this.layoutControl1.Controls.Add(this.gaugeControlConnectivity);
            this.layoutControl1.Controls.Add(this.checkEditLowPass);
            this.layoutControl1.Controls.Add(this.spinEditHighPass);
            this.layoutControl1.Controls.Add(this.spinEditLowPass);
            this.layoutControl1.Controls.Add(this.checkEditApplyFilter);
            this.layoutControl1.Controls.Add(this.checkEditZeroPhaseFilter);
            this.layoutControl1.Controls.Add(this.checkEditDcRemoval);
            this.layoutControl1.Controls.Add(this.btnAutoSearchChannel);
            this.layoutControl1.Controls.Add(this.simpleButtonRemoveChannel);
            this.layoutControl1.Controls.Add(this.simpleButtonAddChannel);
            this.layoutControl1.Controls.Add(this.checkEditHideDisabledChannels);
            this.layoutControl1.Controls.Add(this.spinEditEnabledChannels);
            this.layoutControl1.Controls.Add(this.gridControlChannel);
            this.layoutControl1.Controls.Add(this.spinEditNumberOfChannels);
            this.layoutControl1.Controls.Add(this.comboBoxPort);
            this.layoutControl1.Controls.Add(this.simpleButtonReflection);
            this.layoutControl1.Controls.Add(this.simpleButtonRefraction);
            this.layoutControl1.Controls.Add(this.simpleButtonMASW);
            this.layoutControl1.Controls.Add(this.simpleButtonMicrotremor);
            this.layoutControl1.Controls.Add(this.simpleButtonRenameConfg);
            this.layoutControl1.Controls.Add(this.simpleButtonEditConfg);
            this.layoutControl1.Controls.Add(this.simpleButtonDeleteConfg);
            this.layoutControl1.Controls.Add(this.simpleButtonNewConfg);
            this.layoutControl1.Controls.Add(this.progressBarControl2);
            this.layoutControl1.Controls.Add(this.comboBoxEditSamplingRate);
            this.layoutControl1.Controls.Add(this.comboBoxEditConfg);
            this.layoutControl1.Controls.Add(this.simpleButtonConnect);
            this.layoutControl1.Controls.Add(this.progressBarBattery);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 136);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(786, 341, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(745, 488);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // checkEditHighPass
            // 
            this.checkEditHighPass.Location = new System.Drawing.Point(24, 461);
            this.checkEditHighPass.MenuManager = this.barManagerMain;
            this.checkEditHighPass.Name = "checkEditHighPass";
            this.checkEditHighPass.Properties.Caption = "High Pass";
            this.checkEditHighPass.Size = new System.Drawing.Size(86, 19);
            this.checkEditHighPass.StyleController = this.layoutControl1;
            this.checkEditHighPass.TabIndex = 48;
            this.checkEditHighPass.CheckedChanged += new System.EventHandler(this.checkEditHighPass_CheckedChanged);
            // 
            // spinEditHighPassOrder
            // 
            this.spinEditHighPassOrder.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditHighPassOrder.Enabled = false;
            this.spinEditHighPassOrder.Location = new System.Drawing.Point(294, 461);
            this.spinEditHighPassOrder.MenuManager = this.barManagerMain;
            this.spinEditHighPassOrder.Name = "spinEditHighPassOrder";
            this.spinEditHighPassOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditHighPassOrder.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditHighPassOrder.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditHighPassOrder.Size = new System.Drawing.Size(86, 20);
            this.spinEditHighPassOrder.StyleController = this.layoutControl1;
            this.spinEditHighPassOrder.TabIndex = 47;
            // 
            // spinEditLowPassOrder
            // 
            this.spinEditLowPassOrder.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spinEditLowPassOrder.Enabled = false;
            this.spinEditLowPassOrder.Location = new System.Drawing.Point(294, 437);
            this.spinEditLowPassOrder.MenuManager = this.barManagerMain;
            this.spinEditLowPassOrder.Name = "spinEditLowPassOrder";
            this.spinEditLowPassOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLowPassOrder.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditLowPassOrder.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditLowPassOrder.Size = new System.Drawing.Size(86, 20);
            this.spinEditLowPassOrder.StyleController = this.layoutControl1;
            this.spinEditLowPassOrder.TabIndex = 46;
            // 
            // spinEditBandStopOrder
            // 
            this.spinEditBandStopOrder.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spinEditBandStopOrder.Enabled = false;
            this.spinEditBandStopOrder.Location = new System.Drawing.Point(294, 413);
            this.spinEditBandStopOrder.MenuManager = this.barManagerMain;
            this.spinEditBandStopOrder.Name = "spinEditBandStopOrder";
            this.spinEditBandStopOrder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditBandStopOrder.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditBandStopOrder.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditBandStopOrder.Size = new System.Drawing.Size(86, 20);
            this.spinEditBandStopOrder.StyleController = this.layoutControl1;
            this.spinEditBandStopOrder.TabIndex = 45;
            // 
            // spinEditBandStopMax
            // 
            this.spinEditBandStopMax.EditValue = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.spinEditBandStopMax.Enabled = false;
            this.spinEditBandStopMax.Location = new System.Drawing.Point(204, 413);
            this.spinEditBandStopMax.MenuManager = this.barManagerMain;
            this.spinEditBandStopMax.Name = "spinEditBandStopMax";
            this.spinEditBandStopMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditBandStopMax.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditBandStopMax.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditBandStopMax.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditBandStopMax.Size = new System.Drawing.Size(86, 20);
            this.spinEditBandStopMax.StyleController = this.layoutControl1;
            this.spinEditBandStopMax.TabIndex = 44;
            // 
            // spinEditBandStopMin
            // 
            this.spinEditBandStopMin.EditValue = new decimal(new int[] {
            49,
            0,
            0,
            0});
            this.spinEditBandStopMin.Enabled = false;
            this.spinEditBandStopMin.Location = new System.Drawing.Point(114, 413);
            this.spinEditBandStopMin.MenuManager = this.barManagerMain;
            this.spinEditBandStopMin.Name = "spinEditBandStopMin";
            this.spinEditBandStopMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditBandStopMin.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditBandStopMin.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditBandStopMin.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditBandStopMin.Size = new System.Drawing.Size(86, 20);
            this.spinEditBandStopMin.StyleController = this.layoutControl1;
            this.spinEditBandStopMin.TabIndex = 43;
            // 
            // checkEditBandStop
            // 
            this.checkEditBandStop.Location = new System.Drawing.Point(24, 413);
            this.checkEditBandStop.MenuManager = this.barManagerMain;
            this.checkEditBandStop.Name = "checkEditBandStop";
            this.checkEditBandStop.Properties.Caption = "Band Stop";
            this.checkEditBandStop.Size = new System.Drawing.Size(86, 19);
            this.checkEditBandStop.StyleController = this.layoutControl1;
            this.checkEditBandStop.TabIndex = 42;
            this.checkEditBandStop.CheckedChanged += new System.EventHandler(this.checkEditBandStop_CheckedChanged);
            // 
            // spinEditTriggerSensitivity
            // 
            this.spinEditTriggerSensitivity.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEditTriggerSensitivity.Location = new System.Drawing.Point(293, 204);
            this.spinEditTriggerSensitivity.MenuManager = this.barManagerMain;
            this.spinEditTriggerSensitivity.Name = "spinEditTriggerSensitivity";
            this.spinEditTriggerSensitivity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditTriggerSensitivity.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEditTriggerSensitivity.Properties.MinValue = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.spinEditTriggerSensitivity.Size = new System.Drawing.Size(87, 20);
            this.spinEditTriggerSensitivity.StyleController = this.layoutControl1;
            this.spinEditTriggerSensitivity.TabIndex = 41;
            // 
            // spinEditRecordingTime
            // 
            this.spinEditRecordingTime.EditValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinEditRecordingTime.Location = new System.Drawing.Point(113, 228);
            this.spinEditRecordingTime.MenuManager = this.barManagerMain;
            this.spinEditRecordingTime.Name = "spinEditRecordingTime";
            this.spinEditRecordingTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditRecordingTime.Size = new System.Drawing.Size(87, 20);
            this.spinEditRecordingTime.StyleController = this.layoutControl1;
            this.spinEditRecordingTime.TabIndex = 40;
            // 
            // gaugeControlConnectivity
            // 
            this.gaugeControlConnectivity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gaugeControlConnectivity.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.stateIndicatorGaugeConnctivity});
            this.gaugeControlConnectivity.Location = new System.Drawing.Point(280, 42);
            this.gaugeControlConnectivity.Name = "gaugeControlConnectivity";
            this.gaugeControlConnectivity.Size = new System.Drawing.Size(100, 64);
            this.gaugeControlConnectivity.TabIndex = 39;
            // 
            // stateIndicatorGaugeConnctivity
            // 
            this.stateIndicatorGaugeConnctivity.Bounds = new System.Drawing.Rectangle(6, 6, 88, 52);
            this.stateIndicatorGaugeConnctivity.Indicators.AddRange(new DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent[] {
            this.stateIndicatorComponent1});
            this.stateIndicatorGaugeConnctivity.Name = "stateIndicatorGaugeConnctivity";
            // 
            // stateIndicatorComponent1
            // 
            this.stateIndicatorComponent1.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(124F, 124F);
            this.stateIndicatorComponent1.Name = "stateIndicatorComponent1";
            this.stateIndicatorComponent1.Size = new System.Drawing.SizeF(200F, 200F);
            this.stateIndicatorComponent1.StateIndex = 3;
            indicatorState1.Name = "State1";
            indicatorState1.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight1;
            indicatorState2.Name = "State2";
            indicatorState2.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight2;
            indicatorState3.Name = "State3";
            indicatorState3.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight3;
            indicatorState4.Name = "State4";
            indicatorState4.ShapeType = DevExpress.XtraGauges.Core.Model.StateIndicatorShapeType.ElectricLight4;
            this.stateIndicatorComponent1.States.AddRange(new DevExpress.XtraGauges.Core.Model.IIndicatorState[] {
            indicatorState1,
            indicatorState2,
            indicatorState3,
            indicatorState4});
            // 
            // checkEditLowPass
            // 
            this.checkEditLowPass.Location = new System.Drawing.Point(24, 437);
            this.checkEditLowPass.MenuManager = this.barManagerMain;
            this.checkEditLowPass.Name = "checkEditLowPass";
            this.checkEditLowPass.Properties.Caption = "Low Pass";
            this.checkEditLowPass.Size = new System.Drawing.Size(86, 19);
            this.checkEditLowPass.StyleController = this.layoutControl1;
            this.checkEditLowPass.TabIndex = 37;
            this.checkEditLowPass.CheckedChanged += new System.EventHandler(this.checkEditLowPass_CheckedChanged);
            // 
            // spinEditHighPass
            // 
            this.spinEditHighPass.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditHighPass.Enabled = false;
            this.spinEditHighPass.Location = new System.Drawing.Point(114, 461);
            this.spinEditHighPass.MenuManager = this.barManagerMain;
            this.spinEditHighPass.Name = "spinEditHighPass";
            this.spinEditHighPass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditHighPass.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditHighPass.Size = new System.Drawing.Size(176, 20);
            this.spinEditHighPass.StyleController = this.layoutControl1;
            this.spinEditHighPass.TabIndex = 33;
            // 
            // spinEditLowPass
            // 
            this.spinEditLowPass.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditLowPass.Enabled = false;
            this.spinEditLowPass.Location = new System.Drawing.Point(114, 437);
            this.spinEditLowPass.MenuManager = this.barManagerMain;
            this.spinEditLowPass.Name = "spinEditLowPass";
            this.spinEditLowPass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditLowPass.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditLowPass.Size = new System.Drawing.Size(176, 20);
            this.spinEditLowPass.StyleController = this.layoutControl1;
            this.spinEditLowPass.TabIndex = 32;
            // 
            // checkEditApplyFilter
            // 
            this.checkEditApplyFilter.Location = new System.Drawing.Point(272, 364);
            this.checkEditApplyFilter.MenuManager = this.barManagerMain;
            this.checkEditApplyFilter.Name = "checkEditApplyFilter";
            this.checkEditApplyFilter.Properties.Caption = "Apply Digital Filter";
            this.checkEditApplyFilter.Size = new System.Drawing.Size(108, 19);
            this.checkEditApplyFilter.StyleController = this.layoutControl1;
            this.checkEditApplyFilter.TabIndex = 30;
            // 
            // checkEditZeroPhaseFilter
            // 
            this.checkEditZeroPhaseFilter.Location = new System.Drawing.Point(149, 364);
            this.checkEditZeroPhaseFilter.MenuManager = this.barManagerMain;
            this.checkEditZeroPhaseFilter.Name = "checkEditZeroPhaseFilter";
            this.checkEditZeroPhaseFilter.Properties.Caption = "Zero Phase Filter";
            this.checkEditZeroPhaseFilter.Size = new System.Drawing.Size(119, 19);
            this.checkEditZeroPhaseFilter.StyleController = this.layoutControl1;
            this.checkEditZeroPhaseFilter.TabIndex = 29;
            // 
            // checkEditDcRemoval
            // 
            this.checkEditDcRemoval.EditValue = true;
            this.checkEditDcRemoval.Location = new System.Drawing.Point(24, 364);
            this.checkEditDcRemoval.MenuManager = this.barManagerMain;
            this.checkEditDcRemoval.Name = "checkEditDcRemoval";
            this.checkEditDcRemoval.Properties.Caption = "DC Removal";
            this.checkEditDcRemoval.Size = new System.Drawing.Size(121, 19);
            this.checkEditDcRemoval.StyleController = this.layoutControl1;
            this.checkEditDcRemoval.TabIndex = 28;
            // 
            // btnAutoSearchChannel
            // 
            this.btnAutoSearchChannel.Location = new System.Drawing.Point(408, 139);
            this.btnAutoSearchChannel.Name = "btnAutoSearchChannel";
            this.btnAutoSearchChannel.Size = new System.Drawing.Size(296, 22);
            this.btnAutoSearchChannel.StyleController = this.layoutControl1;
            this.btnAutoSearchChannel.TabIndex = 27;
            this.btnAutoSearchChannel.Text = "Auto Search";
            this.btnAutoSearchChannel.Click += new System.EventHandler(this.btnAutoSearchChannel_Click);
            // 
            // simpleButtonRemoveChannel
            // 
            this.simpleButtonRemoveChannel.Location = new System.Drawing.Point(542, 113);
            this.simpleButtonRemoveChannel.Name = "simpleButtonRemoveChannel";
            this.simpleButtonRemoveChannel.Size = new System.Drawing.Size(162, 22);
            this.simpleButtonRemoveChannel.StyleController = this.layoutControl1;
            this.simpleButtonRemoveChannel.TabIndex = 26;
            this.simpleButtonRemoveChannel.Text = "Remove";
            this.simpleButtonRemoveChannel.Click += new System.EventHandler(this.simpleButtonRemoveChannel_Click);
            // 
            // simpleButtonAddChannel
            // 
            this.simpleButtonAddChannel.Location = new System.Drawing.Point(408, 113);
            this.simpleButtonAddChannel.Name = "simpleButtonAddChannel";
            this.simpleButtonAddChannel.Size = new System.Drawing.Size(130, 22);
            this.simpleButtonAddChannel.StyleController = this.layoutControl1;
            this.simpleButtonAddChannel.TabIndex = 25;
            this.simpleButtonAddChannel.Text = "Add";
            this.simpleButtonAddChannel.Click += new System.EventHandler(this.simpleButtonAddChannel_Click);
            // 
            // checkEditHideDisabledChannels
            // 
            this.checkEditHideDisabledChannels.Location = new System.Drawing.Point(408, 90);
            this.checkEditHideDisabledChannels.MenuManager = this.barManagerMain;
            this.checkEditHideDisabledChannels.Name = "checkEditHideDisabledChannels";
            this.checkEditHideDisabledChannels.Properties.Caption = "Hide Disabled Channels";
            this.checkEditHideDisabledChannels.Size = new System.Drawing.Size(296, 19);
            this.checkEditHideDisabledChannels.StyleController = this.layoutControl1;
            this.checkEditHideDisabledChannels.TabIndex = 24;
            // 
            // spinEditEnabledChannels
            // 
            this.spinEditEnabledChannels.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditEnabledChannels.Location = new System.Drawing.Point(497, 66);
            this.spinEditEnabledChannels.MenuManager = this.barManagerMain;
            this.spinEditEnabledChannels.Name = "spinEditEnabledChannels";
            this.spinEditEnabledChannels.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditEnabledChannels.Size = new System.Drawing.Size(207, 20);
            this.spinEditEnabledChannels.StyleController = this.layoutControl1;
            this.spinEditEnabledChannels.TabIndex = 23;
            // 
            // gridControlChannel
            // 
            this.gridControlChannel.Location = new System.Drawing.Point(408, 165);
            this.gridControlChannel.MainView = this.gridViewChannel;
            this.gridControlChannel.MenuManager = this.barManagerMain;
            this.gridControlChannel.Name = "gridControlChannel";
            this.gridControlChannel.Size = new System.Drawing.Size(296, 316);
            this.gridControlChannel.TabIndex = 22;
            this.gridControlChannel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewChannel});
            // 
            // gridViewChannel
            // 
            this.gridViewChannel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnChannel,
            this.gridColumnGain,
            this.gridColumnX,
            this.gridColumnY,
            this.gridColumnZ});
            this.gridViewChannel.GridControl = this.gridControlChannel;
            this.gridViewChannel.Name = "gridViewChannel";
            this.gridViewChannel.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "ID";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            this.gridColumnId.Visible = true;
            this.gridColumnId.VisibleIndex = 0;
            this.gridColumnId.Width = 28;
            // 
            // gridColumnChannel
            // 
            this.gridColumnChannel.Caption = "Channel";
            this.gridColumnChannel.FieldName = "Channel";
            this.gridColumnChannel.Name = "gridColumnChannel";
            this.gridColumnChannel.Visible = true;
            this.gridColumnChannel.VisibleIndex = 1;
            this.gridColumnChannel.Width = 51;
            // 
            // gridColumnGain
            // 
            this.gridColumnGain.Caption = "Gain (db)";
            this.gridColumnGain.FieldName = "Gain";
            this.gridColumnGain.Name = "gridColumnGain";
            this.gridColumnGain.Visible = true;
            this.gridColumnGain.VisibleIndex = 2;
            this.gridColumnGain.Width = 60;
            // 
            // gridColumnX
            // 
            this.gridColumnX.Caption = "X";
            this.gridColumnX.FieldName = "X";
            this.gridColumnX.Name = "gridColumnX";
            this.gridColumnX.Visible = true;
            this.gridColumnX.VisibleIndex = 3;
            this.gridColumnX.Width = 44;
            // 
            // gridColumnY
            // 
            this.gridColumnY.Caption = "Y";
            this.gridColumnY.FieldName = "Y";
            this.gridColumnY.Name = "gridColumnY";
            this.gridColumnY.Visible = true;
            this.gridColumnY.VisibleIndex = 4;
            this.gridColumnY.Width = 44;
            // 
            // gridColumnZ
            // 
            this.gridColumnZ.Caption = "Z";
            this.gridColumnZ.FieldName = "Z";
            this.gridColumnZ.Name = "gridColumnZ";
            this.gridColumnZ.Visible = true;
            this.gridColumnZ.VisibleIndex = 5;
            this.gridColumnZ.Width = 55;
            // 
            // spinEditNumberOfChannels
            // 
            this.spinEditNumberOfChannels.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditNumberOfChannels.Location = new System.Drawing.Point(497, 42);
            this.spinEditNumberOfChannels.MenuManager = this.barManagerMain;
            this.spinEditNumberOfChannels.Name = "spinEditNumberOfChannels";
            this.spinEditNumberOfChannels.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditNumberOfChannels.Size = new System.Drawing.Size(207, 20);
            this.spinEditNumberOfChannels.StyleController = this.layoutControl1;
            this.spinEditNumberOfChannels.TabIndex = 21;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.EditValue = "Select";
            this.comboBoxPort.Location = new System.Drawing.Point(113, 42);
            this.comboBoxPort.MenuManager = this.barManagerMain;
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxPort.Properties.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.comboBoxPort.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxPort.Size = new System.Drawing.Size(163, 20);
            this.comboBoxPort.StyleController = this.layoutControl1;
            this.comboBoxPort.TabIndex = 20;
            // 
            // simpleButtonReflection
            // 
            this.simpleButtonReflection.Location = new System.Drawing.Point(204, 296);
            this.simpleButtonReflection.Name = "simpleButtonReflection";
            this.simpleButtonReflection.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonReflection.StyleController = this.layoutControl1;
            this.simpleButtonReflection.TabIndex = 19;
            this.simpleButtonReflection.Text = "Reflection";
            // 
            // simpleButtonRefraction
            // 
            this.simpleButtonRefraction.Location = new System.Drawing.Point(24, 296);
            this.simpleButtonRefraction.Name = "simpleButtonRefraction";
            this.simpleButtonRefraction.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonRefraction.StyleController = this.layoutControl1;
            this.simpleButtonRefraction.TabIndex = 18;
            this.simpleButtonRefraction.Text = "Refraction";
            // 
            // simpleButtonMASW
            // 
            this.simpleButtonMASW.Location = new System.Drawing.Point(204, 270);
            this.simpleButtonMASW.Name = "simpleButtonMASW";
            this.simpleButtonMASW.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonMASW.StyleController = this.layoutControl1;
            this.simpleButtonMASW.TabIndex = 17;
            this.simpleButtonMASW.Text = "MASW";
            // 
            // simpleButtonMicrotremor
            // 
            this.simpleButtonMicrotremor.Location = new System.Drawing.Point(24, 270);
            this.simpleButtonMicrotremor.Name = "simpleButtonMicrotremor";
            this.simpleButtonMicrotremor.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonMicrotremor.StyleController = this.layoutControl1;
            this.simpleButtonMicrotremor.TabIndex = 16;
            this.simpleButtonMicrotremor.Text = "Microtremor";
            // 
            // simpleButtonRenameConfg
            // 
            this.simpleButtonRenameConfg.Location = new System.Drawing.Point(204, 178);
            this.simpleButtonRenameConfg.Name = "simpleButtonRenameConfg";
            this.simpleButtonRenameConfg.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonRenameConfg.StyleController = this.layoutControl1;
            this.simpleButtonRenameConfg.TabIndex = 15;
            this.simpleButtonRenameConfg.Text = "Rename Configuration";
            // 
            // simpleButtonEditConfg
            // 
            this.simpleButtonEditConfg.Location = new System.Drawing.Point(204, 152);
            this.simpleButtonEditConfg.Name = "simpleButtonEditConfg";
            this.simpleButtonEditConfg.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonEditConfg.StyleController = this.layoutControl1;
            this.simpleButtonEditConfg.TabIndex = 14;
            this.simpleButtonEditConfg.Text = "Edit Configuration";
            // 
            // simpleButtonDeleteConfg
            // 
            this.simpleButtonDeleteConfg.Location = new System.Drawing.Point(24, 178);
            this.simpleButtonDeleteConfg.Name = "simpleButtonDeleteConfg";
            this.simpleButtonDeleteConfg.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonDeleteConfg.StyleController = this.layoutControl1;
            this.simpleButtonDeleteConfg.TabIndex = 13;
            this.simpleButtonDeleteConfg.Text = "Delete Configuration";
            // 
            // simpleButtonNewConfg
            // 
            this.simpleButtonNewConfg.Location = new System.Drawing.Point(24, 152);
            this.simpleButtonNewConfg.Name = "simpleButtonNewConfg";
            this.simpleButtonNewConfg.Size = new System.Drawing.Size(176, 22);
            this.simpleButtonNewConfg.StyleController = this.layoutControl1;
            this.simpleButtonNewConfg.TabIndex = 12;
            this.simpleButtonNewConfg.Text = "New Configuration";
            // 
            // progressBarControl2
            // 
            this.progressBarControl2.Location = new System.Drawing.Point(113, 252);
            this.progressBarControl2.MenuManager = this.barManagerMain;
            this.progressBarControl2.Name = "progressBarControl2";
            this.progressBarControl2.Size = new System.Drawing.Size(267, 14);
            this.progressBarControl2.StyleController = this.layoutControl1;
            this.progressBarControl2.TabIndex = 11;
            // 
            // comboBoxEditSamplingRate
            // 
            this.comboBoxEditSamplingRate.Location = new System.Drawing.Point(293, 228);
            this.comboBoxEditSamplingRate.MenuManager = this.barManagerMain;
            this.comboBoxEditSamplingRate.Name = "comboBoxEditSamplingRate";
            this.comboBoxEditSamplingRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSamplingRate.Properties.Items.AddRange(new object[] {
            "3750",
            "2000",
            "1000",
            "500",
            "100",
            "60",
            "50"});
            this.comboBoxEditSamplingRate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSamplingRate.Size = new System.Drawing.Size(87, 20);
            this.comboBoxEditSamplingRate.StyleController = this.layoutControl1;
            this.comboBoxEditSamplingRate.TabIndex = 9;
            // 
            // comboBoxEditConfg
            // 
            this.comboBoxEditConfg.Location = new System.Drawing.Point(113, 204);
            this.comboBoxEditConfg.MenuManager = this.barManagerMain;
            this.comboBoxEditConfg.Name = "comboBoxEditConfg";
            this.comboBoxEditConfg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditConfg.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditConfg.Size = new System.Drawing.Size(87, 20);
            this.comboBoxEditConfg.StyleController = this.layoutControl1;
            this.comboBoxEditConfg.TabIndex = 6;
            // 
            // simpleButtonConnect
            // 
            this.simpleButtonConnect.Location = new System.Drawing.Point(24, 84);
            this.simpleButtonConnect.Name = "simpleButtonConnect";
            this.simpleButtonConnect.Size = new System.Drawing.Size(252, 22);
            this.simpleButtonConnect.StyleController = this.layoutControl1;
            this.simpleButtonConnect.TabIndex = 5;
            this.simpleButtonConnect.Text = "Connect";
            this.simpleButtonConnect.Click += new System.EventHandler(this.simpleButtonConnect_Click);
            // 
            // progressBarBattery
            // 
            this.progressBarBattery.Location = new System.Drawing.Point(113, 66);
            this.progressBarBattery.MenuManager = this.barManagerMain;
            this.progressBarBattery.Name = "progressBarBattery";
            this.progressBarBattery.Size = new System.Drawing.Size(163, 14);
            this.progressBarBattery.StyleController = this.layoutControl1;
            this.progressBarBattery.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup4,
            this.layoutControlGroup3,
            this.layoutControlGroup5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(728, 505);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem10,
            this.layoutControlItem12,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 110);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(384, 212);
            this.layoutControlGroup2.Text = "Acquisition Setup";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.comboBoxEditConfg;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem3.Text = "Configuration";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.progressBarControl2;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(360, 18);
            this.layoutControlItem8.Text = "Used Memory";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.simpleButtonMicrotremor;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 118);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.simpleButtonMASW;
            this.layoutControlItem14.Location = new System.Drawing.Point(180, 118);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.simpleButtonRefraction;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.simpleButtonReflection;
            this.layoutControlItem16.Location = new System.Drawing.Point(180, 144);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.simpleButtonNewConfg;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.simpleButtonEditConfg;
            this.layoutControlItem11.Location = new System.Drawing.Point(180, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.simpleButtonDeleteConfg;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.simpleButtonRenameConfg;
            this.layoutControlItem12.Location = new System.Drawing.Point(180, 26);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(180, 26);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.spinEditRecordingTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem4.Text = "Recording Time";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.comboBoxEditSamplingRate;
            this.layoutControlItem6.Location = new System.Drawing.Point(180, 76);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem6.Text = "Sampling Rate";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spinEditTriggerSensitivity;
            this.layoutControlItem5.Location = new System.Drawing.Point(180, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem5.Text = "Trigger Sensitivity";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem20,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.layoutControlItem24,
            this.layoutControlItem19});
            this.layoutControlGroup4.Location = new System.Drawing.Point(384, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(324, 485);
            this.layoutControlGroup4.Text = "Channel Setting";
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.spinEditNumberOfChannels;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem18.Text = "N. Channels";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.spinEditEnabledChannels;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem20.Text = "Enabled";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.checkEditHideDisabledChannels;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(300, 23);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.simpleButtonAddChannel;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 71);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(134, 26);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.simpleButtonRemoveChannel;
            this.layoutControlItem23.Location = new System.Drawing.Point(134, 71);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(166, 26);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.btnAutoSearchChannel;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(300, 26);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.gridControlChannel;
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(300, 320);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17,
            this.layoutControlItem1,
            this.layoutControlItem34,
            this.layoutControlItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(384, 110);
            this.layoutControlGroup3.Text = "Device Setup";
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.comboBoxPort;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(256, 24);
            this.layoutControlItem17.Text = "Port";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.progressBarBattery;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(256, 18);
            this.layoutControlItem1.Text = "Battery";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.gaugeControlConnectivity;
            this.layoutControlItem34.Location = new System.Drawing.Point(256, 0);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(104, 68);
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonConnect;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(256, 26);
            this.layoutControlItem2.Text = "Communication";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25,
            this.layoutControlItem26,
            this.layoutControlItem27,
            this.layoutControlItem29,
            this.layoutControlItem28,
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.layoutControlItem35,
            this.layoutControlItem36,
            this.layoutControlItem31,
            this.layoutControlItem32,
            this.layoutControlItem30,
            this.layoutControlItem33,
            this.layoutControlItem37});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 322);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(384, 163);
            this.layoutControlGroup5.Text = "Digital Filter";
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.checkEditDcRemoval;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(125, 23);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.checkEditZeroPhaseFilter;
            this.layoutControlItem26.Location = new System.Drawing.Point(125, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(123, 23);
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.checkEditApplyFilter;
            this.layoutControlItem27.Location = new System.Drawing.Point(248, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(112, 23);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.spinEditLowPass;
            this.layoutControlItem29.Location = new System.Drawing.Point(90, 73);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem29.Text = "Hz";
            this.layoutControlItem29.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.checkEditLowPass;
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(90, 24);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 23);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(360, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.checkEditBandStop;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(90, 40);
            this.layoutControlItem7.Text = " ";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.spinEditBandStopMin;
            this.layoutControlItem35.Location = new System.Drawing.Point(90, 33);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(90, 40);
            this.layoutControlItem35.Text = "Min (Hz)";
            this.layoutControlItem35.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.spinEditBandStopMax;
            this.layoutControlItem36.Location = new System.Drawing.Point(180, 33);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(90, 40);
            this.layoutControlItem36.Text = "Max (Hz)";
            this.layoutControlItem36.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.spinEditBandStopOrder;
            this.layoutControlItem31.Location = new System.Drawing.Point(270, 33);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(90, 40);
            this.layoutControlItem31.Text = "Order";
            this.layoutControlItem31.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.spinEditLowPassOrder;
            this.layoutControlItem32.Location = new System.Drawing.Point(270, 73);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(90, 24);
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.spinEditHighPass;
            this.layoutControlItem30.Location = new System.Drawing.Point(90, 97);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(180, 24);
            this.layoutControlItem30.Text = "Order";
            this.layoutControlItem30.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.spinEditHighPassOrder;
            this.layoutControlItem33.Location = new System.Drawing.Point(270, 97);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(90, 24);
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.checkEditHighPass;
            this.layoutControlItem37.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(90, 24);
            this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem37.TextVisible = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.AllowDrawArrow = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonStart,
            this.barButtonStacking,
            this.barButtonCommTest,
            this.barButtonSetGainArmTrigg,
            this.barButtonRequestData,
            this.barButtonSeismogram,
            this.barButtonInstSetup,
            this.barButtonRecording,
            this.barButtonGPS,
            this.barButtonClearMemory});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 20);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1,
            this.repositoryItemProgressBar1,
            this.repositoryItemSpinEdit1});
            this.ribbonControl1.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Center;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(745, 116);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // barButtonStart
            // 
            this.barButtonStart.Caption = "Start";
            this.barButtonStart.Id = 1;
            this.barButtonStart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonStart.ImageOptions.Image")));
            this.barButtonStart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonStart.ImageOptions.LargeImage")));
            this.barButtonStart.Name = "barButtonStart";
            this.barButtonStart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonStart_ItemClick);
            // 
            // barButtonStacking
            // 
            this.barButtonStacking.Caption = "Stacking";
            this.barButtonStacking.Id = 2;
            this.barButtonStacking.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonStacking.ImageOptions.Image")));
            this.barButtonStacking.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonStacking.ImageOptions.LargeImage")));
            this.barButtonStacking.Name = "barButtonStacking";
            // 
            // barButtonCommTest
            // 
            this.barButtonCommTest.Caption = "Comm Test";
            this.barButtonCommTest.Id = 3;
            this.barButtonCommTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonCommTest.ImageOptions.Image")));
            this.barButtonCommTest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonCommTest.ImageOptions.LargeImage")));
            this.barButtonCommTest.Name = "barButtonCommTest";
            this.barButtonCommTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonCommTest_ItemClick);
            // 
            // barButtonSetGainArmTrigg
            // 
            this.barButtonSetGainArmTrigg.Caption = "Set Gain and Arm Trigger";
            this.barButtonSetGainArmTrigg.Id = 4;
            this.barButtonSetGainArmTrigg.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonSetGainArmTrigg.ImageOptions.Image")));
            this.barButtonSetGainArmTrigg.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonSetGainArmTrigg.ImageOptions.LargeImage")));
            this.barButtonSetGainArmTrigg.Name = "barButtonSetGainArmTrigg";
            this.barButtonSetGainArmTrigg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSetGainArmTrigg_ItemClick);
            // 
            // barButtonRequestData
            // 
            this.barButtonRequestData.Caption = "Request Data";
            this.barButtonRequestData.Id = 5;
            this.barButtonRequestData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonRequestData.ImageOptions.Image")));
            this.barButtonRequestData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonRequestData.ImageOptions.LargeImage")));
            this.barButtonRequestData.Name = "barButtonRequestData";
            this.barButtonRequestData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonRequestData_ItemClick);
            // 
            // barButtonSeismogram
            // 
            this.barButtonSeismogram.Caption = "Seismogram";
            this.barButtonSeismogram.Id = 6;
            this.barButtonSeismogram.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonSeismogram.ImageOptions.Image")));
            this.barButtonSeismogram.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonSeismogram.ImageOptions.LargeImage")));
            this.barButtonSeismogram.Name = "barButtonSeismogram";
            this.barButtonSeismogram.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSeismogram_ItemClick);
            // 
            // barButtonInstSetup
            // 
            this.barButtonInstSetup.Caption = "Instrument Setup";
            this.barButtonInstSetup.Id = 7;
            this.barButtonInstSetup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonInstSetup.ImageOptions.Image")));
            this.barButtonInstSetup.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonInstSetup.ImageOptions.LargeImage")));
            this.barButtonInstSetup.Name = "barButtonInstSetup";
            // 
            // barButtonRecording
            // 
            this.barButtonRecording.Caption = "Recording";
            this.barButtonRecording.Id = 8;
            this.barButtonRecording.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonRecording.ImageOptions.Image")));
            this.barButtonRecording.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonRecording.ImageOptions.LargeImage")));
            this.barButtonRecording.Name = "barButtonRecording";
            // 
            // barButtonGPS
            // 
            this.barButtonGPS.Caption = "GPS";
            this.barButtonGPS.Id = 10;
            this.barButtonGPS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonGPS.ImageOptions.Image")));
            this.barButtonGPS.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonGPS.ImageOptions.LargeImage")));
            this.barButtonGPS.Name = "barButtonGPS";
            // 
            // barButtonClearMemory
            // 
            this.barButtonClearMemory.Caption = "Clear Data";
            this.barButtonClearMemory.Id = 14;
            this.barButtonClearMemory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonClearMemory.ImageOptions.Image")));
            this.barButtonClearMemory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonClearMemory.ImageOptions.LargeImage")));
            this.barButtonClearMemory.Name = "barButtonClearMemory";
            this.barButtonClearMemory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonClearMemory_ItemClick);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ConvertedFromBarManager";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonInstSetup);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonRecording);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonGPS);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Setup";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonStart);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonStacking);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonCommTest);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonClearMemory);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonSetGainArmTrigg);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonRequestData);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonSeismogram);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Commands";
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 624);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(745, 27);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 651);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditHighPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditHighPassOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLowPassOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBandStopOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBandStopMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditBandStopMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditBandStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTriggerSensitivity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditRecordingTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorGaugeConnctivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateIndicatorComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLowPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditHighPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditLowPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditApplyFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditZeroPhaseFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDcRemoval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditHideDisabledChannels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditEnabledChannels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditNumberOfChannels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSamplingRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditConfg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarBattery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnStart;
        private DevExpress.XtraBars.BarButtonItem btnStacking;
        private DevExpress.XtraBars.BarButtonItem btnCommTest;
        private DevExpress.XtraBars.BarButtonItem btnSetGainArmTrigger;
        private DevExpress.XtraBars.BarButtonItem btnRequestData;
        private DevExpress.XtraBars.BarButtonItem btnNoiseMonitor;
        private DevExpress.XtraBars.BarButtonItem btnFile;
        private DevExpress.XtraBars.BarButtonItem btnConnect;
        private DevExpress.XtraBars.BarButtonItem btnInstrumentSetup;
        private DevExpress.XtraBars.BarButtonItem btnRecording;
        private DevExpress.XtraBars.BarButtonItem btnGPS;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnAutoSearchChannel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRemoveChannel;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAddChannel;
        private DevExpress.XtraEditors.CheckEdit checkEditHideDisabledChannels;
        private DevExpress.XtraEditors.SpinEdit spinEditEnabledChannels;
        private DevExpress.XtraGrid.GridControl gridControlChannel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChannel;
        private DevExpress.XtraEditors.SpinEdit spinEditNumberOfChannels;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxPort;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReflection;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefraction;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMASW;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMicrotremor;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRenameConfg;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEditConfg;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteConfg;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNewConfg;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSamplingRate;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditConfg;
        private DevExpress.XtraEditors.SimpleButton simpleButtonConnect;
        private DevExpress.XtraEditors.ProgressBarControl progressBarBattery;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.CheckEdit checkEditApplyFilter;
        private DevExpress.XtraEditors.CheckEdit checkEditZeroPhaseFilter;
        private DevExpress.XtraEditors.CheckEdit checkEditDcRemoval;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraEditors.SpinEdit spinEditHighPass;
        private DevExpress.XtraEditors.SpinEdit spinEditLowPass;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraEditors.CheckEdit checkEditLowPass;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControlConnectivity;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorGauge stateIndicatorGaugeConnctivity;
        private DevExpress.XtraGauges.Win.Gauges.State.StateIndicatorComponent stateIndicatorComponent1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem barButtonStart;
        private DevExpress.XtraBars.BarButtonItem barButtonStacking;
        private DevExpress.XtraBars.BarButtonItem barButtonCommTest;
        private DevExpress.XtraBars.BarButtonItem barButtonSetGainArmTrigg;
        private DevExpress.XtraBars.BarButtonItem barButtonRequestData;
        private DevExpress.XtraBars.BarButtonItem barButtonSeismogram;
        private DevExpress.XtraBars.BarButtonItem barButtonInstSetup;
        private DevExpress.XtraBars.BarButtonItem barButtonRecording;
        private DevExpress.XtraBars.BarButtonItem barButtonGPS;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnChannel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnX;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnY;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnZ;
        private DevExpress.XtraEditors.SpinEdit spinEditRecordingTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonClearMemory;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.SpinEdit spinEditTriggerSensitivity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.SpinEdit spinEditBandStopMin;
        private DevExpress.XtraEditors.CheckEdit checkEditBandStop;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraEditors.SpinEdit spinEditBandStopMax;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraEditors.SpinEdit spinEditLowPassOrder;
        private DevExpress.XtraEditors.SpinEdit spinEditBandStopOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraEditors.CheckEdit checkEditHighPass;
        private DevExpress.XtraEditors.SpinEdit spinEditHighPassOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
    }
}

