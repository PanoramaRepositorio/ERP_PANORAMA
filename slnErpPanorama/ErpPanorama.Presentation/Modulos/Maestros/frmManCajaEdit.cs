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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManCajaEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        
        public List<CajaBE> lstCaja;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public CajaBE pCajaBE { get; set; }

        int _IdCaja = 0;

        public int IdCaja
        {
            get { return _IdCaja; }
            set { _IdCaja = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManCajaEdit()
        {
            InitializeComponent();
        }

        private void frmManCajaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Caja - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Caja - Modificar";
                cboTienda.EditValue = pCajaBE.IdTienda;
                txtDescripcion.Text = pCajaBE.DescCaja.Trim();
                txtMac.Text = pCajaBE.Mac;
                chkVenta.Checked = pCajaBE.FlagVenta;
            }

            txtDescripcion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    CajaBL objBL_Caja = new CajaBL();
                    CajaBE objCaja = new CajaBE();

                    objCaja.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objCaja.IdCaja = IdCaja;
                    objCaja.DescCaja = txtDescripcion.Text;
                    objCaja.Mac = txtMac.Text;
                    objCaja.FlagVenta = chkVenta.Checked;
                    objCaja.FlagEstado = true;
                    objCaja.Usuario = Parametros.strUsuarioLogin;
                    objCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objCaja.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Caja.Inserta(objCaja);
                    else
                        objBL_Caja.Actualiza(objCaja);

                    this.Close();
                }
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

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboTienda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione la tienda.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (txtMac.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Dirección MAC.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstCaja.Where(oB => oB.DescCaja.ToUpper() == txtDescripcion.Text.ToUpper() && oB.DescTienda == cboTienda.Text
                                            || oB.Mac.ToUpper() == txtMac.Text.ToUpper() ).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción y/o MAC ya existe.\n";
                    flag = true;
                }
            }

            if (pOperacion == Operacion.Modificar)
            {
                //List<CajaBE> lstCaja = new List<CajaBE>();
                lstCaja = new CajaBL().ListaTodosActivo(0, 0);

                //var Buscar = lstCaja.Where(oB => oB.DescCaja.ToUpper() == txtDescripcion.Text.ToUpper() && oB.DescTienda == cboTienda.Text).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- La Caja ya existe.\n"  ;
                //    flag = true;
                //}

                var BuscarMac = lstCaja.Where(oB => oB.Mac.ToUpper() == txtMac.Text.ToUpper()).ToList();
                if (BuscarMac.Count > 0)
                {
                    strMensaje = strMensaje + "- La Dirección MAC está asignado a :" + BuscarMac[0].RazonSocial + " - " + BuscarMac[0].DescTienda + " - " + BuscarMac[0].DescCaja + " \n";
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

        
    }
}