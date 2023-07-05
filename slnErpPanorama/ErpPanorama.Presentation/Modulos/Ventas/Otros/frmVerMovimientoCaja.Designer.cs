namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmVerMovimientoCaja
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
            this.gcMovimientoCaja = new DevExpress.XtraGrid.GridControl();
            this.gvMovimientoCaja = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalDolares = new DevExpress.XtraEditors.TextEdit();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMovimientoCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientoCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDolares.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMovimientoCaja
            // 
            this.gcMovimientoCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcMovimientoCaja.Location = new System.Drawing.Point(0, 0);
            this.gcMovimientoCaja.MainView = this.gvMovimientoCaja;
            this.gcMovimientoCaja.Name = "gcMovimientoCaja";
            this.gcMovimientoCaja.Size = new System.Drawing.Size(1099, 193);
            this.gcMovimientoCaja.TabIndex = 51;
            this.gcMovimientoCaja.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMovimientoCaja});
            // 
            // gvMovimientoCaja
            // 
            this.gvMovimientoCaja.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn11});
            this.gvMovimientoCaja.GridControl = this.gcMovimientoCaja;
            this.gvMovimientoCaja.Name = "gvMovimientoCaja";
            this.gvMovimientoCaja.OptionsSelection.MultiSelect = true;
            this.gvMovimientoCaja.OptionsView.ColumnAutoWidth = false;
            this.gvMovimientoCaja.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdMovimientoCaja";
            this.gridColumn25.FieldName = "IdMovimientoCaja";
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdTipoDocumento";
            this.gridColumn2.FieldName = "IdTipoDocumento";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "CodTipoDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
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
            this.gridColumn23.Width = 80;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Forma Pago";
            this.gridColumn18.FieldName = "DescFormaPago";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 100;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Condición Pago";
            this.gridColumn10.FieldName = "DescCondicionPago";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 120;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Moneda";
            this.gridColumn4.FieldName = "CodMoneda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "T.C";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "TipoCambio";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 50;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Importe S/";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "ImporteSoles";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn6.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn6.Caption = "Importe US$";
            this.gridColumn6.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "ImporteDolares";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdDocumentoVenta";
            this.gridColumn7.FieldName = "IdDocumentoVenta";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Estado";
            this.gridColumn3.FieldName = "FlagEstado";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Motivo Anulación";
            this.gridColumn9.FieldName = "DescMotivoAnulacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 102;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "N° Cond. Pago";
            this.gridColumn11.FieldName = "NumeroCondicion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 242;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(506, 199);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(87, 20);
            this.txtTotal.TabIndex = 72;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Location = new System.Drawing.Point(465, 202);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(35, 13);
            this.labelControl27.TabIndex = 71;
            this.labelControl27.Text = "Total :";
            // 
            // txtTotalDolares
            // 
            this.txtTotalDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalDolares.EditValue = "0.00";
            this.txtTotalDolares.Location = new System.Drawing.Point(594, 199);
            this.txtTotalDolares.Name = "txtTotalDolares";
            this.txtTotalDolares.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalDolares.Properties.Appearance.Options.UseFont = true;
            this.txtTotalDolares.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalDolares.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalDolares.Properties.Mask.EditMask = "n";
            this.txtTotalDolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalDolares.Properties.ReadOnly = true;
            this.txtTotalDolares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalDolares.Size = new System.Drawing.Size(87, 20);
            this.txtTotalDolares.TabIndex = 72;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(28, 202);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(138, 13);
            this.lblTotalRegistros.TabIndex = 73;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // frmVerMovimientoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 226);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.txtTotalDolares);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.labelControl27);
            this.Controls.Add(this.gcMovimientoCaja);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerMovimientoCaja";
            this.Text = "Consulta de Movimiento Caja";
            this.Load += new System.EventHandler(this.frmVerMovimientoCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMovimientoCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientoCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDolares.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMovimientoCaja;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMovimientoCaja;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.TextEdit txtTotalDolares;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
    }
}