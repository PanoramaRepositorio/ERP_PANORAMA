using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteRegistroVendedorBL
    {
        public List<ReporteClienteRegistroVendedorBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteClienteRegistroVendedorDL reporte = new ReporteClienteRegistroVendedorDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
