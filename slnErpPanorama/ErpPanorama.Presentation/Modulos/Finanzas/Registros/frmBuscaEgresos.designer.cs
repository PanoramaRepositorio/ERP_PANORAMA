namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    partial class frmBuscaEgresos
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
            this.gcListaEgresos = new DevExpress.XtraGrid.GridControl();
            this.gvListaEgresos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcListaEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListaEgresos)).BeginInit();
            this.SuspendLayout();
            // 
            // gcListaEgresos
            // 
            this.gcListaEgresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListaEgresos.Location = new System.Drawing.Point(0, 0);
            this.gcListaEgresos.MainView = this.gvListaEgresos;
            this.gcListaEgresos.Name = "gcListaEgresos";
            this.gcListaEgresos.Size = new System.Drawing.Size(327, 466);
            this.gcListaEgresos.TabIndex = 20;
            this.gcListaEgresos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListaEgresos});
            // 
            // gvListaEgresos
            // 
            this.gvListaEgresos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn18,
            this.gridColumn23,
            this.gridColumn2,
            this.gridColumn1});
            this.gvListaEgresos.GridControl = this.gcListaEgresos;
            this.gvListaEgresos.Name = "gvListaEgresos";
            this.gvListaEgresos.OptionsView.ShowFooter = true;
            this.gvListaEgresos.OptionsView.ShowGroupPanel = false;
            this.gvListaEgresos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvCliente_KeyDown);
            this.gvListaEgresos.DoubleClick += new System.EventHandler(this.gvCliente_DoubleClick);
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdCajaEgreso";
            this.gridColumn25.FieldName = "IdCajaEgreso";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdCajaEgresoDetalle";
            this.gridColumn24.FieldName = "IdCajaEgresoDetalle";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "Fecha";
            this.gridColumn18.FieldName = "Fecha";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 1;
            this.gridColumn18.Width = 78;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn23.AppearanceCell.Options.UseFont = true;
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.Caption = "N° Recibo";
            this.gridColumn23.FieldName = "NumRecibo";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 0;
            this.gridColumn23.Width = 86;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "M";
            this.gridColumn2.FieldName = "DescMoneda";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 22;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Monto";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Importe";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 116;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnGrabar.Appearance.Options.UseFont = true;
            this.btnGrabar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.btn_salir3;
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(2, 432);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(325, 31);
            this.btnGrabar.TabIndex = 21;
            this.btnGrabar.Text = "Cerrar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // frmBuscaEgresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 466);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.gcListaEgresos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscaEgresos";
            this.Text = "Búsqueda Recibos de Egresos";
            this.Load += new System.EventHandler(this.frmBuscaEgresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcListaEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListaEgresos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcListaEgresos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListaEgresos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}