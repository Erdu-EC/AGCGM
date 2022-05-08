namespace GCGM.Controls
{
    partial class TransferContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferContainer));
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.LBSource = new System.Windows.Forms.Label();
            this.LBDestination = new System.Windows.Forms.Label();
            this.TransferGroup = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DriveIcon = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.transferItem1 = new GCGM.Controls.TransferItem();
            this.transferItem2 = new GCGM.Controls.TransferItem();
            this.BTStop = new System.Windows.Forms.Button();
            this.BTPause = new System.Windows.Forms.Button();
            this.LBState = new System.Windows.Forms.Label();
            this.Tips = new System.Windows.Forms.ToolTip(this.components);
            this.TransferGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.ItemsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "Folder");
            this.Icons.Images.SetKeyName(1, "Folder_open");
            this.Icons.Images.SetKeyName(2, "HardDisk");
            this.Icons.Images.SetKeyName(3, "USB");
            // 
            // LBSource
            // 
            this.LBSource.AutoEllipsis = true;
            this.LBSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBSource.Location = new System.Drawing.Point(39, 19);
            this.LBSource.Name = "LBSource";
            this.LBSource.Size = new System.Drawing.Size(104, 32);
            this.LBSource.TabIndex = 1;
            this.LBSource.Text = "Unidad Extraible (C:)";
            this.LBSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBDestination
            // 
            this.LBDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBDestination.Location = new System.Drawing.Point(210, 19);
            this.LBDestination.Name = "LBDestination";
            this.LBDestination.Size = new System.Drawing.Size(104, 32);
            this.LBDestination.TabIndex = 3;
            this.LBDestination.Text = "Unidad Extraible (D:)";
            this.LBDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TransferGroup
            // 
            this.TransferGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferGroup.Controls.Add(this.pictureBox2);
            this.TransferGroup.Controls.Add(this.pictureBox1);
            this.TransferGroup.Controls.Add(this.DriveIcon);
            this.TransferGroup.Controls.Add(this.LBDestination);
            this.TransferGroup.Controls.Add(this.LBSource);
            this.TransferGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferGroup.Location = new System.Drawing.Point(3, 3);
            this.TransferGroup.Name = "TransferGroup";
            this.TransferGroup.Size = new System.Drawing.Size(318, 63);
            this.TransferGroup.TabIndex = 4;
            this.TransferGroup.TabStop = false;
            this.TransferGroup.Text = "Transfiriendo (0/0)...";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImage = global::AGCGM.Properties.Resources.Expandir;
            this.pictureBox2.Location = new System.Drawing.Point(143, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::AGCGM.Properties.Resources.Folder_open_32;
            this.pictureBox1.Location = new System.Drawing.Point(177, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // DriveIcon
            // 
            this.DriveIcon.Image = global::AGCGM.Properties.Resources.Folder_open_32;
            this.DriveIcon.Location = new System.Drawing.Point(6, 19);
            this.DriveIcon.Name = "DriveIcon";
            this.DriveIcon.Size = new System.Drawing.Size(32, 32);
            this.DriveIcon.TabIndex = 0;
            this.DriveIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ItemsPanel);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 87);
            this.panel1.TabIndex = 5;
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsPanel.AutoSize = true;
            this.ItemsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ItemsPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ItemsPanel.ColumnCount = 1;
            this.ItemsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemsPanel.Controls.Add(this.transferItem1, 0, 0);
            this.ItemsPanel.Controls.Add(this.transferItem2, 0, 1);
            this.ItemsPanel.Location = new System.Drawing.Point(0, 0);
            this.ItemsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.RowCount = 1;
            this.ItemsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.ItemsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.ItemsPanel.Size = new System.Drawing.Size(318, 87);
            this.ItemsPanel.TabIndex = 0;
            // 
            // transferItem1
            // 
            this.transferItem1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transferItem1.Location = new System.Drawing.Point(4, 4);
            this.transferItem1.Name = "transferItem1";
            this.transferItem1.Size = new System.Drawing.Size(310, 36);
            this.transferItem1.TabIndex = 0;
            // 
            // transferItem2
            // 
            this.transferItem2.Location = new System.Drawing.Point(4, 47);
            this.transferItem2.Name = "transferItem2";
            this.transferItem2.Size = new System.Drawing.Size(310, 36);
            this.transferItem2.TabIndex = 1;
            // 
            // BTStop
            // 
            this.BTStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BTStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTStop.Location = new System.Drawing.Point(246, 161);
            this.BTStop.Name = "BTStop";
            this.BTStop.Size = new System.Drawing.Size(75, 24);
            this.BTStop.TabIndex = 6;
            this.BTStop.Text = "Cancelar";
            this.BTStop.UseVisualStyleBackColor = false;
            this.BTStop.Click += new System.EventHandler(this.BTStop_Click);
            // 
            // BTPause
            // 
            this.BTPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BTPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTPause.Location = new System.Drawing.Point(165, 162);
            this.BTPause.Name = "BTPause";
            this.BTPause.Size = new System.Drawing.Size(75, 24);
            this.BTPause.TabIndex = 7;
            this.BTPause.Text = "Pausar";
            this.BTPause.UseVisualStyleBackColor = false;
            this.BTPause.Click += new System.EventHandler(this.BTPause_Click);
            // 
            // LBState
            // 
            this.LBState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBState.AutoEllipsis = true;
            this.LBState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBState.Location = new System.Drawing.Point(3, 166);
            this.LBState.Name = "LBState";
            this.LBState.Size = new System.Drawing.Size(156, 15);
            this.LBState.TabIndex = 8;
            this.LBState.Text = "-";
            // 
            // TransferContainer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LBState);
            this.Controls.Add(this.BTPause);
            this.Controls.Add(this.BTStop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TransferGroup);
            this.Name = "TransferContainer";
            this.Size = new System.Drawing.Size(325, 189);
            this.TransferGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ItemsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DriveIcon;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.Label LBSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBDestination;
        private System.Windows.Forms.GroupBox TransferGroup;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel ItemsPanel;
        private TransferItem transferItem1;
        private TransferItem transferItem2;
        private System.Windows.Forms.Button BTStop;
        private System.Windows.Forms.Button BTPause;
        private System.Windows.Forms.Label LBState;
        private System.Windows.Forms.ToolTip Tips;
    }
}
