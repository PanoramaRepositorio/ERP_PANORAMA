using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCotizacionBL
    {
        public List<ReporteCotizacionBE> Listado(int IdEmpresa, int IdCotizacion)
        {
            try
            {
                ReporteCotizacionDL Cotizacion = new ReporteCotizacionDL();
                return Cotizacion.Listado(IdEmpresa, IdCotizacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
