namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegNotaIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegNotaIngreso));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.optHangTag = new System.Windows.Forms.RadioButton();
            this.optCodigo = new System.Windows.Forms.RadioButton();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.gcMovimientoAlmacen = new DevExpress.XtraGrid.GridControl();
            this.gvMovimientoAlmacen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMovimientoAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientoAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1374, 24);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.optHangTag);
            this.groupControl1.Controls.Add(this.optCodigo);
            this.groupControl1.Controls.Add(this.labelControl28);
            this.groupControl1.Controls.Add(this.labelControl27);
            this.groupControl1.Controls.Add(this.lblDescripcion);
            this.groupControl1.Controls.Add(this.txtCodigo);
            this.groupControl1.Controls.Add(this.cboTienda);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboMes);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.cboAlmacen);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1374, 58);
            this.groupControl1.TabIndex = 20;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // optHangTag
            // 
            this.optHangTag.AutoSize = true;
            this.optHangTag.Location = new System.Drawing.Point(1273, 31);
            this.optHangTag.Name = "optHangTag";
            this.optHangTag.Size = new System.Drawing.Size(71, 17);
            this.optHangTag.TabIndex = 68;
            this.optHangTag.Text = "&Hang Tag";
            this.optHangTag.UseVisualStyleBackColor = true;
            this.optHangTag.CheckedChanged += new System.EventHandler(this.optHangTag_CheckedChanged);
            // 
            // optCodigo
            // 
            this.optCodigo.AutoSize = true;
            this.optCodigo.Checked = true;
            this.optCodigo.Location = new System.Drawing.Point(1190, 31);
            this.optCodigo.Name = "optCodigo";
            this.optCodigo.Size = new System.Drawing.Size(58, 17);
            this.optCodigo.TabIndex = 66;
            this.optCodigo.TabStop = true;
            this.optCodigo.Text = "&Código";
            this.optCodigo.UseVisualStyleBackColor = true;
            this.optCodigo.CheckedChanged += new System.EventHandler(this.optCodigo_CheckedChanged);
            // 
            // labelControl28
            // 
            this.labelControl28.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl28.Appearance.Options.UseFont = true;
            this.labelControl28.Location = new System.Drawing.Point(1343, 33);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(13, 13);
            this.labelControl28.TabIndex = 69;
            this.labelControl28.Text = "F6";
            // 
            // labelControl27
            // 
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(1248, 33);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(13, 13);
            this.labelControl27.TabIndex = 67;
            this.labelControl27.Text = "F5";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(1005, 33);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(37, 13);
            this.lblDescripcion.TabIndex = 64;
            this.lblDescripcion.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(1048, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Size = new System.Drawing.Size(137, 20);
            this.txtCodigo.TabIndex = 65;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(311, 30);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(147, 20);
            this.cboTienda.TabIndex = 53;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(269, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 52;
            this.labelControl3.Text = "Tienda:";
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(152, 30);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.DropDownRows = 12;
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 51;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(123, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "Mes:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(52, 30);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 49;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(6, 33);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 48;
            this.labelControl7.Text = "Periodo:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(849, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "N° N/I:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(889, 30);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Size = new System.Drawing.Size(71, 20);
            this.txtNumero.TabIndex = 22;
            this.txtNumero.EditValueChanged += new System.EventHandler(this.txtNumero_EditValueChanged);
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(756, 29);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(76, 21);
            this.btnConsultar.TabIndex = 21;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Location = new System.Drawing.Point(514, 30);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.DropDownRows = 10;
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Size = new System.Drawing.Size(236, 20);
            this.cboAlmacen.TabIndex = 20;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(464, 33);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Almacén:";
            // 
            // gcMovimientoAlmacen
            // 
            this.gcMovimientoAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMovimientoAlmacen.Location = new System.Drawing.Point(0, 82);
            this.gcMovimientoAlmacen.MainView = this.gvMovimientoAlmacen;
            this.gcMovimientoAlmacen.Name = "gcMovimientoAlmacen";
            this.gcMovimientoAlmacen.Size = new System.Drawing.Size(1374, 413);
            this.gcMovimientoAlmacen.TabIndex = 21;
            this.gcMovimientoAlmacen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMovimientoAlmacen});
            // 
            // gvMovimientoAlmacen
            // 
            this.gvMovimientoAlmacen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
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
            this.gvMovimientoAlmacen.GridControl = this.gcMovimientoAlmacen;
            this.gvMovimientoAlmacen.GroupPanelText = "Resultado de la Busqueda";
            this.gvMovimientoAlmacen.Name = "gvMovimientoAlmacen";
            this.gvMovimientoAlmacen.OptionsView.ShowGroupPanel = false;
            this.gvMovimientoAlmacen.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvMovimientoAlmacen_RowStyle);
            this.gvMovimientoAlmacen.DoubleClick += new System.EventHandler(this.gvMovimientoAlmacen_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdMovimientoAlmacen";
            this.gridColumn5.FieldName = "IdMovimientoAlmacen";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Almacén";
            this.gridColumn1.FieldName = "DescAlmacen";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 169;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° N/I";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 93;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 78;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Motivo";
            this.gridColumn4.FieldName = "DescMotivo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 219;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Documento";
            this.gridColumn6.FieldName = "CodTipoDocumento";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 78;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "N° Documento";
            this.gridColumn7.FieldName = "NumeroDocumento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 99;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Referencia";
            this.gridColumn8.FieldName = "Referencia";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 104;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Observación";
            this.gridColumn9.FieldName = "Observaciones";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 136;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IdAlmacen";
            this.gridColumn10.FieldName = "IdAlmacenOrigen";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdMotivo";
            this.gridColumn11.FieldName = "IdMotivo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Origen";
            this.gridColumn12.FieldName = "DescAlmacenDestino";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 233;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "IdMovimientoAlmacenReferencia";
            this.gridColumn13.FieldName = "IdMovimientoAlmacenReferencia";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Eliminado por";
            this.gridColumn14.FieldName = "UsuarioElimina";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 10;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Estado";
            this.gridColumn15.FieldName = "FlagEstado";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 9;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Obs. Elimina";
            this.gridColumn16.FieldName = "ObservacionElimina";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 11;
            // 
            // frmRegNotaIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 495);
            this.Controls.Add(this.gcMovimientoAlmacen);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegNotaIngreso";
            this.Text = "Nota de Ingreso - Mantenimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegNotaIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMovimientoAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientoAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        private DevExpress.XtraGrid.GridControl gcMovimientoAlmacen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMovimientoAlmacen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.RadioButton optHangTag;
        private System.Windows.Forms.RadioButton optCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}