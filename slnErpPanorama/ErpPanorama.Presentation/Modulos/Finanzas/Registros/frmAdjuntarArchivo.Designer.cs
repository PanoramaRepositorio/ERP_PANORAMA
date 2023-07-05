namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    partial class frmAdjuntarArchivo
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
        ///
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjuntarArchivo));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNuevaRuta = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscarRuta = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.txtRutaArchivo = new DevExpress.XtraEditors.TextEdit();
            this.btnAbrir = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaRuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaArchivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNuevaRuta);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.btnCancelar);
            this.groupControl1.Controls.Add(this.btnGrabar);
            this.groupControl1.Controls.Add(this.btnBuscarRuta);
            this.groupControl1.Controls.Add(this.labelControl25);
            this.groupControl1.Controls.Add(this.txtRutaArchivo);
            this.groupControl1.Controls.Add(this.btnAbrir);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(616, 57);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "Copiar a:";
            this.labelControl1.Visible = false;
            // 
            // txtNuevaRuta
            // 
            this.txtNuevaRuta.Location = new System.Drawing.Point(74, 29);
            this.txtNuevaRuta.Name = "txtNuevaRuta";
            this.txtNuevaRuta.Properties.MaxLength = 300;
            this.txtNuevaRuta.Properties.ReadOnly = true;
            this.txtNuevaRuta.Size = new System.Drawing.Size(87, 20);
            this.txtNuevaRuta.TabIndex = 54;
            this.txtNuevaRuta.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(504, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(26, 20);
            this.simpleButton1.TabIndex = 52;
            this.simpleButton1.ToolTip = "Buscar ubicación de archivos DWG y JPG";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(280, 29);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(199, 29);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 50;
            this.btnGrabar.Text = "Aceptar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnBuscarRuta
            // 
            this.btnBuscarRuta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarRuta.ImageOptions.Image")));
            this.btnBuscarRuta.Location = new System.Drawing.Point(491, 82);
            this.btnBuscarRuta.Name = "btnBuscarRuta";
            this.btnBuscarRuta.Size = new System.Drawing.Size(26, 20);
            this.btnBuscarRuta.TabIndex = 48;
            this.btnBuscarRuta.ToolTip = "Buscar ubicación de archivos DWG y JPG";
            this.btnBuscarRuta.Visible = false;
            this.btnBuscarRuta.Click += new System.EventHandler(this.btnBuscarRuta_Click);
            // 
            // labelControl25
            // 
            this.labelControl25.Location = new System.Drawing.Point(6, 11);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(65, 13);
            this.labelControl25.TabIndex = 46;
            this.labelControl25.Text = "Ruta archivo:";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(74, 8);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Properties.MaxLength = 300;
            this.txtRutaArchivo.Properties.ReadOnly = true;
            this.txtRutaArchivo.Size = new System.Drawing.Size(428, 20);
            this.txtRutaArchivo.TabIndex = 47;
            // 
            // btnAbrir
            // 
            this.btnAbrir.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Word_16x16;
            this.btnAbrir.Location = new System.Drawing.Point(530, 8);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(26, 20);
            this.btnAbrir.TabIndex = 49;
            this.btnAbrir.ToolTip = "Abrir ubicación de archivos DWG y JPG";
            this.btnAbrir.Visible = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAdjuntarArchivo
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 57);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdjuntarArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adjunta archivo";
            this.Load += new System.EventHandler(this.frmAdjuntarArchivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNuevaRuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaArchivo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscarRuta;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.TextEdit txtRutaArchivo;
        private DevExpress.XtraEditors.SimpleButton btnAbrir;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNuevaRuta;
    }
}