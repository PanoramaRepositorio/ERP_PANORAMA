
namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    partial class frmRegChequeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegChequeEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtMonto = new DevExpress.XtraEditors.TextEdit();
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtDestino = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPortador = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.deFecEmision = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCheque = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNroRecibo = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCajaChica = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecEmision.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecEmision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroRecibo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCajaChica.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtCajaChica);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtNroRecibo);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtMonto);
            this.groupControl1.Controls.Add(this.txtObservacion);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtDestino);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.cboMotivo);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.cboMoneda);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtPortador);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.deFecEmision);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cboBanco);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtCheque);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(638, 215);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Cheques";
            // 
            // txtMonto
            // 
            this.txtMonto.EditValue = "0.00";
            this.txtMonto.Location = new System.Drawing.Point(525, 97);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Properties.DisplayFormat.FormatString = "n";
            this.txtMonto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMonto.Properties.EditFormat.FormatString = "N";
            this.txtMonto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMonto.Properties.Mask.EditMask = "n";
            this.txtMonto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMonto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 20;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress_1);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(82, 160);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(544, 20);
            this.txtObservacion.TabIndex = 19;
            this.txtObservacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacion_KeyPress);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(12, 163);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(67, 13);
            this.labelControl10.TabIndex = 18;
            this.labelControl10.Text = "Observacion: ";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(82, 139);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(544, 20);
            this.txtDestino.TabIndex = 17;
            this.txtDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDestino_KeyPress);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(36, 143);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(43, 13);
            this.labelControl9.TabIndex = 16;
            this.labelControl9.Text = "Destino: ";
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(82, 118);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Size = new System.Drawing.Size(544, 20);
            this.cboMotivo.TabIndex = 15;
            this.cboMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMotivo_KeyPress);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(40, 123);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(39, 13);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Motivo: ";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(484, 100);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(37, 13);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Monto: ";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(82, 97);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Size = new System.Drawing.Size(120, 20);
            this.cboMoneda.TabIndex = 11;
            this.cboMoneda.EditValueChanged += new System.EventHandler(this.cboMoneda_EditValueChanged);
            this.cboMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMoneda_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(37, 102);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(42, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Moneda:";
            // 
            // txtPortador
            // 
            this.txtPortador.Location = new System.Drawing.Point(82, 76);
            this.txtPortador.Name = "txtPortador";
            this.txtPortador.Size = new System.Drawing.Size(543, 20);
            this.txtPortador.TabIndex = 9;
            this.txtPortador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortador_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(33, 79);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Portador:";
            // 
            // deFecEmision
            // 
            this.deFecEmision.EditValue = null;
            this.deFecEmision.Location = new System.Drawing.Point(525, 55);
            this.deFecEmision.Name = "deFecEmision";
            this.deFecEmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecEmision.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecEmision.Size = new System.Drawing.Size(100, 20);
            this.deFecEmision.TabIndex = 7;
            this.deFecEmision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFecEmision_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(458, 58);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Fec. Emision:";
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(82, 55);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBanco.Size = new System.Drawing.Size(240, 20);
            this.cboBanco.TabIndex = 5;
            this.cboBanco.EditValueChanged += new System.EventHandler(this.cboBanco_EditValueChanged);
            this.cboBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBanco_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(46, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Banco:";
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(525, 33);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtCheque.Properties.Appearance.Options.UseFont = true;
            this.txtCheque.Properties.ReadOnly = true;
            this.txtCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCheque.Size = new System.Drawing.Size(100, 20);
            this.txtCheque.TabIndex = 3;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(456, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Nro. Cheque:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(82, 33);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Size = new System.Drawing.Size(312, 20);
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            this.cboEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboEmpresa_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Empresa:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(338, 219);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.Location = new System.Drawing.Point(257, 219);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 20;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtNroRecibo
            // 
            this.txtNroRecibo.Location = new System.Drawing.Point(82, 186);
            this.txtNroRecibo.Name = "txtNroRecibo";
            this.txtNroRecibo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtNroRecibo.Properties.Appearance.Options.UseFont = true;
            this.txtNroRecibo.Properties.MaxLength = 120;
            this.txtNroRecibo.Size = new System.Drawing.Size(120, 20);
            this.txtNroRecibo.TabIndex = 126;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(12, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 27);
            this.label5.TabIndex = 127;
            this.label5.Text = "Nro. Recibo Egreso:";
            // 
            // txtCajaChica
            // 
            this.txtCajaChica.Location = new System.Drawing.Point(458, 186);
            this.txtCajaChica.Name = "txtCajaChica";
            this.txtCajaChica.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtCajaChica.Properties.Appearance.Options.UseFont = true;
            this.txtCajaChica.Properties.MaxLength = 120;
            this.txtCajaChica.Size = new System.Drawing.Size(167, 20);
            this.txtCajaChica.TabIndex = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(344, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Caja Chica Tesoreria:";
            // 
            // frmRegChequeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 246);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmRegChequeEdit";
            this.Text = "Nuevo Cheque";
            this.Load += new System.EventHandler(this.frmRegChequeEdit_Load);
            this.Shown += new System.EventHandler(this.frmRegChequeEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecEmision.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecEmision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroRecibo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCajaChica.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.TextEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtDestino;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtPortador;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit deFecEmision;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cboBanco;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtCheque;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtMonto;
        private DevExpress.XtraEditors.TextEdit txtCajaChica;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtNroRecibo;
        private System.Windows.Forms.Label label5;
    }
}