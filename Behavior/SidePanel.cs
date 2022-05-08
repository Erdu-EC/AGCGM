using AGCGM.Behavior.Task;
using AGCGM.Internal.Configs;
using AGCGM.Internal.IO;
using GCGM.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Behavior
{
    public class SidePanel
    {
        public TableLayoutPanel TransferPanel { get; private set; }
        public TableLayoutPanel DownloadPanel { get; private set; }

        readonly SplitContainer Splitter;
        readonly SplitContainer MainSplitter;

        public SidePanel(SplitContainer sideSplit)
        {
            //Estableciendo.
            Splitter = sideSplit;
            MainSplitter = sideSplit.Parent.Parent as SplitContainer;
            TransferPanel = Splitter.Panel1.Controls.Find("LayoutTransfer", true)[0] as TableLayoutPanel;
            DownloadPanel = Splitter.Panel2.Controls.Find("LayoutDownload", true)[0] as TableLayoutPanel;

            //Ocultando paneles.
            MainSplitter.Panel2Collapsed = Splitter.Panel2Collapsed = true;
        }

        public TransferItem AddTransferItem(string sourcePath, string sourceFile, string sourceLabel, string destPath, string destFile, string destLabel, Image gameBanner, string gameName)
        {
            TransferContainer container;
            TransferItem item = new TransferItem(sourceFile, destFile, gameBanner, gameName);

            if (TransferPanel.Controls.Count > 0 && (container = GetTransferContainerIfExist(sourcePath, destPath, sourceFile, destFile)) != null)
            {
                TransferItem tempItem;

                if ((tempItem = GetTransferItemIfExistIn(container, sourceFile, destFile)) != null)
                    container.Items.Remove(tempItem);

                container.AddTransferItem(item);
                container.CountTransfers();
            }
            else
            {
                container = new TransferContainer(sourcePath, sourceLabel, destPath, destLabel)
                {
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                container.AddTransferItem(item);
                container.CountTransfers();
                TransferPanel.Controls.Add(container);

                TransferPanel.ScrollControlIntoView(container);
            }

            //item.
            return item;
        }

        private TransferContainer GetTransferContainerIfExist(string sourcePath, string destPath, string sourceFile, string destFile)
        {
            var collection = TransferPanel.Controls.Cast<TransferContainer>();
            var result = collection.Where(control => GetTransferItemIfExistIn(control, sourceFile, destFile) != null).SingleOrDefault();
            if (result is null) result = collection.Where(control => (sourcePath.StartsWith(control.SourcePath) && destPath.StartsWith(control.DestinationPath))).FirstOrDefault();
            return result;
        }

        public bool ExistTransferInProgress(string destFile)
        {
            var collection = TransferPanel.Controls.Cast<TransferContainer>();
            return collection.Where(container => container.Items.Cast<TransferItem>().Where(item => item.DestinationPath == destFile && !(item.Tag as TransferTask).IsFinished).Count() > 0).Count() > 0;
        }

        private TransferItem GetTransferItemIfExistIn(TransferContainer container, string sourcePath, string destPath)
        {
            return container.Items.Cast<TransferItem>().Where(item => item.SourcePath == sourcePath && item.DestinationPath == destPath).SingleOrDefault();
        }

        public DownloadItem AddDownloadItem(string gameCode, string gameName)
        {
            if (DownloadPanel.Controls.ContainsKey(gameCode))
                DownloadPanel.Controls.RemoveByKey(gameCode);

            DownloadItem item = new DownloadItem(gameName)
            {
                Name = gameCode,
            };
            DownloadPanel.Controls.Add(item);

            return item;
        }

        public void CollapseTransferPanel(bool collapse)
        {
            //Mostrar.
            if (!collapse)
            {
                if (TransferPanel.Controls.Count > 0)
                {
                    Splitter.Panel1Collapsed = false;

                    if (DownloadPanel.Controls.Count == 0)
                        Splitter.Panel2Collapsed = true;

                    if (MainSplitter.Panel2Collapsed)
                        MainSplitter.Panel2Collapsed = false;
                }
            }
            else
            {
                if (TransferPanel.Controls.Count == 0)
                {
                    if (Splitter.Panel2Collapsed)
                        MainSplitter.Panel2Collapsed = true;

                    Splitter.Panel1Collapsed = true;
                }
            }
        }

        public void CollapseDownloadPanel(bool collapse)
        {
            MainSplitter.SuspendLayout();
            Splitter.SuspendLayout();

            if (!collapse)
            {
                if (DownloadPanel.Controls.Count > 0)
                {
                    Splitter.Panel2Collapsed = false;

                    if (TransferPanel.Controls.Count == 0)
                        Splitter.Panel1Collapsed = true;

                    if (MainSplitter.Panel2Collapsed)
                        MainSplitter.Panel2Collapsed = false;
                }
            }
            else
            {
                if (DownloadPanel.Controls.Count == 0)
                {
                    if (Splitter.Panel1Collapsed)
                        MainSplitter.Panel2Collapsed = true;

                    Splitter.Panel2Collapsed = true;
                }
            }

            Splitter.ResumeLayout(false);
            MainSplitter.ResumeLayout(true);
        }
    }
}
