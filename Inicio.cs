using AGCGM.Behavior;
using AGCGM.Behavior.Task;
using AGCGM.Controls;
using AGCGM.Controls.Page;
using AGCGM.Forms;
using AGCGM.Internal.Configs;
using AGCGM.Internal.DriveDetection;
using AGCGM.Internal.IO;
using AGCGM.Internal.IO.GC;
using AGCGM.Internal.Threading;
using AGCGM.Internal.Tools;
using AGCGM.Internal.XMLDB;
using AGCGM.Lang;
using GCGM.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGCGM
{
    public partial class Inicio : DriveDetecterForm
    {
        public static Settings Settings { get; private set; }
        public static GameList GameList { get; private set; }

        public static SidePanel SidePanel { get; private set; }
        public static DataPanel DataPanel { get; private set; }

        public TabControl Tabs => _MainTabs;

        public ToolStripStatusLabel StatusLabel => StatusMenu_Label;
        public ToolStripStatusLabel StatusFile => StatusMenu_File;
        public ToolStripProgressBar StatusProgress => StatusMenu_Progress;
        public ToolStripStatusLabel StatusButton => StatusMenu_Button;

        public Inicio()
        {
            InitializeComponent();

            //new DiskGC(@"Y:\ROM GC\Ingles\Legend of Zelda, The - Ocarina of Time & Master Quest (Limited Edition).iso").Copy(@"Y:\ROM GC\Ingles\Legend of Zelda, The - Ocarina of Time & Master Quest (Limited Edition).full.iso");
            //new DiskGC(@"Y:\ROM GC\Pokemon Colosseum.iso").Trim(@"Y:\ROM GC\Pokemon Colosseum.trim.iso");

            //Cargando configuraciones.
            Settings = Settings.Load();

            //Inicializando Log.
            Log.Initialize(LogPage);

            //Inicializando pestañas.
            _MainTabs.SelectTab(MainPage);
            _MainTabs.ImageList = ResXManager.GetImageList(
                typeof(ResX.Icons), new Size(32, 32), (name) => name.EndsWith("_32")
            );
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            //Inicializando listas de juegos.
            GameList = new GameList(this, MainPage);

            //Inicializando panel de datos.
            DataPanel = DPData;

            //Inicializando panel de acciones.
            SidePanel = new SidePanel(SideSplit);
        }

        #region TopMenu Events Methods. . .
        private void TopMenu_OpenBackup_Click(object sender, EventArgs e) => GameListDialog.SelectGame(MainPage.Controls[0] as GamePage);

        private void TopMenu_OpenDirectory_MainTab_Click(object sender, EventArgs e) => GameListDialog.SelectDirectory(Settings.SubDirectories, MainPage.Controls[0] as GamePage);

        private void TopMenu_OpenDirectory_NewTab_Click(object sender, EventArgs e) => GameListDialog.SelectDirectory(Settings.SubDirectories, null);

        private void TopMenu_OpenDrive_DropDownOpening(object sender, EventArgs e)
        {
            //Limpiando subelementos.
            TopMenu_OpenDrive.DropDownItems.Clear();

            //Recorriendo dispositivos.
            foreach (Drive drive in Drive.GetList().Select((info) => Execute.Assign(() => new Drive(info))))
            {
                if (drive is null) continue;

                DriveData data = Settings.GetDrive(drive) ?? new DriveData(drive);
                if (data.Hidden) continue;

                ToolStripItem item = new ToolStripMenuItem
                {
                    Name = data.Name,
                    Text = data.GetFormatedLabel(),
                    Image = Properties.Resources.ResourceManager.GetObject(drive.Type.ToString() + "_32") as Image,
                    ImageScaling = ToolStripItemImageScaling.None,
                    Tag = data
                };

                //Controlando evento.
                item.Click += (obj, args) => GameList.AddDrive(item.Tag as DriveData, true);

                //Agregando al menu.
                TopMenu_OpenDrive.DropDownItems.Add(item);
            }

            //Si no hay dispositivos.
            if (TopMenu_OpenDrive.DropDownItems.Count == 0) TopMenu_OpenDrive.DropDownItems.Add("<Vacio>");
        }

        private void TopMenu_Exit_Click(object sender, EventArgs e)
        {
            //Cancelando operaciones en segundo plano.
            TaskManaged.CancelAll();

            //Cerrando aplicacion.
            Application.Exit();
        }

        private void TopMenu_Settings_Click(object sender, EventArgs e) => new ConfigForm(Settings).ShowDialog();
        #endregion

        //Forms Events Methods. . .
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e) => TopMenu_Exit.PerformClick();

        private void MainTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex >= 2)
            {
                GamePage page = e.TabPage.Controls[0] as GamePage;

                if (page.List.SelectedItems.Count == 1)
                    MainSplit.Panel2Collapsed = false;
                else
                    MainSplit.Panel2Collapsed = true;

                if (e.TabPageIndex >= 3) e.Cancel = !page.SelectedTab();
            }
            else
            {
                MainSplit.Panel2Collapsed = true;

                //Inicializando base de datos.
                if (e.TabPage == DBPage && (DBPage.Controls[0] as DBPage).DB is null)
                    dbPage1.Initialize(new TDBDatabase(TDBStrings.DATABASE_NAME));
            }

        }

        private void LayoutDownload_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control control in (sender as TableLayoutPanel).Controls)
                control.Refresh();
        }

        private void BTDownloadClear_Click(object sender, EventArgs e)
        {
            IEnumerable<DownloadItem> controls = from DownloadItem item in LayoutDownload.Controls where (item.Tag as DownloadTask).IsFinished select item;
            //LayoutDownload.SuspendLayout();
            Array.ForEach(controls.ToArray(), item => LayoutDownload.Controls.Remove(item));

            if (controls.Count() == 0) SidePanel.CollapseDownloadPanel(true);
            //LayoutDownload.ResumeLayout(true);
        }

        private void BTTransferClear_Click(object sender, EventArgs e)
        {
            //Obteniendo tareas en progreso.
            var taskRunning = TaskManaged.RunningTasks.OfType<TransferTask>();

            foreach (var container in SidePanel.TransferPanel.Controls.Cast<TransferContainer>().ToArray())
            {
                container.SuspendLayout();

                var itemsToRemove = container.Items.Cast<TransferItem>().Where(item => item.Tag != null && !taskRunning.Contains(item.Tag)).ToArray();
                Array.ForEach(itemsToRemove, item => container.RemoveTransferItem(item));

                if (container.Items.Count == 0)
                {
                    SidePanel.TransferPanel.Controls.Remove(container);
                    continue;
                }
                    
                container.RefreshCountersOf(itemsToRemove.Select(item => item.Tag as TransferTask).ToArray());
                container.CountTransfers();
                container.ResumeLayout(true);
            }

            SidePanel.CollapseTransferPanel(true);
        }
    }
}
