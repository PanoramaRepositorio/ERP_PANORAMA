using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCambioBL
    {
        public List<ReporteCambioBE> Listado(int IdCambio)
        {
            try
            {
                ReporteCambioDL Cambio = new ReporteCambioDL();
                return Cambio.Listado(IdCambio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCambioBE> ConsolidadoListado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCambioDL Cambio = new ReporteCambioDL();
                return Cambio.ConsolidadoListado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
