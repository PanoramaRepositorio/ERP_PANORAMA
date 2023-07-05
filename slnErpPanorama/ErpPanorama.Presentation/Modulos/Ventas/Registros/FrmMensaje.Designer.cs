namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class FrmMensaje
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
            this.labelStatus = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Appearance.Options.UseForeColor = true;
            this.labelStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelStatus.Location = new System.Drawing.Point(41, 27);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(373, 68);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Starting...";
            this.labelStatus.Click += new System.EventHandler(this.labelStatus_Click);
            // 
            // FrmMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 117);
            this.Controls.Add(this.labelStatus);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "FrmMensaje";
            this.SplashImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.SplashScreen1_Load);
            this.Click += new System.EventHandler(this.FrmMensaje_Click);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelStatus;
    }
}
