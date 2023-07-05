using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoMayoristasBL
    {
        public List<ReportePedidoMayoristasBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdRuta)
        {
            try
            {
                ReportePedidoMayoristasDL reporte = new ReportePedidoMayoristasDL();
                return reporte.Listado(FechaDesde, FechaHasta, IdRuta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
