using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoFacturaBL
    {
        public List<ReporteProductoCatalogoFacturaBE> Listado(int IdEmpresa, int IdFactura, int IdTipoCliente)
        {
            try
            {
                ReporteProductoCatalogoFacturaDL ProductoCatalogoFactura = new ReporteProductoCatalogoFacturaDL();
                return ProductoCatalogoFactura.Listado(IdEmpresa, IdFactura, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProductoCatalogoFacturaBE> ListadoSolicitudCompra(int IdEmpresa, int IdSolicitudCompra, int IdTipoCliente)
        {
            try
            {
                ReporteProductoCatalogoFacturaDL ProductoCatalogoFactura = new ReporteProductoCatalogoFacturaDL();
                return ProductoCatalogoFactura.ListadoSolicitudCompra(IdEmpresa, IdSolicitudCompra, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
