namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManTarjetaRegaloEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTarjetaRegaloEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.btnNuevoCliente = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteDisponible = new DevExpress.XtraEditors.TextEdit();
            this.txtImporteTotal = new DevExpress.XtraEditors.TextEdit();
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDisponible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.label1);
            this.grdDatos.Controls.Add(this.labelControl10);
            this.grdDatos.Controls.Add(this.btnNuevoCliente);
            this.grdDatos.Controls.Add(this.btnBuscar);
            this.grdDatos.Controls.Add(this.groupControl1);
            this.grdDatos.Controls.Add(this.txtDescCliente);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.labelControl9);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtImporteDisponible);
            this.grdDatos.Controls.Add(this.txtImporteTotal);
            this.grdDatos.Controls.Add(this.cboSituacion);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.cboTienda);
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtNumero);
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(923, 188);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label1.Location = new System.Drawing.Point(580, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 48);
            this.label1.TabIndex = 17;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(25, 49);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(37, 13);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "Cliente:";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Enabled = false;
            this.btnNuevoCliente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoCliente.ImageOptions.Image")));
            this.btnNuevoCliente.Location = new System.Drawing.Point(548, 46);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(26, 20);
            this.btnNuevoCliente.TabIndex = 6;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(196, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.deHasta);
            this.groupControl1.Controls.Add(this.deDesde);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Location = new System.Drawing.Point(580, 23);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(340, 52);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "Vigencia";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(175, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Hasta:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(213, 23);
            this.deHasta.Name = "deHasta";
            this.deHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Size = new System.Drawing.Size(100, 20);
            this.deHasta.TabIndex = 3;
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(55, 23);
            this.deDesde.Name = "deDesde";
            this.deDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Size = new System.Drawing.Size(100, 20);
            this.deDesde.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(15, 27);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(34, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Desde:";
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(227, 46);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(318, 20);
            this.txtDescCliente.TabIndex = 5;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(98, 46);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Properties.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroDocumento.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(204, 94);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Disponible S/: ";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(25, 121);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(64, 13);
            this.labelControl9.TabIndex = 15;
            this.labelControl9.Text = "Observación:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Importe S/: ";
            // 
            // txtImporteDisponible
            // 
            this.txtImporteDisponible.EditValue = "0.00";
            this.txtImporteDisponible.Location = new System.Drawing.Point(278, 91);
            this.txtImporteDisponible.Name = "txtImporteDisponible";
            this.txtImporteDisponible.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteDisponible.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtImporteDisponible.Properties.Appearance.Options.UseFont = true;
            this.txtImporteDisponible.Properties.Appearance.Options.UseForeColor = true;
            this.txtImporteDisponible.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteDisponible.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteDisponible.Properties.Mask.EditMask = "n2";
            this.txtImporteDisponible.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteDisponible.Properties.Mask.ShowPlaceHolders = false;
            this.txtImporteDisponible.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtImporteDisponible.Properties.ReadOnly = true;
            this.txtImporteDisponible.Size = new System.Drawing.Size(100, 20);
            this.txtImporteDisponible.TabIndex = 12;
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.EditValue = "0.00";
            this.txtImporteTotal.Location = new System.Drawing.Point(98, 91);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtImporteTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteTotal.Properties.Appearance.Options.UseBackColor = true;
            this.txtImporteTotal.Properties.Appearance.Options.UseFont = true;
            this.txtImporteTotal.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteTotal.Properties.Mask.EditMask = "n2";
            this.txtImporteTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteTotal.Properties.Mask.ShowPlaceHolders = false;
            this.txtImporteTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtImporteTotal.Size = new System.Drawing.Size(100, 20);
            this.txtImporteTotal.TabIndex = 10;
            this.txtImporteTotal.EditValueChanged += new System.EventHandler(this.txtImporteTotal_EditValueChanged);
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(444, 91);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(130, 20);
            this.cboSituacion.TabIndex = 14;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(391, 94);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Situación:";
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(98, 23);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(476, 20);
            this.cboTienda.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(25, 26);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Tienda:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(98, 69);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumero.Properties.Appearance.Options.UseFont = true;
            this.txtNumero.Properties.MaxLength = 8;
            this.txtNumero.Properties.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(225, 20);
            this.txtNumero.TabIndex = 8;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(98, 119);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(476, 64);
            this.txtObservacion.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(845, 193);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(764, 193);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManTarjetaRegaloEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 221);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManTarjetaRegaloEdit";
            this.Load += new System.EventHandler(this.frmManTarjetaRegaloEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDisponible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtImporteDisponible;
        public DevExpress.XtraEditors.TextEdit txtImporteTotal;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.SimpleButton btnNuevoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.Label label1;
    }
}