namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    partial class frmAsistenciaImportacionManual
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
            this.gcMarcacion = new DevExpress.XtraGrid.GridControl();
            this.gvMarcacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtRuta = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExaminar = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.dgMarcacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMarcacion
            // 
            this.gcMarcacion.Location = new System.Drawing.Point(238, 440);
            this.gcMarcacion.MainView = this.gvMarcacion;
            this.gcMarcacion.Name = "gcMarcacion";
            this.gcMarcacion.Size = new System.Drawing.Size(216, 98);
            this.gcMarcacion.TabIndex = 6;
            this.gcMarcacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMarcacion});
            this.gcMarcacion.Visible = false;
            // 
            // gvMarcacion
            // 
            this.gvMarcacion.GridControl = this.gcMarcacion;
            this.gvMarcacion.Name = "gvMarcacion";
            this.gvMarcacion.OptionsView.ShowGroupPanel = false;
            this.gvMarcacion.OptionsView.ShowViewCaption = true;
            this.gvMarcacion.ViewCaption = "Marcaciones";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(164, 13);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Properties.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(441, 20);
            this.txtRuta.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccionar archivo de texto: ";
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.Image = global::ErpPanorama.Presentation.Properties.Resources.invoice_16x16;
            this.btnImportar.Location = new System.Drawing.Point(514, 411);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(172, 23);
            this.btnImportar.TabIndex = 7;
            this.btnImportar.Text = "&Importar Marcaciones";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(611, 11);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(75, 23);
            this.btnExaminar.TabIndex = 8;
            this.btnExaminar.Text = "&Examinar...";
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(30, 416);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(61, 13);
            this.lblTotalRegistros.TabIndex = 12;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // dgMarcacion
            // 
            this.dgMarcacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMarcacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMarcacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcacion.Location = new System.Drawing.Point(19, 40);
            this.dgMarcacion.Name = "dgMarcacion";
            this.dgMarcacion.RowHeadersVisible = false;
            this.dgMarcacion.Size = new System.Drawing.Size(667, 365);
            this.dgMarcacion.TabIndex = 11;
            // 
            // frmAsistenciaImportacionManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 452);
            this.Controls.Add(this.gcMarcacion);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.dgMarcacion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsistenciaImportacionManual";
            this.Text = "Importación de Marcaciones";
            this.Load += new System.EventHandler(this.frmAsistenciaImportacionManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMarcacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarcacion;
        private DevExpress.XtraEditors.TextEdit txtRuta;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnImportar;
        private DevExpress.XtraEditors.SimpleButton btnExaminar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.DataGridView dgMarcacion;
    }
}