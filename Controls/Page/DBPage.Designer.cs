namespace AGCGM.Controls.Page
{
    partial class DBPage
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Error", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Advertencia", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Información", System.Windows.Forms.HorizontalAlignment.Left);
            this.ColumnCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TBSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonFilter_Wii = new System.Windows.Forms.ToolStripButton();
            this.ButtonFilter_GameCube = new System.Windows.Forms.ToolStripButton();
            this.ButtonFilter_Other = new System.Windows.Forms.ToolStripButton();
            this.BTFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.List = new System.Windows.Forms.ListView();
            this.ColumnPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnLang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDeveloper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnCode
            // 
            this.ColumnCode.Text = "Codigo";
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.Text = "Titulo";
            this.ColumnTitle.Width = 231;
            // 
            // ColumnRegion
            // 
            this.ColumnRegion.Text = "Región";
            this.ColumnRegion.Width = 75;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.TBSearch,
            this.toolStripSeparator1,
            this.ButtonFilter_Wii,
            this.ButtonFilter_GameCube,
            this.ButtonFilter_Other,
            this.BTFilter,
            this.toolStripSeparator3});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(627, 31);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 28);
            this.toolStripLabel2.Text = "Buscar:";
            // 
            // TBSearch
            // 
            this.TBSearch.AutoSize = false;
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.TBSearch.Size = new System.Drawing.Size(303, 31);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ButtonFilter_Wii
            // 
            this.ButtonFilter_Wii.CheckOnClick = true;
            this.ButtonFilter_Wii.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ButtonFilter_Wii.ForeColor = System.Drawing.Color.White;
            this.ButtonFilter_Wii.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonFilter_Wii.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonFilter_Wii.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.ButtonFilter_Wii.Name = "ButtonFilter_Wii";
            this.ButtonFilter_Wii.Size = new System.Drawing.Size(30, 28);
            this.ButtonFilter_Wii.Text = "Wii";
            // 
            // ButtonFilter_GameCube
            // 
            this.ButtonFilter_GameCube.Checked = true;
            this.ButtonFilter_GameCube.CheckOnClick = true;
            this.ButtonFilter_GameCube.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ButtonFilter_GameCube.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ButtonFilter_GameCube.ForeColor = System.Drawing.Color.White;
            this.ButtonFilter_GameCube.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonFilter_GameCube.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonFilter_GameCube.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.ButtonFilter_GameCube.Name = "ButtonFilter_GameCube";
            this.ButtonFilter_GameCube.Size = new System.Drawing.Size(76, 28);
            this.ButtonFilter_GameCube.Text = "GameCube";
            // 
            // ButtonFilter_Other
            // 
            this.ButtonFilter_Other.CheckOnClick = true;
            this.ButtonFilter_Other.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ButtonFilter_Other.ForeColor = System.Drawing.Color.White;
            this.ButtonFilter_Other.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonFilter_Other.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonFilter_Other.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.ButtonFilter_Other.Name = "ButtonFilter_Other";
            this.ButtonFilter_Other.Size = new System.Drawing.Size(45, 28);
            this.ButtonFilter_Other.Text = "Otros";
            // 
            // BTFilter
            // 
            this.BTFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BTFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BTFilter.ForeColor = System.Drawing.Color.White;
            this.BTFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTFilter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.BTFilter.Name = "BTFilter";
            this.BTFilter.Size = new System.Drawing.Size(63, 28);
            this.BTFilter.Text = "¡Filtrar!";
            this.BTFilter.Click += new System.EventHandler(this.BTFilter_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // List
            // 
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnCode,
            this.ColumnTitle,
            this.ColumnPlayers,
            this.ColumnType,
            this.ColumnRegion,
            this.ColumnLang,
            this.ColumnDeveloper,
            this.ColumnPublisher,
            this.ColumnDate});
            this.List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List.FullRowSelect = true;
            listViewGroup1.Header = "Error";
            listViewGroup1.Name = "Error";
            listViewGroup2.Header = "Advertencia";
            listViewGroup2.Name = "Warning";
            listViewGroup3.Header = "Información";
            listViewGroup3.Name = "Information";
            this.List.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.List.HideSelection = false;
            this.List.Location = new System.Drawing.Point(0, 31);
            this.List.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.List.MultiSelect = false;
            this.List.Name = "List";
            this.List.ShowGroups = false;
            this.List.ShowItemToolTips = true;
            this.List.Size = new System.Drawing.Size(627, 246);
            this.List.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.List.TabIndex = 6;
            this.List.UseCompatibleStateImageBehavior = false;
            this.List.View = System.Windows.Forms.View.Details;
            this.List.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.List_ColumnClick);
            // 
            // ColumnPlayers
            // 
            this.ColumnPlayers.Text = "Jugadores";
            this.ColumnPlayers.Width = 61;
            // 
            // ColumnType
            // 
            this.ColumnType.Text = "Tipo";
            this.ColumnType.Width = 87;
            // 
            // ColumnLang
            // 
            this.ColumnLang.Text = "Idiomas";
            this.ColumnLang.Width = 81;
            // 
            // ColumnDeveloper
            // 
            this.ColumnDeveloper.Text = "Desarrollador";
            this.ColumnDeveloper.Width = 91;
            // 
            // ColumnPublisher
            // 
            this.ColumnPublisher.Text = "Distribuidor";
            this.ColumnPublisher.Width = 91;
            // 
            // ColumnDate
            // 
            this.ColumnDate.Text = "Fecha lanzamiento";
            this.ColumnDate.Width = 102;
            // 
            // DBPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.List);
            this.Controls.Add(this.toolStrip2);
            this.DoubleBuffered = true;
            this.Name = "DBPage";
            this.Size = new System.Drawing.Size(627, 277);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton ButtonFilter_GameCube;
        private System.Windows.Forms.ListView List;
        private System.Windows.Forms.ColumnHeader ColumnDeveloper;
        private System.Windows.Forms.ColumnHeader ColumnPublisher;
        private System.Windows.Forms.ColumnHeader ColumnTitle;
        private System.Windows.Forms.ColumnHeader ColumnRegion;
        private System.Windows.Forms.ColumnHeader ColumnDate;
        private System.Windows.Forms.ColumnHeader ColumnCode;
        private System.Windows.Forms.ColumnHeader ColumnType;
        private System.Windows.Forms.ToolStripTextBox TBSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ButtonFilter_Other;
        private System.Windows.Forms.ToolStripButton ButtonFilter_Wii;
        private System.Windows.Forms.ColumnHeader ColumnPlayers;
        private System.Windows.Forms.ToolStripButton BTFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ColumnHeader ColumnLang;
    }
}
