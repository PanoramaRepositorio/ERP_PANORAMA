using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoSolesBL
    {
        public List<ReportePedidoSolesBE> Listado(int Periodo, int IdPedido)
        {
            try
            {
                ReportePedidoSolesDL reporte = new ReportePedidoSolesDL();
                return reporte.Listado(Periodo, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
