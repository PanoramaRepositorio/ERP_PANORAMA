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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmKardexValorizadoTiendas : DevExpress.XtraEditors.XtraForm
    {
        public frmKardexValorizadoTiendas()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKardexValorizadoTiendas_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivoKardex(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            cboTienda.EditValue = Parametros.intTiendaId;

            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivoKardex(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboLinea_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}