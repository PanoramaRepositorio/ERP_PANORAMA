using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoPedidoBL
    {
        public List<ReporteMovimientoPedidoBE> Listado(int IdPedido)
        {
            try
            {
                ReporteMovimientoPedidoDL MovimientoPedido = new ReporteMovimientoPedidoDL();
                return MovimientoPedido.Listado(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
