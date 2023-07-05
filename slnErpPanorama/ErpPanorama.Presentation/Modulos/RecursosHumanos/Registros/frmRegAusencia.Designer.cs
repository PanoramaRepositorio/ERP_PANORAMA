namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    partial class frmRegAusencia
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.txtApeNom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gcAusencia = new DevExpress.XtraGrid.GridControl();
            this.gvAusencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CambiarRecuperaciontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApeNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAusencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAusencia)).BeginInit();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1287, 24);
            this.tlbMenu.TabIndex = 25;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.txtApeNom);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1287, 49);
            this.groupControl1.TabIndex = 26;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(11, 29);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 78;
            this.labelControl6.Text = "Periodo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(57, 24);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(54, 20);
            this.txtPeriodo.TabIndex = 77;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // txtApeNom
            // 
            this.txtApeNom.Location = new System.Drawing.Point(180, 24);
            this.txtApeNom.Name = "txtApeNom";
            this.txtApeNom.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApeNom.Properties.MaxLength = 50;
            this.txtApeNom.Size = new System.Drawing.Size(378, 20);
            this.txtApeNom.TabIndex = 76;
            this.txtApeNom.EditValueChanged += new System.EventHandler(this.txtApeNom_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(129, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 73;
            this.labelControl5.Text = "Personal:";
            // 
            // gcAusencia
            // 
            this.gcAusencia.ContextMenuStrip = this.mnuContextual;
            this.gcAusencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAusencia.Location = new System.Drawing.Point(0, 73);
            this.gcAusencia.MainView = this.gvAusencia;
            this.gcAusencia.Name = "gcAusencia";
            this.gcAusencia.Size = new System.Drawing.Size(1287, 424);
            this.gcAusencia.TabIndex = 27;
            this.gcAusencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAusencia});
            // 
            // gvAusencia
            // 
            this.gvAusencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn11,
            this.gridColumn12});
            this.gvAusencia.GridControl = this.gcAusencia;
            this.gvAusencia.GroupPanelText = "Resultado de la Busqueda";
            this.gvAusencia.Name = "gvAusencia";
            this.gvAusencia.OptionsView.ColumnAutoWidth = false;
            this.gvAusencia.OptionsView.ShowGroupPanel = false;
            this.gvAusencia.DoubleClick += new System.EventHandler(this.gvAusencia_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdAusencia";
            this.gridColumn5.FieldName = "IdAusencia";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Apellidos y Nombres";
            this.gridColumn4.FieldName = "ApeNom";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 280;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "F. Desde";
            this.gridColumn10.FieldName = "FechaDesde";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "F. Hasta";
            this.gridColumn9.FieldName = "FechaHasta";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 85;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Dias";
            this.gridColumn2.FieldName = "Dias";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 44;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Motivo de Ausencia";
            this.gridColumn3.FieldName = "DescMotivoAusencia";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 229;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Autorizado Por";
            this.gridColumn1.FieldName = "Autorizado";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 250;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Observacion";
            this.gridColumn6.FieldName = "Observacion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 288;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "F. Recuperación";
            this.gridColumn7.FieldName = "FechaRecupera";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "A.Recuperación";
            this.gridColumn8.FieldName = "AsistenciaRecupera";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CambiarRecuperaciontoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(231, 26);
            // 
            // CambiarRecuperaciontoolStripMenuItem
            // 
            this.CambiarRecuperaciontoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Encuesta_16x16;
            this.CambiarRecuperaciontoolStripMenuItem.Name = "CambiarRecuperaciontoolStripMenuItem";
            this.CambiarRecuperaciontoolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.CambiarRecuperaciontoolStripMenuItem.Text = "Cambiar Día de Recuperación";
            this.CambiarRecuperaciontoolStripMenuItem.Click += new System.EventHandler(this.CambiarRecuperaciontoolStripMenuItem_Click);
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Dni";
            this.gridColumn11.FieldName = "Dni";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdPersona";
            this.gridColumn12.FieldName = "IdPersona";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // frmRegAusencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 497);
            this.Controls.Add(this.gcAusencia);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegAusencia";
            this.Text = "Ausencia de Personal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegAusencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApeNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAusencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAusencia)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.TextEdit txtApeNom;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl gcAusencia;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAusencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem CambiarRecuperaciontoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
    }
}