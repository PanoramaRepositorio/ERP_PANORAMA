namespace ErpPanorama.Presentation.Modulos.Maestros
{
    partial class frmManTipoCambioEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTipoCambioEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVentaSunat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCompraSunat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtVenta = new DevExpress.XtraEditors.TextEdit();
            this.txtCompra = new DevExpress.XtraEditors.TextEdit();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVentaSunat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompraSunat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(368, 173);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(273, 173);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.groupBox1);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtVenta);
            this.grdDatos.Controls.Add(this.txtCompra);
            this.grdDatos.Controls.Add(this.lblAño);
            this.grdDatos.Controls.Add(this.deFecha);
            this.grdDatos.Controls.Add(this.cboMoneda);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(485, 156);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVentaSunat);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.txtCompraSunat);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(223, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 82);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "T.C. SUNAT";
            // 
            // txtVentaSunat
            // 
            this.txtVentaSunat.EditValue = "0.00";
            this.txtVentaSunat.Location = new System.Drawing.Point(90, 51);
            this.txtVentaSunat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVentaSunat.Name = "txtVentaSunat";
            this.txtVentaSunat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentaSunat.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtVentaSunat.Properties.Appearance.Options.UseFont = true;
            this.txtVentaSunat.Properties.Appearance.Options.UseForeColor = true;
            this.txtVentaSunat.Properties.DisplayFormat.FormatString = "n3";
            this.txtVentaSunat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtVentaSunat.Properties.Mask.EditMask = "n3";
            this.txtVentaSunat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVentaSunat.Properties.Mask.ShowPlaceHolders = false;
            this.txtVentaSunat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtVentaSunat.Size = new System.Drawing.Size(117, 24);
            this.txtVentaSunat.TabIndex = 7;
            this.txtVentaSunat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVenta_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(15, 57);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 16);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Venta: ";
            // 
            // txtCompraSunat
            // 
            this.txtCompraSunat.EditValue = "0.00";
            this.txtCompraSunat.Location = new System.Drawing.Point(90, 25);
            this.txtCompraSunat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompraSunat.Name = "txtCompraSunat";
            this.txtCompraSunat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompraSunat.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtCompraSunat.Properties.Appearance.Options.UseFont = true;
            this.txtCompraSunat.Properties.Appearance.Options.UseForeColor = true;
            this.txtCompraSunat.Properties.DisplayFormat.FormatString = "n3";
            this.txtCompraSunat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCompraSunat.Properties.Mask.EditMask = "n3";
            this.txtCompraSunat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCompraSunat.Properties.Mask.ShowPlaceHolders = false;
            this.txtCompraSunat.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCompraSunat.Size = new System.Drawing.Size(117, 24);
            this.txtCompraSunat.TabIndex = 5;
            this.txtCompraSunat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompra_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(15, 29);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 16);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Compra: ";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 123);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Venta: ";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 95);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Compra: ";
            // 
            // txtVenta
            // 
            this.txtVenta.EditValue = "0.00";
            this.txtVenta.Location = new System.Drawing.Point(89, 117);
            this.txtVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Properties.Appearance.Options.UseFont = true;
            this.txtVenta.Properties.DisplayFormat.FormatString = "n2";
            this.txtVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtVenta.Properties.Mask.EditMask = "n2";
            this.txtVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVenta.Properties.Mask.ShowPlaceHolders = false;
            this.txtVenta.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtVenta.Size = new System.Drawing.Size(117, 24);
            this.txtVenta.TabIndex = 7;
            this.txtVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVenta_KeyPress);
            // 
            // txtCompra
            // 
            this.txtCompra.EditValue = "0.00";
            this.txtCompra.Location = new System.Drawing.Point(89, 91);
            this.txtCompra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompra.Properties.Appearance.Options.UseFont = true;
            this.txtCompra.Properties.DisplayFormat.FormatString = "n2";
            this.txtCompra.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCompra.Properties.Mask.EditMask = "n2";
            this.txtCompra.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCompra.Properties.Mask.ShowPlaceHolders = false;
            this.txtCompra.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCompra.Size = new System.Drawing.Size(117, 24);
            this.txtCompra.TabIndex = 5;
            this.txtCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompra_KeyPress);
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(14, 68);
            this.lblAño.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(43, 16);
            this.lblAño.TabIndex = 2;
            this.lblAño.Text = "Fecha: ";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(89, 64);
            this.deFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(117, 22);
            this.deFecha.TabIndex = 3;
            this.deFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFecha_KeyPress);
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(89, 37);
            this.cboMoneda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(366, 22);
            this.cboMoneda.TabIndex = 1;
            this.cboMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMoneda_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 41);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Moneda:";
            // 
            // frmManTipoCambioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 220);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManTipoCambioEdit";
            this.Load += new System.EventHandler(this.frmManTipoCambioEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVentaSunat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompraSunat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtVenta;
        public DevExpress.XtraEditors.TextEdit txtCompra;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFecha;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        public DevExpress.XtraEditors.TextEdit txtVentaSunat;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtCompraSunat;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}