using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoPreventaBL
    {
        public List<ReportePedidoPreventaBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoPreventaDL reporte = new ReportePedidoPreventaDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoPreventaBE> ListadoPedidoCodigo(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoPreventaDL reporte = new ReportePedidoPreventaDL();
                return reporte.ListadoPedidoCodigo(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
