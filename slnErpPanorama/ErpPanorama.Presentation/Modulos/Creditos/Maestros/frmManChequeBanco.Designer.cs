
namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    partial class frmManChequeBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManChequeBanco));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcChequeBanco = new DevExpress.XtraGrid.GridControl();
            this.gvChequeBanco = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tblMenu = new System.Windows.Forms.ToolStrip();
            this.btnNuevoCheque = new System.Windows.Forms.ToolStripButton();
            this.btnEditarCheque = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarCheque = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConsultarCheque = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bntExportar = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bntSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChequeBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChequeBanco)).BeginInit();
            this.tblMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSize = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.cboEmpresa);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(618, 35);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(328, 6);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(63, 8);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Size = new System.Drawing.Size(247, 20);
            this.cboEmpresa.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Empresa: ";
            // 
            // gcChequeBanco
            // 
            this.gcChequeBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcChequeBanco.Location = new System.Drawing.Point(0, 60);
            this.gcChequeBanco.MainView = this.gvChequeBanco;
            this.gcChequeBanco.Name = "gcChequeBanco";
            this.gcChequeBanco.Size = new System.Drawing.Size(618, 468);
            this.gcChequeBanco.TabIndex = 3;
            this.gcChequeBanco.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChequeBanco});
            // 
            // gvChequeBanco
            // 
            this.gvChequeBanco.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvChequeBanco.GridControl = this.gcChequeBanco;
            this.gvChequeBanco.Name = "gvChequeBanco";
            this.gvChequeBanco.OptionsBehavior.Editable = false;
            this.gvChequeBanco.OptionsView.ColumnAutoWidth = false;
            this.gvChequeBanco.OptionsView.ShowGroupPanel = false;
            this.gvChequeBanco.DoubleClick += new System.EventHandler(this.gvChequeBanco_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Empresa";
            this.gridColumn1.FieldName = "RazonSocial";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Banco";
            this.gridColumn2.FieldName = "DesBanco";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Moneda";
            this.gridColumn3.FieldName = "DesMoneda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Numeración";
            this.gridColumn4.FieldName = "NumeroCheque";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "id";
            this.gridColumn5.FieldName = "IdChequeBanco";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // tblMenu
            // 
            this.tblMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tblMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoCheque,
            this.btnEditarCheque,
            this.btnEliminarCheque,
            this.toolStripSeparator3,
            this.btnConsultarCheque,
            this.toolStripSeparator2,
            this.bntExportar,
            this.btnActualizar,
            this.toolStripSeparator4,
            this.bntSalir,
            this.toolStripSeparator1});
            this.tblMenu.Location = new System.Drawing.Point(0, 0);
            this.tblMenu.Name = "tblMenu";
            this.tblMenu.Size = new System.Drawing.Size(618, 25);
            this.tblMenu.TabIndex = 76;
            this.tblMenu.Text = "toolStrip2";
            // 
            // btnNuevoCheque
            // 
            this.btnNuevoCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoCheque.Image = global::ErpPanorama.Presentation.Properties.Resources.btnNuevo_Image;
            this.btnNuevoCheque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevoCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoCheque.Name = "btnNuevoCheque";
            this.btnNuevoCheque.Size = new System.Drawing.Size(23, 22);
            this.btnNuevoCheque.Text = "&Nuevo";
            this.btnNuevoCheque.Click += new System.EventHandler(this.btnNuevoCheque_Click);
            // 
            // btnEditarCheque
            // 
            this.btnEditarCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditarCheque.Image = global::ErpPanorama.Presentation.Properties.Resources.btnEditar_Image;
            this.btnEditarCheque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditarCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarCheque.Name = "btnEditarCheque";
            this.btnEditarCheque.Size = new System.Drawing.Size(23, 22);
            this.btnEditarCheque.Text = "Editar";
            this.btnEditarCheque.Visible = false;
            // 
            // btnEliminarCheque
            // 
            this.btnEliminarCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarCheque.Image = global::ErpPanorama.Presentation.Properties.Resources.btnEliminar_Image;
            this.btnEliminarCheque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminarCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarCheque.Name = "btnEliminarCheque";
            this.btnEliminarCheque.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarCheque.Text = "Anular";
            this.btnEliminarCheque.Click += new System.EventHandler(this.btnEliminarCheque_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnConsultarCheque
            // 
            this.btnConsultarCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConsultarCheque.Image = global::ErpPanorama.Presentation.Properties.Resources.btn_buscar;
            this.btnConsultarCheque.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConsultarCheque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsultarCheque.Name = "btnConsultarCheque";
            this.btnConsultarCheque.Size = new System.Drawing.Size(23, 22);
            this.btnConsultarCheque.Text = "Ver";
            this.btnConsultarCheque.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // bntExportar
            // 
            this.bntExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bntExportar.Image = ((System.Drawing.Image)(resources.GetObject("bntExportar.Image")));
            this.bntExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bntExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntExportar.Name = "bntExportar";
            this.bntExportar.Size = new System.Drawing.Size(23, 22);
            this.bntExportar.ToolTipText = "Exportar Excel";
            this.bntExportar.Click += new System.EventHandler(this.bntExportar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(23, 22);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.ToolTipText = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bntSalir
            // 
            this.bntSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bntSalir.Image = global::ErpPanorama.Presentation.Properties.Resources.btn_salir1;
            this.bntSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bntSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntSalir.Name = "bntSalir";
            this.bntSalir.Size = new System.Drawing.Size(24, 22);
            this.bntSalir.Text = "Cerrar";
            this.bntSalir.ToolTipText = "Salir";
            this.bntSalir.Click += new System.EventHandler(this.bntSalir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // frmManChequeBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 528);
            this.Controls.Add(this.tblMenu);
            this.Controls.Add(this.gcChequeBanco);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmManChequeBanco";
            this.Load += new System.EventHandler(this.frmManChequeBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChequeBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChequeBanco)).EndInit();
            this.tblMenu.ResumeLayout(false);
            this.tblMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcChequeBanco;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChequeBanco;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.ToolStrip tblMenu;
        private System.Windows.Forms.ToolStripButton btnNuevoCheque;
        private System.Windows.Forms.ToolStripButton btnEditarCheque;
        private System.Windows.Forms.ToolStripButton btnEliminarCheque;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnConsultarCheque;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bntExportar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bntSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}