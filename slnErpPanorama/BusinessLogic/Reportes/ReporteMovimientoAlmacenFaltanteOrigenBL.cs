using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoAlmacenFaltanteOrigenBL
    {
        public List<ReporteMovimientoAlmacenFaltanteOrigenBE> ListadoFaltanteOrigen(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMovimientoAlmacenFaltanteOrigenDL MovimientoAlmacen = new ReporteMovimientoAlmacenFaltanteOrigenDL();
                return MovimientoAlmacen.ListadoFaltanteOrigen(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
