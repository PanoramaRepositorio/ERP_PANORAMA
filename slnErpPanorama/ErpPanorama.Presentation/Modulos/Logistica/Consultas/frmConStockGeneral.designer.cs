namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    partial class frmConStockGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConStockGeneral));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleTransitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.lblTotalRegistros);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1938, 55);
            this.groupControl1.TabIndex = 49;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.go_back_32x32;
            this.simpleButton1.Location = new System.Drawing.Point(80, 24);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(73, 20);
            this.simpleButton1.TabIndex = 17;
            this.simpleButton1.Text = "Cerrar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(4, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(169, 27);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 4;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // gcProducto
            // 
            this.gcProducto.ContextMenuStrip = this.mnuContextual;
            this.gcProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gcProducto.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcProducto.Location = new System.Drawing.Point(0, 55);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(1938, 548);
            this.gcProducto.TabIndex = 50;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem,
            this.detalleTransitoToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(189, 48);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exportarToolStripMenuItem.Text = "Exportar a Excel";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // detalleTransitoToolStripMenuItem
            // 
            this.detalleTransitoToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultas_16x16;
            this.detalleTransitoToolStripMenuItem.Name = "detalleTransitoToolStripMenuItem";
            this.detalleTransitoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.detalleTransitoToolStripMenuItem.Text = "Detalle Stock_Transito";
            this.detalleTransitoToolStripMenuItem.Click += new System.EventHandler(this.detalleTransitoToolStripMenuItem_Click);
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn12,
            this.gridColumn22,
            this.gridColumn26,
            this.gridColumn37,
            this.gridColumn36,
            this.gridColumn35,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn20,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn27,
            this.gridColumn21,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn19,
            this.gridColumn40,
            this.gridColumn28});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsSelection.MultiSelect = true;
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            this.gvProducto.ColumnFilterChanged += new System.EventHandler(this.gvProducto_ColumnFilterChanged);
            this.gvProducto.DoubleClick += new System.EventHandler(this.gvProducto_DoubleClick);
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "HangTag";
            this.gridColumn25.FieldName = "IdProducto";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 1;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Año";
            this.gridColumn1.FieldName = "Periodo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 40;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Código";
            this.gridColumn23.FieldName = "CodigoProveedor";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 2;
            this.gridColumn23.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Nombre";
            this.gridColumn18.FieldName = "NombreProducto";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            this.gridColumn18.Width = 236;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "U.M";
            this.gridColumn10.FieldName = "Abreviatura";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "P. AB US$";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PrecioAB";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 60;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn6.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn6.Caption = "P. CD US$";
            this.gridColumn6.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "PrecioCD";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "P. AB S/";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "PrecioABSoles";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 60;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "P. CD S/";
            this.gridColumn2.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "PrecioCDSoles";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            this.gridColumn2.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Linea";
            this.gridColumn3.FieldName = "DescLineaProducto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 10;
            this.gridColumn3.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Sub Linea";
            this.gridColumn4.FieldName = "DescSubLineaProducto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 11;
            this.gridColumn4.Width = 130;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Proveedor";
            this.gridColumn33.FieldName = "DescProveedor";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 12;
            this.gridColumn33.Width = 148;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "P. Promedio US$";
            this.gridColumn34.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn34.FieldName = "PrecioPromedio";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 13;
            this.gridColumn34.Width = 64;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "F. Recepción";
            this.gridColumn12.FieldName = "Fecha";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 14;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Nacional";
            this.gridColumn22.FieldName = "FlagNacional";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 15;
            this.gridColumn22.Width = 51;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Compra Ult.";
            this.gridColumn26.FieldName = "CantidadCompra";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 16;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "A. Pendiente";
            this.gridColumn37.FieldName = "AlmacenPendiente";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 17;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "A. Muestras";
            this.gridColumn36.FieldName = "AlmacenMuestras";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 18;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "A. Marketing";
            this.gridColumn35.FieldName = "AlmacenMarketing";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 19;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "A. Central";
            this.gridColumn13.FieldName = "AlmacenCentral";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 24;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "A. Tda Uca";
            this.gridColumn14.FieldName = "AlmacenTienda";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 25;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "A. Tda Outlet";
            this.gridColumn15.FieldName = "AlmacenTdaOutlet";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 26;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "A. Andahuaylas";
            this.gridColumn16.FieldName = "AlmacenAndahuaylas";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 27;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "A. Prescott";
            this.gridColumn17.FieldName = "AlmacenPrescott";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 28;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "A. Aviación 2";
            this.gridColumn38.FieldName = "AlmacenAviacion2";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 29;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "A. San Miguel";
            this.gridColumn39.FieldName = "AlmacenSanMiguel";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.OptionsColumn.AllowFocus = false;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 30;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "A. MegaPlaza";
            this.gridColumn20.FieldName = "AlmacenMegaPlaza";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "A.Mermas";
            this.gridColumn7.FieldName = "AlmacenMermas";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 21;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "A.Reparacion";
            this.gridColumn9.FieldName = "AlmacenReparacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 22;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "A.Temporal";
            this.gridColumn11.FieldName = "AlmacenDiferencias";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 20;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "A. Outlet";
            this.gridColumn27.FieldName = "AlmacenOutlet";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 23;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn21.AppearanceCell.Options.UseFont = true;
            this.gridColumn21.Caption = "Stock Total";
            this.gridColumn21.FieldName = "TotalStock";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 33;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "IdLineaProducto";
            this.gridColumn29.FieldName = "IdLineaProducto";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "IdSubLineaProducto";
            this.gridColumn30.FieldName = "IdSubLineaProducto";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "IdModeloProducto";
            this.gridColumn31.FieldName = "IdModeloProducto";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "A. Transito NS";
            this.gridColumn19.FieldName = "AlmacenTransito_NS";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 31;
            this.gridColumn19.Width = 80;
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "A. Transito PED";
            this.gridColumn40.FieldName = "AlmacenTransito_PED";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.OptionsColumn.AllowFocus = false;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 32;
            this.gridColumn40.Width = 85;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Marca";
            this.gridColumn28.FieldName = "DescMarca";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 5;
            // 
            // frmConStockGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1938, 603);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmConStockGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock General";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConStockGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private System.Windows.Forms.ToolStripMenuItem detalleTransitoToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
    }
}