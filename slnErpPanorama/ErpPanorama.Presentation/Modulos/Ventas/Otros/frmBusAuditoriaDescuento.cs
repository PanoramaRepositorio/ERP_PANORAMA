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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusAuditoriaDescuento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TempListaPrecioDetalleBE> mLista = new List<TempListaPrecioDetalleBE>();
        public Int32 IdProducto { get; set; }

        #endregion

        #region "Eventos"
        public frmBusAuditoriaDescuento()
        {
            InitializeComponent();
        }

        private void frmBusAuditoriaDescuento_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new TempListaPrecioDetalleBL().ListaTodosActivo(Parametros.intEmpresaId,Parametros.intTiendaId, IdProducto);
            gcProducto.DataSource = mLista;
        }
        #endregion

    }
}