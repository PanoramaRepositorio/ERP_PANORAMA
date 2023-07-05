namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManClienteEncuesta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManClienteEncuesta));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcCliente = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importarclientetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpEliminar,
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolstpExportarExcel,
            this.toolStripSeparator2,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(731, 25);
            this.toolStrip1.TabIndex = 57;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpEliminar
            // 
            this.toolstpEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpEliminar.Image = global::ErpPanorama.Presentation.Properties.Resources.delete;
            this.toolstpEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpEliminar.Name = "toolstpEliminar";
            this.toolstpEliminar.Size = new System.Drawing.Size(23, 22);
            this.toolstpEliminar.Text = "toolStripButton1";
            this.toolstpEliminar.Click += new System.EventHandler(this.toolstpEliminar_Click);
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
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolstpExportarExcel.Image")));
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(731, 55);
            this.groupControl1.TabIndex = 58;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(70, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(636, 20);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Descripción:";
            // 
            // gcCliente
            // 
            this.gcCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCliente.ContextMenuStrip = this.mnuContextual;
            this.gcCliente.Location = new System.Drawing.Point(0, 80);
            this.gcCliente.MainView = this.gvCliente;
            this.gcCliente.Name = "gcCliente";
            this.gcCliente.Size = new System.Drawing.Size(731, 388);
            this.gcCliente.TabIndex = 59;
            this.gcCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCliente});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarclientetoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(166, 26);
            // 
            // importarclientetoolStripMenuItem
            // 
            this.importarclientetoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Agenda_16x16;
            this.importarclientetoolStripMenuItem.Name = "importarclientetoolStripMenuItem";
            this.importarclientetoolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.importarclientetoolStripMenuItem.Text = "Importar Clientes";
            this.importarclientetoolStripMenuItem.ToolTipText = "[DNI]";
            this.importarclientetoolStripMenuItem.Click += new System.EventHandler(this.importarclientetoolStripMenuItem_Click);
            // 
            // gvCliente
            // 
            this.gvCliente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvCliente.GridControl = this.gcCliente;
            this.gvCliente.Name = "gvCliente";
            this.gvCliente.OptionsView.ColumnAutoWidth = false;
            this.gvCliente.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEncuesta";
            this.gridColumn1.FieldName = "IdEncuesta";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdCliente";
            this.gridColumn2.FieldName = "IdCliente";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Numero";
            this.gridColumn3.FieldName = "NumeroDocumento";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 151;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Cliente";
            this.gridColumn4.FieldName = "DescCliente";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 447;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Dscto Aplicado";
            this.gridColumn5.FieldName = "FlagDescuento";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 93;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "FlagEstado";
            this.gridColumn6.FieldName = "FlagEstado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(15, 477);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(117, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0 Registros encontrados";
            // 
            // prgFactura
            // 
            this.prgFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgFactura.Location = new System.Drawing.Point(194, 477);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(516, 13);
            this.prgFactura.TabIndex = 60;
            // 
            // frmManClienteEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 498);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.gcCliente);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManClienteEncuesta";
            this.Text = "Mantenimiento - Encuesta";
            this.Load += new System.EventHandler(this.frmManClienteEncuesta_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCliente;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem importarclientetoolStripMenuItem;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private System.Windows.Forms.ToolStripButton toolstpEliminar;

    }
}