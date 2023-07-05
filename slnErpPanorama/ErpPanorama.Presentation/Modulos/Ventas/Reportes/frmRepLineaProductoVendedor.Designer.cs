namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepLineaProductoVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepLineaProductoVendedor));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.grdDetalle = new DevExpress.XtraEditors.GroupControl();
            this.chkVendedor = new System.Windows.Forms.CheckBox();
            this.cboLinea = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.optDia = new System.Windows.Forms.RadioButton();
            this.optMes = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).BeginInit();
            this.grdDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.grdDetalle);
            this.grdDatos.Controls.Add(this.deFechaHasta);
            this.grdDatos.Controls.Add(this.groupControl1);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.deFechaDesde);
            this.grdDatos.Controls.Add(this.lblFecha);
            this.grdDatos.Controls.Add(this.btnVer);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(423, 280);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // grdDetalle
            // 
            this.grdDetalle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.grdDetalle.Controls.Add(this.chkVendedor);
            this.grdDetalle.Controls.Add(this.cboLinea);
            this.grdDetalle.Controls.Add(this.labelControl2);
            this.grdDetalle.Controls.Add(this.cboVendedor);
            this.grdDetalle.Location = new System.Drawing.Point(12, 76);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.Size = new System.Drawing.Size(401, 82);
            this.grdDetalle.TabIndex = 124;
            this.grdDetalle.Text = "Filtro";
            // 
            // chkVendedor
            // 
            this.chkVendedor.AutoSize = true;
            this.chkVendedor.Checked = true;
            this.chkVendedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendedor.Location = new System.Drawing.Point(8, 29);
            this.chkVendedor.Name = "chkVendedor";
            this.chkVendedor.Size = new System.Drawing.Size(55, 17);
            this.chkVendedor.TabIndex = 67;
            this.chkVendedor.Text = "Todos";
            this.chkVendedor.UseVisualStyleBackColor = true;
            this.chkVendedor.CheckedChanged += new System.EventHandler(this.chkVendedor_CheckedChanged);
            // 
            // cboLinea
            // 
            this.cboLinea.Location = new System.Drawing.Point(74, 49);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLinea.Properties.NullText = "";
            this.cboLinea.Size = new System.Drawing.Size(307, 20);
            this.cboLinea.TabIndex = 63;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 64;
            this.labelControl2.Text = "Linea: ";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Enabled = false;
            this.cboVendedor.Location = new System.Drawing.Point(74, 27);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboVendedor.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboVendedor.Properties.Appearance.Options.UseFont = true;
            this.cboVendedor.Properties.Appearance.Options.UseForeColor = true;
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(307, 20);
            this.cboVendedor.TabIndex = 66;
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(99, 50);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 3;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(338, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(99, 28);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 1;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(26, 31);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(240, 239);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 8;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.groupControl2.Controls.Add(this.radioButton1);
            this.groupControl2.Controls.Add(this.radioButton2);
            this.groupControl2.Controls.Add(this.radioButton4);
            this.groupControl2.Location = new System.Drawing.Point(208, 372);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(173, 127);
            this.groupControl2.TabIndex = 124;
            this.groupControl2.Text = "Ordenado por";
            this.groupControl2.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(9, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Vendedor";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(9, 70);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(55, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "Monto";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(9, 47);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(50, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Linea";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.groupControl1.Controls.Add(this.optDia);
            this.groupControl1.Controls.Add(this.optMes);
            this.groupControl1.Location = new System.Drawing.Point(12, 164);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(173, 76);
            this.groupControl1.TabIndex = 124;
            this.groupControl1.Text = "Reporte a mostrar por";
            // 
            // optDia
            // 
            this.optDia.AutoSize = true;
            this.optDia.Checked = true;
            this.optDia.Location = new System.Drawing.Point(14, 24);
            this.optDia.Name = "optDia";
            this.optDia.Size = new System.Drawing.Size(40, 17);
            this.optDia.TabIndex = 7;
            this.optDia.TabStop = true;
            this.optDia.Text = "Dia";
            this.optDia.UseVisualStyleBackColor = true;
            // 
            // optMes
            // 
            this.optMes.AutoSize = true;
            this.optMes.Location = new System.Drawing.Point(14, 47);
            this.optMes.Name = "optMes";
            this.optMes.Size = new System.Drawing.Size(44, 17);
            this.optMes.TabIndex = 5;
            this.optMes.Text = "Mes";
            this.optMes.UseVisualStyleBackColor = true;
            // 
            // frmRepLineaProductoVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 278);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepLineaProductoVendedor";
            this.Text = "Reporte Linea x Vendedor";
            this.Load += new System.EventHandler(this.frmRepLineaProductoVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).EndInit();
            this.grdDetalle.ResumeLayout(false);
            this.grdDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.RadioButton optDia;
        private System.Windows.Forms.RadioButton optMes;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.GroupControl grdDetalle;
        private System.Windows.Forms.CheckBox chkVendedor;
        public DevExpress.XtraEditors.LookUpEdit cboLinea;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton4;
    }
}