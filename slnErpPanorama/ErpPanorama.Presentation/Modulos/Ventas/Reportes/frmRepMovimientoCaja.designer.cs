namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepMovimientoCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepMovimientoCaja));
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.cboCaja = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.chkCaja = new System.Windows.Forms.CheckBox();
            this.chkFormato = new System.Windows.Forms.CheckBox();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.chkResumenDiferencia = new System.Windows.Forms.CheckBox();
            this.lblHasta = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.chkTodoTienda = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(76, 58);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 19;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(14, 61);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(36, 13);
            this.lblFecha.TabIndex = 18;
            this.lblFecha.Text = "Fecha: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(469, 100);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageOptions.ImageIndex = 1;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(371, 100);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 22;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // cboCaja
            // 
            this.cboCaja.Location = new System.Drawing.Point(362, 35);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaja.Properties.NullText = "";
            this.cboCaja.Size = new System.Drawing.Size(182, 20);
            this.cboCaja.TabIndex = 25;
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(76, 35);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(218, 20);
            this.cboTienda.TabIndex = 27;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // chkCaja
            // 
            this.chkCaja.AutoSize = true;
            this.chkCaja.Checked = true;
            this.chkCaja.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaja.Location = new System.Drawing.Point(310, 38);
            this.chkCaja.Name = "chkCaja";
            this.chkCaja.Size = new System.Drawing.Size(52, 17);
            this.chkCaja.TabIndex = 28;
            this.chkCaja.Text = "Caja:";
            this.chkCaja.UseVisualStyleBackColor = true;
            this.chkCaja.CheckedChanged += new System.EventHandler(this.chkCaja_CheckedChanged);
            // 
            // chkFormato
            // 
            this.chkFormato.AutoSize = true;
            this.chkFormato.Checked = true;
            this.chkFormato.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormato.Location = new System.Drawing.Point(310, 58);
            this.chkFormato.Name = "chkFormato";
            this.chkFormato.Size = new System.Drawing.Size(66, 17);
            this.chkFormato.TabIndex = 29;
            this.chkFormato.Text = "Formato";
            this.chkFormato.UseVisualStyleBackColor = true;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(76, 12);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(468, 20);
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(14, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Empresa:";
            // 
            // chkResumenDiferencia
            // 
            this.chkResumenDiferencia.AutoSize = true;
            this.chkResumenDiferencia.Location = new System.Drawing.Point(65, 106);
            this.chkResumenDiferencia.Name = "chkResumenDiferencia";
            this.chkResumenDiferencia.Size = new System.Drawing.Size(121, 17);
            this.chkResumenDiferencia.TabIndex = 29;
            this.chkResumenDiferencia.Text = "Resumen Diferencia";
            this.chkResumenDiferencia.UseVisualStyleBackColor = true;
            this.chkResumenDiferencia.CheckedChanged += new System.EventHandler(this.chkResumenDiferencia_CheckedChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.Location = new System.Drawing.Point(14, 83);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(32, 13);
            this.lblHasta.TabIndex = 18;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Visible = false;
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(76, 80);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 19;
            this.deFechaHasta.Visible = false;
            // 
            // chkTodoTienda
            // 
            this.chkTodoTienda.AutoSize = true;
            this.chkTodoTienda.Checked = true;
            this.chkTodoTienda.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodoTienda.Location = new System.Drawing.Point(12, 37);
            this.chkTodoTienda.Name = "chkTodoTienda";
            this.chkTodoTienda.Size = new System.Drawing.Size(62, 17);
            this.chkTodoTienda.TabIndex = 2;
            this.chkTodoTienda.Text = "Tienda:";
            this.chkTodoTienda.UseVisualStyleBackColor = true;
            this.chkTodoTienda.CheckedChanged += new System.EventHandler(this.chkTodoTienda_CheckedChanged);
            // 
            // frmRepMovimientoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 137);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.chkResumenDiferencia);
            this.Controls.Add(this.chkFormato);
            this.Controls.Add(this.chkCaja);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.cboCaja);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.deFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.chkTodoTienda);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepMovimientoCaja";
            this.Text = "Reporte - Movimiento Caja";
            this.Load += new System.EventHandler(this.frmRepMovimientoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        public DevExpress.XtraEditors.LookUpEdit cboCaja;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private System.Windows.Forms.CheckBox chkCaja;
        private System.Windows.Forms.CheckBox chkFormato;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.CheckBox chkResumenDiferencia;
        private DevExpress.XtraEditors.LabelControl lblHasta;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private System.Windows.Forms.CheckBox chkTodoTienda;
    }
}