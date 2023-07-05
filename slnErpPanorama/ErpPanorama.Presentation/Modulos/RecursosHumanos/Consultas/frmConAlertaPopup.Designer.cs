namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    partial class frmConAlertaPopup
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
            this.gcTexto = new DevExpress.XtraEditors.GroupControl();
            this.txtTitulo = new DevExpress.XtraEditors.TextEdit();
            this.txtMensaje = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTexto)).BeginInit();
            this.gcTexto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMensaje.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTexto
            // 
            this.gcTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTexto.Controls.Add(this.txtTitulo);
            this.gcTexto.Controls.Add(this.txtMensaje);
            this.gcTexto.Location = new System.Drawing.Point(0, 0);
            this.gcTexto.Name = "gcTexto";
            this.gcTexto.Size = new System.Drawing.Size(563, 565);
            this.gcTexto.TabIndex = 0;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.EditValue = "SIN TITULO";
            this.txtTitulo.Location = new System.Drawing.Point(5, 23);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            this.txtTitulo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtTitulo.Properties.Appearance.Options.UseBackColor = true;
            this.txtTitulo.Properties.Appearance.Options.UseFont = true;
            this.txtTitulo.Properties.Appearance.Options.UseForeColor = true;
            this.txtTitulo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTitulo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtTitulo.Properties.ReadOnly = true;
            this.txtTitulo.Size = new System.Drawing.Size(553, 32);
            this.txtTitulo.TabIndex = 2;
            this.txtTitulo.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.EditValue = "El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña tocaba el saxof" +
    "ón detrás del palenque ";
            this.txtMensaje.Location = new System.Drawing.Point(5, 77);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtMensaje.Properties.Appearance.Options.UseFont = true;
            this.txtMensaje.Properties.Appearance.Options.UseForeColor = true;
            this.txtMensaje.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMensaje.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtMensaje.Properties.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(553, 483);
            this.txtMensaje.TabIndex = 1;
            // 
            // frmConAlertaPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 565);
            this.Controls.Add(this.gcTexto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConAlertaPopup";
            this.Text = "Anuncio";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmConAlertaPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTexto)).EndInit();
            this.gcTexto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTitulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMensaje.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcTexto;
        private DevExpress.XtraEditors.MemoEdit txtMensaje;
        private DevExpress.XtraEditors.TextEdit txtTitulo;
    }
}