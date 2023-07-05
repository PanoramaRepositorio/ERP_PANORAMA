namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmCambiarRazonSocial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarRazonSocial));
            this.btnClienteAsociado = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClienteAsociado
            // 
            this.btnClienteAsociado.Image = global::ErpPanorama.Presentation.Properties.Resources.ConsultaClientes_16x16;
            this.btnClienteAsociado.Location = new System.Drawing.Point(660, 9);
            this.btnClienteAsociado.Name = "btnClienteAsociado";
            this.btnClienteAsociado.Size = new System.Drawing.Size(26, 20);
            this.btnClienteAsociado.TabIndex = 31;
            this.btnClienteAsociado.ToolTipTitle = "Cliente Asociado";
            this.btnClienteAsociado.Click += new System.EventHandler(this.btnClienteAsociado_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(164, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 29;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(196, 9);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(461, 20);
            this.txtDescCliente.TabIndex = 30;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(65, 9);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Properties.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(93, 20);
            this.txtNumeroDocumento.TabIndex = 28;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 27;
            this.labelControl5.Text = "Cliente:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(65, 31);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Properties.MaxLength = 100;
            this.txtDireccion.Size = new System.Drawing.Size(621, 20);
            this.txtDireccion.TabIndex = 33;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(611, 57);
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
            this.btnGrabar.Location = new System.Drawing.Point(530, 57);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 34;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmCambiarRazonSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 86);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.btnClienteAsociado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescCliente);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.labelControl5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambiarRazonSocial";
            this.Text = "Cambiar Razon Social";
            this.Load += new System.EventHandler(this.frmCambiarRazonSocial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClienteAsociado;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
    }
}