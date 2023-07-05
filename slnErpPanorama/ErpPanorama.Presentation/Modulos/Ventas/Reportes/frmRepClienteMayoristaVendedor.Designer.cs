namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepClienteMayoristaVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepClienteMayoristaVendedor));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkVendedorTodos = new DevExpress.XtraEditors.CheckEdit();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.chkFormato2 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnInforme = new DevExpress.XtraEditors.SimpleButton();
            this.chkAsociado = new DevExpress.XtraEditors.CheckEdit();
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVendedorTodos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFormato2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAsociado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboSituacion);
            this.groupControl1.Controls.Add(this.labelControl34);
            this.groupControl1.Controls.Add(this.chkVendedorTodos);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.cboVendedor);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.chkFormato2);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Location = new System.Drawing.Point(-2, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(427, 147);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Datos";
            // 
            // chkVendedorTodos
            // 
            this.chkVendedorTodos.Location = new System.Drawing.Point(368, 30);
            this.chkVendedorTodos.Name = "chkVendedorTodos";
            this.chkVendedorTodos.Properties.Caption = "Todos";
            this.chkVendedorTodos.Size = new System.Drawing.Size(54, 19);
            this.chkVendedorTodos.TabIndex = 7;
            this.chkVendedorTodos.CheckedChanged += new System.EventHandler(this.chkVendedorTodos_CheckedChanged);
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Enabled = false;
            this.deFechaHasta.Location = new System.Drawing.Point(214, 81);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 53;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(173, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.TabIndex = 52;
            this.labelControl1.Text = "Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Enabled = false;
            this.deFechaDesde.Location = new System.Drawing.Point(67, 81);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 51;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(14, 84);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 50;
            this.lblFecha.Text = "Desde: ";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(67, 55);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 49;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(67, 29);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(295, 20);
            this.cboVendedor.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 58);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 48;
            this.labelControl7.Text = "Periodo:";
            // 
            // chkFormato2
            // 
            this.chkFormato2.Location = new System.Drawing.Point(166, 56);
            this.chkFormato2.Name = "chkFormato2";
            this.chkFormato2.Properties.Caption = "Formato 2";
            this.chkFormato2.Size = new System.Drawing.Size(75, 19);
            this.chkFormato2.TabIndex = 6;
            this.chkFormato2.CheckedChanged += new System.EventHandler(this.chkFormato2_CheckedChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(14, 32);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(50, 13);
            this.labelControl12.TabIndex = 12;
            this.labelControl12.Text = "Vendedor:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(337, 156);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnInforme.ImageIndex = 1;
            this.btnInforme.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(256, 156);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(75, 23);
            this.btnInforme.TabIndex = 4;
            this.btnInforme.Text = "Informe";
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // chkAsociado
            // 
            this.chkAsociado.Location = new System.Drawing.Point(7, 153);
            this.chkAsociado.Name = "chkAsociado";
            this.chkAsociado.Properties.Caption = "Asociado";
            this.chkAsociado.Size = new System.Drawing.Size(75, 19);
            this.chkAsociado.TabIndex = 6;
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(67, 107);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(247, 20);
            this.cboSituacion.TabIndex = 33;
            // 
            // labelControl34
            // 
            this.labelControl34.Location = new System.Drawing.Point(14, 110);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(47, 13);
            this.labelControl34.TabIndex = 32;
            this.labelControl34.Text = "Situación:";
            // 
            // frmRepClienteMayoristaVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 191);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnInforme);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.chkAsociado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepClienteMayoristaVendedor";
            this.Text = "Reporte Cliente Mayorista Vendedor";
            this.Load += new System.EventHandler(this.frmRepClienteMayoristaVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVendedorTodos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFormato2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAsociado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnInforme;
        private DevExpress.XtraEditors.CheckEdit chkAsociado;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckEdit chkFormato2;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkVendedorTodos;
        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.LabelControl labelControl34;
    }
}