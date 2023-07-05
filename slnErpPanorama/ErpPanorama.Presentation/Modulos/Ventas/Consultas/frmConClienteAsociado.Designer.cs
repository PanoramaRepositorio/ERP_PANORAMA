namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    partial class frmConClienteAsociado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConClienteAsociado));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.VerCatalogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.VerDocumentoVentatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gcClientePrincipal = new DevExpress.XtraGrid.GridControl();
            this.gvClientePrincipal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gcClienteAsociado = new DevExpress.XtraGrid.GridControl();
            this.gvClienteAsociado = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcClientePrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClientePrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAsociado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAsociado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtDescCliente);
            this.panel1.Controls.Add(this.txtNumeroDocumento);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 35);
            this.panel1.TabIndex = 74;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(158, 7);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 54;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(187, 7);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(389, 20);
            this.txtDescCliente.TabIndex = 55;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(53, 7);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(99, 20);
            this.txtNumeroDocumento.TabIndex = 53;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 52;
            this.labelControl5.Text = "Cliente:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 174);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 77;
            this.labelControl1.Text = "Asociados";
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImprimirToolStripMenuItem,
            this.toolStripSeparator1,
            this.VerCatalogoToolStripMenuItem,
            this.toolStripSeparator2,
            this.VerDocumentoVentatoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(191, 82);
            // 
            // ImprimirToolStripMenuItem
            // 
            this.ImprimirToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Print_16x16;
            this.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
            this.ImprimirToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ImprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // VerCatalogoToolStripMenuItem
            // 
            this.VerCatalogoToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.VerCatalogoToolStripMenuItem.Name = "VerCatalogoToolStripMenuItem";
            this.VerCatalogoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.VerCatalogoToolStripMenuItem.Text = "Ver Catalogo";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // VerDocumentoVentatoolStripMenuItem
            // 
            this.VerDocumentoVentatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultas_16x16;
            this.VerDocumentoVentatoolStripMenuItem.Name = "VerDocumentoVentatoolStripMenuItem";
            this.VerDocumentoVentatoolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.VerDocumentoVentatoolStripMenuItem.Text = "Ver Documento Venta";
            // 
            // gcClientePrincipal
            // 
            this.gcClientePrincipal.ContextMenuStrip = this.mnuContextual;
            this.gcClientePrincipal.Location = new System.Drawing.Point(0, 63);
            this.gcClientePrincipal.MainView = this.gvClientePrincipal;
            this.gcClientePrincipal.Name = "gcClientePrincipal";
            this.gcClientePrincipal.Size = new System.Drawing.Size(1125, 105);
            this.gcClientePrincipal.TabIndex = 78;
            this.gcClientePrincipal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClientePrincipal});
            // 
            // gvClientePrincipal
            // 
            this.gvClientePrincipal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn34,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn36,
            this.gridColumn33,
            this.gridColumn35,
            this.gridColumn37,
            this.gridColumn3,
            this.gridColumn4});
            this.gvClientePrincipal.GridControl = this.gcClientePrincipal;
            this.gvClientePrincipal.Name = "gvClientePrincipal";
            this.gvClientePrincipal.OptionsView.ColumnAutoWidth = false;
            this.gvClientePrincipal.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Periodo";
            this.gridColumn1.FieldName = "Periodo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "NumeroDocumento";
            this.gridColumn34.FieldName = "NumeroDocumento";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 2;
            this.gridColumn34.Width = 107;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cliente";
            this.gridColumn2.FieldName = "DescCliente";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 280;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdTipoCliente";
            this.gridColumn5.FieldName = "IdTipoCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdClasificacionCliente";
            this.gridColumn6.FieldName = "IdClasificacionCliente";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Contacto";
            this.gridColumn36.FieldName = "Contacto";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 6;
            this.gridColumn36.Width = 92;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Vendedor";
            this.gridColumn33.FieldName = "DescVendedor";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 4;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Representante";
            this.gridColumn35.FieldName = "Representante";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 5;
            this.gridColumn35.Width = 88;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Direccion";
            this.gridColumn37.FieldName = "Direccion";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 7;
            this.gridColumn37.Width = 248;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Documento";
            this.gridColumn3.FieldName = "AbrevDocumento";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TipoCliente";
            this.gridColumn4.FieldName = "DescTipoCliente";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 121;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(10, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "Principal";
            // 
            // gcClienteAsociado
            // 
            this.gcClienteAsociado.ContextMenuStrip = this.mnuContextual;
            this.gcClienteAsociado.Location = new System.Drawing.Point(0, 193);
            this.gcClienteAsociado.MainView = this.gvClienteAsociado;
            this.gcClienteAsociado.Name = "gcClienteAsociado";
            this.gcClienteAsociado.Size = new System.Drawing.Size(1125, 198);
            this.gcClienteAsociado.TabIndex = 79;
            this.gcClienteAsociado.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClienteAsociado});
            // 
            // gvClienteAsociado
            // 
            this.gvClienteAsociado.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn15,
            this.gridColumn16});
            this.gvClienteAsociado.GridControl = this.gcClienteAsociado;
            this.gvClienteAsociado.Name = "gvClienteAsociado";
            this.gvClienteAsociado.OptionsView.ColumnAutoWidth = false;
            this.gvClienteAsociado.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "NumeroDocumento";
            this.gridColumn8.FieldName = "NumeroDocumento";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            this.gridColumn8.Width = 107;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Cliente";
            this.gridColumn9.FieldName = "DescCliente";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 280;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Direccion";
            this.gridColumn15.FieldName = "Direccion";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 410;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Documento";
            this.gridColumn16.FieldName = "AbrevDocumento";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // frmConClienteAsociado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 403);
            this.Controls.Add(this.gcClienteAsociado);
            this.Controls.Add(this.gcClientePrincipal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConClienteAsociado";
            this.Text = "Consulta Cliente Asociado";
            this.Load += new System.EventHandler(this.frmConClienteAsociado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcClientePrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClientePrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAsociado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAsociado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem ImprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem VerCatalogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem VerDocumentoVentatoolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gcClientePrincipal;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClientePrincipal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl gcClienteAsociado;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClienteAsociado;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;


    }
}