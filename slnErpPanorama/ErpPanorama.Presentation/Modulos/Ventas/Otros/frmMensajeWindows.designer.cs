namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmMensajeWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMensajeWindows));
            this.gcMensaje = new DevExpress.XtraEditors.GroupControl();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcMensaje)).BeginInit();
            this.gcMensaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcMensaje
            // 
            this.gcMensaje.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcMensaje.Appearance.Options.UseFont = true;
            this.gcMensaje.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcMensaje.AppearanceCaption.Options.UseFont = true;
            this.gcMensaje.Controls.Add(this.lblMensaje);
            this.gcMensaje.Controls.Add(this.btnAceptar);
            this.gcMensaje.Location = new System.Drawing.Point(3, 2);
            this.gcMensaje.Name = "gcMensaje";
            this.gcMensaje.Size = new System.Drawing.Size(657, 256);
            this.gcMensaje.TabIndex = 0;
            this.gcMensaje.Text = "Mensaje";
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(83, 82);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(467, 34);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "El pedido se imprimió correctamente";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(211, 138);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(249, 87);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmMensajeWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 258);
            this.Controls.Add(this.gcMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMensajeWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMensajeWindows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMensaje)).EndInit();
            this.gcMensaje.ResumeLayout(false);
            this.gcMensaje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcMensaje;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private System.Windows.Forms.Label lblMensaje;
    }
}