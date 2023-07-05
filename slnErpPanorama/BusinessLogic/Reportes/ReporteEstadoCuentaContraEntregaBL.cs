using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstadoCuentaContraEntregaBL
    {
        public List<ReporteEstadoCuentaContraEntregaBE> Listado(int IdEmpresa, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEstadoCuentaContraEntregaDL EstadoCuentaNumeroDias = new ReporteEstadoCuentaContraEntregaDL();
                return EstadoCuentaNumeroDias.Listado(IdEmpresa, IdMotivo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
