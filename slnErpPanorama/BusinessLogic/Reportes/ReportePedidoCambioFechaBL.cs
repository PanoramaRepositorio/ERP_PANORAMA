using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoCambioFechaBL
    {
        public List<ReportePedidoCambioFechaBE> Listado(DateTime FechaDesde, DateTime FechaHasta, Int32 TipoReporte)
        {
            try
            {
                ReportePedidoCambioFechaDL PedidoCambioFecha = new ReportePedidoCambioFechaDL();
                return PedidoCambioFecha.Listado(FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
