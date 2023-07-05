namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    partial class frmRegHorarioPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegHorarioPersona));
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcHorarioPersona = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bloquearhorariotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desBloquearHorariotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvHorarioPersona = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcHorarioPersonaDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvHorarioPersonaDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHorarioPersona)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvHorarioPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHorarioPersonaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHorarioPersonaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(757, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 42;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(56, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(412, 20);
            this.txtDescripcion.TabIndex = 41;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 40;
            this.labelControl1.Text = "Turno:";
            // 
            // gcHorarioPersona
            // 
            this.gcHorarioPersona.ContextMenuStrip = this.mnuContextual;
            this.gcHorarioPersona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHorarioPersona.Location = new System.Drawing.Point(0, 0);
            this.gcHorarioPersona.MainView = this.gvHorarioPersona;
            this.gcHorarioPersona.Name = "gcHorarioPersona";
            this.gcHorarioPersona.Size = new System.Drawing.Size(464, 441);
            this.gcHorarioPersona.TabIndex = 43;
            this.gcHorarioPersona.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHorarioPersona});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloquearhorariotoolStripMenuItem,
            this.desBloquearHorariotoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(184, 48);
            // 
            // bloquearhorariotoolStripMenuItem
            // 
            this.bloquearhorariotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Lock_32x32;
            this.bloquearhorariotoolStripMenuItem.Name = "bloquearhorariotoolStripMenuItem";
            this.bloquearhorariotoolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.bloquearhorariotoolStripMenuItem.Text = "Bloquear Horario";
            this.bloquearhorariotoolStripMenuItem.Click += new System.EventHandler(this.bloquearhorariotoolStripMenuItem_Click);
            // 
            // desBloquearHorariotoolStripMenuItem
            // 
            this.desBloquearHorariotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Unlock_32x32;
            this.desBloquearHorariotoolStripMenuItem.Name = "desBloquearHorariotoolStripMenuItem";
            this.desBloquearHorariotoolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.desBloquearHorariotoolStripMenuItem.Text = "Desbloquear Horario";
            this.desBloquearHorariotoolStripMenuItem.Click += new System.EventHandler(this.desBloquearHorariotoolStripMenuItem_Click);
            // 
            // gvHorarioPersona
            // 
            this.gvHorarioPersona.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvHorarioPersona.GridControl = this.gcHorarioPersona;
            this.gvHorarioPersona.Name = "gvHorarioPersona";
            this.gvHorarioPersona.OptionsView.ColumnAutoWidth = false;
            this.gvHorarioPersona.OptionsView.ShowGroupPanel = false;
            this.gvHorarioPersona.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvHorarioPersona_FocusedRowChanged);
            this.gvHorarioPersona.Click += new System.EventHandler(this.gvHorarioPersona_Click);
            this.gvHorarioPersona.DoubleClick += new System.EventHandler(this.gvHorarioPersona_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPersona";
            this.gridColumn1.FieldName = "IdPersona";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Apellidos y Nombres";
            this.gridColumn2.FieldName = "ApeNom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 341;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Horas";
            this.gridColumn3.FieldName = "TotalHorasTrab";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(10, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcHorarioPersona);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcHorarioPersonaDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(1119, 441);
            this.splitContainer1.SplitterDistance = 464;
            this.splitContainer1.TabIndex = 44;
            // 
            // gcHorarioPersonaDetalle
            // 
            this.gcHorarioPersonaDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHorarioPersonaDetalle.Location = new System.Drawing.Point(0, 0);
            this.gcHorarioPersonaDetalle.MainView = this.gvHorarioPersonaDetalle;
            this.gcHorarioPersonaDetalle.Name = "gcHorarioPersonaDetalle";
            this.gcHorarioPersonaDetalle.Size = new System.Drawing.Size(651, 441);
            this.gcHorarioPersonaDetalle.TabIndex = 42;
            this.gcHorarioPersonaDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHorarioPersonaDetalle});
            // 
            // gvHorarioPersonaDetalle
            // 
            this.gvHorarioPersonaDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn6});
            this.gvHorarioPersonaDetalle.GridControl = this.gcHorarioPersonaDetalle;
            this.gvHorarioPersonaDetalle.Name = "gvHorarioPersonaDetalle";
            this.gvHorarioPersonaDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvHorarioPersonaDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdTurnoDetalle";
            this.gridColumn4.FieldName = "IdTurnoDetalle";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdTurno";
            this.gridColumn5.FieldName = "IdTurno";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "H. Ingreso";
            this.gridColumn7.DisplayFormat.FormatString = "t";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "FechaIngreso";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 79;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "H. Sal Ref";
            this.gridColumn8.DisplayFormat.FormatString = "t";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn8.FieldName = "FechaSalidaRef";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 81;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn9.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn9.Caption = "H. Ing Ref";
            this.gridColumn9.DisplayFormat.FormatString = "t";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn9.FieldName = "FechaIngresoRef";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 82;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "H. Salida";
            this.gridColumn10.DisplayFormat.FormatString = "t";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn10.FieldName = "FechaSalida";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            this.gridColumn10.Width = 81;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Min Ref";
            this.gridColumn11.FieldName = "TotalHorasRef";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            this.gridColumn11.Width = 55;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Horas";
            this.gridColumn12.FieldName = "TotalHorasTrab";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 7;
            this.gridColumn12.Width = 55;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "FlagEstado";
            this.gridColumn13.FieldName = "FlagEstado";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Width = 32;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Día";
            this.gridColumn14.FieldName = "DiaSemanaName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Fecha";
            this.gridColumn6.FieldName = "Fecha";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(492, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 45;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(671, 31);
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
            this.deHasta.TabIndex = 48;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(633, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 47;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(533, 31);
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
            this.deDesde.TabIndex = 46;
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1141, 24);
            this.tlbMenu.TabIndex = 31;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // frmRegHorarioPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 509);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.deHasta);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.deDesde);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegHorarioPersona";
            this.Text = "Horario Persona";
            this.Load += new System.EventHandler(this.frmRegHorarioPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHorarioPersona)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvHorarioPersona)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcHorarioPersonaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHorarioPersonaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcHorarioPersona;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHorarioPersona;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.GridControl gcHorarioPersonaDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHorarioPersonaDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private ControlUser.UIToolBar tlbMenu;
        public System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem bloquearhorariotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desBloquearHorariotoolStripMenuItem;
    }
}