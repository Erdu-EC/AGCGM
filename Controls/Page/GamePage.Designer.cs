namespace AGCGM.Controls.Page
{
    partial class GamePage
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePage));
            this.ColumnImage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnMaker = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnLenght = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTAdd = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTRemove = new System.Windows.Forms.ToolStripButton();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTClear = new System.Windows.Forms.ToolStripButton();
            this.BTDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTRefresh = new System.Windows.Forms.ToolStripButton();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTDelete = new System.Windows.Forms.ToolStripButton();
            this.GameList = new System.Windows.Forms.ListView();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.transferirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferirComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMTransferFull = new System.Windows.Forms.ToolStripMenuItem();
            this.vacioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMTransferTrim = new System.Windows.Forms.ToolStripMenuItem();
            this.vacioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.reducirISOComprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.descargarCaratulasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.PBSpace = new GCGM.Controls.ProgressBarEx(this.components);
            this.vacioToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnImage
            // 
            this.ColumnImage.Text = "Imagen";
            this.ColumnImage.Width = 102;
            // 
            // ColumnCode
            // 
            this.ColumnCode.Text = "Codigo";
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.Text = "Titulo";
            this.ColumnTitle.Width = 155;
            // 
            // ColumnMaker
            // 
            this.ColumnMaker.Text = "Creador";
            this.ColumnMaker.Width = 107;
            // 
            // ColumnCountry
            // 
            this.ColumnCountry.Text = "Region";
            this.ColumnCountry.Width = 71;
            // 
            // ColumnLenght
            // 
            this.ColumnLenght.Text = "Tamaño";
            this.ColumnLenght.Width = 73;
            // 
            // ColumnFile
            // 
            this.ColumnFile.Text = "Fichero";
            this.ColumnFile.Width = 75;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTAdd,
            this.Separator1,
            this.BTRemove,
            this.Separator2,
            this.BTClear,
            this.BTDownload,
            this.toolStripSeparator7,
            this.toolStripSeparator8,
            this.Separator3,
            this.BTRefresh,
            this.Separator4,
            this.BTDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(627, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTAdd
            // 
            this.BTAdd.ForeColor = System.Drawing.Color.White;
            this.BTAdd.Image = global::AGCGM.Properties.Resources.add_white_24;
            this.BTAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.Size = new System.Drawing.Size(74, 28);
            this.BTAdd.Text = "Añadir";
            this.BTAdd.Click += new System.EventHandler(this.BTAdd_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(6, 31);
            // 
            // BTRemove
            // 
            this.BTRemove.Enabled = false;
            this.BTRemove.ForeColor = System.Drawing.Color.White;
            this.BTRemove.Image = global::AGCGM.Properties.Resources.remove_white_24;
            this.BTRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTRemove.Name = "BTRemove";
            this.BTRemove.Size = new System.Drawing.Size(88, 28);
            this.BTRemove.Text = "Remover";
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(6, 31);
            // 
            // BTClear
            // 
            this.BTClear.ForeColor = System.Drawing.Color.White;
            this.BTClear.Image = global::AGCGM.Properties.Resources.delete_white_24;
            this.BTClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTClear.Name = "BTClear";
            this.BTClear.Size = new System.Drawing.Size(79, 28);
            this.BTClear.Text = "Limpiar";
            // 
            // BTDownload
            // 
            this.BTDownload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BTDownload.ForeColor = System.Drawing.Color.White;
            this.BTDownload.Image = global::AGCGM.Properties.Resources.cloud_download_white_24;
            this.BTDownload.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTDownload.Name = "BTDownload";
            this.BTDownload.Size = new System.Drawing.Size(152, 28);
            this.BTDownload.Text = "Descargar caratulas";
            this.BTDownload.Click += new System.EventHandler(this.BTDownload_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(6, 31);
            // 
            // BTRefresh
            // 
            this.BTRefresh.ForeColor = System.Drawing.Color.White;
            this.BTRefresh.Image = global::AGCGM.Properties.Resources.add_white_24;
            this.BTRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTRefresh.Name = "BTRefresh";
            this.BTRefresh.Size = new System.Drawing.Size(92, 28);
            this.BTRefresh.Text = "Actualizar";
            // 
            // Separator4
            // 
            this.Separator4.Name = "Separator4";
            this.Separator4.Size = new System.Drawing.Size(6, 31);
            // 
            // BTDelete
            // 
            this.BTDelete.Enabled = false;
            this.BTDelete.ForeColor = System.Drawing.Color.White;
            this.BTDelete.Image = global::AGCGM.Properties.Resources.remove_white_24;
            this.BTDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.Size = new System.Drawing.Size(82, 28);
            this.BTDelete.Text = "Eliminar";
            // 
            // GameList
            // 
            this.GameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnImage,
            this.ColumnCode,
            this.ColumnTitle,
            this.ColumnMaker,
            this.ColumnCountry,
            this.ColumnLenght,
            this.ColumnFile});
            this.GameList.ContextMenuStrip = this.ContextMenu;
            this.GameList.FullRowSelect = true;
            this.GameList.GridLines = true;
            this.GameList.HideSelection = false;
            this.GameList.Location = new System.Drawing.Point(0, 32);
            this.GameList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.GameList.Name = "GameList";
            this.GameList.Size = new System.Drawing.Size(627, 210);
            this.GameList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.GameList.TabIndex = 5;
            this.GameList.UseCompatibleStateImageBehavior = false;
            this.GameList.View = System.Windows.Forms.View.Details;
            this.GameList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.GameList_ColumnClick);
            this.GameList.SelectedIndexChanged += new System.EventHandler(this.GameList_SelectedIndexChanged);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferirToolStripMenuItem,
            this.transferirComoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.reducirISOComprimirToolStripMenuItem,
            this.toolStripMenuItem3,
            this.descargarCaratulasToolStripMenuItem,
            this.toolStripMenuItem2});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(205, 132);
            // 
            // transferirToolStripMenuItem
            // 
            this.transferirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacioToolStripMenuItem2});
            this.transferirToolStripMenuItem.Name = "transferirToolStripMenuItem";
            this.transferirToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.transferirToolStripMenuItem.Text = "Transferir";
            this.transferirToolStripMenuItem.DropDownOpening += new System.EventHandler(this.TSMTransferAllTypes_DropDownOpening);
            // 
            // transferirComoToolStripMenuItem
            // 
            this.transferirComoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMTransferFull,
            this.TSMTransferTrim});
            this.transferirComoToolStripMenuItem.Name = "transferirComoToolStripMenuItem";
            this.transferirComoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.transferirComoToolStripMenuItem.Text = "Transferir como";
            // 
            // TSMTransferFull
            // 
            this.TSMTransferFull.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacioToolStripMenuItem});
            this.TSMTransferFull.Name = "TSMTransferFull";
            this.TSMTransferFull.Size = new System.Drawing.Size(178, 22);
            this.TSMTransferFull.Text = "ISO Completa hacia";
            this.TSMTransferFull.ToolTipText = resources.GetString("TSMTransferFull.ToolTipText");
            this.TSMTransferFull.DropDownOpening += new System.EventHandler(this.TSMTransferAllTypes_DropDownOpening);
            // 
            // vacioToolStripMenuItem
            // 
            this.vacioToolStripMenuItem.Enabled = false;
            this.vacioToolStripMenuItem.Name = "vacioToolStripMenuItem";
            this.vacioToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.vacioToolStripMenuItem.Text = "<Vacio>";
            // 
            // TSMTransferTrim
            // 
            this.TSMTransferTrim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacioToolStripMenuItem1});
            this.TSMTransferTrim.Name = "TSMTransferTrim";
            this.TSMTransferTrim.Size = new System.Drawing.Size(178, 22);
            this.TSMTransferTrim.Text = "ISO Reducida hacia";
            this.TSMTransferTrim.ToolTipText = "El ISO resultante sera de menor tamaño, al eliminar los datos basura de esta.\r\n\r\n" +
    "Si se realiza, se obtendra una ISO mas ligera y perfectamente funcional.";
            this.TSMTransferTrim.DropDownOpening += new System.EventHandler(this.TSMTransferAllTypes_DropDownOpening);
            // 
            // vacioToolStripMenuItem1
            // 
            this.vacioToolStripMenuItem1.Enabled = false;
            this.vacioToolStripMenuItem1.Name = "vacioToolStripMenuItem1";
            this.vacioToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.vacioToolStripMenuItem1.Text = "<Vacio>";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // reducirISOComprimirToolStripMenuItem
            // 
            this.reducirISOComprimirToolStripMenuItem.Name = "reducirISOComprimirToolStripMenuItem";
            this.reducirISOComprimirToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.reducirISOComprimirToolStripMenuItem.Text = "Reducir ISO (Comprimir)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(201, 6);
            // 
            // descargarCaratulasToolStripMenuItem
            // 
            this.descargarCaratulasToolStripMenuItem.Name = "descargarCaratulasToolStripMenuItem";
            this.descargarCaratulasToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.descargarCaratulasToolStripMenuItem.Text = "Descargar caratulas";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(201, 6);
            // 
            // PBSpace
            // 
            this.PBSpace.AnimationInterval = 4000;
            this.PBSpace.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.PBSpace.BorderPadding = 1;
            this.PBSpace.BorderWidth = 1;
            this.PBSpace.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBSpace.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PBSpace.Location = new System.Drawing.Point(0, 247);
            this.PBSpace.MarqueeAnimationSpeed = 0;
            this.PBSpace.Name = "PBSpace";
            this.PBSpace.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PBSpace.PausedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PBSpace.Size = new System.Drawing.Size(627, 30);
            this.PBSpace.State = GCGM.Controls.ProgressBarEx.ProgressBarState.Normal;
            this.PBSpace.Style = GCGM.Controls.ProgressBarEx.ProgressBarStyle.Continuous;
            this.PBSpace.TabIndex = 4;
            this.PBSpace.TextAlign = GCGM.Controls.ProgressBarEx.ContentAlignment.MiddleCenter;
            this.PBSpace.TextColor = System.Drawing.Color.Black;
            this.PBSpace.TextEllipsis = System.Drawing.StringTrimming.EllipsisCharacter;
            this.PBSpace.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.PBSpace.TextFormat = "{0}%";
            // 
            // vacioToolStripMenuItem2
            // 
            this.vacioToolStripMenuItem2.Enabled = false;
            this.vacioToolStripMenuItem2.Name = "vacioToolStripMenuItem2";
            this.vacioToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.vacioToolStripMenuItem2.Text = "<Vacio>";
            // 
            // GamePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.GameList);
            this.Controls.Add(this.PBSpace);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "GamePage";
            this.Size = new System.Drawing.Size(627, 277);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTAdd;
        private System.Windows.Forms.ToolStripButton BTDownload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private GCGM.Controls.ProgressBarEx PBSpace;
        private System.Windows.Forms.ListView GameList;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripButton BTRemove;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripButton BTClear;
        private System.Windows.Forms.ColumnHeader ColumnImage;
        private System.Windows.Forms.ColumnHeader ColumnCode;
        private System.Windows.Forms.ColumnHeader ColumnTitle;
        private System.Windows.Forms.ColumnHeader ColumnMaker;
        private System.Windows.Forms.ColumnHeader ColumnCountry;
        private System.Windows.Forms.ColumnHeader ColumnLenght;
        private System.Windows.Forms.ColumnHeader ColumnFile;
        private System.Windows.Forms.ToolStripSeparator Separator3;
        private System.Windows.Forms.ToolStripButton BTRefresh;
        private System.Windows.Forms.ToolStripSeparator Separator4;
        private System.Windows.Forms.ToolStripButton BTDelete;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem transferirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferirComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMTransferFull;
        private System.Windows.Forms.ToolStripMenuItem TSMTransferTrim;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem descargarCaratulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reducirISOComprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem vacioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vacioToolStripMenuItem2;
    }
}
