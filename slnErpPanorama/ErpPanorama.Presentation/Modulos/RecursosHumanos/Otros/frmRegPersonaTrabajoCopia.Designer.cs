namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    partial class frmRegPersonaTrabajoCopia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPersonaTrabajoCopia));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.deFechaFin);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.txtObservacion);
            this.groupControl3.Controls.Add(this.lblAño);
            this.groupControl3.Controls.Add(this.deFechaIni);
            this.groupControl3.Controls.Add(this.deFecha);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(490, 94);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Datos";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 43;
            this.labelControl1.Text = "Fecha:";
            // 
            // deFechaFin
            // 
            this.deFechaFin.EditValue = null;
            this.deFechaFin.Location = new System.Drawing.Point(363, 23);
            this.deFechaFin.Name = "deFechaFin";
            this.deFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaFin.Properties.DisplayFormat.FormatString = "t";
            this.deFechaFin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deFechaFin.Properties.Mask.EditMask = "t";
            this.deFechaFin.Size = new System.Drawing.Size(100, 20);
            this.deFechaFin.TabIndex = 42;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(336, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(21, 13);
            this.labelControl2.TabIndex = 41;
            this.labelControl2.Text = "Fin: ";
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(194, 26);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(32, 13);
            this.lblAño.TabIndex = 39;
            this.lblAño.Text = "Inicio: ";
            // 
            // deFechaIni
            // 
            this.deFechaIni.EditValue = null;
            this.deFechaIni.Location = new System.Drawing.Point(230, 23);
            this.deFechaIni.Name = "deFechaIni";
            this.deFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaIni.Properties.DisplayFormat.FormatString = "t";
            this.deFechaIni.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFechaIni.Properties.Mask.EditMask = "t";
            this.deFechaIni.Size = new System.Drawing.Size(100, 20);
            this.deFechaIni.TabIndex = 40;
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(88, 23);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 38;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(20, 50);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(88, 49);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Properties.MaxLength = 50;
            this.txtObservacion.Size = new System.Drawing.Size(375, 33);
            this.txtObservacion.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(388, 109);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(307, 109);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 39;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegPersonaTrabajoCopia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 143);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPersonaTrabajoCopia";
            this.Text = "Copiar Lista de Domingos";
            this.Load += new System.EventHandler(this.frmRegPersonaTrabajoCopia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaFin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblAño;
        private DevExpress.XtraEditors.DateEdit deFechaIni;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
    }
}