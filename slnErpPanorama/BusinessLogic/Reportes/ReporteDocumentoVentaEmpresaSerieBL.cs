using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDocumentoVentaEmpresaSerieBL
    {
        public List<ReporteDocumentoVentaEmpresaSerieBE> Listado(int IdEmpresa, int IdTipoDocumento, string Serie, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDocumentoVentaEmpresaSerieDL ReporteDocumentoVentaEmpresaSerie = new ReporteDocumentoVentaEmpresaSerieDL();
                return ReporteDocumentoVentaEmpresaSerie.Listado(IdEmpresa, IdTipoDocumento,Serie, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaEmpresaSerieBE> ListadoSerieResumen(int IdEmpresa, int IdTipoDocumento, string Serie, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDocumentoVentaEmpresaSerieDL ReporteDocumentoVentaEmpresaSerie = new ReporteDocumentoVentaEmpresaSerieDL();
                return ReporteDocumentoVentaEmpresaSerie.ListadoSerieResumen(IdEmpresa, IdTipoDocumento,Serie, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDocumentoVentaEmpresaSerieBE> ListadoTipoDocumento(int IdEmpresa, int IdTipoDocumento, string Serie, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDocumentoVentaEmpresaSerieDL ReporteDocumentoVentaEmpresaSerie = new ReporteDocumentoVentaEmpresaSerieDL();
                return ReporteDocumentoVentaEmpresaSerie.ListadoTipoDocumento(IdEmpresa, IdTipoDocumento,Serie, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
