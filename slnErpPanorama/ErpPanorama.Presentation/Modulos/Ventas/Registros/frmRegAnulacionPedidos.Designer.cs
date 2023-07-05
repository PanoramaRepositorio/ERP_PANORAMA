namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegAnulacionPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegAnulacionPedidos));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtMotivo = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtPeriodo);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtNumero);
            this.grdDatos.Controls.Add(this.txtMotivo);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(680, 67);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(217, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Motivo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(57, 32);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(54, 20);
            this.txtPeriodo.TabIndex = 1;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(116, 32);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 7;
            this.txtNumero.Size = new System.Drawing.Size(95, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(592, 73);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(511, 73);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.EditValue = "";
            this.txtMotivo.Location = new System.Drawing.Point(259, 32);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMotivo.Properties.Items.AddRange(new object[] {
            "POR ERROR DEL VENDEDOR AL DIGITAR CODIGO",
            "EL CLIENTE DESISTE DE LA COMPRA",
            "CAMBIO DE MODELO DE PRODUCTO",
            "NO TIENE EFECTIVO PARA PAGAR",
            "POR REDUCCION DE ITEMS (FACTURADO)"});
            this.txtMotivo.Properties.MaxLength = 50;
            this.txtMotivo.Size = new System.Drawing.Size(408, 20);
            this.txtMotivo.TabIndex = 4;
            this.txtMotivo.ToolTip = "Motivo de Anulación - Breve";
            // 
            // frmRegAnulacionPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 104);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegAnulacionPedidos";
            this.Text = "Anulación de Pedido";
            this.Load += new System.EventHandler(this.frmRegAnulacionPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.ComboBoxEdit txtMotivo;
    }
}