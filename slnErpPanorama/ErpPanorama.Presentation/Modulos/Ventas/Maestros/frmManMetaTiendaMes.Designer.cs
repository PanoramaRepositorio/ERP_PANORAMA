namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManMetaTiendaMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManMetaTiendaMes));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.gcMetaTiendaMes = new DevExpress.XtraGrid.GridControl();
            this.gvMetaTiendaMes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcMetaTiendaMes2 = new DevExpress.XtraGrid.GridControl();
            this.gvMetaTiendaMes2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMetaTiendaMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMetaTiendaMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMetaTiendaMes2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMetaTiendaMes2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(72, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(454, 20);
            this.txtDescripcion.TabIndex = 49;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // gcMetaTiendaMes
            // 
            this.gcMetaTiendaMes.Location = new System.Drawing.Point(200, 553);
            this.gcMetaTiendaMes.MainView = this.gvMetaTiendaMes;
            this.gcMetaTiendaMes.Name = "gcMetaTiendaMes";
            this.gcMetaTiendaMes.Size = new System.Drawing.Size(848, 71);
            this.gcMetaTiendaMes.TabIndex = 51;
            this.gcMetaTiendaMes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMetaTiendaMes});
            this.gcMetaTiendaMes.Visible = false;
            // 
            // gvMetaTiendaMes
            // 
            this.gvMetaTiendaMes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvMetaTiendaMes.GridControl = this.gcMetaTiendaMes;
            this.gvMetaTiendaMes.Name = "gvMetaTiendaMes";
            this.gvMetaTiendaMes.OptionsView.ColumnAutoWidth = false;
            this.gvMetaTiendaMes.OptionsView.ShowGroupPanel = false;
            this.gvMetaTiendaMes.DoubleClick += new System.EventHandler(this.gvMetaTiendaMes_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdMetaTiendaMes";
            this.gridColumn1.FieldName = "IdMetaTiendaMes";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdTienda";
            this.gridColumn3.FieldName = "IdTienda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tienda";
            this.gridColumn4.FieldName = "DescTienda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 137;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdTipoCliente";
            this.gridColumn5.FieldName = "IdTipoCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tipo Cliente";
            this.gridColumn6.FieldName = "DescTipoCliente";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 159;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Periodo";
            this.gridColumn7.FieldName = "Periodo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Mes";
            this.gridColumn8.FieldName = "Mes";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Mes";
            this.gridColumn9.FieldName = "NombreMes";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 105;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Importe";
            this.gridColumn10.FieldName = "Importe";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Estado";
            this.gridColumn11.FieldName = "FlagEstado";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(532, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1212, 24);
            this.tlbMenu.TabIndex = 47;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcMetaTiendaMes2
            // 
            this.gcMetaTiendaMes2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcMetaTiendaMes2.Location = new System.Drawing.Point(0, 56);
            this.gcMetaTiendaMes2.MainView = this.gvMetaTiendaMes2;
            this.gcMetaTiendaMes2.Name = "gcMetaTiendaMes2";
            this.gcMetaTiendaMes2.Size = new System.Drawing.Size(1212, 434);
            this.gcMetaTiendaMes2.TabIndex = 68;
            this.gcMetaTiendaMes2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMetaTiendaMes2});
            // 
            // gvMetaTiendaMes2
            // 
            this.gvMetaTiendaMes2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
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
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn12});
            this.gvMetaTiendaMes2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvMetaTiendaMes2.GridControl = this.gcMetaTiendaMes2;
            this.gvMetaTiendaMes2.Name = "gvMetaTiendaMes2";
            this.gvMetaTiendaMes2.OptionsView.ColumnAutoWidth = false;
            this.gvMetaTiendaMes2.OptionsView.ShowGroupPanel = false;
            this.gvMetaTiendaMes2.DoubleClick += new System.EventHandler(this.gvMetaTiendaMes2_DoubleClick);
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Enero";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "Enero";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 70;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Febrero";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "Febrero";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 70;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Marzo";
            this.gridColumn15.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "Marzo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 70;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Abril";
            this.gridColumn16.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "Abril";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 6;
            this.gridColumn16.Width = 70;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Mayo";
            this.gridColumn17.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "Mayo";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 7;
            this.gridColumn17.Width = 70;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Junio";
            this.gridColumn18.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "Junio";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 8;
            this.gridColumn18.Width = 70;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Julio";
            this.gridColumn19.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "Julio";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 9;
            this.gridColumn19.Width = 70;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Agosto";
            this.gridColumn20.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn20.FieldName = "Agosto";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 10;
            this.gridColumn20.Width = 70;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Setiembre";
            this.gridColumn21.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn21.FieldName = "Setiembre";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 11;
            this.gridColumn21.Width = 70;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Octubre";
            this.gridColumn22.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "Octubre";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 12;
            this.gridColumn22.Width = 70;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Noviembre";
            this.gridColumn23.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn23.FieldName = "Noviembre";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 13;
            this.gridColumn23.Width = 70;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Diciembre";
            this.gridColumn24.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn24.FieldName = "Diciembre";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 14;
            this.gridColumn24.Width = 70;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdTienda";
            this.gridColumn25.FieldName = "IdTienda";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Tienda";
            this.gridColumn26.FieldName = "DescTienda";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 0;
            this.gridColumn26.Width = 128;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "IdTipoCliente";
            this.gridColumn27.FieldName = "IdTipoCliente";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Tipo Cliente";
            this.gridColumn28.FieldName = "DescTipoCliente";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            this.gridColumn28.Width = 121;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Periodo";
            this.gridColumn12.FieldName = "Periodo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            // 
            // frmManMetaTiendaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 492);
            this.Controls.Add(this.gcMetaTiendaMes2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.gcMetaTiendaMes);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManMetaTiendaMes";
            this.Text = "Mantenimiento - Meta Tienda Mes";
            this.Load += new System.EventHandler(this.frmManMetaTiendaMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMetaTiendaMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMetaTiendaMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMetaTiendaMes2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMetaTiendaMes2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraGrid.GridControl gcMetaTiendaMes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMetaTiendaMes;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.GridControl gcMetaTiendaMes2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMetaTiendaMes2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}