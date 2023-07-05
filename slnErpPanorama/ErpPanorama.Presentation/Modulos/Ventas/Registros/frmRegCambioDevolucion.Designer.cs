namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegCambioDevolucion
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcCambio = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aprobarsolicitudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recibirdevolucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularrecibimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cambiarclienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportarexcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvCambio = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultarMasInformacion = new DevExpress.XtraEditors.SimpleButton();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcCambio)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1742, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // gcCambio
            // 
            this.gcCambio.ContextMenuStrip = this.mnuContextual;
            this.gcCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCambio.Location = new System.Drawing.Point(0, 76);
            this.gcCambio.MainView = this.gvCambio;
            this.gcCambio.Name = "gcCambio";
            this.gcCambio.Size = new System.Drawing.Size(1742, 481);
            this.gcCambio.TabIndex = 24;
            this.gcCambio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCambio});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aprobarsolicitudToolStripMenuItem,
            this.toolStripSeparator1,
            this.recibirdevolucionToolStripMenuItem,
            this.anularrecibimientoToolStripMenuItem,
            this.toolStripSeparator2,
            this.cambiarclienteToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportarexcelToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(183, 154);
            // 
            // aprobarsolicitudToolStripMenuItem
            // 
            this.aprobarsolicitudToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Aprobar_16x16;
            this.aprobarsolicitudToolStripMenuItem.Name = "aprobarsolicitudToolStripMenuItem";
            this.aprobarsolicitudToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aprobarsolicitudToolStripMenuItem.Text = "Aprobar Solicitud";
            this.aprobarsolicitudToolStripMenuItem.Click += new System.EventHandler(this.aprobarsolicitudToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // recibirdevolucionToolStripMenuItem
            // 
            this.recibirdevolucionToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.RecibirDevolucion_16x16;
            this.recibirdevolucionToolStripMenuItem.Name = "recibirdevolucionToolStripMenuItem";
            this.recibirdevolucionToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.recibirdevolucionToolStripMenuItem.Text = "Recibir Devolución";
            this.recibirdevolucionToolStripMenuItem.Click += new System.EventHandler(this.recibirdevolucionToolStripMenuItem_Click);
            // 
            // anularrecibimientoToolStripMenuItem
            // 
            this.anularrecibimientoToolStripMenuItem.Enabled = false;
            this.anularrecibimientoToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.AnularRecibimiento_16x16;
            this.anularrecibimientoToolStripMenuItem.Name = "anularrecibimientoToolStripMenuItem";
            this.anularrecibimientoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.anularrecibimientoToolStripMenuItem.Text = "Anular Recibimiento";
            this.anularrecibimientoToolStripMenuItem.Click += new System.EventHandler(this.anularrecibimientoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // cambiarclienteToolStripMenuItem
            // 
            this.cambiarclienteToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Clientes_16x16;
            this.cambiarclienteToolStripMenuItem.Name = "cambiarclienteToolStripMenuItem";
            this.cambiarclienteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarclienteToolStripMenuItem.Text = "Cambiar Cliente";
            this.cambiarclienteToolStripMenuItem.Click += new System.EventHandler(this.cambiarclienteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // exportarexcelToolStripMenuItem
            // 
            this.exportarexcelToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.exportarexcelToolStripMenuItem.Name = "exportarexcelToolStripMenuItem";
            this.exportarexcelToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportarexcelToolStripMenuItem.Text = "Exportar Excel";
            this.exportarexcelToolStripMenuItem.Click += new System.EventHandler(this.exportarexcelToolStripMenuItem_Click);
            // 
            // gvCambio
            // 
            this.gvCambio.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn5,
            this.gridColumn16,
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn14,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn13,
            this.gridColumn15,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn21,
            this.gridColumn20,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24});
            this.gvCambio.GridControl = this.gcCambio;
            this.gvCambio.GroupPanelText = "Resultado de la Busqueda";
            this.gvCambio.Name = "gvCambio";
            this.gvCambio.OptionsView.ColumnAutoWidth = false;
            this.gvCambio.OptionsView.ShowGroupPanel = false;
            this.gvCambio.ColumnFilterChanged += new System.EventHandler(this.gvCambio_ColumnFilterChanged);
            this.gvCambio.DoubleClick += new System.EventHandler(this.gvCambio_DoubleClick);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IdEmpresa";
            this.gridColumn10.FieldName = "IdEmpresa";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdCambio";
            this.gridColumn5.FieldName = "IdCambio";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "IdTienda";
            this.gridColumn16.FieldName = "IdTienda";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Empresa";
            this.gridColumn12.FieldName = "RazonSocial";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tienda";
            this.gridColumn6.FieldName = "DescTienda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Periodo";
            this.gridColumn14.FieldName = "Periodo";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Documento";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "N° Pedido";
            this.gridColumn1.FieldName = "NumeroPedido";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "N° Documento Venta";
            this.gridColumn4.FieldName = "NumeroDocumentoVenta";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 110;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cliente";
            this.gridColumn8.FieldName = "DescCliente";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 250;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Moneda";
            this.gridColumn9.FieldName = "CodMoneda";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Total";
            this.gridColumn11.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "Total";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Aprobado";
            this.gridColumn7.FieldName = "FlagAprobado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 65;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Recibido";
            this.gridColumn13.FieldName = "FlagRecibido";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 60;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "N° Nota de Credito";
            this.gridColumn15.FieldName = "NumeroNotaCredito";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 11;
            this.gridColumn15.Width = 120;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Aplicación";
            this.gridColumn17.FieldName = "DescTipoAplicacion";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 12;
            this.gridColumn17.Width = 104;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Supervisor";
            this.gridColumn18.FieldName = "DescSupervisor";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 15;
            this.gridColumn18.Width = 247;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Tipo Cliente";
            this.gridColumn19.FieldName = "DescTipoCliente";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 16;
            this.gridColumn19.Width = 111;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Usuario";
            this.gridColumn21.FieldName = "Usuario";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 13;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "IdTipoDocumento";
            this.gridColumn20.FieldName = "IdTipoDocumento";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.gridColumn22.AppearanceHeader.Options.UseForeColor = true;
            this.gridColumn22.Caption = "Reajuste";
            this.gridColumn22.FieldName = "FlagReajuste";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 14;
            this.gridColumn22.Width = 51;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Motivo";
            this.gridColumn23.FieldName = "Motivo";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 17;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Observacion";
            this.gridColumn24.FieldName = "Observacion";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 18;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblTotalRegistros);
            this.groupControl1.Controls.Add(this.btnConsultarMasInformacion);
            this.groupControl1.Controls.Add(this.cboMes);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1742, 52);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(961, 29);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRegistros.TabIndex = 59;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // btnConsultarMasInformacion
            // 
            this.btnConsultarMasInformacion.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultar_16x16;
            this.btnConsultarMasInformacion.Location = new System.Drawing.Point(1213, 24);
            this.btnConsultarMasInformacion.Name = "btnConsultarMasInformacion";
            this.btnConsultarMasInformacion.Size = new System.Drawing.Size(118, 23);
            this.btnConsultarMasInformacion.TabIndex = 58;
            this.btnConsultarMasInformacion.Text = "Más Información";
            this.btnConsultarMasInformacion.Click += new System.EventHandler(this.btnConsultarMasInformacion_Click);
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(157, 26);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 57;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(128, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 56;
            this.labelControl2.Text = "Mes:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(273, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "N° Documento:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(352, 26);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Size = new System.Drawing.Size(106, 20);
            this.txtNumero.TabIndex = 48;
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(57, 26);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 47;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 29);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 46;
            this.labelControl7.Text = "Periodo:";
            // 
            // frmRegCambioDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1742, 557);
            this.Controls.Add(this.gcCambio);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegCambioDevolucion";
            this.Text = "Cambios y Devoluciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegCambioDevolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCambio)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcCambio;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCambio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem aprobarsolicitudToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem recibirdevolucionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularrecibimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cambiarclienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportarexcelToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.SimpleButton btnConsultarMasInformacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
    }
}