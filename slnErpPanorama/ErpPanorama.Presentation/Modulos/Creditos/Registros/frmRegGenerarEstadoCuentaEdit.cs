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

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegGenerarEstadoCuentaEdit : DevExpress.XtraEditors.XtraForm
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

        public frmRegGenerarEstadoCuentaEdit()
        {
            InitializeComponent();
        }

        private void frmRegGenerarEstadoCuentaEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            PedidoBE objE_Pedido = null;
            objE_Pedido = new PedidoBL().Selecciona(IdPedido);
            if (objE_Pedido != null)
            {
                if (objE_Pedido.IdFormaPago == Parametros.intCredito || objE_Pedido.IdFormaPago == Parametros.intContraEntrega)
                {
                    if (objE_Pedido.IdSituacion == Parametros.intPVDespachado)
                    {
                        EstadoCuentaBE objCuenta = new EstadoCuentaBE();
                        objCuenta = new EstadoCuentaBL().SeleccionaNumeroDocumento(objE_Pedido.Periodo, objE_Pedido.Numero);
                        if (objCuenta == null)
                        {
                            EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();
                            EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();

                            int NumDias = 0;

                            ClienteCreditoBE objClienteCredito = null;
                            objClienteCredito = new ClienteCreditoBL().SeleccionaCliente(objE_Pedido.IdEmpresa, objE_Pedido.IdCliente,Convert.ToInt32(cboMotivo.EditValue));
                            if (objClienteCredito != null)
                            {
                                NumDias = objClienteCredito.NumeroDias;
                            }

                            objE_EstadoCuenta.IdEstadoCuenta = 0;
                            objE_EstadoCuenta.IdEmpresa = objE_Pedido.IdEmpresa;
                            objE_EstadoCuenta.Periodo = objE_Pedido.Periodo;
                            objE_EstadoCuenta.IdCliente = objE_Pedido.IdCliente;
                            objE_EstadoCuenta.NumeroDocumento = objE_Pedido.Numero;
                            objE_EstadoCuenta.FechaCredito = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                            objE_EstadoCuenta.FechaDeposito = null;
                            objE_EstadoCuenta.Concepto = "CREDITO PEDIDO";
                            objE_EstadoCuenta.FechaVencimiento = deFecha.DateTime.AddDays(NumDias);
                            objE_EstadoCuenta.Importe = objE_Pedido.Total;
                            objE_EstadoCuenta.ImporteAnt = objE_Pedido.Total;
                            objE_EstadoCuenta.TipoMovimiento = "C";
                            objE_EstadoCuenta.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                            objE_EstadoCuenta.Observacion = "";
                            objE_EstadoCuenta.FlagEstado = true;
                            objE_EstadoCuenta.Usuario = Parametros.strUsuarioLogin;
                            objE_EstadoCuenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                            XtraMessageBox.Show("El estado de cuenta se ha generado correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("El número de pedido ya existe en el estado de cuenta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        
                    }
                    else
                    {
                        XtraMessageBox.Show("El Pedido de Venta no esta despachado...por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Para aprobar un Pedido de Venta tienque ser credito o contraentrega...por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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