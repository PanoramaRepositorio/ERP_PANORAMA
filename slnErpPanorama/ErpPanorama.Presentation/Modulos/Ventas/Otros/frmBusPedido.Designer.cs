namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusPedido
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
            this.txtNumeroPedido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Location = new System.Drawing.Point(176, 12);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Properties.MaxLength = 7;
            this.txtNumeroPedido.Size = new System.Drawing.Size(95, 20);
            this.txtNumeroPedido.TabIndex = 3;
            this.txtNumeroPedido.ToolTip = "Ingresar los 7 digitos del N° Pedido";
            this.txtNumeroPedido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroPedido_KeyUp);
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(119, 15);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(51, 13);
            this.labelControl17.TabIndex = 2;
            this.labelControl17.Text = "N° Pedido:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Periodo:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = "2014";
            this.txtPeriodo.Location = new System.Drawing.Point(63, 12);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.MaxLength = 7;
            this.txtPeriodo.Size = new System.Drawing.Size(49, 20);
            this.txtPeriodo.TabIndex = 1;
            this.txtPeriodo.ToolTip = "Ingresar los 7 digitos del N° Pedido";
            this.txtPeriodo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroPedido_KeyUp);
            // 
            // frmBusPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 49);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.labelControl17);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusPedido";
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.frmBusPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNumeroPedido;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPeriodo;

    }
}