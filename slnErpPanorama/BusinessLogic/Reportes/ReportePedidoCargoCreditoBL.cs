using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoCargoCreditoBL
    {
        public List<ReportePedidoCargoCreditoBE> Listado(int IdEmpresa, int IdCotizacion)
        {
            try
            {
                ReportePedidoCargoCreditoDL ProductoCreditoPedido = new ReportePedidoCargoCreditoDL();
                return ProductoCreditoPedido.Listado(IdEmpresa, IdCotizacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
