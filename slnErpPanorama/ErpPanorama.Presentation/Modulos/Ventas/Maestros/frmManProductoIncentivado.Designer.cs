namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManProductoIncentivado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManProductoIncentivado));
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvProductoIncentivado = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductoIncentivado = new DevExpress.XtraGrid.GridControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvProductoIncentivado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductoIncentivado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(531, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 52;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(605, 24);
            this.tlbMenu.TabIndex = 50;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
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
            this.gridColumn1.Caption = "IdPromocion2x1";
            this.gridColumn1.FieldName = "IdPromocion2x1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gvProductoIncentivado
            // 
            this.gvProductoIncentivado.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gvProductoIncentivado.GridControl = this.gcProductoIncentivado;
            this.gvProductoIncentivado.Name = "gvProductoIncentivado";
            this.gvProductoIncentivado.OptionsView.ColumnAutoWidth = false;
            this.gvProductoIncentivado.OptionsView.ShowGroupPanel = false;
            this.gvProductoIncentivado.DoubleClick += new System.EventHandler(this.gvProductoIncentivado_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "DescProductoIncentivado";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 315;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "F. Inicio";
            this.gridColumn6.FieldName = "FechaInicio";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "F. Fin";
            this.gridColumn7.FieldName = "FechaFin";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Estado";
            this.gridColumn8.FieldName = "FlagEstado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // gcProductoIncentivado
            // 
            this.gcProductoIncentivado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcProductoIncentivado.Location = new System.Drawing.Point(0, 66);
            this.gcProductoIncentivado.MainView = this.gvProductoIncentivado;
            this.gcProductoIncentivado.Name = "gcProductoIncentivado";
            this.gcProductoIncentivado.Size = new System.Drawing.Size(598, 297);
            this.gcProductoIncentivado.TabIndex = 51;
            this.gcProductoIncentivado.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProductoIncentivado});
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(66, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(459, 20);
            this.txtDescripcion.TabIndex = 54;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "Descripción:";
            // 
            // frmManProductoIncentivado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 369);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tlbMenu);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcProductoIncentivado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManProductoIncentivado";
            this.Text = "Producto Incentivado";
            this.Load += new System.EventHandler(this.frmManProductoIncentivado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvProductoIncentivado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProductoIncentivado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProductoIncentivado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.GridControl gcProductoIncentivado;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}