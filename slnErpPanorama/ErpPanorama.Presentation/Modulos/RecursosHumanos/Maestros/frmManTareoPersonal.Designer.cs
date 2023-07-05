namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManTareoPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTareoPersonal));
            this.gcTareo = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.faltainjustificadatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarpersonatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.asignardescansotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminardiadescansotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.verlistadomingotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvTareo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.chkVerDomingo = new DevExpress.XtraEditors.CheckEdit();
            this.ceColorSeleccion = new DevExpress.XtraEditors.ColorEdit();
            this.rdgSector = new DevExpress.XtraEditors.RadioGroup();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.btnVerLeyenda = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTareo)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTareo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerDomingo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColorSeleccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgSector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcTareo
            // 
            this.gcTareo.ContextMenuStrip = this.mnuContextual;
            this.gcTareo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTareo.Location = new System.Drawing.Point(0, 88);
            this.gcTareo.MainView = this.gvTareo;
            this.gcTareo.Name = "gcTareo";
            this.gcTareo.Size = new System.Drawing.Size(1349, 438);
            this.gcTareo.TabIndex = 75;
            this.gcTareo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTareo});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.faltainjustificadatoolStripMenuItem,
            this.editarpersonatoolStripMenuItem,
            this.toolStripSeparator5,
            this.asignardescansotoolStripMenuItem,
            this.eliminardiadescansotoolStripMenuItem,
            this.toolStripSeparator4,
            this.verlistadomingotoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(248, 126);
            // 
            // faltainjustificadatoolStripMenuItem
            // 
            this.faltainjustificadatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Ausencia_32x32;
            this.faltainjustificadatoolStripMenuItem.Name = "faltainjustificadatoolStripMenuItem";
            this.faltainjustificadatoolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.faltainjustificadatoolStripMenuItem.Text = "Asignar Motivo de Ausencia";
            this.faltainjustificadatoolStripMenuItem.Click += new System.EventHandler(this.faltainjustificadatoolStripMenuItem_Click);
            // 
            // editarpersonatoolStripMenuItem
            // 
            this.editarpersonatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Personal_32x32;
            this.editarpersonatoolStripMenuItem.Name = "editarpersonatoolStripMenuItem";
            this.editarpersonatoolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.editarpersonatoolStripMenuItem.Text = "Editar Personal";
            this.editarpersonatoolStripMenuItem.Click += new System.EventHandler(this.editarpersonatoolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(244, 6);
            // 
            // asignardescansotoolStripMenuItem
            // 
            this.asignardescansotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Horario_32x32;
            this.asignardescansotoolStripMenuItem.Name = "asignardescansotoolStripMenuItem";
            this.asignardescansotoolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.asignardescansotoolStripMenuItem.Text = "Asignar Día descanso";
            this.asignardescansotoolStripMenuItem.Click += new System.EventHandler(this.asignardescansotoolStripMenuItem_Click);
            // 
            // eliminardiadescansotoolStripMenuItem
            // 
            this.eliminardiadescansotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Eliminar_16x16;
            this.eliminardiadescansotoolStripMenuItem.Name = "eliminardiadescansotoolStripMenuItem";
            this.eliminardiadescansotoolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.eliminardiadescansotoolStripMenuItem.Text = "Eliminar Día descanso";
            this.eliminardiadescansotoolStripMenuItem.Click += new System.EventHandler(this.eliminardiadescansotoolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(244, 6);
            // 
            // verlistadomingotoolStripMenuItem
            // 
            this.verlistadomingotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.PersonaTrabajo_16x16;
            this.verlistadomingotoolStripMenuItem.Name = "verlistadomingotoolStripMenuItem";
            this.verlistadomingotoolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.verlistadomingotoolStripMenuItem.Text = "Ver Lista de Domingos y Feriados";
            this.verlistadomingotoolStripMenuItem.Click += new System.EventHandler(this.verlistadomingotoolStripMenuItem_Click);
            // 
            // gvTareo
            // 
            this.gvTareo.GridControl = this.gcTareo;
            this.gvTareo.GroupPanelText = "Resultado de la Busqueda";
            this.gvTareo.Name = "gvTareo";
            this.gvTareo.OptionsFilter.ColumnFilterPopupMode = DevExpress.XtraGrid.Columns.ColumnFilterPopupMode.Excel;
            this.gvTareo.OptionsView.ColumnAutoWidth = false;
            this.gvTareo.OptionsView.ShowGroupPanel = false;
            this.gvTareo.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvTareo_CustomDrawCell);
            this.gvTareo.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvTareo_RowCellStyle);
            this.gvTareo.ColumnFilterChanged += new System.EventHandler(this.gvTareo_ColumnFilterChanged);
            this.gvTareo.DoubleClick += new System.EventHandler(this.gvTareo_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1349, 63);
            this.panel1.TabIndex = 74;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblTotalRegistros);
            this.groupControl1.Controls.Add(this.chkVerDomingo);
            this.groupControl1.Controls.Add(this.ceColorSeleccion);
            this.groupControl1.Controls.Add(this.rdgSector);
            this.groupControl1.Controls.Add(this.cboMes);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtPeriodo);
            this.groupControl1.Controls.Add(this.btnVerLeyenda);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1349, 57);
            this.groupControl1.TabIndex = 58;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Location = new System.Drawing.Point(1169, 33);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 76;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // chkVerDomingo
            // 
            this.chkVerDomingo.Location = new System.Drawing.Point(824, 30);
            this.chkVerDomingo.Name = "chkVerDomingo";
            this.chkVerDomingo.Properties.Caption = "&Ver Domingo";
            this.chkVerDomingo.Size = new System.Drawing.Size(87, 20);
            this.chkVerDomingo.TabIndex = 64;
            this.chkVerDomingo.CheckedChanged += new System.EventHandler(this.chkVerDomingo_CheckedChanged);
            // 
            // ceColorSeleccion
            // 
            this.ceColorSeleccion.EditValue = System.Drawing.Color.Empty;
            this.ceColorSeleccion.Location = new System.Drawing.Point(712, 29);
            this.ceColorSeleccion.Name = "ceColorSeleccion";
            this.ceColorSeleccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceColorSeleccion.Size = new System.Drawing.Size(100, 20);
            this.ceColorSeleccion.TabIndex = 63;
            this.ceColorSeleccion.ColorChanged += new System.EventHandler(this.ceColorSeleccion_ColorChanged);
            // 
            // rdgSector
            // 
            this.rdgSector.Location = new System.Drawing.Point(416, 24);
            this.rdgSector.Name = "rdgSector";
            this.rdgSector.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Estándar"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Calculado")});
            this.rdgSector.Size = new System.Drawing.Size(225, 30);
            this.rdgSector.TabIndex = 62;
            this.rdgSector.SelectedIndexChanged += new System.EventHandler(this.rdgSector_SelectedIndexChanged);
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(150, 27);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.DropDownRows = 12;
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 61;
            this.cboMes.SelectedValueChanged += new System.EventHandler(this.cboMes_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(658, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 60;
            this.labelControl1.Text = "Selección:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(121, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 60;
            this.labelControl2.Text = "Mes:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 59;
            this.labelControl6.Text = "Periodo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(55, 27);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(54, 20);
            this.txtPeriodo.TabIndex = 58;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // btnVerLeyenda
            // 
            this.btnVerLeyenda.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Help_16x16;
            this.btnVerLeyenda.Location = new System.Drawing.Point(1241, 28);
            this.btnVerLeyenda.Name = "btnVerLeyenda";
            this.btnVerLeyenda.Size = new System.Drawing.Size(96, 21);
            this.btnVerLeyenda.TabIndex = 21;
            this.btnVerLeyenda.Text = "Ver &Leyenda";
            this.btnVerLeyenda.Click += new System.EventHandler(this.btnVerLeyenda_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(266, 26);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(76, 21);
            this.btnConsultar.TabIndex = 21;
            this.btnConsultar.Text = "&Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpExcel,
            this.toolStripSeparator3,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1349, 25);
            this.toolStrip1.TabIndex = 73;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolstpExcel
            // 
            this.toolstpExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExcel.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.toolstpExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExcel.Name = "toolstpExcel";
            this.toolstpExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExcel.ToolTipText = "Exportar Excel";
            this.toolstpExcel.Click += new System.EventHandler(this.toolstpExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // frmManTareoPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 526);
            this.Controls.Add(this.gcTareo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmManTareoPersonal";
            this.Text = "Tareo Mensual del Personal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmManTareoPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTareo)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTareo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerDomingo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColorSeleccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgSector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTareo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTareo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpExcel;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup rdgSector;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem faltainjustificadatoolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnVerLeyenda;
        private DevExpress.XtraEditors.ColorEdit ceColorSeleccion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkVerDomingo;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private System.Windows.Forms.ToolStripMenuItem editarpersonatoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignardescansotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminardiadescansotoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem verlistadomingotoolStripMenuItem;
    }
}