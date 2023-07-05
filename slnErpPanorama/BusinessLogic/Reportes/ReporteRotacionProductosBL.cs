using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteRotacionProductosBL
    {
        public List<ReporteRotacionProductosBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReporteRotacionProductosDL reporte = new ReporteRotacionProductosDL();
                return reporte.Listado(IdEmpresa, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteRotacionProductosBE> ListadoPorTienda(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReporteRotacionProductosDL reporte = new ReporteRotacionProductosDL();
                return reporte.ListadoPorTienda(IdEmpresa, IdTienda, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
