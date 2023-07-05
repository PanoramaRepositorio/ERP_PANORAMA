namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    partial class frmRegCambiarSituacionPedidoAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegCambiarSituacionPedidoAlmacen));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboSituacionAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacionAlmacen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(399, 67);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(318, 67);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.cboSituacionAlmacen);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(479, 61);
            this.grdDatos.TabIndex = 9;
            this.grdDatos.Text = "Datos";
            // 
            // cboSituacionAlmacen
            // 
            this.cboSituacionAlmacen.Location = new System.Drawing.Point(105, 27);
            this.cboSituacionAlmacen.Name = "cboSituacionAlmacen";
            this.cboSituacionAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacionAlmacen.Properties.NullText = "";
            this.cboSituacionAlmacen.Size = new System.Drawing.Size(172, 20);
            this.cboSituacionAlmacen.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(15, 30);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(90, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Situación Almacén:";
            // 
            // frmRegCambiarSituacionPedidoAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 96);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegCambiarSituacionPedidoAlmacen";
            this.Text = "Cambiar Situación Pedido";
            this.Load += new System.EventHandler(this.frmRegCambiarSituacionPedidoAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacionAlmacen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.LookUpEdit cboSituacionAlmacen;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
    }
}