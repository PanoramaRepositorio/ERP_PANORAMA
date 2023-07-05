namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegMovimientoAgenteEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegMovimientoAgenteEdit));
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtConcepto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteDolares = new DevExpress.XtraEditors.TextEdit();
            this.txtImporteSoles = new DevExpress.XtraEditors.TextEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboCondicionPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.cboCaja = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.optPago = new System.Windows.Forms.RadioButton();
            this.optRetiro = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDolares.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteSoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCondicionPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Concepto:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(76, 72);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Properties.MaxLength = 50;
            this.txtConcepto.Size = new System.Drawing.Size(445, 20);
            this.txtConcepto.TabIndex = 10;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(250, 144);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 13);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "Importe US$: ";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 144);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 13;
            this.labelControl8.Text = "Importe S/: ";
            // 
            // txtImporteDolares
            // 
            this.txtImporteDolares.EditValue = "0.00";
            this.txtImporteDolares.Location = new System.Drawing.Point(320, 141);
            this.txtImporteDolares.Name = "txtImporteDolares";
            this.txtImporteDolares.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteDolares.Properties.Appearance.Options.UseFont = true;
            this.txtImporteDolares.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteDolares.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteDolares.Properties.Mask.EditMask = "n2";
            this.txtImporteDolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteDolares.Properties.Mask.ShowPlaceHolders = false;
            this.txtImporteDolares.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtImporteDolares.Size = new System.Drawing.Size(100, 20);
            this.txtImporteDolares.TabIndex = 18;
            // 
            // txtImporteSoles
            // 
            this.txtImporteSoles.EditValue = "0.00";
            this.txtImporteSoles.Location = new System.Drawing.Point(76, 141);
            this.txtImporteSoles.Name = "txtImporteSoles";
            this.txtImporteSoles.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteSoles.Properties.Appearance.Options.UseFont = true;
            this.txtImporteSoles.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteSoles.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteSoles.Properties.Mask.EditMask = "n2";
            this.txtImporteSoles.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteSoles.Properties.Mask.ShowPlaceHolders = false;
            this.txtImporteSoles.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtImporteSoles.Size = new System.Drawing.Size(100, 20);
            this.txtImporteSoles.TabIndex = 14;
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(76, 120);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(172, 20);
            this.cboMoneda.TabIndex = 12;
            this.cboMoneda.Click += new System.EventHandler(this.cboMoneda_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 123);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Moneda:";
            // 
            // cboCondicionPago
            // 
            this.cboCondicionPago.Location = new System.Drawing.Point(323, 50);
            this.cboCondicionPago.Name = "cboCondicionPago";
            this.cboCondicionPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCondicionPago.Properties.NullText = "";
            this.cboCondicionPago.Size = new System.Drawing.Size(198, 20);
            this.cboCondicionPago.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(257, 53);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Cond. Pago:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(250, 123);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "TC: ";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.EditValue = "0.00";
            this.txtTipoCambio.Location = new System.Drawing.Point(320, 120);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCambio.Properties.DisplayFormat.FormatString = "n2";
            this.txtTipoCambio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTipoCambio.Properties.Mask.EditMask = "n2";
            this.txtTipoCambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoCambio.Properties.Mask.ShowPlaceHolders = false;
            this.txtTipoCambio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(49, 20);
            this.txtTipoCambio.TabIndex = 17;
            // 
            // cboDocumento
            // 
            this.cboDocumento.Location = new System.Drawing.Point(76, 50);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Properties.ReadOnly = true;
            this.cboDocumento.Size = new System.Drawing.Size(69, 20);
            this.cboDocumento.TabIndex = 5;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(151, 50);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(97, 20);
            this.txtNumeroDocumento.TabIndex = 6;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(367, 186);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 53);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Documento:";
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(379, 31);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(36, 13);
            this.lblAño.TabIndex = 2;
            this.lblAño.Text = "Fecha: ";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(421, 28);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.ReadOnly = true;
            this.deFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 3;
            // 
            // cboCaja
            // 
            this.cboCaja.Location = new System.Drawing.Point(76, 28);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaja.Properties.NullText = "";
            this.cboCaja.Size = new System.Drawing.Size(297, 20);
            this.cboCaja.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Caja:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(446, 186);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.optPago);
            this.grdDatos.Controls.Add(this.optRetiro);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtConcepto);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.txtImporteDolares);
            this.grdDatos.Controls.Add(this.txtImporteSoles);
            this.grdDatos.Controls.Add(this.cboMoneda);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboCondicionPago);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtTipoCambio);
            this.grdDatos.Controls.Add(this.cboDocumento);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.lblAño);
            this.grdDatos.Controls.Add(this.deFecha);
            this.grdDatos.Controls.Add(this.cboCaja);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Location = new System.Drawing.Point(0, 1);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(528, 179);
            this.grdDatos.TabIndex = 6;
            this.grdDatos.Text = "Datos del Recibo de Pago";
            // 
            // optPago
            // 
            this.optPago.AutoSize = true;
            this.optPago.Location = new System.Drawing.Point(145, 97);
            this.optPago.Name = "optPago";
            this.optPago.Size = new System.Drawing.Size(49, 17);
            this.optPago.TabIndex = 20;
            this.optPago.Text = "Pago";
            this.optPago.UseVisualStyleBackColor = true;
            // 
            // optRetiro
            // 
            this.optRetiro.AutoSize = true;
            this.optRetiro.Checked = true;
            this.optRetiro.Location = new System.Drawing.Point(76, 97);
            this.optRetiro.Name = "optRetiro";
            this.optRetiro.Size = new System.Drawing.Size(54, 17);
            this.optRetiro.TabIndex = 19;
            this.optRetiro.TabStop = true;
            this.optRetiro.Text = "Retiro";
            this.optRetiro.UseVisualStyleBackColor = true;
            // 
            // frmRegMovimientoAgenteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 216);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegMovimientoAgenteEdit";
            this.Load += new System.EventHandler(this.frmRegMovimientoAgenteEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDolares.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteSoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCondicionPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtConcepto;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtImporteDolares;
        public DevExpress.XtraEditors.TextEdit txtImporteSoles;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboCondicionPago;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtTipoCambio;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        public DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFecha;
        public DevExpress.XtraEditors.LookUpEdit cboCaja;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.RadioButton optPago;
        private System.Windows.Forms.RadioButton optRetiro;
    }
}