using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoClienteLineaBL
    {
        public List<ReportePedidoClienteLineaBE> Listado(int Periodo, int IdCliente)
        {
            try
            {
                ReportePedidoClienteLineaDL reporte = new ReportePedidoClienteLineaDL();
                return reporte.Listado(Periodo, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReportePedidoClienteLineaBE> ListadoModelo(int Periodo, int IdCliente, int IdLineaProducto)
        {
            try
            {
                ReportePedidoClienteLineaDL reporte = new ReportePedidoClienteLineaDL();
                return reporte.ListadoModelo(Periodo, IdCliente, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
