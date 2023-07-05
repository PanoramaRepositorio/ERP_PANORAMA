namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    partial class frmAgendarVisitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgendarVisitas));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboAsesor = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAsesor = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            //this.btnClienteAsociado = new DevExpress.XtraEditors.SimpleButton();
            //this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            //this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            //this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            //this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            //this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAsesor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.groupBox1);
            this.grdDatos.Controls.Add(this.textBox2);
            this.grdDatos.Controls.Add(this.textBox1);
            this.grdDatos.Controls.Add(this.cboTienda);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboAsesor);
            this.grdDatos.Controls.Add(this.lblAsesor);
            this.grdDatos.Controls.Add(this.txtNumero);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(824, 452);
            this.grdDatos.TabIndex = 3;
            this.grdDatos.Text = "Datos";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = new System.DateTime(2022, 6, 16, 17, 40, 10, 822);
            this.deFecha.Location = new System.Drawing.Point(51, 166);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Properties.ReadOnly = true;
            this.deFecha.Size = new System.Drawing.Size(215, 20);
            this.deFecha.TabIndex = 121;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 168);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 13);
            this.labelControl6.TabIndex = 120;
            this.labelControl6.Text = "Fecha:";
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(626, 323);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboTienda.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cboTienda.Properties.Appearance.Options.UseFont = true;
            this.cboTienda.Properties.Appearance.Options.UseForeColor = true;
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(156, 20);
            this.cboTienda.TabIndex = 119;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(587, 327);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 118;
            this.labelControl4.Text = "Tienda:";
            // 
            // cboAsesor
            // 
            this.cboAsesor.Location = new System.Drawing.Point(206, 345);
            this.cboAsesor.Name = "cboAsesor";
            this.cboAsesor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboAsesor.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cboAsesor.Properties.Appearance.Options.UseFont = true;
            this.cboAsesor.Properties.Appearance.Options.UseForeColor = true;
            this.cboAsesor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAsesor.Properties.DropDownRows = 12;
            this.cboAsesor.Properties.NullText = "";
            this.cboAsesor.Size = new System.Drawing.Size(576, 20);
            this.cboAsesor.TabIndex = 117;
            this.cboAsesor.EditValueChanged += new System.EventHandler(this.cboAsesor_EditValueChanged);
            // 
            // lblAsesor
            // 
            this.lblAsesor.Location = new System.Drawing.Point(125, 349);
            this.lblAsesor.Name = "lblAsesor";
            this.lblAsesor.Size = new System.Drawing.Size(52, 13);
            this.lblAsesor.TabIndex = 116;
            this.lblAsesor.Text = "Diseñador:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(206, 323);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Properties.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(90, 20);
            this.txtNumero.TabIndex = 35;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(8, 38);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(36, 13);
            this.labelControl11.TabIndex = 34;
            this.labelControl11.Text = "Motivo:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(125, 381);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(75, 13);
            this.labelControl20.TabIndex = 32;
            this.labelControl20.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(51, 55);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Properties.MaxLength = 200;
            this.txtObservaciones.Size = new System.Drawing.Size(752, 109);
            this.txtObservaciones.TabIndex = 33;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(410, 458);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(329, 458);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 122;
            this.labelControl1.Text = "Cliente:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(353, 400);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(99, 21);
            this.textBox1.TabIndex = 123;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(283, 282);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(498, 21);
            this.textBox2.TabIndex = 124;
            // 
            // btnClienteAsociado
            // 
            //this.btnClienteAsociado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClienteAsociado.ImageOptions.Image")));
            //this.btnClienteAsociado.Location = new System.Drawing.Point(777, 13);
            //this.btnClienteAsociado.Name = "btnClienteAsociado";
            //this.btnClienteAsociado.Size = new System.Drawing.Size(26, 20);
            //this.btnClienteAsociado.TabIndex = 128;
            //this.btnClienteAsociado.ToolTipTitle = "Cliente Asociado";
            // 
            // btnBuscar
            // 
            //this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            //this.btnBuscar.Location = new System.Drawing.Point(144, 13);
            //this.btnBuscar.Name = "btnBuscar";
            //this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            //this.btnBuscar.TabIndex = 126;
            // 
            // txtDescCliente
            // 
            //this.txtDescCliente.Location = new System.Drawing.Point(171, 13);
            //this.txtDescCliente.Name = "txtDescCliente";
            //this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            //this.txtDescCliente.Properties.MaxLength = 50;
            //this.txtDescCliente.Properties.ReadOnly = true;
            //this.txtDescCliente.Size = new System.Drawing.Size(605, 20);
            //this.txtDescCliente.TabIndex = 127;
            // 
            // txtNumeroDocumento
            // 
            //this.txtNumeroDocumento.Location = new System.Drawing.Point(51, 13);
            //this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            //this.txtNumeroDocumento.Properties.MaxLength = 15;
            //this.txtNumeroDocumento.Size = new System.Drawing.Size(92, 20);
            //this.txtNumeroDocumento.TabIndex = 125;
            // 
            // groupBox1
            // 
            //this.groupBox1.Controls.Add(this.lookUpEdit1);
            //this.groupBox1.Controls.Add(this.labelControl2);
            //this.groupBox1.Controls.Add(this.txtDescCliente);
            //this.groupBox1.Controls.Add(this.deFecha);
            //this.groupBox1.Controls.Add(this.labelControl6);
            //this.groupBox1.Controls.Add(this.btnClienteAsociado);
            //this.groupBox1.Controls.Add(this.txtNumeroDocumento);
            //this.groupBox1.Controls.Add(this.labelControl1);
            //this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.labelControl11);
            this.groupBox1.Location = new System.Drawing.Point(5, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 236);
            this.groupBox1.TabIndex = 130;
            this.groupBox1.TabStop = false;
            // 
            // labelControl2
            // 
            //this.labelControl2.Location = new System.Drawing.Point(8, 95);
            //this.labelControl2.Name = "labelControl2";
            //this.labelControl2.Size = new System.Drawing.Size(32, 13);
            //this.labelControl2.TabIndex = 129;
            //this.labelControl2.Text = "Notas:";
            // 
            // lookUpEdit1
            // 
            //this.lookUpEdit1.Location = new System.Drawing.Point(51, 34);
            //this.lookUpEdit1.Name = "lookUpEdit1";
            //this.lookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            //this.lookUpEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            //this.lookUpEdit1.Properties.Appearance.Options.UseFont = true;
            //this.lookUpEdit1.Properties.Appearance.Options.UseForeColor = true;
            //this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            //new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            //this.lookUpEdit1.Properties.NullText = "";
            //this.lookUpEdit1.Size = new System.Drawing.Size(281, 20);
            //this.lookUpEdit1.TabIndex = 131;
            // 
            // frmAgendarVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 486);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgendarVisitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAgendarVisitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAsesor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            //((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.LookUpEdit cboAsesor;
        private DevExpress.XtraEditors.LabelControl lblAsesor;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        //public LookUpEdit lookUpEdit1;
        //private LabelControl labelControl2;
        //private TextEdit txtDescCliente;
        //private SimpleButton btnClienteAsociado;
        //private TextEdit txtNumeroDocumento;
        //private SimpleButton btnBuscar;
    }
}