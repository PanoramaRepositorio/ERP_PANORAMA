using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRegCambiarSituacionPedidoAlmacen : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmRegCambiarSituacionPedidoAlmacen()
        {
            InitializeComponent();
        }

        private void frmRegCambiarSituacionPedidoAlmacen_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSituacionAlmacen, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblSituacionAlmacen), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //PedidoBE ObjE_Pedido = null;
                //ObjE_Pedido = new PedidoBL().Selecciona(IdPedido);

                //if (ObjE_Pedido.IdSituacion == Parametros.intFacturado && Convert.ToInt32(cboSituacionAlmacen.EditValue) == Parametros.intEnAlmacenDespacho)
                //{
                    PedidoBL objBL_Pedido = new PedidoBL();
                    objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Convert.ToInt32(cboSituacionAlmacen.EditValue), Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());
                    this.Close();
                //}
                //else
                //{
                //    XtraMessageBox.Show("El pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}



            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        #endregion

        #region "Metodos"

        #endregion

        
    }
}