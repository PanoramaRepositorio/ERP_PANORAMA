namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    partial class frmConControlAuxiliar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConControlAuxiliar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.gcPedido = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoCargoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCargoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPedido = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPedido)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 58;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolstpExportarExcel.Image")));
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // gcPedido
            // 
            this.gcPedido.ContextMenuStrip = this.mnuContextual;
            this.gcPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPedido.Location = new System.Drawing.Point(0, 25);
            this.gcPedido.MainView = this.gvPedido;
            this.gcPedido.Name = "gcPedido";
            this.gcPedido.Size = new System.Drawing.Size(849, 443);
            this.gcPedido.TabIndex = 60;
            this.gcPedido.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPedido});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCargoToolStripMenuItem,
            this.eliminarCargoToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(118, 48);
            // 
            // nuevoCargoToolStripMenuItem
            // 
            this.nuevoCargoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoCargoToolStripMenuItem.Image")));
            this.nuevoCargoToolStripMenuItem.Name = "nuevoCargoToolStripMenuItem";
            this.nuevoCargoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoCargoToolStripMenuItem.Text = "Nuevo";
            this.nuevoCargoToolStripMenuItem.Click += new System.EventHandler(this.nuevoCargoToolStripMenuItem_Click);
            // 
            // eliminarCargoToolStripMenuItem
            // 
            this.eliminarCargoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarCargoToolStripMenuItem.Image")));
            this.eliminarCargoToolStripMenuItem.Name = "eliminarCargoToolStripMenuItem";
            this.eliminarCargoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarCargoToolStripMenuItem.Text = "Eliminar";
            this.eliminarCargoToolStripMenuItem.Click += new System.EventHandler(this.eliminarCargoToolStripMenuItem_Click);
            // 
            // gvPedido
            // 
            this.gvPedido.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvPedido.GridControl = this.gcPedido;
            this.gvPedido.Name = "gvPedido";
            this.gvPedido.OptionsView.ColumnAutoWidth = false;
            this.gvPedido.OptionsView.ShowGroupPanel = false;
            this.gvPedido.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvPedido_RowStyle);
            this.gvPedido.DoubleClick += new System.EventHandler(this.gvPedido_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPersona";
            this.gridColumn1.FieldName = "IdPersona";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Nombre";
            this.gridColumn3.FieldName = "ApeNom";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 300;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Cargo";
            this.gridColumn4.FieldName = "DescCargo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 228;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "F. Picking";
            this.gridColumn5.DisplayFormat.FormatString = "hh:mm tt";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "FechaPreparado";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "N° Pedidos";
            this.gridColumn6.FieldName = "CantidadPedido";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Disponible";
            this.gridColumn7.FieldName = "Disponible";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 126;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(777, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "ACTIVO";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(358, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 21);
            this.numericUpDown1.TabIndex = 62;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Segundos";
            // 
            // frmConControlAuxiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 468);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gcPedido);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConControlAuxiliar";
            this.Text = "Control de Pedido por Persona";
            this.Load += new System.EventHandler(this.frmConControlAuxiliar_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPedido)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcPedido;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPedido;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoCargoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarCargoToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
    }
}