using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmMovimientoCajaVuelto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propieadades"

        public int IdEmpresa { get; set; }
        public int IdMovimientoCaja { get; set; }
        private int? IdPedido = null;
        public string NumeroFactura = "";
        #endregion

        #region "Eventos"
        public frmMovimientoCajaVuelto()
        {
            InitializeComponent();
        }

        private void frmMovimientoCajaVuelto_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboCaja.EditValue = Parametros.intCajaId;

        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
            //MovimientoCajaBL objBL_Documento = new MovimientoCajaBL();

            //PagosBL objBL_Pagos = new PagosBL();

            ////Datos del Recibo de Pago
            //PagosBE objPago = new PagosBE();
            //objPago.IdPago = 0;
            //objPago.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
            //objPago.IdCaja = Convert.ToInt32(cboCaja.EditValue);
            //objPago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            //objPago.IdTipoDocumento = Parametros.intTipoDocIngresoCaja;
            //objPago.NumeroDocumento = "VUELTO";
            //objPago.IdCondicionPago = Parametros.intEfectivo;
            //objPago.Concepto = "Vuelto Fact. N°" + NumeroFactura;
            //objPago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
            //objPago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            //objPago.ImporteSoles = Convert.ToDecimal(txtImporteSoles.EditValue);// 0;
            //objPago.ImporteDolares = Convert.ToDecimal(txtImporteDolares.EditValue);//0;
            //objPago.FlagEstado = true;
            //objPago.Usuario = Parametros.strUsuarioLogin;
            //objPago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //objPago.IdEmpresa = Parametros.intEmpresaId;

            ////Datos del Movimiento de Caja
            //List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

            //MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
            //objMovimientoCaja.IdMovimientoCaja = 0;
            //objMovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
            //objMovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
            //objMovimientoCaja.IdTipoDocumento = Parametros.intTipoDocIngresoCaja;
            //objMovimientoCaja.NumeroDocumento = "VUELTO";
            //objMovimientoCaja.IdFormaPago = Parametros.intContado;
            //objMovimientoCaja.IdCondicionPago = Parametros.intEfectivo;
            //objMovimientoCaja.Concepto = "Vuelto Fact. N°" + NumeroFactura;
            //objMovimientoCaja.TipoMovimiento = "S";
            //objMovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
            //objMovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
            //objMovimientoCaja.ImporteSoles = 0;//Convert.ToDecimal(txtImporteSoles.EditValue);
            //objMovimientoCaja.ImporteDolares = 0;// Convert.ToDecimal(txtImporteDolares.EditValue);
            //objMovimientoCaja.IdPersona = 0;
            //objMovimientoCaja.FlagEstado = true;
            //objMovimientoCaja.Usuario = Parametros.strUsuarioLogin;
            //objMovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //objMovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
            //lstMovimientoCaja.Add(objMovimientoCaja);

            //objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
            //objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            //objBL_Documento.ActualizaCliente(objE_Cambio.IdCambio, objE_Cambio.IdCliente, objE_Cambio.NumeroCliente, objE_Cambio.DescCliente);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion

        #region "Metodos"

        #endregion

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
            
        }
    }
}