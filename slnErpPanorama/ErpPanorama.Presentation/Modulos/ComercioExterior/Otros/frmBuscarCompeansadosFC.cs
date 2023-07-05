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

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Otros
{
    public partial class frmBuscarCompeansadosFC : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"
        public List<EstadoCuentaProveedorPagoBE> mListaPago = new List<EstadoCuentaProveedorPagoBE>();

        public int IdProveedor { get; set; }
        public int IdEstadoCuentaProveedor { get; set; }
        #endregion
        public frmBuscarCompeansadosFC()
        {
            InitializeComponent();
        }

        private void frmBuscarCompeansadosFC_Load(object sender, EventArgs e)
        {
            gcEstadoCuentaProveedor.DataSource = mListaPago;

            //Formato
            gcGrupoPago.Visible = true;
            gcGrupoPago.GroupIndex = 1;
            gvEstadoCuentaProveedor.OptionsView.ShowGroupPanel = false;
            gvEstadoCuentaProveedor.ExpandAllGroups();
        }
    }
}