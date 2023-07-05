using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstadoCuentaNumeroDiasBL
    {
        public List<ReporteEstadoCuentaNumeroDiasBE> Listado(int IdEmpresa, int NumeroDias, int IdTipoCliente, int IdClasificacionCliente, int IdMotivo, DateTime fecha)
        {
            try
            {
                ReporteEstadoCuentaNumeroDiasDL EstadoCuentaNumeroDias = new ReporteEstadoCuentaNumeroDiasDL();
                return EstadoCuentaNumeroDias.Listado(IdEmpresa, NumeroDias, IdTipoCliente, IdClasificacionCliente, IdMotivo, fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
