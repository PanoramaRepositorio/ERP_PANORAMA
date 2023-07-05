namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManModeloProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManModeloProducto));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwDatos = new System.Windows.Forms.TreeView();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.gcModeloProducto = new DevExpress.XtraGrid.GridControl();
            this.gvModeloProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBuscar = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcModeloProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvModeloProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(890, 28);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvwDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnBuscar);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscar);
            this.splitContainer1.Panel2.Controls.Add(this.gcModeloProducto);
            this.splitContainer1.Size = new System.Drawing.Size(890, 406);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 1;
            // 
            // tvwDatos
            // 
            this.tvwDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDatos.ImageIndex = 0;
            this.tvwDatos.ImageList = this.imgLista;
            this.tvwDatos.Location = new System.Drawing.Point(0, 0);
            this.tvwDatos.Name = "tvwDatos";
            this.tvwDatos.SelectedImageIndex = 0;
            this.tvwDatos.Size = new System.Drawing.Size(304, 406);
            this.tvwDatos.TabIndex = 1;
            this.tvwDatos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDatos_AfterSelect);
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "LineaProducto_16x16.gif");
            this.imgLista.Images.SetKeyName(1, "SubLinea_16x16.gif");
            // 
            // gcModeloProducto
            // 
            this.gcModeloProducto.Location = new System.Drawing.Point(0, 34);
            this.gcModeloProducto.MainView = this.gvModeloProducto;
            this.gcModeloProducto.Name = "gcModeloProducto";
            this.gcModeloProducto.Size = new System.Drawing.Size(582, 376);
            this.gcModeloProducto.TabIndex = 37;
            this.gcModeloProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvModeloProducto});
            // 
            // gvModeloProducto
            // 
            this.gvModeloProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn4});
            this.gvModeloProducto.GridControl = this.gcModeloProducto;
            this.gvModeloProducto.Name = "gvModeloProducto";
            this.gvModeloProducto.OptionsSelection.MultiSelect = true;
            this.gvModeloProducto.OptionsView.ColumnAutoWidth = false;
            this.gvModeloProducto.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn1.Caption = "IdLineaProducto";
            this.gridColumn1.FieldName = "IdLineaProducto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdModeloProducto";
            this.gridColumn3.FieldName = "IdModeloProducto";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "DescModeloProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 431;
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
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(70, 8);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(296, 20);
            this.txtBuscar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Búsqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(372, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.Text = "Buscar";
            // 
            // frmManModeloProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 434);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManModeloProducto";
            this.Text = "Mantenimiento -Modelo Producto";
            this.Load += new System.EventHandler(this.frmManModeloProducto_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcModeloProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvModeloProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwDatos;
        private DevExpress.XtraGrid.GridControl gcModeloProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvModeloProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ImageList imgLista;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtBuscar;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
    }
}