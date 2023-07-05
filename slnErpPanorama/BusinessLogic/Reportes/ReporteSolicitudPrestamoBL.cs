using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteSolicitudPrestamoBL
    {
        public List<ReporteSolicitudPrestamoBE> Listado(int IdEmpresa, int IdSolicitudPrestamo)
        {
            try
            {
                ReporteSolicitudPrestamoDL SolicitudPrestamo = new ReporteSolicitudPrestamoDL();
                return SolicitudPrestamo.Listado(IdEmpresa, IdSolicitudPrestamo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteSolicitudPrestamoBE> ListadoFecha(int IdEmpresa, int IdTipoDocumento, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSolicitudPrestamoDL SolicitudPrestamo = new ReporteSolicitudPrestamoDL();
                return SolicitudPrestamo.ListadoFecha(IdEmpresa, IdTipoDocumento, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteSolicitudPrestamoBE> ListadoVencido(int IdEmpresa, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSolicitudPrestamoDL SolicitudPrestamo = new ReporteSolicitudPrestamoDL();
                return SolicitudPrestamo.ListadoVencido(IdEmpresa, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteSolicitudPrestamoBE> ListadoVencidoResumen(int IdEmpresa, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteSolicitudPrestamoDL SolicitudPrestamo = new ReporteSolicitudPrestamoDL();
                return SolicitudPrestamo.ListadoVencidoResumen(IdEmpresa, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
