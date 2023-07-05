using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;
using ErpPanorama.DataLogic.Reporte;

namespace ErpPanorama.BusinessLogic.Reportes
{
    public class ReporteSolicitudProductoDetalleBL
    {
        public List<ReporteSolicitudProductoDetalleBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSolicitudProductoDetalleDL SolicitudProductoDetalle = new ReporteSolicitudProductoDetalleDL();
                return SolicitudProductoDetalle.Listado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
