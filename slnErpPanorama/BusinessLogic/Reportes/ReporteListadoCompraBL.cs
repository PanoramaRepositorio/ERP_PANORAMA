using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteListadoCompraBL
    {
        public List<ReporteListadoCompraBE> Listado(int IdEmpresa, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteListadoCompraDL ListaCompra = new ReporteListadoCompraDL();
                return ListaCompra.Listado(IdEmpresa, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
