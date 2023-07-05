namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegNovioRegalo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegNovioRegalo));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroNovioRegalo = new DevExpress.XtraEditors.TextEdit();
            this.gcNovioRegalo = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImprimirContratotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerCatalogotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvNovioRegalo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroNovioRegalo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNovioRegalo)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvNovioRegalo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1337, 24);
            this.tlbMenu.TabIndex = 51;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.txtDescCliente);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.deHasta);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.deDesde);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtNumeroNovioRegalo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1337, 55);
            this.groupControl1.TabIndex = 52;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(364, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 55;
            this.labelControl2.Text = "Cliente : ";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(287, 25);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 59;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(413, 26);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Size = new System.Drawing.Size(438, 20);
            this.txtDescCliente.TabIndex = 54;
            this.txtDescCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescCliente_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 55;
            this.labelControl1.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(197, 26);
            this.deHasta.Name = "deHasta";
            this.deHasta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHasta.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deHasta.Properties.ShowPopupShadow = false;
            this.deHasta.Properties.ShowToday = false;
            this.deHasta.Size = new System.Drawing.Size(80, 20);
            this.deHasta.TabIndex = 58;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(159, 29);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 57;
            this.labelControl4.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(59, 26);
            this.deDesde.Name = "deDesde";
            this.deDesde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDesde.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deDesde.Properties.ShowPopupShadow = false;
            this.deDesde.Properties.ShowToday = false;
            this.deDesde.Size = new System.Drawing.Size(80, 20);
            this.deDesde.TabIndex = 56;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(857, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(78, 13);
            this.labelControl3.TabIndex = 54;
            this.labelControl3.Text = "Código Novios : ";
            // 
            // txtNumeroNovioRegalo
            // 
            this.txtNumeroNovioRegalo.Location = new System.Drawing.Point(936, 25);
            this.txtNumeroNovioRegalo.Name = "txtNumeroNovioRegalo";
            this.txtNumeroNovioRegalo.Properties.MaxLength = 30;
            this.txtNumeroNovioRegalo.Size = new System.Drawing.Size(91, 20);
            this.txtNumeroNovioRegalo.TabIndex = 53;
            this.txtNumeroNovioRegalo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroNovioRegalo_KeyUp);
            // 
            // gcNovioRegalo
            // 
            this.gcNovioRegalo.ContextMenuStrip = this.mnuContextual;
            this.gcNovioRegalo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNovioRegalo.Location = new System.Drawing.Point(0, 79);
            this.gcNovioRegalo.MainView = this.gvNovioRegalo;
            this.gcNovioRegalo.Name = "gcNovioRegalo";
            this.gcNovioRegalo.Size = new System.Drawing.Size(1337, 456);
            this.gcNovioRegalo.TabIndex = 53;
            this.gcNovioRegalo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNovioRegalo});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImprimirContratotoolStripMenuItem,
            this.VerCatalogotoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(171, 48);
            // 
            // ImprimirContratotoolStripMenuItem
            // 
            this.ImprimirContratotoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImprimirContratotoolStripMenuItem.Image")));
            this.ImprimirContratotoolStripMenuItem.Name = "ImprimirContratotoolStripMenuItem";
            this.ImprimirContratotoolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ImprimirContratotoolStripMenuItem.Text = "Imprimir Contrato";
            this.ImprimirContratotoolStripMenuItem.Click += new System.EventHandler(this.ImprimirContratotoolStripMenuItem_Click);
            // 
            // VerCatalogotoolStripMenuItem
            // 
            this.VerCatalogotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.VerCatalogotoolStripMenuItem.Name = "VerCatalogotoolStripMenuItem";
            this.VerCatalogotoolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.VerCatalogotoolStripMenuItem.Text = "Ver Catálogo";
            this.VerCatalogotoolStripMenuItem.Click += new System.EventHandler(this.VerCatalogotoolStripMenuItem_Click);
            // 
            // gvNovioRegalo
            // 
            this.gvNovioRegalo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gvNovioRegalo.GridControl = this.gcNovioRegalo;
            this.gvNovioRegalo.Name = "gvNovioRegalo";
            this.gvNovioRegalo.OptionsView.ColumnAutoWidth = false;
            this.gvNovioRegalo.OptionsView.ShowGroupPanel = false;
            this.gvNovioRegalo.DoubleClick += new System.EventHandler(this.gvNovioRegalo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdNovioRegalo";
            this.gridColumn1.FieldName = "IdNovioRegalo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 88;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tienda";
            this.gridColumn2.FieldName = "DescTienda";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Novio";
            this.gridColumn3.FieldName = "DescNovio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 190;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Novia";
            this.gridColumn4.FieldName = "DescNovia";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 214;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Fecha Boda";
            this.gridColumn5.FieldName = "FechaBoda";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Asesor";
            this.gridColumn6.FieldName = "DescAsesor";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 186;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Observación";
            this.gridColumn7.FieldName = "Observacion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Dirección";
            this.gridColumn8.FieldName = "Direccion";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Width = 343;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "FlagEstado";
            this.gridColumn9.FieldName = "FlagEstado";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Código Novios";
            this.gridColumn10.FieldName = "Numero";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 80;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Fecha";
            this.gridColumn11.FieldName = "Fecha";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Vendedor";
            this.gridColumn12.FieldName = "DescVendedor";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            this.gridColumn12.Width = 210;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Invitados S/";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "TotalInvitados";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Novios S/";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "TotalNovios";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 9;
            // 
            // frmRegNovioRegalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 535);
            this.Controls.Add(this.gcNovioRegalo);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegNovioRegalo";
            this.Text = "Lista de Novios";
            this.Load += new System.EventHandler(this.frmRegNovioRegalo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroNovioRegalo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNovioRegalo)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvNovioRegalo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNumeroNovioRegalo;
        private DevExpress.XtraGrid.GridControl gcNovioRegalo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNovioRegalo;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem ImprimirContratotoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.ToolStripMenuItem VerCatalogotoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}