namespace AGCGM.Controls.Page
{
    partial class LogPage
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
            this.ColumnIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.BTLogClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTLogError = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTLogWarning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTLogInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.LogList = new System.Windows.Forms.ListView();
            this.ColumnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnStack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.Text = "";
            this.ColumnIcon.Width = 29;
            // 
            // ColumnTime
            // 
            this.ColumnTime.Text = "Tiempo";
            this.ColumnTime.Width = 66;
            // 
            // ColumnSource
            // 
            this.ColumnSource.Text = "Fuente";
            this.ColumnSource.Width = 154;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.BTLogClear,
            this.toolStripSeparator6,
            this.toolStripSeparator5,
            this.BTLogError,
            this.toolStripSeparator2,
            this.BTLogWarning,
            this.toolStripSeparator3,
            this.BTLogInfo,
            this.toolStripSeparator4});
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
            this.toolStripLabel2.Size = new System.Drawing.Size(149, 28);
            this.toolStripLabel2.Text = "Niveles de depuración:";
            // 
            // BTLogClear
            // 
            this.BTLogClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BTLogClear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.BTLogClear.ForeColor = System.Drawing.Color.White;
            this.BTLogClear.Image = global::AGCGM.Properties.Resources.delete_white_24;
            this.BTLogClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTLogClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTLogClear.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.BTLogClear.Name = "BTLogClear";
            this.BTLogClear.Size = new System.Drawing.Size(79, 28);
            this.BTLogClear.Text = "Limpiar";
            this.BTLogClear.Click += new System.EventHandler(this.LogClear_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // BTLogError
            // 
            this.BTLogError.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BTLogError.Checked = true;
            this.BTLogError.CheckOnClick = true;
            this.BTLogError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BTLogError.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.BTLogError.ForeColor = System.Drawing.Color.White;
            this.BTLogError.Image = global::AGCGM.Properties.Resources.cancel_white_24;
            this.BTLogError.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTLogError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTLogError.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.BTLogError.Name = "BTLogError";
            this.BTLogError.Size = new System.Drawing.Size(66, 28);
            this.BTLogError.Text = "Error";
            this.BTLogError.Click += new System.EventHandler(this.LogFilter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // BTLogWarning
            // 
            this.BTLogWarning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BTLogWarning.Checked = true;
            this.BTLogWarning.CheckOnClick = true;
            this.BTLogWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BTLogWarning.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.BTLogWarning.ForeColor = System.Drawing.Color.White;
            this.BTLogWarning.Image = global::AGCGM.Properties.Resources.warning_white_24;
            this.BTLogWarning.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTLogWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTLogWarning.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.BTLogWarning.Name = "BTLogWarning";
            this.BTLogWarning.Size = new System.Drawing.Size(104, 28);
            this.BTLogWarning.Text = "Advertencia";
            this.BTLogWarning.Click += new System.EventHandler(this.LogFilter_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // BTLogInfo
            // 
            this.BTLogInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BTLogInfo.Checked = true;
            this.BTLogInfo.CheckOnClick = true;
            this.BTLogInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BTLogInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.BTLogInfo.ForeColor = System.Drawing.Color.White;
            this.BTLogInfo.Image = global::AGCGM.Properties.Resources.info_white_24;
            this.BTLogInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTLogInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTLogInfo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.BTLogInfo.Name = "BTLogInfo";
            this.BTLogInfo.Size = new System.Drawing.Size(105, 28);
            this.BTLogInfo.Text = "Información";
            this.BTLogInfo.Click += new System.EventHandler(this.LogFilter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // LogList
            // 
            this.LogList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnIcon,
            this.ColumnTime,
            this.ColumnSource,
            this.ColumnType,
            this.ColumnMessage,
            this.ColumnFile,
            this.ColumnStack});
            this.LogList.FullRowSelect = true;
            listViewGroup1.Header = "Error";
            listViewGroup1.Name = "Error";
            listViewGroup2.Header = "Advertencia";
            listViewGroup2.Name = "Warning";
            listViewGroup3.Header = "Información";
            listViewGroup3.Name = "Information";
            this.LogList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.LogList.HideSelection = false;
            this.LogList.Location = new System.Drawing.Point(0, 32);
            this.LogList.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.LogList.Name = "LogList";
            this.LogList.ShowGroups = false;
            this.LogList.Size = new System.Drawing.Size(627, 245);
            this.LogList.TabIndex = 6;
            this.LogList.UseCompatibleStateImageBehavior = false;
            this.LogList.View = System.Windows.Forms.View.Details;
            this.LogList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LogList_ColumnClick);
            // 
            // ColumnType
            // 
            this.ColumnType.Text = "Tipo";
            this.ColumnType.Width = 108;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.Text = "Mensaje";
            this.ColumnMessage.Width = 225;
            // 
            // ColumnFile
            // 
            this.ColumnFile.Text = "Ubicación";
            this.ColumnFile.Width = 104;
            // 
            // ColumnStack
            // 
            this.ColumnStack.Text = "Pila de llamadas";
            this.ColumnStack.Width = 91;
            // 
            // LogPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.LogList);
            this.Controls.Add(this.toolStrip2);
            this.DoubleBuffered = true;
            this.Name = "LogPage";
            this.Size = new System.Drawing.Size(627, 277);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton BTLogClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BTLogError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTLogWarning;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTLogInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ListView LogList;
        private System.Windows.Forms.ColumnHeader ColumnFile;
        private System.Windows.Forms.ColumnHeader ColumnStack;
        private System.Windows.Forms.ColumnHeader ColumnTime;
        private System.Windows.Forms.ColumnHeader ColumnSource;
        private System.Windows.Forms.ColumnHeader ColumnMessage;
        private System.Windows.Forms.ColumnHeader ColumnIcon;
        private System.Windows.Forms.ColumnHeader ColumnType;
    }
}
