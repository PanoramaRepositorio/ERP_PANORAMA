namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    partial class frmAsignarProveedorEC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarProveedorEC));
            this.txTotal = new DevExpress.XtraEditors.TextEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvFacturaCompra = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcFacturaCompra = new DevExpress.XtraGrid.GridControl();
            this.cboProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTipoCambio = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkPorFactura = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPorFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txTotal
            // 
            this.txTotal.Location = new System.Drawing.Point(306, 316);
            this.txTotal.Name = "txTotal";
            this.txTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txTotal.Properties.Appearance.Options.UseFont = true;
            this.txTotal.Properties.Mask.EditMask = "n2";
            this.txTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txTotal.Properties.ReadOnly = true;
            this.txTotal.Size = new System.Drawing.Size(100, 20);
            this.txTotal.TabIndex = 108;
            this.txTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txTotal_KeyPress);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultar_16x16;
            this.btnConsultar.Location = new System.Drawing.Point(431, 1);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 107;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnConsultar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnConsultar_KeyPress);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Pagar";
            this.gridColumn1.FieldName = "FlagPagado";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Importe Pago";
            this.gridColumn27.FieldName = "ImportePago";
            this.gridColumn27.Name = "gridColumn27";
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Situacion Pago";
            this.gridColumn26.FieldName = "SituacionPago";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 5;
            this.gridColumn26.Width = 87;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Nacional";
            this.gridColumn18.FieldName = "FlagNacional";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Recibido";
            this.gridColumn12.FieldName = "FlagRecibido";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Importe";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Importe";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 95;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Forma Pago";
            this.gridColumn4.FieldName = "FormaPago";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "F.Vencimiento";
            this.gridColumn25.FieldName = "FechaVencimiento";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "F. Recepción";
            this.gridColumn13.FieldName = "FechaRecepcion";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Documento";
            this.gridColumn5.FieldName = "NumeroDocumento";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdFacturaCompra";
            this.gridColumn2.FieldName = "IdFacturaCompra";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gvFacturaCompra
            // 
            this.gvFacturaCompra.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn13,
            this.gridColumn25,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn18,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn1});
            this.gvFacturaCompra.GridControl = this.gcFacturaCompra;
            this.gvFacturaCompra.Name = "gvFacturaCompra";
            this.gvFacturaCompra.OptionsSelection.MultiSelect = true;
            this.gvFacturaCompra.OptionsView.ColumnAutoWidth = false;
            this.gvFacturaCompra.OptionsView.ShowGroupPanel = false;
            // 
            // gcFacturaCompra
            // 
            this.gcFacturaCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturaCompra.Location = new System.Drawing.Point(3, 30);
            this.gcFacturaCompra.MainView = this.gvFacturaCompra;
            this.gcFacturaCompra.Name = "gcFacturaCompra";
            this.gcFacturaCompra.Size = new System.Drawing.Size(584, 257);
            this.gcFacturaCompra.TabIndex = 106;
            this.gcFacturaCompra.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFacturaCompra});
            // 
            // cboProveedor
            // 
            this.cboProveedor.Location = new System.Drawing.Point(61, 3);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProveedor.Properties.NullText = "";
            this.cboProveedor.Size = new System.Drawing.Size(364, 20);
            this.cboProveedor.TabIndex = 105;
            this.cboProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboProveedor_KeyPress);
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.Location = new System.Drawing.Point(109, 319);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(25, 13);
            this.lblTipoCambio.TabIndex = 102;
            this.lblTipoCambio.Text = "T.C.:";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.EditValue = "0.00";
            this.txtTipoCambio.Location = new System.Drawing.Point(140, 316);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCambio.Properties.DisplayFormat.FormatString = "n3";
            this.txtTipoCambio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTipoCambio.Properties.Mask.EditMask = "n3";
            this.txtTipoCambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoCambio.Properties.Mask.ShowPlaceHolders = false;
            this.txtTipoCambio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(54, 20);
            this.txtTipoCambio.TabIndex = 101;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(493, 313);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 100;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(412, 313);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 99;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(2, 299);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 13);
            this.labelControl6.TabIndex = 97;
            this.labelControl6.Text = "Observacion:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(71, 293);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Properties.MaxLength = 100;
            this.txtObservacion.Size = new System.Drawing.Size(575, 20);
            this.txtObservacion.TabIndex = 98;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(2, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(57, 13);
            this.labelControl5.TabIndex = 96;
            this.labelControl5.Text = "Proveedor :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(215, 319);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 109;
            this.labelControl1.Text = "Total Importe:";
            // 
            // chkPorFactura
            // 
            this.chkPorFactura.Location = new System.Drawing.Point(512, 3);
            this.chkPorFactura.Name = "chkPorFactura";
            this.chkPorFactura.Properties.Caption = "Por Factura";
            this.chkPorFactura.Size = new System.Drawing.Size(75, 19);
            this.chkPorFactura.TabIndex = 110;
            this.chkPorFactura.CheckedChanged += new System.EventHandler(this.chkPorFactura_CheckedChanged);
            // 
            // frmAsignarProveedorEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 342);
            this.Controls.Add(this.chkPorFactura);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txTotal);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.gcFacturaCompra);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.lblTipoCambio);
            this.Controls.Add(this.txtTipoCambio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.labelControl5);
            this.Name = "frmAsignarProveedorEC";
            this.Text = "Asignar Pago - Estado Cuenta Proveedor";
            this.Load += new System.EventHandler(this.frmAsignarProveedorEC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPorFactura.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txTotal;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturaCompra;
        private DevExpress.XtraGrid.GridControl gcFacturaCompra;
        public DevExpress.XtraEditors.LookUpEdit cboProveedor;
        private DevExpress.XtraEditors.LabelControl lblTipoCambio;
        public DevExpress.XtraEditors.TextEdit txtTipoCambio;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkPorFactura;
    }
}