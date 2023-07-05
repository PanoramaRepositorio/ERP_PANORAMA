namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    partial class frmRegPersonaTrabajoDetalleVarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPersonaTrabajoDetalleVarios));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.gcPersonaTrabajoDetalle = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarprecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPersonaTrabajoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCboTienda = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCboIdArea = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersonaTrabajoDetalle)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonaTrabajoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCboTienda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCboIdArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatos.Controls.Add(this.gcPersonaTrabajoDetalle);
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.ShowCaption = false;
            this.grdDatos.Size = new System.Drawing.Size(1180, 423);
            this.grdDatos.TabIndex = 15;
            // 
            // gcPersonaTrabajoDetalle
            // 
            this.gcPersonaTrabajoDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcPersonaTrabajoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPersonaTrabajoDetalle.Location = new System.Drawing.Point(2, 2);
            this.gcPersonaTrabajoDetalle.MainView = this.gvPersonaTrabajoDetalle;
            this.gcPersonaTrabajoDetalle.Name = "gcPersonaTrabajoDetalle";
            this.gcPersonaTrabajoDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo,
            this.repositoryItemComboBox1,
            this.gcCboTienda,
            this.gcCboIdArea});
            this.gcPersonaTrabajoDetalle.Size = new System.Drawing.Size(1176, 419);
            this.gcPersonaTrabajoDetalle.TabIndex = 36;
            this.gcPersonaTrabajoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersonaTrabajoDetalle});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarprecioToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportartoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(118, 54);
            // 
            // modificarprecioToolStripMenuItem
            // 
            this.modificarprecioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarprecioToolStripMenuItem.Image")));
            this.modificarprecioToolStripMenuItem.Name = "modificarprecioToolStripMenuItem";
            this.modificarprecioToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.modificarprecioToolStripMenuItem.Text = "Editar";
            this.modificarprecioToolStripMenuItem.Click += new System.EventHandler(this.modificarprecioToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // exportartoolStripMenuItem
            // 
            this.exportartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportartoolStripMenuItem.Image")));
            this.exportartoolStripMenuItem.Name = "exportartoolStripMenuItem";
            this.exportartoolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exportartoolStripMenuItem.Text = "Exportar";
            this.exportartoolStripMenuItem.Click += new System.EventHandler(this.exportartoolStripMenuItem_Click);
            // 
            // gvPersonaTrabajoDetalle
            // 
            this.gvPersonaTrabajoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
            this.gvPersonaTrabajoDetalle.GridControl = this.gcPersonaTrabajoDetalle;
            this.gvPersonaTrabajoDetalle.Name = "gvPersonaTrabajoDetalle";
            this.gvPersonaTrabajoDetalle.OptionsEditForm.EditFormColumnCount = 2;
            this.gvPersonaTrabajoDetalle.OptionsEditForm.PopupEditFormWidth = 900;
            this.gvPersonaTrabajoDetalle.OptionsFind.AlwaysVisible = true;
            this.gvPersonaTrabajoDetalle.OptionsSelection.MultiSelect = true;
            this.gvPersonaTrabajoDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvPersonaTrabajoDetalle.OptionsView.ShowGroupPanel = false;
            this.gvPersonaTrabajoDetalle.ColumnFilterChanged += new System.EventHandler(this.gvPersonaTrabajoDetalle_ColumnFilterChanged);
            this.gvPersonaTrabajoDetalle.DoubleClick += new System.EventHandler(this.gvPersonaTrabajoDetalle_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPersonaTrabajo";
            this.gridColumn1.FieldName = "IdRuta";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPersonaTrabajoDetalle";
            this.gridColumn11.FieldName = "IdRutaDetalle";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdPersona";
            this.gridColumn7.FieldName = "IdPersona";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Nombre";
            this.gridColumn10.FieldName = "ApeNom";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 216;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn3.AppearanceHeader.Options.UseBackColor = true;
            this.gridColumn3.Caption = "IdTienda";
            this.gridColumn3.ColumnEdit = this.gcCboTienda;
            this.gridColumn3.FieldName = "IdTienda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 122;
            // 
            // gcCboTienda
            // 
            this.gcCboTienda.AutoHeight = false;
            this.gcCboTienda.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gcCboTienda.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IdTienda", "Código", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DescTienda", "Tienda", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Direccion", "Dirección", 700, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.gcCboTienda.Name = "gcCboTienda";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gridColumn4.AppearanceHeader.Options.UseBackColor = true;
            this.gridColumn4.Caption = "Tienda";
            this.gridColumn4.FieldName = "DescTienda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.Caption = "Puesto";
            this.gridColumn5.ColumnEdit = this.gcCboIdArea;
            this.gridColumn5.FieldName = "IdArea";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 107;
            // 
            // gcCboIdArea
            // 
            this.gcCboIdArea.AutoHeight = false;
            this.gcCboIdArea.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gcCboIdArea.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripción")});
            this.gcCboIdArea.Name = "gcCboIdArea";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Puesto";
            this.gridColumn6.FieldName = "DescArea";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Width = 148;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn8.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn8.Caption = "Importe";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Importe";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn9.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn9.Caption = "Observación";
            this.gridColumn9.FieldName = "Observacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 107;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Apoyo";
            this.gridColumn12.FieldName = "FlagApoyo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Width = 48;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn13.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn13.Caption = "Seleccionar";
            this.gridColumn13.FieldName = "FlagEstado";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "TipoOper";
            this.gridColumn14.FieldName = "TipoOper";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Cargo";
            this.gridColumn15.FieldName = "DescCargo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            this.gridColumn15.Width = 142;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Teléfono";
            this.gridColumn16.FieldName = "Telefono";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            this.gridColumn16.Width = 232;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageOptions.ImageIndex = 1;
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(955, 429);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1036, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(27, 434);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 40;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // frmRegPersonaTrabajoDetalleVarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 462);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPersonaTrabajoDetalleVarios";
            this.Text = "Seleccionar Personal de Apoyo";
            this.Load += new System.EventHandler(this.frmRegPersonaTrabajoDetalleVarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPersonaTrabajoDetalle)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonaTrabajoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCboTienda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCboIdArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarprecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportartoolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gcPersonaTrabajoDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersonaTrabajoDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcCboTienda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcCboIdArea;
    }
}