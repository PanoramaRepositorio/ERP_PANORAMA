﻿namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    partial class frmManTipoColorEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTipoColorEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDis_TipoColor = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDis_TipoColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Controls.Add(this.txtDis_TipoColor);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(483, 79);
            this.grdDatos.TabIndex = 9;
            this.grdDatos.Text = "Datos";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(402, 51);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Descripcion:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(321, 51);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtDis_TipoColor
            // 
            this.txtDis_TipoColor.Location = new System.Drawing.Point(76, 25);
            this.txtDis_TipoColor.Name = "txtDis_TipoColor";
            this.txtDis_TipoColor.Size = new System.Drawing.Size(400, 20);
            this.txtDis_TipoColor.TabIndex = 3;
            // 
            // frmManTipoColorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 79);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManTipoColorEdit";
            this.Load += new System.EventHandler(this.frmManTipoColorEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDis_TipoColor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.TextEdit txtDis_TipoColor;
    }
}