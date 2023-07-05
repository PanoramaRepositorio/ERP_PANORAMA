namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    partial class frmRegHojaInstalacionPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegHojaInstalacionPedido));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.gcHojaInstalacion = new DevExpress.XtraGrid.GridControl();
            this.gvHojaInstalacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reservartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHojaInstalacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHojaInstalacion)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.deHasta);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.deDesde);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(693, 55);
            this.groupControl1.TabIndex = 61;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(277, 23);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(191, 23);
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
            this.deHasta.TabIndex = 15;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(153, 26);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(53, 23);
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
            this.deDesde.TabIndex = 13;
            // 
            // gcHojaInstalacion
            // 
            this.gcHojaInstalacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcHojaInstalacion.Location = new System.Drawing.Point(0, 55);
            this.gcHojaInstalacion.MainView = this.gvHojaInstalacion;
            this.gcHojaInstalacion.Name = "gcHojaInstalacion";
            this.gcHojaInstalacion.Size = new System.Drawing.Size(693, 398);
            this.gcHojaInstalacion.TabIndex = 62;
            this.gcHojaInstalacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHojaInstalacion});
            // 
            // gvHojaInstalacion
            // 
            this.gvHojaInstalacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvHojaInstalacion.GridControl = this.gcHojaInstalacion;
            this.gvHojaInstalacion.Name = "gvHojaInstalacion";
            this.gvHojaInstalacion.OptionsView.ShowGroupPanel = false;
            this.gvHojaInstalacion.RowHeight = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdHojaInstalacion";
            this.gridColumn1.FieldName = "IdHojaInstalacion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 76;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "10:00 - 13:00";
            this.gridColumn3.DisplayFormat.FormatString = "t";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "HoraInicio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 114;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "15:00 - 18:00";
            this.gridColumn4.DisplayFormat.FormatString = "t";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "HoraFin";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 124;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Observación";
            this.gridColumn5.FieldName = "Observacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 167;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "FlagEstado";
            this.gridColumn6.FieldName = "FlagEstado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Día Semana";
            this.gridColumn7.FieldName = "DiaSemana";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservartoolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // reservartoolStripMenuItem
            // 
            this.reservartoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Aprobar_16x16;
            this.reservartoolStripMenuItem.Name = "reservartoolStripMenuItem";
            this.reservartoolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reservartoolStripMenuItem.Text = "Reservar";
            this.reservartoolStripMenuItem.Click += new System.EventHandler(this.reservartoolStripMenuItem_Click);
            // 
            // frmRegHojaInstalacionPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 453);
            this.Controls.Add(this.gcHojaInstalacion);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegHojaInstalacionPedido";
            this.Text = "Reserva de Servicio de Instalación";
            this.Load += new System.EventHandler(this.frmRegHojaInstalacionPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHojaInstalacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHojaInstalacion)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraGrid.GridControl gcHojaInstalacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHojaInstalacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservartoolStripMenuItem;
    }
}