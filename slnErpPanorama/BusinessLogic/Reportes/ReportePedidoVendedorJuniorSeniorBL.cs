using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorJuniorSeniorBL
    {
        public List<ReportePedidoVendedorJuniorSeniorBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReportePedidoVendedorJuniorSeniorDL reporte = new ReportePedidoVendedorJuniorSeniorDL();
                return reporte.Listado(IdVendedor, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
