namespace ErpPanorama.Presentation.Modulos.Ecommerce
{
    partial class frmRegPagoCliente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPagoCliente));
            this.gcTxtComentario = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.asdf = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.mnuContextualClienteAsociado = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoClienteAsociadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarClienteAsociadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextualClienteCorreo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoClienteCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarClienteCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextualClienteTracking = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoClienteTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaClienteTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bsListadoClienteCorreo = new System.Windows.Forms.BindingSource(this.components);
            this.bsListadoClienteAsociado = new System.Windows.Forms.BindingSource(this.components);
            this.bsListadoClienteTracking = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtedObs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dteFecPago = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtedOperacion = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComentario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asdf)).BeginInit();
            this.mnuContextualClienteAsociado.SuspendLayout();
            this.mnuContextualClienteCorreo.SuspendLayout();
            this.mnuContextualClienteTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteAsociado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteTracking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtedObs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFecPago.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFecPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtedOperacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTxtComentario
            // 
            this.gcTxtComentario.Appearance.Options.UseTextOptions = true;
            this.gcTxtComentario.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcTxtComentario.Name = "gcTxtComentario";
            // 
            // asdf
            // 
            this.asdf.AutoHeight = false;
            this.asdf.Name = "asdf";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(176, 112);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(98, 112);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // mnuContextualClienteAsociado
            // 
            this.mnuContextualClienteAsociado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualClienteAsociado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteAsociadoToolStripMenuItem,
            this.eliminarClienteAsociadoToolStripMenuItem});
            this.mnuContextualClienteAsociado.Name = "contextMenuStrip1";
            this.mnuContextualClienteAsociado.Size = new System.Drawing.Size(122, 56);
            // 
            // nuevoClienteAsociadoToolStripMenuItem
            // 
            this.nuevoClienteAsociadoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoClienteAsociadoToolStripMenuItem.Image")));
            this.nuevoClienteAsociadoToolStripMenuItem.Name = "nuevoClienteAsociadoToolStripMenuItem";
            this.nuevoClienteAsociadoToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.nuevoClienteAsociadoToolStripMenuItem.Text = "Nuevo";
            this.nuevoClienteAsociadoToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteAsociadoToolStripMenuItem_Click);
            // 
            // eliminarClienteAsociadoToolStripMenuItem
            // 
            this.eliminarClienteAsociadoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarClienteAsociadoToolStripMenuItem.Image")));
            this.eliminarClienteAsociadoToolStripMenuItem.Name = "eliminarClienteAsociadoToolStripMenuItem";
            this.eliminarClienteAsociadoToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.eliminarClienteAsociadoToolStripMenuItem.Text = "Eliminar";
            this.eliminarClienteAsociadoToolStripMenuItem.Click += new System.EventHandler(this.eliminarClienteAsociadoToolStripMenuItem_Click);
            // 
            // mnuContextualClienteCorreo
            // 
            this.mnuContextualClienteCorreo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualClienteCorreo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteCorreoToolStripMenuItem,
            this.eliminarClienteCorreoToolStripMenuItem});
            this.mnuContextualClienteCorreo.Name = "contextMenuStrip1";
            this.mnuContextualClienteCorreo.Size = new System.Drawing.Size(122, 56);
            // 
            // nuevoClienteCorreoToolStripMenuItem
            // 
            this.nuevoClienteCorreoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoClienteCorreoToolStripMenuItem.Image")));
            this.nuevoClienteCorreoToolStripMenuItem.Name = "nuevoClienteCorreoToolStripMenuItem";
            this.nuevoClienteCorreoToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.nuevoClienteCorreoToolStripMenuItem.Text = "Nuevo";
            this.nuevoClienteCorreoToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteCorreoToolStripMenuItem_Click);
            // 
            // eliminarClienteCorreoToolStripMenuItem
            // 
            this.eliminarClienteCorreoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarClienteCorreoToolStripMenuItem.Image")));
            this.eliminarClienteCorreoToolStripMenuItem.Name = "eliminarClienteCorreoToolStripMenuItem";
            this.eliminarClienteCorreoToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.eliminarClienteCorreoToolStripMenuItem.Text = "Eliminar";
            this.eliminarClienteCorreoToolStripMenuItem.Click += new System.EventHandler(this.eliminarClienteCorreoToolStripMenuItem_Click);
            // 
            // mnuContextualClienteTracking
            // 
            this.mnuContextualClienteTracking.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextualClienteTracking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteTrackingToolStripMenuItem,
            this.eliminaClienteTrackingToolStripMenuItem});
            this.mnuContextualClienteTracking.Name = "contextMenuStrip1";
            this.mnuContextualClienteTracking.Size = new System.Drawing.Size(122, 56);
            // 
            // nuevoClienteTrackingToolStripMenuItem
            // 
            this.nuevoClienteTrackingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoClienteTrackingToolStripMenuItem.Image")));
            this.nuevoClienteTrackingToolStripMenuItem.Name = "nuevoClienteTrackingToolStripMenuItem";
            this.nuevoClienteTrackingToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.nuevoClienteTrackingToolStripMenuItem.Text = "Nuevo";
            this.nuevoClienteTrackingToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteTrackingToolStripMenuItem_Click);
            // 
            // eliminaClienteTrackingToolStripMenuItem
            // 
            this.eliminaClienteTrackingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminaClienteTrackingToolStripMenuItem.Image")));
            this.eliminaClienteTrackingToolStripMenuItem.Name = "eliminaClienteTrackingToolStripMenuItem";
            this.eliminaClienteTrackingToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.eliminaClienteTrackingToolStripMenuItem.Text = "Eliminar";
            this.eliminaClienteTrackingToolStripMenuItem.Click += new System.EventHandler(this.eliminaClienteTrackingToolStripMenuItem_Click);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // gridView3
            // 
            this.gridView3.Name = "gridView3";
            // 
            // gridView4
            // 
            this.gridView4.Name = "gridView4";
            // 
            // gridView5
            // 
            this.gridView5.Name = "gridView5";
            // 
            // gridView6
            // 
            this.gridView6.Name = "gridView6";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.txtedObs);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.dteFecPago);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.txtedOperacion);
            this.groupControl2.Location = new System.Drawing.Point(12, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(332, 97);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Pago Pedido Web";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(84, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Banco:";
            // 
            // txtedObs
            // 
            this.txtedObs.Location = new System.Drawing.Point(123, 67);
            this.txtedObs.Name = "txtedObs";
            this.txtedObs.Properties.MaxLength = 15;
            this.txtedObs.Size = new System.Drawing.Size(159, 20);
            this.txtedObs.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(42, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(75, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Fecha de Pago:";
            // 
            // dteFecPago
            // 
            this.dteFecPago.EditValue = null;
            this.dteFecPago.Location = new System.Drawing.Point(123, 25);
            this.dteFecPago.Name = "dteFecPago";
            this.dteFecPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFecPago.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteFecPago.Size = new System.Drawing.Size(119, 20);
            this.dteFecPago.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(36, 49);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(81, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Num. Operación:";
            // 
            // txtedOperacion
            // 
            this.txtedOperacion.Location = new System.Drawing.Point(123, 46);
            this.txtedOperacion.Name = "txtedOperacion";
            this.txtedOperacion.Properties.MaxLength = 15;
            this.txtedOperacion.Size = new System.Drawing.Size(159, 20);
            this.txtedOperacion.TabIndex = 2;
            // 
            // frmRegPagoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 138);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPagoCliente";
            this.Load += new System.EventHandler(this.frmManClienteMinoristaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtComentario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asdf)).EndInit();
            this.mnuContextualClienteAsociado.ResumeLayout(false);
            this.mnuContextualClienteCorreo.ResumeLayout(false);
            this.mnuContextualClienteTracking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteAsociado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListadoClienteTracking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtedObs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFecPago.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFecPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtedOperacion.Properties)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnCancelar;
    private System.Windows.Forms.ContextMenuStrip mnuContextualClienteCorreo;
    private System.Windows.Forms.ToolStripMenuItem nuevoClienteCorreoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem eliminarClienteCorreoToolStripMenuItem;
    private System.Windows.Forms.BindingSource bsListadoClienteCorreo;
    private System.Windows.Forms.ContextMenuStrip mnuContextualClienteAsociado;
    private System.Windows.Forms.ToolStripMenuItem nuevoClienteAsociadoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem eliminarClienteAsociadoToolStripMenuItem;
    private System.Windows.Forms.BindingSource bsListadoClienteAsociado;
    public DevExpress.XtraEditors.SimpleButton btnGrabar;
    private System.Windows.Forms.BindingSource bsListadoClienteTracking;
    private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit gcTxtComentario;
    private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit asdf;
    private System.Windows.Forms.ContextMenuStrip mnuContextualClienteTracking;
    private System.Windows.Forms.ToolStripMenuItem nuevoClienteTrackingToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem eliminaClienteTrackingToolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtedObs;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dteFecPago;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtedOperacion;
    }
}