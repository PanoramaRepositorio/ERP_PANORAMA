namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManPiso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPiso));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwDatos = new System.Windows.Forms.TreeView();
            this.imgLista = new System.Windows.Forms.ImageList(this.components);
            this.gcPiso = new DevExpress.XtraGrid.GridControl();
            this.gvPiso = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPiso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPiso)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.gcPiso);
            this.splitContainer1.Size = new System.Drawing.Size(682, 452);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 2;
            // 
            // tvwDatos
            // 
            this.tvwDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDatos.ImageIndex = 0;
            this.tvwDatos.ImageList = this.imgLista;
            this.tvwDatos.Location = new System.Drawing.Point(0, 0);
            this.tvwDatos.Name = "tvwDatos";
            this.tvwDatos.SelectedImageIndex = 0;
            this.tvwDatos.Size = new System.Drawing.Size(197, 452);
            this.tvwDatos.TabIndex = 0;
            this.tvwDatos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDatos_AfterSelect);
            // 
            // imgLista
            // 
            this.imgLista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLista.ImageStream")));
            this.imgLista.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLista.Images.SetKeyName(0, "Almacen_16x16.gif");
            this.imgLista.Images.SetKeyName(1, "Ubicaciones_16x16.gif");
            // 
            // gcPiso
            // 
            this.gcPiso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPiso.Location = new System.Drawing.Point(0, 0);
            this.gcPiso.MainView = this.gvPiso;
            this.gcPiso.Name = "gcPiso";
            this.gcPiso.Size = new System.Drawing.Size(481, 452);
            this.gcPiso.TabIndex = 36;
            this.gcPiso.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPiso});
            // 
            // gvPiso
            // 
            this.gvPiso.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn4});
            this.gvPiso.GridControl = this.gcPiso;
            this.gvPiso.Name = "gvPiso";
            this.gvPiso.OptionsView.ColumnAutoWidth = false;
            this.gvPiso.OptionsView.ShowGroupPanel = false;
            this.gvPiso.DoubleClick += new System.EventHandler(this.gvPiso_DoubleClick);
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
            this.gridColumn3.Caption = "IdUbicacion";
            this.gridColumn3.FieldName = "IdUbicacion";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdPiso";
            this.gridColumn6.FieldName = "IdPiso";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "DescPiso";
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
            // frmManPiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 476);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPiso";
            this.Text = "Piso - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManPiso_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPiso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPiso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwDatos;
        private DevExpress.XtraGrid.GridControl gcPiso;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPiso;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ImageList imgLista;
    }
}