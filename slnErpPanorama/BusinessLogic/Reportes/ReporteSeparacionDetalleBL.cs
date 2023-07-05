using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteSeparacionDetalleBL
    {
        public List<ReporteSeparacionDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            try
            {
                ReporteSeparacionDetalleDL SeparacionDetalle = new ReporteSeparacionDetalleDL();
                return SeparacionDetalle.Listado(FechaDesde,FechaHasta, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
