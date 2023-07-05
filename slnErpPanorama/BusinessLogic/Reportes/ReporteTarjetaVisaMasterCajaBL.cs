using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTarjetaVisaMasterCajaBL
    {
        public List<ReporteTarjetaVisaMasterCajaBE> Listado(int IdTienda, int IdCaja, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteTarjetaVisaMasterCajaDL reporte = new ReporteTarjetaVisaMasterCajaDL();
                return reporte.Listado(IdTienda, IdCaja, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public List<ReporteTarjetaVisaMasterCajaBE> ListadoResumen(int IdTienda, int IdCaja, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    //try
        //    //{
        //    //    ReporteTarjetaVisaMasterCajaDL reporte = new ReporteTarjetaVisaMasterCajaDL();
        //    //    return reporte.ListadoResumen(IdTienda, IdCaja, FechaDesde, FechaHasta);
        //    //}
        //    //catch (Exception ex)
        //    //{ throw ex; }
        //}

    }
}
