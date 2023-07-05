namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManMetasEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManMetasEdit));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtImporteFinal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteMayorista = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtImporteDiseno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.txtImporte = new DevExpress.XtraEditors.TextEdit();
            this.cboCargo = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboMes = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteMayorista.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDiseno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupBox1);
            this.groupControl3.Controls.Add(this.txtPeriodo);
            this.groupControl3.Controls.Add(this.txtImporte);
            this.groupControl3.Controls.Add(this.cboCargo);
            this.groupControl3.Controls.Add(this.cboTienda);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.cboMes);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(413, 201);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Datos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtImporteFinal);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.txtImporteMayorista);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.txtImporteDiseno);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Location = new System.Drawing.Point(198, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 95);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Por Tipo Cliente";
            // 
            // txtImporteFinal
            // 
            this.txtImporteFinal.EditValue = "0.00";
            this.txtImporteFinal.Location = new System.Drawing.Point(86, 20);
            this.txtImporteFinal.Name = "txtImporteFinal";
            this.txtImporteFinal.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteFinal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteFinal.Properties.EditFormat.FormatString = "n2";
            this.txtImporteFinal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteFinal.Properties.Mask.EditMask = "n2";
            this.txtImporteFinal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteFinal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImporteFinal.Size = new System.Drawing.Size(100, 20);
            this.txtImporteFinal.TabIndex = 1;
            this.txtImporteFinal.EditValueChanged += new System.EventHandler(this.txtImporteFinal_EditValueChanged);
            this.txtImporteFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteFinal_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(40, 23);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "C. Final:";
            // 
            // txtImporteMayorista
            // 
            this.txtImporteMayorista.EditValue = "0.00";
            this.txtImporteMayorista.Location = new System.Drawing.Point(86, 42);
            this.txtImporteMayorista.Name = "txtImporteMayorista";
            this.txtImporteMayorista.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteMayorista.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteMayorista.Properties.EditFormat.FormatString = "n2";
            this.txtImporteMayorista.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteMayorista.Properties.Mask.EditMask = "n2";
            this.txtImporteMayorista.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteMayorista.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImporteMayorista.Size = new System.Drawing.Size(100, 20);
            this.txtImporteMayorista.TabIndex = 3;
            this.txtImporteMayorista.EditValueChanged += new System.EventHandler(this.txtImporteMayorista_EditValueChanged);
            this.txtImporteMayorista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteMayorista_KeyPress);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(30, 67);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(50, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "C. Diseño:";
            // 
            // txtImporteDiseno
            // 
            this.txtImporteDiseno.EditValue = "0.00";
            this.txtImporteDiseno.Location = new System.Drawing.Point(86, 64);
            this.txtImporteDiseno.Name = "txtImporteDiseno";
            this.txtImporteDiseno.Properties.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.txtImporteDiseno.Properties.Appearance.Options.UseForeColor = true;
            this.txtImporteDiseno.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporteDiseno.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteDiseno.Properties.EditFormat.FormatString = "n2";
            this.txtImporteDiseno.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporteDiseno.Properties.Mask.EditMask = "n2";
            this.txtImporteDiseno.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporteDiseno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImporteDiseno.Size = new System.Drawing.Size(100, 20);
            this.txtImporteDiseno.TabIndex = 5;
            this.txtImporteDiseno.EditValueChanged += new System.EventHandler(this.txtImporteDiseno_EditValueChanged);
            this.txtImporteDiseno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporteDiseno_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 45);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "C. Mayorista:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = "2015";
            this.txtPeriodo.Location = new System.Drawing.Point(92, 25);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(38, 20);
            this.txtPeriodo.TabIndex = 1;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // txtImporte
            // 
            this.txtImporte.EditValue = "0.00";
            this.txtImporte.Location = new System.Drawing.Point(92, 92);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtImporte.Properties.Appearance.Options.UseFont = true;
            this.txtImporte.Properties.DisplayFormat.FormatString = "n2";
            this.txtImporte.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporte.Properties.EditFormat.FormatString = "n2";
            this.txtImporte.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImporte.Properties.Mask.EditMask = "n";
            this.txtImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImporte.Size = new System.Drawing.Size(100, 20);
            this.txtImporte.TabIndex = 9;
            // 
            // cboCargo
            // 
            this.cboCargo.Location = new System.Drawing.Point(92, 69);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCargo.Properties.DropDownRows = 15;
            this.cboCargo.Properties.NullText = "";
            this.cboCargo.Size = new System.Drawing.Size(298, 20);
            this.cboCargo.TabIndex = 7;
            this.cboCargo.EditValueChanged += new System.EventHandler(this.cboCargo_EditValueChanged);
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(92, 47);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(298, 20);
            this.cboTienda.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Periodo:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tienda:";
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(178, 24);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.NullText = "";
            this.cboMes.Size = new System.Drawing.Size(212, 20);
            this.cboMes.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(149, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Mes:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 74);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Cargo:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 95);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Importe:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(322, 207);
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
            this.btnGrabar.Location = new System.Drawing.Point(241, 207);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManMetasEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 236);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManMetasEdit";
            this.Load += new System.EventHandler(this.frmManMetasEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteMayorista.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporteDiseno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        public DevExpress.XtraEditors.LookUpEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboCargo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtImporte;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtImporteFinal;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtImporteMayorista;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtImporteDiseno;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}