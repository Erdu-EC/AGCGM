namespace AGCGM.Forms
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabControl MainTab;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.ColumnHeader Letra;
            System.Windows.Forms.ColumnHeader Nombre;
            System.Windows.Forms.ColumnHeader Alias;
            System.Windows.Forms.ColumnHeader Oculta;
            System.Windows.Forms.ColumnHeader Automontaje;
            System.Windows.Forms.ToolStripMenuItem DelItem;
            System.Windows.Forms.ToolStripSeparator SeparatorItem;
            System.Windows.Forms.ToolStripMenuItem ClearItem;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Fijos", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Extraibles", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ColumnHeader Unidad;
            System.Windows.Forms.ColumnHeader Size;
            System.Windows.Forms.ToolStripMenuItem GCPrepareItem;
            System.Windows.Forms.ToolStripMenuItem WiiPrepareItem;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripMenuItem SetAliasItem;
            System.Windows.Forms.ToolStripMenuItem DelAliasItem;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
            System.Windows.Forms.ToolStripMenuItem HiddenItem;
            System.Windows.Forms.ToolStripMenuItem MountItem;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.ColumnHeader Path;
            System.Windows.Forms.ColumnHeader NewTab;
            System.Windows.Forms.ToolStripMenuItem NewTabItemDir;
            System.Windows.Forms.ToolStripSeparator SeparatorItemDir;
            System.Windows.Forms.ToolStripMenuItem DelItemDir;
            System.Windows.Forms.ToolStripMenuItem ClearItemDir;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            System.Windows.Forms.GroupBox groupBox7;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.GroupBox groupBox6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.Label label1;
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DrivePage = new System.Windows.Forms.TabPage();
            this.ModList = new System.Windows.Forms.ListView();
            this.ModMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SpaceBar = new GCGM.Controls.ProgressBarEx(this.components);
            this.WiiPicture = new System.Windows.Forms.PictureBox();
            this.GCPicture = new System.Windows.Forms.PictureBox();
            this.DriveList = new System.Windows.Forms.ListView();
            this.DriveMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DirPage = new System.Windows.Forms.TabPage();
            this.BTAddDir = new System.Windows.Forms.Button();
            this.BTDelDir = new System.Windows.Forms.Button();
            this.BTExplorerDir = new System.Windows.Forms.Button();
            this.CBSearchDir = new System.Windows.Forms.CheckBox();
            this.TBPathDir = new System.Windows.Forms.TextBox();
            this.DirList = new System.Windows.Forms.ListView();
            this.DirMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CoverPage = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.CoverSources = new System.Windows.Forms.TabControl();
            this.TPDisc = new System.Windows.Forms.TabPage();
            this.CoverDiskSource = new System.Windows.Forms.CheckedListBox();
            this.TPFront = new System.Windows.Forms.TabPage();
            this.CoverFrontSource = new System.Windows.Forms.CheckedListBox();
            this.TPFront3D = new System.Windows.Forms.TabPage();
            this.CoverFront3DSource = new System.Windows.Forms.CheckedListBox();
            this.TPFull = new System.Windows.Forms.TabPage();
            this.CoverFullSource = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.CLRegion = new System.Windows.Forms.CheckedListBox();
            this.CBDisc = new System.Windows.Forms.CheckBox();
            this.CBFull = new System.Windows.Forms.CheckBox();
            this.CBFront3D = new System.Windows.Forms.CheckBox();
            this.CBFront = new System.Windows.Forms.CheckBox();
            this.DialogPath = new System.Windows.Forms.FolderBrowserDialog();
            MainTab = new System.Windows.Forms.TabControl();
            groupBox2 = new System.Windows.Forms.GroupBox();
            Letra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Alias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Oculta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Automontaje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            DelItem = new System.Windows.Forms.ToolStripMenuItem();
            SeparatorItem = new System.Windows.Forms.ToolStripSeparator();
            ClearItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox1 = new System.Windows.Forms.GroupBox();
            Unidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            GCPrepareItem = new System.Windows.Forms.ToolStripMenuItem();
            WiiPrepareItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            SetAliasItem = new System.Windows.Forms.ToolStripMenuItem();
            DelAliasItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            HiddenItem = new System.Windows.Forms.ToolStripMenuItem();
            MountItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox4 = new System.Windows.Forms.GroupBox();
            Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            NewTab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            NewTabItemDir = new System.Windows.Forms.ToolStripMenuItem();
            SeparatorItemDir = new System.Windows.Forms.ToolStripSeparator();
            DelItemDir = new System.Windows.Forms.ToolStripMenuItem();
            ClearItemDir = new System.Windows.Forms.ToolStripMenuItem();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            groupBox7 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            groupBox6 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            MainTab.SuspendLayout();
            this.DrivePage.SuspendLayout();
            groupBox2.SuspendLayout();
            this.ModMenu.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WiiPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCPicture)).BeginInit();
            this.DriveMenu.SuspendLayout();
            this.DirPage.SuspendLayout();
            groupBox4.SuspendLayout();
            this.DirMenu.SuspendLayout();
            groupBox3.SuspendLayout();
            this.CoverPage.SuspendLayout();
            groupBox7.SuspendLayout();
            this.CoverSources.SuspendLayout();
            this.TPDisc.SuspendLayout();
            this.TPFront.SuspendLayout();
            this.TPFront3D.SuspendLayout();
            this.TPFull.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            MainTab.Controls.Add(this.tabPage1);
            MainTab.Controls.Add(this.DrivePage);
            MainTab.Controls.Add(this.DirPage);
            MainTab.Controls.Add(this.CoverPage);
            MainTab.Location = new System.Drawing.Point(1, 1);
            MainTab.Multiline = true;
            MainTab.Name = "MainTab";
            MainTab.SelectedIndex = 0;
            MainTab.Size = new System.Drawing.Size(443, 385);
            MainTab.TabIndex = 3;
            MainTab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainTab_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(435, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DrivePage
            // 
            this.DrivePage.Controls.Add(groupBox2);
            this.DrivePage.Controls.Add(groupBox1);
            this.DrivePage.Location = new System.Drawing.Point(4, 22);
            this.DrivePage.Name = "DrivePage";
            this.DrivePage.Padding = new System.Windows.Forms.Padding(3);
            this.DrivePage.Size = new System.Drawing.Size(435, 359);
            this.DrivePage.TabIndex = 1;
            this.DrivePage.Text = "Dispositivos";
            this.DrivePage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(this.ModList);
            groupBox2.Location = new System.Drawing.Point(7, 222);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(420, 131);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Alias y modificaciones";
            // 
            // ModList
            // 
            this.ModList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Letra,
            Nombre,
            Alias,
            Oculta,
            Automontaje});
            this.ModList.ContextMenuStrip = this.ModMenu;
            this.ModList.FullRowSelect = true;
            this.ModList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ModList.HideSelection = false;
            this.ModList.Location = new System.Drawing.Point(6, 19);
            this.ModList.Name = "ModList";
            this.ModList.Size = new System.Drawing.Size(408, 106);
            this.ModList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ModList.TabIndex = 2;
            this.ModList.UseCompatibleStateImageBehavior = false;
            this.ModList.View = System.Windows.Forms.View.Details;
            // 
            // Letra
            // 
            Letra.Text = "Unidad";
            Letra.Width = 46;
            // 
            // Nombre
            // 
            Nombre.Text = "Nombre";
            Nombre.Width = 132;
            // 
            // Alias
            // 
            Alias.Text = "Alias";
            Alias.Width = 102;
            // 
            // Oculta
            // 
            Oculta.Text = "Oculta";
            Oculta.Width = 53;
            // 
            // Automontaje
            // 
            Automontaje.Text = "Automontaje";
            Automontaje.Width = 71;
            // 
            // ModMenu
            // 
            this.ModMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            DelItem,
            SeparatorItem,
            ClearItem});
            this.ModMenu.Name = "ModMenu";
            this.ModMenu.Size = new System.Drawing.Size(171, 54);
            this.ModMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ModMenu_Opening);
            // 
            // DelItem
            // 
            DelItem.Name = "DelItem";
            DelItem.Size = new System.Drawing.Size(170, 22);
            DelItem.Text = "Eliminar elemento";
            DelItem.Click += new System.EventHandler(this.DelItem_Click);
            // 
            // SeparatorItem
            // 
            SeparatorItem.Name = "SeparatorItem";
            SeparatorItem.Size = new System.Drawing.Size(167, 6);
            // 
            // ClearItem
            // 
            ClearItem.Name = "ClearItem";
            ClearItem.Size = new System.Drawing.Size(170, 22);
            ClearItem.Text = "Limpiar lista";
            ClearItem.Click += new System.EventHandler(this.ClearItem_Click);
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.SpaceBar);
            groupBox1.Controls.Add(this.WiiPicture);
            groupBox1.Controls.Add(this.GCPicture);
            groupBox1.Controls.Add(this.DriveList);
            groupBox1.Location = new System.Drawing.Point(7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(420, 210);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Unidades montadas y ocultas";
            // 
            // SpaceBar
            // 
            this.SpaceBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpaceBar.AnimationInterval = 4000;
            this.SpaceBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.SpaceBar.BorderPadding = 1;
            this.SpaceBar.BorderWidth = 1;
            this.SpaceBar.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SpaceBar.Location = new System.Drawing.Point(6, 170);
            this.SpaceBar.MarqueeAnimationSpeed = 0;
            this.SpaceBar.Name = "SpaceBar";
            this.SpaceBar.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SpaceBar.PausedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SpaceBar.Size = new System.Drawing.Size(337, 32);
            this.SpaceBar.State = GCGM.Controls.ProgressBarEx.ProgressBarState.Normal;
            this.SpaceBar.Style = GCGM.Controls.ProgressBarEx.ProgressBarStyle.Continuous;
            this.SpaceBar.TabIndex = 6;
            this.SpaceBar.TextAlign = GCGM.Controls.ProgressBarEx.ContentAlignment.MiddleCenter;
            this.SpaceBar.TextColor = System.Drawing.Color.Black;
            this.SpaceBar.TextEllipsis = System.Drawing.StringTrimming.EllipsisCharacter;
            this.SpaceBar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SpaceBar.TextFormat = "";
            // 
            // WiiPicture
            // 
            this.WiiPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WiiPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WiiPicture.Image = global::AGCGM.Properties.Resources.Wii_disabled_32;
            this.WiiPicture.Location = new System.Drawing.Point(381, 170);
            this.WiiPicture.Name = "WiiPicture";
            this.WiiPicture.Size = new System.Drawing.Size(33, 32);
            this.WiiPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WiiPicture.TabIndex = 4;
            this.WiiPicture.TabStop = false;
            this.WiiPicture.EnabledChanged += new System.EventHandler(this.GCWiiPicture_Enabled);
            // 
            // GCPicture
            // 
            this.GCPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GCPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GCPicture.Enabled = false;
            this.GCPicture.Image = global::AGCGM.Properties.Resources.GC_disabled_32;
            this.GCPicture.Location = new System.Drawing.Point(349, 170);
            this.GCPicture.Name = "GCPicture";
            this.GCPicture.Size = new System.Drawing.Size(33, 32);
            this.GCPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GCPicture.TabIndex = 5;
            this.GCPicture.TabStop = false;
            this.GCPicture.EnabledChanged += new System.EventHandler(this.GCWiiPicture_Enabled);
            // 
            // DriveList
            // 
            this.DriveList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DriveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Unidad,
            Size});
            this.DriveList.ContextMenuStrip = this.DriveMenu;
            this.DriveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewGroup3.Header = "Fijos";
            listViewGroup3.Name = "Fixed";
            listViewGroup4.Header = "Extraibles";
            listViewGroup4.Name = "Removable";
            this.DriveList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.DriveList.HideSelection = false;
            this.DriveList.Location = new System.Drawing.Point(6, 19);
            this.DriveList.MultiSelect = false;
            this.DriveList.Name = "DriveList";
            this.DriveList.Size = new System.Drawing.Size(408, 145);
            this.DriveList.TabIndex = 2;
            this.DriveList.TileSize = new System.Drawing.Size(190, 36);
            this.DriveList.UseCompatibleStateImageBehavior = false;
            this.DriveList.View = System.Windows.Forms.View.Tile;
            this.DriveList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.DriveList_AfterLabelEdit);
            this.DriveList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DriveList_ItemSelectionChanged);
            // 
            // Unidad
            // 
            Unidad.Text = "Unidad";
            // 
            // Size
            // 
            Size.Text = "Size";
            // 
            // DriveMenu
            // 
            this.DriveMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            GCPrepareItem,
            WiiPrepareItem,
            toolStripMenuItem1,
            SetAliasItem,
            DelAliasItem,
            toolStripMenuItem2,
            HiddenItem,
            MountItem});
            this.DriveMenu.Name = "contextMenuStrip1";
            this.DriveMenu.Size = new System.Drawing.Size(227, 244);
            this.DriveMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DriveMenu_Opening);
            this.DriveMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DriveMenu_ItemClicked);
            // 
            // GCPrepareItem
            // 
            GCPrepareItem.Image = global::AGCGM.Properties.Resources.GC_32;
            GCPrepareItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            GCPrepareItem.Name = "GCPrepareItem";
            GCPrepareItem.Size = new System.Drawing.Size(226, 38);
            GCPrepareItem.Text = "Preparar para GC";
            GCPrepareItem.Click += new System.EventHandler(this.GCWiiPrepare_Click);
            // 
            // WiiPrepareItem
            // 
            WiiPrepareItem.Image = global::AGCGM.Properties.Resources.Wii_32;
            WiiPrepareItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            WiiPrepareItem.Name = "WiiPrepareItem";
            WiiPrepareItem.Size = new System.Drawing.Size(226, 38);
            WiiPrepareItem.Text = "Preparar para Wii";
            WiiPrepareItem.Click += new System.EventHandler(this.GCWiiPrepare_Click);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(223, 6);
            // 
            // SetAliasItem
            // 
            SetAliasItem.Name = "SetAliasItem";
            SetAliasItem.Size = new System.Drawing.Size(226, 38);
            SetAliasItem.Text = "Establecer un Alias";
            SetAliasItem.Click += new System.EventHandler(this.SetAliasItem_Click);
            // 
            // DelAliasItem
            // 
            DelAliasItem.Name = "DelAliasItem";
            DelAliasItem.Size = new System.Drawing.Size(226, 38);
            DelAliasItem.Text = "Eliminar un Alias";
            DelAliasItem.Click += new System.EventHandler(this.DelAliasItem_Click);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(223, 6);
            // 
            // HiddenItem
            // 
            HiddenItem.Name = "HiddenItem";
            HiddenItem.Size = new System.Drawing.Size(226, 38);
            HiddenItem.Text = "Ocultar dispositivo";
            HiddenItem.Click += new System.EventHandler(this.HiddenItem_Click);
            // 
            // MountItem
            // 
            MountItem.Checked = true;
            MountItem.CheckState = System.Windows.Forms.CheckState.Checked;
            MountItem.Name = "MountItem";
            MountItem.Size = new System.Drawing.Size(226, 38);
            MountItem.Text = "Montar automaticamente";
            MountItem.Click += new System.EventHandler(this.MountItem_Click);
            // 
            // DirPage
            // 
            this.DirPage.Controls.Add(groupBox4);
            this.DirPage.Controls.Add(groupBox3);
            this.DirPage.Location = new System.Drawing.Point(4, 22);
            this.DirPage.Name = "DirPage";
            this.DirPage.Padding = new System.Windows.Forms.Padding(3);
            this.DirPage.Size = new System.Drawing.Size(435, 359);
            this.DirPage.TabIndex = 2;
            this.DirPage.Text = "Directorios";
            this.DirPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox4.Controls.Add(this.BTAddDir);
            groupBox4.Controls.Add(this.BTDelDir);
            groupBox4.Controls.Add(this.BTExplorerDir);
            groupBox4.Controls.Add(this.CBSearchDir);
            groupBox4.Controls.Add(this.TBPathDir);
            groupBox4.Controls.Add(this.DirList);
            groupBox4.Location = new System.Drawing.Point(7, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(420, 232);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Busqueda de Backups (ROMs)";
            // 
            // BTAddDir
            // 
            this.BTAddDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTAddDir.Enabled = false;
            this.BTAddDir.Image = global::AGCGM.Properties.Resources.Folder_open_32;
            this.BTAddDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTAddDir.Location = new System.Drawing.Point(324, 175);
            this.BTAddDir.Name = "BTAddDir";
            this.BTAddDir.Size = new System.Drawing.Size(90, 49);
            this.BTAddDir.TabIndex = 14;
            this.BTAddDir.Text = "Añadir Carpeta";
            this.BTAddDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTAddDir.UseVisualStyleBackColor = true;
            this.BTAddDir.Click += new System.EventHandler(this.BTAddDir_Click);
            // 
            // BTDelDir
            // 
            this.BTDelDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTDelDir.Enabled = false;
            this.BTDelDir.Image = global::AGCGM.Properties.Resources.Error_16;
            this.BTDelDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTDelDir.Location = new System.Drawing.Point(238, 175);
            this.BTDelDir.Name = "BTDelDir";
            this.BTDelDir.Size = new System.Drawing.Size(80, 23);
            this.BTDelDir.TabIndex = 12;
            this.BTDelDir.Text = "Eliminar";
            this.BTDelDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTDelDir.UseVisualStyleBackColor = true;
            this.BTDelDir.Click += new System.EventHandler(this.BTDelDir_Click);
            // 
            // BTExplorerDir
            // 
            this.BTExplorerDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTExplorerDir.Image = global::AGCGM.Properties.Resources.Search_16;
            this.BTExplorerDir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BTExplorerDir.Location = new System.Drawing.Point(238, 201);
            this.BTExplorerDir.Name = "BTExplorerDir";
            this.BTExplorerDir.Size = new System.Drawing.Size(80, 23);
            this.BTExplorerDir.TabIndex = 13;
            this.BTExplorerDir.Text = "Explorar...";
            this.BTExplorerDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTExplorerDir.UseVisualStyleBackColor = true;
            this.BTExplorerDir.Click += new System.EventHandler(this.BTExplorerDir_Click);
            // 
            // CBSearchDir
            // 
            this.CBSearchDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CBSearchDir.AutoSize = true;
            this.CBSearchDir.Checked = true;
            this.CBSearchDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBSearchDir.Location = new System.Drawing.Point(6, 179);
            this.CBSearchDir.Name = "CBSearchDir";
            this.CBSearchDir.Size = new System.Drawing.Size(142, 17);
            this.CBSearchDir.TabIndex = 10;
            this.CBSearchDir.Text = "Buscar en subdirectorios";
            this.CBSearchDir.UseVisualStyleBackColor = true;
            this.CBSearchDir.CheckedChanged += new System.EventHandler(this.CBSearchDir_CheckedChanged);
            // 
            // TBPathDir
            // 
            this.TBPathDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBPathDir.Location = new System.Drawing.Point(6, 203);
            this.TBPathDir.MaxLength = 255;
            this.TBPathDir.Name = "TBPathDir";
            this.TBPathDir.ShortcutsEnabled = false;
            this.TBPathDir.Size = new System.Drawing.Size(226, 20);
            this.TBPathDir.TabIndex = 11;
            this.TBPathDir.WordWrap = false;
            this.TBPathDir.TextChanged += new System.EventHandler(this.TBPathDir_TextChanged);
            this.TBPathDir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBPathDir_KeyPress);
            // 
            // DirList
            // 
            this.DirList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirList.CheckBoxes = true;
            this.DirList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Path,
            NewTab});
            this.DirList.ContextMenuStrip = this.DirMenu;
            this.DirList.FullRowSelect = true;
            this.DirList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.DirList.HideSelection = false;
            this.DirList.Location = new System.Drawing.Point(6, 19);
            this.DirList.Name = "DirList";
            this.DirList.ShowGroups = false;
            this.DirList.Size = new System.Drawing.Size(408, 150);
            this.DirList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.DirList.TabIndex = 2;
            this.DirList.UseCompatibleStateImageBehavior = false;
            this.DirList.View = System.Windows.Forms.View.Details;
            this.DirList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.DirList_ItemChecked);
            this.DirList.SelectedIndexChanged += new System.EventHandler(this.DirList_SelectedIndexChanged);
            // 
            // Path
            // 
            Path.Text = "Directorio";
            Path.Width = 316;
            // 
            // NewTab
            // 
            NewTab.Text = "Nueva Pestaña";
            NewTab.Width = 87;
            // 
            // DirMenu
            // 
            this.DirMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            NewTabItemDir,
            SeparatorItemDir,
            DelItemDir,
            ClearItemDir});
            this.DirMenu.Name = "DirMenu";
            this.DirMenu.Size = new System.Drawing.Size(196, 76);
            this.DirMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DirMenu_Opening);
            // 
            // NewTabItemDir
            // 
            NewTabItemDir.Name = "NewTabItemDir";
            NewTabItemDir.Size = new System.Drawing.Size(195, 22);
            NewTabItemDir.Text = "Abrir en nueva pestaña";
            NewTabItemDir.Click += new System.EventHandler(this.NewTabItemDir_Click);
            // 
            // SeparatorItemDir
            // 
            SeparatorItemDir.Name = "SeparatorItemDir";
            SeparatorItemDir.Size = new System.Drawing.Size(192, 6);
            // 
            // DelItemDir
            // 
            DelItemDir.Name = "DelItemDir";
            DelItemDir.Size = new System.Drawing.Size(195, 22);
            DelItemDir.Text = "Eliminar elemento";
            DelItemDir.Click += new System.EventHandler(this.DelItemDir_Click);
            // 
            // ClearItemDir
            // 
            ClearItemDir.Name = "ClearItemDir";
            ClearItemDir.Size = new System.Drawing.Size(195, 22);
            ClearItemDir.Text = "Limpiar lista";
            ClearItemDir.Click += new System.EventHandler(this.ClearItemDir_Click);
            // 
            // groupBox3
            // 
            groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox3.Controls.Add(label2);
            groupBox3.ForeColor = System.Drawing.Color.Red;
            groupBox3.Location = new System.Drawing.Point(7, 244);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(420, 109);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "¡Información!";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label2.Location = new System.Drawing.Point(3, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(414, 90);
            label2.TabIndex = 0;
            label2.Text = resources.GetString("label2.Text");
            label2.UseMnemonic = false;
            // 
            // CoverPage
            // 
            this.CoverPage.Controls.Add(groupBox7);
            this.CoverPage.Controls.Add(groupBox6);
            this.CoverPage.Controls.Add(groupBox5);
            this.CoverPage.Location = new System.Drawing.Point(4, 22);
            this.CoverPage.Name = "CoverPage";
            this.CoverPage.Size = new System.Drawing.Size(435, 359);
            this.CoverPage.TabIndex = 3;
            this.CoverPage.Text = "Caratulas";
            this.CoverPage.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox7.Controls.Add(this.button5);
            groupBox7.Controls.Add(this.button6);
            groupBox7.Controls.Add(this.button3);
            groupBox7.Controls.Add(this.button4);
            groupBox7.Controls.Add(this.CoverSources);
            groupBox7.Controls.Add(this.textBox1);
            groupBox7.Controls.Add(label4);
            groupBox7.Location = new System.Drawing.Point(7, 178);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(420, 178);
            groupBox7.TabIndex = 6;
            groupBox7.TabStop = false;
            groupBox7.Text = "Fuentes URL";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(386, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(28, 25);
            this.button5.TabIndex = 19;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(386, 72);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 25);
            this.button6.TabIndex = 18;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(386, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 31);
            this.button3.TabIndex = 17;
            this.button3.Text = "↓";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(386, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 31);
            this.button4.TabIndex = 16;
            this.button4.Text = "↑";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CoverSources
            // 
            this.CoverSources.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.CoverSources.Controls.Add(this.TPDisc);
            this.CoverSources.Controls.Add(this.TPFront);
            this.CoverSources.Controls.Add(this.TPFront3D);
            this.CoverSources.Controls.Add(this.TPFull);
            this.CoverSources.Location = new System.Drawing.Point(9, 72);
            this.CoverSources.Name = "CoverSources";
            this.CoverSources.SelectedIndex = 0;
            this.CoverSources.Size = new System.Drawing.Size(371, 100);
            this.CoverSources.TabIndex = 15;
            // 
            // TPDisc
            // 
            this.TPDisc.Controls.Add(this.CoverDiskSource);
            this.TPDisc.Location = new System.Drawing.Point(4, 25);
            this.TPDisc.Name = "TPDisc";
            this.TPDisc.Padding = new System.Windows.Forms.Padding(3);
            this.TPDisc.Size = new System.Drawing.Size(363, 71);
            this.TPDisc.TabIndex = 0;
            this.TPDisc.Text = "Disco";
            this.TPDisc.UseVisualStyleBackColor = true;
            // 
            // CoverDiskSource
            // 
            this.CoverDiskSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoverDiskSource.FormattingEnabled = true;
            this.CoverDiskSource.Location = new System.Drawing.Point(3, 3);
            this.CoverDiskSource.Name = "CoverDiskSource";
            this.CoverDiskSource.Size = new System.Drawing.Size(357, 65);
            this.CoverDiskSource.TabIndex = 5;
            // 
            // TPFront
            // 
            this.TPFront.Controls.Add(this.CoverFrontSource);
            this.TPFront.Location = new System.Drawing.Point(4, 25);
            this.TPFront.Name = "TPFront";
            this.TPFront.Padding = new System.Windows.Forms.Padding(3);
            this.TPFront.Size = new System.Drawing.Size(363, 71);
            this.TPFront.TabIndex = 1;
            this.TPFront.Text = "Frontal";
            this.TPFront.UseVisualStyleBackColor = true;
            // 
            // CoverFrontSource
            // 
            this.CoverFrontSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoverFrontSource.FormattingEnabled = true;
            this.CoverFrontSource.Location = new System.Drawing.Point(3, 3);
            this.CoverFrontSource.Name = "CoverFrontSource";
            this.CoverFrontSource.Size = new System.Drawing.Size(357, 65);
            this.CoverFrontSource.TabIndex = 6;
            // 
            // TPFront3D
            // 
            this.TPFront3D.Controls.Add(this.CoverFront3DSource);
            this.TPFront3D.Location = new System.Drawing.Point(4, 25);
            this.TPFront3D.Name = "TPFront3D";
            this.TPFront3D.Padding = new System.Windows.Forms.Padding(3);
            this.TPFront3D.Size = new System.Drawing.Size(363, 71);
            this.TPFront3D.TabIndex = 2;
            this.TPFront3D.Text = "Frontal 3D";
            this.TPFront3D.UseVisualStyleBackColor = true;
            // 
            // CoverFront3DSource
            // 
            this.CoverFront3DSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoverFront3DSource.FormattingEnabled = true;
            this.CoverFront3DSource.Location = new System.Drawing.Point(3, 3);
            this.CoverFront3DSource.Name = "CoverFront3DSource";
            this.CoverFront3DSource.Size = new System.Drawing.Size(357, 65);
            this.CoverFront3DSource.TabIndex = 6;
            // 
            // TPFull
            // 
            this.TPFull.Controls.Add(this.CoverFullSource);
            this.TPFull.Location = new System.Drawing.Point(4, 25);
            this.TPFull.Name = "TPFull";
            this.TPFull.Padding = new System.Windows.Forms.Padding(3);
            this.TPFull.Size = new System.Drawing.Size(363, 71);
            this.TPFull.TabIndex = 3;
            this.TPFull.Text = "Completa";
            this.TPFull.UseVisualStyleBackColor = true;
            // 
            // CoverFullSource
            // 
            this.CoverFullSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoverFullSource.FormattingEnabled = true;
            this.CoverFullSource.Location = new System.Drawing.Point(3, 3);
            this.CoverFullSource.Name = "CoverFullSource";
            this.CoverFullSource.Size = new System.Drawing.Size(357, 65);
            this.CoverFullSource.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(9, 47);
            this.textBox1.MaxLength = 255;
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(371, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.WordWrap = false;
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label4.Location = new System.Drawing.Point(6, 15);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(408, 29);
            label4.TabIndex = 1;
            label4.Text = "Los enlaces en la parte superior de cada lista tendran mayor prioridad, si no se " +
    "encuentra la caratula en el enlace con mayor prioridad, se utilizara el siguient" +
    "e.";
            label4.UseMnemonic = false;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox6.Controls.Add(this.button2);
            groupBox6.Controls.Add(this.button1);
            groupBox6.Controls.Add(this.CLRegion);
            groupBox6.Controls.Add(label3);
            groupBox6.Location = new System.Drawing.Point(7, 56);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(420, 116);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Idiomas preferidos para caratulas";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(386, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "↓";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(386, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "↑";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CLRegion
            // 
            this.CLRegion.FormattingEnabled = true;
            this.CLRegion.Location = new System.Drawing.Point(9, 61);
            this.CLRegion.MultiColumn = true;
            this.CLRegion.Name = "CLRegion";
            this.CLRegion.Size = new System.Drawing.Size(371, 49);
            this.CLRegion.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            label3.Location = new System.Drawing.Point(6, 16);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(408, 42);
            label3.TabIndex = 1;
            label3.Text = "Los idiomas en la parte superior izquierda de la lista tendran mas prioridad, de " +
    "forma que si no se encuentra una caratula para el idioma con mayor prioridad, se" +
    " utilizara el siguiente.";
            label3.UseMnemonic = false;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox5.Controls.Add(this.CBDisc);
            groupBox5.Controls.Add(this.CBFull);
            groupBox5.Controls.Add(this.CBFront3D);
            groupBox5.Controls.Add(this.CBFront);
            groupBox5.Location = new System.Drawing.Point(7, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(420, 44);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tipos de caratulas a descargar";
            // 
            // CBDisc
            // 
            this.CBDisc.AutoSize = true;
            this.CBDisc.Location = new System.Drawing.Point(6, 19);
            this.CBDisc.Name = "CBDisc";
            this.CBDisc.Size = new System.Drawing.Size(53, 17);
            this.CBDisc.TabIndex = 4;
            this.CBDisc.Text = "Disco";
            this.CBDisc.UseVisualStyleBackColor = true;
            this.CBDisc.CheckedChanged += new System.EventHandler(this.CBDisk_CheckedChanged);
            // 
            // CBFull
            // 
            this.CBFull.AutoSize = true;
            this.CBFull.Location = new System.Drawing.Point(342, 19);
            this.CBFull.Name = "CBFull";
            this.CBFull.Size = new System.Drawing.Size(70, 17);
            this.CBFull.TabIndex = 2;
            this.CBFull.Text = "Completa";
            this.CBFull.UseVisualStyleBackColor = true;
            // 
            // CBFront3D
            // 
            this.CBFront3D.AutoSize = true;
            this.CBFront3D.Location = new System.Drawing.Point(217, 19);
            this.CBFront3D.Name = "CBFront3D";
            this.CBFront3D.Size = new System.Drawing.Size(75, 17);
            this.CBFront3D.TabIndex = 1;
            this.CBFront3D.Text = "Frontal 3D";
            this.CBFront3D.UseVisualStyleBackColor = true;
            // 
            // CBFront
            // 
            this.CBFront.AutoSize = true;
            this.CBFront.Location = new System.Drawing.Point(109, 19);
            this.CBFront.Name = "CBFront";
            this.CBFront.Size = new System.Drawing.Size(58, 17);
            this.CBFront.TabIndex = 0;
            this.CBFront.Text = "Frontal";
            this.CBFront.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(173, 389);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(271, 82);
            label1.TabIndex = 5;
            label1.Text = "Este software fue desarrollado y probado por el equipo de HunterStars, para ser d" +
    "istribuido gratuitamente.\r\n\r\nPero, si es su deseo puede apoyarnos con una donaci" +
    "on.";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DialogPath
            // 
            this.DialogPath.Description = "Por favor elija un directorio que contenga backups de juegos GameCube.";
            this.DialogPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.DialogPath.ShowNewFolderButton = false;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 471);
            this.Controls.Add(label1);
            this.Controls.Add(MainTab);
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajustes de la aplicación";
            MainTab.ResumeLayout(false);
            this.DrivePage.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            this.ModMenu.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WiiPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCPicture)).EndInit();
            this.DriveMenu.ResumeLayout(false);
            this.DirPage.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            this.DirMenu.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            this.CoverPage.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            this.CoverSources.ResumeLayout(false);
            this.TPDisc.ResumeLayout(false);
            this.TPFront.ResumeLayout(false);
            this.TPFront3D.ResumeLayout(false);
            this.TPFull.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage DrivePage;
        private GCGM.Controls.ProgressBarEx SpaceBar;
        private System.Windows.Forms.PictureBox WiiPicture;
        private System.Windows.Forms.PictureBox GCPicture;
        private System.Windows.Forms.ListView DriveList;
        private System.Windows.Forms.ListView ModList;
        private System.Windows.Forms.ContextMenuStrip DriveMenu;
        private System.Windows.Forms.TabPage DirPage;
        private System.Windows.Forms.ListView DirList;
        private System.Windows.Forms.Button BTDelDir;
        private System.Windows.Forms.Button BTExplorerDir;
        private System.Windows.Forms.CheckBox CBSearchDir;
        private System.Windows.Forms.TextBox TBPathDir;
        private System.Windows.Forms.Button BTAddDir;
        private System.Windows.Forms.ContextMenuStrip ModMenu;
        private System.Windows.Forms.FolderBrowserDialog DialogPath;
        private System.Windows.Forms.ContextMenuStrip DirMenu;
        private System.Windows.Forms.TabPage CoverPage;
        private System.Windows.Forms.CheckBox CBFull;
        private System.Windows.Forms.CheckBox CBFront3D;
        private System.Windows.Forms.CheckBox CBFront;
        private System.Windows.Forms.CheckBox CBDisc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox CLRegion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl CoverSources;
        private System.Windows.Forms.TabPage TPDisc;
        private System.Windows.Forms.CheckedListBox CoverDiskSource;
        private System.Windows.Forms.TabPage TPFront;
        private System.Windows.Forms.TabPage TPFront3D;
        private System.Windows.Forms.TabPage TPFull;
        private System.Windows.Forms.CheckedListBox CoverFrontSource;
        private System.Windows.Forms.CheckedListBox CoverFront3DSource;
        private System.Windows.Forms.CheckedListBox CoverFullSource;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}