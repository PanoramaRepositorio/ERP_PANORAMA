using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorTipoClienteBL
    {
        public List<ReportePedidoVendedorTipoClienteBE> Listado(int IdVendedor, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.Listado(IdVendedor, IdTipoCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoVendedorTipoClienteBE> ListadoDisenio(  DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoDisenio(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAvanceMeta> ListadoAvanceMeta(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoAvanceMeta(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReporteAvanceMeta> ListadoAvanceMetaCartera(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoAvanceMetaCartera(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAvanceMeta> ListadoSueldoVendPiso(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoSueldoVendPiso(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAvanceMeta> ListadoSueldoAsesorVentasVirtual(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoSueldoAsesorVentasVirtual(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAvanceMeta> ListadoSueldoDisenioInterior(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoSueldoDisenioInterior(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAvanceMeta> ListadoAvanceMetaJefeCartera(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoAvanceMetaJefeCartera(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAvanceMeta> ListadoAvanceMetaDisenio(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.ListadoAvanceMetaDisenio(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReporteSueldoAdmUcayali> SueldoAdmUcayali(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.SueldoAdmUcayali(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteSueldoAdmUcayali> SueldoSubAdm(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.SueldoSubAdm(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteSueldoAdmUcayali> SueldoJefeCampo(int IdVendedor, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorTipoClienteDL reporte = new ReportePedidoVendedorTipoClienteDL();
                return reporte.SueldoJefeCampo(IdVendedor, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
