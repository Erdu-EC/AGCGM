using AGCGM.Behavior;
using AGCGM.Behavior.Task;
using AGCGM.Internal.Actions;
using AGCGM.Internal.Configs;
using AGCGM.Internal.IO;
using AGCGM.Internal.Tools;
using GCGM.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace AGCGM.Forms
{
    public partial class ConfigForm : Form
    {
        internal DriveActions DriveAction { get; }
        internal DirectoryActions DirAction { get; }
        internal CoverActions CoverAction { get; }

        public ConfigForm(Settings Settings)
        {
            InitializeComponent();

            DriveAction = new DriveActions(Settings, DrivePage);
            DirAction = new DirectoryActions(Settings, DirPage);
            CoverAction = new CoverActions(Settings, CoverPage);

            DriveList.LargeImageList = DriveList.SmallImageList = ResXManager.GetImageList(
                typeof(ResX.Icons), new Size(32, 32), (name) => name.EndsWith("_32")
            );
        }

        private void MainTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "DrivePage":
                    if (DriveAction.FillDrives() is false) e.Cancel = true;
                    break;
                case "DirPage":
                    DirAction.Fill();
                    CBSearchDir.Checked = DirAction.SubDirectories;
                    break;
                case "CoverPage":
                    CoverAction.Fill();
                    break;
            }
        }

        #region Pestaña "Dispositivos" . . .
        private void DriveList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) => DriveAction.SelectDrive(e.Item, e.IsSelected);

        private void DriveList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            //Cancelando cambio de nombre automatico.
            e.CancelEdit = true;

            //Realizando cambio de nombre propio.
            DriveAction.EditDriveLabel(DriveList.Items[e.Item], e.Label);

            //Desactivando edicion no permitida XD.
            DriveList.LabelEdit = false;
        }

        private void GCWiiPicture_Enabled(object sender, EventArgs e)
        {
            PictureBox picture = sender as PictureBox;
            if (picture == GCPicture) picture.Image = picture.Enabled ? Properties.Resources.GC_32 : Properties.Resources.GC_disabled_32;
            if (picture == WiiPicture) picture.Image = picture.Enabled ? Properties.Resources.Wii_32 : Properties.Resources.Wii_disabled_32;
        }

        private void DriveMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DriveList.SelectedItems.Count == 0)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                //Obteniendo datos
                ListViewItem item = DriveList.SelectedItems[0];
                DriveData data = item.Tag as DriveData;

                //Si la unidad no esta lista, no abrir.
                if (!DriveAction.IsDriveReady(item))
                {
                    e.Cancel = true;
                    return;
                }

                //Activando elementos
                DriveMenu.Items["GCPrepareItem"].Enabled = !Drive.IsReadyForGC(data.Name);
                DriveMenu.Items["WiiPrepareItem"].Enabled = !Drive.IsReadyForWii(data.Name);
                DriveMenu.Items["SetAliasItem"].Text = data.Alias is null ? "Establecer un Alias" : "Cambiar Alias";
                DriveMenu.Items["DelAliasItem"].Visible = data.Alias != null;
                (DriveMenu.Items["HiddenItem"] as ToolStripMenuItem).Checked = data.Hidden;
                (DriveMenu.Items["MountItem"] as ToolStripMenuItem).Checked = data.Automount;
            }
        }

        private void DriveMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Cerrar menu contextual.
            DriveMenu.Close();

            //Si la unidad no esta lista, mostrar mensaje.
            DriveAction.IsDriveReady(DriveList.SelectedItems[0]);
        }

        private void GCWiiPrepare_Click(object sender, EventArgs e)
        {
            if (DriveList.SelectedItems.Count > 0)
            {
                //Obteniendo datos
                ListViewItem item = DriveList.SelectedItems[0];
                DriveData data = item.Tag as DriveData;

                //Identificando toolitem del evento.
                bool GC = (sender as ToolStripItem).Name == "GCPrepareItem";

                //Creando root de la unidad.
                if (GC ? Drive.CreateGCRoot(data.Name) : Drive.CreateWiiRoot(data.Name))
                    (GC ? GCPicture : WiiPicture).Enabled = true;
                else
                {
                    //Mostrando mensaje.
                    DialogResult result = MessageBox.Show(
                       $"Ha ocurrido un error al crear el directorio \"{(GC ? data.GetGCRoot() : data.GetWiiRoot())}\" en el dispositivo.",
                       "Error al preparar dispositivo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error
                   );

                    //Intentando de nuevo.
                    if (result == DialogResult.Retry) (sender as ToolStripItem).PerformClick();
                }
            }
        }

        private void SetAliasItem_Click(object sender, EventArgs e)
        {
            if (DriveList.SelectedItems.Count > 0)
            {
                //Obteniendo datos
                ListViewItem item = DriveList.SelectedItems[0];
                DriveData data = item.Tag as DriveData;

                //Cambiando texto del label.
                item.Text = data.GetLabel();

                //Permitiendo la edicion del nombre
                item.ListView.LabelEdit = true;

                //Iniciando evento de edicion.
                item.BeginEdit();
            }
        }

        private void DelAliasItem_Click(object sender, EventArgs e)
        {
            if (DriveList.SelectedItems.Count > 0)
            {
                //Obteniendo datos
                ListViewItem item = DriveList.SelectedItems[0];
                DriveData data = item.Tag as DriveData;

                //Eliminando alias
                item.Text = $"{data.Label} ({data.GetName()})";
                data.Alias = null;

                //Guardando cambios.
                DriveAction.SaveSettings(data);
            }
        }

        private void HiddenItem_Click(object sender, EventArgs e)
        {
            if (DriveList.SelectedItems.Count > 0)
            {
                //Obteniendo datos.
                ListViewItem item = DriveList.SelectedItems[0];
                DriveData data = item.Tag as DriveData;

                //Estableciendo estado.
                ((ToolStripMenuItem)sender).Checked = data.Hidden = !data.Hidden;

                //Modificando DriveList.
                DriveAction.HiddenDrive(item, data.Hidden);

                //Guardando cambios
                DriveAction.SaveSettings(data);
            }
        }

        private void MountItem_Click(object sender, EventArgs e)
        {
            if (DriveList.SelectedItems.Count > 0)
            {
                //Obteniendo datos.
                DriveData data = DriveList.SelectedItems[0].Tag as DriveData;

                //Estableciendo estado.
                ((ToolStripMenuItem)sender).Checked = data.Automount = !data.Automount;

                //Guardando cambios
                DriveAction.SaveSettings(data);
            }
        }

        private void ModMenu_Opening(object sender, CancelEventArgs e)
        {
            bool SelectItem = ModList.SelectedItems.Count > 0;
            ModMenu.Items["DelItem"].Text = ModList.SelectedItems.Count > 1 ? "Eliminar seleccionados" : "Eliminar elemento";
            ModMenu.Items["DelItem"].Visible = SelectItem;
            ModMenu.Items["SeparatorItem"].Visible = SelectItem;
        }

        private void DelItem_Click(object sender, EventArgs e)
        {
            //Aplicando accion en elementos seleccionados.
            foreach (ListViewItem item in ModList.SelectedItems) DriveAction.DelMod(item);

            //Guardando configuraciones.
            DriveAction.SaveSettings(null);
        }

        private void ClearItem_Click(object sender, EventArgs e) => DriveAction.ClearMods();
        #endregion

        #region Pestaña "Directorios" . . .
        private void DirList_SelectedIndexChanged(object sender, EventArgs e) => BTDelDir.Enabled = DirList.SelectedItems.Count > 0;

        private void DirList_ItemChecked(object sender, ItemCheckedEventArgs e) => DirAction.Check(e.Item, e.Item.Checked);

        private void BTExplorerDir_Click(object sender, EventArgs e)
        {
            if (DialogPath.ShowDialog() == DialogResult.OK) TBPathDir.Text = DialogPath.SelectedPath;
        }

        private void BTAddDir_Click(object sender, EventArgs e) => DirAction.Add(TBPathDir.Text);

        private void BTDelDir_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in DirList.SelectedItems) DirAction.Remove(item.Text);
        }

        private void CBSearchDir_CheckedChanged(object sender, EventArgs e) => DirAction.SubDirectories = CBSearchDir.Checked;

        private void TBPathDir_TextChanged(object sender, EventArgs e) => BTAddDir.Enabled = !string.IsNullOrWhiteSpace(TBPathDir.Text);

        private void TBPathDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b') e.Handled = Path.GetInvalidPathChars().Union(new char[] { '\"', '?', '*' }).Contains(e.KeyChar);
        }

        private void DirMenu_Opening(object sender, CancelEventArgs e)
        {
            //Numero de elementos seleccionados
            int num_selected = DirList.SelectedItems.Count;

            //Estableciendo estado de elementos
            if (num_selected == 1)
                (DirMenu.Items["NewTabItemDir"] as ToolStripMenuItem).Checked = DirList.SelectedItems[0].SubItems[1].Text == "Si";

            //Mostrando, ocultando y renombrando elementos
            DirMenu.Items["NewTabItemDir"].Visible = DirMenu.Items["SeparatorItemDir"].Visible = num_selected == 1;
            DirMenu.Items["DelItemDir"].Visible = num_selected > 0;
            DirMenu.Items["DelItemDir"].Text = (num_selected > 1) ? "Eliminar seleccionados" : "Eliminar elemento";
        }

        private void NewTabItemDir_Click(object sender, EventArgs e)
        {
            ListViewItem item = DirList.SelectedItems[0];
            ToolStripMenuItem menuitem = sender as ToolStripMenuItem;
            DirAction.SetNewTab(item.Text, (menuitem.Checked = !menuitem.Checked));
            item.SubItems[1].Text = menuitem.Checked ? "Si" : "No";
        }

        private void DelItemDir_Click(object sender, EventArgs e) => BTDelDir.PerformClick();

        private void ClearItemDir_Click(object sender, EventArgs e) => DirAction.Clear();
