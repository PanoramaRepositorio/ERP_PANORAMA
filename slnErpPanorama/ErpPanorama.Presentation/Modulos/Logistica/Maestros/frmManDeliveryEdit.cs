using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManDeliveryEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public UbigeoBE oBE;
        public List<ListaPrecioDeliveryBE> lstListaPrecioDelivery;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public ListaPrecioDeliveryBE pListaPrecioDeliveryBE { get; set; }

        int _IdIdListaPrecioDelivery = 0;

        public int IdListaPrecioDelivery
        {
            get { return _IdIdListaPrecioDelivery; }
            set { _IdIdListaPrecioDelivery = value; }
        }



        #endregion

        #region "Eventos"

        public frmManDeliveryEdit()
        {
            InitializeComponent();
        }

        private void frmManDeliveryEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Almacen - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Almacen - Modificar";
                cboDepartamento.EditValue = pListaPrecioDeliveryBE.IdDepartamento;
                cboProvincia.EditValue = pListaPrecioDeliveryBE.IdProvincia;
                cboDistrito.EditValue = pListaPrecioDeliveryBE.IdDistrito;
                txtDescripcion.EditValue = pListaPrecioDeliveryBE.DescUbigeo;
                txtTotal.EditValue = pListaPrecioDeliveryBE.TarifaEnvio;
                txtTotala.EditValue = pListaPrecioDeliveryBE.TarifaEnvioA;
                txtTotalp.EditValue = pListaPrecioDeliveryBE.TarifaEnvioP;
            }

            txtDescripcion.Select();

        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);

                if (pOperacion == Operacion.Nuevo)
                {
                    cboProvincia.EditValue = Parametros.sIdProvincia;
                }
                else
                {
                    cboProvincia.EditValue = pListaPrecioDeliveryBE.IdProvincia;
                }
                
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(),cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);

                //BSUtils.LoaderLook(cboDistrito, new /*ListaPrecioDeliveryBL*/().ListaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdListaPrecioDelivery", false);//del 29/09
                //cboDistrito.EditValue = Parametros.sIdDistrito;
                if (pOperacion == Operacion.Nuevo)
                {
                    cboDistrito.EditValue = Parametros.sIdDistrito;
                }
                else
                {
                    cboDistrito.EditValue = pListaPrecioDeliveryBE.IdDistrito;
                }
            }
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboDistrito.EditValue != null)
            //{
            //    ListaPrecioDeliveryBE objE_ListaPrecioDelivery = null;
            //    objE_ListaPrecioDelivery = new ListaPrecioDeliveryBL().Selecciona(Convert.ToInt32(cboDistrito.EditValue));
            //    txtTotal.EditValue = objE_ListaPrecioDelivery.TarifaEnvio;
            //    cboDistrito.Select();
            //}

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCallao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCallao.Checked == true)
            {
                cboDepartamento.Enabled = true;
                cboProvincia.Enabled = true;
                cboDepartamento.EditValue = "07";//Callao
            }
            else
            {
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDepartamento.EditValue = Parametros.sIdDepartamento;//Lima
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ListaPrecioDeliveryBL objBL_Almacen = new ListaPrecioDeliveryBL();
                    ListaPrecioDeliveryBE objAlmacen = new ListaPrecioDeliveryBE();
                    objAlmacen.IdListaPrecioDelivery = IdListaPrecioDelivery;
                    objAlmacen.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objAlmacen.IdDepartamento = cboDepartamento.EditValue.ToString();
                    objAlmacen.IdProvincia = cboProvincia.EditValue.ToString();
                    objAlmacen.IdDistrito = cboDistrito.EditValue.ToString();
                    objAlmacen.DescUbigeo = txtDescripcion.Text.Trim();

                    objAlmacen.TarifaEnvio = Convert.ToDecimal(txtTotal.EditValue);
                    objAlmacen.TarifaEnvioA = Convert.ToDecimal(txtTotala.EditValue);
                    objAlmacen.TarifaEnvioP = Convert.ToDecimal(txtTotalp.EditValue);

                    objAlmacen.FlagEstado = true;
                    objAlmacen.Usuario = Parametros.strUsuarioLogin;
                    objAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objAlmacen.IdEmpresa = Parametros.intIdPanoramaDistribuidores;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Almacen.Inserta(objAlmacen);
                    else
                        objBL_Almacen.Actualiza(objAlmacen);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción del Distrito.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstListaPrecioDelivery.Where(oB => oB.DescUbigeo.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Distrito ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        private void grdDatos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}