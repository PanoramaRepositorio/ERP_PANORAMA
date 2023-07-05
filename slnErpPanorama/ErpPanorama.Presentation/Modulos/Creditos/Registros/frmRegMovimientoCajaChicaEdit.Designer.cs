namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    partial class frmRegMovimientoCajaChicaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegMovimientoCajaChicaEdit));
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboCondicionPago = new DevExpress.XtraEditors.LookUpEdit();
            this.optPago = new System.Windows.Forms.RadioButton();
            this.optRetiro = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteSoles = new DevExpress.XtraEditors.TextEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboPersonaAutoriza = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscarPersona = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescAnexo = new DevExpress.XtraEditors.TextEdit();
            this.lblDes = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.txtConcepto = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtIdHoraExtra = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroPrestamo = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoAnexo = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCondicionPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteSoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonaAutoriza.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescAnexo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdHoraExtra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPrestamo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoAnexo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(391, 296);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(308, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Cond. Pago:";
            // 
            // cboCondicionPago
            // 
            this.cboCondicionPago.Location = new System.Drawing.Point(374, 75);
            this.cboCondicionPago.Name = "cboCondicionPago";
            this.cboCondicionPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCondicionPago.Properties.NullText = "";
            this.cboCondicionPago.Properties.ReadOnly = true;
            this.cboCondicionPago.Size = new System.Drawing.Size(172, 20);
            this.cboCondicionPago.TabIndex = 12;
            // 
            // optPago
            // 
            this.optPago.AutoSize = true;
            this.optPago.Location = new System.Drawing.Point(103, 121);
            this.optPago.Name = "optPago";
            this.optPago.Size = new System.Drawing.Size(62, 17);
            this.optPago.TabIndex = 16;
            this.optPago.Text = "&Ingreso";
            this.optPago.UseVisualStyleBackColor = true;
            this.optPago.CheckedChanged += new System.EventHandler(this.optPago_CheckedChanged);
            // 
            // optRetiro
            // 
            this.optRetiro.AutoSize = true;
            this.optRetiro.Checked = true;
            this.optRetiro.Location = new System.Drawing.Point(176, 121);
            this.optRetiro.Name = "optRetiro";
            this.optRetiro.Size = new System.Drawing.Size(53, 17);
            this.optRetiro.TabIndex = 15;
            this.optRetiro.TabStop = true;
            this.optRetiro.Text = "&Salida";
            this.optRetiro.UseVisualStyleBackColor = true;
            this.optRetiro.CheckedChanged += new System.EventHandler(this.optRetiro_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 100);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Concepto:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(23, 148);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "Importe: ";
            // 
            // txtImporteSoles
            // 
            this.txtImporteSoles.EditValue = "0.00";
            this.txtImporteSoles.Location = new System.Drawing.Point(101, 145);
            this.txtImporteSoles.Name = "txtImporteSoles";
            this.txtImporteSoles.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteSoles.Properties.Appearance.Options.UseFont = true;
            this.txtImporteSoles.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteSoles.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteSoles.Properties.Mask.EditMask = "n2";
            this.txtImporteSoles.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteSoles.Properties.Mask.ShowPlaceHolders = false;
            this.txtImporteSoles.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtImporteSoles.Size = new System.Drawing.Size(131, 20);
            this.txtImporteSoles.TabIndex = 20;
            this.txtImporteSoles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteSoles_KeyPress);
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(374, 119);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Properties.ReadOnly = true;
            this.cboMoneda.Size = new System.Drawing.Size(172, 20);
            this.cboMoneda.TabIndex = 18;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(326, 122);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Moneda:";
            // 
            // cboDocumento
            // 
            this.cboDocumento.Location = new System.Drawing.Point(101, 75);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Size = new System.Drawing.Size(69, 20);
            this.cboDocumento.TabIndex = 9;
            this.cboDocumento.EditValueChanged += new System.EventHandler(this.cboDocumento_EditValueChanged);
            this.cboDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDocumento_KeyPress);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(176, 75);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(126, 20);
            this.txtNumeroDocumento.TabIndex = 10;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(23, 78);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "Documento:";
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(404, 30);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(36, 13);
            this.lblAño.TabIndex = 3;
            this.lblAño.Text = "Fecha: ";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(446, 27);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Properties.ReadOnly = true;
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 4;
            // 
            // grdDatos
            // 
            this.grdDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatos.Controls.Add(this.cboPersonaAutoriza);
            this.grdDatos.Controls.Add(this.labelControl12);
            this.grdDatos.Controls.Add(this.btnBuscarPersona);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.txtDescAnexo);
            this.grdDatos.Controls.Add(this.lblDes);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboCondicionPago);
            this.grdDatos.Controls.Add(this.optPago);
            this.grdDatos.Controls.Add(this.optRetiro);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.txtImporteSoles);
            this.grdDatos.Controls.Add(this.cboMoneda);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboTipoAnexo);
            this.grdDatos.Controls.Add(this.cboDocumento);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.lblAño);
            this.grdDatos.Controls.Add(this.deFecha);
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Controls.Add(this.txtConcepto);
            this.grdDatos.Location = new System.Drawing.Point(-1, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(569, 247);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // cboPersonaAutoriza
            // 
            this.cboPersonaAutoriza.Location = new System.Drawing.Point(101, 166);
            this.cboPersonaAutoriza.Name = "cboPersonaAutoriza";
            this.cboPersonaAutoriza.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPersonaAutoriza.Properties.NullText = "";
            this.cboPersonaAutoriza.Size = new System.Drawing.Size(445, 20);
            this.cboPersonaAutoriza.TabIndex = 22;
            this.cboPersonaAutoriza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPersonaAutoriza_KeyPress);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(23, 169);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(75, 13);
            this.labelControl12.TabIndex = 21;
            this.labelControl12.Text = "Autorizado por:";
            // 
            // btnBuscarPersona
            // 
            this.btnBuscarPersona.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPersona.ImageOptions.Image")));
            this.btnBuscarPersona.Location = new System.Drawing.Point(520, 49);
            this.btnBuscarPersona.Name = "btnBuscarPersona";
            this.btnBuscarPersona.Size = new System.Drawing.Size(26, 20);
            this.btnBuscarPersona.TabIndex = 7;
            this.btnBuscarPersona.Click += new System.EventHandler(this.btnBuscarPersona_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(23, 191);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 13);
            this.labelControl6.TabIndex = 23;
            this.labelControl6.Text = "Observación:";
            // 
            // txtDescAnexo
            // 
            this.txtDescAnexo.Location = new System.Drawing.Point(101, 49);
            this.txtDescAnexo.Name = "txtDescAnexo";
            this.txtDescAnexo.Properties.ReadOnly = true;
            this.txtDescAnexo.Size = new System.Drawing.Size(418, 20);
            this.txtDescAnexo.TabIndex = 6;
            // 
            // lblDes
            // 
            this.lblDes.Location = new System.Drawing.Point(23, 52);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(40, 13);
            this.lblDes.TabIndex = 5;
            this.lblDes.Text = "Usuario:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(101, 189);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Properties.MaxLength = 50;
            this.txtObservacion.Size = new System.Drawing.Size(445, 52);
            this.txtObservacion.TabIndex = 24;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(101, 97);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtConcepto.Properties.Appearance.Options.UseFont = true;
            this.txtConcepto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtConcepto.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Properties.Items.AddRange(new object[] {
            "COMIDA",
            "INSUMOS Y SUMINISTROS",
            "MOVILIDAD",
            "TRABAJO DE PERSONAL",
            "REAJUSTE DE SUELDO",
            "RETIRO GERENCIA",
            "OTROS"});
            this.txtConcepto.Properties.MaxLength = 50;
            this.txtConcepto.Size = new System.Drawing.Size(445, 20);
            this.txtConcepto.TabIndex = 14;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(470, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.txtIdHoraExtra);
            this.groupControl1.Controls.Add(this.txtNumeroPrestamo);
            this.groupControl1.Location = new System.Drawing.Point(-1, 247);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(316, 72);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Datos Interno";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(23, 49);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(53, 13);
            this.labelControl11.TabIndex = 10;
            this.labelControl11.Text = "N° HH.EE. ";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(23, 26);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(74, 13);
            this.labelControl10.TabIndex = 11;
            this.labelControl10.Text = "N° Préstamo:";
            // 
            // txtIdHoraExtra
            // 
            this.txtIdHoraExtra.Location = new System.Drawing.Point(101, 46);
            this.txtIdHoraExtra.Name = "txtIdHoraExtra";
            this.txtIdHoraExtra.Properties.MaxLength = 15;
            this.txtIdHoraExtra.Size = new System.Drawing.Size(97, 20);
            this.txtIdHoraExtra.TabIndex = 12;
            // 
            // txtNumeroPrestamo
            // 
            this.txtNumeroPrestamo.Location = new System.Drawing.Point(101, 23);
            this.txtNumeroPrestamo.Name = "txtNumeroPrestamo";
            this.txtNumeroPrestamo.Properties.MaxLength = 15;
            this.txtNumeroPrestamo.Size = new System.Drawing.Size(97, 20);
            this.txtNumeroPrestamo.TabIndex = 13;
            this.txtNumeroPrestamo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroPrestamo_KeyDown);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(204, 23);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 44);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Pago Domingos\r\ny Feriados";
            this.simpleButton1.ToolTip = "Lista de trabajos por apoyo";
            this.simpleButton1.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Documento:";
            // 
            // cboTipoAnexo
            // 
            this.cboTipoAnexo.Location = new System.Drawing.Point(101, 27);
            this.cboTipoAnexo.Name = "cboTipoAnexo";
            this.cboTipoAnexo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoAnexo.Properties.NullText = "";
            this.cboTipoAnexo.Size = new System.Drawing.Size(201, 20);
            this.cboTipoAnexo.TabIndex = 9;
            this.cboTipoAnexo.EditValueChanged += new System.EventHandler(this.cboDocumento_EditValueChanged);
            this.cboTipoAnexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDocumento_KeyPress);
            // 
            // frmRegMovimientoCajaChicaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 332);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegMovimientoCajaChicaEdit";
            this.Load += new System.EventHandler(this.frmRegMovimientoCajaChicaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboCondicionPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteSoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonaAutoriza.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescAnexo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConcepto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdHoraExtra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPrestamo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoAnexo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboCondicionPago;
        private System.Windows.Forms.RadioButton optPago;
        private System.Windows.Forms.RadioButton optRetiro;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtImporteSoles;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        public DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnBuscarPersona;
        private DevExpress.XtraEditors.TextEdit txtDescAnexo;
        private DevExpress.XtraEditors.LabelControl lblDes;
        public DevExpress.XtraEditors.LookUpEdit cboPersonaAutoriza;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.ComboBoxEdit txtConcepto;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        public DevExpress.XtraEditors.TextEdit txtIdHoraExtra;
        public DevExpress.XtraEditors.TextEdit txtNumeroPrestamo;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.LookUpEdit cboTipoAnexo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}