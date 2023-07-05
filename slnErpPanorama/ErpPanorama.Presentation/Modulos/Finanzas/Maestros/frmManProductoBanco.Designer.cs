namespace ErpPanorama.Presentation.Modulos.Finanzas.Maestros
{
    partial class frmManProductoBanco
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcBancoProducto = new DevExpress.XtraGrid.GridControl();
            this.gvBancoProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcBancoProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBancoProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(908, 24);
            this.tlbMenu.TabIndex = 50;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tblMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcBancoProducto
            // 
            this.gcBancoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBancoProducto.Location = new System.Drawing.Point(0, 28);
            this.gcBancoProducto.MainView = this.gvBancoProducto;
            this.gcBancoProducto.Name = "gcBancoProducto";
            this.gcBancoProducto.Size = new System.Drawing.Size(905, 496);
            this.gcBancoProducto.TabIndex = 51;
            this.gcBancoProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBancoProducto});
            // 
            // gvBancoProducto
            // 
            this.gvBancoProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn13,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gvBancoProducto.GridControl = this.gcBancoProducto;
            this.gvBancoProducto.Name = "gvBancoProducto";
            this.gvBancoProducto.OptionsSelection.MultiSelect = true;
            this.gvBancoProducto.OptionsView.AllowCellMerge = true;
            this.gvBancoProducto.OptionsView.ColumnAutoWidth = false;
            this.gvBancoProducto.OptionsView.ShowFooter = true;
            this.gvBancoProducto.OptionsView.ShowGroupPanel = false;
            this.gvBancoProducto.OptionsView.ShowViewCaption = true;
            this.gvBancoProducto.ViewCaption = "Línea de Crédito";
            this.gvBancoProducto.DoubleClick += new System.EventHandler(this.gvBancoProducto_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdBancoProducto";
            this.gridColumn1.FieldName = "IdBancoProducto";
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
            this.gridColumn3.Caption = "IdBanco";
            this.gridColumn3.FieldName = "IdBanco";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Banco";
            this.gridColumn4.FieldName = "DescBanco";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 194;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdTipoProducto";
            this.gridColumn5.FieldName = "IdTipoProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tipo Producto";
            this.gridColumn6.FieldName = "DescTipoProducto";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 163;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Línea Crédito";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "LineaCredito";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LineaCredito", "{0:#,0.00}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 101;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Total Préstamo";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "Prestamo";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Prestamo", "{0:#,0.00}")});
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 90;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Saldo Préstamo";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "MontoUtilizado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoUtilizado", "{0:#,0.00}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 101;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Disponible";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Disponible";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Disponible", "{0:#,0.00}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "FlagEstado";
            this.gridColumn10.FieldName = "FlagEstado";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Moneda";
            this.gridColumn11.FieldName = "DescMoneda";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 110;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdMoneda";
            this.gridColumn12.FieldName = "IdMoneda";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // frmManProductoBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 536);
            this.Controls.Add(this.gcBancoProducto);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmManProductoBanco";
            this.Text = "Mantenimiento - Producto Banco";
            this.Load += new System.EventHandler(this.frmManProductoBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcBancoProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBancoProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcBancoProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBancoProducto;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}