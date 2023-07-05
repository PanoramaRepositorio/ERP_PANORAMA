using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoAlmacenTransferenciaBL
    {
        public List<ReporteMovimientoAlmacenTransferenciaBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdAlmacenOrigen, int IdAlmacenDestino, bool FlagRecibido, int IdMotivo, int TipoReporte)
        {
            try
            {
                ReporteMovimientoAlmacenTransferenciaDL MovimientoAlmacen = new ReporteMovimientoAlmacenTransferenciaDL();
                return MovimientoAlmacen.Listado(IdEmpresa, FechaDesde, FechaHasta, IdAlmacenOrigen, IdAlmacenDestino, FlagRecibido, IdMotivo, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoAlmacenTransferenciaBE> ListadoResumen(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdAlmacenOrigen, int IdAlmacenDestino, bool FlagRecibido, int IdMotivo, int TipoReporte)
        {
            try
            {
                ReporteMovimientoAlmacenTransferenciaDL MovimientoAlmacen = new ReporteMovimientoAlmacenTransferenciaDL();
                return MovimientoAlmacen.ListadoResumen(IdEmpresa, FechaDesde, FechaHasta, IdAlmacenOrigen, IdAlmacenDestino, FlagRecibido, IdMotivo, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
