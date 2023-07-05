namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusLineaProducto
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
            this.gcLineaProducto = new DevExpress.XtraGrid.GridControl();
            this.gvLineaProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcLineaProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLineaProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // gcLineaProducto
            // 
            this.gcLineaProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLineaProducto.Location = new System.Drawing.Point(0, 0);
            this.gcLineaProducto.MainView = this.gvLineaProducto;
            this.gcLineaProducto.Name = "gcLineaProducto";
            this.gcLineaProducto.Size = new System.Drawing.Size(374, 309);
            this.gcLineaProducto.TabIndex = 46;
            this.gcLineaProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLineaProducto});
            // 
            // gvLineaProducto
            // 
            this.gvLineaProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn3});
            this.gvLineaProducto.GridControl = this.gcLineaProducto;
            this.gvLineaProducto.Name = "gvLineaProducto";
            this.gvLineaProducto.OptionsView.ShowGroupPanel = false;
            this.gvLineaProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvLineaProducto_KeyDown);
            this.gvLineaProducto.DoubleClick += new System.EventHandler(this.gvLineaProducto_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdLineaProducto";
            this.gridColumn2.FieldName = "IdLineaProducto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Línea Producto";
            this.gridColumn3.FieldName = "DescLineaProducto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 358;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "N°";
            this.gridColumn4.FieldName = "Numero";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 30;
            // 
            // frmBusLineaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 309);
            this.Controls.Add(this.gcLineaProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmBusLineaProducto";
            this.Text = "Búsqueda Línea Producto";
            this.Load += new System.EventHandler(this.frmBusLineaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcLineaProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLineaProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcLineaProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLineaProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}