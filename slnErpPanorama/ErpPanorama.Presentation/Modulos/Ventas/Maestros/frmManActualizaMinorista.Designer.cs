namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManActualizaMinorista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManActualizaMinorista));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboClasificacion = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.cboClasificacion);
            this.grdDatos.Controls.Add(this.txtTipoCliente);
            this.grdDatos.Controls.Add(this.txtDescCliente);
            this.grdDatos.Controls.Add(this.btnBuscar);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(519, 132);
            this.grdDatos.TabIndex = 7;
            this.grdDatos.Text = "Datos";
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(83, 69);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(428, 20);
            this.txtTipoCliente.TabIndex = 74;
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(83, 47);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Size = new System.Drawing.Size(428, 20);
            this.txtDescCliente.TabIndex = 73;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(175, 25);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(83, 25);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(91, 20);
            this.txtNumeroDocumento.TabIndex = 14;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 28);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Cliente:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(436, 98);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(355, 98);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 94);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 13);
            this.labelControl7.TabIndex = 75;
            this.labelControl7.Text = "Clasificación: ";
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.Location = new System.Drawing.Point(83, 91);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClasificacion.Properties.NullText = "";
            this.cboClasificacion.Size = new System.Drawing.Size(102, 20);
            this.cboClasificacion.TabIndex = 76;
            this.cboClasificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboClasificacion_KeyPress);
            // 
            // frmManActualizaMinorista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 127);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManActualizaMinorista";
            this.Text = "Actualizar Cliente Minorista";
            this.Load += new System.EventHandler(this.frmManActualizaMinorista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.LookUpEdit cboClasificacion;
    }
}