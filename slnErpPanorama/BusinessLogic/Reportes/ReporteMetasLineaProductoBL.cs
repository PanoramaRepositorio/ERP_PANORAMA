using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMetasLineaProductoBL
    {
        public List<ReporteMetasLineaProductoBE> Listado(int IdLineaProducto, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMetasLineaProductoDL MetasLineaProducto = new ReporteMetasLineaProductoDL();
                return MetasLineaProducto.Listado(IdLineaProducto, IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMetasLineaProductoBE> ListadoDiario(int IdLineaProducto, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMetasLineaProductoDL MetasLineaProducto = new ReporteMetasLineaProductoDL();
                return MetasLineaProducto.ListadoDiario(IdLineaProducto, IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
