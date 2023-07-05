using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTasaConversionBL
    {
        public List<ReporteTasaConversionBE> Listado(DateTime FechaDesde, DateTime FechaHasta ,int IdEmpresa)
        {
            try
            {
                ReporteTasaConversionDL reporte = new ReporteTasaConversionDL();
                return reporte.Listado(FechaDesde, FechaHasta, IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
