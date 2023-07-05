using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmModificarHorario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        HorarioPersonaBE mLista = new HorarioPersonaBE();

        public int IdPersona { get; set; }
        public int IdHorarioPersona { get; set; }
        public int Fecha { get; set; }
        #endregion

        #region "Eventos"
        public frmModificarHorario()
        {
            InitializeComponent();
        }

        private void frmModificarHorario_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Métodos"
        public void Cargar()
        {
           //mLista = new HorarioPersonaBL().ListaTodosActivo(IdPersona,  deFecha.EditValue);
        }
        #endregion
    }
}