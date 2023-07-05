using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteKardexAlmacenBL
    {
        public List<ReporteKardexAlmacenBE> Listado(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteKardexAlmacenDL KardexAlmacen = new ReporteKardexAlmacenDL();
                return KardexAlmacen.Listado(IdEmpresa, IdAlmacen, IdProducto, FechaDesde,FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
