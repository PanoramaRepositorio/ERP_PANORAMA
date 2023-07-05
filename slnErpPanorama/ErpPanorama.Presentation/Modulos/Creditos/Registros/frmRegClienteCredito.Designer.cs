namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    partial class frmRegClienteCredito
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcClienteCredito = new DevExpress.XtraGrid.GridControl();
            this.gvClienteCredito = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.txtClienteCredito = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteCredito.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1312, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcClienteCredito
            // 
            this.gcClienteCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcClienteCredito.Location = new System.Drawing.Point(0, 79);
            this.gcClienteCredito.MainView = this.gvClienteCredito;
            this.gcClienteCredito.Name = "gcClienteCredito";
            this.gcClienteCredito.Size = new System.Drawing.Size(1312, 432);
            this.gcClienteCredito.TabIndex = 49;
            this.gcClienteCredito.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClienteCredito});
            // 
            // gvClienteCredito
            // 
            this.gvClienteCredito.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn14,
            this.gridColumn15});
            this.gvClienteCredito.GridControl = this.gcClienteCredito;
            this.gvClienteCredito.Name = "gvClienteCredito";
            this.gvClienteCredito.OptionsView.ColumnAutoWidth = false;
            this.gvClienteCredito.OptionsView.ShowGroupPanel = false;
            this.gvClienteCredito.DoubleClick += new System.EventHandler(this.gvClienteCredito_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdClienteCredito";
            this.gridColumn2.FieldName = "IdClienteCredito";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdCliente";
            this.gridColumn25.FieldName = "IdCliente";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdClasificacionCliente";
            this.gridColumn3.FieldName = "IdClasificacionCliente";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "AbrevDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "N° Documento";
            this.gridColumn23.FieldName = "NumeroDocumento";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Cliente";
            this.gridColumn18.FieldName = "DescCliente";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 350;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Clasifica";
            this.gridColumn6.FieldName = "AbrevClasifica";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Fecha Aprob.";
            this.gridColumn4.FieldName = "FechaAprobacion";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Linea Credito";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "LineaCredito";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Linea Credito Utilizada";
            this.gridColumn11.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "LineaCreditoUtilizada";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            this.gridColumn11.Width = 120;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Linea Credito Disponible";
            this.gridColumn12.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "LineaCreditoDisponible";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 7;
            this.gridColumn12.Width = 120;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "N° Dias";
            this.gridColumn13.FieldName = "NumeroDias";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            this.gridColumn13.Width = 60;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tipo Cliente";
            this.gridColumn5.FieldName = "DescTipoCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            this.gridColumn5.Width = 121;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ruta";
            this.gridColumn8.FieldName = "DescRuta";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboMotivo);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.txtClienteCredito);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1312, 55);
            this.groupControl1.TabIndex = 48;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(636, 29);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(123, 20);
            this.cboMotivo.TabIndex = 81;
            this.cboMotivo.EditValueChanged += new System.EventHandler(this.cboMotivo_EditValueChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(592, 32);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(36, 13);
            this.labelControl21.TabIndex = 80;
            this.labelControl21.Text = "Motivo:";
            // 
            // txtClienteCredito
            // 
            this.txtClienteCredito.Location = new System.Drawing.Point(49, 29);
            this.txtClienteCredito.Name = "txtClienteCredito";
            this.txtClienteCredito.Size = new System.Drawing.Size(502, 20);
            this.txtClienteCredito.TabIndex = 3;
            this.txtClienteCredito.EditValueChanged += new System.EventHandler(this.txtClienteCredito_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Cliente:";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn9.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn9.Caption = "Creado por";
            this.gridColumn9.FieldName = "UsuarioRegistro";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn10.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn10.Caption = "F.Creación";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "FechaRegistro";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 12;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn14.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn14.Caption = "Modificado Por";
            this.gridColumn14.FieldName = "UsuarioModifica";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 13;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn15.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn15.Caption = "F.Modifica";
            this.gridColumn15.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn15.FieldName = "FechaModifica";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 14;
            this.gridColumn15.Width = 100;
            // 
            // frmRegClienteCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 511);
            this.Controls.Add(this.gcClienteCredito);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegClienteCredito";
            this.Text = "Cliente Credito - Mantenimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegClienteCredito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClienteCredito.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcClienteCredito;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClienteCredito;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtClienteCredito;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
    }
}