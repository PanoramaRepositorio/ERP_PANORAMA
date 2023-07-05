namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegGenerarGuiaRemision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegGenerarGuiaRemision));
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnClienteAsociado = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboSerie = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btnEditNumeracionDocumento = new DevExpress.XtraEditors.SimpleButton();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtSerie = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboDescAgencia = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAgenciaAsociado = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuevaAgencia = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDescAgencia.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(410, 183);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnClienteAsociado
            // 
            this.btnClienteAsociado.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.ConsultaClientes_16x16;
            this.btnClienteAsociado.Location = new System.Drawing.Point(592, 85);
            this.btnClienteAsociado.Name = "btnClienteAsociado";
            this.btnClienteAsociado.Size = new System.Drawing.Size(26, 20);
            this.btnClienteAsociado.TabIndex = 54;
            this.btnClienteAsociado.ToolTipTitle = "Cliente Asociado";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(198, 82);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 52;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(5, 133);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(89, 13);
            this.labelControl6.TabIndex = 55;
            this.labelControl6.Text = "Direccion Destino: ";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(103, 137);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Properties.MaxLength = 100;
            this.txtDireccion.Size = new System.Drawing.Size(515, 20);
            this.txtDireccion.TabIndex = 56;
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(230, 82);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(356, 20);
            this.txtDescCliente.TabIndex = 53;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(103, 82);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Properties.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(93, 20);
            this.txtNumeroDocumento.TabIndex = 51;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(8, 85);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 50;
            this.labelControl5.Text = "Cliente:";
            // 
            // cboSerie
            // 
            this.cboSerie.Location = new System.Drawing.Point(154, 56);
            this.cboSerie.Name = "cboSerie";
            this.cboSerie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSerie.Properties.NullText = "";
            this.cboSerie.Size = new System.Drawing.Size(41, 20);
            this.cboSerie.TabIndex = 46;
            this.cboSerie.EditValueChanged += new System.EventHandler(this.cboSerie_EditValueChanged);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(211, 56);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Properties.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(85, 20);
            this.txtNumero.TabIndex = 47;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(200, 59);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(4, 13);
            this.labelControl11.TabIndex = 49;
            this.labelControl11.Text = "-";
            // 
            // btnEditNumeracionDocumento
            // 
            this.btnEditNumeracionDocumento.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.NumeracionDocumento_16x16;
            this.btnEditNumeracionDocumento.Location = new System.Drawing.Point(298, 56);
            this.btnEditNumeracionDocumento.Name = "btnEditNumeracionDocumento";
            this.btnEditNumeracionDocumento.Size = new System.Drawing.Size(26, 20);
            this.btnEditNumeracionDocumento.TabIndex = 48;
            this.btnEditNumeracionDocumento.ToolTipTitle = "Cliente Asociado";
            this.btnEditNumeracionDocumento.Click += new System.EventHandler(this.btnEditNumeracionDocumento_Click);
            // 
            // cboDocumento
            // 
            this.cboDocumento.Location = new System.Drawing.Point(102, 56);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Size = new System.Drawing.Size(46, 20);
            this.cboDocumento.TabIndex = 44;
            this.cboDocumento.EditValueChanged += new System.EventHandler(this.cboDocumento_EditValueChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(8, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 43;
            this.labelControl7.Text = "Documento:";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(154, 56);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(39, 20);
            this.txtSerie.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fecha :";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(379, 56);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 15;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(103, 30);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(344, 20);
            this.cboEmpresa.TabIndex = 1;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(8, 33);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(45, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Empresa:";
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.cboDescAgencia);
            this.grdDatos.Controls.Add(this.btnAgenciaAsociado);
            this.grdDatos.Controls.Add(this.btnNuevaAgencia);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.btnClienteAsociado);
            this.grdDatos.Controls.Add(this.btnBuscar);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.txtDireccion);
            this.grdDatos.Controls.Add(this.txtDescCliente);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboSerie);
            this.grdDatos.Controls.Add(this.txtNumero);
            this.grdDatos.Controls.Add(this.labelControl11);
            this.grdDatos.Controls.Add(this.btnEditNumeracionDocumento);
            this.grdDatos.Controls.Add(this.cboDocumento);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtSerie);
            this.grdDatos.Controls.Add(this.label1);
            this.grdDatos.Controls.Add(this.deFecha);
            this.grdDatos.Controls.Add(this.cboEmpresa);
            this.grdDatos.Controls.Add(this.labelControl9);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(663, 177);
            this.grdDatos.TabIndex = 9;
            this.grdDatos.Text = "Datos";
            // 
            // cboDescAgencia
            // 
            this.cboDescAgencia.Location = new System.Drawing.Point(104, 111);
            this.cboDescAgencia.Name = "cboDescAgencia";
            this.cboDescAgencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDescAgencia.Properties.NullText = "";
            this.cboDescAgencia.Size = new System.Drawing.Size(487, 20);
            this.cboDescAgencia.TabIndex = 58;
            this.cboDescAgencia.EditValueChanged += new System.EventHandler(this.cboDescAgencia_EditValueChanged);
            // 
            // btnAgenciaAsociado
            // 
            this.btnAgenciaAsociado.Location = new System.Drawing.Point(629, 111);
            this.btnAgenciaAsociado.Name = "btnAgenciaAsociado";
            this.btnAgenciaAsociado.Size = new System.Drawing.Size(26, 20);
            this.btnAgenciaAsociado.TabIndex = 62;
            this.btnAgenciaAsociado.ToolTipTitle = "Cliente Asociado";
            this.btnAgenciaAsociado.Visible = false;
            // 
            // btnNuevaAgencia
            // 
            this.btnNuevaAgencia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaAgencia.ImageOptions.Image")));
            this.btnNuevaAgencia.Location = new System.Drawing.Point(597, 111);
            this.btnNuevaAgencia.Name = "btnNuevaAgencia";
            this.btnNuevaAgencia.Size = new System.Drawing.Size(26, 20);
            this.btnNuevaAgencia.TabIndex = 59;
            this.btnNuevaAgencia.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 57;
            this.labelControl2.Text = "Agencia:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(511, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmRegGenerarGuiaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 213);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Name = "frmRegGenerarGuiaRemision";
            this.Text = "Generar Guia de Remisión";
            this.Load += new System.EventHandler(this.frmRegGenerarGuiaRemision2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDescAgencia.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.SimpleButton btnClienteAsociado;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboSerie;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.SimpleButton btnEditNumeracionDocumento;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtSerie;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit deFecha;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.LookUpEdit cboDescAgencia;
        private DevExpress.XtraEditors.SimpleButton btnAgenciaAsociado;
        private DevExpress.XtraEditors.SimpleButton btnNuevaAgencia;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}