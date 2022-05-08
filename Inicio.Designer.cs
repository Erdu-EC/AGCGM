namespace AGCGM
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.TopMenu_OpenBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu_OpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu_OpenDirectory_MainTab = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu_OpenDirectory_NewTab = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu_OpenDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.vacioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TopMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.StatusMenu = new System.Windows.Forms.StatusStrip();
            this.StatusMenu_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusMenu_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusMenu_Button = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusMenu_File = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this._MainTabs = new System.Windows.Forms.TabControl();
            this.LogPage = new System.Windows.Forms.TabPage();
            this.logPage1 = new AGCGM.Controls.Page.LogPage();
            this.DBPage = new System.Windows.Forms.TabPage();
            this.dbPage1 = new AGCGM.Controls.Page.DBPage();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.gamePage1 = new AGCGM.Controls.Page.GamePage();
            this.DPData = new AGCGM.Controls.DataPanel();
            this.SideSplit = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LayoutTransfer = new System.Windows.Forms.TableLayoutPanel();
            this.BTTransferClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LayoutDownload = new System.Windows.Forms.TableLayoutPanel();
            this.BTDownloadClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenu.SuspendLayout();
            this.StatusMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this._MainTabs.SuspendLayout();
            this.LogPage.SuspendLayout();
            this.DBPage.SuspendLayout();
            this.MainPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SideSplit)).BeginInit();
            this.SideSplit.Panel1.SuspendLayout();
            this.SideSplit.Panel2.SuspendLayout();
            this.SideSplit.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMenu_OpenBackup,
            this.TopMenu_OpenDirectory,
            this.TopMenu_OpenDrive,
            this.toolStripSeparator1,
            this.TopMenu_Exit});
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // TopMenu_OpenBackup
            // 
            this.TopMenu_OpenBackup.Image = global::AGCGM.Properties.Resources.note_add_black_24dp;
            this.TopMenu_OpenBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_OpenBackup.Name = "TopMenu_OpenBackup";
            this.TopMenu_OpenBackup.Size = new System.Drawing.Size(181, 30);
            this.TopMenu_OpenBackup.Text = "Abrir...";
            this.TopMenu_OpenBackup.Click += new System.EventHandler(this.TopMenu_OpenBackup_Click);
            // 
            // TopMenu_OpenDirectory
            // 
            this.TopMenu_OpenDirectory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMenu_OpenDirectory_MainTab,
            this.TopMenu_OpenDirectory_NewTab});
            this.TopMenu_OpenDirectory.Image = global::AGCGM.Properties.Resources.new_folder_black_24dp;
            this.TopMenu_OpenDirectory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_OpenDirectory.Name = "TopMenu_OpenDirectory";
            this.TopMenu_OpenDirectory.Size = new System.Drawing.Size(181, 30);
            this.TopMenu_OpenDirectory.Text = "Abrir directorio";
            // 
            // TopMenu_OpenDirectory_MainTab
            // 
            this.TopMenu_OpenDirectory_MainTab.Image = global::AGCGM.Properties.Resources.home_black_24dp;
            this.TopMenu_OpenDirectory_MainTab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_OpenDirectory_MainTab.Name = "TopMenu_OpenDirectory_MainTab";
            this.TopMenu_OpenDirectory_MainTab.Size = new System.Drawing.Size(172, 30);
            this.TopMenu_OpenDirectory_MainTab.Text = "Pestaña principal";
            this.TopMenu_OpenDirectory_MainTab.Click += new System.EventHandler(this.TopMenu_OpenDirectory_MainTab_Click);
            // 
            // TopMenu_OpenDirectory_NewTab
            // 
            this.TopMenu_OpenDirectory_NewTab.Image = global::AGCGM.Properties.Resources.tab_black_24dp;
            this.TopMenu_OpenDirectory_NewTab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_OpenDirectory_NewTab.Name = "TopMenu_OpenDirectory_NewTab";
            this.TopMenu_OpenDirectory_NewTab.Size = new System.Drawing.Size(172, 30);
            this.TopMenu_OpenDirectory_NewTab.Text = "Nueva pestaña";
            this.TopMenu_OpenDirectory_NewTab.Click += new System.EventHandler(this.TopMenu_OpenDirectory_NewTab_Click);
            // 
            // TopMenu_OpenDrive
            // 
            this.TopMenu_OpenDrive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacioToolStripMenuItem});
            this.TopMenu_OpenDrive.Image = global::AGCGM.Properties.Resources.usb_black_24dp;
            this.TopMenu_OpenDrive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_OpenDrive.Name = "TopMenu_OpenDrive";
            this.TopMenu_OpenDrive.Size = new System.Drawing.Size(181, 30);
            this.TopMenu_OpenDrive.Text = "Montar dispositivo";
            this.TopMenu_OpenDrive.DropDownOpening += new System.EventHandler(this.TopMenu_OpenDrive_DropDownOpening);
            // 
            // vacioToolStripMenuItem
            // 
            this.vacioToolStripMenuItem.Name = "vacioToolStripMenuItem";
            this.vacioToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.vacioToolStripMenuItem.Text = "<Vacio>";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // TopMenu_Exit
            // 
            this.TopMenu_Exit.Image = global::AGCGM.Properties.Resources.exit_to_app_black_24dp;
            this.TopMenu_Exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_Exit.Name = "TopMenu_Exit";
            this.TopMenu_Exit.Size = new System.Drawing.Size(181, 30);
            this.TopMenu_Exit.Text = "Salir";
            this.TopMenu_Exit.Click += new System.EventHandler(this.TopMenu_Exit_Click);
            // 
            // opcionesToolStripMenuItem
            // 
            opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopMenu_Settings});
            opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // TopMenu_Settings
            // 
            this.TopMenu_Settings.Image = global::AGCGM.Properties.Resources.settings_black_24dp;
            this.TopMenu_Settings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TopMenu_Settings.Name = "TopMenu_Settings";
            this.TopMenu_Settings.Size = new System.Drawing.Size(158, 30);
            this.TopMenu_Settings.Text = "Configuración";
            this.TopMenu_Settings.Click += new System.EventHandler(this.TopMenu_Settings_Click);
            // 
            // TopMenu
            // 
            this.TopMenu.BackColor = System.Drawing.SystemColors.Window;
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            archivoToolStripMenuItem,
            opcionesToolStripMenuItem});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(974, 24);
            this.TopMenu.TabIndex = 2;
            this.TopMenu.Text = "menuStrip1";
            // 
            // StatusMenu
            // 
            this.StatusMenu.AutoSize = false;
            this.StatusMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.StatusMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMenu_Label,
            this.StatusMenu_Progress,
            this.StatusMenu_Button,
            this.StatusMenu_File});
            this.StatusMenu.Location = new System.Drawing.Point(0, 579);
            this.StatusMenu.Name = "StatusMenu";
            this.StatusMenu.Size = new System.Drawing.Size(974, 22);
            this.StatusMenu.TabIndex = 3;
            this.StatusMenu.Text = "statusStrip1";
            // 
            // StatusMenu_Label
            // 
            this.StatusMenu_Label.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.StatusMenu_Label.ForeColor = System.Drawing.Color.White;
            this.StatusMenu_Label.Margin = new System.Windows.Forms.Padding(0, 1, 0, 2);
            this.StatusMenu_Label.Name = "StatusMenu_Label";
            this.StatusMenu_Label.Size = new System.Drawing.Size(35, 19);
            this.StatusMenu_Label.Text = "Listo";
            // 
            // StatusMenu_Progress
            // 
            this.StatusMenu_Progress.Name = "StatusMenu_Progress";
            this.StatusMenu_Progress.Size = new System.Drawing.Size(100, 16);
            this.StatusMenu_Progress.Step = 1;
            this.StatusMenu_Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.StatusMenu_Progress.Visible = false;
            // 
            // StatusMenu_Button
            // 
            this.StatusMenu_Button.AutoSize = false;
            this.StatusMenu_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusMenu_Button.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.StatusMenu_Button.Image = global::AGCGM.Properties.Resources.cancel_white_24;
            this.StatusMenu_Button.IsLink = true;
            this.StatusMenu_Button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.StatusMenu_Button.Name = "StatusMenu_Button";
            this.StatusMenu_Button.Size = new System.Drawing.Size(16, 17);
            this.StatusMenu_Button.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StatusMenu_Button.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.StatusMenu_Button.Visible = false;
            // 
            // StatusMenu_File
            // 
            this.StatusMenu_File.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.StatusMenu_File.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.StatusMenu_File.ForeColor = System.Drawing.Color.Silver;
            this.StatusMenu_File.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.StatusMenu_File.Name = "StatusMenu_File";
            this.StatusMenu_File.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.StatusMenu_File.Size = new System.Drawing.Size(918, 17);
            this.StatusMenu_File.Spring = true;
            this.StatusMenu_File.Text = "File";
            this.StatusMenu_File.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusMenu_File.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MainSplit);
            this.splitContainer1.Panel1MinSize = 638;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.SideSplit);
            this.splitContainer1.Panel2MinSize = 290;
            this.splitContainer1.Size = new System.Drawing.Size(974, 555);
            this.splitContainer1.SplitterDistance = 642;
            this.splitContainer1.TabIndex = 4;
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this._MainTabs);
            this.MainSplit.Panel1MinSize = 300;
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.MainSplit.Panel2.Controls.Add(this.DPData);
            this.MainSplit.Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.MainSplit.Panel2MinSize = 202;
            this.MainSplit.Size = new System.Drawing.Size(638, 551);
            this.MainSplit.SplitterDistance = 327;
            this.MainSplit.TabIndex = 0;
            // 
            // _MainTabs
            // 
            this._MainTabs.Controls.Add(this.LogPage);
            this._MainTabs.Controls.Add(this.DBPage);
            this._MainTabs.Controls.Add(this.MainPage);
            this._MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MainTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._MainTabs.ItemSize = new System.Drawing.Size(58, 32);
            this._MainTabs.Location = new System.Drawing.Point(0, 0);
            this._MainTabs.Margin = new System.Windows.Forms.Padding(0);
            this._MainTabs.Name = "_MainTabs";
            this._MainTabs.Padding = new System.Drawing.Point(9, 3);
            this._MainTabs.SelectedIndex = 0;
            this._MainTabs.ShowToolTips = true;
            this._MainTabs.Size = new System.Drawing.Size(638, 327);
            this._MainTabs.TabIndex = 0;
            this._MainTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainTabs_Selecting);
            // 
            // LogPage
            // 
            this.LogPage.Controls.Add(this.logPage1);
            this.LogPage.Location = new System.Drawing.Point(4, 36);
            this.LogPage.Name = "LogPage";
            this.LogPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogPage.Size = new System.Drawing.Size(630, 287);
            this.LogPage.TabIndex = 2;
            this.LogPage.Text = "Log";
            this.LogPage.UseVisualStyleBackColor = true;
            // 
            // logPage1
            // 
            this.logPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPage1.Location = new System.Drawing.Point(3, 3);
            this.logPage1.Name = "logPage1";
            this.logPage1.Size = new System.Drawing.Size(624, 281);
            this.logPage1.TabIndex = 0;
            // 
            // DBPage
            // 
            this.DBPage.Controls.Add(this.dbPage1);
            this.DBPage.Location = new System.Drawing.Point(4, 36);
            this.DBPage.Name = "DBPage";
            this.DBPage.Padding = new System.Windows.Forms.Padding(3);
            this.DBPage.Size = new System.Drawing.Size(630, 287);
            this.DBPage.TabIndex = 3;
            this.DBPage.Text = "Base de datos";
            this.DBPage.UseVisualStyleBackColor = true;
            // 
            // dbPage1
            // 
            this.dbPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbPage1.Location = new System.Drawing.Point(3, 3);
            this.dbPage1.Name = "dbPage1";
            this.dbPage1.Size = new System.Drawing.Size(624, 281);
            this.dbPage1.TabIndex = 0;
            // 
            // MainPage
            // 
            this.MainPage.Controls.Add(this.gamePage1);
            this.MainPage.Location = new System.Drawing.Point(4, 36);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(630, 287);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "Juegos";
            this.MainPage.UseVisualStyleBackColor = true;
            // 
            // gamePage1
            // 
            this.gamePage1.Banners = null;
            this.gamePage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamePage1.DriveData = null;
            this.gamePage1.Location = new System.Drawing.Point(3, 3);
            this.gamePage1.Name = "gamePage1";
            this.gamePage1.Size = new System.Drawing.Size(624, 281);
            this.gamePage1.TabIndex = 0;
            // 
            // DPData
            // 
            this.DPData.Cover = ((System.Drawing.Image)(resources.GetObject("DPData.Cover")));
            this.DPData.Description = "Descripción...";
            this.DPData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DPData.Languages = "-";
            this.DPData.Location = new System.Drawing.Point(0, 0);
            this.DPData.Name = "DPData";
            this.DPData.Size = new System.Drawing.Size(635, 220);
            this.DPData.TabIndex = 0;
            this.DPData.Title = "Titulo";
            this.DPData.Trimmed = "No Trimmed";
            // 
            // SideSplit
            // 
            this.SideSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SideSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideSplit.Location = new System.Drawing.Point(0, 0);
            this.SideSplit.Name = "SideSplit";
            this.SideSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SideSplit.Panel1
            // 
            this.SideSplit.Panel1.Controls.Add(this.panel4);
            this.SideSplit.Panel1.Controls.Add(this.BTTransferClear);
            this.SideSplit.Panel1.Controls.Add(this.label2);
            // 
            // SideSplit.Panel2
            // 
            this.SideSplit.Panel2.Controls.Add(this.panel3);
            this.SideSplit.Panel2.Controls.Add(this.BTDownloadClear);
            this.SideSplit.Panel2.Controls.Add(this.label3);
            this.SideSplit.Size = new System.Drawing.Size(328, 555);
            this.SideSplit.SplitterDistance = 296;
            this.SideSplit.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.LayoutTransfer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(324, 229);
            this.panel4.TabIndex = 11;
            // 
            // LayoutTransfer
            // 
            this.LayoutTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutTransfer.AutoSize = true;
            this.LayoutTransfer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LayoutTransfer.ColumnCount = 1;
            this.LayoutTransfer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutTransfer.Location = new System.Drawing.Point(0, 0);
            this.LayoutTransfer.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutTransfer.MinimumSize = new System.Drawing.Size(0, 20);
            this.LayoutTransfer.Name = "LayoutTransfer";
            this.LayoutTransfer.RowCount = 1;
            this.LayoutTransfer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutTransfer.Size = new System.Drawing.Size(324, 20);
            this.LayoutTransfer.TabIndex = 11;
            // 
            // BTTransferClear
            // 
            this.BTTransferClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BTTransferClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTTransferClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTTransferClear.Location = new System.Drawing.Point(0, 265);
            this.BTTransferClear.Name = "BTTransferClear";
            this.BTTransferClear.Size = new System.Drawing.Size(324, 27);
            this.BTTransferClear.TabIndex = 10;
            this.BTTransferClear.Text = "Limpiar finalizados";
            this.BTTransferClear.UseVisualStyleBackColor = false;
            this.BTTransferClear.Click += new System.EventHandler(this.BTTransferClear_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Transferencias";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.LayoutDownload);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 188);
            this.panel3.TabIndex = 10;
            // 
            // LayoutDownload
            // 
            this.LayoutDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutDownload.AutoSize = true;
            this.LayoutDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LayoutDownload.ColumnCount = 1;
            this.LayoutDownload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutDownload.Location = new System.Drawing.Point(0, 0);
            this.LayoutDownload.Margin = new System.Windows.Forms.Padding(0);
            this.LayoutDownload.MinimumSize = new System.Drawing.Size(0, 20);
            this.LayoutDownload.Name = "LayoutDownload";
            this.LayoutDownload.RowCount = 1;
            this.LayoutDownload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutDownload.Size = new System.Drawing.Size(324, 20);
            this.LayoutDownload.TabIndex = 10;
            // 
            // BTDownloadClear
            // 
            this.BTDownloadClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BTDownloadClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTDownloadClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTDownloadClear.Location = new System.Drawing.Point(0, 224);
            this.BTDownloadClear.Name = "BTDownloadClear";
            this.BTDownloadClear.Size = new System.Drawing.Size(324, 27);
            this.BTDownloadClear.TabIndex = 9;
            this.BTDownloadClear.Text = "Limpiar finalizados";
            this.BTDownloadClear.UseVisualStyleBackColor = false;
            this.BTDownloadClear.Click += new System.EventHandler(this.BTDownloadClear_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descargas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "cancel_black_18");
            this.Icons.Images.SetKeyName(1, "warning_black_18");
            this.Icons.Images.SetKeyName(2, "info_black_18");
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.StatusMenu);
            this.Controls.Add(this.TopMenu);
            this.MinimumSize = new System.Drawing.Size(980, 550);
            this.Name = "Inicio";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            this.Shown += new System.EventHandler(this.Inicio_Shown);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.StatusMenu.ResumeLayout(false);
            this.StatusMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this._MainTabs.ResumeLayout(false);
            this.LogPage.ResumeLayout(false);
            this.DBPage.ResumeLayout(false);
            this.MainPage.ResumeLayout(false);
            this.SideSplit.Panel1.ResumeLayout(false);
            this.SideSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SideSplit)).EndInit();
            this.SideSplit.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.TabControl _MainTabs;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.TabPage MainPage;
        private Controls.Page.GamePage gamePage1;
        private System.Windows.Forms.ToolStripStatusLabel StatusMenu_Label;
        private System.Windows.Forms.ToolStripProgressBar StatusMenu_Progress;
        private System.Windows.Forms.ToolStripStatusLabel StatusMenu_Button;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_OpenBackup;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_OpenDirectory;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_OpenDrive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_OpenDirectory_MainTab;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_OpenDirectory_NewTab;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_Exit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem vacioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TopMenu_Settings;
        private System.Windows.Forms.StatusStrip StatusMenu;
        private System.Windows.Forms.ToolStripStatusLabel StatusMenu_File;
        private System.Windows.Forms.TabPage LogPage;
        private Controls.Page.LogPage logPage1;
        private System.Windows.Forms.TabPage DBPage;
        private Controls.Page.DBPage dbPage1;
        private System.Windows.Forms.SplitContainer SideSplit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel LayoutTransfer;
        private System.Windows.Forms.Button BTTransferClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel LayoutDownload;
        private System.Windows.Forms.Button BTDownloadClear;
        private System.Windows.Forms.Label label3;
        private Controls.DataPanel DPData;
    }
}

