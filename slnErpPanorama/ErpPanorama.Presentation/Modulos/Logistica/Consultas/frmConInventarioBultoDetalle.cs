using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConInventarioBultoDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<KardexBultoBE> mLista = new List<KardexBultoBE>();

        public int IdProducto { get; set; }
        public int IdAlmacen { get; set; }
        public string CodigoProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Abreviatura { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        #endregion

        #region "Eventos"

        public frmConInventarioBultoDetalle()
        {
            InitializeComponent();
        }

        private void frmConInventarioBultoDetalle_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = CodigoProveedor;
            txtNombreProducto.Text = NombreProducto;
            txtUnidadMedida.Text = Abreviatura;

            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new KardexBultoBL().ListaInventarioDetalle(Parametros.intEmpresaId, IdAlmacen, IdProducto, FechaDesde, FechaHasta);
            gcInventarioBultoDetalle.DataSource = mLista;
        }

        #endregion

        
    }
}