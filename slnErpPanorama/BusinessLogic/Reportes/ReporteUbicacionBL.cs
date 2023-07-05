using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteUbicacionBL
    {
        public List<ReporteUbicacionBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteUbicacionDL Ubicacion = new ReporteUbicacionDL();
                return Ubicacion.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
