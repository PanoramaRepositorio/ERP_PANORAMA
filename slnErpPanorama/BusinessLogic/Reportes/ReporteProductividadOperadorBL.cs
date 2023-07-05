using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductividadOperadorBL
    {
        public List<ReporteProductividadOperadorBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteProductividadOperadorDL reporte = new ReporteProductividadOperadorDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
