using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoAlmacenBL
    {
        public List<ReporteMovimientoAlmacenBE> Listado(int IdEmpresa, int IdMovimientoAlmacen)
        {
            try
            {
                ReporteMovimientoAlmacenDL MovimientoAlmacen = new ReporteMovimientoAlmacenDL();
                return MovimientoAlmacen.Listado(IdEmpresa, IdMovimientoAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }


       
    }
}