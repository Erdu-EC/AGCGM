using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGCGM.Internal.Tools;
using AGCGM.Internal.Serialize;
using AGCGM.Internal.IO;
using AGCGM.Internal.IO.GC;
using AGCGM.Behavior;
using AGCGM.Internal.Configs;
using System.IO;
using GCGM.Controls;
using static GCGM.Controls.ProgressBarEx;
using AGCGM.Behavior.Task;
using AGCGM.Internal.XMLDB;
using AGCGM.Lang;
using static AGCGM.Behavior.Log;

namespace AGCGM.Controls.Page
{
    public partial class GamePage : UserControl
    {
        public GamePage() => Initialize(null, false);

        public GamePage(string path, bool external) => Initialize(path, external);

        private void Initialize(string path, bool external)
        {
            InitializeComponent();
            List.ListViewItemSorter = new ListViewItemSorter(List);

            if (external)
            {
                SourcePath = path;
                BTAdd.Visible = BTRemove.Visible = BTClear.Visible = false;
                Separator1.Visible = Separator2.Visible = false;
            }
            else
            {
                BTRefresh.Visible = BTDelete.Visible = false;
                Separator3.Visible = Separator4.Visible = false;

                PBSpace.Visible = false;
                GameList.Dock = DockStyle.Fill;
            }
        }


        public string SourcePath { get; private set; }

        public DriveData DriveData { get; set; }
        public ListView List { get => GameList; }
        public ImageList Banners
        {
            get => GameList.LargeImageList ?? GameList.SmallImageList;
            set => Execute.RunForeground(GameList, () =>
            {
                GameList.LargeImageList = value;
                GameList.SmallImageList = value;
            });
        }

        //Eventos.
        public bool SelectedTab()
        {
            Drive drive = DriveData is null
                ? Execute.Assign(() => new Drive(new DriveInfo(Path.GetPathRoot(Parent.Name))))
                : Execute.Assign(() => new Drive(DriveData));

            if (!Behavior.GameList.IsValidPage(this, "No se encontro el Dispositivo o directorio."))
                return false;

            RefreshSpace(drive);
            return true;
        }

        private void RefreshSpace(Drive drive)
        {
            try
            {
                //Cambiando estilo de barra de progreso
                PBSpace.Style = ProgressBarEx.ProgressBarStyle.Continuous;

                //Estableciendo el espacio utilizado en barra de progreso
                PBSpace.Value = Calc.Percentage(drive.UsedSpace, drive.TotalSpace);

                //Mostrando texto en la barra de progreso
                PBSpace.TextFormat = $"{drive.Label} ({drive.Name}) - {drive.Format} - " +
                    $"{drive.GetFreeSpace()} disponibles de {drive.GetTotalSize()} / ({{0}}% utilizado)";

                //Estableciendo estado de la barra de progreso
                if (PBSpace.Value >= 90) PBSpace.State = ProgressBarState.Error;
                else if (PBSpace.Value >= 75) PBSpace.State = ProgressBarState.Paused;
                else PBSpace.State = ProgressBarState.Normal;
            }
            catch
            {
                PBSpace.Value = 0;
                PBSpace.TextFormat = "???";
                PBSpace.State = ProgressBarState.Error;
            }
        }

        //Banners.
        public void AddBanner(string key, Image img) => Execute.RunForeground(ParentForm, () =>
        {
            if (!HasBanner(key)) Banners.Images.Add(key, img);
        });

        public bool HasBanner(string key) => Banners.Images.Count != 0 && Banners.Images.ContainsKey(key);


        //Metodos de consultas.
        public bool ContainsGame(string file)
        {
            if (List.InvokeRequired)
                return (bool)List.Invoke(new Func<string, bool>(ContainsGame), file);

            return List.Items.ContainsKey(file);
        }

        public void AddGame(string file, GameInfoItem item)
        {
            //Verificando si se llama desde un subproceso.
            if (GameList.InvokeRequired)
            {
                GameList.Invoke(new Action<string, GameInfoItem>(AddGame), file, item);
                return;
            }

            //Agregando backup a la lista.
            GameList.Items.Add(new ListViewItem(new string[]{
                "",
                item.Code,
                item.Title,
                item.Maker,
                item.Country,
                DataSize.ToString(item.Length),
                file
            })
            {
                Name = file,
                ImageKey = HasBanner(item.GetCodeID()) ? item.GetCodeID() : Behavior.GameList.NOBACKUPBANNER
            });
        }

        //Controladores de eventos.
        private void GameList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemSorter ItemSorter = List.ListViewItemSorter as ListViewItemSorter;

            if (e.Column == ColumnLenght.Index)
                ItemSorter.Sort(e.Column, ListViewItemSorter.TypeColumn.DataSize);
            else
                ItemSorter.Sort(e.Column);
        }

        private void BTAdd_Click(object sender, EventArgs e) => GameListDialog.SelectGame(this);

