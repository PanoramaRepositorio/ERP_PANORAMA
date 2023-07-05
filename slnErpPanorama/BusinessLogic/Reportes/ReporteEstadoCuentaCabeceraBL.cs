using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstadoCuentaCabeceraBL
    {
        public List<ReporteEstadoCuentaCabeceraBE> Listado(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            try
            {
                ReporteEstadoCuentaCabeceraDL EstadoCuentaCabecera = new ReporteEstadoCuentaCabeceraDL();
                return EstadoCuentaCabecera.Listado(IdEmpresa, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
