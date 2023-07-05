namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManClienteMayoristaAgendaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManClienteMayoristaAgendaEdit));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.gcClienteAgenda = new DevExpress.XtraGrid.GridControl();
            this.mnuContextualClienteAgenda = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoClienteAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaClienteAgendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvClienteAgenda = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.bsListadoClienteAgenda = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAgenda)).BeginInit();
            this.mnuContextualClienteAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtNumeroTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComentario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage4;
            this.xtraTabControl1.Size = new System.Drawing.Size(782, 629);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage4});
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.splitContainer1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(776, 601);
            this.xtraTabPage4.Text = "Seguimiento de Llamadas";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCliente);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl30);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcClienteAgenda);
            this.splitContainer1.Size = new System.Drawing.Size(776, 601);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 16;
            // 
            // lblCliente
            // 
            this.lblCliente.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(289, 11);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCliente.TabIndex = 5;
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl30.Location = new System.Drawing.Point(3, 6);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(215, 13);
            this.labelControl30.TabIndex = 4;
            this.labelControl30.Text = "<F1> Seleccionar Teléfonos, Situación";
            // 
            // gcClienteAgenda
            // 
            this.gcClienteAgenda.ContextMenuStrip = this.mnuContextualClienteAgenda;
            this.gcClienteAgenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcClienteAgenda.Location = new System.Drawing.Point(0, 0);
            this.gcClienteAgenda.MainView = this.gvClienteAgenda;
            this.gcClienteAgenda.Name = "gcClienteAgenda";
            this.gcClienteAgenda.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtNumeroTelefono,
            this.gcTxtSituacion,
            this.gcTxtComentario});
            this.gcClienteAgenda.Size = new System.Drawing.Size(776, 564);
            this.gcClienteAgenda.TabIndex = 32;
            this.gcClienteAgenda.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClienteAgenda});
            // 
            // mnuContextualClienteAgenda
            // 
            this.mnuContextualClienteAgenda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteAgendaToolStripMenuItem,
            this.eliminaClienteAgendaToolStripMenuItem});
            this.mnuContextualClienteAgenda.Name = "contextMenuStrip1";
            this.mnuContextualClienteAgenda.Size = new System.Drawing.Size(118, 48);
            // 
            // nuevoClienteAgendaToolStripMenuItem
            // 
            this.nuevoClienteAgendaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoClienteAgendaToolStripMenuItem.Image")));
            this.nuevoClienteAgendaToolStripMenuItem.Name = "nuevoClienteAgendaToolStripMenuItem";
            this.nuevoClienteAgendaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoClienteAgendaToolStripMenuItem.Text = "Nuevo";
            this.nuevoClienteAgendaToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteAgendaToolStripMenuItem_Click);
            // 
            // eliminaClienteAgendaToolStripMenuItem
            // 
            this.eliminaClienteAgendaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminaClienteAgendaToolStripMenuItem.Image")));
            this.eliminaClienteAgendaToolStripMenuItem.Name = "eliminaClienteAgendaToolStripMenuItem";
            this.eliminaClienteAgendaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminaClienteAgendaToolStripMenuItem.Text = "Eliminar";
            this.eliminaClienteAgendaToolStripMenuItem.Click += new System.EventHandler(this.eliminaClienteAgendaToolStripMenuItem_Click);
            // 
            // gvClienteAgenda
            // 
            this.gvClienteAgenda.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn30,
            this.gridColumn31,
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
            this.gridColumn30.Caption = "IdClienteAgenda";
            this.gridColumn30.FieldName = "IdClienteAgenda";
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
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Fecha Registro";
            this.gridColumn32.DisplayFormat.FormatString = "g";
            this.gridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn32.FieldName = "FechaRegistro";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 0;
            this.gridColumn32.Width = 120;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "N° Teléfono";
            this.gridColumn33.ColumnEdit = this.gcTxtNumeroTelefono;
            this.gridColumn33.FieldName = "Numero";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 1;
            this.gridColumn33.Width = 89;
            // 
            // gcTxtNumeroTelefono
            // 
            this.gcTxtNumeroTelefono.AutoHeight = false;
            this.gcTxtNumeroTelefono.Name = "gcTxtNumeroTelefono";
            this.gcTxtNumeroTelefono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gcTxtNumeroTelefono_KeyUp);
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn35.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn35.Caption = "Comentario";
            this.gridColumn35.ColumnEdit = this.gcTxtComentario;
            this.gridColumn35.FieldName = "Comentario";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 2;
            this.gridColumn35.Width = 356;
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
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 3;
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
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 4;
            this.gridColumn29.Width = 73;
            // 
            // gcTxtSituacion
            // 
            this.gcTxtSituacion.AutoHeight = false;
            this.gcTxtSituacion.Name = "gcTxtSituacion";
            this.gcTxtSituacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gcTxtSituacion_KeyUp);
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "TipoOper";
            this.gridColumn37.FieldName = "TipoOper";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(695, 635);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(614, 635);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManClienteMayoristaAgendaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 665);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManClienteMayoristaAgendaEdit";
            this.Load += new System.EventHandler(this.frmManClienteMayoristaAgendaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteAgenda)).EndInit();
            this.mnuContextualClienteAgenda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtNumeroTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComentario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtSituacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteAgenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.LabelControl labelControl30;
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
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private System.Windows.Forms.ContextMenuStrip mnuContextualClienteAgenda;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteAgendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaClienteAgendaToolStripMenuItem;
        private System.Windows.Forms.BindingSource bsListadoClienteAgenda;
        private DevExpress.XtraEditors.LabelControl lblCliente;
    }
}