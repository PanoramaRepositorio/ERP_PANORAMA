using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoAlmacenGuiaRemisionBL
    {
        public List<ReporteMovimientoAlmacenGuiaRemisionBE> Listado(int IdEmpresa, int IdMovimientoAlmacen)
        {
            try
            {
                ReporteMovimientoAlmacenGuiaRemisionDL MovimientoAlmacen = new ReporteMovimientoAlmacenGuiaRemisionDL();
                return MovimientoAlmacen.Listado(IdEmpresa, IdMovimientoAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
