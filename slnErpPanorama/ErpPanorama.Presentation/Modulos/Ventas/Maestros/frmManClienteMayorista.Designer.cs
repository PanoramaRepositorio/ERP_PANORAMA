namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManClienteMayorista
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
            this.gcCliente = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agendatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vercumpleanostoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seguimientoclientetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.informeporvendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarcelulartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboPagina = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCantidadRegistros = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(980, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // gcCliente
            // 
            this.gcCliente.ContextMenuStrip = this.mnuContextual;
            this.gcCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCliente.Location = new System.Drawing.Point(0, 79);
            this.gcCliente.MainView = this.gvCliente;
            this.gcCliente.Name = "gcCliente";
            this.gcCliente.Size = new System.Drawing.Size(980, 431);
            this.gcCliente.TabIndex = 21;
            this.gcCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCliente});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendatoolStripMenuItem,
            this.vercumpleanostoolStripMenuItem,
            this.seguimientoclientetoolStripMenuItem,
            this.toolStripSeparator1,
            this.informeporvendedorToolStripMenuItem,
            this.exportarcelulartoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(210, 120);
            // 
            // agendatoolStripMenuItem
            // 
            this.agendatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Agenda_16x16;
            this.agendatoolStripMenuItem.Name = "agendatoolStripMenuItem";
            this.agendatoolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.agendatoolStripMenuItem.Text = "Ver Agenda";
            this.agendatoolStripMenuItem.Click += new System.EventHandler(this.agendatoolStripMenuItem_Click);
            // 
            // vercumpleanostoolStripMenuItem
            // 
            this.vercumpleanostoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Birthday_16x16;
            this.vercumpleanostoolStripMenuItem.Name = "vercumpleanostoolStripMenuItem";
            this.vercumpleanostoolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.vercumpleanostoolStripMenuItem.Text = "Ver Cumpleaños";
            this.vercumpleanostoolStripMenuItem.Click += new System.EventHandler(this.vercumpleanostoolStripMenuItem_Click);
            // 
            // seguimientoclientetoolStripMenuItem
            // 
            this.seguimientoclientetoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.GenerarEstadoCuenta_16x16;
            this.seguimientoclientetoolStripMenuItem.Name = "seguimientoclientetoolStripMenuItem";
            this.seguimientoclientetoolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.seguimientoclientetoolStripMenuItem.Text = "Seguimiento de Clientes";
            this.seguimientoclientetoolStripMenuItem.Click += new System.EventHandler(this.seguimientoclientetoolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // informeporvendedorToolStripMenuItem
            // 
            this.informeporvendedorToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.informeporvendedorToolStripMenuItem.Name = "informeporvendedorToolStripMenuItem";
            this.informeporvendedorToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.informeporvendedorToolStripMenuItem.Text = "Ver Informe Por Vendedor";
            this.informeporvendedorToolStripMenuItem.Click += new System.EventHandler(this.informeporvendedorToolStripMenuItem_Click);
            // 
            // exportarcelulartoolStripMenuItem
            // 
            this.exportarcelulartoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.exportarcelulartoolStripMenuItem.Name = "exportarcelulartoolStripMenuItem";
            this.exportarcelulartoolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.exportarcelulartoolStripMenuItem.Text = "Exportar Celulares";
            this.exportarcelulartoolStripMenuItem.Click += new System.EventHandler(this.exportarcelulartoolStripMenuItem_Click);
            // 
            // gvCliente
            // 
            this.gvCliente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn5});
            this.gvCliente.GridControl = this.gcCliente;
            this.gvCliente.Name = "gvCliente";
            this.gvCliente.OptionsView.ColumnAutoWidth = false;
            this.gvCliente.OptionsView.ShowGroupPanel = false;
            this.gvCliente.DoubleClick += new System.EventHandler(this.gvCliente_DoubleClick);
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdCliente";
            this.gridColumn25.FieldName = "IdCliente";
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "AbrevDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
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
            this.gridColumn23.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Cliente";
            this.gridColumn18.FieldName = "DescCliente";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 259;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Departamento";
            this.gridColumn10.FieldName = "NomDpto";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 105;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Provincia";
            this.gridColumn9.FieldName = "NomProv";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 132;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Distrito";
            this.gridColumn8.FieldName = "NomDist";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 113;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Teléfono";
            this.gridColumn6.FieldName = "Telefono";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Celular";
            this.gridColumn5.FieldName = "Celular";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 83;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.prgFactura);
            this.groupControl1.Controls.Add(this.txtCliente);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(980, 55);
            this.groupControl1.TabIndex = 20;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(559, 31);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(409, 17);
            this.prgFactura.TabIndex = 54;
            this.prgFactura.Visible = false;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(50, 29);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(502, 20);
            this.txtCliente.TabIndex = 3;
            this.txtCliente.EditValueChanged += new System.EventHandler(this.txtCliente_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Cliente:";
            // 
            // cboPagina
            // 
            this.cboPagina.Location = new System.Drawing.Point(510, 483);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPagina.Size = new System.Drawing.Size(46, 20);
            this.cboPagina.TabIndex = 53;
            this.cboPagina.EditValueChanged += new System.EventHandler(this.cboPagina_EditValueChanged);
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.EditValue = "18";
            this.txtCantidadRegistros.Location = new System.Drawing.Point(557, 483);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Properties.Mask.EditMask = "\\d{0,3}";
            this.txtCantidadRegistros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCantidadRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(30, 20);
            this.txtCantidadRegistros.TabIndex = 50;
            this.txtCantidadRegistros.EditValueChanged += new System.EventHandler(this.txtCantidadRegistros_EditValueChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(448, 483);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 51;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(479, 483);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 52;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(417, 483);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 49;
            this.btnPrevious.Tag = "";
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(386, 483);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 48;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmManClienteMayorista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 510);
            this.Controls.Add(this.cboPagina);
            this.Controls.Add(this.txtCantidadRegistros);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.gcCliente);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmManClienteMayorista";
            this.Text = "Cliente Mayorista - Mantenimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManClienteMayorista_Load);
            this.Shown += new System.EventHandler(this.frmManClienteMayorista_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboPagina;
        private DevExpress.XtraEditors.TextEdit txtCantidadRegistros;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem informeporvendedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem vercumpleanostoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendatoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguimientoclientetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarcelulartoolStripMenuItem;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private System.Windows.Forms.Timer timer1;
    }
}