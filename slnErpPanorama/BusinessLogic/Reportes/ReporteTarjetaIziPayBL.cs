using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTarjetaIziPayBL
    {
        public List<ReporteTarjetaIziPayBE> Listado(int IdTienda, int IdCaja, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteTarjetaIziPayDL reporte = new ReporteTarjetaIziPayDL();
                return reporte.Listado(IdTienda, IdCaja, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
