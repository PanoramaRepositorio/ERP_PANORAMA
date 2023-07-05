namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegGuiaRemision
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.gcGuiaRemision = new DevExpress.XtraGrid.GridControl();
            this.gvGuiaRemision = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bultosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuiaRemision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuiaRemision)).BeginInit();
            this.mnuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(972, 24);
            this.tlbMenu.TabIndex = 26;
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
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(972, 58);
            this.groupControl1.TabIndex = 27;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "N° Guia Remisión:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(103, 30);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 6;
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 22;
            this.txtNumero.EditValueChanged += new System.EventHandler(this.txtNumero_EditValueChanged);
            // 
            // gcGuiaRemision
            // 
            this.gcGuiaRemision.ContextMenuStrip = this.mnuContextual;
            this.gcGuiaRemision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGuiaRemision.Location = new System.Drawing.Point(0, 82);
            this.gcGuiaRemision.MainView = this.gvGuiaRemision;
            this.gcGuiaRemision.Name = "gcGuiaRemision";
            this.gcGuiaRemision.Size = new System.Drawing.Size(972, 413);
            this.gcGuiaRemision.TabIndex = 28;
            this.gcGuiaRemision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGuiaRemision});
            // 
            // gvGuiaRemision
            // 
            this.gvGuiaRemision.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gvGuiaRemision.GridControl = this.gcGuiaRemision;
            this.gvGuiaRemision.GroupPanelText = "Resultado de la Busqueda";
            this.gvGuiaRemision.Name = "gvGuiaRemision";
            this.gvGuiaRemision.OptionsView.ShowGroupPanel = false;
            this.gvGuiaRemision.DoubleClick += new System.EventHandler(this.gvGuiaRemision_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdGuiaRemision";
            this.gridColumn5.FieldName = "IdGuiaRemision";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Serie";
            this.gridColumn10.FieldName = "Serie";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 65;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Guia Remisión";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 97;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 83;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Empresa Destinatario";
            this.gridColumn4.FieldName = "RazonSocialDestinatario";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 233;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tienda Destinatario";
            this.gridColumn1.FieldName = "TiendaDestinatario";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Documento";
            this.gridColumn6.FieldName = "CodTipoDocumentoReferencia";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 61;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "N° Documento";
            this.gridColumn7.FieldName = "NumeroDocumento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 90;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Motivo";
            this.gridColumn8.FieldName = "DescMotivo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 175;
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bultosToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(179, 48);
            // 
            // bultosToolStripMenuItem
            // 
            this.bultosToolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Bultos_16x16;
            this.bultosToolStripMenuItem.Name = "bultosToolStripMenuItem";
            this.bultosToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.bultosToolStripMenuItem.Text = "Bultos Involucrados";
            this.bultosToolStripMenuItem.Click += new System.EventHandler(this.bultosToolStripMenuItem_Click);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Periodo";
            this.gridColumn9.FieldName = "Periodo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            // 
            // frmRegGuiaRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 495);
            this.Controls.Add(this.gcGuiaRemision);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegGuiaRemision";
            this.Text = "Guia Remisión - Mantenimiento";
            this.Load += new System.EventHandler(this.frmRegGuiaRemision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuiaRemision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuiaRemision)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraGrid.GridControl gcGuiaRemision;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGuiaRemision;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem bultosToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}