namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepRotacionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepRotacionProductos));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.chkTiendaTodo = new System.Windows.Forms.CheckBox();
            this.chkResumen = new System.Windows.Forms.CheckBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.optMenor = new System.Windows.Forms.RadioButton();
            this.optMayor = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(87, 78);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 9;
            this.deFechaHasta.EditValueChanged += new System.EventHandler(this.deFechaHasta_EditValueChanged);
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Fecha Hasta: ";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(87, 56);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 7;
            this.deFechaDesde.EditValueChanged += new System.EventHandler(this.deFechaDesde_EditValueChanged);
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(14, 59);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha Desde: ";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(218, 139);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageOptions.ImageIndex = 1;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(120, 139);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 10;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // cboTienda
            // 
            this.cboTienda.Enabled = false;
            this.cboTienda.Location = new System.Drawing.Point(87, 101);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboTienda.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboTienda.Properties.Appearance.Options.UseFont = true;
            this.cboTienda.Properties.Appearance.Options.UseForeColor = true;
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(206, 20);
            this.cboTienda.TabIndex = 68;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // chkTiendaTodo
            // 
            this.chkTiendaTodo.AutoSize = true;
            this.chkTiendaTodo.Checked = true;
            this.chkTiendaTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTiendaTodo.Location = new System.Drawing.Point(14, 104);
            this.chkTiendaTodo.Name = "chkTiendaTodo";
            this.chkTiendaTodo.Size = new System.Drawing.Size(55, 17);
            this.chkTiendaTodo.TabIndex = 69;
            this.chkTiendaTodo.Text = "Todas";
            this.chkTiendaTodo.UseVisualStyleBackColor = true;
            this.chkTiendaTodo.CheckedChanged += new System.EventHandler(this.chkTiendaTodo_CheckedChanged);
            // 
            // chkResumen
            // 
            this.chkResumen.AutoSize = true;
            this.chkResumen.Location = new System.Drawing.Point(14, 143);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Size = new System.Drawing.Size(70, 17);
            this.chkResumen.TabIndex = 69;
            this.chkResumen.Text = "Resumen";
            this.chkResumen.UseVisualStyleBackColor = true;
            this.chkResumen.CheckedChanged += new System.EventHandler(this.chkResumen_CheckedChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.optMenor);
            this.groupControl1.Controls.Add(this.optMayor);
            this.groupControl1.Location = new System.Drawing.Point(14, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(281, 46);
            this.groupControl1.TabIndex = 70;
            this.groupControl1.Text = "Tipo de reporte";
            // 
            // optMenor
            // 
            this.optMenor.AutoSize = true;
            this.optMenor.Location = new System.Drawing.Point(151, 23);
            this.optMenor.Name = "optMenor";
            this.optMenor.Size = new System.Drawing.Size(84, 17);
            this.optMenor.TabIndex = 0;
            this.optMenor.Text = "Sin Rotación";
            this.optMenor.UseVisualStyleBackColor = true;
            this.optMenor.CheckedChanged += new System.EventHandler(this.optMenor_CheckedChanged);
            // 
            // optMayor
            // 
            this.optMayor.AutoSize = true;
            this.optMayor.Checked = true;
            this.optMayor.Location = new System.Drawing.Point(26, 23);
            this.optMayor.Name = "optMayor";
            this.optMayor.Size = new System.Drawing.Size(100, 17);
            this.optMayor.TabIndex = 0;
            this.optMayor.TabStop = true;
            this.optMayor.Text = "Mayor Rotación";
            this.optMayor.UseVisualStyleBackColor = true;
            // 
            // frmRepRotacionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 173);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.chkResumen);
            this.Controls.Add(this.chkTiendaTodo);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepRotacionProductos";
            this.Text = "Mayor Rotación de Productos";
            this.Load += new System.EventHandler(this.frmRepRotacionProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
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
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private System.Windows.Forms.CheckBox chkTiendaTodo;
        private System.Windows.Forms.CheckBox chkResumen;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RadioButton optMenor;
        private System.Windows.Forms.RadioButton optMayor;
    }
}