namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmProductoStockVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductoStockVenta));
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verreservadostoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBtnVerTransito = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.gcProducto2 = new DevExpress.XtraGrid.GridControl();
            this.gvProducto2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAutoservicio = new System.Windows.Forms.CheckBox();
            this.gcStockAlmacenes = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBtnVerTransito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockAlmacenes)).BeginInit();
            this.gcStockAlmacenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcProducto
            // 
            this.gcProducto.ContextMenuStrip = this.mnuContextual;
            this.gcProducto.Location = new System.Drawing.Point(0, 2);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcBtnVerTransito,
            this.repositoryItemPictureEdit1});
            this.gcProducto.Size = new System.Drawing.Size(693, 213);
            this.gcProducto.TabIndex = 0;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verreservadostoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(153, 26);
            // 
            // verreservadostoolStripMenuItem
            // 
            this.verreservadostoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultar_16x16;
            this.verreservadostoolStripMenuItem.Name = "verreservadostoolStripMenuItem";
            this.verreservadostoolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verreservadostoolStripMenuItem.Text = "Ver Reservados";
            this.verreservadostoolStripMenuItem.Click += new System.EventHandler(this.verreservadostoolStripMenuItem_Click);
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tienda";
            this.gridColumn2.FieldName = "DescTienda";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 132;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Almacén";
            this.gridColumn5.FieldName = "DescAlmacen";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 255;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn3.Caption = "Stock";
            this.gridColumn3.FieldName = "Cantidad";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "Cantidad";
            this.gridColumn1.FieldName = "CantidadPedida";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Abrev Alm.";
            this.gridColumn8.FieldName = "AbrevAlmacen";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "Observación";
            this.gridColumn9.FieldName = "Observacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 159;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IdAlmacen";
            this.gridColumn10.FieldName = "IdAlmacen";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gcBtnVerTransito
            // 
            this.gcBtnVerTransito.AutoHeight = false;
            this.gcBtnVerTransito.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.gcBtnVerTransito.Name = "gcBtnVerTransito";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(602, 432);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageOptions.ImageIndex = 1;
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(521, 432);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gcProducto2
            // 
            this.gcProducto2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducto2.Location = new System.Drawing.Point(2, 23);
            this.gcProducto2.MainView = this.gvProducto2;
            this.gcProducto2.Name = "gcProducto2";
            this.gcProducto2.Size = new System.Drawing.Size(689, 155);
            this.gcProducto2.TabIndex = 0;
            this.gcProducto2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto2});
            // 
            // gvProducto2
            // 
            this.gvProducto2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7});
            this.gvProducto2.GridControl = this.gcProducto2;
            this.gvProducto2.Name = "gvProducto2";
            this.gvProducto2.OptionsView.ColumnAutoWidth = false;
            this.gvProducto2.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn4.Width = 132;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Almacén";
            this.gridColumn6.FieldName = "DescAlmacen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 255;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn7.Caption = "Stock";
            this.gridColumn7.FieldName = "Cantidad";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Si Ud. desea vender de otro Almacén, debe comunicarse con el encargado \r\nde almac" +
    "én de la tienda origen para reservar el stock físico.";
            // 
            // chkAutoservicio
            // 
            this.chkAutoservicio.AutoSize = true;
            this.chkAutoservicio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkAutoservicio.ForeColor = System.Drawing.Color.Red;
            this.chkAutoservicio.Location = new System.Drawing.Point(32, 645);
            this.chkAutoservicio.Name = "chkAutoservicio";
            this.chkAutoservicio.Size = new System.Drawing.Size(97, 17);
            this.chkAutoservicio.TabIndex = 1;
            this.chkAutoservicio.Text = "&Autoservicio";
            this.chkAutoservicio.UseVisualStyleBackColor = true;
            this.chkAutoservicio.Visible = false;
            // 
            // gcStockAlmacenes
            // 
            this.gcStockAlmacenes.Controls.Add(this.gcProducto2);
            this.gcStockAlmacenes.Location = new System.Drawing.Point(0, 247);
            this.gcStockAlmacenes.Name = "gcStockAlmacenes";
            this.gcStockAlmacenes.Size = new System.Drawing.Size(693, 180);
            this.gcStockAlmacenes.TabIndex = 0;
            this.gcStockAlmacenes.Text = "Stock de Todos los almacenes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(495, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clic derecho, para ver stock Reservado\r\n";
            // 
            // frmProductoStockVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 464);
            this.Controls.Add(this.gcStockAlmacenes);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.chkAutoservicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductoStockVenta";
            this.Text = "Stock Disponible por Tienda";
            this.Load += new System.EventHandler(this.frmProductoStockVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBtnVerTransito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStockAlmacenes)).EndInit();
            this.gcStockAlmacenes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraGrid.GridControl gcProducto2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoservicio;
        private DevExpress.XtraEditors.GroupControl gcStockAlmacenes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit gcBtnVerTransito;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem verreservadostoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.Label label1;
    }
}