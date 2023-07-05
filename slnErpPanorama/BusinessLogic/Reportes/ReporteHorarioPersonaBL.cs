using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteHorarioPersonaBL
    {
        public List<ReporteHorarioPersonaBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            try
            {
                ReporteHorarioPersonaDL HorarioPersona = new ReporteHorarioPersonaDL();
                return HorarioPersona.Listado(FechaDesde, FechaHasta, IdPersona, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
