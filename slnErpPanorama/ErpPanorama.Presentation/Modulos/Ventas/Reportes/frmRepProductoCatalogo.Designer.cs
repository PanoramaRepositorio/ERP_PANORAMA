namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
	partial class frmRepProductoCatalogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepProductoCatalogo));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnInforme = new DevExpress.XtraEditors.SimpleButton();
            this.btnxPedido = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboVendedor);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(509, 66);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Datos";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(67, 29);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(315, 20);
            this.cboVendedor.TabIndex = 13;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(11, 32);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(50, 13);
            this.labelControl12.TabIndex = 12;
            this.labelControl12.Text = "Vendedor:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(358, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnInforme.ImageIndex = 1;
            this.btnInforme.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(277, 84);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Size = new System.Drawing.Size(75, 23);
            this.btnInforme.TabIndex = 7;
            this.btnInforme.Text = "Informe";
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnxPedido
            // 
            this.btnxPedido.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnxPedido.ImageIndex = 1;
            this.btnxPedido.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnxPedido.Location = new System.Drawing.Point(277, 113);
            this.btnxPedido.Name = "btnxPedido";
            this.btnxPedido.Size = new System.Drawing.Size(97, 23);
            this.btnxPedido.TabIndex = 7;
            this.btnxPedido.Text = "Por Pedido";
            this.btnxPedido.Click += new System.EventHandler(this.btnxPedido_Click);
            // 
            // frmRepProductoCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 175);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnxPedido);
            this.Controls.Add(this.btnInforme);
            this.Name = "frmRepProductoCatalogo";
            this.Text = "Reporte Catalogo Productos";
            this.Load += new System.EventHandler(this.frmRepProductoCatalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnInforme;
        private DevExpress.XtraEditors.SimpleButton btnxPedido;
	}
}