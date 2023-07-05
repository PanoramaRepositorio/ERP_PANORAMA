namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegTrackingPedido
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboSituacionAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblMinuto = new System.Windows.Forms.Label();
            this.lblSegundo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPersonaPicking = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPersonalPicking = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacionAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonaPicking.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Fecha y Hora:";
            // 
            // cboSituacionAlmacen
            // 
            this.cboSituacionAlmacen.Location = new System.Drawing.Point(108, 44);
            this.cboSituacionAlmacen.Name = "cboSituacionAlmacen";
            this.cboSituacionAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacionAlmacen.Properties.NullText = "";
            this.cboSituacionAlmacen.Size = new System.Drawing.Size(178, 20);
            this.cboSituacionAlmacen.TabIndex = 11;
            this.cboSituacionAlmacen.EditValueChanged += new System.EventHandler(this.cboSituacionAlmacen_EditValueChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(15, 47);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(90, 13);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Situación Almacén:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 69);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 62;
            this.labelControl4.Text = "N° Pedido:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(108, 66);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 7;
            this.txtNumero.Size = new System.Drawing.Size(111, 20);
            this.txtNumero.TabIndex = 61;
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblHora.Location = new System.Drawing.Point(105, 19);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(0, 14);
            this.lblHora.TabIndex = 63;
            // 
            // lblMinuto
            // 
            this.lblMinuto.AutoSize = true;
            this.lblMinuto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinuto.Location = new System.Drawing.Point(358, 96);
            this.lblMinuto.Name = "lblMinuto";
            this.lblMinuto.Size = new System.Drawing.Size(43, 14);
            this.lblMinuto.TabIndex = 64;
            this.lblMinuto.Text = "label2";
            this.lblMinuto.Visible = false;
            // 
            // lblSegundo
            // 
            this.lblSegundo.AutoSize = true;
            this.lblSegundo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblSegundo.Location = new System.Drawing.Point(407, 96);
            this.lblSegundo.Name = "lblSegundo";
            this.lblSegundo.Size = new System.Drawing.Size(43, 14);
            this.lblSegundo.TabIndex = 65;
            this.lblSegundo.Text = "label2";
            this.lblSegundo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(397, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 14);
            this.label2.TabIndex = 66;
            this.label2.Text = ":";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(347, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 14);
            this.label3.TabIndex = 67;
            this.label3.Text = ":";
            this.label3.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(212, 97);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 14);
            this.lblFecha.TabIndex = 68;
            this.lblFecha.Text = "label2";
            this.lblFecha.Visible = false;
            // 
            // lblEquipo
            // 
            this.lblEquipo.AutoSize = true;
            this.lblEquipo.Location = new System.Drawing.Point(105, 98);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(19, 13);
            this.lblEquipo.TabIndex = 9;
            this.lblEquipo.Text = "eq";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 98);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 62;
            this.labelControl1.Text = "Equipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "El primer ingreso del N° de pedido es para cambiar la Situación a: CHEQUEO.\r\nPost" +
    "eriormente demorará 60 seg para que el nuevo ingreso sea considerado como: \r\nPT(" +
    "Chequeo Terminado)";
            // 
            // cboPersonaPicking
            // 
            this.cboPersonaPicking.Location = new System.Drawing.Point(433, 44);
            this.cboPersonaPicking.Name = "cboPersonaPicking";
            this.cboPersonaPicking.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboPersonaPicking.Properties.Appearance.Options.UseForeColor = true;
            this.cboPersonaPicking.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPersonaPicking.Properties.NullText = "";
            this.cboPersonaPicking.Size = new System.Drawing.Size(236, 20);
            this.cboPersonaPicking.TabIndex = 70;
            // 
            // lblPersonalPicking
            // 
            this.lblPersonalPicking.Location = new System.Drawing.Point(292, 47);
            this.lblPersonalPicking.Name = "lblPersonalPicking";
            this.lblPersonalPicking.Size = new System.Drawing.Size(80, 13);
            this.lblPersonalPicking.TabIndex = 69;
            this.lblPersonalPicking.Text = "Personal Picking:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(378, 44);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(50, 20);
            this.txtCodigo.TabIndex = 71;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // frmRegTrackingPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 189);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cboPersonaPicking);
            this.Controls.Add(this.lblPersonalPicking);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSegundo);
            this.Controls.Add(this.lblMinuto);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.cboSituacionAlmacen);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegTrackingPedido";
            this.Text = "Tracking Pedido";
            this.Load += new System.EventHandler(this.frmRegTrackingPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacionAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersonaPicking.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.LookUpEdit cboSituacionAlmacen;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblMinuto;
        private System.Windows.Forms.Label lblSegundo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEquipo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label4;
        public DevExpress.XtraEditors.LookUpEdit cboPersonaPicking;
        private DevExpress.XtraEditors.LabelControl lblPersonalPicking;
        private DevExpress.XtraEditors.TextEdit txtCodigo;

    }
}