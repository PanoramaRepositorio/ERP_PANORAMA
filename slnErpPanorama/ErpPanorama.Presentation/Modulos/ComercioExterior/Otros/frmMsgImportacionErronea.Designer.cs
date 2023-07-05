namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Otros
{
    partial class frmMsgImportacionErronea
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblRegistros = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.gcProducto);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(371, 382);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "NO EXISTEN";
            // 
            // gcProducto
            // 
            this.gcProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducto.Location = new System.Drawing.Point(2, 21);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(367, 359);
            this.gcProducto.TabIndex = 89;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gcCodigo,
            this.gcCantidad});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsSelection.MultiSelect = true;
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdMovimientoAlmancen";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPreventaDetalle";
            this.gridColumn11.FieldName = "IdPreventaDetalle";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.FieldName = "CodigoProveedor";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 132;
            // 
            // gcCantidad
            // 
            this.gcCantidad.Caption = "Cantidad";
            this.gcCantidad.FieldName = "Cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.OptionsColumn.AllowEdit = false;
            this.gcCantidad.OptionsColumn.AllowFocus = false;
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 1;
            this.gcCantidad.Width = 60;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistros.Location = new System.Drawing.Point(12, 393);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblRegistros.TabIndex = 126;
            this.lblRegistros.Text = "0 Registros";
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageIndex = 1;
            this.btnExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(269, 388);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(91, 23);
            this.btnExportar.TabIndex = 125;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmMsgImportacionErronea
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 423);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMsgImportacionErronea";
            this.Text = "Codigo Erróneos (VERIFICAR)";
            this.Load += new System.EventHandler(this.frmMsgImportacionErronea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcProducto;
        public DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraEditors.LabelControl lblRegistros;
        public DevExpress.XtraEditors.SimpleButton btnExportar;

    }
}