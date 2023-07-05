namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManInsumoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManInsumoEdit));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.cboClasificacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoBarra = new DevExpress.XtraEditors.TextEdit();
            this.cboUnidadMedida = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtIdInsumo = new DevExpress.XtraEditors.TextEdit();
            this.chkActivo = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadMedida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdInsumo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(905, 400);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl3);
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(899, 372);
            this.xtraTabPage1.Text = "Datos Generales";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnEliminar);
            this.groupControl3.Controls.Add(this.btnAgregar);
            this.groupControl3.Controls.Add(this.picImage);
            this.groupControl3.Location = new System.Drawing.Point(566, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(329, 359);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Clasificación";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageIndex = 1;
            this.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(299, 52);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageIndex = 1;
            this.btnAgregar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(299, 23);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // picImage
            // 
            this.picImage.EditValue = global::ErpPanorama.Presentation.Properties.Resources.noImage;
            this.picImage.Location = new System.Drawing.Point(13, 23);
            this.picImage.Name = "picImage";
            this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picImage.Size = new System.Drawing.Size(280, 315);
            this.picImage.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dateEdit1);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.textEdit1);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Location = new System.Drawing.Point(3, 182);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(557, 180);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Más Información";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(98, 23);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 1;
            this.dateEdit1.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Fecha Compra:";
            this.labelControl2.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(98, 45);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textEdit1.Properties.MaxLength = 50;
            this.textEdit1.Size = new System.Drawing.Size(120, 20);
            this.textEdit1.TabIndex = 3;
            this.textEdit1.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Proveedor:";
            this.labelControl3.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtObservaciones);
            this.groupControl1.Controls.Add(this.cboClasificacion);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl20);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtCodigoBarra);
            this.groupControl1.Controls.Add(this.cboUnidadMedida);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtIdInsumo);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(557, 173);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Datos";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(98, 97);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Properties.MaxLength = 500;
            this.txtObservaciones.Size = new System.Drawing.Size(452, 59);
            this.txtObservaciones.TabIndex = 11;
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.Location = new System.Drawing.Point(98, 75);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClasificacion.Properties.NullText = "";
            this.cboClasificacion.Size = new System.Drawing.Size(452, 20);
            this.cboClasificacion.TabIndex = 9;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(11, 98);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(75, 13);
            this.labelControl12.TabIndex = 10;
            this.labelControl12.Text = "Observaciones:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(11, 78);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(62, 13);
            this.labelControl20.TabIndex = 8;
            this.labelControl20.Text = "Clasificación:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(216, 35);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(61, 13);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Cod. Barras:";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(281, 32);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Properties.MaxLength = 15;
            this.txtCodigoBarra.Size = new System.Drawing.Size(159, 20);
            this.txtCodigoBarra.TabIndex = 3;
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.Location = new System.Drawing.Point(488, 32);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnidadMedida.Properties.NullText = "";
            this.cboUnidadMedida.Size = new System.Drawing.Size(62, 20);
            this.cboUnidadMedida.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(446, 35);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Unidad:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(98, 53);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(452, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 56);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Nombre:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Código:";
            // 
            // txtIdInsumo
            // 
            this.txtIdInsumo.Location = new System.Drawing.Point(98, 32);
            this.txtIdInsumo.Name = "txtIdInsumo";
            this.txtIdInsumo.Properties.MaxLength = 25;
            this.txtIdInsumo.Properties.ReadOnly = true;
            this.txtIdInsumo.Size = new System.Drawing.Size(111, 20);
            this.txtIdInsumo.TabIndex = 1;
            // 
            // chkActivo
            // 
            this.chkActivo.EditValue = true;
            this.chkActivo.Location = new System.Drawing.Point(17, 406);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkActivo.Properties.Appearance.Options.UseFont = true;
            this.chkActivo.Properties.Caption = "Activo";
            this.chkActivo.Size = new System.Drawing.Size(89, 19);
            this.chkActivo.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(774, 413);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(697, 413);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManInsumoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 446);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManInsumoEdit";
            this.Load += new System.EventHandler(this.frmManInsumoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoBarra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidadMedida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdInsumo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        public DevExpress.XtraEditors.LookUpEdit cboClasificacion;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtCodigoBarra;
        public DevExpress.XtraEditors.LookUpEdit cboUnidadMedida;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtIdInsumo;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnEliminar;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.PictureEdit picImage;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}