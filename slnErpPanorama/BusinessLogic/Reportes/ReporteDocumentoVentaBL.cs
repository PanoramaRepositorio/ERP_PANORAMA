using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDocumentoVentaBL
    {
        public List<ReporteDocumentoVentaBE> Listado(int Periodo, int IdPedido)
        {
            try
            {
                ReporteDocumentoVentaDL ReporteDocumentoVenta = new ReporteDocumentoVentaDL();
                return ReporteDocumentoVenta.Listado(Periodo, IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaBE> ListaPedidoDocumento(int Periodo, int IdPedido, int IdTipoDocumento)
        {
            try
            {
                ReporteDocumentoVentaDL ReporteDocumentoVenta = new ReporteDocumentoVentaDL();
                return ReporteDocumentoVenta.ListaPedidoDocumento(Periodo, IdPedido, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaBE> ListaCodigo(int IdDocumentoVenta)
        {
            try
            {
                ReporteDocumentoVentaDL ReporteDocumentoVenta = new ReporteDocumentoVentaDL();
                return ReporteDocumentoVenta.ListaCodigo(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaBE> ListadoDocumento(int IdDocumentoVenta)
        {
            try
            {
                ReporteDocumentoVentaDL ReporteDocumentoVenta = new ReporteDocumentoVentaDL();
                return ReporteDocumentoVenta.ListadoDocumento(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaBE> ListaCliente(int IdEmpresa, int IdCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDocumentoVentaDL ReporteDocumentoVenta = new ReporteDocumentoVentaDL();
                return ReporteDocumentoVenta.ListaCliente(IdEmpresa, IdCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaBE> ListaGuiaCliente(int IdEmpresa, int IdCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDocumentoVentaDL ReporteDocumentoVenta = new ReporteDocumentoVentaDL();
                return ReporteDocumentoVenta.ListaGuiaCliente(IdEmpresa, IdCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
