using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmVerFotoProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public int IdProducto { get; set; }
        
        #endregion

        #region "Metodos"

        public frmVerFotoProducto()
        {
            InitializeComponent();
        }

        private void frmVerFotoProducto_Load(object sender, EventArgs e)
        {
            CargarFoto();
        }

        #endregion

        #region "Eventos"

        private void CargarFoto()
        {
            ProductoBE objE_Producto = null;
            objE_Producto = new ProductoBL().SeleccionaImagen(Parametros.intIdPanoramaDistribuidores, IdProducto);

            if (objE_Producto.Imagen != null)
            {
                this.picImage.Image = new FuncionBase().Bytes2Image((byte[])objE_Producto.Imagen);
            }
            else
            { this.picImage.Image = ErpPanorama.Presentation.Properties.Resources.noImage; }
           
        }

        #endregion

       
    }
}