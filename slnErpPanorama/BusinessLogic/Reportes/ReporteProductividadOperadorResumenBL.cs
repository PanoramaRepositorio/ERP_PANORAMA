using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductividadOperadorResumenBL
    {
        public List<ReporteProductividadOperadorResumenBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteProductividadOperadorResumenDL reporte = new ReporteProductividadOperadorResumenDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
