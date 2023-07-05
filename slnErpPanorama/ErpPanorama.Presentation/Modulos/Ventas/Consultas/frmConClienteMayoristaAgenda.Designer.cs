namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    partial class frmConClienteMayoristaAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConClienteMayoristaAgenda));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gcClienteAgenda = new DevExpress.XtraGrid.GridControl();
            this.gvClienteAgenda = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtNumeroTelefono = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtComentario = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtSituacion = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtNumeroTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComentario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpExcel,
            this.toolStripSeparator3,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1048, 25);
            this.toolStrip1.TabIndex = 66;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpExcel
            // 
            this.toolstpExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExcel.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.toolstpExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExcel.Name = "toolstpExcel";
            this.toolstpExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExcel.ToolTipText = "Exportar Excel";
            this.toolstpExcel.Click += new System.EventHandler(this.toolstpExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(23, 22);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboSituacion);
            this.groupControl1.Controls.Add(this.lblTotalRegistros);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.cboVendedor);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1048, 52);
            this.groupControl1.TabIndex = 75;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(476, 24);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(180, 20);
            this.cboSituacion.TabIndex = 22;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(423, 27);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(47, 13);
            this.labelControl18.TabIndex = 21;
            this.labelControl18.Text = "Situación:";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(7, 27);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(50, 13);
            this.labelControl11.TabIndex = 19;
            this.labelControl11.Text = "Vendedor:";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(63, 24);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(350, 20);
            this.cboVendedor.TabIndex = 20;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(662, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 18;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gcClienteAgenda
            // 
            this.gcClienteAgenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcClienteAgenda.Location = new System.Drawing.Point(0, 77);
            this.gcClienteAgenda.MainView = this.gvClienteAgenda;
            this.gcClienteAgenda.Name = "gcClienteAgenda";
            this.gcClienteAgenda.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtNumeroTelefono,
            this.gcTxtSituacion,
            this.gcTxtComentario});
            this.gcClienteAgenda.Size = new System.Drawing.Size(1048, 429);
            this.gcClienteAgenda.TabIndex = 76;
            this.gcClienteAgenda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClienteAgenda});
            // 
            // gvClienteAgenda
            // 
            this.gvClienteAgenda.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn35,
            this.gridColumn34,
            this.gridColumn36,
            this.gridColumn29,
            this.gridColumn37});
            this.gvClienteAgenda.GridControl = this.gcClienteAgenda;
            this.gvClienteAgenda.Name = "gvClienteAgenda";
            this.gvClienteAgenda.OptionsView.ColumnAutoWidth = false;
            this.gvClienteAgenda.OptionsView.RowAutoHeight = true;
            this.gvClienteAgenda.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "IdClienteTracking";
            this.gridColumn30.FieldName = "IdClienteTracking";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "IdCliente";
            this.gridColumn31.FieldName = "IdCliente";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdVendedor";
            this.gridColumn2.FieldName = "IdVendedor";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Cliente";
            this.gridColumn1.FieldName = "DescCliente";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 300;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Fecha Registro";
            this.gridColumn32.DisplayFormat.FormatString = "g";
            this.gridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn32.FieldName = "FechaRegistro";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsColumn.AllowFocus = false;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 1;
            this.gridColumn32.Width = 120;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "N° Teléfono";
            this.gridColumn33.ColumnEdit = this.gcTxtNumeroTelefono;
            this.gridColumn33.FieldName = "Numero";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 2;
            this.gridColumn33.Width = 89;
            // 
            // gcTxtNumeroTelefono
            // 
            this.gcTxtNumeroTelefono.AutoHeight = false;
            this.gcTxtNumeroTelefono.Name = "gcTxtNumeroTelefono";
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn35.Caption = "Comentario";
            this.gridColumn35.ColumnEdit = this.gcTxtComentario;
            this.gridColumn35.FieldName = "Comentario";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 3;
            this.gridColumn35.Width = 450;
            // 
            // gcTxtComentario
            // 
            this.gcTxtComentario.Appearance.Options.UseTextOptions = true;
            this.gcTxtComentario.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcTxtComentario.Name = "gcTxtComentario";
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Fecha Próxima";
            this.gridColumn34.DisplayFormat.FormatString = "g";
            this.gridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn34.FieldName = "FechaProxima";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 4;
            this.gridColumn34.Width = 120;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "IdSituacion";
            this.gridColumn36.FieldName = "IdSituacion";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Width = 294;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Situación";
            this.gridColumn29.ColumnEdit = this.gcTxtSituacion;
            this.gridColumn29.FieldName = "DescSituacion";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 5;
            this.gridColumn29.Width = 73;
            // 
            // gcTxtSituacion
            // 
            this.gcTxtSituacion.AutoHeight = false;
            this.gcTxtSituacion.Name = "gcTxtSituacion";
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "TipoOper";
            this.gridColumn37.FieldName = "TipoOper";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(943, 27);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 21;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // frmConClienteMayoristaAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 506);
            this.Controls.Add(this.gcClienteAgenda);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConClienteMayoristaAgenda";
            this.Text = "Consulta Cliente Mayorista - Agenda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConClienteMayoristaAgenda_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtNumeroTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComentario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraGrid.GridControl gcClienteAgenda;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClienteAgenda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtNumeroTelefono;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtComentario;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtSituacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
    }
}