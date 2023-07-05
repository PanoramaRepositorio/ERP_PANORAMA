namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    partial class frmRegCodigoBarra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegCodigoBarra));
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoBarra = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtNombreProducto = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreProducto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 18);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(61, 13);
            this.labelControl9.TabIndex = 30;
            this.labelControl9.Text = "Cod. Barras:";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Enabled = false;
            this.txtCodigoBarra.Location = new System.Drawing.Point(98, 15);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Properties.MaxLength = 15;
            this.txtCodigoBarra.Size = new System.Drawing.Size(178, 20);
            this.txtCodigoBarra.TabIndex = 31;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(435, 86);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(352, 86);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 34;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Producto:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 41);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(37, 13);
            this.lblDescripcion.TabIndex = 38;
            this.lblDescripcion.Text = "Código:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(250, 38);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(98, 38);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Size = new System.Drawing.Size(146, 20);
            this.txtCodigo.TabIndex = 39;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(98, 60);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Properties.MaxLength = 50;
            this.txtNombreProducto.Properties.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(412, 20);
            this.txtNombreProducto.TabIndex = 41;
            // 
            // frmRegCodigoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 124);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.txtCodigoBarra);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegCodigoBarra";
            this.Text = "Registro - Código Barra";
            this.Load += new System.EventHandler(this.frmRegCodigoBarra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreProducto.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtCodigoBarra;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtNombreProducto;
    }
}