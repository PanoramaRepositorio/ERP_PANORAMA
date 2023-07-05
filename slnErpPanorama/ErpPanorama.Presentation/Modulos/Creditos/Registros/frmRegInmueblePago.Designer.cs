namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    partial class frmRegInmueblePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInmueblePago));
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboInmueble = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gvInmueblePago = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInmueblePago = new DevExpress.XtraGrid.GridControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldo = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalAbono = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalCargo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboInmueble.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInmueblePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInmueblePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAbono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCargo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(825, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(918, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Desde:";
            this.labelControl2.Visible = false;
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(1097, 24);
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
            this.deHasta.TabIndex = 11;
            this.deHasta.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(1059, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Hasta:";
            this.labelControl3.Visible = false;
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(959, 24);
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
            this.deDesde.TabIndex = 9;
            this.deDesde.Visible = false;
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1012, 24);
            this.tlbMenu.TabIndex = 62;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboInmueble);
            this.groupControl1.Controls.Add(this.deHasta);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.deDesde);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.txtDescCliente);
            this.groupControl1.Controls.Add(this.txtNumeroDocumento);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1012, 52);
            this.groupControl1.TabIndex = 65;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboInmueble
            // 
            this.cboInmueble.Location = new System.Drawing.Point(623, 24);
            this.cboInmueble.Name = "cboInmueble";
            this.cboInmueble.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboInmueble.Properties.NullText = "";
            this.cboInmueble.Size = new System.Drawing.Size(196, 20);
            this.cboInmueble.TabIndex = 83;
            this.cboInmueble.EditValueChanged += new System.EventHandler(this.cboInmueble_EditValueChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(569, 27);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(48, 13);
            this.labelControl21.TabIndex = 82;
            this.labelControl21.Text = "Inmueble:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(160, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 75;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(192, 24);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Size = new System.Drawing.Size(361, 20);
            this.txtDescCliente.TabIndex = 76;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(55, 24);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(99, 20);
            this.txtNumeroDocumento.TabIndex = 74;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 73;
            this.labelControl5.Text = "Cliente:";
            // 
            // gvInmueblePago
            // 
            this.gvInmueblePago.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gvInmueblePago.GridControl = this.gcInmueblePago;
            this.gvInmueblePago.Name = "gvInmueblePago";
            this.gvInmueblePago.OptionsSelection.MultiSelect = true;
            this.gvInmueblePago.OptionsView.ColumnAutoWidth = false;
            this.gvInmueblePago.OptionsView.ShowGroupPanel = false;
            this.gvInmueblePago.DoubleClick += new System.EventHandler(this.gvInmueblePago_DoubleClick);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdInmueblePago";
            this.gridColumn3.FieldName = "IdInmueblePago";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Inmueble";
            this.gridColumn10.FieldName = "DescInmueble";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Width = 178;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "N° Documento";
            this.gridColumn1.FieldName = "NumeroDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "F. Pago";
            this.gridColumn5.FieldName = "FechaPago";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "F.Vencimiento";
            this.gridColumn4.FieldName = "FechaVencimiento";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Concepto";
            this.gridColumn8.FieldName = "Concepto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 275;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Periodo";
            this.gridColumn6.FieldName = "Periodo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mes";
            this.gridColumn2.FieldName = "Mes";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Mes";
            this.gridColumn9.FieldName = "DescMes";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 95;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tipo";
            this.gridColumn11.FieldName = "TipoMovimiento";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Cargo";
            this.gridColumn12.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "CreditoCargo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Abono";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "PagoAbono";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 7;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Saldo";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "Saldo";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gcInmueblePago
            // 
            this.gcInmueblePago.Location = new System.Drawing.Point(0, 74);
            this.gcInmueblePago.MainView = this.gvInmueblePago;
            this.gcInmueblePago.Name = "gcInmueblePago";
            this.gcInmueblePago.Size = new System.Drawing.Size(1012, 384);
            this.gcInmueblePago.TabIndex = 64;
            this.gcInmueblePago.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInmueblePago});
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(642, 467);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 69;
            this.labelControl1.Text = "TOTALES:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.EditValue = "0.00";
            this.txtSaldo.Location = new System.Drawing.Point(861, 464);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Properties.Appearance.Options.UseFont = true;
            this.txtSaldo.Properties.DisplayFormat.FormatString = "n";
            this.txtSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldo.Properties.Mask.EditMask = "n";
            this.txtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldo.Properties.ReadOnly = true;
            this.txtSaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldo.Size = new System.Drawing.Size(70, 20);
            this.txtSaldo.TabIndex = 68;
            // 
            // txtTotalAbono
            // 
            this.txtTotalAbono.EditValue = "0.00";
            this.txtTotalAbono.Location = new System.Drawing.Point(785, 464);
            this.txtTotalAbono.Name = "txtTotalAbono";
            this.txtTotalAbono.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAbono.Properties.Appearance.Options.UseFont = true;
            this.txtTotalAbono.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalAbono.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalAbono.Properties.Mask.EditMask = "n";
            this.txtTotalAbono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalAbono.Properties.ReadOnly = true;
            this.txtTotalAbono.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalAbono.Size = new System.Drawing.Size(70, 20);
            this.txtTotalAbono.TabIndex = 67;
            // 
            // txtTotalCargo
            // 
            this.txtTotalCargo.EditValue = "0.00";
            this.txtTotalCargo.Location = new System.Drawing.Point(709, 464);
            this.txtTotalCargo.Name = "txtTotalCargo";
            this.txtTotalCargo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCargo.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCargo.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalCargo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCargo.Properties.Mask.EditMask = "n";
            this.txtTotalCargo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCargo.Properties.ReadOnly = true;
            this.txtTotalCargo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCargo.Size = new System.Drawing.Size(70, 20);
            this.txtTotalCargo.TabIndex = 66;
            // 
            // frmRegInmueblePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 493);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.txtTotalAbono);
            this.Controls.Add(this.txtTotalCargo);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcInmueblePago);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegInmueblePago";
            this.Text = "Registro de Pago";
            this.Load += new System.EventHandler(this.frmRegInmueblePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboInmueble.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInmueblePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInmueblePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAbono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCargo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.LookUpEdit cboInmueble;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInmueblePago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl gcInmueblePago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSaldo;
        private DevExpress.XtraEditors.TextEdit txtTotalAbono;
        private DevExpress.XtraEditors.TextEdit txtTotalCargo;
    }
}