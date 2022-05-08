namespace GCGM.Controls
{
    partial class TransferItem
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
            this.PBBanner = new System.Windows.Forms.PictureBox();
            this.PBProgress = new GCGM.Controls.ProgressBarEx(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PBBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // PBBanner
            // 
            this.PBBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PBBanner.Location = new System.Drawing.Point(3, 3);
            this.PBBanner.Name = "PBBanner";
            this.PBBanner.Size = new System.Drawing.Size(90, 30);
            this.PBBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBanner.TabIndex = 0;
            this.PBBanner.TabStop = false;
            // 
            // PBProgress
            // 
            this.PBProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBProgress.AnimationInterval = 4000;
            this.PBProgress.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.PBProgress.BorderPadding = 1;
            this.PBProgress.BorderWidth = 1;
            this.PBProgress.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PBProgress.Location = new System.Drawing.Point(99, 3);
            this.PBProgress.MarqueeAnimationSpeed = 0;
            this.PBProgress.Name = "PBProgress";
            this.PBProgress.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PBProgress.PausedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PBProgress.Size = new System.Drawing.Size(358, 30);
            this.PBProgress.State = GCGM.Controls.ProgressBarEx.ProgressBarState.Normal;
            this.PBProgress.Style = GCGM.Controls.ProgressBarEx.ProgressBarStyle.Continuous;
            this.PBProgress.TabIndex = 1;
            this.PBProgress.TextAlign = GCGM.Controls.ProgressBarEx.ContentAlignment.MiddleCenter;
            this.PBProgress.TextColor = System.Drawing.Color.Black;
            this.PBProgress.TextEllipsis = System.Drawing.StringTrimming.EllipsisPath;
            this.PBProgress.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PBProgress.TextFormat = "Titulo | ({0}%)";
            // 
            // TransferItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PBProgress);
            this.Controls.Add(this.PBBanner);
            this.Name = "TransferItem";
            this.Size = new System.Drawing.Size(460, 36);
            ((System.ComponentModel.ISupportInitialize)(this.PBBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBBanner;
        private Controls.ProgressBarEx PBProgress;
    }
}
