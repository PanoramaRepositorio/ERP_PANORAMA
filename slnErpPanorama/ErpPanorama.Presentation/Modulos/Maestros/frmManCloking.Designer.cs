namespace ErpPanorama.Presentation.Modulos.Maestros
{
    partial class frmManCloking
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.optIngreso = new System.Windows.Forms.RadioButton();
            this.optSalida = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gcMarcacion = new DevExpress.XtraGrid.GridControl();
            this.gvMarcacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.txtHoraExtra = new System.Windows.Forms.TextBox();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaIngreso = new DevExpress.XtraEditors.DateEdit();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblHora.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblHora.Location = new System.Drawing.Point(84, 9);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(231, 34);
            this.lblHora.TabIndex = 65;
            this.lblHora.Text = "05:30:30 p.m.";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(4, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 24);
            this.labelControl4.TabIndex = 67;
            this.labelControl4.Text = "Dni:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(100, 106);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtDni.Properties.Appearance.Options.UseFont = true;
            this.txtDni.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDni.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDni.Properties.MaxLength = 9;
            this.txtDni.Size = new System.Drawing.Size(288, 40);
            this.txtDni.TabIndex = 66;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            this.txtDni.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyUp);
            // 
            // optIngreso
            // 
            this.optIngreso.AutoSize = true;
            this.optIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.optIngreso.Checked = true;
            this.optIngreso.Font = new System.Drawing.Font("Tahoma", 15F);
            this.optIngreso.Location = new System.Drawing.Point(-98, 411);
            this.optIngreso.Name = "optIngreso";
            this.optIngreso.Size = new System.Drawing.Size(95, 28);
            this.optIngreso.TabIndex = 69;
            this.optIngreso.TabStop = true;
            this.optIngreso.Text = "Ingreso";
            this.optIngreso.UseVisualStyleBackColor = false;
            // 
            // optSalida
            // 
            this.optSalida.AutoSize = true;
            this.optSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.optSalida.Font = new System.Drawing.Font("Tahoma", 15F);
            this.optSalida.Location = new System.Drawing.Point(-89, 398);
            this.optSalida.Name = "optSalida";
            this.optSalida.Size = new System.Drawing.Size(82, 28);
            this.optSalida.TabIndex = 70;
            this.optSalida.Text = "Salida";
            this.optSalida.UseVisualStyleBackColor = false;
            this.optSalida.CheckedChanged += new System.EventHandler(this.optSalida_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(92, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 71;
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFecha.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblFecha.Location = new System.Drawing.Point(42, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(292, 22);
            this.lblFecha.TabIndex = 65;
            this.lblFecha.Text = "Jueves, 09 de Octubre de 2014";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gcMarcacion
            // 
            this.gcMarcacion.Location = new System.Drawing.Point(6, 11);
            this.gcMarcacion.MainView = this.gvMarcacion;
            this.gcMarcacion.Name = "gcMarcacion";
            this.gcMarcacion.Size = new System.Drawing.Size(540, 392);
            this.gcMarcacion.TabIndex = 72;
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
            this.gvMarcacion.OptionsView.AllowCellMerge = true;
            this.gvMarcacion.OptionsView.RowAutoHeight = true;
            this.gvMarcacion.OptionsView.ShowGroupPanel = false;
            this.gvMarcacion.RowHeight = 40;
            this.gvMarcacion.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvMarcacion_RowStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "DNI";
            this.gridColumn1.FieldName = "Dni";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "NOMBRES";
            this.gridColumn2.FieldName = "ApeNom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 259;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "APELLIDOS";
            this.gridColumn3.FieldName = "Apellidos";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.Caption = "HORA";
            this.gridColumn4.DisplayFormat.FormatString = "t";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "Fecha";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 136;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.Caption = "ESTADO";
            this.gridColumn5.FieldName = "Marcacion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 209;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // txtHoraExtra
            // 
            this.txtHoraExtra.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtHoraExtra.Location = new System.Drawing.Point(229, 596);
            this.txtHoraExtra.MaxLength = 8;
            this.txtHoraExtra.Multiline = true;
            this.txtHoraExtra.Name = "txtHoraExtra";
            this.txtHoraExtra.Size = new System.Drawing.Size(190, 30);
            this.txtHoraExtra.TabIndex = 73;
            this.txtHoraExtra.Visible = false;
            this.txtHoraExtra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoraExtra_KeyPress);
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(838, 617);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(514, 150);
            this.gridControl2.TabIndex = 74;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Visible = false;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn12,
            this.gridColumn11});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Dni";
            this.gridColumn6.FieldName = "dni";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Nombre y Apellidos";
            this.gridColumn7.FieldName = "ApeNom";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Hora Inicio";
            this.gridColumn8.FieldName = "FechaDesde";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 2;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Marcacion Ingreso";
            this.gridColumn9.FieldName = "Ingreso";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Hora Salida";
            this.gridColumn10.FieldName = "FechaHasta";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Marcacion Salida";
            this.gridColumn12.FieldName = "Salida";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 5;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Observacion";
            this.gridColumn11.FieldName = "Observacion";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(90, 573);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(26, 23);
            this.textBox2.TabIndex = 75;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(122, 558);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(355, 46);
            this.labelControl1.TabIndex = 76;
            this.labelControl1.Text = "Pulse el Boton Dorado Para Activar Horas Extras";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tempus Sans ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(229, 535);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(159, 29);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "Area Sistemas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.deFechaIngreso);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Controls.Add(this.txtDni);
            this.panel1.Location = new System.Drawing.Point(30, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 195);
            this.panel1.TabIndex = 78;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(4, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(115, 24);
            this.labelControl3.TabIndex = 70;
            this.labelControl3.Text = "Fecha Ing.:";
            // 
            // deFechaIngreso
            // 
            this.deFechaIngreso.EditValue = null;
            this.deFechaIngreso.Location = new System.Drawing.Point(117, 64);
            this.deFechaIngreso.Name = "deFechaIngreso";
            this.deFechaIngreso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.deFechaIngreso.Properties.Appearance.Options.UseFont = true;
            this.deFechaIngreso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaIngreso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaIngreso.Properties.DisplayFormat.FormatString = "g";
            this.deFechaIngreso.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFechaIngreso.Properties.EditFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.deFechaIngreso.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFechaIngreso.Properties.Mask.EditMask = "g";
            this.deFechaIngreso.Size = new System.Drawing.Size(271, 30);
            this.deFechaIngreso.TabIndex = 69;
            // 
            // timer4
            // 
            this.timer4.Interval = 500;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textBox3.ForeColor = System.Drawing.Color.Lime;
            this.textBox3.Location = new System.Drawing.Point(30, 51);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(197, 213);
            this.textBox3.TabIndex = 79;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.gcMarcacion);
            this.groupControl1.Location = new System.Drawing.Point(453, -2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(558, 421);
            this.groupControl1.TabIndex = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ErpPanorama.Presentation.Properties.Resources.Clocking;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(446, 469);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(885, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 34);
            this.button1.TabIndex = 82;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmManCloking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 472);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtHoraExtra);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.optSalida);
            this.Controls.Add(this.optIngreso);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManCloking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmManCloking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblHora;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDni;
        private System.Windows.Forms.RadioButton optIngreso;
        private System.Windows.Forms.RadioButton optSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
        private DevExpress.XtraGrid.GridControl gcMarcacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarcacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox txtHoraExtra;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.TextBox textBox2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        public System.Windows.Forms.Timer timer3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.TextBox textBox3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deFechaIngreso;
        private System.Windows.Forms.Button button1;
    }
}