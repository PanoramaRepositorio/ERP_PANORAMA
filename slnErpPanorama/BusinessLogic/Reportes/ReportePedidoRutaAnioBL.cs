using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoRutaAnioBL
    {
        public List<ReportePedidoRutaAnioBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoRutaAnioDL reporte = new ReportePedidoRutaAnioDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