        private void ShowDataPanel()
        {
            SplitContainer splitter = Inicio.DataPanel.Parent.Parent as SplitContainer;

            if (!Behavior.GameList.IsValidPage(this, "No se encontro el Dispositivo o directorio."))
            {
                splitter.Panel2Collapsed = true;
                return;
            }

            if (GameList.SelectedItems.Count > 1)
                splitter.Panel2Collapsed = true;
            else if (GameList.SelectedItems.Count == 1)
            {
                DataPanel panel = Inicio.DataPanel;
                ListViewItem selectedItem = GameList.SelectedItems[0];
                string filePath = selectedItem.SubItems[6].Text;
                string key = selectedItem.SubItems[1].Text;
                //key = key.Substring(0, key.Length - 2);

                //Comprobando que el archivo exista.
                if (!File.Exists(filePath))
                {
                    string message = $"El archivo \"{filePath}\" no esta disponible, puede que este haya sido movido, eliminado, el directorio no exista o este ubicado en un dispositivo no conectado.";
                    MessageBox.Show(message, "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddLog(message, LogLevel.Error, filePath);
                    return;
                }

                //Obteniendo header.
                DiskGC disk;
                long trimmed;
                using (FileStream stream = File.OpenRead(filePath))
                {
                    disk = new DiskGC(stream, new DiskGC.GCHeader(new BinaryReader(stream)));
                    trimmed = stream.Length - disk.GetLength();
                }

                //Accediendo a base de datos.
                TDBDatabase DB = new TDBDatabase(TDBStrings.DATABASE_NAME);
                TDBGame gameInfo = DB.GetGameByCode(key);

                //Actualizando datos.
                //panel.SuspendLayout();
                panel.Cover = Cache.GetCover(key, GameCover.Type.Front) ?? Properties.Resources.cover_front;
                panel.SetRegionFlag(gameInfo.Region);
                panel.Title = gameInfo?.Titles.SingleOrDefault(item => item.Key == TDBEnums.GameLanguage.ES).Value ?? gameInfo?.Titles.FirstOrDefault().Value;
                panel.Languages = gameInfo?.GetLanguages();
                panel.Description = gameInfo?.Synopsis.SingleOrDefault(item => item.Key == TDBEnums.GameLanguage.ES).Value ?? gameInfo?.Synopsis.FirstOrDefault().Value;
                panel.SetRequiredControls(gameInfo?.ControlsRequired);
                panel.SetOptionalControls(gameInfo?.ControlsOptional);
                panel.Trimmed = trimmed == 0 ? "Trimmed" : $"No Trimmed ({DataSize.ToString(trimmed)} Basura)";
                //panel.ResumeLayout(true);

                //Mostrando panel.
                splitter.Panel2Collapsed = false;

                List.EnsureVisible(List.SelectedIndices[0]);
            }
        }

        private void GameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = GameList.SelectedItems.Count;

            if (count <= 1) BTRemove.Enabled = BTDelete.Enabled = count == 1;

            ShowDataPanel();
        }

        private void BTDownload_Click(object sender, EventArgs e) => Behavior.GameList.DownloadCovers(GameList.Items.Cast<ListViewItem>());

        #region ContextMenu. . .
        private void TSMTransferAllTypes_DropDownOpening(object sender, EventArgs e)
        {
            //Obteniendo menu contextual actual.
            ToolStripMenuItem ToolMenu = sender as ToolStripMenuItem;

            //Limpiando menu contextual.
            ToolMenu.DropDownItems.Clear();

            //Recorriendo pestañas.
            foreach (TabPage page in Behavior.GameList.Tabs.TabPages)
            {
                GamePage gamePage = page.Controls[0] as GamePage;

                if (gamePage != this)
                {
                    Drive drive = null;
                    if (gamePage.DriveData != null) drive = Execute.Assign(() => new Drive(gamePage.DriveData));

                    if (gamePage.DriveData is null || drive.IsReadyForGC())
                    {
                        ToolStripItem item = new ToolStripMenuItem
                        {
                            Name = page.Name,
                            Text = gamePage.DriveData?.GetFormatedLabel() ?? page.Text,
                            ToolTipText = gamePage.DriveData?.GetGCRoot() ?? page.Name,
                            Image = gamePage.DriveData is null ? Properties.Resources.Folder_open_32 : Properties.Resources.ResourceManager.GetObject(drive?.Type.ToString() + "_32") as Image,
                            ImageScaling = ToolStripItemImageScaling.None,
                            Tag = gamePage.DriveData
                        };
                        item.Click += (obj, arg) =>
                        {
                            bool full = ToolMenu == TSMTransferFull;
                            Behavior.GameList.TransferTo(this, gamePage, GameList.SelectedItems, trim: !full);
                        };

                        ToolMenu.DropDownItems.Add(item);
                    }
                }
            }

            if (ToolMenu.DropDownItems.Count == 0)
                ToolMenu.DropDownItems.Add("<Vacio>").Enabled = false;
        }

        private void TSMTransferFull_Click(object sender, EventArgs e)
        {
            //Behavior.GameList.Transfer(GameList.SelectedItems);
        }
        #endregion


    }
}
