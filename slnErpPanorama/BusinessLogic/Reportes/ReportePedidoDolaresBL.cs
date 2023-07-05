using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoDolaresBL
    {
        public List<ReportePedidoDolaresBE> Listado(int Periodo, int IdPedido)
        {
            try
            {
                ReportePedidoDolaresDL reporte = new ReportePedidoDolaresDL();
                return reporte.Listado(Periodo, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
