namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusProductoStockPreVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusProductoStockPreVenta));
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboPagina = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCantidadRegistros = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Enabled = false;
            this.cboAlmacen.Location = new System.Drawing.Point(66, 50);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Size = new System.Drawing.Size(338, 20);
            this.cboAlmacen.TabIndex = 80;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 79;
            this.labelControl1.Text = "Almacén:";
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(761, 3);
            this.picImage.Margin = new System.Windows.Forms.Padding(1);
            this.picImage.MinimumSize = new System.Drawing.Size(85, 85);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(85, 85);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 78;
            this.picImage.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(219, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 77;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboTienda
            // 
            this.cboTienda.Enabled = false;
            this.cboTienda.Location = new System.Drawing.Point(66, 28);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(147, 20);
            this.cboTienda.TabIndex = 76;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "Tienda:";
            // 
            // cboPagina
            // 
            this.cboPagina.Location = new System.Drawing.Point(483, 485);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPagina.Size = new System.Drawing.Size(46, 20);
            this.cboPagina.TabIndex = 73;
            this.cboPagina.EditValueChanged += new System.EventHandler(this.cboPagina_EditValueChanged);
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.EditValue = "18";
            this.txtCantidadRegistros.Location = new System.Drawing.Point(530, 485);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Properties.Mask.EditMask = "\\d{0,3}";
            this.txtCantidadRegistros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCantidadRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(30, 20);
            this.txtCantidadRegistros.TabIndex = 74;
            this.txtCantidadRegistros.EditValueChanged += new System.EventHandler(this.txtCantidadRegistros_EditValueChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(421, 485);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 71;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(452, 485);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 72;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(390, 485);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 70;
            this.btnPrevious.Tag = "";
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(359, 485);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 69;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(66, 6);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(338, 20);
            this.txtDescripcion.TabIndex = 66;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(13, 9);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(47, 13);
            this.lblPersona.TabIndex = 68;
            this.lblPersona.Text = "Producto:";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "% Dscto";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Descuento";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 7;
            this.gridColumn10.Width = 60;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "PrecioAB S/";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PrecioABSoles";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 70;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "PrecioCD";
            this.gridColumn12.FieldName = "PrecioCD";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "PrecioAB";
            this.gridColumn13.FieldName = "PrecioAB";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn3.Caption = "Stock";
            this.gridColumn3.FieldName = "Cantidad";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ubicación";
            this.gridColumn7.FieldName = "DescUbicacion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "U.M";
            this.gridColumn4.FieldName = "Abreviatura";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 45;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "NombreProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 350;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Código";
            this.gridColumn2.FieldName = "CodigoProveedor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdAlmacen";
            this.gridColumn6.FieldName = "IdAlmacen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdLineaProducto";
            this.gridColumn11.FieldName = "IdLineaProducto";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdProducto";
            this.gridColumn1.FieldName = "IdProducto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn14});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            this.gvProducto.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvProducto_FocusedRowChanged);
            this.gvProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvProducto_KeyDown);
            this.gvProducto.DoubleClick += new System.EventHandler(this.gvProducto_DoubleClick);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "PrecioCD S/";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "PrecioCDSoles";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 70;
            // 
            // gcProducto
            // 
            this.gcProducto.Location = new System.Drawing.Point(0, 92);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(846, 387);
            this.gcProducto.TabIndex = 67;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "FlagNacional";
            this.gridColumn14.FieldName = "FlagNacional";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            // 
            // frmBusProductoStockPreVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 509);
            this.Controls.Add(this.cboAlmacen);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboPagina);
            this.Controls.Add(this.txtCantidadRegistros);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.gcProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusProductoStockPreVenta";
            this.Text = "Búsqueda Producto";
            this.Load += new System.EventHandler(this.frmBusProductoStockPreVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox picImage;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboPagina;
        private DevExpress.XtraEditors.TextEdit txtCantidadRegistros;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}