using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteHoraExtraBL
    {
        public List<ReporteHoraExtraBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            try
            {
                ReporteHoraExtraDL HoraExtra = new ReporteHoraExtraDL();
                return HoraExtra.Listado(FechaDesde, FechaHasta, IdPersona, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReporteHoraExtraBE> ListadoResumen(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            try
            {
                ReporteHoraExtraDL HoraExtra = new ReporteHoraExtraDL();
                return HoraExtra.ListadoResumen(FechaDesde, FechaHasta, IdPersona, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
