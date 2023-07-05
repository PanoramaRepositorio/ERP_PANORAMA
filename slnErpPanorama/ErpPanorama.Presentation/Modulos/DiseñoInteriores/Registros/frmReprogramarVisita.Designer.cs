namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    partial class frmReprogramarVisita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReprogramarVisita));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.gcPendientes = new DevExpress.XtraGrid.GridControl();
            this.gvPendientes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.btnNuevoCliente = new DevExpress.XtraEditors.SimpleButton();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.denavAgenda = new DevExpress.XtraScheduler.DateNavigator();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAsesor = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumProyecto = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtNumProyecto);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.gcPendientes);
            this.grdDatos.Controls.Add(this.labelControl12);
            this.grdDatos.Controls.Add(this.cboDepartamento);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Controls.Add(this.cboProvincia);
            this.grdDatos.Controls.Add(this.labelControl19);
            this.grdDatos.Controls.Add(this.labelControl11);
            this.grdDatos.Controls.Add(this.btnNuevoCliente);
            this.grdDatos.Controls.Add(this.txtCelular);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtAgenda);
            this.grdDatos.Controls.Add(this.textBox3);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboDistrito);
            this.grdDatos.Controls.Add(this.labelControl18);
            this.grdDatos.Controls.Add(this.txtDireccion);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.denavAgenda);
            this.grdDatos.Controls.Add(this.btnBuscar);
            this.grdDatos.Controls.Add(this.txtDescCliente);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboMotivo);
            this.grdDatos.Controls.Add(this.lblAsesor);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(1183, 257);
            this.grdDatos.TabIndex = 3;
            this.grdDatos.Text = "Datos de Visita";
            // 
            // gcPendientes
            // 
            this.gcPendientes.Location = new System.Drawing.Point(983, 49);
            this.gcPendientes.MainView = this.gvPendientes;
            this.gcPendientes.Name = "gcPendientes";
            this.gcPendientes.Size = new System.Drawing.Size(188, 194);
            this.gcPendientes.TabIndex = 158;
            this.gcPendientes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPendientes});
            // 
            // gvPendientes
            // 
            this.gvPendientes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gvPendientes.GridControl = this.gcPendientes;
            this.gvPendientes.Name = "gvPendientes";
            this.gvPendientes.OptionsBehavior.Editable = false;
            this.gvPendientes.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Visita";
            this.gridColumn1.FieldName = "NumAgendaVisita";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 65;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "StrFechaAgenda";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 98;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.FieldName = "IdAgendaVisita";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(982, 28);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(90, 13);
            this.labelControl12.TabIndex = 157;
            this.labelControl12.Text = "Visitas Pendientes:";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Enabled = false;
            this.cboDepartamento.Location = new System.Drawing.Point(71, 89);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.NullText = "";
            this.cboDepartamento.Size = new System.Drawing.Size(153, 20);
            this.cboDepartamento.TabIndex = 6;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(544, 196);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(463, 196);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Enabled = false;
            this.cboProvincia.Location = new System.Drawing.Point(290, 89);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.NullText = "";
            this.cboProvincia.Size = new System.Drawing.Size(121, 20);
            this.cboProvincia.TabIndex = 7;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(241, 93);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(47, 13);
            this.labelControl19.TabIndex = 152;
            this.labelControl19.Text = "Provincia:";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(30, 92);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(37, 13);
            this.labelControl11.TabIndex = 150;
            this.labelControl11.Text = "Depto.:";
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Enabled = false;
            this.btnNuevoCliente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoCliente.ImageOptions.Image")));
            this.btnNuevoCliente.Location = new System.Drawing.Point(593, 46);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(26, 20);
            this.btnNuevoCliente.TabIndex = 4;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(71, 110);
            this.txtCelular.MaxLength = 20;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(153, 21);
            this.txtCelular.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(30, 114);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(37, 13);
            this.labelControl7.TabIndex = 145;
            this.labelControl7.Text = "Celular:";
            // 
            // txtAgenda
            // 
            this.txtAgenda.Location = new System.Drawing.Point(71, 132);
            this.txtAgenda.MaxLength = 120;
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.Size = new System.Drawing.Size(548, 21);
            this.txtAgenda.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(527, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(92, 21);
            this.textBox3.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(471, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 13);
            this.labelControl3.TabIndex = 139;
            this.labelControl3.Text = "Nro. Visita:";
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(470, 89);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.NullText = "";
            this.cboDistrito.Size = new System.Drawing.Size(149, 20);
            this.cboDistrito.TabIndex = 8;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(426, 93);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(38, 13);
            this.labelControl18.TabIndex = 137;
            this.labelControl18.Text = "Distrito:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(71, 67);
            this.txtDireccion.MaxLength = 120;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(548, 21);
            this.txtDireccion.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(37, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 131;
            this.labelControl2.Text = "Lugar:";
            // 
            // denavAgenda
            // 
            this.denavAgenda.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.denavAgenda.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.denavAgenda.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.denavAgenda.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denavAgenda.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.ClassicNew;
            this.denavAgenda.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.denavAgenda.Location = new System.Drawing.Point(625, 24);
            this.denavAgenda.Name = "denavAgenda";
            this.denavAgenda.NavigationMode = DevExpress.XtraScheduler.DateNavigationMode.ScrollCalendar;
            this.denavAgenda.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
            this.denavAgenda.ShowFooter = false;
            this.denavAgenda.ShowHeader = false;
            this.denavAgenda.ShowTodayButton = false;
            this.denavAgenda.ShowWeekNumbers = false;
            this.denavAgenda.Size = new System.Drawing.Size(352, 219);
            this.denavAgenda.TabIndex = 130;
            this.denavAgenda.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)(((((DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.QuarterView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.denavAgenda.EditValueChanged += new System.EventHandler(this.denavAgenda_EditValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(164, 46);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(191, 46);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(401, 20);
            this.txtDescCliente.TabIndex = 126;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Enabled = false;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(71, 46);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Properties.ReadOnly = true;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(92, 20);
            this.txtNumeroDocumento.TabIndex = 0;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 49);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 123;
            this.labelControl5.Text = "Cliente:";
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(363, 110);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboMotivo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cboMotivo.Properties.Appearance.Options.UseFont = true;
            this.cboMotivo.Properties.Appearance.Options.UseForeColor = true;
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(256, 20);
            this.cboMotivo.TabIndex = 10;
            // 
            // lblAsesor
            // 
            this.lblAsesor.Location = new System.Drawing.Point(323, 113);
            this.lblAsesor.Name = "lblAsesor";
            this.lblAsesor.Size = new System.Drawing.Size(36, 13);
            this.lblAsesor.TabIndex = 116;
            this.lblAsesor.Text = "Motivo:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(26, 136);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(41, 13);
            this.labelControl20.TabIndex = 32;
            this.labelControl20.Text = "Agenda:";
            // 
            // txtNumProyecto
            // 
            this.txtNumProyecto.Enabled = false;
            this.txtNumProyecto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumProyecto.Location = new System.Drawing.Point(71, 23);
            this.txtNumProyecto.Name = "txtNumProyecto";
            this.txtNumProyecto.Size = new System.Drawing.Size(83, 22);
            this.txtNumProyecto.TabIndex = 159;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 160;
            this.labelControl1.Text = "N° Proyecto:";
            // 
            // frmReprogramarVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 255);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReprogramarVisita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reprogramar Visita";
            this.Load += new System.EventHandler(this.frmReprogramarVisita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl lblAsesor;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraScheduler.DateNavigator denavAgenda;
        private System.Windows.Forms.TextBox txtDireccion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private System.Windows.Forms.TextBox textBox3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txtAgenda;
        private System.Windows.Forms.TextBox txtCelular;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnNuevoCliente;
        public DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        public DevExpress.XtraEditors.LookUpEdit cboProvincia;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraGrid.GridControl gcPendientes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPendientes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.TextBox txtNumProyecto;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}