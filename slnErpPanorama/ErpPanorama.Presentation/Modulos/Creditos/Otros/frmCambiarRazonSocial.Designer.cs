namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
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
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnClienteAsociado = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.lblTipoCambio = new DevExpress.XtraEditors.LabelControl();
            this.lblPedido = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMotivo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 33);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 13);
            this.labelControl6.TabIndex = 41;
            this.labelControl6.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(65, 30);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Properties.MaxLength = 100;
            this.txtDireccion.Size = new System.Drawing.Size(690, 20);
            this.txtDireccion.TabIndex = 42;
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(196, 8);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(531, 20);
            this.txtDescCliente.TabIndex = 39;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(65, 8);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Properties.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(93, 20);
            this.txtNumeroDocumento.TabIndex = 37;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(22, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 36;
            this.labelControl5.Text = "Cliente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(680, 51);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(599, 51);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 43;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnClienteAsociado
            // 
            this.btnClienteAsociado.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.ConsultaClientes_16x16;
            this.btnClienteAsociado.Location = new System.Drawing.Point(728, 8);
            this.btnClienteAsociado.Name = "btnClienteAsociado";
            this.btnClienteAsociado.Size = new System.Drawing.Size(26, 20);
            this.btnClienteAsociado.TabIndex = 40;
            this.btnClienteAsociado.ToolTipTitle = "Cliente Asociado";
            this.btnClienteAsociado.Click += new System.EventHandler(this.btnClienteAsociado_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(164, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.EditValue = "0.00";
            this.txtTipoCambio.Location = new System.Drawing.Point(481, 52);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCambio.Properties.DisplayFormat.FormatString = "n3";
            this.txtTipoCambio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTipoCambio.Properties.Mask.EditMask = "n3";
            this.txtTipoCambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoCambio.Properties.Mask.ShowPlaceHolders = false;
            this.txtTipoCambio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(54, 20);
            this.txtTipoCambio.TabIndex = 46;
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.Location = new System.Drawing.Point(451, 56);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(25, 13);
            this.lblTipoCambio.TabIndex = 47;
            this.lblTipoCambio.Text = "T.C.:";
            // 
            // lblPedido
            // 
            this.lblPedido.Location = new System.Drawing.Point(127, 56);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(51, 13);
            this.lblPedido.TabIndex = 53;
            this.lblPedido.Text = "N° Pedido:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(181, 52);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 7;
            this.txtNumero.Size = new System.Drawing.Size(80, 20);
            this.txtNumero.TabIndex = 52;
            this.txtNumero.ToolTip = "Ingresar los 7 dígitos del N° Pedido";
            this.txtNumero.EditValueChanged += new System.EventHandler(this.txtNumero_EditValueChanged);
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(309, 52);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(137, 20);
            this.cboMotivo.TabIndex = 54;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Location = new System.Drawing.Point(269, 56);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(36, 13);
            this.lblMotivo.TabIndex = 55;
            this.lblMotivo.Text = "Motivo:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 57;
            this.labelControl1.Text = "Periodo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(65, 52);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPeriodo.Properties.Appearance.Options.UseFont = true;
            this.txtPeriodo.Properties.MaxLength = 7;
            this.txtPeriodo.Size = new System.Drawing.Size(57, 20);
            this.txtPeriodo.TabIndex = 56;
            this.txtPeriodo.ToolTip = "Ingresar los 7 dígitos del N° Pedido";
            // 
            // frmCambiarRazonSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 80);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblTipoCambio);
            this.Controls.Add(this.txtTipoCambio);
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
            this.Text = "Asignar Pago - Estado Cuenta";
            this.Load += new System.EventHandler(this.frmCambiarRazonSocial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraEditors.SimpleButton btnClienteAsociado;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtTipoCambio;
        private DevExpress.XtraEditors.LabelControl lblTipoCambio;
        private DevExpress.XtraEditors.LabelControl lblPedido;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl lblMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPeriodo;
    }
}