namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    partial class frmConGeneradorCatalogos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConGeneradorCatalogos));
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.cboMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboModelo = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnExportarNavidadPDF = new DevExpress.XtraEditors.SimpleButton();
            this.cboTipoCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblNumExp = new DevExpress.XtraEditors.LabelControl();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotalCantidad = new DevExpress.XtraEditors.TextEdit();
            this.btnExportarPDFxLinea = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportarPDF = new DevExpress.XtraEditors.SimpleButton();
            this.cboSubLinea = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.cboLinea = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verfotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModelo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubLinea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(902, 30);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboMaterial
            // 
            this.cboMaterial.Location = new System.Drawing.Point(713, 30);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMaterial.Properties.NullText = "";
            this.cboMaterial.Size = new System.Drawing.Size(183, 20);
            this.cboMaterial.TabIndex = 15;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(665, 32);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Material:";
            // 
            // cboModelo
            // 
            this.cboModelo.Location = new System.Drawing.Point(509, 30);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModelo.Properties.NullText = "";
            this.cboModelo.Size = new System.Drawing.Size(150, 20);
            this.cboModelo.TabIndex = 5;
            this.cboModelo.EditValueChanged += new System.EventHandler(this.cboModelo_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.radioGroup1);
            this.groupControl1.Controls.Add(this.btnExportarNavidadPDF);
            this.groupControl1.Controls.Add(this.cboTipoCliente);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.lblNumExp);
            this.groupControl1.Controls.Add(this.btnVer);
            this.groupControl1.Controls.Add(this.txtTotalCantidad);
            this.groupControl1.Controls.Add(this.btnExportarPDFxLinea);
            this.groupControl1.Controls.Add(this.btnExportarPDF);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.cboMaterial);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.cboSubLinea);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboModelo);
            this.groupControl1.Controls.Add(this.labelControl19);
            this.groupControl1.Controls.Add(this.cboLinea);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl20);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1207, 86);
            this.groupControl1.TabIndex = 53;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // btnExportarNavidadPDF
            // 
            this.btnExportarNavidadPDF.Image = global::ErpPanorama.Presentation.Properties.Resources.Exportar;
            this.btnExportarNavidadPDF.ImageIndex = 1;
            this.btnExportarNavidadPDF.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarNavidadPDF.Location = new System.Drawing.Point(825, 55);
            this.btnExportarNavidadPDF.Name = "btnExportarNavidadPDF";
            this.btnExportarNavidadPDF.Size = new System.Drawing.Size(214, 23);
            this.btnExportarNavidadPDF.TabIndex = 59;
            this.btnExportarNavidadPDF.Text = "Generar Catalogo Pre-Venta Navidad";
            this.btnExportarNavidadPDF.Click += new System.EventHandler(this.btnExportarNavidadPDF_Click);
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.Location = new System.Drawing.Point(40, 52);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCliente.Properties.NullText = "";
            this.cboTipoCliente.Size = new System.Drawing.Size(213, 20);
            this.cboTipoCliente.TabIndex = 58;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 57;
            this.labelControl2.Text = "Tipo:";
            // 
            // lblNumExp
            // 
            this.lblNumExp.Appearance.BackColor = System.Drawing.Color.White;
            this.lblNumExp.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumExp.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblNumExp.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblNumExp.Location = new System.Drawing.Point(322, 55);
            this.lblNumExp.Name = "lblNumExp";
            this.lblNumExp.Size = new System.Drawing.Size(4, 18);
            this.lblNumExp.TabIndex = 56;
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(895, 56);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 55;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Visible = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.EditValue = "8";
            this.txtTotalCantidad.Location = new System.Drawing.Point(770, 56);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCantidad.Properties.Mask.EditMask = "n";
            this.txtTotalCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCantidad.Size = new System.Drawing.Size(49, 20);
            this.txtTotalCantidad.TabIndex = 54;
            this.txtTotalCantidad.Visible = false;
            // 
            // btnExportarPDFxLinea
            // 
            this.btnExportarPDFxLinea.Image = global::ErpPanorama.Presentation.Properties.Resources.Exportar;
            this.btnExportarPDFxLinea.ImageIndex = 1;
            this.btnExportarPDFxLinea.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarPDFxLinea.Location = new System.Drawing.Point(1045, 56);
            this.btnExportarPDFxLinea.Name = "btnExportarPDFxLinea";
            this.btnExportarPDFxLinea.Size = new System.Drawing.Size(158, 23);
            this.btnExportarPDFxLinea.TabIndex = 53;
            this.btnExportarPDFxLinea.Text = "Generar catálogo x Lineas";
            this.btnExportarPDFxLinea.Click += new System.EventHandler(this.btnExportarPDFxLinea_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Image = global::ErpPanorama.Presentation.Properties.Resources.Exportar;
            this.btnExportarPDF.ImageIndex = 1;
            this.btnExportarPDF.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportarPDF.Location = new System.Drawing.Point(1044, 27);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(158, 23);
            this.btnExportarPDF.TabIndex = 53;
            this.btnExportarPDF.Text = "Generar catálogo x Lista";
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // cboSubLinea
            // 
            this.cboSubLinea.Location = new System.Drawing.Point(309, 30);
            this.cboSubLinea.Name = "cboSubLinea";
            this.cboSubLinea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSubLinea.Properties.NullText = "";
            this.cboSubLinea.Size = new System.Drawing.Size(150, 20);
            this.cboSubLinea.TabIndex = 5;
            this.cboSubLinea.EditValueChanged += new System.EventHandler(this.cboSubLinea_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(258, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "SubLinea:";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(465, 33);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(38, 13);
            this.labelControl19.TabIndex = 4;
            this.labelControl19.Text = "Modelo:";
            // 
            // cboLinea
            // 
            this.cboLinea.Location = new System.Drawing.Point(40, 29);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLinea.Properties.NullText = "";
            this.cboLinea.Size = new System.Drawing.Size(213, 20);
            this.cboLinea.TabIndex = 3;
            this.cboLinea.EditValueChanged += new System.EventHandler(this.cboLinea_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(710, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Stock T. >=";
            this.labelControl1.Visible = false;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(5, 32);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(29, 13);
            this.labelControl20.TabIndex = 2;
            this.labelControl20.Text = "Línea:";
            // 
            // gcProducto
            // 
            this.gcProducto.ContextMenuStrip = this.mnuContextual;
            this.gcProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducto.Location = new System.Drawing.Point(0, 86);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(1207, 421);
            this.gcProducto.TabIndex = 57;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.verfotoToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(160, 70);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exportarToolStripMenuItem.Text = "Exportar a Excel";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.delete;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar Código";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // verfotoToolStripMenuItem
            // 
            this.verfotoToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Foto_16x16;
            this.verfotoToolStripMenuItem.Name = "verfotoToolStripMenuItem";
            this.verfotoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.verfotoToolStripMenuItem.Text = "Ver Imagen";
            this.verfotoToolStripMenuItem.Click += new System.EventHandler(this.verfotoToolStripMenuItem_Click);
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn11});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdProducto";
            this.gridColumn25.FieldName = "IdProducto";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Año";
            this.gridColumn1.FieldName = "Periodo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 40;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Código";
            this.gridColumn23.FieldName = "CodigoProveedor";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Nombre";
            this.gridColumn18.FieldName = "NombreProducto";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 208;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "U.M";
            this.gridColumn10.FieldName = "Abreviatura";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Dscto %";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Descuento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "P. AB US$";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PrecioAB";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 60;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn6.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn6.Caption = "P. CD US$";
            this.gridColumn6.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "PrecioCD";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "P. AB S/";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "PrecioABSoles";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 60;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "P. CD S/";
            this.gridColumn2.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "PrecioCDSoles";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            this.gridColumn2.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Linea";
            this.gridColumn3.FieldName = "DescLineaProducto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Modelo";
            this.gridColumn4.FieldName = "DescModeloProducto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 10;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Material";
            this.gridColumn7.FieldName = "DescMaterial";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 11;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Stock";
            this.gridColumn11.FieldName = "StockCantidades";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            this.gridColumn11.Width = 49;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(309, 51);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Stock Bultos"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Stock Total")});
            this.radioGroup1.Size = new System.Drawing.Size(350, 25);
            this.radioGroup1.TabIndex = 58;
            // 
            // frmConGeneradorCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 507);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmConGeneradorCatalogos";
            this.Text = "Generador de Catálogos por Stock Bultos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConGeneradorCatalogos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModelo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubLinea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        public DevExpress.XtraEditors.LookUpEdit cboMaterial;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.LookUpEdit cboModelo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtTotalCantidad;
        public DevExpress.XtraEditors.SimpleButton btnExportarPDF;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        public DevExpress.XtraEditors.LookUpEdit cboLinea;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        public DevExpress.XtraEditors.SimpleButton btnExportarPDFxLinea;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.LabelControl lblNumExp;
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.SimpleButton btnExportarNavidadPDF;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verfotoToolStripMenuItem;
        public DevExpress.XtraEditors.LookUpEdit cboSubLinea;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}