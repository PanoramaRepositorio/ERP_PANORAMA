namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    partial class frmRegEstadoCuentaProveedorPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegEstadoCuentaProveedorPago));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtDescProveedor = new DevExpress.XtraEditors.TextEdit();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboFactuaCompra = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLimpiar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.optPagoAbono = new System.Windows.Forms.RadioButton();
            this.optCreditoCargo = new System.Windows.Forms.RadioButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroPedido = new DevExpress.XtraEditors.TextEdit();
            this.deFechaVencimiento = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDeposito = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaCredito = new DevExpress.XtraEditors.DateEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporte = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.txtConcepto = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactuaCompra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDeposito.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDeposito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaCredito.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaCredito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(463, 240);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtTipoCliente);
            this.groupControl1.Controls.Add(this.txtDescProveedor);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(565, 52);
            this.groupControl1.TabIndex = 33;
            this.groupControl1.Text = "Datos del Cliente";
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(585, 25);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCliente.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(170, 20);
            this.txtTipoCliente.TabIndex = 77;
            // 
            // txtDescProveedor
            // 
            this.txtDescProveedor.Location = new System.Drawing.Point(72, 25);
            this.txtDescProveedor.Name = "txtDescProveedor";
            this.txtDescProveedor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescProveedor.Properties.Appearance.Options.UseFont = true;
            this.txtDescProveedor.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescProveedor.Properties.MaxLength = 50;
            this.txtDescProveedor.Properties.ReadOnly = true;
            this.txtDescProveedor.Size = new System.Drawing.Size(483, 20);
            this.txtDescProveedor.TabIndex = 76;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(561, 25);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Properties.Appearance.Options.UseFont = true;
            this.txtNumero.Properties.MaxLength = 15;
            this.txtNumero.Properties.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(99, 20);
            this.txtNumero.TabIndex = 74;
            this.txtNumero.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 73;
            this.labelControl5.Text = "Proveedor:";
            // 
            // cboFactuaCompra
            // 
            this.cboFactuaCompra.Location = new System.Drawing.Point(282, 26);
            this.cboFactuaCompra.Name = "cboFactuaCompra";
            this.cboFactuaCompra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFactuaCompra.Properties.NullText = "";
            this.cboFactuaCompra.Size = new System.Drawing.Size(90, 20);
            this.cboFactuaCompra.TabIndex = 51;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Eliminar_16x16;
            this.btnLimpiar.ImageOptions.ImageIndex = 0;
            this.btnLimpiar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(378, 25);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(26, 21);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(12, 143);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(64, 13);
            this.labelControl10.TabIndex = 50;
            this.labelControl10.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(91, 141);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.MaxLength = 200;
            this.txtObservacion.Size = new System.Drawing.Size(464, 34);
            this.txtObservacion.TabIndex = 49;
            this.txtObservacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacion_KeyPress);
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(461, 23);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(94, 20);
            this.cboMotivo.TabIndex = 7;
            this.cboMotivo.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(419, 26);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 48;
            this.labelControl7.Text = "Motivo:";
            this.labelControl7.Visible = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::ErpPanorama.Presentation.Properties.Resources.Pagos_32x32;
            this.pictureEdit1.Location = new System.Drawing.Point(690, 24);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(23, 28);
            this.pictureEdit1.TabIndex = 47;
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(382, 240);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 31;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.optPagoAbono);
            this.groupControl2.Controls.Add(this.optCreditoCargo);
            this.groupControl2.Controls.Add(this.cboFactuaCompra);
            this.groupControl2.Controls.Add(this.btnLimpiar);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Controls.Add(this.txtObservacion);
            this.groupControl2.Controls.Add(this.pictureEdit1);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.txtNumeroPedido);
            this.groupControl2.Controls.Add(this.deFechaVencimiento);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.deFechaDeposito);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.deFechaCredito);
            this.groupControl2.Controls.Add(this.labelControl11);
            this.groupControl2.Controls.Add(this.txtImporte);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.txtNumeroDocumento);
            this.groupControl2.Controls.Add(this.txtConcepto);
            this.groupControl2.Controls.Add(this.cboMotivo);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 52);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(565, 184);
            this.groupControl2.TabIndex = 30;
            this.groupControl2.Text = "Datos del Estado de Cuenta";
            // 
            // optPagoAbono
            // 
            this.optPagoAbono.AutoSize = true;
            this.optPagoAbono.Enabled = false;
            this.optPagoAbono.Location = new System.Drawing.Point(466, 55);
            this.optPagoAbono.Name = "optPagoAbono";
            this.optPagoAbono.Size = new System.Drawing.Size(83, 17);
            this.optPagoAbono.TabIndex = 53;
            this.optPagoAbono.Text = "Pago Abono";
            this.optPagoAbono.UseVisualStyleBackColor = true;
            // 
            // optCreditoCargo
            // 
            this.optCreditoCargo.AutoSize = true;
            this.optCreditoCargo.Checked = true;
            this.optCreditoCargo.Location = new System.Drawing.Point(373, 55);
            this.optCreditoCargo.Name = "optCreditoCargo";
            this.optCreditoCargo.Size = new System.Drawing.Size(92, 17);
            this.optCreditoCargo.TabIndex = 52;
            this.optCreditoCargo.TabStop = true;
            this.optCreditoCargo.Text = "Crédito Cargo";
            this.optCreditoCargo.UseVisualStyleBackColor = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(552, 78);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Pedido N°:";
            this.labelControl6.Visible = false;
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Location = new System.Drawing.Point(609, 99);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroPedido.Properties.MaxLength = 15;
            this.txtNumeroPedido.Size = new System.Drawing.Size(104, 20);
            this.txtNumeroPedido.TabIndex = 4;
            // 
            // deFechaVencimiento
            // 
            this.deFechaVencimiento.EditValue = null;
            this.deFechaVencimiento.Location = new System.Drawing.Point(91, 97);
            this.deFechaVencimiento.Name = "deFechaVencimiento";
            this.deFechaVencimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaVencimiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaVencimiento.Size = new System.Drawing.Size(90, 20);
            this.deFechaVencimiento.TabIndex = 5;
            this.deFechaVencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaVencimiento_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Fecha Vcto:";
            // 
            // deFechaDeposito
            // 
            this.deFechaDeposito.EditValue = null;
            this.deFechaDeposito.Location = new System.Drawing.Point(282, 52);
            this.deFechaDeposito.Name = "deFechaDeposito";
            this.deFechaDeposito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDeposito.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDeposito.Size = new System.Drawing.Size(90, 20);
            this.deFechaDeposito.TabIndex = 2;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(235, 29);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(41, 13);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "Factura:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(203, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(78, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Fecha Depósito:";
            // 
            // deFechaCredito
            // 
            this.deFechaCredito.EditValue = null;
            this.deFechaCredito.Location = new System.Drawing.Point(91, 52);
            this.deFechaCredito.Name = "deFechaCredito";
            this.deFechaCredito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaCredito.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaCredito.Size = new System.Drawing.Size(90, 20);
            this.deFechaCredito.TabIndex = 1;
            this.deFechaCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaCredito_KeyPress);
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 55);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 13);
            this.labelControl11.TabIndex = 4;
            this.labelControl11.Text = "Fecha Pago:";
            // 
            // txtImporte
            // 
            this.txtImporte.EditValue = "0.00";
            this.txtImporte.Location = new System.Drawing.Point(91, 120);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Properties.DisplayFormat.FormatString = "n";
            this.txtImporte.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporte.Properties.Mask.EditMask = "n";
            this.txtImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImporte.Size = new System.Drawing.Size(90, 20);
            this.txtImporte.TabIndex = 6;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 123);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(42, 13);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "Importe:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Concepto:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "N° Documento:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(91, 30);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(137, 20);
            this.txtNumeroDocumento.TabIndex = 0;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
            // 
            // txtConcepto
            // 
            this.txtConcepto.EditValue = "PAGO";
            this.txtConcepto.Location = new System.Drawing.Point(91, 75);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtConcepto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Properties.Items.AddRange(new object[] {
            "DEVOLUCION",
            "PAGO",
            "CARGO"});
            this.txtConcepto.Properties.MaxLength = 50;
            this.txtConcepto.Size = new System.Drawing.Size(464, 20);
            this.txtConcepto.TabIndex = 3;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            // 
            // frmRegEstadoCuentaProveedorPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 267);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmRegEstadoCuentaProveedorPago";
            this.Text = "EstadoCuentaProveedorPago";
            this.Load += new System.EventHandler(this.frmRegEstadoCuentaProveedorPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFactuaCompra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDeposito.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDeposito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaCredito.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaCredito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private DevExpress.XtraEditors.TextEdit txtDescProveedor;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboFactuaCompra;
        private DevExpress.XtraEditors.SimpleButton btnLimpiar;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtNumeroPedido;
        public DevExpress.XtraEditors.DateEdit deFechaVencimiento;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.DateEdit deFechaDeposito;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.DateEdit deFechaCredito;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtImporte;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.ComboBoxEdit txtConcepto;
        private System.Windows.Forms.RadioButton optPagoAbono;
        private System.Windows.Forms.RadioButton optCreditoCargo;
    }
}