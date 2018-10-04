using System.Windows.Forms;
using DevExpress.XtraEditors;
using Refragama.io;
using RefraGama.Core;

namespace RefraGama.Seismogram
{
    public partial class GatherViewer : DevExpress.XtraEditors.XtraForm
    {
        private readonly WaveformViewer _waveformViewer;
        public GatherViewer(ISeismicStream stream)
        {
            InitializeComponent();
            _waveformViewer = new WaveformViewer();
            _waveformViewer.UpdatePayload(stream);
            var newItem = layoutControlGroup1.AddItem();
            newItem.Control = _waveformViewer;
            newItem.TextVisible = false;
        }

        private void barButtonGvSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = @"Miniseed Files (*.mseed) | *.mseed " };
            var dlg = sfd.ShowDialog();

            if(dlg != DialogResult.OK) return;
            var stream = _waveformViewer.GetInnerStream();
            stream.Write(sfd.FileName,"mseed");
            XtraMessageBox.Show("Data Saved Successfully", "Save");
        }
    }
}