namespace ErpPanorama.Presentation.Modulos.Maestros
{
    partial class frmManCajaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManCajaEmpresa));
            this.gcCajaEmpresa = new DevExpress.XtraGrid.GridControl();
            this.mnuCajaEmpresa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvCajaEmpresa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdCajaEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcCajaEmpresa)).BeginInit();
            this.mnuCajaEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCajaEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCajaEmpresa
            // 
            this.gcCajaEmpresa.ContextMenuStrip = this.mnuCajaEmpresa;
            this.gcCajaEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCajaEmpresa.Location = new System.Drawing.Point(0, 0);
            this.gcCajaEmpresa.MainView = this.gvCajaEmpresa;
            this.gcCajaEmpresa.Name = "gcCajaEmpresa";
            this.gcCajaEmpresa.Size = new System.Drawing.Size(763, 262);
            this.gcCajaEmpresa.TabIndex = 25;
            this.gcCajaEmpresa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCajaEmpresa});
            // 
            // mnuCajaEmpresa
            // 
            this.mnuCajaEmpresa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.mnuCajaEmpresa.Name = "contextMenuStrip1";
            this.mnuCajaEmpresa.Size = new System.Drawing.Size(126, 70);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem.Image")));
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // gvCajaEmpresa
            // 
            this.gvCajaEmpresa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdCajaEmpresa,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvCajaEmpresa.GridControl = this.gcCajaEmpresa;
            this.gvCajaEmpresa.Name = "gvCajaEmpresa";
            this.gvCajaEmpresa.OptionsView.ColumnAutoWidth = false;
            this.gvCajaEmpresa.OptionsView.ShowGroupPanel = false;
            this.gvCajaEmpresa.DoubleClick += new System.EventHandler(this.gvCajaEmpresa_DoubleClick);
            // 
            // IdCajaEmpresa
            // 
            this.IdCajaEmpresa.Caption = "IdCajaEmpresa";
            this.IdCajaEmpresa.Name = "IdCajaEmpresa";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdTienda";
            this.gridColumn1.FieldName = "IdTienda";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdCaja";
            this.gridColumn6.FieldName = "IdCaja";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tienda";
            this.gridColumn8.FieldName = "DescTienda";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Caja";
            this.gridColumn5.FieldName = "DescCaja";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Empresa";
            this.gridColumn7.FieldName = "RazonSocial";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 264;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Estado";
            this.gridColumn4.FieldName = "FlagEstado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 20;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdTipoFormato";
            this.gridColumn3.FieldName = "IdTipoFormato";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tipo Formato";
            this.gridColumn9.FieldName = "DescTipoFormato";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 111;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Serie BOV";
            this.gridColumn10.FieldName = "SerieBoleta";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Serie FAV";
            this.gridColumn11.FieldName = "SerieFactura";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // frmManCajaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 262);
            this.Controls.Add(this.gcCajaEmpresa);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManCajaEmpresa";
            this.Text = "Caja Empresa - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManCajaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCajaEmpresa)).EndInit();
            this.mnuCajaEmpresa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCajaEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCajaEmpresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCajaEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ContextMenuStrip mnuCajaEmpresa;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn IdCajaEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}