using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstadoCuentaCuentaBancoBL
    {
        public List<ReporteEstadoCuentaCuentaBancoBE> Listado(int IdEmpresa, int IdCuentaBancoDetalle)
        {
            try
            {
                ReporteEstadoCuentaCuentaBancoDL EstadoCuentaCabecera = new ReporteEstadoCuentaCuentaBancoDL();
                return EstadoCuentaCabecera.Listado(IdEmpresa, IdCuentaBancoDetalle);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
