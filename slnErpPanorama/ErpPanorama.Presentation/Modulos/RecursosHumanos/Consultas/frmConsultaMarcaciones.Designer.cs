namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    partial class frmConsultaMarcaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaMarcaciones));
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.txDni = new DevExpress.XtraEditors.TextEdit();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.gcMarcacion = new DevExpress.XtraGrid.GridControl();
            this.gvMarcacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(580, 39);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(119, 23);
            this.simpleButton2.TabIndex = 33;
            this.simpleButton2.Text = "Consultar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txDni
            // 
            this.txDni.Location = new System.Drawing.Point(386, 41);
            this.txDni.Name = "txDni";
            this.txDni.Properties.MaxLength = 8;
            this.txDni.Size = new System.Drawing.Size(151, 20);
            this.txDni.TabIndex = 29;
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(113, 41);
            this.deDesde.Name = "deDesde";
            this.deDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Size = new System.Drawing.Size(141, 20);
            this.deDesde.TabIndex = 26;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.txDni);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.deDesde);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(878, 86);
            this.groupControl1.TabIndex = 63;
            this.groupControl1.Text = "Consulta de Marcaciones";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(294, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 13);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "Ingrese Dni";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Fecha Desde";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(878, 25);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(23, 22);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // gcMarcacion
            // 
            this.gcMarcacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMarcacion.Location = new System.Drawing.Point(0, 111);
            this.gcMarcacion.MainView = this.gvMarcacion;
            this.gcMarcacion.Name = "gcMarcacion";
            this.gcMarcacion.Size = new System.Drawing.Size(878, 416);
            this.gcMarcacion.TabIndex = 64;
            this.gcMarcacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMarcacion});
            // 
            // gvMarcacion
            // 
            this.gvMarcacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvMarcacion.GridControl = this.gcMarcacion;
            this.gvMarcacion.Name = "gvMarcacion";
            this.gvMarcacion.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Dni";
            this.gridColumn1.FieldName = "dni";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 172;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nombres y Apellidos";
            this.gridColumn2.FieldName = "ApeNom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 172;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Marcacion";
            this.gridColumn4.FieldName = "Marcacion";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 172;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tienda";
            this.gridColumn5.FieldName = "DescTienda";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 143;
            // 
            // frmConsultaMarcaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 527);
            this.Controls.Add(this.gcMarcacion);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConsultaMarcaciones";
            this.Text = "frmConsultaMarcaciones";
            this.Load += new System.EventHandler(this.frmConsultaMarcaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txDni;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraGrid.GridControl gcMarcacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarcacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
    }
}