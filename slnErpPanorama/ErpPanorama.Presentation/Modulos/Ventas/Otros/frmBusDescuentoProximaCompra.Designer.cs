namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusDescuentoProximaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusDescuentoProximaCompra));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcDocumentoVenta = new DevExpress.XtraGrid.GridControl();
            this.gvDocumentoVenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtNumeroReferencia = new DevExpress.XtraEditors.TextEdit();
            this.txtSerieReferencia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.cboDocumentoReferencia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verdetalletoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerieReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumentoReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.groupControl1);
            this.grdDatos.Controls.Add(this.txtNumeroReferencia);
            this.grdDatos.Controls.Add(this.txtSerieReferencia);
            this.grdDatos.Controls.Add(this.labelControl19);
            this.grdDatos.Controls.Add(this.cboDocumentoReferencia);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Controls.Add(this.btnBuscar);
            this.grdDatos.Controls.Add(this.txtDescCliente);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(1215, 330);
            this.grdDatos.TabIndex = 45;
            this.grdDatos.Text = "Ubicación";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gcDocumentoVenta);
            this.groupControl1.Location = new System.Drawing.Point(0, 49);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1214, 276);
            this.groupControl1.TabIndex = 54;
            this.groupControl1.Text = "Comprobantes con Promoción";
            // 
            // gcDocumentoVenta
            // 
            this.gcDocumentoVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDocumentoVenta.Location = new System.Drawing.Point(2, 20);
            this.gcDocumentoVenta.MainView = this.gvDocumentoVenta;
            this.gcDocumentoVenta.Name = "gcDocumentoVenta";
            this.gcDocumentoVenta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo});
            this.gcDocumentoVenta.Size = new System.Drawing.Size(1210, 254);
            this.gcDocumentoVenta.TabIndex = 53;
            this.gcDocumentoVenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocumentoVenta});
            this.gcDocumentoVenta.DoubleClick += new System.EventHandler(this.gvDocumentoVenta_DoubleClick);
            // 
            // gvDocumentoVenta
            // 
            this.gvDocumentoVenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn12,
            this.gridColumn2,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gvDocumentoVenta.GridControl = this.gcDocumentoVenta;
            this.gvDocumentoVenta.Name = "gvDocumentoVenta";
            this.gvDocumentoVenta.OptionsView.ColumnAutoWidth = false;
            this.gvDocumentoVenta.OptionsView.ShowGroupPanel = false;
            this.gvDocumentoVenta.DoubleClick += new System.EventHandler(this.gvDocumentoVenta_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Razón Social";
            this.gridColumn3.FieldName = "RazonSocial";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 200;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdDocumentoVenta";
            this.gridColumn4.FieldName = "IdDocumentoVenta";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdTipoDocumento";
            this.gridColumn12.FieldName = "IdTipoDocumento";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Documento";
            this.gridColumn2.FieldName = "CodTipoDocumento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Serie";
            this.gridColumn10.FieldName = "Serie";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 40;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Numero";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Fecha";
            this.gridColumn13.FieldName = "Fecha";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Cliente";
            this.gridColumn5.FieldName = "DescCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Moneda";
            this.gridColumn6.FieldName = "CodMoneda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Total";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Total";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Vendedor";
            this.gridColumn9.FieldName = "DescVendedor";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            this.gridColumn9.Width = 200;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Caja";
            this.gridColumn11.FieldName = "DescCaja";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "N° Pedido";
            this.gridColumn14.FieldName = "NumeroPedido";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Forma Pago";
            this.gridColumn15.FieldName = "DescFormaPago";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn16.AppearanceCell.Options.UseFont = true;
            this.gridColumn16.Caption = "% Dscto";
            this.gridColumn16.FieldName = "PorcentajeDescuento";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 10;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // txtNumeroReferencia
            // 
            this.txtNumeroReferencia.Location = new System.Drawing.Point(876, 23);
            this.txtNumeroReferencia.Name = "txtNumeroReferencia";
            this.txtNumeroReferencia.Size = new System.Drawing.Size(123, 20);
            this.txtNumeroReferencia.TabIndex = 52;
            this.txtNumeroReferencia.ToolTip = "Presionar ENTER para cargar Documento";
            this.txtNumeroReferencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroReferencia_KeyDown);
            // 
            // txtSerieReferencia
            // 
            this.txtSerieReferencia.Location = new System.Drawing.Point(822, 23);
            this.txtSerieReferencia.Name = "txtSerieReferencia";
            this.txtSerieReferencia.Size = new System.Drawing.Size(38, 20);
            this.txtSerieReferencia.TabIndex = 50;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(866, 26);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(4, 13);
            this.labelControl19.TabIndex = 51;
            this.labelControl19.Text = "-";
            // 
            // cboDocumentoReferencia
            // 
            this.cboDocumentoReferencia.Location = new System.Drawing.Point(772, 23);
            this.cboDocumentoReferencia.Name = "cboDocumentoReferencia";
            this.cboDocumentoReferencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumentoReferencia.Properties.NullText = "";
            this.cboDocumentoReferencia.Size = new System.Drawing.Size(46, 20);
            this.cboDocumentoReferencia.TabIndex = 49;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(696, 26);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(69, 13);
            this.labelControl20.TabIndex = 48;
            this.labelControl20.Text = "Comprobante:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(179, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 46;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(206, 23);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(465, 20);
            this.txtDescCliente.TabIndex = 47;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(91, 23);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(88, 20);
            this.txtNumeroDocumento.TabIndex = 45;
            this.txtNumeroDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(15, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 44;
            this.labelControl5.Text = "Cliente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(981, 338);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(900, 338);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(29, 338);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(138, 13);
            this.lblTotalRegistros.TabIndex = 70;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verdetalletoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(130, 26);
            // 
            // verdetalletoolStripMenuItem
            // 
            this.verdetalletoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verdetalletoolStripMenuItem.Image")));
            this.verdetalletoolStripMenuItem.Name = "verdetalletoolStripMenuItem";
            this.verdetalletoolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verdetalletoolStripMenuItem.Text = "Ver Detalle";
            this.verdetalletoolStripMenuItem.Click += new System.EventHandler(this.verdetalletoolStripMenuItem_Click);
            // 
            // frmBusDescuentoProximaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 373);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusDescuentoProximaCompra";
            this.Text = "Descuento en Próxima Compra";
            this.Load += new System.EventHandler(this.frmBusDescuentoProximaCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerieReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumentoReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtNumeroReferencia;
        private DevExpress.XtraEditors.TextEdit txtSerieReferencia;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        public DevExpress.XtraEditors.LookUpEdit cboDocumentoReferencia;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraGrid.GridControl gcDocumentoVenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumentoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem verdetalletoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
    }
}