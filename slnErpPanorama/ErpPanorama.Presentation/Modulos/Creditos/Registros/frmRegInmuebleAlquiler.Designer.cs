namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    partial class frmRegInmuebleAlquiler
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
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvInmuebleAlquiler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInmuebleAlquiler = new DevExpress.XtraGrid.GridControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtInmuebleAlquiler = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.gvInmuebleAlquiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInmuebleAlquiler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInmuebleAlquiler.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Día Pago";
            this.gridColumn13.FieldName = "DiaPago";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Fecha Inicio";
            this.gridColumn4.FieldName = "FechaInicio";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Cliente";
            this.gridColumn18.FieldName = "DescCliente";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            this.gridColumn18.Width = 275;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "N° Documento";
            this.gridColumn23.FieldName = "NumeroDocumento";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 2;
            this.gridColumn23.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tipo";
            this.gridColumn1.FieldName = "DescTipoInmueble";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdCliente";
            this.gridColumn25.FieldName = "IdCliente";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdClienteCredito";
            this.gridColumn2.FieldName = "IdClienteCredito";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gvInmuebleAlquiler
            // 
            this.gvInmuebleAlquiler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn14,
            this.gridColumn10,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn13});
            this.gvInmuebleAlquiler.GridControl = this.gcInmuebleAlquiler;
            this.gvInmuebleAlquiler.Name = "gvInmuebleAlquiler";
            this.gvInmuebleAlquiler.OptionsView.ColumnAutoWidth = false;
            this.gvInmuebleAlquiler.OptionsView.ShowGroupPanel = false;
            this.gvInmuebleAlquiler.DoubleClick += new System.EventHandler(this.gvInmuebleAlquiler_DoubleClick);
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "DescInmueble";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 138;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Moneda";
            this.gridColumn6.FieldName = "DescMoneda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 57;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "P. Alquiler";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PrecioAlquiler";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Adelanto";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.FieldName = "Adelanto";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Garantia";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.FieldName = "Garantia";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mora";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Mora";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Fecha Fin";
            this.gridColumn9.FieldName = "FechaFin";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gcInmuebleAlquiler
            // 
            this.gcInmuebleAlquiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInmuebleAlquiler.Location = new System.Drawing.Point(0, 79);
            this.gcInmuebleAlquiler.MainView = this.gvInmuebleAlquiler;
            this.gcInmuebleAlquiler.Name = "gcInmuebleAlquiler";
            this.gcInmuebleAlquiler.Size = new System.Drawing.Size(1012, 432);
            this.gcInmuebleAlquiler.TabIndex = 55;
            this.gcInmuebleAlquiler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInmuebleAlquiler});
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtInmuebleAlquiler);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1012, 55);
            this.groupControl1.TabIndex = 54;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // txtInmuebleAlquiler
            // 
            this.txtInmuebleAlquiler.Location = new System.Drawing.Point(49, 29);
            this.txtInmuebleAlquiler.Name = "txtInmuebleAlquiler";
            this.txtInmuebleAlquiler.Size = new System.Drawing.Size(502, 20);
            this.txtInmuebleAlquiler.TabIndex = 3;
            this.txtInmuebleAlquiler.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInmuebleAlquiler_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Cliente:";
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1012, 24);
            this.tlbMenu.TabIndex = 53;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // frmRegInmuebleAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 511);
            this.Controls.Add(this.gcInmuebleAlquiler);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegInmuebleAlquiler";
            this.Text = "Alquileres - Mantenimiento";
            this.Load += new System.EventHandler(this.frmRegInmuebleAlquiler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvInmuebleAlquiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInmuebleAlquiler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInmuebleAlquiler.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInmuebleAlquiler;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.GridControl gcInmuebleAlquiler;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtInmuebleAlquiler;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}