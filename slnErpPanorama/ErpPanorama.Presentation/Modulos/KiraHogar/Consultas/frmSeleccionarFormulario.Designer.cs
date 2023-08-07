
namespace ErpPanorama.Presentation.Modulos.KiraHogar.Consultas
{
    partial class frmSeleccionarFormulario
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
            this.btnAbrirCotizacion = new System.Windows.Forms.Button();
            this.btnAbrirProductoTerminado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAbrirCotizacion
            // 
            this.btnAbrirCotizacion.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirCotizacion.Name = "btnAbrirCotizacion";
            this.btnAbrirCotizacion.Size = new System.Drawing.Size(171, 23);
            this.btnAbrirCotizacion.TabIndex = 0;
            this.btnAbrirCotizacion.Text = "Precio Producto Cliente Stock";
            this.btnAbrirCotizacion.UseVisualStyleBackColor = true;
            this.btnAbrirCotizacion.Click += new System.EventHandler(this.btnAbrirCotizacion_Click);
            // 
            // btnAbrirProductoTerminado
            // 
            this.btnAbrirProductoTerminado.Location = new System.Drawing.Point(189, 12);
            this.btnAbrirProductoTerminado.Name = "btnAbrirProductoTerminado";
            this.btnAbrirProductoTerminado.Size = new System.Drawing.Size(162, 23);
            this.btnAbrirProductoTerminado.TabIndex = 1;
            this.btnAbrirProductoTerminado.Text = "Precio Producto Terminado";
            this.btnAbrirProductoTerminado.UseVisualStyleBackColor = true;
            this.btnAbrirProductoTerminado.Click += new System.EventHandler(this.btnAbrirProductoTerminado_Click);
            // 
            // frmSeleccionarFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 46);
            this.Controls.Add(this.btnAbrirProductoTerminado);
            this.Controls.Add(this.btnAbrirCotizacion);
            this.Name = "frmSeleccionarFormulario";
            this.Text = "Escoja registro";
            this.Load += new System.EventHandler(this.frmSeleccionarFormulario_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirCotizacion;
        private System.Windows.Forms.Button btnAbrirProductoTerminado;
    }
}