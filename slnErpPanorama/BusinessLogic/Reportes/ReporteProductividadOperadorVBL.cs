using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductividadOperadorVBL
    {
        public List<ReporteProductividadOperadorVBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteProductividadOperadorVDL reporte = new ReporteProductividadOperadorVDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
