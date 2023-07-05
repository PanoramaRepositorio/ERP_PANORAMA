using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoAlmacenChequeoBL
    {
        public List<ReporteMovimientoAlmacenChequeoBE> Listado(int Periodo, string Numero, int IdTipoMovimiento)
        {
            try
            {
                ReporteMovimientoAlmacenChequeoDL MovimientoAlmacen = new ReporteMovimientoAlmacenChequeoDL();
                return MovimientoAlmacen.Listado(Periodo, Numero, IdTipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
