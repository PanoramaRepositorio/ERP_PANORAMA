using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePisoBL
    {
        public List<ReportePisoBE> Listado(int IdEmpresa,int IdUbicacion)
        {
            try
            {
                ReportePisoDL Piso = new ReportePisoDL();
                return Piso.Listado(IdEmpresa,IdUbicacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
