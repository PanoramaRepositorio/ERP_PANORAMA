using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorFormaPagoBL
    {
        public List<ReportePedidoVendedorFormaPagoBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorFormaPagoDL reporte = new ReportePedidoVendedorFormaPagoDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
