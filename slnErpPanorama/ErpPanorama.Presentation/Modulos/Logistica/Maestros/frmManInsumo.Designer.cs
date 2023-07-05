namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManInsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManInsumo));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageActivo = new DevExpress.XtraTab.XtraTabPage();
            this.gcInsumo = new DevExpress.XtraGrid.GridControl();
            this.gvInsumo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboPagina = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtCantidadRegistros = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageInactivo = new DevExpress.XtraTab.XtraTabPage();
            this.gcInsumoInactivo = new DevExpress.XtraGrid.GridControl();
            this.gvInsumoInactivo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTotalRegistrosInactivos = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.txtInsumoInactivo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageActivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcInsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.xtraTabPageInactivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcInsumoInactivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInsumoInactivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsumoInactivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1435, 24);
            this.tlbMenu.TabIndex = 1;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 24);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageActivo;
            this.xtraTabControl1.Size = new System.Drawing.Size(1435, 555);
            this.xtraTabControl1.TabIndex = 57;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageActivo,
            this.xtraTabPageInactivo});
            // 
            // xtraTabPageActivo
            // 
            this.xtraTabPageActivo.Controls.Add(this.picImage);
            this.xtraTabPageActivo.Controls.Add(this.gcInsumo);
            this.xtraTabPageActivo.Controls.Add(this.groupControl1);
            this.xtraTabPageActivo.Name = "xtraTabPageActivo";
            this.xtraTabPageActivo.Size = new System.Drawing.Size(1429, 527);
            this.xtraTabPageActivo.Text = "Activos";
            // 
            // gcInsumo
            // 
            this.gcInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcInsumo.Location = new System.Drawing.Point(3, 59);
            this.gcInsumo.MainView = this.gvInsumo;
            this.gcInsumo.Name = "gcInsumo";
            this.gcInsumo.Size = new System.Drawing.Size(1090, 460);
            this.gcInsumo.TabIndex = 49;
            this.gcInsumo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInsumo});
            // 
            // gvInsumo
            // 
            this.gvInsumo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn24,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn12,
            this.gridColumn13});
            this.gvInsumo.GridControl = this.gcInsumo;
            this.gvInsumo.Name = "gvInsumo";
            this.gvInsumo.OptionsView.ColumnAutoWidth = false;
            this.gvInsumo.OptionsView.ShowGroupPanel = false;
            this.gvInsumo.DoubleClick += new System.EventHandler(this.gvInsumo_DoubleClick);
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Código";
            this.gridColumn23.FieldName = "IdInsumo";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 0;
            this.gridColumn23.Width = 59;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Descripción";
            this.gridColumn18.FieldName = "Descripcion";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 1;
            this.gridColumn18.Width = 464;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "U.M";
            this.gridColumn10.FieldName = "Abreviatura";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "Precio S/";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PrecioAB";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Observación";
            this.gridColumn3.FieldName = "Observacion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 163;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Clasificación";
            this.gridColumn1.FieldName = "DescInsumoClasificacion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 278;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Stock";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 5;
            this.gridColumn12.Width = 54;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Precio";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.cboPagina);
            this.groupControl1.Controls.Add(this.txtCodigo);
            this.groupControl1.Controls.Add(this.txtCantidadRegistros);
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.btnNext);
            this.groupControl1.Controls.Add(this.btnLast);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.btnPrevious);
            this.groupControl1.Controls.Add(this.btnFirst);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1426, 55);
            this.groupControl1.TabIndex = 48;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // cboPagina
            // 
            this.cboPagina.Location = new System.Drawing.Point(1202, 23);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPagina.Size = new System.Drawing.Size(46, 20);
            this.cboPagina.TabIndex = 55;
            this.cboPagina.Visible = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(1070, 23);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.DisplayFormat.FormatString = "f0";
            this.txtCodigo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCodigo.Properties.Mask.EditMask = "f0";
            this.txtCodigo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCodigo.Properties.MaxLength = 10;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 48;
            this.txtCodigo.ToolTip = "Periodo";
            this.txtCodigo.Visible = false;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.EditValue = "18";
            this.txtCantidadRegistros.Location = new System.Drawing.Point(1249, 23);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Properties.Mask.EditMask = "\\d{0,3}";
            this.txtCantidadRegistros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCantidadRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(30, 20);
            this.txtCantidadRegistros.TabIndex = 52;
            this.txtCantidadRegistros.Visible = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(1009, 20);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1140, 23);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 53;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(1171, 23);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 54;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">>";
            this.btnLast.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Descripción:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(1027, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Código:";
            this.labelControl2.Visible = false;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(1109, 23);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 51;
            this.btnPrevious.Tag = "";
            this.btnPrevious.Text = "<";
            this.btnPrevious.Visible = false;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(1078, 23);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 50;
            this.btnFirst.Text = "<<";
            this.btnFirst.Visible = false;
            // 
            // xtraTabPageInactivo
            // 
            this.xtraTabPageInactivo.Controls.Add(this.gcInsumoInactivo);
            this.xtraTabPageInactivo.Controls.Add(this.lblTotalRegistrosInactivos);
            this.xtraTabPageInactivo.Controls.Add(this.groupControl2);
            this.xtraTabPageInactivo.Name = "xtraTabPageInactivo";
            this.xtraTabPageInactivo.Size = new System.Drawing.Size(1194, 527);
            this.xtraTabPageInactivo.Text = "Inactivos";
            // 
            // gcInsumoInactivo
            // 
            this.gcInsumoInactivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcInsumoInactivo.Location = new System.Drawing.Point(3, 59);
            this.gcInsumoInactivo.MainView = this.gvInsumoInactivo;
            this.gcInsumoInactivo.Name = "gcInsumoInactivo";
            this.gcInsumoInactivo.Size = new System.Drawing.Size(1139, 460);
            this.gcInsumoInactivo.TabIndex = 52;
            this.gcInsumoInactivo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInsumoInactivo});
            // 
            // gvInsumoInactivo
            // 
            this.gvInsumoInactivo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn11});
            this.gvInsumoInactivo.GridControl = this.gcInsumoInactivo;
            this.gvInsumoInactivo.Name = "gvInsumoInactivo";
            this.gvInsumoInactivo.OptionsView.ColumnAutoWidth = false;
            this.gvInsumoInactivo.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Código";
            this.gridColumn4.FieldName = "IdInsumo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "Descripcion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 464;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "U.M";
            this.gridColumn6.FieldName = "Abreviatura";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn7.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn7.Caption = "Precio S/";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "PrecioAB";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Observación";
            this.gridColumn9.FieldName = "Observacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 113;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Clasificación";
            this.gridColumn11.FieldName = "DescInsumoClasificacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 278;
            // 
            // lblTotalRegistrosInactivos
            // 
            this.lblTotalRegistrosInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistrosInactivos.Location = new System.Drawing.Point(13, 541);
            this.lblTotalRegistrosInactivos.Name = "lblTotalRegistrosInactivos";
            this.lblTotalRegistrosInactivos.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRegistrosInactivos.TabIndex = 51;
            this.lblTotalRegistrosInactivos.Text = "0 Registros encontrados";
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl2.Controls.Add(this.btnConsultar);
            this.groupControl2.Controls.Add(this.textEdit1);
            this.groupControl2.Controls.Add(this.txtInsumoInactivo);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1133, 55);
            this.groupControl2.TabIndex = 49;
            this.groupControl2.Text = "Criterios de Busqueda";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(589, 30);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 57;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(695, 30);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.DisplayFormat.FormatString = "f0";
            this.textEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit1.Properties.Mask.EditMask = "f0";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.MaxLength = 10;
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 48;
            this.textEdit1.ToolTip = "Periodo";
            this.textEdit1.Visible = false;
            // 
            // txtInsumoInactivo
            // 
            this.txtInsumoInactivo.Location = new System.Drawing.Point(81, 30);
            this.txtInsumoInactivo.Name = "txtInsumoInactivo";
            this.txtInsumoInactivo.Size = new System.Drawing.Size(502, 20);
            this.txtInsumoInactivo.TabIndex = 3;
            this.txtInsumoInactivo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInsumoInactivo_KeyUp);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Descripción:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(674, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(15, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "ID:";
            this.labelControl4.Visible = false;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(1097, 59);
            this.picImage.Margin = new System.Windows.Forms.Padding(1);
            this.picImage.MinimumSize = new System.Drawing.Size(85, 85);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(331, 460);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 65;
            this.picImage.TabStop = false;
            // 
            // frmManInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 579);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmManInsumo";
            this.Text = "Insumo - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManInsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageActivo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcInsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.xtraTabPageInactivo.ResumeLayout(false);
            this.xtraTabPageInactivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcInsumoInactivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInsumoInactivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsumoInactivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageActivo;
        private DevExpress.XtraEditors.ComboBoxEdit cboPagina;
        private DevExpress.XtraEditors.TextEdit txtCantidadRegistros;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraGrid.GridControl gcInsumo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInsumo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageInactivo;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistrosInactivos;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit txtInsumoInactivo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl gcInsumoInactivo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInsumoInactivo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.PictureBox picImage;
    }
}