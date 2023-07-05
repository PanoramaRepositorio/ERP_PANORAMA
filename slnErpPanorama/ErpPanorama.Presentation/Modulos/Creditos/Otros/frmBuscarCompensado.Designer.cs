namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    partial class frmBuscarCompensado
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
            this.gcEstadoCuentaCliente = new DevExpress.XtraGrid.GridControl();
            this.gvEstadoCuentaCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIdDocumentoVenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGrupoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuentaCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuentaCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // gcEstadoCuentaCliente
            // 
            this.gcEstadoCuentaCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEstadoCuentaCliente.Location = new System.Drawing.Point(0, 0);
            this.gcEstadoCuentaCliente.MainView = this.gvEstadoCuentaCliente;
            this.gcEstadoCuentaCliente.Name = "gcEstadoCuentaCliente";
            this.gcEstadoCuentaCliente.Size = new System.Drawing.Size(1107, 364);
            this.gcEstadoCuentaCliente.TabIndex = 62;
            this.gcEstadoCuentaCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEstadoCuentaCliente});
            // 
            // gvEstadoCuentaCliente
            // 
            this.gvEstadoCuentaCliente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn11,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gcIdDocumentoVenta,
            this.gcGrupoPago,
            this.gridColumn12});
            this.gvEstadoCuentaCliente.GridControl = this.gcEstadoCuentaCliente;
            this.gvEstadoCuentaCliente.GroupPanelText = "Resultado de la Busqueda";
            this.gvEstadoCuentaCliente.Name = "gvEstadoCuentaCliente";
            this.gvEstadoCuentaCliente.OptionsSelection.MultiSelect = true;
            this.gvEstadoCuentaCliente.OptionsView.ColumnAutoWidth = false;
            this.gvEstadoCuentaCliente.OptionsView.ShowFooter = true;
            this.gvEstadoCuentaCliente.OptionsView.ShowGroupPanel = false;
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
            this.gridColumn6.FieldName = "IdEstadoCuentaCliente";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 62;
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
            this.gridColumn2.Width = 119;
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
            this.gridColumn3.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "F. Vencimiento";
            this.gridColumn9.FieldName = "FechaVencimiento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
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
            this.gridColumn4.Width = 271;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Importe";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Importe";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 82;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tipo";
            this.gridColumn7.FieldName = "TipoMovimiento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 35;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Días";
            this.gridColumn10.FieldName = "DiasVencimiento";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 44;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "IdMoneda";
            this.gridColumn13.FieldName = "IdMoneda";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Moneda";
            this.gridColumn14.FieldName = "DescMoneda";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            this.gridColumn14.Width = 49;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "IdMotivo";
            this.gridColumn15.FieldName = "IdMotivo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Motivo";
            this.gridColumn16.FieldName = "DescMotivo";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPedido";
            this.gridColumn11.FieldName = "IdPedido";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "IdMovimientoCaja";
            this.gridColumn17.FieldName = "IdMovimientoCaja";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "IdCuentaBancoDetalle";
            this.gridColumn18.FieldName = "IdCuentaBancoDetalle";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Vendedor";
            this.gridColumn19.FieldName = "DescPersona";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 10;
            this.gridColumn19.Width = 162;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "UsuarioRegistro";
            this.gridColumn20.FieldName = "UsuarioRegistro";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "F.Registro";
            this.gridColumn21.FieldName = "FechaRegistro";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Saldo";
            this.gridColumn22.DisplayFormat.FormatString = "#,#.00";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "Saldo";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "FlagEstado";
            this.gridColumn23.FieldName = "FlagEstado";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            // 
            // gcIdDocumentoVenta
            // 
            this.gcIdDocumentoVenta.Caption = "IdDocumentoVenta";
            this.gcIdDocumentoVenta.FieldName = "IdDocumentoVenta";
            this.gcIdDocumentoVenta.Name = "gcIdDocumentoVenta";
            this.gcIdDocumentoVenta.OptionsColumn.AllowEdit = false;
            this.gcIdDocumentoVenta.OptionsColumn.AllowFocus = false;
            // 
            // gcGrupoPago
            // 
            this.gcGrupoPago.Caption = "Grupo Pago";
            this.gcGrupoPago.FieldName = "GrupoPago";
            this.gcGrupoPago.Name = "gcGrupoPago";
            this.gcGrupoPago.OptionsColumn.AllowEdit = false;
            this.gcGrupoPago.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdEstadoCuentaClientePago";
            this.gridColumn12.FieldName = "IdEstadoCuentaClientePago";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // frmBuscarCompensado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 364);
            this.Controls.Add(this.gcEstadoCuentaCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarCompensado";
            this.Text = "Historial de Compensados";
            this.Load += new System.EventHandler(this.frmBuscarCompensado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuentaCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuentaCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcEstadoCuentaCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEstadoCuentaCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gcIdDocumentoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcGrupoPago;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}