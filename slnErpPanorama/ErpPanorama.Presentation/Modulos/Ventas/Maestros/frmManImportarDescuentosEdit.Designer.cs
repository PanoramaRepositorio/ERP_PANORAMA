namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManImportarDescuentosEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManImportarDescuentosEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkDescuentoMayorista = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.chkDescuentoOutlet = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkDescuentoOutlet);
            this.groupControl1.Controls.Add(this.chkDescuentoMayorista);
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(592, 108);
            this.groupControl1.TabIndex = 50;
            this.groupControl1.Text = "Datos";
            // 
            // chkDescuentoMayorista
            // 
            this.chkDescuentoMayorista.AutoSize = true;
            this.chkDescuentoMayorista.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescuentoMayorista.Location = new System.Drawing.Point(12, 60);
            this.chkDescuentoMayorista.Name = "chkDescuentoMayorista";
            this.chkDescuentoMayorista.Size = new System.Drawing.Size(206, 18);
            this.chkDescuentoMayorista.TabIndex = 8;
            this.chkDescuentoMayorista.Text = "Descuento Especial Mayorista";
            this.chkDescuentoMayorista.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(69, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(518, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Descripción:";
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(5, 119);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(421, 10);
            this.prgFactura.TabIndex = 47;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(431, 112);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 48;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(512, 112);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkDescuentoOutlet
            // 
            this.chkDescuentoOutlet.AutoSize = true;
            this.chkDescuentoOutlet.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescuentoOutlet.Location = new System.Drawing.Point(12, 84);
            this.chkDescuentoOutlet.Name = "chkDescuentoOutlet";
            this.chkDescuentoOutlet.Size = new System.Drawing.Size(134, 18);
            this.chkDescuentoOutlet.TabIndex = 9;
            this.chkDescuentoOutlet.Text = "Descuento Outlet";
            this.chkDescuentoOutlet.UseVisualStyleBackColor = true;
            // 
            // frmManImportarDescuentosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 146);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.prgFactura);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManImportarDescuentosEdit";
            this.Text = "Importación de Descuento en Excel";
            this.Load += new System.EventHandler(this.frmManImportarDescuentosEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private System.Windows.Forms.CheckBox chkDescuentoMayorista;
        private System.Windows.Forms.CheckBox chkDescuentoOutlet;
    }
}