namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmImportarImagenes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProceso = new DevExpress.XtraEditors.SimpleButton();
            this.btnDirectorio = new DevExpress.XtraEditors.SimpleButton();
            this.txtDirectorio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dgImg = new System.Windows.Forms.DataGridView();
            this.colIcn = new System.Windows.Forms.DataGridViewImageColumn();
            this.colArc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgFot = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectorio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFot)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnProceso);
            this.panel1.Controls.Add(this.btnDirectorio);
            this.panel1.Controls.Add(this.txtDirectorio);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnProceso
            // 
            this.btnProceso.Image = global::ErpPanorama.Presentation.Properties.Resources.Proceso_16x16;
            this.btnProceso.ImageIndex = 1;
            this.btnProceso.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnProceso.Location = new System.Drawing.Point(486, 3);
            this.btnProceso.Name = "btnProceso";
            this.btnProceso.Size = new System.Drawing.Size(25, 23);
            this.btnProceso.TabIndex = 31;
            this.btnProceso.Click += new System.EventHandler(this.btnProceso_Click);
            // 
            // btnDirectorio
            // 
            this.btnDirectorio.Image = global::ErpPanorama.Presentation.Properties.Resources.FolderPicture_16x16;
            this.btnDirectorio.ImageIndex = 1;
            this.btnDirectorio.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDirectorio.Location = new System.Drawing.Point(455, 3);
            this.btnDirectorio.Name = "btnDirectorio";
            this.btnDirectorio.Size = new System.Drawing.Size(25, 23);
            this.btnDirectorio.TabIndex = 30;
            this.btnDirectorio.Click += new System.EventHandler(this.btnDirectorio_Click);
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Location = new System.Drawing.Point(57, 6);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(392, 20);
            this.txtDirectorio.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Carpeta:";
            // 
            // dgImg
            // 
            this.dgImg.AllowUserToAddRows = false;
            this.dgImg.AllowUserToOrderColumns = true;
            this.dgImg.AllowUserToResizeRows = false;
            this.dgImg.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgImg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgImg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgImg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgImg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIcn,
            this.colArc});
            this.dgImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgImg.Location = new System.Drawing.Point(0, 32);
            this.dgImg.Name = "dgImg";
            this.dgImg.ReadOnly = true;
            this.dgImg.RowHeadersVisible = false;
            this.dgImg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgImg.Size = new System.Drawing.Size(524, 405);
            this.dgImg.TabIndex = 48;
            // 
            // colIcn
            // 
            this.colIcn.HeaderText = "";
            this.colIcn.Name = "colIcn";
            this.colIcn.ReadOnly = true;
            this.colIcn.Width = 30;
            // 
            // colArc
            // 
            this.colArc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colArc.HeaderText = "Archivo";
            this.colArc.Name = "colArc";
            this.colArc.ReadOnly = true;
            // 
            // imgFot
            // 
            this.imgFot.Location = new System.Drawing.Point(473, 383);
            this.imgFot.Name = "imgFot";
            this.imgFot.Size = new System.Drawing.Size(51, 54);
            this.imgFot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFot.TabIndex = 50;
            this.imgFot.TabStop = false;
            this.imgFot.Visible = false;
            // 
            // frmImportarImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 437);
            this.Controls.Add(this.imgFot);
            this.Controls.Add(this.dgImg);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportarImagenes";
            this.Text = "Importar Imágenes de Productos";
            this.Load += new System.EventHandler(this.frmImportarImagenes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirectorio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgImg;
        private System.Windows.Forms.DataGridViewImageColumn colIcn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArc;
        private System.Windows.Forms.PictureBox imgFot;
        private DevExpress.XtraEditors.TextEdit txtDirectorio;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnProceso;
        private DevExpress.XtraEditors.SimpleButton btnDirectorio;
    }
}