namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepVentasDiarias
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepVentasDiarias));
            this.gcReporte = new DevExpress.XtraGrid.GridControl();
            this.gvReporte = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboTipoOperacion = new DevExpress.XtraEditors.LookUpEdit();
            this.chkResumen = new System.Windows.Forms.CheckBox();
            this.cboTipoReporte = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.button1 = new System.Windows.Forms.Button();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReporte)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoOperacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcReporte
            // 
            this.gcReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcReporte.Location = new System.Drawing.Point(0, 75);
            this.gcReporte.MainView = this.gvReporte;
            this.gcReporte.Name = "gcReporte";
            this.gcReporte.Size = new System.Drawing.Size(1279, 630);
            this.gcReporte.TabIndex = 2;
            this.gcReporte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReporte});
            // 
            // gvReporte
            // 
            this.gvReporte.GridControl = this.gcReporte;
            this.gvReporte.Name = "gvReporte";
            this.gvReporte.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvReporte.OptionsView.ShowViewCaption = true;
            this.gvReporte.ViewCaption = "Reporte";
            this.gvReporte.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvReporte_RowCellStyle);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpExcel,
            this.toolStripSeparator3,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1279, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpExcel
            // 
            this.toolstpExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExcel.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.toolstpExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExcel.Name = "toolstpExcel";
            this.toolstpExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExcel.ToolTipText = "Exportar Excel";
            this.toolstpExcel.Click += new System.EventHandler(this.toolstpExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(23, 22);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.button1);
            this.groupControl1.Controls.Add(this.cboTipoOperacion);
            this.groupControl1.Controls.Add(this.chkResumen);
            this.groupControl1.Controls.Add(this.cboTipoReporte);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cboTienda);
            this.groupControl1.Controls.Add(this.cboMes);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1279, 48);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // cboTipoOperacion
            // 
            this.cboTipoOperacion.Location = new System.Drawing.Point(1047, 23);
            this.cboTipoOperacion.Name = "cboTipoOperacion";
            this.cboTipoOperacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoOperacion.Properties.DropDownRows = 9;
            this.cboTipoOperacion.Properties.NullText = "";
            this.cboTipoOperacion.Size = new System.Drawing.Size(154, 20);
            this.cboTipoOperacion.TabIndex = 11;
            this.cboTipoOperacion.Visible = false;
            // 
            // chkResumen
            // 
            this.chkResumen.AutoSize = true;
            this.chkResumen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkResumen.ForeColor = System.Drawing.Color.Black;
            this.chkResumen.Location = new System.Drawing.Point(885, 30);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Size = new System.Drawing.Size(131, 17);
            this.chkResumen.TabIndex = 0;
            this.chkResumen.Text = "Resumen Semanal";
            this.chkResumen.Visible = false;
            this.chkResumen.CheckedChanged += new System.EventHandler(this.chkResumen_CheckedChanged);
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.Location = new System.Drawing.Point(473, 23);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoReporte.Properties.NullText = "";
            this.cboTipoReporte.Size = new System.Drawing.Size(129, 20);
            this.cboTipoReporte.TabIndex = 1;
            this.cboTipoReporte.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(1142, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Reporte:";
            this.labelControl3.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(608, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Tienda:";
            this.labelControl1.Visible = false;
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(650, 26);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.DropDownRows = 9;
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(154, 20);
            this.cboTienda.TabIndex = 7;
            this.cboTienda.Visible = false;
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(147, 24);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.DropDownRows = 12;
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 5;
            this.cboMes.SelectedValueChanged += new System.EventHandler(this.cboMes_SelectedValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(120, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Mes:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 28);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Periodo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(52, 24);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(54, 20);
            this.txtPeriodo.TabIndex = 3;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(261, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(76, 21);
            this.btnConsultar.TabIndex = 9;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmRepVentasDiarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 705);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gcReporte);
            this.Name = "frmRepVentasDiarias";
            this.Text = "Reporte Ventas Dia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepVentasDiarias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReporte)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoOperacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcReporte;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReporte;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboTipoReporte;
        private System.Windows.Forms.CheckBox chkResumen;
        public DevExpress.XtraEditors.LookUpEdit cboTipoOperacion;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private System.Windows.Forms.Timer timer1;
    }
}