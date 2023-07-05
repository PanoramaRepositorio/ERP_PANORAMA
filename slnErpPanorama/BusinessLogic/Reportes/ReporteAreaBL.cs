using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteAreaBL
    {
        public List<ReporteAreaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteAreaDL Area = new ReporteAreaDL();
                return Area.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
