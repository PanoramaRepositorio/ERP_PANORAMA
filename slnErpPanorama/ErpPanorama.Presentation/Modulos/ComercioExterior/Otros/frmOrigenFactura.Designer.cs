namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Otros
{
    partial class frmOrigenFactura
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
            this.bntNacional = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportado = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bntNacional
            // 
            this.bntNacional.Image = global::ErpPanorama.Presentation.Properties.Resources.PeruCircle_128x128;
            this.bntNacional.Location = new System.Drawing.Point(20, 12);
            this.bntNacional.Name = "bntNacional";
            this.bntNacional.Size = new System.Drawing.Size(131, 42);
            this.bntNacional.TabIndex = 0;
            this.bntNacional.Text = "&Nacional";
            this.bntNacional.Click += new System.EventHandler(this.bntNacional_Click);
            // 
            // btnImportado
            // 
            this.btnImportado.Image = global::ErpPanorama.Presentation.Properties.Resources.BarcoCircle_128x128;
            this.btnImportado.Location = new System.Drawing.Point(157, 12);
            this.btnImportado.Name = "btnImportado";
            this.btnImportado.Size = new System.Drawing.Size(131, 42);
            this.btnImportado.TabIndex = 0;
            this.btnImportado.Text = "&Importado";
            this.btnImportado.Click += new System.EventHandler(this.btnImportado_Click);
            // 
            // frmOrigenFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 68);
            this.Controls.Add(this.btnImportado);
            this.Controls.Add(this.bntNacional);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrigenFactura";
            this.Text = "Origen";
            this.Load += new System.EventHandler(this.frmOrigenFactura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bntNacional;
        private DevExpress.XtraEditors.SimpleButton btnImportado;
    }
}