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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmConAusenciaLeyenda : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MotivoAusenciaBE> mLista = new List<MotivoAusenciaBE>();

        #endregion

        #region "Eventos"

        public frmConAusenciaLeyenda()
        {
            InitializeComponent();
        }

        private void frmConAusenciaLeyenda_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MotivoAusenciaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMotivoAusencia.DataSource = mLista;
        }

        #endregion

    }
}