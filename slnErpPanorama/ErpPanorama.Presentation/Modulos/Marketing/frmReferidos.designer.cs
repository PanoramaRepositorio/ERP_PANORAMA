namespace ErpPanorama.Presentation.Modulos.Marketing.Consultas
{
    partial class frmReferidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReferidos));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.gcClienteRegistro = new DevExpress.XtraGrid.GridControl();
            this.gvClienteRegistro = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteRegistro)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1367, 27);
            this.toolStrip1.TabIndex = 79;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolstpExportarExcel.Image")));
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(24, 24);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(24, 24);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(24, 24);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalRegistros);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.deHasta);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.deDesde);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 35);
            this.panel1.TabIndex = 80;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(392, 10);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 14;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
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
            // gcClienteRegistro
            // 
            this.gcClienteRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcClienteRegistro.Location = new System.Drawing.Point(0, 63);
            this.gcClienteRegistro.MainView = this.gvClienteRegistro;
            this.gcClienteRegistro.Name = "gcClienteRegistro";
            this.gcClienteRegistro.Size = new System.Drawing.Size(1367, 440);
            this.gcClienteRegistro.TabIndex = 81;
            this.gcClienteRegistro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClienteRegistro});
            // 
            // gvClienteRegistro
            // 
            this.gvClienteRegistro.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvClienteRegistro.GridControl = this.gcClienteRegistro;
            this.gvClienteRegistro.Name = "gvClienteRegistro";
            this.gvClienteRegistro.OptionsSelection.MultiSelect = true;
            this.gvClienteRegistro.OptionsView.ColumnAutoWidth = false;
            this.gvClienteRegistro.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Documento";
            this.gridColumn2.FieldName = "NumeroDocumento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 102;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Referente";
            this.gridColumn3.FieldName = "Referido";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 112;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "N° Pedido";
            this.gridColumn4.FieldName = "NumeroPedido";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 103;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Concepto";
            this.gridColumn5.FieldName = "Concepto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 242;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Referido";
            this.gridColumn6.FieldName = "Compro";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 300;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tienda";
            this.gridColumn7.FieldName = "DescTienda";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 237;
            // 
            // frmReferidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 537);
            this.Controls.Add(this.gcClienteRegistro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmReferidos";
            this.Text = "Clientes Referidos";
            this.Load += new System.EventHandler(this.frmClientesRegistrados_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcClienteRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClienteRegistro)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraGrid.GridControl gcClienteRegistro;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClienteRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}