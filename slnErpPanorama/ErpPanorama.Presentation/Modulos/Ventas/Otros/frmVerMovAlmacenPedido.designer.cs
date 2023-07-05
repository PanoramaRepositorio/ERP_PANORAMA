namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmVerMovAlmacenPedido
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
            this.gcMovimientoAlmacen = new DevExpress.XtraGrid.GridControl();
            this.gvMovimientoAlmacen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcMovimientoAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientoAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMovimientoAlmacen
            // 
            this.gcMovimientoAlmacen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMovimientoAlmacen.Location = new System.Drawing.Point(0, 0);
            this.gcMovimientoAlmacen.MainView = this.gvMovimientoAlmacen;
            this.gcMovimientoAlmacen.Name = "gcMovimientoAlmacen";
            this.gcMovimientoAlmacen.Size = new System.Drawing.Size(906, 271);
            this.gcMovimientoAlmacen.TabIndex = 24;
            this.gcMovimientoAlmacen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMovimientoAlmacen});
            // 
            // gvMovimientoAlmacen
            // 
            this.gvMovimientoAlmacen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn21});
            this.gvMovimientoAlmacen.GridControl = this.gcMovimientoAlmacen;
            this.gvMovimientoAlmacen.GroupPanelText = "Resultado de la Busqueda";
            this.gvMovimientoAlmacen.Name = "gvMovimientoAlmacen";
            this.gvMovimientoAlmacen.OptionsView.ColumnAutoWidth = false;
            this.gvMovimientoAlmacen.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdMovimientoAlmacen";
            this.gridColumn5.FieldName = "IdMovimientoAlmacen";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Periodo";
            this.gridColumn10.FieldName = "Periodo";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Almacén Origen";
            this.gridColumn1.FieldName = "DescAlmacen";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 152;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° N/S";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
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
            this.gridColumn3.Width = 67;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Motivo";
            this.gridColumn4.FieldName = "DescMotivo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 187;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Documento";
            this.gridColumn6.FieldName = "CodTipoDocumento";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Width = 39;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "N° Documento";
            this.gridColumn7.FieldName = "NumeroDocumento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Width = 95;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Referencia";
            this.gridColumn8.FieldName = "Referencia";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Width = 88;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Observación";
            this.gridColumn9.FieldName = "Observaciones";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Width = 230;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdAlmacenOrigen";
            this.gridColumn11.FieldName = "IdAlmacen";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdMotivo";
            this.gridColumn12.FieldName = "IdMotivo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "FlagRecibido";
            this.gridColumn13.FieldName = "FlagRecibido";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Almacén Destino";
            this.gridColumn14.FieldName = "DescAlmacenDestino";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 5;
            this.gridColumn14.Width = 173;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Recibido";
            this.gridColumn15.FieldName = "FlagRecibido";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            this.gridColumn15.Width = 48;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Usuario";
            this.gridColumn16.FieldName = "Usuario";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Delivery";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Width = 50;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "F. Delivery";
            this.gridColumn18.FieldName = "FechaDelivery";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 8;
            this.gridColumn18.Width = 66;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Físico";
            this.gridColumn19.FieldName = "FlagRecibidoFisico";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 7;
            this.gridColumn19.Width = 37;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Situación Pedido";
            this.gridColumn21.FieldName = "DescSituacionPedido";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            // 
            // frmVerMovAlmacenPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 271);
            this.Controls.Add(this.gcMovimientoAlmacen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerMovAlmacenPedido";
            this.Text = "Nota de Salida Generadas";
            this.Load += new System.EventHandler(this.frmVerMovAlmacenPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMovimientoAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientoAlmacen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMovimientoAlmacen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMovimientoAlmacen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
    }
}