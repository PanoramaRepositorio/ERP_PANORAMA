namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepVentaProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepVentaProducto));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.cboLinea = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.chkTienda = new System.Windows.Forms.CheckBox();
            this.cboTipoCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.optRentabilidad = new System.Windows.Forms.RadioButton();
            this.optGrafico = new System.Windows.Forms.RadioButton();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.optDetalle = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(79, 31);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 3;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(79, 9);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 1;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(6, 12);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(295, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(197, 245);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 4;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // cboLinea
            // 
            this.cboLinea.Location = new System.Drawing.Point(85, 41);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLinea.Properties.NullText = "";
            this.cboLinea.Size = new System.Drawing.Size(266, 20);
            this.cboLinea.TabIndex = 58;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 59;
            this.labelControl2.Text = "Linea: ";
            // 
            // cboTienda
            // 
            this.cboTienda.Enabled = false;
            this.cboTienda.Location = new System.Drawing.Point(85, 19);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboTienda.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboTienda.Properties.Appearance.Options.UseFont = true;
            this.cboTienda.Properties.Appearance.Options.UseForeColor = true;
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(266, 20);
            this.cboTienda.TabIndex = 61;
            // 
            // chkTienda
            // 
            this.chkTienda.AutoSize = true;
            this.chkTienda.Checked = true;
            this.chkTienda.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTienda.Location = new System.Drawing.Point(21, 21);
            this.chkTienda.Name = "chkTienda";
            this.chkTienda.Size = new System.Drawing.Size(55, 17);
            this.chkTienda.TabIndex = 62;
            this.chkTienda.Text = "Todas";
            this.chkTienda.UseVisualStyleBackColor = true;
            this.chkTienda.CheckedChanged += new System.EventHandler(this.chkTienda_CheckedChanged);
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.Location = new System.Drawing.Point(85, 65);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCliente.Properties.NullText = "";
            this.cboTipoCliente.Size = new System.Drawing.Size(266, 20);
            this.cboTipoCliente.TabIndex = 65;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 64;
            this.labelControl3.Text = "Tipo Cliente:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.optRentabilidad);
            this.groupControl1.Controls.Add(this.optGrafico);
            this.groupControl1.Controls.Add(this.optResumen);
            this.groupControl1.Controls.Add(this.optDetalle);
            this.groupControl1.Location = new System.Drawing.Point(6, 172);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(364, 55);
            this.groupControl1.TabIndex = 66;
            this.groupControl1.Text = "Mostrar por";
            // 
            // optRentabilidad
            // 
            this.optRentabilidad.AutoSize = true;
            this.optRentabilidad.Location = new System.Drawing.Point(275, 23);
            this.optRentabilidad.Name = "optRentabilidad";
            this.optRentabilidad.Size = new System.Drawing.Size(84, 17);
            this.optRentabilidad.TabIndex = 0;
            this.optRentabilidad.Text = "Rentabilidad";
            this.optRentabilidad.UseVisualStyleBackColor = true;
            // 
            // optGrafico
            // 
            this.optGrafico.AutoSize = true;
            this.optGrafico.Location = new System.Drawing.Point(164, 23);
            this.optGrafico.Name = "optGrafico";
            this.optGrafico.Size = new System.Drawing.Size(101, 17);
            this.optGrafico.TabIndex = 0;
            this.optGrafico.Text = "Gráfico Mensual";
            this.optGrafico.UseVisualStyleBackColor = true;
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Location = new System.Drawing.Point(85, 23);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(69, 17);
            this.optResumen.TabIndex = 0;
            this.optResumen.Text = "Resumen";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // optDetalle
            // 
            this.optDetalle.AutoSize = true;
            this.optDetalle.Checked = true;
            this.optDetalle.Location = new System.Drawing.Point(17, 23);
            this.optDetalle.Name = "optDetalle";
            this.optDetalle.Size = new System.Drawing.Size(58, 17);
            this.optDetalle.TabIndex = 0;
            this.optDetalle.TabStop = true;
            this.optDetalle.Text = "Detalle";
            this.optDetalle.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTienda);
            this.groupBox1.Controls.Add(this.cboLinea);
            this.groupBox1.Controls.Add(this.cboTipoCliente);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.cboTienda);
            this.groupBox1.Location = new System.Drawing.Point(6, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 109);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            // 
            // frmRepVentaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 279);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepVentaProducto";
            this.Text = "Reporte de Ventas Por Producto";
            this.Load += new System.EventHandler(this.frmRepVentaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        public DevExpress.XtraEditors.LookUpEdit cboLinea;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private System.Windows.Forms.CheckBox chkTienda;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RadioButton optRentabilidad;
        private System.Windows.Forms.RadioButton optGrafico;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}