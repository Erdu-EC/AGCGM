using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGCGM.Internal.Tools;
using AGCGM.Behavior;

namespace GCGM.Controls
{
    public partial class DownloadItem : UserControl
    {
        public int GameProgress = 0;
        public string GameName;

        private int TotalDownloads;
        private int DownloadsFinished;


        public DownloadItem(string gameName)
        {
            InitializeComponent();
            PBProgress.TextFormat = gameName + " - ({0}%)";
        }

        public void ReportTypeEnabled(GameCover.Type type) {
            TotalDownloads++;
            Execute.RunForeground(this, () => SetLabelForeColor(type, Color.Black));
        }

        public void ReportSuccessOf(GameCover.Type type) => ReportOf(type, false);

        public void ReportErrorOf(GameCover.Type type) => ReportOf(type, true);

        private void ReportOf(GameCover.Type type, bool error)
        {
            Execute.RunForeground(this, () =>
            {
                SetLabelForeColor(type, error ? PBProgress.ErrorColor : PBProgress.NormalColor);
                DownloadsFinished += 1;

                if (DownloadsFinished == TotalDownloads)
                    PBProgress.Value = 100;
            });
        }

        public void ReportError()
        {
            Execute.RunForeground(this, () =>
            {
                PBProgress.State = ProgressBarEx.ProgressBarState.Error;
                PBProgress.TextFormat = PBProgress.TextFormat.Replace("{0}%", "¡Error!");
                PBProgress.Value = 100;
            });
        }

        public void ReportProgress(int value) {
            int progress = Calc.Percentage(DownloadsFinished, TotalDownloads);
            value = progress + Calc.Percentage(value, TotalDownloads * 100);

            if (value > GameProgress)
            {
                GameProgress = value;

                Execute.RunForeground(this, () =>
                {
                    PBProgress.Value = value;
                });
            }
        }

        private void SetLabelForeColor(GameCover.Type type, Color color) => Controls[$"LB{type.ToString()}"].ForeColor = color;
    }
}
