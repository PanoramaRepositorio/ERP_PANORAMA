namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    partial class frmRegEstadoCuentaProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegEstadoCuentaProveedor));
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.btnCredito = new DevExpress.XtraEditors.SimpleButton();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.btnPago = new DevExpress.XtraEditors.SimpleButton();
            this.gvEstadoCuentaProveedor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEstadoCuentaProveedor = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuentaProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuentaProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(741, 82);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(170, 20);
            this.txtTipoCliente.TabIndex = 84;
            // 
            // btnCredito
            // 
            this.btnCredito.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Add_16x16;
            this.btnCredito.Location = new System.Drawing.Point(97, 80);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(76, 22);
            this.btnCredito.TabIndex = 86;
            this.btnCredito.Text = "Cargo";
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(947, 24);
            this.tlbMenu.TabIndex = 81;
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(623, 24);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(123, 20);
            this.cboSituacion.TabIndex = 83;
            this.cboSituacion.EditValueChanged += new System.EventHandler(this.cboSituacion_EditValueChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(752, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 78;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnConsultar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnConsultar_KeyPress);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(579, 27);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(36, 13);
            this.labelControl21.TabIndex = 82;
            this.labelControl21.Text = "Motivo:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 73;
            this.labelControl5.Text = "Cliente:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboProveedor);
            this.groupControl1.Controls.Add(this.cboSituacion);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(947, 52);
            this.groupControl1.TabIndex = 82;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboProveedor
            // 
            this.cboProveedor.Location = new System.Drawing.Point(64, 24);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProveedor.Properties.NullText = "";
            this.cboProveedor.Size = new System.Drawing.Size(509, 20);
            this.cboProveedor.TabIndex = 90;
            this.cboProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboProveedor_KeyPress);
            // 
            // btnPago
            // 
            this.btnPago.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPago.ImageOptions.Image")));
            this.btnPago.Location = new System.Drawing.Point(8, 80);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(83, 22);
            this.btnPago.TabIndex = 85;
            this.btnPago.Text = "Pago";
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // gvEstadoCuentaProveedor
            // 
            this.gvEstadoCuentaProveedor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn12});
            this.gvEstadoCuentaProveedor.GridControl = this.gcEstadoCuentaProveedor;
            this.gvEstadoCuentaProveedor.GroupPanelText = "Resultado de la Busqueda";
            this.gvEstadoCuentaProveedor.Name = "gvEstadoCuentaProveedor";
            this.gvEstadoCuentaProveedor.OptionsView.ColumnAutoWidth = false;
            this.gvEstadoCuentaProveedor.OptionsView.ShowGroupPanel = false;
            this.gvEstadoCuentaProveedor.DoubleClick += new System.EventHandler(this.gvEstadoCuentaProveedor_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdEmpresa";
            this.gridColumn5.FieldName = "IdEmpresa";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "N° Correlativo";
            this.gridColumn6.FieldName = "IdEstadoCuentaProveedor";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Periodo";
            this.gridColumn1.FieldName = "Periodo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Documento";
            this.gridColumn2.FieldName = "NumeroDocumento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "F. Crédito";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "F. Depósito";
            this.gridColumn10.FieldName = "FechaDeposito";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "F. Vencimiento";
            this.gridColumn9.FieldName = "FechaVencimiento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Concepto";
            this.gridColumn4.FieldName = "Concepto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 374;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Importe US$";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Importe";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 90;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tipo";
            this.gridColumn7.FieldName = "TipoMovimiento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPedido";
            this.gridColumn11.FieldName = "IdPedido";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdCuentaBancoDetalle";
            this.gridColumn12.FieldName = "IdCuentaBancoDetalle";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gcEstadoCuentaProveedor
            // 
            this.gcEstadoCuentaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcEstadoCuentaProveedor.Location = new System.Drawing.Point(1, 108);
            this.gcEstadoCuentaProveedor.MainView = this.gvEstadoCuentaProveedor;
            this.gcEstadoCuentaProveedor.Name = "gcEstadoCuentaProveedor";
            this.gcEstadoCuentaProveedor.Size = new System.Drawing.Size(947, 393);
            this.gcEstadoCuentaProveedor.TabIndex = 83;
            this.gcEstadoCuentaProveedor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEstadoCuentaProveedor});
            // 
            // frmRegEstadoCuentaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 503);
            this.Controls.Add(this.txtTipoCliente);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.gcEstadoCuentaProveedor);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegEstadoCuentaProveedor";
            this.Text = "Estado de Cuenta Proveedor";
            this.Load += new System.EventHandler(this.frmRegEstadoCuentaProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuentaProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuentaProveedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private DevExpress.XtraEditors.SimpleButton btnCredito;
        private ControlUser.UIToolBar tlbMenu;
        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnPago;
        public DevExpress.XtraEditors.LookUpEdit cboProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEstadoCuentaProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.GridControl gcEstadoCuentaProveedor;
    }
}