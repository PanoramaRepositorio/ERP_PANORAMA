using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoAlmacenMermasBL
    {
        public List<ReporteMovimientoAlmacenMermasBE> ListadoMermas(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMovimientoAlmacenMermasDL MovimientoAlmacen = new ReporteMovimientoAlmacenMermasDL();
                return MovimientoAlmacen.ListadoMermas(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
