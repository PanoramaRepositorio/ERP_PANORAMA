using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SeparacionBL
    {
        public List<SeparacionBE> ListaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.ListaCliente(FechaDesde,FechaHasta,IdCliente,IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SeparacionBE> ListaTodosActivo(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.ListaTodosActivo(IdEmpresa, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SeparacionBE> ListaPedido(int IdEmpresa, int IdPedido, string TipoMovimiento)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.ListaPedido(IdEmpresa, IdPedido, TipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeparacionBE Selecciona(int IdEmpresa, int IdSeparacion)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.Selecciona(IdEmpresa, IdSeparacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeparacionBE SeleccionaDocumentoVenta(int IdDocumentoVenta)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.SeleccionaDocumentoVenta(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeparacionBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.SeleccionaNumeroDocumento(Periodo, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeparacionBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                return Separacion.SeleccionaMovimientoCaja(IdMovimientoCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SeparacionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SeparacionDL Separacion = new SeparacionDL();
                    Separacion.Inserta(pItem);

                    ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    if (pItem.TipoMovimiento == "C")
                        ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
                    else
                        ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SeparacionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SeparacionDL Separacion = new SeparacionDL();
                    Separacion.Actualiza(pItem);

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

        public void Elimina(SeparacionBE pItem)
        {
            try
            {
                SeparacionDL Separacion = new SeparacionDL();
                Separacion.Elimina(pItem);

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
                    SeparacionDL Separacion = new SeparacionDL();
                    Separacion.EliminaDocumento(IdEmpresa, Periodo, IdCliente, NumeroDocumento);

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
