namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmMensajeWindowsYESNO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMensajeWindowsYESNO));
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.lblMensaje = new System.Windows.Forms.TextBox();
            this.gcMensaje = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMensaje)).BeginInit();
            this.gcMensaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Appearance.Options.UseFont = true;
            this.btnAceptar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.ImageOptions.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(99, 161);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(249, 87);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "SI";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(363, 161);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(249, 87);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "NO";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMensaje.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(25, 69);
            this.lblMensaje.Multiline = true;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.ReadOnly = true;
            this.lblMensaje.Size = new System.Drawing.Size(660, 86);
            this.lblMensaje.TabIndex = 22;
            this.lblMensaje.Text = "Msg";
            this.lblMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gcMensaje
            // 
            this.gcMensaje.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcMensaje.Appearance.Options.UseFont = true;
            this.gcMensaje.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcMensaje.AppearanceCaption.Options.UseFont = true;
            this.gcMensaje.Controls.Add(this.btnCancelar);
            this.gcMensaje.Controls.Add(this.lblMensaje);
            this.gcMensaje.Controls.Add(this.btnAceptar);
            this.gcMensaje.Location = new System.Drawing.Point(1, 1);
            this.gcMensaje.Name = "gcMensaje";
            this.gcMensaje.Size = new System.Drawing.Size(699, 286);
            this.gcMensaje.TabIndex = 23;
            this.gcMensaje.Text = "Mensaje";
            // 
            // frmMensajeWindowsYESNO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 285);
            this.ControlBox = false;
            this.Controls.Add(this.gcMensaje);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMensajeWindowsYESNO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMensajeWindowsYESNO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMensaje)).EndInit();
            this.gcMensaje.ResumeLayout(false);
            this.gcMensaje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private System.Windows.Forms.TextBox lblMensaje;
        private DevExpress.XtraEditors.GroupControl gcMensaje;
    }
}