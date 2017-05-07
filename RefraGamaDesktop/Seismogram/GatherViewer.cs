using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
    }
}