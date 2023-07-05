namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    partial class frmRegAusenciaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegAusenciaEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblMensajeTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.lblFechaRecuperacion = new DevExpress.XtraEditors.LabelControl();
            this.txtDias = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscarAutorizado = new DevExpress.XtraEditors.SimpleButton();
            this.txtAutorizado = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.cboMotivoAusencia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPersona = new DevExpress.XtraEditors.TextEdit();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gboReporte = new System.Windows.Forms.GroupBox();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.optDetalle = new System.Windows.Forms.RadioButton();
            this.optSueldo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutorizado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivoAusencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.gboReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblMensajeTitulo);
            this.groupControl1.Controls.Add(this.lblMensaje);
            this.groupControl1.Controls.Add(this.deFecha);
            this.groupControl1.Controls.Add(this.lblFechaRecuperacion);
            this.groupControl1.Controls.Add(this.txtDias);
            this.groupControl1.Controls.Add(this.btnBuscarAutorizado);
            this.groupControl1.Controls.Add(this.txtAutorizado);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.txtObservacion);
            this.groupControl1.Controls.Add(this.cboMotivoAusencia);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.lblAño);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtPersona);
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(619, 202);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Datos de la Ausencia";
            // 
            // lblMensajeTitulo
            // 
            this.lblMensajeTitulo.Location = new System.Drawing.Point(479, 72);
            this.lblMensajeTitulo.Name = "lblMensajeTitulo";
            this.lblMensajeTitulo.Size = new System.Drawing.Size(26, 13);
            this.lblMensajeTitulo.TabIndex = 54;
            this.lblMensajeTitulo.Text = "Des.:";
            this.lblMensajeTitulo.Visible = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(511, 72);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(50, 13);
            this.lblMensaje.TabIndex = 55;
            this.lblMensaje.Text = "Domingo";
            this.lblMensaje.Visible = false;
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(479, 111);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Size = new System.Drawing.Size(82, 20);
            this.deFecha.TabIndex = 53;
            this.deFecha.Visible = false;
            // 
            // lblFechaRecuperacion
            // 
            this.lblFechaRecuperacion.Location = new System.Drawing.Point(479, 93);
            this.lblFechaRecuperacion.Name = "lblFechaRecuperacion";
            this.lblFechaRecuperacion.Size = new System.Drawing.Size(82, 13);
            this.lblFechaRecuperacion.TabIndex = 52;
            this.lblFechaRecuperacion.Text = "F. Recuperación:";
            this.lblFechaRecuperacion.Visible = false;
            // 
            // txtDias
            // 
            this.txtDias.EditValue = "1";
            this.txtDias.Location = new System.Drawing.Point(224, 90);
            this.txtDias.Name = "txtDias";
            this.txtDias.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDias.Properties.Appearance.Options.UseBackColor = true;
            this.txtDias.Properties.DisplayFormat.FormatString = "f0";
            this.txtDias.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDias.Properties.Mask.EditMask = "f0";
            this.txtDias.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDias.Properties.MaxLength = 4;
            this.txtDias.Size = new System.Drawing.Size(53, 20);
            this.txtDias.TabIndex = 51;
            this.txtDias.ToolTip = "[Enter]  - Fijar fecha final";
            this.txtDias.EditValueChanged += new System.EventHandler(this.txtDias_EditValueChanged);
            this.txtDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDias_KeyPress);
            // 
            // btnBuscarAutorizado
            // 
            this.btnBuscarAutorizado.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarAutorizado.Image")));
            this.btnBuscarAutorizado.Location = new System.Drawing.Point(585, 134);
            this.btnBuscarAutorizado.Name = "btnBuscarAutorizado";
            this.btnBuscarAutorizado.Size = new System.Drawing.Size(26, 20);
            this.btnBuscarAutorizado.TabIndex = 50;
            this.btnBuscarAutorizado.Click += new System.EventHandler(this.btnBuscarAutorizado_Click);
            // 
            // txtAutorizado
            // 
            this.txtAutorizado.Location = new System.Drawing.Point(87, 134);
            this.txtAutorizado.Name = "txtAutorizado";
            this.txtAutorizado.Size = new System.Drawing.Size(499, 20);
            this.txtAutorizado.TabIndex = 49;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 137);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Autorizado Por:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(12, 159);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(64, 13);
            this.labelControl12.TabIndex = 47;
            this.labelControl12.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(87, 156);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.MaxLength = 200;
            this.txtObservacion.Size = new System.Drawing.Size(523, 34);
            this.txtObservacion.TabIndex = 46;
            // 
            // cboMotivoAusencia
            // 
            this.cboMotivoAusencia.Location = new System.Drawing.Point(87, 112);
            this.cboMotivoAusencia.Name = "cboMotivoAusencia";
            this.cboMotivoAusencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivoAusencia.Properties.DropDownRows = 10;
            this.cboMotivoAusencia.Properties.NullText = "";
            this.cboMotivoAusencia.Size = new System.Drawing.Size(384, 20);
            this.cboMotivoAusencia.TabIndex = 37;
            this.cboMotivoAusencia.EditValueChanged += new System.EventHandler(this.cboMotivoAusencia_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 115);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(36, 13);
            this.labelControl9.TabIndex = 36;
            this.labelControl9.Text = "Motivo:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(194, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "Dias:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "Fecha Hasta:";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(87, 90);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 33;
            this.deFechaHasta.EditValueChanged += new System.EventHandler(this.deFechaHasta_EditValueChanged);
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(11, 71);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(69, 13);
            this.lblAño.TabIndex = 30;
            this.lblAño.Text = "Fecha Desde: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(87, 68);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 31;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(584, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(87, 46);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(499, 20);
            this.txtPersona.TabIndex = 22;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(87, 24);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(523, 20);
            this.cboEmpresa.TabIndex = 21;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(11, 49);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(43, 13);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "Persona:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Empresa:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(547, 211);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(466, 211);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 29;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gboReporte);
            this.groupControl2.Location = new System.Drawing.Point(3, 211);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(338, 90);
            this.groupControl2.TabIndex = 40;
            this.groupControl2.Text = "Tipo de pago";
            this.groupControl2.Visible = false;
            // 
            // gboReporte
            // 
            this.gboReporte.Controls.Add(this.optResumen);
            this.gboReporte.Controls.Add(this.optDetalle);
            this.gboReporte.Controls.Add(this.optSueldo);
            this.gboReporte.Location = new System.Drawing.Point(9, 24);
            this.gboReporte.Name = "gboReporte";
            this.gboReporte.Size = new System.Drawing.Size(228, 50);
            this.gboReporte.TabIndex = 52;
            this.gboReporte.TabStop = false;
            this.gboReporte.Text = "Descuento a cuenta de";
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Location = new System.Drawing.Point(90, 20);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(57, 17);
            this.optResumen.TabIndex = 1;
            this.optResumen.Text = "Salario";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // optDetalle
            // 
            this.optDetalle.AutoSize = true;
            this.optDetalle.Checked = true;
            this.optDetalle.Location = new System.Drawing.Point(6, 20);
            this.optDetalle.Name = "optDetalle";
            this.optDetalle.Size = new System.Drawing.Size(78, 17);
            this.optDetalle.TabIndex = 0;
            this.optDetalle.TabStop = true;
            this.optDetalle.Text = "Vacaciones";
            this.optDetalle.UseVisualStyleBackColor = true;
            // 
            // optSueldo
            // 
            this.optSueldo.AutoSize = true;
            this.optSueldo.Location = new System.Drawing.Point(154, 20);
            this.optSueldo.Name = "optSueldo";
            this.optSueldo.Size = new System.Drawing.Size(52, 17);
            this.optSueldo.TabIndex = 2;
            this.optSueldo.Text = "Otros";
            this.optSueldo.UseVisualStyleBackColor = true;
            // 
            // frmRegAusenciaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 249);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegAusenciaEdit";
            this.Load += new System.EventHandler(this.frmRegAusenciaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutorizado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivoAusencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.gboReporte.ResumeLayout(false);
            this.gboReporte.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        public DevExpress.XtraEditors.LookUpEdit cboMotivoAusencia;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtPersona;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnBuscarAutorizado;
        private DevExpress.XtraEditors.TextEdit txtAutorizado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtDias;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.GroupBox gboReporte;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.RadioButton optSueldo;
        private DevExpress.XtraEditors.LabelControl lblMensajeTitulo;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl lblFechaRecuperacion;
    }
}