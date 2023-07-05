using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EstadoCuentaBL
    {
        public List<EstadoCuentaBE> ListaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.ListaCliente(FechaDesde, FechaHasta, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaBE> ListaClienteResumen(DateTime FechaDesde, DateTime FechaHasta, int IdEmpresa, int IdTipoCliente, int IdCliente, int IdMotivo)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.ListaClienteResumen(FechaDesde, FechaHasta, IdEmpresa, IdTipoCliente, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaBE> ListaTodosActivo(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.ListaTodosActivo(IdEmpresa,IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaBE> ListaPedido(int IdEmpresa, int IdPedido, string TipoMovimiento)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.ListaPedido(IdEmpresa, IdPedido, TipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaBE Selecciona(int IdEmpresa, int IdEstadoCuenta)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.Selecciona(IdEmpresa, IdEstadoCuenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.SeleccionaNumeroDocumento(Periodo, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.SeleccionaMovimientoCaja(IdMovimientoCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaBE SeleccionaDocumentoVenta(int IdEmpresa, int? IdDocumentoVenta)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                return EstadoCuenta.SeleccionaDocumentoVenta(IdEmpresa, IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EstadoCuentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                    EstadoCuenta.Inserta(pItem);

                    ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    if (pItem.TipoMovimiento == "C")
                        ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0,pItem.IdMotivo);
                    else
                        ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EstadoCuentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                    EstadoCuenta.Actualiza(pItem);

                    ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    if (pItem.TipoMovimiento == "C")
                        ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, pItem.ImporteAnt, pItem.IdMotivo);
                    else
                        ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.ImporteAnt, pItem.Importe, pItem.IdMotivo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EstadoCuentaBE pItem)
        {
            try
            {
                EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                EstadoCuenta.Elimina(pItem);

                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                if (pItem.TipoMovimiento == "C")
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);
                else
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaDocumento(int IdEmpresa, int Periodo, int IdCliente, string NumeroDocumento, string TipoMovimiento, decimal Importe, int IdMotivo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                    EstadoCuenta.EliminaDocumento(IdEmpresa, Periodo, IdCliente, NumeroDocumento);

                    ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    if (TipoMovimiento == "C")
                        ClienteCredito.ActualizaLineaCreditoUtilizada(IdEmpresa, IdCliente, 0, Importe, IdMotivo);
                    else
                        ClienteCredito.ActualizaLineaCreditoUtilizada(IdEmpresa, IdCliente, Importe, 0, IdMotivo);

                    ts.Complete();
                }


            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
