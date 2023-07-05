using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteRutaBL
    {
        public List<ReporteRutaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteRutaDL ruta = new ReporteRutaDL();
                return ruta.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
