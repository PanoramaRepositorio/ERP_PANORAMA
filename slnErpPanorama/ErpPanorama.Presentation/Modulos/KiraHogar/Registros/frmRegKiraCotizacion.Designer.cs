
namespace ErpPanorama.Presentation.Modulos.KiraHogar.Registros
{
    partial class frmRegKiraCotizacion
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCotizaciones = new DevExpress.XtraGrid.GridControl();
            this.gvCotizacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCotizacionesProducto = new DevExpress.XtraGrid.GridControl();
            this.gvCotizacionProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblTotalRegistrosProductos = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroProducto = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodoProducto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCotizaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCotizacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCotizacionesProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCotizacionProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodoProducto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1554, 20);
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
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.lblTotalRegistros);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 20);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1554, 53);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Criterios de Búsqueda Precio Producto Cliente Stock";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(961, 29);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRegistros.TabIndex = 59;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(163, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "N° Cotizacion :";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(256, 26);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Size = new System.Drawing.Size(106, 20);
            this.txtNumero.TabIndex = 48;
            this.txtNumero.EditValueChanged += new System.EventHandler(this.txtNumero_EditValueChanged);
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(57, 26);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 47;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 29);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 46;
            this.labelControl7.Text = "Periodo:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Fecha de Registro";
            this.gridColumn26.FieldName = "Fecha";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 10;
            this.gridColumn26.Width = 170;
            // 
            // gcCotizaciones
            // 
            this.gcCotizaciones.Location = new System.Drawing.Point(0, 72);
            this.gcCotizaciones.MainView = this.gvCotizacion;
            this.gcCotizaciones.Name = "gcCotizaciones";
            this.gcCotizaciones.Size = new System.Drawing.Size(1597, 337);
            this.gcCotizaciones.TabIndex = 26;
            this.gcCotizaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCotizacion});
            // 
            // gvCotizacion
            // 
            this.gvCotizacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn13,
            this.gridColumn25,
            this.gridColumn5});
            this.gvCotizacion.GridControl = this.gcCotizaciones;
            this.gvCotizacion.GroupPanelText = "Resultado de la Busqueda";
            this.gvCotizacion.Name = "gvCotizacion";
            this.gvCotizacion.OptionsSelection.MultiSelect = true;
            this.gvCotizacion.OptionsView.ColumnAutoWidth = false;
            this.gvCotizacion.OptionsView.ShowGroupPanel = false;
            this.gvCotizacion.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvCotizacion_CustomDrawCell_1);
            this.gvCotizacion.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvCotizacion_PopupMenuShowing);
            this.gvCotizacion.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCotizacion_FocusedRowChanged);
            this.gvCotizacion.DoubleClick += new System.EventHandler(this.gvCotizacion_DoubleClick);
            this.gvCotizacion.LostFocus += new System.EventHandler(this.gvCotizacion_LostFocus);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Codigo Producto";
            this.gridColumn12.FieldName = "CodigoProducto";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            this.gridColumn12.Width = 115;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Nombre";
            this.gridColumn6.FieldName = "Descripcion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 214;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Materiales";
            this.gridColumn2.FieldName = "CostoMateriales";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 72;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Insumos";
            this.gridColumn3.FieldName = "CostoInsumos";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Accesorios";
            this.gridColumn1.FieldName = "CostoAccesorios";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 86;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mano de Obra";
            this.gridColumn4.FieldName = "CostoManoObra";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 97;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Movilidad y Viaticos";
            this.gridColumn8.FieldName = "CostoMovilidad";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 114;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Equipo y Herramientas";
            this.gridColumn9.FieldName = "CostoEquipos";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 123;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Costo Gastos Total";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "TotalGastos";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 139;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Precio de Venta Final";
            this.gridColumn7.FieldName = "PrecioVenta";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 140;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Fecha de Registro";
            this.gridColumn13.FieldName = "Fecha";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 95;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "TIPO";
            this.gridColumn25.FieldName = "DescTablaElemento";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 12;
            this.gridColumn25.Width = 225;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Cotizacion";
            this.gridColumn5.FieldName = "IdCotizacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 76;
            // 
            // gcCotizacionesProducto
            // 
            this.gcCotizacionesProducto.Location = new System.Drawing.Point(0, 467);
            this.gcCotizacionesProducto.MainView = this.gvCotizacionProducto;
            this.gcCotizacionesProducto.Name = "gcCotizacionesProducto";
            this.gcCotizacionesProducto.Size = new System.Drawing.Size(1191, 381);
            this.gcCotizacionesProducto.TabIndex = 27;
            this.gcCotizacionesProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCotizacionProducto});
            // 
            // gvCotizacionProducto
            // 
            this.gvCotizacionProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn27});
            this.gvCotizacionProducto.GridControl = this.gcCotizacionesProducto;
            this.gvCotizacionProducto.GroupPanelText = "Resultado de la Busqueda";
            this.gvCotizacionProducto.Name = "gvCotizacionProducto";
            this.gvCotizacionProducto.OptionsSelection.MultiSelect = true;
            this.gvCotizacionProducto.OptionsView.ColumnAutoWidth = false;
            this.gvCotizacionProducto.OptionsView.ShowGroupPanel = false;
            this.gvCotizacionProducto.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCotizacionProducto_FocusedRowChanged);
            this.gvCotizacionProducto.DoubleClick += new System.EventHandler(this.gvCotizacionProducto_DoubleClick);
            this.gvCotizacionProducto.LostFocus += new System.EventHandler(this.gvCotizacionProducto_LostFocus);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Codigo Producto";
            this.gridColumn10.FieldName = "CodigoProducto";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 115;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Nombre";
            this.gridColumn14.FieldName = "Descripcion";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 214;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "CostoProductos";
            this.gridColumn15.FieldName = "CostoProductos";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 103;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Insumos";
            this.gridColumn16.FieldName = "CostoInsumos";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Accesorios";
            this.gridColumn17.FieldName = "CostoAccesorios";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Width = 86;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Mano de Obra";
            this.gridColumn18.FieldName = "CostoManoObra";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Width = 97;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Movilidad y Viaticos";
            this.gridColumn19.FieldName = "CostoMovilidad";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Width = 114;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Equipo y Herramientas";
            this.gridColumn20.FieldName = "CostoEquipos";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.Width = 123;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Costo Gastos Total";
            this.gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn21.FieldName = "TotalGastos";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 4;
            this.gridColumn21.Width = 139;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Precio de Venta Final";
            this.gridColumn22.FieldName = "PrecioVenta";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 5;
            this.gridColumn22.Width = 140;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Fecha de Registro";
            this.gridColumn23.FieldName = "Fecha";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 6;
            this.gridColumn23.Width = 95;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "TIPO";
            this.gridColumn24.FieldName = "DescTablaElemento";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 7;
            this.gridColumn24.Width = 258;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "N° Cotizacion";
            this.gridColumn27.FieldName = "IdCotizacion";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 0;
            this.gridColumn27.Width = 76;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.lblTotalRegistrosProductos);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.txtNumeroProducto);
            this.groupControl2.Controls.Add(this.txtPeriodoProducto);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Location = new System.Drawing.Point(0, 415);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1595, 52);
            this.groupControl2.TabIndex = 28;
            this.groupControl2.Text = "Criterios de Búsqueda Precio Producto Terminado";
            // 
            // lblTotalRegistrosProductos
            // 
            this.lblTotalRegistrosProductos.Location = new System.Drawing.Point(961, 29);
            this.lblTotalRegistrosProductos.Name = "lblTotalRegistrosProductos";
            this.lblTotalRegistrosProductos.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRegistrosProductos.TabIndex = 59;
            this.lblTotalRegistrosProductos.Text = "0 Registros encontrados";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(163, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 49;
            this.labelControl3.Text = "N° Cotizacion :";
            // 
            // txtNumeroProducto
            // 
            this.txtNumeroProducto.Location = new System.Drawing.Point(256, 26);
            this.txtNumeroProducto.Name = "txtNumeroProducto";
            this.txtNumeroProducto.Properties.MaxLength = 6;
            this.txtNumeroProducto.Size = new System.Drawing.Size(106, 20);
            this.txtNumeroProducto.TabIndex = 48;
            this.txtNumeroProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroProducto_KeyDown);
            // 
            // txtPeriodoProducto
            // 
            this.txtPeriodoProducto.Location = new System.Drawing.Point(57, 26);
            this.txtPeriodoProducto.Name = "txtPeriodoProducto";
            this.txtPeriodoProducto.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodoProducto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodoProducto.Properties.Mask.EditMask = "f0";
            this.txtPeriodoProducto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodoProducto.Properties.MaxLength = 4;
            this.txtPeriodoProducto.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodoProducto.TabIndex = 47;
            this.txtPeriodoProducto.ToolTip = "Periodo";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 29);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 46;
            this.labelControl4.Text = "Periodo:";
            // 
            // frmRegKiraCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 852);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.gcCotizacionesProducto);
            this.Controls.Add(this.gcCotizaciones);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegKiraCotizacion";
            this.Text = "Consulta Cotizaciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegKiraCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCotizaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCotizacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCotizacionesProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCotizacionProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodoProducto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.GridControl gcCotizaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCotizacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl gcCotizacionesProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCotizacionProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistrosProductos;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNumeroProducto;
        public DevExpress.XtraEditors.TextEdit txtPeriodoProducto;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}