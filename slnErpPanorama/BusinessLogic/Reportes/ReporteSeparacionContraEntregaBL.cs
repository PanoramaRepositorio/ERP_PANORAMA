using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteSeparacionContraEntregaBL
    {
        public List<ReporteSeparacionContraEntregaBE> Listado(int IdEmpresa, int Periodo, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSeparacionContraEntregaDL SeparacionNumeroDias = new ReporteSeparacionContraEntregaDL();
                return SeparacionNumeroDias.Listado(IdEmpresa, Periodo, IdMotivo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
