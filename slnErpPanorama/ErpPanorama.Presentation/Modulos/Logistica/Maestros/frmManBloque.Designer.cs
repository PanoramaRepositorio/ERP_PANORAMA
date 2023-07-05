namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManBloque));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwDatos = new System.Windows.Forms.TreeView();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.gcBloque = new DevExpress.XtraGrid.GridControl();
            this.gvBloque = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBloque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(682, 24);
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvwDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcBloque);
            this.splitContainer1.Size = new System.Drawing.Size(682, 366);
            this.splitContainer1.SplitterDistance = 197;
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
            this.tvwDatos.Size = new System.Drawing.Size(197, 366);
            this.tvwDatos.TabIndex = 0;
            this.tvwDatos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDatos_AfterSelect);
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "Almacen_16x16.gif");
            this.imgLista.Images.SetKeyName(1, "Sectores_16x16.gif");
            // 
            // gcBloque
            // 
            this.gcBloque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBloque.Location = new System.Drawing.Point(0, 0);
            this.gcBloque.MainView = this.gvBloque;
            this.gcBloque.Name = "gcBloque";
            this.gcBloque.Size = new System.Drawing.Size(481, 366);
            this.gcBloque.TabIndex = 36;
            this.gcBloque.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBloque});
            // 
            // gvBloque
            // 
            this.gvBloque.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn4});
            this.gvBloque.GridControl = this.gcBloque;
            this.gvBloque.Name = "gvBloque";
            this.gvBloque.OptionsView.ColumnAutoWidth = false;
            this.gvBloque.OptionsView.ShowGroupPanel = false;
            this.gvBloque.DoubleClick += new System.EventHandler(this.gvBloque_DoubleClick);
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
            this.gridColumn1.Caption = "IdAlmacen";
            this.gridColumn1.FieldName = "IdAlmacen";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdSector";
            this.gridColumn3.FieldName = "IdSector";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdBloque";
            this.gridColumn6.FieldName = "IdBloque";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "DescBloque";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 494;
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
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdTienda";
            this.gridColumn7.FieldName = "IdTienda";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // frmManBloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 390);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManBloque";
            this.Text = "Bloques - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManBloque_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBloque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBloque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwDatos;
        private System.Windows.Forms.ImageList imgLista;
        private DevExpress.XtraGrid.GridControl gcBloque;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBloque;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}