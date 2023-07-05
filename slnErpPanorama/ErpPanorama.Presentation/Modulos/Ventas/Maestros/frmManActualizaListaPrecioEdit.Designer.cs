namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManActualizaListaPrecioEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManActualizaListaPrecioEdit));
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkTodo = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.chkMinorista = new DevExpress.XtraEditors.CheckEdit();
            this.chkMayorista = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMinorista.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMayorista.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(146, 106);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(280, 10);
            this.prgFactura.TabIndex = 43;
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(432, 101);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 44;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(512, 101);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(592, 62);
            this.groupControl1.TabIndex = 46;
            this.groupControl1.Text = "Datos";
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
            // chkTodo
            // 
            this.chkTodo.EditValue = true;
            this.chkTodo.Location = new System.Drawing.Point(12, 101);
            this.chkTodo.Name = "chkTodo";
            this.chkTodo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkTodo.Properties.Appearance.Options.UseFont = true;
            this.chkTodo.Properties.Caption = "Todas las Tiendas";
            this.chkTodo.Size = new System.Drawing.Size(128, 20);
            this.chkTodo.TabIndex = 47;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(5, 71);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 50;
            this.labelControl5.Text = "Tipo Cliente:";
            // 
            // chkMinorista
            // 
            this.chkMinorista.Location = new System.Drawing.Point(176, 68);
            this.chkMinorista.Name = "chkMinorista";
            this.chkMinorista.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkMinorista.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.chkMinorista.Properties.Appearance.Options.UseFont = true;
            this.chkMinorista.Properties.Appearance.Options.UseForeColor = true;
            this.chkMinorista.Properties.Caption = "Final CD";
            this.chkMinorista.Size = new System.Drawing.Size(92, 20);
            this.chkMinorista.TabIndex = 49;
            // 
            // chkMayorista
            // 
            this.chkMayorista.Location = new System.Drawing.Point(78, 68);
            this.chkMayorista.Name = "chkMayorista";
            this.chkMayorista.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkMayorista.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkMayorista.Properties.Appearance.Options.UseFont = true;
            this.chkMayorista.Properties.Appearance.Options.UseForeColor = true;
            this.chkMayorista.Properties.Caption = "Mayorista";
            this.chkMayorista.Size = new System.Drawing.Size(92, 20);
            this.chkMayorista.TabIndex = 48;
            // 
            // frmManActualizaListaPrecioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 133);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.chkMinorista);
            this.Controls.Add(this.chkMayorista);
            this.Controls.Add(this.chkTodo);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.prgFactura);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManActualizaListaPrecioEdit";
            this.Text = "Actualiza Lista Precio";
            this.Load += new System.EventHandler(this.frmManActualizaListaPrecioEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMinorista.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMayorista.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chkTodo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckEdit chkMinorista;
        private DevExpress.XtraEditors.CheckEdit chkMayorista;
    }
}