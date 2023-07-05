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

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConBultosInvolucrados : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<DocumentoBultoBE> mLista = new List<DocumentoBultoBE>();

        public int Periodo { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Numero { get; set; }

        #endregion

        #region "Eventos"

        public frmConBultosInvolucrados()
        {
            InitializeComponent();
        }

        private void frmConBultosInvolucrados_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DocumentoBultoBL().ListaTodosActivo(Parametros.intEmpresaId, Periodo, IdTipoDocumento, Numero);
            gcBulto.DataSource = mLista;
        }

        #endregion

        
    }
}