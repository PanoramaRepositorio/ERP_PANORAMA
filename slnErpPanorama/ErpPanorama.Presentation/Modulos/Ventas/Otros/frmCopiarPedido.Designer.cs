namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmCopiarPedido
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCopiaCabeceraDetalle = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopiaCabecera = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopiaDetalle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnCopiaCabeceraDetalle);
            this.groupControl1.Controls.Add(this.btnCopiaCabecera);
            this.groupControl1.Controls.Add(this.btnCopiaDetalle);
            this.groupControl1.Location = new System.Drawing.Point(2, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(439, 84);
            this.groupControl1.TabIndex = 0;
            // 
            // btnCopiaCabeceraDetalle
            // 
            this.btnCopiaCabeceraDetalle.Location = new System.Drawing.Point(148, 34);
            this.btnCopiaCabeceraDetalle.Name = "btnCopiaCabeceraDetalle";
            this.btnCopiaCabeceraDetalle.Size = new System.Drawing.Size(128, 35);
            this.btnCopiaCabeceraDetalle.TabIndex = 0;
            this.btnCopiaCabeceraDetalle.Text = "Cabecera y Detalle";
            this.btnCopiaCabeceraDetalle.Click += new System.EventHandler(this.btnCopiaCabeceraDetalle_Click);
            // 
            // btnCopiaCabecera
            // 
            this.btnCopiaCabecera.Location = new System.Drawing.Point(282, 34);
            this.btnCopiaCabecera.Name = "btnCopiaCabecera";
            this.btnCopiaCabecera.Size = new System.Drawing.Size(95, 35);
            this.btnCopiaCabecera.TabIndex = 0;
            this.btnCopiaCabecera.Text = "Sólo Cabecera";
            this.btnCopiaCabecera.Click += new System.EventHandler(this.btnCopiaCabecera_Click);
            // 
            // btnCopiaDetalle
            // 
            this.btnCopiaDetalle.Location = new System.Drawing.Point(47, 34);
            this.btnCopiaDetalle.Name = "btnCopiaDetalle";
            this.btnCopiaDetalle.Size = new System.Drawing.Size(95, 35);
            this.btnCopiaDetalle.TabIndex = 0;
            this.btnCopiaDetalle.Text = "Sólo Detalle";
            this.btnCopiaDetalle.Click += new System.EventHandler(this.btnCopiaDetalle_Click);
            // 
            // frmCopiarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 106);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopiarPedido";
            this.Text = "Opciones de Copia";
            this.Load += new System.EventHandler(this.frmCopiarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCopiaCabeceraDetalle;
        private DevExpress.XtraEditors.SimpleButton btnCopiaDetalle;
        private DevExpress.XtraEditors.SimpleButton btnCopiaCabecera;
    }
}