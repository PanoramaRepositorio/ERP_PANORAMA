namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManPromocion2x1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPromocion2x1));
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromocion2x1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPromocion2x1 = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generarporlineatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarporsublineatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromocion2x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromocion2x1)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(604, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 47;
            this.btnBuscar.Text = "Buscar";
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
            // gvPromocion2x1
            // 
            this.gvPromocion2x1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn18,
            this.gridColumn17,
            this.gridColumn16,
            this.gridColumn15,
            this.gridColumn14,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23});
            this.gvPromocion2x1.GridControl = this.gcPromocion2x1;
            this.gvPromocion2x1.Name = "gvPromocion2x1";
            this.gvPromocion2x1.OptionsView.ColumnAutoWidth = false;
            this.gvPromocion2x1.OptionsView.ShowGroupPanel = false;
            this.gvPromocion2x1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvPromocion2x1_RowStyle);
            this.gvPromocion2x1.DoubleClick += new System.EventHandler(this.gvPromocion2x1_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "DescPromocion2x1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 239;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdFormaPago";
            this.gridColumn4.FieldName = "IdFormaPago";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Forma Pago";
            this.gridColumn5.FieldName = "DescFormaPago";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "F. Inicio";
            this.gridColumn6.FieldName = "FechaInicio";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "F. Fin";
            this.gridColumn7.FieldName = "FechaFin";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Estado";
            this.gridColumn8.FieldName = "FlagEstado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "IdTipoCliente";
            this.gridColumn9.FieldName = "IdTipoCliente";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tipo Cliente";
            this.gridColumn10.FieldName = "DescTipoCliente";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Width = 140;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Empresa";
            this.gridColumn11.FieldName = "RazonSocial";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 86;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Contado";
            this.gridColumn18.FieldName = "FlagContado";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 7;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Crédito";
            this.gridColumn17.FieldName = "FlagCredito";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 9;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Consignación";
            this.gridColumn16.FieldName = "FlagConsignacion";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 13;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Separación";
            this.gridColumn15.FieldName = "FlagSeparacion";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 10;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Contraentrega";
            this.gridColumn14.FieldName = "FlagContraentrega";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Copagan";
            this.gridColumn13.FieldName = "FlagCopagan";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Obsequio";
            this.gridColumn12.FieldName = "FlagObsequio";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Asaf";
            this.gridColumn19.FieldName = "FlagAsaf";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 14;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "C.Mayorista";
            this.gridColumn20.FieldName = "FlagClienteMayorista";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 4;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "F.Final";
            this.gridColumn21.FieldName = "FlagClienteFinal";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 3;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn22.AppearanceCell.Options.UseFont = true;
            this.gridColumn22.Caption = "Tipo";
            this.gridColumn22.FieldName = "Tipo";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Web";
            this.gridColumn23.FieldName = "FlagWeb";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 15;
            this.gridColumn23.Width = 42;
            // 
            // gcPromocion2x1
            // 
            this.gcPromocion2x1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPromocion2x1.ContextMenuStrip = this.mnuContextual;
            this.gcPromocion2x1.Location = new System.Drawing.Point(0, 60);
            this.gcPromocion2x1.MainView = this.gvPromocion2x1;
            this.gcPromocion2x1.Name = "gcPromocion2x1";
            this.gcPromocion2x1.Size = new System.Drawing.Size(1383, 426);
            this.gcPromocion2x1.TabIndex = 46;
            this.gcPromocion2x1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPromocion2x1});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiartoolStripMenuItem,
            this.pegartoolStripMenuItem,
            this.toolStripSeparator1,
            this.generarporlineatoolStripMenuItem,
            this.generarporsublineatoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(191, 98);
            // 
            // copiartoolStripMenuItem
            // 
            this.copiartoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Copiar_16x16;
            this.copiartoolStripMenuItem.Name = "copiartoolStripMenuItem";
            this.copiartoolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copiartoolStripMenuItem.Text = "Copiar";
            // 
            // pegartoolStripMenuItem
            // 
            this.pegartoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Copiar_16x16;
            this.pegartoolStripMenuItem.Name = "pegartoolStripMenuItem";
            this.pegartoolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.pegartoolStripMenuItem.Text = "Pegar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // generarporlineatoolStripMenuItem
            // 
            this.generarporlineatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Pdf_16x16;
            this.generarporlineatoolStripMenuItem.Name = "generarporlineatoolStripMenuItem";
            this.generarporlineatoolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.generarporlineatoolStripMenuItem.Text = "Generar por Línea";
            this.generarporlineatoolStripMenuItem.Click += new System.EventHandler(this.generarporlineatoolStripMenuItem_Click);
            // 
            // generarporsublineatoolStripMenuItem
            // 
            this.generarporsublineatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Pdf_16x16;
            this.generarporsublineatoolStripMenuItem.Name = "generarporsublineatoolStripMenuItem";
            this.generarporsublineatoolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.generarporsublineatoolStripMenuItem.Text = "Generar por SubLínea ";
            this.generarporsublineatoolStripMenuItem.Click += new System.EventHandler(this.generarporsublineatoolStripMenuItem_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(66, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(532, 20);
            this.txtDescripcion.TabIndex = 49;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Descripción:";
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1395, 24);
            this.tlbMenu.TabIndex = 45;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Appearance.Options.UseForeColor = true;
            this.lblMensaje.Location = new System.Drawing.Point(712, 34);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(130, 13);
            this.lblMensaje.TabIndex = 62;
            this.lblMensaje.Text = "Promoción [ 8 ] en memoria";
            this.lblMensaje.Visible = false;
            // 
            // frmManPromocion2x1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 498);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcPromocion2x1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmManPromocion2x1";
            this.Text = "Promoción 2x1";
            this.Load += new System.EventHandler(this.frmManPromocion2x1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPromocion2x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromocion2x1)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPromocion2x1;
        private DevExpress.XtraGrid.GridControl gcPromocion2x1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem copiartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegartoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem generarporlineatoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarporsublineatoolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
    }
}