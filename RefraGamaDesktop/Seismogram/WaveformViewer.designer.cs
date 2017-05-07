namespace RefraGama.Seismogram
{
    partial class WaveformViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaveformViewer));
            this.hScrollBar1 = new DevExpress.XtraEditors.HScrollBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.zoomTrackBarControl1 = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.zoomTrackBarControl2 = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.extraOptionBar = new DevExpress.XtraBars.Bar();
            this.barButtonSaveStream = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.LargeChange = 100;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 245);
            this.hScrollBar1.Margin = new System.Windows.Forms.Padding(2);
            this.hScrollBar1.Maximum = 1000;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Opacity = 1F;
            this.hScrollBar1.Size = new System.Drawing.Size(475, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 222);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.zoomTrackBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.zoomTrackBarControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(475, 23);
            this.splitContainerControl1.SplitterPosition = 277;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.splitContainerControl1.Resize += new System.EventHandler(this.splitContainerControl1_Resize);
            // 
            // zoomTrackBarControl1
            // 
            this.zoomTrackBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomTrackBarControl1.EditValue = null;
            this.zoomTrackBarControl1.Location = new System.Drawing.Point(0, 0);
            this.zoomTrackBarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.zoomTrackBarControl1.Name = "zoomTrackBarControl1";
            this.zoomTrackBarControl1.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.zoomTrackBarControl1.Size = new System.Drawing.Size(277, 23);
            this.zoomTrackBarControl1.TabIndex = 0;
            this.zoomTrackBarControl1.ValueChanged += new System.EventHandler(this.zoomTrackBarControl1_ValueChanged);
            // 
            // zoomTrackBarControl2
            // 
            this.zoomTrackBarControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zoomTrackBarControl2.EditValue = null;
            this.zoomTrackBarControl2.Location = new System.Drawing.Point(0, 0);
            this.zoomTrackBarControl2.Margin = new System.Windows.Forms.Padding(2);
            this.zoomTrackBarControl2.Name = "zoomTrackBarControl2";
            this.zoomTrackBarControl2.Properties.Maximum = 999;
            this.zoomTrackBarControl2.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.zoomTrackBarControl2.Size = new System.Drawing.Size(193, 23);
            this.zoomTrackBarControl2.TabIndex = 0;
            this.zoomTrackBarControl2.ValueChanged += new System.EventHandler(this.zoomTrackBarControl2_ValueChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.extraOptionBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCheckItem1,
            this.barCheckItem2,
            this.barButtonSaveStream});
            this.barManager1.MainMenu = this.extraOptionBar;
            this.barManager1.MaxItemId = 11;
            // 
            // extraOptionBar
            // 
            this.extraOptionBar.BarName = "Main menu";
            this.extraOptionBar.DockCol = 0;
            this.extraOptionBar.DockRow = 0;
            this.extraOptionBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.extraOptionBar.FloatLocation = new System.Drawing.Point(109, 362);
            this.extraOptionBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonSaveStream, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.extraOptionBar.OptionsBar.MultiLine = true;
            this.extraOptionBar.OptionsBar.UseWholeRow = true;
            this.extraOptionBar.Text = "Main menu";
            // 
            // barButtonSaveStream
            // 
            this.barButtonSaveStream.Caption = "Save this stream";
            this.barButtonSaveStream.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonSaveStream.Glyph")));
            this.barButtonSaveStream.Id = 10;
            this.barButtonSaveStream.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonSaveStream.LargeGlyph")));
            this.barButtonSaveStream.Name = "barButtonSaveStream";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(475, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 262);
            this.barDockControlBottom.Size = new System.Drawing.Size(475, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 238);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(475, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 238);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "Delete Window";
            this.barCheckItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barCheckItem1.Glyph")));
            this.barCheckItem1.Id = 8;
            this.barCheckItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barCheckItem1.LargeGlyph")));
            this.barCheckItem1.Name = "barCheckItem1";
            this.barCheckItem1.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            this.barCheckItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_ItemClick);
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "Add Window";
            this.barCheckItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barCheckItem2.Glyph")));
            this.barCheckItem2.Id = 9;
            this.barCheckItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barCheckItem2.LargeGlyph")));
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // WaveformViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "WaveformViewer";
            this.Size = new System.Drawing.Size(475, 262);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBarControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.HScrollBar hScrollBar1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl1;
        private DevExpress.XtraEditors.ZoomTrackBarControl zoomTrackBarControl2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar extraOptionBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonSaveStream;
    }
}
