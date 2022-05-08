using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GCGM.Controls
{
    public partial class TransferContainer : UserControl
    {
        public string SourcePath { get; }
        public string DestinationPath { get; }

        public ControlCollection Items { get => ItemsPanel.Controls; }

        public TransferContainer(string source, string destination)
        {
            InitializeComponent();

            SourcePath = source;
            DestinationPath = destination;

            LBSource.Text = Path.GetFileName(source);
            Tips.SetToolTip(LBSource, source);
            LBDestination.Text = Path.GetFileName(destination);
            Tips.SetToolTip(LBDestination, destination);
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TransferItem1_Load(object sender, EventArgs e)
        {

        }
    }
}
