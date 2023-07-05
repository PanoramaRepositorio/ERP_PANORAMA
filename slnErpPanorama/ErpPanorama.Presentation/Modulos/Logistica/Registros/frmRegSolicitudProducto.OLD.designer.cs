namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegSolicitudProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegSolicitudProducto));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gcSolicitudProducto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enviarAlmanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImprimirAsesoriatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recibirsolicitudtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSolicitudProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudProducto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1334, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
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
            this.groupControl1.Size = new System.Drawing.Size(1334, 52);
            this.groupControl1.TabIndex = 21;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(156, 25);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 57;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(127, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 56;
            this.labelControl2.Text = "Mes:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(282, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "N° Documento:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(361, 25);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Size = new System.Drawing.Size(106, 20);
            this.txtNumero.TabIndex = 48;
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(57, 25);
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
            this.labelControl7.Location = new System.Drawing.Point(11, 28);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 46;
            this.labelControl7.Text = "Periodo:";
            // 
            // gcSolicitudProducto
            // 
            this.gcSolicitudProducto.ContextMenuStrip = this.mnuContextual;
            this.gcSolicitudProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSolicitudProducto.Location = new System.Drawing.Point(0, 76);
            this.gcSolicitudProducto.MainView = this.gvSolicitudProducto;
            this.gcSolicitudProducto.Name = "gcSolicitudProducto";
            this.gcSolicitudProducto.Size = new System.Drawing.Size(1334, 414);
            this.gcSolicitudProducto.TabIndex = 22;
            this.gcSolicitudProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSolicitudProducto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarAlmanceToolStripMenuItem,
            this.ImprimirAsesoriatoolStripMenuItem,
            this.recibirsolicitudtoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(202, 92);
            // 
            // enviarAlmanceToolStripMenuItem
            // 
            this.enviarAlmanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enviarAlmanceToolStripMenuItem.Image")));
            this.enviarAlmanceToolStripMenuItem.Name = "enviarAlmanceToolStripMenuItem";
            this.enviarAlmanceToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.enviarAlmanceToolStripMenuItem.Text = "Enviar Almacen";
            this.enviarAlmanceToolStripMenuItem.Click += new System.EventHandler(this.enviarAlmanceToolStripMenuItem_Click);
            // 
            // ImprimirAsesoriatoolStripMenuItem
            // 
            this.ImprimirAsesoriatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Print_16x16;
            this.ImprimirAsesoriatoolStripMenuItem.Name = "ImprimirAsesoriatoolStripMenuItem";
            this.ImprimirAsesoriatoolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ImprimirAsesoriatoolStripMenuItem.Text = "Imprimir como Asesoria";
            this.ImprimirAsesoriatoolStripMenuItem.Click += new System.EventHandler(this.ImprimirAsesoriatoolStripMenuItem_Click);
            // 
            // recibirsolicitudtoolStripMenuItem
            // 
            this.recibirsolicitudtoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.SolicitudProducto_32x32;
            this.recibirsolicitudtoolStripMenuItem.Name = "recibirsolicitudtoolStripMenuItem";
            this.recibirsolicitudtoolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.recibirsolicitudtoolStripMenuItem.Text = "Recibir Solicitud";
            this.recibirsolicitudtoolStripMenuItem.Click += new System.EventHandler(this.recibirsolicitudtoolStripMenuItem_Click);
            // 
            // gvSolicitudProducto
            // 
            this.gvSolicitudProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gvSolicitudProducto.GridControl = this.gcSolicitudProducto;
            this.gvSolicitudProducto.GroupPanelText = "Resultado de la Busqueda";
            this.gvSolicitudProducto.Name = "gvSolicitudProducto";
            this.gvSolicitudProducto.OptionsView.ColumnAutoWidth = false;
            this.gvSolicitudProducto.OptionsView.ShowGroupPanel = false;
            this.gvSolicitudProducto.DoubleClick += new System.EventHandler(this.gvSolicitudProducto_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdSolicitudProducto";
            this.gridColumn5.FieldName = "IdSolicitudProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Almacén Origen";
            this.gridColumn6.FieldName = "DescAlmacen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "CodTipoDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 70;
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
            this.gridColumn3.FieldName = "FechaSolicitud";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Solicitante";
            this.gridColumn4.FieldName = "Solicitante";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 300;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tienda Destino";
            this.gridColumn8.FieldName = "DescTiendaDestino";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Almacen Destino";
            this.gridColumn9.FieldName = "DescAlmacenDestino";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Enviado";
            this.gridColumn7.FieldName = "FlagEnviado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 52;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "F. Envío";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "FechaEnvio";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 123;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Recibido";
            this.gridColumn11.FieldName = "FlagRecibido";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 47;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "F.Recibido";
            this.gridColumn12.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.FieldName = "FechaRecibido";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "N° N/S";
            this.gridColumn13.FieldName = "NumeroNS";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Picking N/S";
            this.gridColumn14.FieldName = "PickingNS";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "FechaPicking";
            this.gridColumn15.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn15.FieldName = "FechaPicking";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Observación";
            this.gridColumn16.FieldName = "Observacion";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            this.gridColumn16.Width = 150;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "F.Delivery";
            this.gridColumn17.FieldName = "FechaDelivery";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            // 
            // frmRegSolicitudProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 490);
            this.Controls.Add(this.gcSolicitudProducto);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegSolicitudProducto";
            this.Text = "Solicitud Producto - Mantenimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegSolicitudProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudProducto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcSolicitudProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSolicitudProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem enviarAlmanceToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStripMenuItem ImprimirAsesoriatoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private System.Windows.Forms.ToolStripMenuItem recibirsolicitudtoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
    }
}