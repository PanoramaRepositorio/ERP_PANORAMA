using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ErpPanorama.DataLogic;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteVentaDataTicketBL
    {
        public DataTable Listado(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            ReporteVentaDataTicketDL objDL = new ReporteVentaDataTicketDL();

            return objDL.Listado(IdEmpresa, IdTienda, FechaDesde, FechaHasta, TipoReporte);
        }
        public DataTable ListadoVtasDiarias(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            ReporteVentaDataTicketDL objDL = new ReporteVentaDataTicketDL();

            return objDL.ListadoVtasDiarias(IdEmpresa, IdTienda, FechaDesde, FechaHasta, TipoReporte);
        }
    }
}
