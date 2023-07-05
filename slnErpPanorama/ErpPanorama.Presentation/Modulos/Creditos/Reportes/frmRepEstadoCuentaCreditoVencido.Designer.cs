namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    partial class frmRepEstadoCuentaCreditoVencido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepEstadoCuentaCreditoVencido));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.chkClienteTodo = new System.Windows.Forms.CheckBox();
            this.cboClasificacion = new DevExpress.XtraEditors.LookUpEdit();
            this.chkClasifica = new System.Windows.Forms.CheckBox();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboClasifica = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkMoroso = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasifica.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(86, 34);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 17;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(86, 12);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 15;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(11, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 14;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(507, 174);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(409, 174);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 12;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(389, 137);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(193, 20);
            this.txtTipoCliente.TabIndex = 50;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(208, 111);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 48;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(240, 111);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(342, 20);
            this.txtDescCliente.TabIndex = 49;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(87, 111);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Properties.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(115, 20);
            this.txtNumeroDocumento.TabIndex = 47;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 114);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 46;
            this.labelControl5.Text = "Cliente:";
            // 
            // chkClienteTodo
            // 
            this.chkClienteTodo.AutoSize = true;
            this.chkClienteTodo.Checked = true;
            this.chkClienteTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClienteTodo.Location = new System.Drawing.Point(11, 91);
            this.chkClienteTodo.Name = "chkClienteTodo";
            this.chkClienteTodo.Size = new System.Drawing.Size(112, 17);
            this.chkClienteTodo.TabIndex = 45;
            this.chkClienteTodo.Text = "Todos los Clientes";
            this.chkClienteTodo.UseVisualStyleBackColor = true;
            this.chkClienteTodo.CheckedChanged += new System.EventHandler(this.chkClienteTodo_CheckedChanged);
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.Enabled = false;
            this.cboClasificacion.Location = new System.Drawing.Point(315, 12);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClasificacion.Properties.NullText = "";
            this.cboClasificacion.Size = new System.Drawing.Size(123, 20);
            this.cboClasificacion.TabIndex = 55;
            // 
            // chkClasifica
            // 
            this.chkClasifica.AutoSize = true;
            this.chkClasifica.Location = new System.Drawing.Point(226, 14);
            this.chkClasifica.Name = "chkClasifica";
            this.chkClasifica.Size = new System.Drawing.Size(88, 17);
            this.chkClasifica.TabIndex = 54;
            this.chkClasifica.Text = "Clasificación:";
            this.chkClasifica.UseVisualStyleBackColor = true;
            this.chkClasifica.CheckedChanged += new System.EventHandler(this.chkClasifica_CheckedChanged);
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(86, 57);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(121, 20);
            this.cboMotivo.TabIndex = 57;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 56;
            this.labelControl2.Text = "Motivo:";
            // 
            // cboClasifica
            // 
            this.cboClasifica.Location = new System.Drawing.Point(315, 34);
            this.cboClasifica.Name = "cboClasifica";
            this.cboClasifica.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClasifica.Properties.NullText = "";
            this.cboClasifica.Size = new System.Drawing.Size(123, 20);
            this.cboClasifica.TabIndex = 59;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(268, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 58;
            this.labelControl3.Text = "Califica:";
            // 
            // chkMoroso
            // 
            this.chkMoroso.AutoSize = true;
            this.chkMoroso.Location = new System.Drawing.Point(226, 60);
            this.chkMoroso.Name = "chkMoroso";
            this.chkMoroso.Size = new System.Drawing.Size(93, 17);
            this.chkMoroso.TabIndex = 60;
            this.chkMoroso.Text = "Incluir Moroso";
            this.chkMoroso.UseVisualStyleBackColor = true;
            this.chkMoroso.CheckedChanged += new System.EventHandler(this.chkMoroso_CheckedChanged);
            // 
            // frmRepEstadoCuentaCreditoVencido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 203);
            this.Controls.Add(this.chkMoroso);
            this.Controls.Add(this.cboClasifica);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboClasificacion);
            this.Controls.Add(this.chkClasifica);
            this.Controls.Add(this.txtTipoCliente);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescCliente);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.chkClienteTodo);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.Name = "frmRepEstadoCuentaCreditoVencido";
            this.Text = "Reporte de Créditos Vencidos";
            this.Load += new System.EventHandler(this.frmRepEstadoCuentaCreditoVencido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasifica.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.CheckBox chkClienteTodo;
        public DevExpress.XtraEditors.LookUpEdit cboClasificacion;
        private System.Windows.Forms.CheckBox chkClasifica;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboClasifica;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.CheckBox chkMoroso;
    }
}