using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDevolucionesMayoristasRutaBL
    {
        public List<ReporteDevolucionesMayoristasRutaBE> Listado(int IdRuta, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDevolucionesMayoristasRutaDL Almacen = new ReporteDevolucionesMayoristasRutaDL();
                return Almacen.Listado(IdRuta, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
