using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorAsesoriaBL
    {
        public List<ReportePedidoVendedorAsesoriaBE> Listado(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorAsesoriaDL reporte = new ReportePedidoVendedorAsesoriaDL();
                return reporte.Listado(IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
