using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoPreventaVendedorBL
    {
        public List<ReportePedidoPreVentaVendedorBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoPreventaVendedorDL reporte = new ReportePedidoPreventaVendedorDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
