namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    partial class frmRegCabeceraDetalle
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
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvDocumentoVenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDocumentoVenta = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentoVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Total";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Total";
            this.gridColumn7.MinWidth = 23;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:#,0.00}")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Moneda";
            this.gridColumn6.FieldName = "CodMoneda";
            this.gridColumn6.MinWidth = 23;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 58;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Fecha";
            this.gridColumn13.FieldName = "Fecha";
            this.gridColumn13.MinWidth = 23;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 87;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Numero";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.MinWidth = 23;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 87;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Serie";
            this.gridColumn10.FieldName = "Serie";
            this.gridColumn10.MinWidth = 23;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 47;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Razón Social";
            this.gridColumn3.FieldName = "RazonSocial";
            this.gridColumn3.MinWidth = 23;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 233;
            // 
            // gvDocumentoVenta
            // 
            this.gvDocumentoVenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn4});
            this.gvDocumentoVenta.DetailHeight = 431;
            this.gvDocumentoVenta.GridControl = this.gcDocumentoVenta;
            this.gvDocumentoVenta.Name = "gvDocumentoVenta";
            this.gvDocumentoVenta.OptionsSelection.MultiSelect = true;
            this.gvDocumentoVenta.OptionsView.ColumnAutoWidth = false;
            this.gvDocumentoVenta.OptionsView.ShowFooter = true;
            this.gvDocumentoVenta.OptionsView.ShowGroupPanel = false;
            this.gvDocumentoVenta.DoubleClick += new System.EventHandler(this.gvDocumentoVenta_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Documento";
            this.gridColumn2.FieldName = "CodTipoDocumento";
            this.gridColumn2.MinWidth = 23;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 87;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TotalDetalle";
            this.gridColumn1.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "TotalDetalle";
            this.gridColumn1.MinWidth = 23;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDetalle", "{0:#,0.00}")});
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 87;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdDocumentoVenta";
            this.gridColumn4.FieldName = "IdDocumentoVenta";
            this.gridColumn4.MinWidth = 23;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Width = 87;
            // 
            // gcDocumentoVenta
            // 
            this.gcDocumentoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDocumentoVenta.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDocumentoVenta.Location = new System.Drawing.Point(3, 5);
            this.gcDocumentoVenta.MainView = this.gvDocumentoVenta;
            this.gcDocumentoVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcDocumentoVenta.Name = "gcDocumentoVenta";
            this.gcDocumentoVenta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo});
            this.gcDocumentoVenta.Size = new System.Drawing.Size(812, 403);
            this.gcDocumentoVenta.TabIndex = 69;
            this.gcDocumentoVenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocumentoVenta});
            // 
            // frmRegCabeceraDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 414);
            this.Controls.Add(this.gcDocumentoVenta);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegCabeceraDetalle";
            this.Text = "Consulta Diferencia Cabecera - Detalle";
            this.Load += new System.EventHandler(this.frmRegCabeceraDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentoVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumentoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gcDocumentoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}