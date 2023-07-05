namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    partial class frmRegPersonaTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPersonaTrabajo));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.gcPersonaTrabajo = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirpublicaciontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copialistatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPersonaTrabajo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersonaTrabajo)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonaTrabajo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(849, 24);
            this.tlbMenu.TabIndex = 27;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(849, 55);
            this.groupControl1.TabIndex = 59;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(17, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 80;
            this.labelControl6.Text = "Periodo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = "2016";
            this.txtPeriodo.Location = new System.Drawing.Point(63, 27);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(68, 20);
            this.txtPeriodo.TabIndex = 79;
            this.txtPeriodo.ToolTip = "Periodo";
            this.txtPeriodo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPeriodo_KeyUp);
            // 
            // gcPersonaTrabajo
            // 
            this.gcPersonaTrabajo.ContextMenuStrip = this.mnuContextual;
            this.gcPersonaTrabajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPersonaTrabajo.Location = new System.Drawing.Point(0, 79);
            this.gcPersonaTrabajo.MainView = this.gvPersonaTrabajo;
            this.gcPersonaTrabajo.Name = "gcPersonaTrabajo";
            this.gcPersonaTrabajo.Size = new System.Drawing.Size(849, 435);
            this.gcPersonaTrabajo.TabIndex = 60;
            this.gcPersonaTrabajo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersonaTrabajo});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirpublicaciontoolStripMenuItem,
            this.copialistatoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(250, 48);
            // 
            // imprimirpublicaciontoolStripMenuItem
            // 
            this.imprimirpublicaciontoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirpublicaciontoolStripMenuItem.Image")));
            this.imprimirpublicaciontoolStripMenuItem.Name = "imprimirpublicaciontoolStripMenuItem";
            this.imprimirpublicaciontoolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.imprimirpublicaciontoolStripMenuItem.Text = "Imprimir Formato de Publicación";
            this.imprimirpublicaciontoolStripMenuItem.Click += new System.EventHandler(this.imprimirpublicaciontoolStripMenuItem_Click);
            // 
            // copialistatoolStripMenuItem
            // 
            this.copialistatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Copiar_16x16;
            this.copialistatoolStripMenuItem.Name = "copialistatoolStripMenuItem";
            this.copialistatoolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.copialistatoolStripMenuItem.Text = "Copiar Lista";
            this.copialistatoolStripMenuItem.Click += new System.EventHandler(this.copialistatoolStripMenuItem_Click);
            // 
            // gvPersonaTrabajo
            // 
            this.gvPersonaTrabajo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gvPersonaTrabajo.GridControl = this.gcPersonaTrabajo;
            this.gvPersonaTrabajo.Name = "gvPersonaTrabajo";
            this.gvPersonaTrabajo.OptionsView.ShowGroupPanel = false;
            this.gvPersonaTrabajo.DoubleClick += new System.EventHandler(this.gvPersonaTrabajo_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPersonaTrabajo";
            this.gridColumn1.FieldName = "IdPersonaTrabajo";
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
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Hora Ini";
            this.gridColumn3.DisplayFormat.FormatString = "t";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "HoraInicio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Hora Fin";
            this.gridColumn4.DisplayFormat.FormatString = "t";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "HoraFin";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 81;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Observacion";
            this.gridColumn5.FieldName = "Observacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 226;
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
            this.gridColumn7.Width = 84;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Festivo";
            this.gridColumn8.FieldName = "DiaFeriado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 160;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Creado por";
            this.gridColumn9.FieldName = "Usuario";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // frmRegPersonaTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 514);
            this.Controls.Add(this.gcPersonaTrabajo);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPersonaTrabajo";
            this.Text = "Lista Domingo";
            this.Load += new System.EventHandler(this.frmRegPersonaTrabajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersonaTrabajo)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPersonaTrabajo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcPersonaTrabajo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersonaTrabajo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem imprimirpublicaciontoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copialistatoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}