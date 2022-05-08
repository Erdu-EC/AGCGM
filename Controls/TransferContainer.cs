using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AGCGM.Behavior.Task;

namespace GCGM.Controls
{
    public partial class TransferContainer : UserControl
    {
        public int TaskFinished { get; set; }
        public int TaskError { get; set; }
        public int TaskCancel { get; set; }

        public string SourcePath { get; }
        public string DestinationPath { get; }

        public ControlCollection Items { get => ItemsPanel.Controls; }

        public TransferContainer(string source, string sourceLabel, string destination, string destLabel)
        {
            InitializeComponent();

            SourcePath = source;
            DestinationPath = destination;

            LBSource.Text = sourceLabel;
            Tips.SetToolTip(LBSource, source);
            LBDestination.Text = destLabel;
            Tips.SetToolTip(LBDestination, destination);

            ItemsPanel.Controls.Clear();
            ItemsPanel.RowCount = 1;
            Height -= 36;
        }

        public void AddTransferItem(TransferItem item)
        {
            if (Items.Count > 0 && Items.Count < 3)
                Height += item.Height;

            Items.Add(item);
        }

        public void RemoveTransferItem(TransferItem item)
        {
            Items.Remove(item);

            if (Items.Count > 0 && Items.Count < 3)
                Height -= item.Height;
        }

        private void BTPause_Click(object sender, EventArgs e)
        {
            if (BTPause.Text == "Pausar")
            {
                foreach (var item in ItemsPanel.Controls.Cast<TransferItem>().ToArray())
                {
                    TransferTask task = item.Tag as TransferTask;
                    if (!task.IsCancelRequested && !task.IsFinished) task.Pause();
                }

                BTPause.Text = "Reanudar";
            }
            else
            {
                foreach (var item in ItemsPanel.Controls.Cast<TransferItem>().ToArray())
                {
                    TransferTask task = item.Tag as TransferTask;
                    if (!task.IsCancelRequested && !task.IsFinished) task.Resume();
                }
                    

                BTPause.Text = "Pausar";
            }
        }

        private void BTStop_Click(object sender, EventArgs e)
        {
            foreach (var item in ItemsPanel.Controls.Cast<TransferItem>().ToArray())
            {
                TransferTask task = item.Tag as TransferTask;
                task.Cancel();
                task.Resume();
            }
                
        }

        public void RefreshCountersOf(TransferTask[] tasks)
        {
            foreach (var task in tasks)
            {
                if (task.IsFaulted)
                    TaskError--;
                else if (task.IsCanceled)
                    TaskCancel--;
                else if (task.IsFinished)
                    TaskFinished--;
            }
        }
        public void CountTransfers()
        {
            TransferGroup.Text = $"Transfiriendo ({TaskFinished + TaskError + TaskCancel}/{Items.Count})...";
            LBState.Text = $"Exito: {TaskFinished} | Error: {TaskError} | Cancelado: {TaskCancel}";
        }
    }
}
