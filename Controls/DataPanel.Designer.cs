namespace AGCGM.Controls
{
    partial class DataPanel
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
            this.PLBTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FlowOptional = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.FlowRequired = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PLBLang = new System.Windows.Forms.Label();
            this.PLBTrimmed = new System.Windows.Forms.Label();
            this.PLBDescription = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PPBRegion = new System.Windows.Forms.PictureBox();
            this.PPBCover = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.FlowRequired.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBCover)).BeginInit();
            this.SuspendLayout();
            // 
            // PLBTitle
            // 
            this.PLBTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(111)))), ((int)(((byte)(0)))));
            this.PLBTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PLBTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PLBTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLBTitle.ForeColor = System.Drawing.Color.White;
            this.PLBTitle.Location = new System.Drawing.Point(0, 0);
            this.PLBTitle.Name = "PLBTitle";
            this.PLBTitle.Size = new System.Drawing.Size(968, 28);
            this.PLBTitle.TabIndex = 3;
            this.PLBTitle.Text = "Titulo";
            this.PLBTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.FlowOptional);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.FlowRequired);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(783, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 204);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // FlowOptional
            // 
            this.FlowOptional.Location = new System.Drawing.Point(6, 133);
            this.FlowOptional.Name = "FlowOptional";
            this.FlowOptional.Size = new System.Drawing.Size(171, 64);
            this.FlowOptional.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoEllipsis = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Controles opcionales";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlowRequired
            // 
            this.FlowRequired.Controls.Add(this.pictureBox2);
            this.FlowRequired.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowRequired.Location = new System.Drawing.Point(9, 43);
            this.FlowRequired.Name = "FlowRequired";
            this.FlowRequired.Size = new System.Drawing.Size(171, 65);
            this.FlowRequired.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoEllipsis = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Controles requeridos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PLBLang);
            this.groupBox1.Controls.Add(this.PLBTrimmed);
            this.groupBox1.Controls.Add(this.PPBRegion);
            this.groupBox1.Controls.Add(this.PLBDescription);
            this.groupBox1.Controls.Add(this.PPBCover);
            this.groupBox1.Location = new System.Drawing.Point(-1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 204);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Idiomas:";
            // 
            // PLBLang
            // 
            this.PLBLang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PLBLang.AutoEllipsis = true;
            this.PLBLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLBLang.Location = new System.Drawing.Point(210, 49);
            this.PLBLang.Name = "PLBLang";
            this.PLBLang.Size = new System.Drawing.Size(562, 17);
            this.PLBLang.TabIndex = 8;
            this.PLBLang.Text = "-";
            // 
            // PLBTrimmed
            // 
            this.PLBTrimmed.AutoSize = true;
            this.PLBTrimmed.BackColor = System.Drawing.Color.DarkRed;
            this.PLBTrimmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLBTrimmed.ForeColor = System.Drawing.SystemColors.Control;
            this.PLBTrimmed.Location = new System.Drawing.Point(171, 22);
            this.PLBTrimmed.Name = "PLBTrimmed";
            this.PLBTrimmed.Padding = new System.Windows.Forms.Padding(2);
            this.PLBTrimmed.Size = new System.Drawing.Size(90, 19);
            this.PLBTrimmed.TabIndex = 7;
            this.PLBTrimmed.Text = "No Trimmed";
            // 
            // PLBDescription
            // 
            this.PLBDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PLBDescription.AutoEllipsis = true;
            this.PLBDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLBDescription.Location = new System.Drawing.Point(133, 75);
            this.PLBDescription.Name = "PLBDescription";
            this.PLBDescription.Size = new System.Drawing.Size(639, 119);
            this.PLBDescription.TabIndex = 2;
            this.PLBDescription.Text = "Descripción...";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 59);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // PPBRegion
            // 
            this.PPBRegion.Image = global::AGCGM.Properties.Resources.Flag_Europe;
            this.PPBRegion.Location = new System.Drawing.Point(133, 21);
            this.PPBRegion.Name = "PPBRegion";
            this.PPBRegion.Size = new System.Drawing.Size(32, 22);
            this.PPBRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PPBRegion.TabIndex = 6;
            this.PPBRegion.TabStop = false;
            // 
            // PPBCover
            // 
            this.PPBCover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PPBCover.Image = global::AGCGM.Properties.Resources.cover_front;
            this.PPBCover.Location = new System.Drawing.Point(6, 21);
            this.PPBCover.Name = "PPBCover";
            this.PPBCover.Size = new System.Drawing.Size(118, 173);
            this.PPBCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PPBCover.TabIndex = 0;
            this.PPBCover.TabStop = false;
            // 
            // DataPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PLBTitle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DataPanel";
            this.Size = new System.Drawing.Size(968, 216);
            this.groupBox2.ResumeLayout(false);
            this.FlowRequired.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PLBTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel FlowOptional;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel FlowRequired;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PLBTrimmed;
        private System.Windows.Forms.PictureBox PPBRegion;
        private System.Windows.Forms.Label PLBDescription;
        private System.Windows.Forms.PictureBox PPBCover;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PLBLang;
    }
}
