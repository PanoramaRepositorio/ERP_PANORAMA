namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    partial class frmAsignarHorario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignarHorario));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHoraSalida = new DevExpress.XtraEditors.DateEdit();
            this.deHoraIngreso = new DevExpress.XtraEditors.DateEdit();
            this.deHoraSalRef = new DevExpress.XtraEditors.DateEdit();
            this.deHoraIngRef = new DevExpress.XtraEditors.DateEdit();
            this.btnAplicarHoras = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalida.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngreso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalRef.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalRef.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngRef.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngRef.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(380, 66);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(51, 31);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deFecha.Properties.ShowPopupShadow = false;
            this.deFecha.Properties.ShowToday = false;
            this.deFecha.Size = new System.Drawing.Size(80, 20);
            this.deFecha.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Hasta:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(380, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(28, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Salida";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(299, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Ing. Refrigerio";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(218, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Sal. Refrigerio";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(137, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ingreso";
            // 
            // deHoraSalida
            // 
            this.deHoraSalida.EditValue = null;
            this.deHoraSalida.Location = new System.Drawing.Point(380, 31);
            this.deHoraSalida.Name = "deHoraSalida";
            this.deHoraSalida.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.deHoraSalida.Properties.Appearance.Options.UseFont = true;
            this.deHoraSalida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Separator)});
            this.deHoraSalida.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHoraSalida.Properties.DisplayFormat.FormatString = "t";
            this.deHoraSalida.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deHoraSalida.Properties.Mask.EditMask = "t";
            this.deHoraSalida.Size = new System.Drawing.Size(75, 20);
            this.deHoraSalida.TabIndex = 9;
            // 
            // deHoraIngreso
            // 
            this.deHoraIngreso.EditValue = null;
            this.deHoraIngreso.Location = new System.Drawing.Point(137, 31);
            this.deHoraIngreso.Name = "deHoraIngreso";
            this.deHoraIngreso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.deHoraIngreso.Properties.Appearance.Options.UseFont = true;
            this.deHoraIngreso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Separator)});
            this.deHoraIngreso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHoraIngreso.Properties.DisplayFormat.FormatString = "t";
            this.deHoraIngreso.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deHoraIngreso.Properties.Mask.EditMask = "t";
            this.deHoraIngreso.Size = new System.Drawing.Size(75, 20);
            this.deHoraIngreso.TabIndex = 3;
            // 
            // deHoraSalRef
            // 
            this.deHoraSalRef.EditValue = null;
            this.deHoraSalRef.Location = new System.Drawing.Point(218, 31);
            this.deHoraSalRef.Name = "deHoraSalRef";
            this.deHoraSalRef.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.deHoraSalRef.Properties.Appearance.Options.UseFont = true;
            this.deHoraSalRef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Separator)});
            this.deHoraSalRef.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHoraSalRef.Properties.DisplayFormat.FormatString = "t";
            this.deHoraSalRef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deHoraSalRef.Properties.Mask.EditMask = "t";
            this.deHoraSalRef.Size = new System.Drawing.Size(75, 20);
            this.deHoraSalRef.TabIndex = 5;
            // 
            // deHoraIngRef
            // 
            this.deHoraIngRef.EditValue = null;
            this.deHoraIngRef.Location = new System.Drawing.Point(299, 31);
            this.deHoraIngRef.Name = "deHoraIngRef";
            this.deHoraIngRef.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.deHoraIngRef.Properties.Appearance.Options.UseFont = true;
            this.deHoraIngRef.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Separator)});
            this.deHoraIngRef.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHoraIngRef.Properties.DisplayFormat.FormatString = "t";
            this.deHoraIngRef.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deHoraIngRef.Properties.Mask.EditMask = "t";
            this.deHoraIngRef.Size = new System.Drawing.Size(75, 20);
            this.deHoraIngRef.TabIndex = 7;
            // 
            // btnAplicarHoras
            // 
            this.btnAplicarHoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicarHoras.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAplicarHoras.Location = new System.Drawing.Point(299, 66);
            this.btnAplicarHoras.Name = "btnAplicarHoras";
            this.btnAplicarHoras.Size = new System.Drawing.Size(75, 23);
            this.btnAplicarHoras.TabIndex = 10;
            this.btnAplicarHoras.Text = "Aceptar";
            this.btnAplicarHoras.Click += new System.EventHandler(this.btnAplicarHoras_Click);
            // 
            // frmAsignarHorario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 101);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.deFecha);
            this.Controls.Add(this.deHoraIngreso);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnAplicarHoras);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.deHoraIngRef);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.deHoraSalRef);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.deHoraSalida);
            this.Controls.Add(this.labelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarHorario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Horario";
            this.Load += new System.EventHandler(this.frmAsignarHorario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalida.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngreso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalRef.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraSalRef.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngRef.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHoraIngRef.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHoraSalida;
        private DevExpress.XtraEditors.DateEdit deHoraIngreso;
        private DevExpress.XtraEditors.DateEdit deHoraSalRef;
        private DevExpress.XtraEditors.DateEdit deHoraIngRef;
        private DevExpress.XtraEditors.SimpleButton btnAplicarHoras;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
    }
}