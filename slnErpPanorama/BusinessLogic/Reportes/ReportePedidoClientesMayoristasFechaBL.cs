using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoClientesMayoristasFechaBL
    {
        public List<ReportePedidoClientesMayoristasFechaBE> ListaPedidoClientesMayoristasFecha(DateTime FechaDesde, DateTime FechaHasta, int IdRuta, int IdTipoCliente)
        {
            try
            {
                ReportePedidoClientesMayoristasFechaDL reporte = new ReportePedidoClientesMayoristasFechaDL();
                return reporte.ListaPedidoClientesMayoristasFecha(FechaDesde, FechaHasta, IdRuta, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
