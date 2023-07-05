using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstadoCuentaDetalleBL
    {
        public List<ReporteEstadoCuentaDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            try
            {
                ReporteEstadoCuentaDetalleDL EstadoCuentaDetalle = new ReporteEstadoCuentaDetalleDL();
                return EstadoCuentaDetalle.Listado(FechaDesde, FechaHasta, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
