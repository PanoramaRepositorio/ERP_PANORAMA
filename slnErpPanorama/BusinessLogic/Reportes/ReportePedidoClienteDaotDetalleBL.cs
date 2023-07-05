using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoClienteDaotDetalleBL
    {
        public List<ReportePedidoClienteDaotDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdEmpresa, int IdCliente, string IdTipoDocumento, string Operador, decimal Valor)
        {
            try
            {
                ReportePedidoClienteDaotDetalleDL reporte = new ReportePedidoClienteDaotDetalleDL();
                return reporte.Listado(FechaDesde, FechaHasta, IdEmpresa, IdCliente, IdTipoDocumento, Operador, Valor);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
