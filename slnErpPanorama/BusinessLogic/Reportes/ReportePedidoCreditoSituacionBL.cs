using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoCreditoSituacionBL
    {
        public List<ReportePedidoCreditoSituacionBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion)
        {
            try
            {
                ReportePedidoCreditoSituacionDL reporte = new ReportePedidoCreditoSituacionDL();
                return reporte.Listado(FechaDesde, FechaHasta, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
