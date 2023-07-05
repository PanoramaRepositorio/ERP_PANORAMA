using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorBL
    {
        public List<ReportePedidoVendedorBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdVendedor)
        {
            try
            {
                ReportePedidoVendedorDL reporte = new ReportePedidoVendedorDL();
                return reporte.Listado(FechaDesde, FechaHasta,IdVendedor);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
