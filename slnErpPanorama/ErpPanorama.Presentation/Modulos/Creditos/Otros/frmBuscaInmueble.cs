using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    public partial class frmBuscaInmueble : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<InmuebleBE> mLista = new List<InmuebleBE>();
        public InmuebleBE _Be { get; set; }

        #endregion

        #region "Eventos"
        public frmBuscaInmueble()
        {
            InitializeComponent();
        }

        private void frmBuscaInmueble_Load(object sender, EventArgs e)
        {
            Carga();
        }

        private void gvInmueble_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void gvInmueble_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aceptar();
        }

        private void txtInmueble_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarCriterio();
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            mLista = new InmuebleBL().ListaTodosActivo(0); //.SeleccionaBusqueda();
            gcInmueble.DataSource = mLista;
        }

        private void Aceptar()
        {
            _Be = (InmuebleBE)gvInmueble.GetRow(gvInmueble.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarCriterio()
        {
            gcInmueble.DataSource = mLista.Where(obj =>
                                                   obj.DescInmueble.ToUpper().Contains(txtInmueble.Text.ToUpper())).ToList();

        }

        #endregion

    }
}