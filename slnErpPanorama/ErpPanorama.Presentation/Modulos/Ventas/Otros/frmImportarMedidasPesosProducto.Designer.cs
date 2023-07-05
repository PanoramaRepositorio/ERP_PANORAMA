namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmImportarMedidasPesosProducto
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
            this.btnProcesoRapido = new DevExpress.XtraEditors.SimpleButton();
            this.btnProceso = new DevExpress.XtraEditors.SimpleButton();
            this.txtDirectorio = new DevExpress.XtraEditors.TextEdit();
            this.btnDirectorio = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.gvProducto = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridColumn23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.countToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCantidadtoolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectorio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnProcesoRapido);
            this.groupControl1.Controls.Add(this.btnProceso);
            this.groupControl1.Controls.Add(this.txtDirectorio);
            this.groupControl1.Controls.Add(this.btnDirectorio);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1393, 55);
            this.groupControl1.TabIndex = 54;
            this.groupControl1.Text = "Actualización de Datos";
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
            this.btnProcesoRapido.Visible = false;
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
            // prgFactura
            // 
            this.prgFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.prgFactura.Location = new System.Drawing.Point(833, 668);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(539, 16);
            this.prgFactura.TabIndex = 43;
            // 
            // gcProducto
            // 
            this.gcProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProducto.Location = new System.Drawing.Point(0, 55);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(1393, 611);
            this.gcProducto.TabIndex = 59;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // gvProducto
            // 
            this.gvProducto.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gvProducto.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvProducto.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn1});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Hang Tag";
            this.gridColumn23.FieldName = "IdProductoStr";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.Width = 64;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Nombre";
            this.gridColumn18.FieldName = "NombreProducto";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.Width = 361;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "U.M";
            this.gridColumn10.FieldName = "Abreviatura";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.Width = 49;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Altura";
            this.gridColumn6.FieldName = "MedidaInternaAltura";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Ancho";
            this.gridColumn5.FieldName = "MedidaInternaAncho";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Profundidad";
            this.gridColumn4.FieldName = "MedidaInternaProfundidad";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Altura";
            this.gridColumn3.FieldName = "MedidaExternaAltura";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Ancho";
            this.gridColumn2.FieldName = "MedidaExternaAncho";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.Width = 70;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Profundidad";
            this.gridColumn9.FieldName = "MedidaExternaProfundidad";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.Width = 70;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Neto";
            this.gridColumn8.FieldName = "PesoNeto";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.Width = 60;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Bruto";
            this.gridColumn1.FieldName = "PesoBruto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.Width = 60;
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
            this.statusStrip.Location = new System.Drawing.Point(0, 666);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1393, 20);
            this.statusStrip.TabIndex = 58;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Descripción del Producto";
            this.gridBand1.Columns.Add(this.gridColumn23);
            this.gridBand1.Columns.Add(this.gridColumn18);
            this.gridBand1.Columns.Add(this.gridColumn10);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 474;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Medida Interna (cm)";
            this.gridBand2.Columns.Add(this.gridColumn6);
            this.gridBand2.Columns.Add(this.gridColumn5);
            this.gridBand2.Columns.Add(this.gridColumn4);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 210;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Medida Externa (cm)";
            this.gridBand3.Columns.Add(this.gridColumn3);
            this.gridBand3.Columns.Add(this.gridColumn2);
            this.gridBand3.Columns.Add(this.gridColumn9);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 210;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Peso (kg)";
            this.gridBand4.Columns.Add(this.gridColumn8);
            this.gridBand4.Columns.Add(this.gridColumn1);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 120;
            // 
            // frmImportarMedidasPesosProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 686);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmImportarMedidasPesosProducto";
            this.Text = "Actualizar Medidas y Pesos de Productos";
            this.Load += new System.EventHandler(this.frmImportarMedidasPesosProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectorio.Properties)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private System.Windows.Forms.ToolStripStatusLabel countToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tssCantidadtoolStripStatus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private DevExpress.XtraEditors.SimpleButton btnProcesoRapido;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvProducto;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn23;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn18;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}