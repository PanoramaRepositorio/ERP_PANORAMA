using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_DisenoFuncionalBL
    {
        public List<ReporteDis_DisenoFuncionalBE> Listado( int IdDis_ProyectoServicio)
        {
            try
            {
                ReporteDis_DisenoFuncionalDL DisenoFuncional = new ReporteDis_DisenoFuncionalDL();
                return DisenoFuncional.Listado(IdDis_ProyectoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
