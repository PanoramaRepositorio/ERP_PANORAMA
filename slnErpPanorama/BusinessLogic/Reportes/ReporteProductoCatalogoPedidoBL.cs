using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoPedidoBL
    {
        public List<ReporteProductoCatalogoPedidoBE> Listado(int IdEmpresa, int IdPedido)
        {
            try
            {
                ReporteProductoCatalogoPedidoDL ProductoCatalogoPedido = new ReporteProductoCatalogoPedidoDL();
                return ProductoCatalogoPedido.Listado(IdEmpresa,IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
