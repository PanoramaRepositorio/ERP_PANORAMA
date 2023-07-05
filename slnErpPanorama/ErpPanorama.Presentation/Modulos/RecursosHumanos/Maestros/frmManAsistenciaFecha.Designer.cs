namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManAsistenciaFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManAsistenciaFecha));
            this.gcAsistencia = new DevExpress.XtraGrid.GridControl();
            this.gvAsistencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deFechaSincronizacion = new DevExpress.XtraEditors.DateEdit();
            this.btnElimina = new DevExpress.XtraEditors.SimpleButton();
            this.btnSincronizar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarReloj2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSincronizacionReloj2 = new DevExpress.XtraEditors.SimpleButton();
            this.txtDiasReloj2 = new DevExpress.XtraEditors.TextEdit();
            this.txFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txDni = new DevExpress.XtraEditors.TextEdit();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnImportarManual = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsistencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaSincronizacion.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaSincronizacion.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiasReloj2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcAsistencia
            // 
            this.gcAsistencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAsistencia.Location = new System.Drawing.Point(0, 139);
            this.gcAsistencia.MainView = this.gvAsistencia;
            this.gcAsistencia.Name = "gcAsistencia";
            this.gcAsistencia.Size = new System.Drawing.Size(1205, 364);
            this.gcAsistencia.TabIndex = 58;
            this.gcAsistencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAsistencia});
            // 
            // gvAsistencia
            // 
            this.gvAsistencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6});
            this.gvAsistencia.GridControl = this.gcAsistencia;
            this.gvAsistencia.GroupPanelText = "Resultado de la Busqueda";
            this.gvAsistencia.Name = "gvAsistencia";
            this.gvAsistencia.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Apellidos y Nombres";
            this.gridColumn1.FieldName = "ApeNom";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 310;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 106;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Hora Ingreso";
            this.gridColumn4.DisplayFormat.FormatString = "t";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "FechaIngreso";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Hora Salida";
            this.gridColumn6.DisplayFormat.FormatString = "t";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "FechaSalida";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 131;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.txFecha);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txDni);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Controls.Add(this.btnImportarManual);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1205, 114);
            this.groupControl1.TabIndex = 57;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deFechaSincronizacion);
            this.groupBox2.Controls.Add(this.btnElimina);
            this.groupBox2.Controls.Add(this.btnSincronizar);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(513, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 82);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reloj 1 - Easy Clocking";
            // 
            // deFechaSincronizacion
            // 
            this.deFechaSincronizacion.EditValue = null;
            this.deFechaSincronizacion.Location = new System.Drawing.Point(23, 40);
            this.deFechaSincronizacion.Name = "deFechaSincronizacion";
            this.deFechaSincronizacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaSincronizacion.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaSincronizacion.Size = new System.Drawing.Size(124, 20);
            this.deFechaSincronizacion.TabIndex = 32;
            this.deFechaSincronizacion.EditValueChanged += new System.EventHandler(this.deFechaSincronizacion_EditValueChanged);
            // 
            // btnElimina
            // 
            this.btnElimina.Image = global::ErpPanorama.Presentation.Properties.Resources.Advanced_16x16;
            this.btnElimina.Location = new System.Drawing.Point(165, 27);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(124, 21);
            this.btnElimina.TabIndex = 40;
            this.btnElimina.Text = "Eliminacion";
            this.btnElimina.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Enabled = false;
            this.btnSincronizar.Image = global::ErpPanorama.Presentation.Properties.Resources.Advanced_16x16;
            this.btnSincronizar.Location = new System.Drawing.Point(165, 49);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(124, 21);
            this.btnSincronizar.TabIndex = 30;
            this.btnSincronizar.Text = "Sincronizar Reloj";
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(114, 13);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "Fecha de Sincronizacion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEliminarReloj2);
            this.groupBox1.Controls.Add(this.btnSincronizacionReloj2);
            this.groupBox1.Controls.Add(this.txtDiasReloj2);
            this.groupBox1.Location = new System.Drawing.Point(831, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 82);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reloj 2 - ZKTeco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Días\r\nAtrás:";
            // 
            // btnEliminarReloj2
            // 
            this.btnEliminarReloj2.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnEliminarReloj2.Location = new System.Drawing.Point(134, 27);
            this.btnEliminarReloj2.Name = "btnEliminarReloj2";
            this.btnEliminarReloj2.Size = new System.Drawing.Size(100, 39);
            this.btnEliminarReloj2.TabIndex = 1;
            this.btnEliminarReloj2.Text = "Sincronizar";
            this.btnEliminarReloj2.Click += new System.EventHandler(this.btnEliminarReloj2_Click);
            // 
            // btnSincronizacionReloj2
            // 
            this.btnSincronizacionReloj2.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnSincronizacionReloj2.Location = new System.Drawing.Point(143, 13);
            this.btnSincronizacionReloj2.Name = "btnSincronizacionReloj2";
            this.btnSincronizacionReloj2.Size = new System.Drawing.Size(100, 23);
            this.btnSincronizacionReloj2.TabIndex = 1;
            this.btnSincronizacionReloj2.Text = "Sincronizar Sin ELiminar";
            this.btnSincronizacionReloj2.Visible = false;
            this.btnSincronizacionReloj2.Click += new System.EventHandler(this.btnSincronizacionReloj2_Click);
            // 
            // txtDiasReloj2
            // 
            this.txtDiasReloj2.EditValue = "1";
            this.txtDiasReloj2.Location = new System.Drawing.Point(81, 35);
            this.txtDiasReloj2.Name = "txtDiasReloj2";
            this.txtDiasReloj2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiasReloj2.Properties.Appearance.Options.UseFont = true;
            this.txtDiasReloj2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDiasReloj2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDiasReloj2.Properties.Mask.EditMask = "d";
            this.txtDiasReloj2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiasReloj2.Size = new System.Drawing.Size(47, 26);
            this.txtDiasReloj2.TabIndex = 0;
            // 
            // txFecha
            // 
            this.txFecha.EditValue = null;
            this.txFecha.Location = new System.Drawing.Point(303, 86);
            this.txFecha.Name = "txFecha";
            this.txFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txFecha.Size = new System.Drawing.Size(100, 20);
            this.txFecha.TabIndex = 39;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(258, 89);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(39, 13);
            this.labelControl6.TabIndex = 38;
            this.labelControl6.Text = "Fecha : ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(165, 13);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Consulta de un Trabajador por Dni";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(409, 84);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 35;
            this.simpleButton1.Text = "Consultar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Ingrese Dni";
            // 
            // txDni
            // 
            this.txDni.Location = new System.Drawing.Point(69, 86);
            this.txDni.Name = "txDni";
            this.txDni.Size = new System.Drawing.Size(161, 20);
            this.txDni.TabIndex = 33;
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(211, 27);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 29;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(162, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Fecha Fin: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(56, 27);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 27;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(8, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(51, 13);
            this.lblFecha.TabIndex = 26;
            this.lblFecha.Text = "Fecha Ini: ";
            // 
            // btnImportarManual
            // 
            this.btnImportarManual.Image = global::ErpPanorama.Presentation.Properties.Resources.Fecha_16x16;
            this.btnImportarManual.Location = new System.Drawing.Point(1095, 30);
            this.btnImportarManual.Name = "btnImportarManual";
            this.btnImportarManual.Size = new System.Drawing.Size(98, 76);
            this.btnImportarManual.TabIndex = 21;
            this.btnImportarManual.Text = "Importación\r\nManual TXT";
            this.btnImportarManual.Click += new System.EventHandler(this.btnImportarManual_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(317, 26);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(76, 21);
            this.btnConsultar.TabIndex = 21;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
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
            this.toolStrip1.Size = new System.Drawing.Size(1205, 25);
            this.toolStrip1.TabIndex = 56;
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
            // frmManAsistenciaFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 503);
            this.Controls.Add(this.gcAsistencia);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManAsistenciaFecha";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmManAsistenciaFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsistencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaSincronizacion.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaSincronizacion.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiasReloj2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcAsistencia;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAsistencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        private DevExpress.XtraEditors.SimpleButton btnSincronizar;
        private DevExpress.XtraEditors.DateEdit deFechaSincronizacion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txDni;
        private DevExpress.XtraEditors.DateEdit txFecha;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnElimina;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnSincronizacionReloj2;
        private DevExpress.XtraEditors.TextEdit txtDiasReloj2;
        private DevExpress.XtraEditors.SimpleButton btnEliminarReloj2;
        private DevExpress.XtraEditors.SimpleButton btnImportarManual;
    }
}