using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteHojaInstalacionBL
    {
        public List<ReporteHojaInstalacionBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteHojaInstalacionDL HojaInstalacion = new ReporteHojaInstalacionDL();
                return HojaInstalacion.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
