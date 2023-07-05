using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class EstadoCuentaComisionBL
	{
        public List<EstadoCuentaComisionBE> ListaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                return EstadoCuentaComision.ListaCliente(FechaDesde, FechaHasta, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaComisionBE> ListaTodosActivo(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                return EstadoCuentaComision.ListaTodosActivo(IdEmpresa, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaComisionBE> ListaPedido(int IdEmpresa, int IdPedido)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                return EstadoCuentaComision.ListaPedido(IdEmpresa, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaComisionBE Selecciona(int IdEmpresa, int IdEstadoCuentaComision)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                return EstadoCuentaComision.Selecciona(IdEmpresa, IdEstadoCuentaComision);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaComisionBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                return EstadoCuentaComision.SeleccionaNumeroDocumento(Periodo, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaComisionBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                return EstadoCuentaComision.SeleccionaMovimientoCaja(IdMovimientoCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EstadoCuentaComisionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                    EstadoCuentaComision.Inserta(pItem);

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

        public void Actualiza(EstadoCuentaComisionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                    EstadoCuentaComision.Actualiza(pItem);

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

        public void Elimina(EstadoCuentaComisionBE pItem)
        {
            try
            {
                EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                EstadoCuentaComision.Elimina(pItem);

                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                if (pItem.TipoMovimiento == "C")
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);
                else
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

	}
}