#endregion

        internal class DriveActions
        {
            private readonly Settings Settings;
            private readonly ListView List;
            private readonly ListView ModList;
            private readonly PictureBox GCPicture;
            private readonly PictureBox WiiPicture;
            private readonly ProgressBarEx SpaceBar;

            public DriveActions(Settings Settings, TabPage page)
            {
                Control.ControlCollection controls1 = page.Controls[1].Controls;
                Control.ControlCollection controls2 = page.Controls[0].Controls;

                this.Settings = Settings;
                List = controls1["DriveList"] as ListView;
                SpaceBar = controls1["SpaceBar"] as ProgressBarEx;
                GCPicture = controls1["GCPicture"] as PictureBox;
                WiiPicture = controls1["WiiPicture"] as PictureBox;
                ModList = controls2["ModList"] as ListView;
            }

            //Metodos publicos para dispositivos.
            public bool FillDrives()
            {
                //Limpiando lista.
                List.Items.Clear();

                //Obteniendo lista de dispositivos.
                DriveInfo[] Drives = null;

                Execute.OnErrorShow(
                    () => Drives = Drive.GetList(),
                    null, "Error al acceder a los dispositivos."
                );

                //Comprobando que la lista se haya obtenido.
                if (Drives is null) return false;

                //Deteniendo logica del control.
                List.SuspendLayout();

                //Recorriendo dispositivos.
                foreach (DriveInfo info in Drives)
                {
                    //Obteniendo datos del dispositivo actual, si no continuar.
                    Drive drive = null;
                    if (Execute.Run(() => drive = new Drive(info), null) is false) continue;

                    //Obteniendo datos del dispositivo desde configuracion.
                    DriveData data = Settings.GetDrive(drive) ?? new DriveData(drive);

                    //Agregando item al ListView y guardando datos de unidad.
                    ListViewItem item = AddDrive(drive, data);

                    //Ocultando unidad si es necesario
                    HiddenDrive(item, data.Hidden);

                    //Anexando datos de unidad.
                    item.Tag = data;
                }

                //Reanudando logica del control.
                List.ResumeLayout();

                //Rellenando listas de modificaciones.
                FillMods();

                //Notificando exito.
                return true;
            }

            public bool IsDriveReady(ListViewItem item)
            {
                //Obteniendo dispositivo.
                DriveData data = item.Tag as DriveData;

                //Comprobando estado del dispositivo.
                if (!new DriveInfo(data.Name).IsReady)
                {
                    MessageBox.Show(
                        $"El dispositivo \"{data.Name}\" ya no esta disponible, puede que haya sido desconectado.",
                        "Error al acceder al dispositivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation
                    );

                    //Remover item de la lista
                    List.Items.Remove(item);

                    return false;
                }

                return true;
            }

            public void SelectDrive(ListViewItem item, bool enable)
            {
                if (enable is false)
                {
                    GCPicture.Enabled = WiiPicture.Enabled = false;
                    SpaceBar.Reset();
                    return;
                }
                else
                {
                    //Obteniendo unidad.
                    DriveData data = item.Tag as DriveData;

                    //Confirmar el estado de la unidad.
                    if (!IsDriveReady(item)) return;

                    //Estableciendo cosas o tratando error.
                    Execute.Run(
                        () =>
                        {
                            Drive drive = new Drive(data);
                            GCPicture.Enabled = drive.IsReadyForGC();
                            WiiPicture.Enabled = drive.IsReadyForWii();
                            SpaceBar.SetUsedSpace(drive);
                        },
                        OnError: (_) => SelectDrive(item, false)
                    );

                    //Seleccionando elemento en lista de modificacion.
                    SelectMod(data.GetID());
                }
            }

            public void EditDriveLabel(ListViewItem item, string label)
            {
                //Obteniendo datos.
                DriveData data = item.Tag as DriveData;

                //Realizando edicion del label del elemento.
                if (data.Label == label || string.IsNullOrWhiteSpace(label))
                {
                    item.Text = $"{data.Label} ({data.GetName()})";
                    data.Alias = null;
                }
                else
                {
                    item.Text = $"{label} ({data.GetName()})";
                    data.Alias = label;
                }

                //Guardando cambios.
                SaveSettings(data);
            }

            public void HiddenDrive(ListViewItem item, bool hidden)
            {
                item.ImageKey = hidden ? $"{item.Group.Name}_hidden_32" : $"{item.Group.Name}_32";
                item.ForeColor = hidden ? SystemColors.GrayText : SystemColors.WindowText;
            }

            //Metodos privados para dispositivos.
            private ListViewItem AddDrive(Drive drive, DriveData data)
            {
                return List.Items.Add(
                    new ListViewItem(new string[] {
                        $"{data.GetLabel()} ({data.GetName()})",
                        $"{drive.Format} - {drive.GetTotalSize()}"
                    })
                    {
                        Group = List.Groups[drive.Type.ToString()], //Fixed or Removable
                    ImageKey = $"{drive.Type.ToString()}_32" //Fixed or Removable
                }
                );
            }

            //Metodos publicos para modificaciones.
            public void FillMods()
            {
                //Deteniendo logica.
                ModList.SuspendLayout();

                //Limpiando lista
                ModList.Items.Clear();

                //Añadiendo modificaciones a la lista.
                Settings.Drives.ForEach((data) => AddMod(data, null));

                //Reanudando logica.
                ModList.ResumeLayout();
            }

            public void DelMod(ListViewItem item)
            {
                //Obteniendo datos.
                DriveData data = Settings.GetDrive(name: item.SubItems[0].Text, label: item.SubItems[1].Text);

                //Eliminando elemento de ModList.
                ModList.Items.Remove(item);

                //Eliminando elemento de las configuraciones.
                if (data != null && Settings.Drives.Contains(data)) Settings.Drives.Remove(data);

                //Actualizando lista de dispositivos.
                FillDrives();
            }

            public void ClearMods()
            {
                //Limpiando configuraciones.
                Settings.Drives.Clear();

                //Actualizando listas.
                FillDrives();
                ModList.Items.Clear();

                //Guardandolas.
                SaveSettings(null);
            }

            //Metodos privados para modificaciones.
            private ListViewItem AddMod(DriveData data, ListViewItem item)
            {
                //Obteniendo elemento.
                if (item is null) item = new ListViewItem();

                //Agregando subelementos
                item.SubItems.Clear();
                item.SubItems.AddRange(new string[] {
                    data.Label,
                    data.Alias ?? "-",
                    data.Hidden? "Si":"No",
                    data.Automount? "Si":"No"
                });

                //Agregando datos.
                item.Name = data.GetID();
                item.Text = data.Name;

                //Devolviendo y agregando a lista si no existe.
                return HasMod(data.GetID()) ? item : ModList.Items.Add(item);
            }

            private bool HasMod(string DriveID) => ModList.Items.ContainsKey(DriveID);

            private void SelectMod(string DriveID)
            {
                if (HasMod(DriveID))
                {
                    //Deseleccionando otros elementos
                    foreach (ListViewItem mod_item in ModList.Items) mod_item.Selected = false;

                    //Seleccionando este.
                    ModList.Items[DriveID].Selected = true;
                    ModList.Items[DriveID].EnsureVisible();
                }
            }

            //Miembros estaticos.
            public void SaveSettings(DriveData data)
            {
                //Reflejando cambios en la configuracion
                if (data != null)
                {
                    if (data.IsEmpty())
                    {
                        if (Settings.Drives.Contains(data)) Settings.Drives.Remove(data);
                        if (HasMod(data.GetID())) ModList.Items.RemoveByKey(data.GetID());
                    }
                    else
                    {
                        //Si no existen en configuraciones, agregarlo.
                        if (!Settings.Drives.Contains(data)) Settings.Drives.Add(data);

                        //Obteniendo elemento si existe en lista de modificaciones.
                        ListViewItem item = HasMod(data.GetID()) ? ModList.Items[data.GetID()] : new ListViewItem();

                        //Otorgando a lista de modificaciones.
                        ModList.Focus();

                        //Agregandolo a lista de modificaciones.
                        AddMod(data, item);

                        //Marcando este como seleccionado
                        SelectMod(data.GetID());
                    }
                }

                //Guardando.
                Settings.Save();
            }
        }

        internal class DirectoryActions
        {
            private readonly Settings Settings;
            private readonly ListView List;

            public DirectoryActions(Settings Settings, TabPage page)
            {
                this.Settings = Settings;
                List = page.Controls[0].Controls["DirList"] as ListView;
            }

            public bool SubDirectories
            {
                get => Settings.SubDirectories;
                set {
                    Settings.SubDirectories = value;
                    Settings.Save();
                }
            }

            public void Fill()
            {
                //Limpiando lista
                List.Items.Clear();

                //Deteniendo logica de diseño.
                List.SuspendLayout();

                //Recorriendo directorios configurados y agregandolos.
                foreach (DirectoryData directory in Settings.Directories) AddItem(directory);

                //Reanudando logica.
                List.ResumeLayout();
            }

            public void Add(string path)
            {
                //Verificando que el directorio que se agregara exista.
                if (!Directory.Exists(path))
                {
                    MessageBox.Show(
                        $"El directorio \"{path}\" no es valido o simplemente no existe.",
                        "Error al agregar directorio", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                    return;
                }

                //Otorgandole el foco al ListView
                List.Focus();

                //Si el directorio no existe en las configuraciones.
                if (Settings.GetDirectory(path) is null)
                {
                    //Agregandolo a ellas.
                    DirectoryData directory = new DirectoryData(path);
                    Settings.Directories.Add(directory);

                    //Deseleccionando elementos del ListView
                    foreach (ListViewItem diritem in List.Items) diritem.Selected = false;

                    //Agregandolo a ListView
                    ListViewItem item = AddItem(directory);
                    item.Selected = true;
                    item.EnsureVisible();

                    //Guardando configuracion
                    Settings.Save();
                }
            }

            public void Remove(string path)
            {
                //Obteniendo directorio desde las configuraciones.
                DirectoryData directory = Settings.GetDirectory(path);

                //Si el directorio no fue encontrado en lista, terminar.
                if (directory is null) return;

                //Eliminando directorio de las configuraciones.
                Settings.Directories.Remove(directory);

                //Removiendo directorio de ListView.
                if (List.Items.ContainsKey(path)) List.Items.RemoveByKey(path);

                //Guardando configuracion
                Settings.Save();
            }

            public void Clear()
            {
                List.Items.Clear();
                Settings.Directories.Clear();
                Settings.Save();
            }

            public void Check(ListViewItem item, bool check)
            {
                //Obteniendo datos de configuracion.
                DirectoryData dir = Settings.GetDirectory(item.Text);

                if (dir != null)
                {
                    //Estableciendo estado checkeado.
                    dir.Active = check;

                    //Cambiando color de texto del elemento
                    item.ForeColor = check ? SystemColors.WindowText : SystemColors.GrayText;

                    //Guardando configuraciones
                    Settings.Save();
                }
            }

            public void SetNewTab(string path, bool newtab)
            {
                DirectoryData data = Settings.GetDirectory(path);
                if (data != null)
                {
                    data.NewTab = newtab;
                    Settings.Save();
                }
            }

            private ListViewItem AddItem(DirectoryData Dir)
            {
                //Agregandolo a ListView.
                return List.Items.Add(new ListViewItem(new string[] { Dir.Path, Dir.NewTab ? "Si" : "No" })
                {
                    Name = Dir.Path,
                    Checked = Dir.Active
                });
            }
        }

        internal class CoverActions
        {
            private readonly Settings Settings;
            private readonly CheckedListBox RegionList;
            private readonly TabControl Sources;
            private readonly GroupBox Group;
            //private readonly ListView List;

            internal CoverActions(Settings settings, TabPage page)
            {
                Settings = settings;
                RegionList = page.Controls[1].Controls["CLRegion"] as CheckedListBox;
                Sources = page.Controls[0].Controls["CoverSources"] as TabControl;
                Group = page.Controls[2] as GroupBox;
            }

            public void Fill()
            {
                //Cargando regiones.
                RegionList.SuspendLayout();
                RegionList.Items.Clear();
                foreach (var region in Settings.CoverRegions.OrderBy(item => item.Index))
                    RegionList.Items.Add(region.Lang.ToString(), region.Enabled);
                RegionList.ResumeLayout(true);

                //Cargando tipos de caratulas.
                foreach (var cover in Settings.Covers)
                {
                    //Checkbox.
                    (Group.Controls[$"CB{cover.Type.ToString()}"] as CheckBox).Checked = cover.Enabled;

                    //Lists
                    CheckedListBox list = Sources.TabPages[$"TP{cover.Type.ToString()}"].Controls[0] as CheckedListBox;

                    list.Items.Clear();
                    foreach (CoverSourceData source in cover.Sources)
                        list.Items.Add(source.Source, source.Enable);
                }
            }
        }

        private void CBDisk_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
