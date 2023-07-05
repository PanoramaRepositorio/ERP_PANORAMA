namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmImportarClasificacionProducto
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnValida = new DevExpress.XtraEditors.SimpleButton();
            this.btnProcesoRapido = new DevExpress.XtraEditors.SimpleButton();
            this.btnProceso = new DevExpress.XtraEditors.SimpleButton();
            this.txtDirectorio = new DevExpress.XtraEditors.TextEdit();
            this.btnDirectorio = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.countToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCantidadtoolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectorio.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnValida);
            this.groupControl1.Controls.Add(this.btnProcesoRapido);
            this.groupControl1.Controls.Add(this.btnProceso);
            this.groupControl1.Controls.Add(this.txtDirectorio);
            this.groupControl1.Controls.Add(this.btnDirectorio);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1513, 55);
            this.groupControl1.TabIndex = 54;
            this.groupControl1.Text = "Actualización de Datos";
            // 
            // btnValida
            // 
            this.btnValida.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnValida.ImageOptions.ImageIndex = 1;
            this.btnValida.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnValida.Location = new System.Drawing.Point(809, 24);
            this.btnValida.Name = "btnValida";
            this.btnValida.Size = new System.Drawing.Size(109, 26);
            this.btnValida.TabIndex = 31;
            this.btnValida.Text = "Verificar Código";
            this.btnValida.ToolTip = "Verifica código si el Código existe";
            this.btnValida.Visible = false;
            // 
            // btnProcesoRapido
            // 
            this.btnProcesoRapido.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Proceso_16x16;
            this.btnProcesoRapido.ImageOptions.ImageIndex = 1;
            this.btnProcesoRapido.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnProcesoRapido.Location = new System.Drawing.Point(652, 27);
            this.btnProcesoRapido.Name = "btnProcesoRapido";
            this.btnProcesoRapido.Size = new System.Drawing.Size(80, 23);
            this.btnProcesoRapido.TabIndex = 31;
            this.btnProcesoRapido.Text = "I. Rápida";
            this.btnProcesoRapido.ToolTip = "Importar Registros sin Validar datos";
            this.btnProcesoRapido.Click += new System.EventHandler(this.btnProcesoRapido_Click);
            // 
            // btnProceso
            // 
            this.btnProceso.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Proceso_16x16;
            this.btnProceso.ImageOptions.ImageIndex = 1;
            this.btnProceso.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnProceso.Location = new System.Drawing.Point(557, 27);
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Size = new System.Drawing.Size(83, 23);
            this.btnProceso.TabIndex = 31;
            this.btnProceso.Text = "Importar";
            this.btnProceso.ToolTip = "Importar Registros Validando datos";
            this.btnProceso.Click += new System.EventHandler(this.btnProceso_Click);
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Location = new System.Drawing.Point(63, 30);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(392, 20);
            this.txtDirectorio.TabIndex = 5;
            // 
            // btnDirectorio
            // 
            this.btnDirectorio.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.FolderPicture_16x16;
            this.btnDirectorio.ImageOptions.ImageIndex = 1;
            this.btnDirectorio.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDirectorio.Location = new System.Drawing.Point(461, 27);
            this.btnDirectorio.Name = "btnDirectorio";
            this.btnDirectorio.Size = new System.Drawing.Size(90, 23);
            this.btnDirectorio.TabIndex = 30;
            this.btnDirectorio.Text = "Archivo";
            this.btnDirectorio.ToolTip = "Abrir archivo";
            this.btnDirectorio.Click += new System.EventHandler(this.btnDirectorio_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Carpeta:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1513, 22);
            this.panel1.TabIndex = 56;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(324, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "I.Rápida: Permite la actualización de los datos válidos de un código.";
            // 
            // prgFactura
            // 
            this.prgFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgFactura.Location = new System.Drawing.Point(953, 444);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(539, 16);
            this.prgFactura.TabIndex = 43;
            // 
            // gcProducto
            // 
            this.gcProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducto.Location = new System.Drawing.Point(0, 77);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(1513, 365);
            this.gcProducto.TabIndex = 59;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn13,
            this.gridColumn9,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn11,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn7});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            this.gvProducto.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvProducto_RowStyle);
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Código";
            this.gridColumn23.FieldName = "CodigoProveedor";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Nombre";
            this.gridColumn18.FieldName = "NombreProducto";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 350;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "U.M";
            this.gridColumn10.FieldName = "Abreviatura";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 50;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Peso";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Peso";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Medida";
            this.gridColumn1.FieldName = "Medida";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Marca";
            this.gridColumn4.FieldName = "DescMarca";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Colección";
            this.gridColumn12.FieldName = "Coleccion";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Procedencia";
            this.gridColumn3.FieldName = "DescProcedencia";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Material";
            this.gridColumn2.FieldName = "DescMaterial";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 10;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Familia";
            this.gridColumn11.FieldName = "DescFamiliaProducto";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Linea";
            this.gridColumn5.FieldName = "DescLineaProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 12;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "SubLinea";
            this.gridColumn8.FieldName = "DescSubLineaProducto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 13;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Modelo";
            this.gridColumn6.FieldName = "DescModeloProducto";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 14;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Estado";
            this.gridColumn7.FieldName = "FlagEstado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 41;
            // 
            // countToolStripStatusLabel
            // 
            this.countToolStripStatusLabel.Name = "countToolStripStatusLabel";
            this.countToolStripStatusLabel.Size = new System.Drawing.Size(0, 0);
            // 
            // tssCantidadtoolStripStatus
            // 
            this.tssCantidadtoolStripStatus.Name = "tssCantidadtoolStripStatus";
            this.tssCantidadtoolStripStatus.Size = new System.Drawing.Size(10, 15);
            this.tssCantidadtoolStripStatus.Text = ".";
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countToolStripStatusLabel,
            this.tssCantidadtoolStripStatus});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 442);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1513, 20);
            this.statusStrip.TabIndex = 58;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Descripción";
            this.gridColumn13.FieldName = "Descripcion";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 166;
            // 
            // frmImportarClasificacionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 462);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmImportarClasificacionProducto";
            this.Text = "Actualizar Clasificación de Productos";
            this.Load += new System.EventHandler(this.frmImportarClasificacionProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectorio.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnProceso;
        private DevExpress.XtraEditors.SimpleButton btnDirectorio;
        private DevExpress.XtraEditors.TextEdit txtDirectorio;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnValida;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private System.Windows.Forms.ToolStripStatusLabel countToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssCantidadtoolStripStatus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private DevExpress.XtraEditors.SimpleButton btnProcesoRapido;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}