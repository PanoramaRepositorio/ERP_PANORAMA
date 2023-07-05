namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManTarjetaRegalo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTarjetaRegalo));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcTarjetaRegalo = new DevExpress.XtraGrid.GridControl();
            this.gvTarjetaRegalo = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirDocumentolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gcTarjetaRegalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarjetaRegalo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1273, 24);
            this.tlbMenu.TabIndex = 1;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcTarjetaRegalo
            // 
            this.gcTarjetaRegalo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcTarjetaRegalo.Location = new System.Drawing.Point(0, 56);
            this.gcTarjetaRegalo.MainView = this.gvTarjetaRegalo;
            this.gcTarjetaRegalo.Name = "gcTarjetaRegalo";
            this.gcTarjetaRegalo.Size = new System.Drawing.Size(1273, 514);
            this.gcTarjetaRegalo.TabIndex = 35;
            this.gcTarjetaRegalo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTarjetaRegalo});
            // 
            // gvTarjetaRegalo
            // 
            this.gvTarjetaRegalo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gvTarjetaRegalo.GridControl = this.gcTarjetaRegalo;
            this.gvTarjetaRegalo.Name = "gvTarjetaRegalo";
            this.gvTarjetaRegalo.OptionsView.ColumnAutoWidth = false;
            this.gvTarjetaRegalo.OptionsView.ShowGroupPanel = false;
            this.gvTarjetaRegalo.DoubleClick += new System.EventHandler(this.gvTarjetaRegalo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdTarjetaRegalo";
            this.gridColumn1.FieldName = "IdTarjetaRegalo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
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
            this.gridColumn3.Caption = "IdTienda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
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
            this.gridColumn4.Width = 115;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdCliente";
            this.gridColumn5.FieldName = "IdCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "DNI";
            this.gridColumn6.FieldName = "NumeroDocumento";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cliente";
            this.gridColumn7.FieldName = "DescCliente";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Width = 144;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Número  GiftCard";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 121;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total";
            this.gridColumn9.FieldName = "ImporteTotal";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 98;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Disponible";
            this.gridColumn10.FieldName = "ImporteDisponible";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "Fecha Inicio";
            this.gridColumn11.FieldName = "FechaInicio";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 84;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "Fecha Fin";
            this.gridColumn12.FieldName = "FechaFin";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 5;
            this.gridColumn12.Width = 87;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "IdSituacion";
            this.gridColumn13.FieldName = "IdSituacion";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "Situación";
            this.gridColumn14.FieldName = "DescSituacion";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            this.gridColumn14.Width = 210;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Observación";
            this.gridColumn15.FieldName = "Observacion";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 7;
            this.gridColumn15.Width = 251;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "FlagEstado";
            this.gridColumn16.FieldName = "FlagEstado";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(460, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(105, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(349, 20);
            this.txtDescripcion.TabIndex = 33;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 13);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Codigo Gift Card:";
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirDocumentolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(219, 26);
            // 
            // imprimirDocumentolStripMenuItem
            // 
            this.imprimirDocumentolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Printer_32x32;
            this.imprimirDocumentolStripMenuItem.Name = "imprimirDocumentolStripMenuItem";
            this.imprimirDocumentolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.imprimirDocumentolStripMenuItem.Text = "Imprimir Documento Venta";
            this.imprimirDocumentolStripMenuItem.Click += new System.EventHandler(this.imprimirDocumentolStripMenuItem_Click);
            // 
            // frmManTarjetaRegalo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 572);
            this.Controls.Add(this.gcTarjetaRegalo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManTarjetaRegalo";
            this.Text = "Mantenimiento - Tarjeta Regalo";
            this.Load += new System.EventHandler(this.frmManTarjetaRegalo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTarjetaRegalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTarjetaRegalo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcTarjetaRegalo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTarjetaRegalo;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem imprimirDocumentolStripMenuItem;
    }
}