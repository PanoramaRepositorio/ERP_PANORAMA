using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoCreditoBL
    {
        public List<ReportePedidoCreditoBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoCreditoDL ReportePedidoCredito = new ReportePedidoCreditoDL();
                return ReportePedidoCredito.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
