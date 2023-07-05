using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteVentaProductoBL
    {
        public List<ReporteVentaProductoBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdTienda, int IdLineaProducto, int IdTipoCliente)
        {
            try
            {
                ReporteVentaProductoDL reporte = new ReporteVentaProductoDL();
                return reporte.Listado(FechaDesde, FechaHasta, IdTienda, IdLineaProducto, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteVentaProductoBE> ListadoResumen(DateTime FechaDesde, DateTime FechaHasta, int IdTienda, int IdLineaProducto, int IdTipoCliente)
        {
            try
            {
                ReporteVentaProductoDL reporte = new ReporteVentaProductoDL();
                return reporte.ListadoResumen(FechaDesde, FechaHasta, IdTienda, IdLineaProducto, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteVentaProductoBE> ListadoRentabilidad(DateTime FechaDesde, DateTime FechaHasta, int IdTienda, int IdLineaProducto, int IdTipoCliente)
        {
            try
            {
                ReporteVentaProductoDL reporte = new ReporteVentaProductoDL();
                return reporte.ListadoRentabilidad(FechaDesde, FechaHasta, IdTienda, IdLineaProducto, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public List<ReporteVentaProductoBE> ListadoDias(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int DiasVendidos, int IdLineaProducto, string IdProducto)
        {
            try
            {
                ReporteVentaProductoDL reporte = new ReporteVentaProductoDL();
                return reporte.ListadoDias(IdEmpresa,FechaDesde, FechaHasta, DiasVendidos, IdLineaProducto, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteVentaProductoBE> ListadoDiasResumen(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int DiasVendidos, int IdLineaProducto, int IdFamiliaProducto)
        {
            try
            {
                ReporteVentaProductoDL reporte = new ReporteVentaProductoDL();
                return reporte.ListadoDiasResumen(IdEmpresa, FechaDesde, FechaHasta, DiasVendidos, IdLineaProducto, IdFamiliaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
