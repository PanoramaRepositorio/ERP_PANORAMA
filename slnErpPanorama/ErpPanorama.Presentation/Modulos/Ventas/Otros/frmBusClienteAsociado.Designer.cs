namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusClienteAsociado
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
            this.gcClienteAsociado = new DevExpress.XtraGrid.GridControl();
            this.gvClienteAsociado = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtAbrevDocumento = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAsociado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAsociado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtAbrevDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // gcClienteAsociado
            // 
            this.gcClienteAsociado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcClienteAsociado.Location = new System.Drawing.Point(0, 0);
            this.gcClienteAsociado.MainView = this.gvClienteAsociado;
            this.gcClienteAsociado.Name = "gcClienteAsociado";
            this.gcClienteAsociado.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtAbrevDocumento});
            this.gcClienteAsociado.Size = new System.Drawing.Size(764, 211);
            this.gcClienteAsociado.TabIndex = 15;
            this.gcClienteAsociado.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClienteAsociado});
            // 
            // gvClienteAsociado
            // 
            this.gvClienteAsociado.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn15,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn12});
            this.gvClienteAsociado.GridControl = this.gcClienteAsociado;
            this.gvClienteAsociado.Name = "gvClienteAsociado";
            this.gvClienteAsociado.OptionsView.ShowGroupPanel = false;
            this.gvClienteAsociado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvClienteAsociado_KeyDown);
            this.gvClienteAsociado.DoubleClick += new System.EventHandler(this.gvClienteAsociado_DoubleClick);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdEmpresa";
            this.gridColumn6.FieldName = "IdEmpresa";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdClienteAsociado";
            this.gridColumn8.FieldName = "IdClienteAsociado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "IdCliente";
            this.gridColumn9.FieldName = "IdCliente";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IdTipoDocumento";
            this.gridColumn10.FieldName = "IdTipoDocumento";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Documento";
            this.gridColumn11.ColumnEdit = this.gcTxtAbrevDocumento;
            this.gridColumn11.FieldName = "AbrevDocumento";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 70;
            // 
            // gcTxtAbrevDocumento
            // 
            this.gcTxtAbrevDocumento.AutoHeight = false;
            this.gcTxtAbrevDocumento.Name = "gcTxtAbrevDocumento";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "N° Documento";
            this.gridColumn15.FieldName = "NumeroDocumento";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 1;
            this.gridColumn15.Width = 78;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Cliente";
            this.gridColumn13.FieldName = "DescCliente";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 344;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Dirección";
            this.gridColumn14.FieldName = "Direccion";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 255;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "TipoOper";
            this.gridColumn12.FieldName = "TipoOper";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // frmBusClienteAsociado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 211);
            this.Controls.Add(this.gcClienteAsociado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusClienteAsociado";
            this.Text = "Búsqueda Cliente Asociado";
            this.Load += new System.EventHandler(this.frmBusClienteAsociado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAsociado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAsociado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtAbrevDocumento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcClienteAsociado;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClienteAsociado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtAbrevDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}