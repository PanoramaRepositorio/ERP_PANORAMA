namespace ErpPanorama.Presentation.Modulos.Seguridad
{
    partial class frmManPerfilEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPerfilEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEstado = new DevExpress.XtraEditors.CheckEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.lblEstado = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.trwMenu = new System.Windows.Forms.TreeView();
            this.grpPermisos = new System.Windows.Forms.GroupBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.chkAllowPrint = new System.Windows.Forms.CheckBox();
            this.chkAllowWrite = new System.Windows.Forms.CheckBox();
            this.chkAllowUpdate = new System.Windows.Forms.CheckBox();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.chkAllowRead = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.grpPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkEstado);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 74);
            this.panel1.TabIndex = 8;
            // 
            // chkEstado
            // 
            this.chkEstado.Location = new System.Drawing.Point(78, 40);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Properties.Caption = "Activo";
            this.chkEstado.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkEstado.Size = new System.Drawing.Size(75, 22);
            this.chkEstado.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(16, 18);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(58, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(16, 43);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(37, 13);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(80, 15);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(468, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // trwMenu
            // 
            this.trwMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trwMenu.CheckBoxes = true;
            this.trwMenu.Location = new System.Drawing.Point(2, 80);
            this.trwMenu.Name = "trwMenu";
            this.trwMenu.Size = new System.Drawing.Size(375, 375);
            this.trwMenu.TabIndex = 9;
            this.trwMenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trwMenu_AfterCheck);
            this.trwMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trwMenu_NodeMouseClick);
            // 
            // grpPermisos
            // 
            this.grpPermisos.Controls.Add(this.lblMenu);
            this.grpPermisos.Controls.Add(this.chkAllowPrint);
            this.grpPermisos.Controls.Add(this.chkAllowWrite);
            this.grpPermisos.Controls.Add(this.chkAllowUpdate);
            this.grpPermisos.Controls.Add(this.chkAllowDelete);
            this.grpPermisos.Controls.Add(this.chkAllowRead);
            this.grpPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPermisos.Location = new System.Drawing.Point(383, 80);
            this.grpPermisos.Name = "grpPermisos";
            this.grpPermisos.Size = new System.Drawing.Size(154, 340);
            this.grpPermisos.TabIndex = 10;
            this.grpPermisos.TabStop = false;
            this.grpPermisos.Text = "Permisos";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.BackColor = System.Drawing.Color.Transparent;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(23, 34);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(0, 13);
            this.lblMenu.TabIndex = 0;
            // 
            // chkAllowPrint
            // 
            this.chkAllowPrint.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowPrint.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowPrint.Image")));
            this.chkAllowPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowPrint.Location = new System.Drawing.Point(17, 174);
            this.chkAllowPrint.Name = "chkAllowPrint";
            this.chkAllowPrint.Size = new System.Drawing.Size(88, 25);
            this.chkAllowPrint.TabIndex = 5;
            this.chkAllowPrint.Text = "Imprimir";
            this.chkAllowPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowPrint.UseVisualStyleBackColor = false;
            this.chkAllowPrint.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowWrite
            // 
            this.chkAllowWrite.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowWrite.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowWrite.Image")));
            this.chkAllowWrite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowWrite.Location = new System.Drawing.Point(17, 81);
            this.chkAllowWrite.Name = "chkAllowWrite";
            this.chkAllowWrite.Size = new System.Drawing.Size(94, 28);
            this.chkAllowWrite.TabIndex = 2;
            this.chkAllowWrite.Text = "Escritura";
            this.chkAllowWrite.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowWrite.UseVisualStyleBackColor = false;
            this.chkAllowWrite.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowUpdate.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowUpdate.Image")));
            this.chkAllowUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowUpdate.Location = new System.Drawing.Point(17, 112);
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            this.chkAllowUpdate.Size = new System.Drawing.Size(96, 28);
            this.chkAllowUpdate.TabIndex = 3;
            this.chkAllowUpdate.Text = "Modificar";
            this.chkAllowUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowUpdate.UseVisualStyleBackColor = false;
            this.chkAllowUpdate.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowDelete.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowDelete.Image")));
            this.chkAllowDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowDelete.Location = new System.Drawing.Point(17, 143);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(88, 28);
            this.chkAllowDelete.TabIndex = 4;
            this.chkAllowDelete.Text = "Eliminar";
            this.chkAllowDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowDelete.UseVisualStyleBackColor = false;
            this.chkAllowDelete.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // chkAllowRead
            // 
            this.chkAllowRead.BackColor = System.Drawing.Color.Transparent;
            this.chkAllowRead.Image = ((System.Drawing.Image)(resources.GetObject("chkAllowRead.Image")));
            this.chkAllowRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkAllowRead.Location = new System.Drawing.Point(17, 50);
            this.chkAllowRead.Name = "chkAllowRead";
            this.chkAllowRead.Size = new System.Drawing.Size(96, 28);
            this.chkAllowRead.TabIndex = 1;
            this.chkAllowRead.Text = "Lectura  ";
            this.chkAllowRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAllowRead.UseVisualStyleBackColor = false;
            this.chkAllowRead.CheckedChanged += new System.EventHandler(this.chkAllowRead_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(462, 434);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(381, 434);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 11;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManPerfilEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 461);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grpPermisos);
            this.Controls.Add(this.trwMenu);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPerfilEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Perfil";
            this.Load += new System.EventHandler(this.frmManPerfilEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.grpPermisos.ResumeLayout(false);
            this.grpPermisos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.CheckEdit chkEstado;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.LabelControl lblEstado;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private System.Windows.Forms.TreeView trwMenu;
        private System.Windows.Forms.GroupBox grpPermisos;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.CheckBox chkAllowPrint;
        private System.Windows.Forms.CheckBox chkAllowWrite;
        private System.Windows.Forms.CheckBox chkAllowUpdate;
        private System.Windows.Forms.CheckBox chkAllowDelete;
        private System.Windows.Forms.CheckBox chkAllowRead;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
    }
}