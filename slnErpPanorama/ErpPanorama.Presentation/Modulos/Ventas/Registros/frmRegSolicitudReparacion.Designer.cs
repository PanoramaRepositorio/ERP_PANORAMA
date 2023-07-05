namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegSolicitudReparacion
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcCambio = new DevExpress.XtraGrid.GridControl();
            this.gvCambio = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recibirdevolucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularrecibimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1100, 24);
            this.tlbMenu.TabIndex = 26;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcCambio
            // 
            this.gcCambio.ContextMenuStrip = this.mnuContextual;
            this.gcCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCambio.Location = new System.Drawing.Point(0, 76);
            this.gcCambio.MainView = this.gvCambio;
            this.gcCambio.Name = "gcCambio";
            this.gcCambio.Size = new System.Drawing.Size(1100, 414);
            this.gcCambio.TabIndex = 29;
            this.gcCambio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCambio});
            // 
            // gvCambio
            // 
            this.gvCambio.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn5,
            this.gridColumn16,
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn14,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn13,
            this.gridColumn4});
            this.gvCambio.GridControl = this.gcCambio;
            this.gvCambio.GroupPanelText = "Resultado de la Busqueda";
            this.gvCambio.Name = "gvCambio";
            this.gvCambio.OptionsView.ColumnAutoWidth = false;
            this.gvCambio.OptionsView.ShowGroupPanel = false;
            this.gvCambio.DoubleClick += new System.EventHandler(this.gvCambio_DoubleClick);
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IdEmpresa";
            this.gridColumn10.FieldName = "IdEmpresa";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdCambio";
            this.gridColumn5.FieldName = "IdCambio";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "IdTienda";
            this.gridColumn16.FieldName = "IdTienda";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Empresa";
            this.gridColumn12.FieldName = "RazonSocial";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tienda";
            this.gridColumn6.FieldName = "DescTienda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 100;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Periodo";
            this.gridColumn14.FieldName = "Periodo";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Documento";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
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
            this.gridColumn3.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "N° Pedido";
            this.gridColumn1.FieldName = "NumeroPedido";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cliente";
            this.gridColumn8.FieldName = "DescCliente";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 250;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Moneda";
            this.gridColumn9.FieldName = "CodMoneda";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Total";
            this.gridColumn11.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "Total";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Recibido";
            this.gridColumn13.FieldName = "FlagRecibido";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            this.gridColumn13.Width = 60;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboMes);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1100, 52);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(157, 26);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 57;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(128, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 56;
            this.labelControl2.Text = "Mes:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(273, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "N° Documento:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(352, 26);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Size = new System.Drawing.Size(106, 20);
            this.txtNumero.TabIndex = 48;
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(57, 26);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 47;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 29);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 46;
            this.labelControl7.Text = "Periodo:";
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recibirdevolucionToolStripMenuItem,
            this.anularrecibimientoToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(183, 48);
            // 
            // recibirdevolucionToolStripMenuItem
            // 
            this.recibirdevolucionToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.RecibirDevolucion_16x16;
            this.recibirdevolucionToolStripMenuItem.Name = "recibirdevolucionToolStripMenuItem";
            this.recibirdevolucionToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.recibirdevolucionToolStripMenuItem.Text = "Recibir Devolución";
            this.recibirdevolucionToolStripMenuItem.Click += new System.EventHandler(this.recibirdevolucionToolStripMenuItem_Click);
            // 
            // anularrecibimientoToolStripMenuItem
            // 
            this.anularrecibimientoToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.AnularRecibimiento_16x16;
            this.anularrecibimientoToolStripMenuItem.Name = "anularrecibimientoToolStripMenuItem";
            this.anularrecibimientoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.anularrecibimientoToolStripMenuItem.Text = "Anular Recibimiento";
            this.anularrecibimientoToolStripMenuItem.Click += new System.EventHandler(this.anulardevolucionToolStripMenuItem_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdTipoDocumento";
            this.gridColumn4.FieldName = "IdTipoDocumento";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // frmRegSolicitudReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 490);
            this.Controls.Add(this.gcCambio);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegSolicitudReparacion";
            this.Text = "Solicitud de Reparación";
            this.Load += new System.EventHandler(this.frmRegSolicitudReparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcCambio;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCambio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem recibirdevolucionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularrecibimientoToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}