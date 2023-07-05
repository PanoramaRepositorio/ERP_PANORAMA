namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmMovimientoCajaVuelto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientoCajaVuelto));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.cboCaja = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteDolares = new DevExpress.XtraEditors.TextEdit();
            this.txtImporteSoles = new DevExpress.XtraEditors.TextEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDolares.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteSoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(419, 157);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(338, 157);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 36;
            this.btnGrabar.Text = "Grabar";
            // 
            // cboTienda
            // 
            this.cboTienda.Enabled = false;
            this.cboTienda.Location = new System.Drawing.Point(82, 21);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(110, 20);
            this.cboTienda.TabIndex = 58;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 57;
            this.labelControl2.Text = "Tienda:";
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(348, 24);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(36, 13);
            this.lblAño.TabIndex = 56;
            this.lblAño.Text = "Fecha: ";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(390, 21);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 55;
            // 
            // cboCaja
            // 
            this.cboCaja.Enabled = false;
            this.cboCaja.Location = new System.Drawing.Point(230, 21);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaja.Properties.DropDownRows = 10;
            this.cboCaja.Properties.NullText = "";
            this.cboCaja.Size = new System.Drawing.Size(112, 20);
            this.cboCaja.TabIndex = 54;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(198, 24);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(26, 13);
            this.labelControl6.TabIndex = 53;
            this.labelControl6.Text = "Caja:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(213, 66);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 65;
            this.labelControl1.Text = "Importe US$: ";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 66);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 63;
            this.labelControl8.Text = "Importe S/: ";
            // 
            // txtImporteDolares
            // 
            this.txtImporteDolares.EditValue = "0.00";
            this.txtImporteDolares.Location = new System.Drawing.Point(286, 63);
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
            this.txtImporteDolares.TabIndex = 66;
            // 
            // txtImporteSoles
            // 
            this.txtImporteSoles.EditValue = "0.00";
            this.txtImporteSoles.Location = new System.Drawing.Point(82, 63);
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
            this.txtImporteSoles.TabIndex = 64;
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(82, 42);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(172, 20);
            this.cboMoneda.TabIndex = 60;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 45);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 59;
            this.labelControl5.Text = "Moneda:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(260, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 13);
            this.labelControl3.TabIndex = 61;
            this.labelControl3.Text = "TC: ";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.EditValue = "0.00";
            this.txtTipoCambio.Location = new System.Drawing.Point(286, 42);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCambio.Properties.DisplayFormat.FormatString = "n2";
            this.txtTipoCambio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTipoCambio.Properties.Mask.EditMask = "n2";
            this.txtTipoCambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoCambio.Properties.Mask.ShowPlaceHolders = false;
            this.txtTipoCambio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(56, 20);
            this.txtTipoCambio.TabIndex = 62;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(82, 86);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(408, 61);
            this.txtObservacion.TabIndex = 67;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 88);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 13);
            this.labelControl4.TabIndex = 63;
            this.labelControl4.Text = "Observación:";
            // 
            // frmMovimientoCajaVuelto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 192);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtImporteDolares);
            this.Controls.Add(this.txtImporteSoles);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtTipoCambio);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblAño);
            this.Controls.Add(this.deFecha);
            this.Controls.Add(this.cboCaja);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtObservacion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMovimientoCajaVuelto";
            this.Text = "Movimiento Caja Vuelto";
            this.Load += new System.EventHandler(this.frmMovimientoCajaVuelto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDolares.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteSoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFecha;
        public DevExpress.XtraEditors.LookUpEdit cboCaja;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtImporteDolares;
        public DevExpress.XtraEditors.TextEdit txtImporteSoles;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtTipoCambio;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}