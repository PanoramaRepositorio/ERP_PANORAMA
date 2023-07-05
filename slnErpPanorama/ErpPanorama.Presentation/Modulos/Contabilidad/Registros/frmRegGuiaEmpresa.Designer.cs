namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    partial class frmRegGuiaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegGuiaEmpresa));
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvDocumento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDocumento = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vistapreliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imprimirguiatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selecciontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirunaguiatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renumerartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarrazonsocialtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumento)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 65;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Forma Pago";
            this.gridColumn2.FieldName = "DescFormaPago";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Cliente";
            this.gridColumn4.FieldName = "DescCliente";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 280;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Número";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 65;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Serie";
            this.gridColumn9.FieldName = "Serie";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 55;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Doc";
            this.gridColumn11.FieldName = "CodTipoDocumento";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            this.gridColumn11.Width = 65;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Fecha";
            this.gridColumn5.FieldName = "Fecha";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Razón Social";
            this.gridColumn12.FieldName = "RazonSocial";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdDocumentoVenta";
            this.gridColumn3.FieldName = "IdDocumentoVenta";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gvDocumento
            // 
            this.gvDocumento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn12,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn1});
            this.gvDocumento.GridControl = this.gcDocumento;
            this.gvDocumento.Name = "gvDocumento";
            this.gvDocumento.OptionsSelection.MultiSelect = true;
            this.gvDocumento.OptionsView.ColumnAutoWidth = false;
            this.gvDocumento.OptionsView.ShowGroupPanel = false;
            this.gvDocumento.DoubleClick += new System.EventHandler(this.gvDocumento_DoubleClick);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Moneda";
            this.gridColumn6.FieldName = "CodMoneda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 50;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tienda";
            this.gridColumn10.FieldName = "DescTienda";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 117;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdTienda";
            this.gridColumn1.FieldName = "IdTienda";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gcDocumento
            // 
            this.gcDocumento.ContextMenuStrip = this.mnuContextual;
            this.gcDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDocumento.Location = new System.Drawing.Point(0, 59);
            this.gcDocumento.MainView = this.gvDocumento;
            this.gcDocumento.Name = "gcDocumento";
            this.gcDocumento.Size = new System.Drawing.Size(1107, 394);
            this.gcDocumento.TabIndex = 65;
            this.gcDocumento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocumento});
            // 
            // mnuContextual
            // 
            this.mnuContextual.BackColor = System.Drawing.Color.White;
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vistapreliminarToolStripMenuItem,
            this.toolStripSeparator1,
            this.imprimirguiatoolStripMenuItem,
            this.toolStripSeparator3,
            this.selecciontoolStripMenuItem,
            this.toolStripSeparator2,
            this.renumerartoolStripMenuItem,
            this.cambiarrazonsocialtoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(285, 132);
            // 
            // vistapreliminarToolStripMenuItem
            // 
            this.vistapreliminarToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.vistapreliminarToolStripMenuItem.Name = "vistapreliminarToolStripMenuItem";
            this.vistapreliminarToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.vistapreliminarToolStripMenuItem.Text = "Vista Preliminar";
            this.vistapreliminarToolStripMenuItem.Click += new System.EventHandler(this.vistapreliminarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(281, 6);
            // 
            // imprimirguiatoolStripMenuItem
            // 
            this.imprimirguiatoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.imprimirguiatoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirguiatoolStripMenuItem.Image")));
            this.imprimirguiatoolStripMenuItem.Name = "imprimirguiatoolStripMenuItem";
            this.imprimirguiatoolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.imprimirguiatoolStripMenuItem.Text = "Imprimir Guía de Remisión - Por Cliente";
            this.imprimirguiatoolStripMenuItem.Click += new System.EventHandler(this.imprimirguiatoolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(281, 6);
            // 
            // selecciontoolStripMenuItem
            // 
            this.selecciontoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirunaguiatoolStripMenuItem});
            this.selecciontoolStripMenuItem.Name = "selecciontoolStripMenuItem";
            this.selecciontoolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.selecciontoolStripMenuItem.Text = "Imprimir Selección";
            // 
            // imprimirunaguiatoolStripMenuItem
            // 
            this.imprimirunaguiatoolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.imprimirunaguiatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Print_16x16;
            this.imprimirunaguiatoolStripMenuItem.Name = "imprimirunaguiatoolStripMenuItem";
            this.imprimirunaguiatoolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.imprimirunaguiatoolStripMenuItem.Text = "Guía de Remisión";
            this.imprimirunaguiatoolStripMenuItem.Click += new System.EventHandler(this.imprimirunaguiatoolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(281, 6);
            // 
            // renumerartoolStripMenuItem
            // 
            this.renumerartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renumerartoolStripMenuItem.Image")));
            this.renumerartoolStripMenuItem.Name = "renumerartoolStripMenuItem";
            this.renumerartoolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.renumerartoolStripMenuItem.Text = "Renumerar N° Documento";
            this.renumerartoolStripMenuItem.Click += new System.EventHandler(this.renumerartoolStripMenuItem_Click);
            // 
            // cambiarrazonsocialtoolStripMenuItem
            // 
            this.cambiarrazonsocialtoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Clientes_16x16;
            this.cambiarrazonsocialtoolStripMenuItem.Name = "cambiarrazonsocialtoolStripMenuItem";
            this.cambiarrazonsocialtoolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.cambiarrazonsocialtoolStripMenuItem.Text = "Cambiar Razón Social";
            this.cambiarrazonsocialtoolStripMenuItem.Click += new System.EventHandler(this.cambiarrazonsocialtoolStripMenuItem_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(277, 7);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(191, 7);
            this.deHasta.Name = "deHasta";
            this.deHasta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHasta.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deHasta.Properties.ShowPopupShadow = false;
            this.deHasta.Properties.ShowToday = false;
            this.deHasta.Size = new System.Drawing.Size(80, 20);
            this.deHasta.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(153, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(53, 7);
            this.deDesde.Name = "deDesde";
            this.deDesde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDesde.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deDesde.Properties.ShowPopupShadow = false;
            this.deDesde.Properties.ShowToday = false;
            this.deDesde.Size = new System.Drawing.Size(80, 20);
            this.deDesde.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prgFactura);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.deHasta);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.deDesde);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 35);
            this.panel1.TabIndex = 64;
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(613, 6);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(201, 21);
            this.prgFactura.TabIndex = 66;
            this.prgFactura.Visible = false;
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1107, 24);
            this.tlbMenu.TabIndex = 63;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // frmRegGuiaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 453);
            this.Controls.Add(this.gcDocumento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegGuiaEmpresa";
            this.Text = "Guía de Remisión Empresa - Traslados";
            this.Load += new System.EventHandler(this.frmRegGuiaEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumento)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.GridControl gcDocumento;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem vistapreliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem imprimirguiatoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem selecciontoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirunaguiatoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem renumerartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarrazonsocialtoolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private System.Windows.Forms.Panel panel1;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}