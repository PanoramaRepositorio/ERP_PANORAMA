using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteRegistroVendedorDetalleBL
    {
        public List<ReporteClienteRegistroVendedorDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteClienteRegistroVendedorDetalleDL ClienteRegistroVendedorDetalle = new ReporteClienteRegistroVendedorDetalleDL();
                return ClienteRegistroVendedorDetalle.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
