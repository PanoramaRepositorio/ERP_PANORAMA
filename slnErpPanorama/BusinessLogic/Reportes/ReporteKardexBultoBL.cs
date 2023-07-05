using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteKardexBultoBL
    {
        public List<ReporteKardexBultoBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteKardexBultoDL kardexbulto = new ReporteKardexBultoDL();
                return kardexbulto.Listado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReporteKardexBultoBE> KardexBulto_Listado(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto, int IdMaterial)
        {
            try
            {
                ReporteKardexBultoDL kardexbultoLista = new ReporteKardexBultoDL();
                return kardexbultoLista.KardexBulto_Listado(IdEmpresa, IdLineaProducto, IdSubLineaProducto, IdModeloProducto, IdMaterial);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
