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

namespace ErpPanorama.Presentation.Modulos.Maestros.Otros
{
    public partial class frmBuscaPersona : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PersonaBE> mLista = new List<PersonaBE>();
        public PersonaBE _Be { get; set; }
        
        public int TipoBusqueda = 0;
        public string Title = "Búsqueda de Persona";

        #endregion

        #region "Eventos"

        public frmBuscaPersona()
        {
            InitializeComponent();
        }

        private void frmBuscaPersona_Load(object sender, EventArgs e)
        {
            this.Text = Title;
            Carga();
            txtPersona.Select();
        }

        private void gvPersona_DoubleClick(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void gvPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aceptar();
        }

        private void txtPersona_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarCriterio();
        }

        #endregion

        #region "Metodos"

        private void Carga()
        {
            if (TipoBusqueda == 0)
            {
                mLista = new PersonaBL().SeleccionaBusqueda();
                gcPersona.DataSource = mLista;
            }
            if (TipoBusqueda == 1) 
            {
                mLista = new PersonaBL().SeleccionaBusquedaSinUsuario();
                gcPersona.DataSource = mLista;
            }

        }

        private void Aceptar()
        {
            _Be = (PersonaBE)gvPersona.GetRow(gvPersona.FocusedRowHandle);
            this.DialogResult = DialogResult.OK;
        }

        private void BuscarCriterio()
        {
            gcPersona.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtPersona.Text.ToUpper())).ToList();

        }

        #endregion

        
    }
}