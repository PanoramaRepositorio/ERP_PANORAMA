using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoContadoBL
    {
        public List<ReportePedidoContadoBE> Listado(int Periodo, int IdPedido, int IdTienda)
        {
            try
            {
                ReportePedidoContadoDL reporte = new ReportePedidoContadoDL();
                return reporte.Listado(Periodo, IdPedido, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoContadoBE> ListadoChequeo(int Periodo, int IdPedido)
        {
            try
            {
                ReportePedidoContadoDL reporte = new ReportePedidoContadoDL();
                return reporte.ListadoChequeo(Periodo, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoContadoBE> ListadoChequeoProducto(int Periodo, int IdPedido)
        {
            try
            {
                ReportePedidoContadoDL reporte = new ReportePedidoContadoDL();
                return reporte.ListadoChequeoProducto(Periodo, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
