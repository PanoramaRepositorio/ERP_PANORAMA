namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManTardanzaPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTardanzaPersonal));
            this.gcHorarioSalida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHorarioIngreso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip();
            this.justificartardanzatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTotalMinutos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.gcMarcacion = new DevExpress.XtraGrid.GridControl();
            this.gvMarcacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcApeNom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optDetalle = new System.Windows.Forms.RadioButton();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMinutos.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHorarioSalida
            // 
            this.gcHorarioSalida.Caption = "H. Salida";
            this.gcHorarioSalida.FieldName = "HorarioSalida";
            this.gcHorarioSalida.Name = "gcHorarioSalida";
            this.gcHorarioSalida.OptionsColumn.AllowEdit = false;
            this.gcHorarioSalida.OptionsColumn.AllowFocus = false;
            this.gcHorarioSalida.Visible = true;
            this.gcHorarioSalida.VisibleIndex = 10;
            this.gcHorarioSalida.Width = 113;
            // 
            // gcHorarioIngreso
            // 
            this.gcHorarioIngreso.Caption = "H. Ingreso";
            this.gcHorarioIngreso.FieldName = "HorarioIngreso";
            this.gcHorarioIngreso.Name = "gcHorarioIngreso";
            this.gcHorarioIngreso.OptionsColumn.AllowEdit = false;
            this.gcHorarioIngreso.OptionsColumn.AllowFocus = false;
            this.gcHorarioIngreso.Visible = true;
            this.gcHorarioIngreso.VisibleIndex = 9;
            this.gcHorarioIngreso.Width = 107;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tardanza";
            this.gridColumn13.FieldName = "Tardanza";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            this.gridColumn13.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Fecha";
            this.gridColumn12.FieldName = "Fecha";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 85;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDescuento.EditValue = "0";
            this.txtDescuento.Location = new System.Drawing.Point(810, 566);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescuento.Properties.Appearance.Options.UseFont = true;
            this.txtDescuento.Properties.DisplayFormat.FormatString = "n0";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n0";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.ReadOnly = true;
            this.txtDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescuento.Size = new System.Drawing.Size(76, 20);
            this.txtDescuento.TabIndex = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Apoyo";
            this.gridColumn4.FieldName = "FlagApoyo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 8;
            this.gridColumn4.Width = 41;
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.justificartardanzatoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(171, 26);
            // 
            // justificartardanzatoolStripMenuItem
            // 
            this.justificartardanzatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.HorasTrabajadas_16x16;
            this.justificartardanzatoolStripMenuItem.Name = "justificartardanzatoolStripMenuItem";
            this.justificartardanzatoolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.justificartardanzatoolStripMenuItem.Text = "Justificar Tardanza";
            // 
            // txtTotalMinutos
            // 
            this.txtTotalMinutos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalMinutos.EditValue = "0";
            this.txtTotalMinutos.Location = new System.Drawing.Point(700, 566);
            this.txtTotalMinutos.Name = "txtTotalMinutos";
            this.txtTotalMinutos.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalMinutos.Properties.Appearance.Options.UseFont = true;
            this.txtTotalMinutos.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalMinutos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalMinutos.Properties.Mask.EditMask = "n0";
            this.txtTotalMinutos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalMinutos.Properties.ReadOnly = true;
            this.txtTotalMinutos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalMinutos.Size = new System.Drawing.Size(56, 20);
            this.txtTotalMinutos.TabIndex = 102;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(659, 569);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(35, 13);
            this.labelControl27.TabIndex = 93;
            this.labelControl27.Text = "Total :";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1289, 25);
            this.toolStrip1.TabIndex = 83;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolstpExportarExcel.Image")));
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(23, 22);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(28, 567);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(57, 13);
            this.lblTotalRegistros.TabIndex = 86;
            this.lblTotalRegistros.Text = "0 Registros ";
            // 
            // gcMarcacion
            // 
            this.gcMarcacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcMarcacion.Location = new System.Drawing.Point(0, 86);
            this.gcMarcacion.MainView = this.gvMarcacion;
            this.gcMarcacion.Name = "gcMarcacion";
            this.gcMarcacion.Size = new System.Drawing.Size(1289, 474);
            this.gcMarcacion.TabIndex = 85;
            this.gcMarcacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMarcacion});
            // 
            // gvMarcacion
            // 
            this.gvMarcacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn1,
            this.gcApeNom,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn13,
            this.gcHorarioIngreso,
            this.gcHorarioSalida,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn8});
            this.gvMarcacion.CustomizationFormBounds = new System.Drawing.Rectangle(742, 407, 210, 172);
            this.gvMarcacion.GridControl = this.gcMarcacion;
            this.gvMarcacion.GroupPanelText = "Resultado de la Busqueda";
            this.gvMarcacion.Name = "gvMarcacion";
            this.gvMarcacion.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.gvMarcacion.OptionsSelection.MultiSelect = true;
            this.gvMarcacion.OptionsView.ColumnAutoWidth = false;
            this.gvMarcacion.OptionsView.ShowGroupPanel = false;
            this.gvMarcacion.ColumnFilterChanged += new System.EventHandler(this.gvMarcacion_ColumnFilterChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Dni";
            this.gridColumn1.FieldName = "Dni";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 92;
            // 
            // gcApeNom
            // 
            this.gcApeNom.Caption = "Apellidos y Nombres";
            this.gcApeNom.FieldName = "ApeNom";
            this.gcApeNom.Name = "gcApeNom";
            this.gcApeNom.OptionsColumn.AllowEdit = false;
            this.gcApeNom.OptionsColumn.AllowFocus = false;
            this.gcApeNom.Visible = true;
            this.gcApeNom.VisibleIndex = 2;
            this.gcApeNom.Width = 320;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "Ingreso";
            this.gridColumn3.FieldName = "Ingreso";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 84;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridColumn6.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn6.Caption = "Salida";
            this.gridColumn6.FieldName = "Salida";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 91;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sueldo";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Sueldo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.Caption = "Descuento";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Descuento";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 63;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1289, 58);
            this.groupControl1.TabIndex = 104;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optDetalle);
            this.groupBox1.Controls.Add(this.optResumen);
            this.groupBox1.Location = new System.Drawing.Point(1092, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 29);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // optDetalle
            // 
            this.optDetalle.AutoSize = true;
            this.optDetalle.Location = new System.Drawing.Point(91, 8);
            this.optDetalle.Name = "optDetalle";
            this.optDetalle.Size = new System.Drawing.Size(58, 17);
            this.optDetalle.TabIndex = 1;
            this.optDetalle.TabStop = true;
            this.optDetalle.Text = "Detalle";
            this.optDetalle.UseVisualStyleBackColor = true;
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Location = new System.Drawing.Point(7, 8);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(69, 17);
            this.optResumen.TabIndex = 0;
            this.optResumen.TabStop = true;
            this.optResumen.Text = "Resumen";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(420, 33);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 77;
            this.labelControl7.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.EditValue = "";
            this.txtDescripcion.Location = new System.Drawing.Point(484, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(601, 20);
            this.txtDescripcion.TabIndex = 76;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(212, 27);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 29;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(162, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Fecha Fin: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(56, 27);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 27;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(8, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(51, 13);
            this.lblFecha.TabIndex = 26;
            this.lblFecha.Text = "Fecha Ini: ";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(318, 26);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(76, 21);
            this.btnConsultar.TabIndex = 21;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // frmManTardanzaPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 598);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtTotalMinutos);
            this.Controls.Add(this.labelControl27);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.gcMarcacion);
            this.Name = "frmManTardanzaPersonal";
            this.Text = "frmManTardanzaPersonal";
            this.Load += new System.EventHandler(this.frmManTardanzaPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMinutos.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn gcHorarioSalida;
        private DevExpress.XtraGrid.Columns.GridColumn gcHorarioIngreso;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.TextEdit txtDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem justificartardanzatoolStripMenuItem;
        private DevExpress.XtraEditors.TextEdit txtTotalMinutos;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraGrid.GridControl gcMarcacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarcacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcApeNom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.RadioButton optResumen;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
    }
}