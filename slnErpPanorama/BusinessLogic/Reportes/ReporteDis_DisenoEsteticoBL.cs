using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_DisenoEsteticoBL
    {
        public List<ReporteDis_DisenoEsteticoBE> Listado(int IdDis_ProyectoServicio)
        {
            try
            {
                ReporteDis_DisenoEsteticoDL DisenoEstetico = new ReporteDis_DisenoEsteticoDL();
                return DisenoEstetico.Listado(IdDis_ProyectoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
