namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManDescuentoClienteMayorista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDescuentoClienteMayorista));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcDescuentoClienteMayorista = new DevExpress.XtraGrid.GridControl();
            this.gvDescuentoClienteMayorista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboLineaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcDescuentoClienteMayorista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDescuentoClienteMayorista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(663, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcDescuentoClienteMayorista
            // 
            this.gcDescuentoClienteMayorista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDescuentoClienteMayorista.Location = new System.Drawing.Point(0, 59);
            this.gcDescuentoClienteMayorista.MainView = this.gvDescuentoClienteMayorista;
            this.gcDescuentoClienteMayorista.Name = "gcDescuentoClienteMayorista";
            this.gcDescuentoClienteMayorista.Size = new System.Drawing.Size(663, 437);
            this.gcDescuentoClienteMayorista.TabIndex = 27;
            this.gcDescuentoClienteMayorista.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDescuentoClienteMayorista});
            // 
            // gvDescuentoClienteMayorista
            // 
            this.gvDescuentoClienteMayorista.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn4,
            this.gridColumn12});
            this.gvDescuentoClienteMayorista.GridControl = this.gcDescuentoClienteMayorista;
            this.gvDescuentoClienteMayorista.Name = "gvDescuentoClienteMayorista";
            this.gvDescuentoClienteMayorista.OptionsView.ColumnAutoWidth = false;
            this.gvDescuentoClienteMayorista.OptionsView.ShowGroupPanel = false;
            this.gvDescuentoClienteMayorista.DoubleClick += new System.EventHandler(this.gvDescuentoClienteMayorista_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdDescuentoClienteMayorista";
            this.gridColumn1.FieldName = "IdDescuentoClienteFinal";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdFormaPago";
            this.gridColumn8.FieldName = "IdFormaPago";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Forma Pago";
            this.gridColumn6.FieldName = "DescFormaPago";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdLineaProducto";
            this.gridColumn5.FieldName = "IdLineaProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Linea Producto";
            this.gridColumn3.FieldName = "DescLineaProducto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 130;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Monto Min US$";
            this.gridColumn7.DisplayFormat.FormatString = "#0,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "MontoMin";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 85;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Monto Max US$";
            this.gridColumn10.DisplayFormat.FormatString = "#0,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "MontoMax";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 85;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "% Dscto";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "PorDescuento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Pre-Venta";
            this.gridColumn11.FieldName = "FlagPreVenta";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Estado";
            this.gridColumn4.FieldName = "FlagEstado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 20;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn12.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn12.Caption = "Venta PV";
            this.gridColumn12.FieldName = "FlagVenta";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 6;
            this.gridColumn12.Width = 69;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(71, 30);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(145, 20);
            this.cboFormaPago.TabIndex = 29;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Forma Pago:";
            // 
            // cboLineaProducto
            // 
            this.cboLineaProducto.Location = new System.Drawing.Point(304, 30);
            this.cboLineaProducto.Name = "cboLineaProducto";
            this.cboLineaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLineaProducto.Properties.NullText = "";
            this.cboLineaProducto.Size = new System.Drawing.Size(250, 20);
            this.cboLineaProducto.TabIndex = 31;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(223, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "Linea Producto:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(560, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 35;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmManDescuentoClienteMayorista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 495);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboLineaProducto);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcDescuentoClienteMayorista);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDescuentoClienteMayorista";
            this.Text = "Escala de Descuento de Ventas";
            this.Load += new System.EventHandler(this.frmManDescuentoClienteMayorista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDescuentoClienteMayorista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDescuentoClienteMayorista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcDescuentoClienteMayorista;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDescuentoClienteMayorista;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboLineaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}