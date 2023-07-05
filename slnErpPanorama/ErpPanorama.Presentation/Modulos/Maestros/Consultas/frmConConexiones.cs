using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Maestros.Consultas
{
    public partial class frmConConexiones : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<ReporteConexionSQLBE> mLista = new List<ReporteConexionSQLBE>();

        #endregion

        #region "Eventos"

        public frmConConexiones()
        {
            InitializeComponent();
        }

        private void frmConConexiones_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ReporteConexionSQLBL().Listado(Parametros.intEmpresaId);
            gcConexionSQL.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count.ToString() + " Conexiones Activas";
            //gvConexionSQL.text
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                Cargar();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void bntConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }


    }
}