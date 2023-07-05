using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorPisoSueldoBL
    {
        public List<ReportePedidoVendedorPisoSueldoBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReportePedidoVendedorPisoSueldoDL reporte = new ReportePedidoVendedorPisoSueldoDL();
                return reporte.Listado(IdVendedor, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
