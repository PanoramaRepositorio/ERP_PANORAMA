namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegReciboPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegReciboPago));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnConsultarTodo = new DevExpress.XtraEditors.SimpleButton();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaHasta = new DevExpress.XtraEditors.LabelControl();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.cboCaja = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.gcReciboPago = new DevExpress.XtraGrid.GridControl();
            this.gvReciboPago = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReciboPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReciboPago)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1238, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnConsultarTodo);
            this.groupControl1.Controls.Add(this.cboTienda);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.lblFechaHasta);
            this.groupControl1.Controls.Add(this.lblAño);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.deFecha);
            this.groupControl1.Controls.Add(this.cboCaja);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1238, 55);
            this.groupControl1.TabIndex = 50;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // btnConsultarTodo
            // 
            this.btnConsultarTodo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarTodo.ImageOptions.Image")));
            this.btnConsultarTodo.Location = new System.Drawing.Point(1005, 29);
            this.btnConsultarTodo.Name = "btnConsultarTodo";
            this.btnConsultarTodo.Size = new System.Drawing.Size(112, 20);
            this.btnConsultarTodo.TabIndex = 52;
            this.btnConsultarTodo.Text = "&Todas las Cajas";
            this.btnConsultarTodo.Visible = false;
            this.btnConsultarTodo.Click += new System.EventHandler(this.btnConsultarTodo_Click);
            // 
            // cboTienda
            // 
            this.cboTienda.Enabled = false;
            this.cboTienda.Location = new System.Drawing.Point(347, 29);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(110, 20);
            this.cboTienda.TabIndex = 55;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(305, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 53;
            this.labelControl2.Text = "Tienda:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Enabled = false;
            this.cboEmpresa.Location = new System.Drawing.Point(69, 29);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(233, 20);
            this.cboEmpresa.TabIndex = 56;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(18, 32);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(45, 13);
            this.labelControl9.TabIndex = 54;
            this.labelControl9.Text = "Empresa:";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Location = new System.Drawing.Point(861, 32);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(32, 13);
            this.lblFechaHasta.TabIndex = 36;
            this.lblFechaHasta.Text = "Hasta:";
            this.lblFechaHasta.Visible = false;
            this.lblFechaHasta.Click += new System.EventHandler(this.lblFechaHasta_Click);
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(711, 32);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(36, 13);
            this.lblAño.TabIndex = 36;
            this.lblAño.Text = "Fecha: ";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(899, 29);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 35;
            this.deFechaHasta.Visible = false;
            this.deFechaHasta.EditValueChanged += new System.EventHandler(this.deFechaHasta_EditValueChanged);
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(757, 29);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 35;
            this.deFecha.EditValueChanged += new System.EventHandler(this.deFecha_EditValueChanged);
            // 
            // cboCaja
            // 
            this.cboCaja.Location = new System.Drawing.Point(503, 29);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaja.Properties.NullText = "";
            this.cboCaja.Size = new System.Drawing.Size(198, 20);
            this.cboCaja.TabIndex = 13;
            this.cboCaja.EditValueChanged += new System.EventHandler(this.cboCaja_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(471, 32);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(26, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Caja:";
            // 
            // gcReciboPago
            // 
            this.gcReciboPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReciboPago.Location = new System.Drawing.Point(0, 79);
            this.gcReciboPago.MainView = this.gvReciboPago;
            this.gcReciboPago.Name = "gcReciboPago";
            this.gcReciboPago.Size = new System.Drawing.Size(1238, 417);
            this.gcReciboPago.TabIndex = 51;
            this.gcReciboPago.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReciboPago});
            // 
            // gvReciboPago
            // 
            this.gvReciboPago.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn10,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gvReciboPago.GridControl = this.gcReciboPago;
            this.gvReciboPago.Name = "gvReciboPago";
            this.gvReciboPago.OptionsView.ColumnAutoWidth = false;
            this.gvReciboPago.OptionsView.ShowGroupPanel = false;
            this.gvReciboPago.DoubleClick += new System.EventHandler(this.gvReciboPago_DoubleClick);
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdPago";
            this.gridColumn25.FieldName = "IdPago";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdTipoDocumento";
            this.gridColumn2.FieldName = "IdTipoDocumento";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "CodTipoDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "N° Documento";
            this.gridColumn23.FieldName = "NumeroDocumento";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 3;
            this.gridColumn23.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Condición Pago";
            this.gridColumn10.FieldName = "DescCondicionPago";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Concepto";
            this.gridColumn3.FieldName = "Concepto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 300;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Moneda";
            this.gridColumn4.FieldName = "CodMoneda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            this.gridColumn4.Width = 51;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "T.C";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "TipoCambio";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Importe S/";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "ImporteSoles";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn6.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn6.Caption = "Importe US$";
            this.gridColumn6.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "ImporteDolares";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 11;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "N° Proyecto";
            this.gridColumn7.FieldName = "NumeroProyectoServicio";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "N° Pedido";
            this.gridColumn9.FieldName = "NumeroPedido";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Caja";
            this.gridColumn11.FieldName = "DescCaja";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdCaja";
            this.gridColumn12.FieldName = "IdCaja";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tienda";
            this.gridColumn13.FieldName = "DescTienda";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Fecha";
            this.gridColumn14.FieldName = "Fecha";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Cliente";
            this.gridColumn15.FieldName = "DescCliente";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            this.gridColumn15.Width = 150;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "gridColumn16";
            this.gridColumn16.FieldName = "CodigoGiftCard";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // frmRegReciboPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 496);
            this.Controls.Add(this.gcReciboPago);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegReciboPago";
            this.Text = "Recibo de Pago";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegReciboPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReciboPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReciboPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFecha;
        public DevExpress.XtraEditors.LookUpEdit cboCaja;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.GridControl gcReciboPago;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReciboPago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnConsultarTodo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.LabelControl lblFechaHasta;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}