
namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    partial class frmReservaNuevo
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
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.cboFin = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboInicio = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAsesor = new DevExpress.XtraEditors.LabelControl();
            this.denavAgenda = new DevExpress.XtraScheduler.DateNavigator();
            this.txtReserva = new System.Windows.Forms.TextBox();
            this.txtAgenda = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.simpleButton2);
            this.grdDatos.Controls.Add(this.simpleButton1);
            this.grdDatos.Controls.Add(this.groupControl1);
            this.grdDatos.Controls.Add(this.denavAgenda);
            this.grdDatos.Controls.Add(this.txtReserva);
            this.grdDatos.Controls.Add(this.txtAgenda);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(908, 411);
            this.grdDatos.TabIndex = 132;
            this.grdDatos.Text = "Datos de Visita";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(675, 376);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(106, 23);
            this.simpleButton2.TabIndex = 159;
            this.simpleButton2.Text = "Cerrar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(563, 376);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 23);
            this.simpleButton1.TabIndex = 158;
            this.simpleButton1.Text = "Reservar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblFecha);
            this.groupControl1.Controls.Add(this.cboFin);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboInicio);
            this.groupControl1.Controls.Add(this.lblAsesor);
            this.groupControl1.Location = new System.Drawing.Point(381, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(520, 48);
            this.groupControl1.TabIndex = 157;
            this.groupControl1.Text = "Seleccionar el horario de la reserva";
            // 
            // lblFecha
            // 
            this.lblFecha.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.lblFecha.Appearance.Options.UseFont = true;
            this.lblFecha.Appearance.Options.UseForeColor = true;
            this.lblFecha.Location = new System.Drawing.Point(407, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 21);
            this.lblFecha.TabIndex = 158;
            // 
            // cboFin
            // 
            this.cboFin.Location = new System.Drawing.Point(403, 24);
            this.cboFin.Name = "cboFin";
            this.cboFin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboFin.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cboFin.Properties.Appearance.Options.UseFont = true;
            this.cboFin.Properties.Appearance.Options.UseForeColor = true;
            this.cboFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFin.Properties.DropDownRows = 12;
            this.cboFin.Properties.NullText = "";
            this.cboFin.Size = new System.Drawing.Size(100, 20);
            this.cboFin.TabIndex = 117;
            this.cboFin.EditValueChanged += new System.EventHandler(this.cboFin_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(381, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(18, 13);
            this.labelControl3.TabIndex = 118;
            this.labelControl3.Text = "Fin:";
            // 
            // cboInicio
            // 
            this.cboInicio.Location = new System.Drawing.Point(45, 24);
            this.cboInicio.Name = "cboInicio";
            this.cboInicio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboInicio.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cboInicio.Properties.Appearance.Options.UseFont = true;
            this.cboInicio.Properties.Appearance.Options.UseForeColor = true;
            this.cboInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboInicio.Properties.DropDownRows = 12;
            this.cboInicio.Properties.NullText = "";
            this.cboInicio.Size = new System.Drawing.Size(100, 20);
            this.cboInicio.TabIndex = 8;
            // 
            // lblAsesor
            // 
            this.lblAsesor.Location = new System.Drawing.Point(14, 28);
            this.lblAsesor.Name = "lblAsesor";
            this.lblAsesor.Size = new System.Drawing.Size(29, 13);
            this.lblAsesor.TabIndex = 116;
            this.lblAsesor.Text = "Inicio:";
            // 
            // denavAgenda
            // 
            this.denavAgenda.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.denavAgenda.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.denavAgenda.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.denavAgenda.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denavAgenda.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.denavAgenda.DateTime = new System.DateTime(2023, 5, 26, 0, 0, 0, 0);
            this.denavAgenda.EditValue = new System.DateTime(2023, 5, 26, 0, 0, 0, 0);
            this.denavAgenda.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.denavAgenda.Location = new System.Drawing.Point(5, 26);
            this.denavAgenda.Name = "denavAgenda";
            this.denavAgenda.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
            this.denavAgenda.ShowFooter = false;
            this.denavAgenda.ShowTodayButton = false;
            this.denavAgenda.ShowWeekNumbers = false;
            this.denavAgenda.Size = new System.Drawing.Size(371, 373);
            this.denavAgenda.TabIndex = 156;
            this.denavAgenda.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)(((((DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.QuarterView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.denavAgenda.EditValueChanged += new System.EventHandler(this.denavAgenda_EditValueChanged);
            this.denavAgenda.Click += new System.EventHandler(this.denavAgenda_Click);
            this.denavAgenda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.denavAgenda_KeyUp);
            // 
            // txtReserva
            // 
            this.txtReserva.Location = new System.Drawing.Point(429, 99);
            this.txtReserva.MaxLength = 120;
            this.txtReserva.Name = "txtReserva";
            this.txtReserva.ReadOnly = true;
            this.txtReserva.Size = new System.Drawing.Size(359, 21);
            this.txtReserva.TabIndex = 9;
            // 
            // txtAgenda
            // 
            this.txtAgenda.Location = new System.Drawing.Point(429, 77);
            this.txtAgenda.MaxLength = 200;
            this.txtAgenda.Name = "txtAgenda";
            this.txtAgenda.Size = new System.Drawing.Size(472, 21);
            this.txtAgenda.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(386, 81);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 131;
            this.labelControl2.Text = "Agenda:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(383, 103);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(44, 13);
            this.labelControl20.TabIndex = 32;
            this.labelControl20.Text = "Reserva:";
            // 
            // frmReservaNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 411);
            this.Controls.Add(this.grdDatos);
            this.Name = "frmReservaNuevo";
            this.Text = "frmReservaNuevo";
            this.Load += new System.EventHandler(this.frmReservaNuevo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denavAgenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.TextBox txtReserva;
        private System.Windows.Forms.TextBox txtAgenda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboInicio;
        private DevExpress.XtraEditors.LabelControl lblAsesor;
        private DevExpress.XtraEditors.LabelControl labelControl20;
 
        private DevExpress.XtraScheduler.DateNavigator denavAgenda;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.LookUpEdit cboFin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl lblFecha;
    }
}