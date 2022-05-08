using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGCGM.Internal.Tools;

namespace GCGM.Controls
{
    public partial class TransferItem : UserControl
    {
        public string SourcePath { get; }
        public string DestinationPath { get; }

        private readonly ToolTip Tip;

        public TransferItem() { }
        public TransferItem(string source, string destination, Image banner, string name)
        {
            InitializeComponent();

            SourcePath = source;
            DestinationPath = destination;

            PBBanner.Image = banner;
            PBProgress.TextFormat = $"{name} | ({{0}}%)";

            Tip = new ToolTip()
            {
                IsBalloon = true,
                ToolTipTitle = "Transferencia:",
                ToolTipIcon = ToolTipIcon.Info
            };
            SetToolTip($"> De: {source}\n> Hacia: {destination}");
        }

        public string GetToolTip() => Tip.GetToolTip(this);
        public void SetToolTip(string tiptext)
        {
            Tip.RemoveAll();
            Tip.SetToolTip(this, tiptext);
            Tip.SetToolTip(PBBanner, tiptext);
            Tip.SetToolTip(PBProgress, tiptext);
        }

        public void ReportProgress(int progress)
        {
            Execute.RunForeground(this, () =>
            {
                if (progress <= 100 && progress > PBProgress.Value)
                    PBProgress.Value = progress;
            });
        }

        public void ReportPause()
        {
            Execute.RunForeground(this, () =>
            {
                PBProgress.State = ProgressBarEx.ProgressBarState.Paused;
            });
        }

        public void ReportResume()
        {
            Execute.RunForeground(this, () =>
            {
                PBProgress.State = ProgressBarEx.ProgressBarState.Normal;
            });
        }

        public void ReportError(string errorMessage) {
            Execute.RunForeground(this, () =>
            {
                TransferContainer container = Parent.Parent.Parent as TransferContainer;
                container.TaskError++;
                container.CountTransfers();

                PBProgress.TextFormat = PBProgress.TextFormat.Replace("{0}%", "¡Error!");
                PBProgress.State = ProgressBarEx.ProgressBarState.Error;
                PBProgress.Value = 100;

                Tip.ToolTipIcon = ToolTipIcon.Error;
                SetToolTip(GetToolTip() + "\n\nError: " + errorMessage);
            });
        }

        public void ReportCancel()
        {
            Execute.RunForeground(this, () =>
            {
                TransferContainer container = Parent.Parent.Parent as TransferContainer;
                container.TaskCancel++;
                container.CountTransfers();
                PBProgress.TextFormat = PBProgress.TextFormat.Replace("{0}%", "¡Cancelada!");
                PBProgress.State = ProgressBarEx.ProgressBarState.Error;
                PBProgress.Value = 100;
            });
        }

        public void ReportSuccess()
        {
            Execute.RunForeground(this, () =>
            {
                TransferContainer container = Parent.Parent.Parent as TransferContainer;
                container.TaskFinished++;
                container.CountTransfers();
                PBProgress.TextFormat = PBProgress.TextFormat.Replace("{0}%", "¡Exito!");
                PBProgress.State = ProgressBarEx.ProgressBarState.Normal;
                PBProgress.Value = 100;
            });
        }
    }
}
