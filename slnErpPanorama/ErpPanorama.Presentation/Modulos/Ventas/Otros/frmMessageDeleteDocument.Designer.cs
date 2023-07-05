namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmMessageDeleteDocument
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
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboMotivoAnulacion = new DevExpress.XtraEditors.LookUpEdit();
            this.imgIcono = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivoAnulacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(95, 64);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(184, 64);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(64, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(168, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Seleccione un motivo de Anulación:";
            // 
            // cboMotivoAnulacion
            // 
            this.cboMotivoAnulacion.Location = new System.Drawing.Point(64, 31);
            this.cboMotivoAnulacion.Name = "cboMotivoAnulacion";
            this.cboMotivoAnulacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivoAnulacion.Properties.NullText = "";
            this.cboMotivoAnulacion.Size = new System.Drawing.Size(270, 20);
            this.cboMotivoAnulacion.TabIndex = 1;
            // 
            // imgIcono
            // 
            this.imgIcono.Image = global::ErpPanorama.Presentation.Properties.Resources.Help_32x32;
            this.imgIcono.Location = new System.Drawing.Point(12, 22);
            this.imgIcono.Name = "imgIcono";
            this.imgIcono.Size = new System.Drawing.Size(33, 35);
            this.imgIcono.TabIndex = 1;
            this.imgIcono.TabStop = false;
            // 
            // frmMessageDeleteDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 102);
            this.Controls.Add(this.cboMotivoAnulacion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.imgIcono);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageDeleteDocument";
            this.Text = "Eliminar Documento";
            this.Load += new System.EventHandler(this.frmMessageDeleteDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivoAnulacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private System.Windows.Forms.PictureBox imgIcono;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboMotivoAnulacion;
    }
}