using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ErpPanorama.DataLogic;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteVentaDataTicketResumenBL
    {
        public DataTable Listado(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte, int TipoOperacion)
        {
            ReporteVentaDataTicketResumenDL objDL = new ReporteVentaDataTicketResumenDL();

            return objDL.Listado(IdEmpresa, IdTienda, FechaDesde, FechaHasta, TipoReporte, TipoOperacion);
        }
    }
}
