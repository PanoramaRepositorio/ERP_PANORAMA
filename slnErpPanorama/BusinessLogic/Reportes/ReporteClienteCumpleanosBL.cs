using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteCumpleanosBL
    {
        public List<ReporteClienteCumpleanosBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdTipoCliente)
        {
            try
            {
                ReporteClienteCumpleanosDL ClienteCumpleanos = new ReporteClienteCumpleanosDL();
                return ClienteCumpleanos.Listado(FechaDesde, FechaHasta, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
