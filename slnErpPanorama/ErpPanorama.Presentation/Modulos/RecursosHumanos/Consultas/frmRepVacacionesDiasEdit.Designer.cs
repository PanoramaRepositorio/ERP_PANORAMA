namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    partial class frmRepVacacionesDiasEdit
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
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblFechaIngreso = new DevExpress.XtraEditors.LabelControl();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sdas = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.lblDiasVacacionesTotal = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblDiasVacacionesTomadas = new DevExpress.XtraEditors.LabelControl();
            this.lblDiasVacacionesPendientes = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcVacaciones = new DevExpress.XtraGrid.GridControl();
            this.gvVacaciones = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVacaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVacaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.btnSalir1;
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(901, 441);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblFechaIngreso);
            this.groupControl1.Controls.Add(this.lblPersona);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.sdas);
            this.groupControl1.Controls.Add(this.btnExportar);
            this.groupControl1.Location = new System.Drawing.Point(3, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(975, 55);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Datos";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.Location = new System.Drawing.Point(98, 26);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(56, 13);
            this.lblFechaIngreso.TabIndex = 22;
            this.lblFechaIngreso.Text = "01-01-1900";
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(237, 26);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(70, 13);
            this.lblPersona.TabIndex = 21;
            this.lblPersona.Text = "Datos Persona";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(182, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Persona:";
            // 
            // sdas
            // 
            this.sdas.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sdas.Appearance.Options.UseFont = true;
            this.sdas.Location = new System.Drawing.Point(9, 26);
            this.sdas.Name = "sdas";
            this.sdas.Size = new System.Drawing.Size(83, 13);
            this.sdas.TabIndex = 19;
            this.sdas.Text = "Fecha Ingreso:";
            // 
            // btnExportar
            // 
            this.btnExportar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageOptions.ImageIndex = 0;
            this.btnExportar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(889, 26);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblDiasVacacionesTotal
            // 
            this.lblDiasVacacionesTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiasVacacionesTotal.Appearance.Options.UseFont = true;
            this.lblDiasVacacionesTotal.Location = new System.Drawing.Point(114, 463);
            this.lblDiasVacacionesTotal.Name = "lblDiasVacacionesTotal";
            this.lblDiasVacacionesTotal.Size = new System.Drawing.Size(8, 16);
            this.lblDiasVacacionesTotal.TabIndex = 27;
            this.lblDiasVacacionesTotal.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(5, 463);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Dias Total:";
            // 
            // lblDiasVacacionesTomadas
            // 
            this.lblDiasVacacionesTomadas.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiasVacacionesTomadas.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDiasVacacionesTomadas.Appearance.Options.UseFont = true;
            this.lblDiasVacacionesTomadas.Appearance.Options.UseForeColor = true;
            this.lblDiasVacacionesTomadas.Location = new System.Drawing.Point(114, 427);
            this.lblDiasVacacionesTomadas.Name = "lblDiasVacacionesTomadas";
            this.lblDiasVacacionesTomadas.Size = new System.Drawing.Size(8, 16);
            this.lblDiasVacacionesTomadas.TabIndex = 24;
            this.lblDiasVacacionesTomadas.Text = "0";
            // 
            // lblDiasVacacionesPendientes
            // 
            this.lblDiasVacacionesPendientes.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiasVacacionesPendientes.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblDiasVacacionesPendientes.Appearance.Options.UseFont = true;
            this.lblDiasVacacionesPendientes.Appearance.Options.UseForeColor = true;
            this.lblDiasVacacionesPendientes.Location = new System.Drawing.Point(114, 444);
            this.lblDiasVacacionesPendientes.Name = "lblDiasVacacionesPendientes";
            this.lblDiasVacacionesPendientes.Size = new System.Drawing.Size(8, 16);
            this.lblDiasVacacionesPendientes.TabIndex = 25;
            this.lblDiasVacacionesPendientes.Text = "0";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 430);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Dias Tomadas:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Green;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 446);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 13);
            this.labelControl3.TabIndex = 25;
            this.labelControl3.Text = "Dias Pendientes:";
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl2.Controls.Add(this.gcVacaciones);
            this.groupControl2.Location = new System.Drawing.Point(3, 67);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(975, 354);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Detalle Salida de Vacaciones";
            // 
            // gcVacaciones
            // 
            this.gcVacaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVacaciones.Location = new System.Drawing.Point(2, 23);
            this.gcVacaciones.MainView = this.gvVacaciones;
            this.gcVacaciones.Name = "gcVacaciones";
            this.gcVacaciones.Size = new System.Drawing.Size(971, 329);
            this.gcVacaciones.TabIndex = 30;
            this.gcVacaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVacaciones});
            // 
            // gvVacaciones
            // 
            this.gvVacaciones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gvVacaciones.GridControl = this.gcVacaciones;
            this.gvVacaciones.GroupPanelText = "Resultado de la Busqueda";
            this.gvVacaciones.Name = "gvVacaciones";
            this.gvVacaciones.OptionsSelection.MultiSelect = true;
            this.gvVacaciones.OptionsView.ColumnAutoWidth = false;
            this.gvVacaciones.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdVacaciones";
            this.gridColumn5.FieldName = "IdVacaciones";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
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
            this.gridColumn10.VisibleIndex = 0;
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
            this.gridColumn9.VisibleIndex = 1;
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
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 44;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Situación";
            this.gridColumn3.FieldName = "DescSituacion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 92;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Gozado";
            this.gridColumn6.FieldName = "FlagGozo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 52;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Autorizado Por";
            this.gridColumn1.FieldName = "Autorizado";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 202;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Observación";
            this.gridColumn7.FieldName = "Observacion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 232;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Usuario";
            this.gridColumn14.FieldName = "Usuario";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 8;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Adelantadas";
            this.gridColumn15.FieldName = "FlagAdelantadas";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "FechaInicio ";
            this.gridColumn16.FieldName = "FechaInicio ";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "FechaFin ";
            this.gridColumn17.FieldName = "FechaFin ";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            // 
            // frmRepVacacionesDiasEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 480);
            this.Controls.Add(this.lblDiasVacacionesPendientes);
            this.Controls.Add(this.lblDiasVacacionesTomadas);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblDiasVacacionesTotal);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepVacacionesDiasEdit";
            this.Text = "Detalle Vacaciones Dias";
            this.Load += new System.EventHandler(this.frmRepVacacionesDiasEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcVacaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVacaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl sdas;
        private DevExpress.XtraEditors.LabelControl lblFechaIngreso;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcVacaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVacaciones;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblDiasVacacionesTomadas;
        private DevExpress.XtraEditors.LabelControl lblDiasVacacionesPendientes;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblDiasVacacionesTotal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}