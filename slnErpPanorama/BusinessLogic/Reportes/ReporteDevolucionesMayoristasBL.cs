using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDevolucionesMayoristasBL
    {
        public List<ReporteDevolucionesMayoristasBE> Listado(int IdCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteDevolucionesMayoristasDL Almacen = new ReporteDevolucionesMayoristasDL();
                return Almacen.Listado(IdCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
