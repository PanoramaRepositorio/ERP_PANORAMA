using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVentaTiendaTipoClientePorCargoBL
    {
        public List<ReportePedidoVentaTiendaTipoClientePorCargoBE> Listado(Int32 IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVentaTiendaTipoClientePorCargoDL PedidoVentaTiendaTipoClientePorCargo = new ReportePedidoVentaTiendaTipoClientePorCargoDL();
                return PedidoVentaTiendaTipoClientePorCargo.Listado(IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
