namespace GCGM.Controls
{
    partial class DownloadItem
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
            this.PBCover = new System.Windows.Forms.PictureBox();
            this.LBFront = new System.Windows.Forms.Label();
            this.LBDisc = new System.Windows.Forms.Label();
            this.LBFull = new System.Windows.Forms.Label();
            this.LBFront3D = new System.Windows.Forms.Label();
            this.PBProgress = new GCGM.Controls.ProgressBarEx(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PBCover)).BeginInit();
            this.SuspendLayout();
            // 
            // PBCover
            // 
            this.PBCover.Image = global::AGCGM.Properties.Resources.cover_front;
            this.PBCover.Location = new System.Drawing.Point(3, 3);
            this.PBCover.Name = "PBCover";
            this.PBCover.Size = new System.Drawing.Size(53, 62);
            this.PBCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBCover.TabIndex = 0;
            this.PBCover.TabStop = false;
            // 
            // LBFront
            // 
            this.LBFront.AutoSize = true;
            this.LBFront.ForeColor = System.Drawing.Color.LightGray;
            this.LBFront.Location = new System.Drawing.Point(59, 47);
            this.LBFront.Name = "LBFront";
            this.LBFront.Size = new System.Drawing.Size(51, 13);
            this.LBFront.TabIndex = 10;
            this.LBFront.Text = "◆ Frontal";
            // 
            // LBDisc
            // 
            this.LBDisc.AutoSize = true;
            this.LBDisc.ForeColor = System.Drawing.Color.LightGray;
            this.LBDisc.Location = new System.Drawing.Point(190, 47);
            this.LBDisc.Name = "LBDisc";
            this.LBDisc.Size = new System.Drawing.Size(46, 13);
            this.LBDisc.TabIndex = 11;
            this.LBDisc.Text = "◆ Disco";
            // 
            // LBFull
            // 
            this.LBFull.AutoSize = true;
            this.LBFull.ForeColor = System.Drawing.Color.LightGray;
            this.LBFull.Location = new System.Drawing.Point(242, 47);
            this.LBFull.Name = "LBFull";
            this.LBFull.Size = new System.Drawing.Size(63, 13);
            this.LBFull.TabIndex = 12;
            this.LBFull.Text = "◆ Completa";
            // 
            // LBFront3D
            // 
            this.LBFront3D.AutoSize = true;
            this.LBFront3D.ForeColor = System.Drawing.Color.LightGray;
            this.LBFront3D.Location = new System.Drawing.Point(116, 47);
            this.LBFront3D.Name = "LBFront3D";
            this.LBFront3D.Size = new System.Drawing.Size(68, 13);
            this.LBFront3D.TabIndex = 13;
            this.LBFront3D.Text = "◆ Frontal 3D";
            // 
            // PBProgress
            // 
            this.PBProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBProgress.AnimationInterval = 4000;
            this.PBProgress.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.PBProgress.BorderPadding = 1;
            this.PBProgress.BorderWidth = 1;
            this.PBProgress.ErrorColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PBProgress.Location = new System.Drawing.Point(62, 3);
            this.PBProgress.MarqueeAnimationSpeed = 0;
            this.PBProgress.Name = "PBProgress";
            this.PBProgress.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PBProgress.PausedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PBProgress.Size = new System.Drawing.Size(393, 32);
            this.PBProgress.State = GCGM.Controls.ProgressBarEx.ProgressBarState.Normal;
            this.PBProgress.Style = GCGM.Controls.ProgressBarEx.ProgressBarStyle.Continuous;
            this.PBProgress.TabIndex = 1;
            this.PBProgress.TextAlign = GCGM.Controls.ProgressBarEx.ContentAlignment.MiddleCenter;
            this.PBProgress.TextColor = System.Drawing.Color.Black;
            this.PBProgress.TextEllipsis = System.Drawing.StringTrimming.EllipsisPath;
            this.PBProgress.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PBProgress.TextFormat = "??? - ({0}%)";
            // 
            // DownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LBFront3D);
            this.Controls.Add(this.LBFull);
            this.Controls.Add(this.LBDisc);
            this.Controls.Add(this.LBFront);
            this.Controls.Add(this.PBProgress);
            this.Controls.Add(this.PBCover);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Name = "DownloadItem";
            this.Size = new System.Drawing.Size(458, 66);
            ((System.ComponentModel.ISupportInitialize)(this.PBCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBCover;
        private Controls.ProgressBarEx PBProgress;
        private System.Windows.Forms.Label LBFront;
        private System.Windows.Forms.Label LBDisc;
        private System.Windows.Forms.Label LBFull;
        private System.Windows.Forms.Label LBFront3D;
    }
}
