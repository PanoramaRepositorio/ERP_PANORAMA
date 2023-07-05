using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstadoCuentaClienteDetBL
    {
        public List<ReporteEstadoCuentaClienteDetBE> Listado(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
        {
            try
            {
                ReporteEstadoCuentaClienteDetDL reporte = new ReporteEstadoCuentaClienteDetDL();
                return reporte.Listado(IdEmpresa, IdCliente, TipoMovimiento, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
