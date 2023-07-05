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
    public partial class frmManTipoCambioEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<TipoCambioBE> lstTipoCambio;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TipoCambioBE pTipoCambioBE { get; set; }

        int _IdTipoCambio = 0;

        public int IdTipoCambio
        {
            get { return _IdTipoCambio; }
            set { _IdTipoCambio = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipoCambioEdit()
        {
            InitializeComponent();
        }

        private void frmManTipoCambioEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipo de Cambio - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipo de Cambio - Modificar";

                cboMoneda.EditValue = pTipoCambioBE.IdMoneda;
                deFecha.EditValue = pTipoCambioBE.Fecha;
                txtCompra.EditValue = pTipoCambioBE.Compra;
                txtVenta.EditValue = pTipoCambioBE.Venta;
                txtCompraSunat.EditValue = pTipoCambioBE.CompraSunat;
                txtVentaSunat.EditValue = pTipoCambioBE.VentaSunat;

            }

            txtCompra.Select();

            
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
              //  Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TipoCambioBL objBL_TipoCambio = new TipoCambioBL();
                    TipoCambioBE objTipoCambio = new TipoCambioBE();
                    objTipoCambio.IdTipoCambio = IdTipoCambio;
                    objTipoCambio.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objTipoCambio.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objTipoCambio.Compra = Convert.ToDecimal(txtCompra.EditValue);
                    objTipoCambio.Venta = Convert.ToDecimal(txtVenta.EditValue);
                    objTipoCambio.CompraSunat = Convert.ToDecimal(txtCompraSunat.EditValue);
                    objTipoCambio.VentaSunat = Convert.ToDecimal(txtVentaSunat.EditValue);
                    objTipoCambio.FlagEstado = true;
                    objTipoCambio.Usuario = Parametros.strUsuarioLogin;
                    objTipoCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTipoCambio.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        TipoCambioBE objE_TipoCambio = null;
                        objE_TipoCambio = new TipoCambioBL().BuscarFecha(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                        if (objE_TipoCambio == null)
                        {
                            objBL_TipoCambio.Inserta(objTipoCambio);
                        }
                        else
                        {
                            XtraMessageBox.Show("La fecha ya existe!!!. Buscar la fecha y modificarla.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else ///if(pOperacion == Operacion.Modificar)
                    {
                        objBL_TipoCambio.Actualiza(objTipoCambio);
                    }

                        this.Close();
                   
                }
            }
            catch (Exception ex)
            {
              //  Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtCompra.Text.Trim().ToString() == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el tipo de cambio compra.\n";
                flag = true;
            }

            if (txtVenta.Text.Trim().ToString() == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el tipo de cambio venta.\n";
                flag = true;
            }

            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstTipoCambio.Where(oB => oB.Fecha.ToShortDateString() == Convert.ToDateTime(deFecha.EditValue).ToShortDateString()).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- El fecha de tipo de cambio ya existe.\n";
            //        flag = true;
            //    }
            //}

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