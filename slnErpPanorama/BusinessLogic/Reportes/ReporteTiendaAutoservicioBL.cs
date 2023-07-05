using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTiendaAutoservicioBL
    {
        public List<ReporteTiendaAutoservicioBE> Listado(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteTiendaAutoservicioDL reporte = new ReporteTiendaAutoservicioDL();
                return reporte.Listado(IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteTiendaAutoservicioBE> ListadoCodigoProveedor(int IdTienda,int IdFamiliaProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteTiendaAutoservicioDL reporte = new ReporteTiendaAutoservicioDL();
                return reporte.ListadoCodigoProveedor(IdTienda, IdFamiliaProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
