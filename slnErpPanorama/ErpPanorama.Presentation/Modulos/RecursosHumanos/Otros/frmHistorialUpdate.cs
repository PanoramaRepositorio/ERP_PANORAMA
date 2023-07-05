using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    public partial class frmHistorialUpdate : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<TempCheckinoutBE> mLista = new List<TempCheckinoutBE>();
        public string Dni { get; set; } = "";
        public DateTime Fecha { get; set; }
        #endregion

        #region "Eventos"

        public frmHistorialUpdate()
        {
            InitializeComponent();
        }

        private void frmHistorialUpdate_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new TempCheckinoutBL().ListaFecha(Dni, Fecha, Fecha);
            gcMarcacion.DataSource = mLista;
        }
        
        #endregion
    }
}