using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_ProyectoServicioBL
    {
        public List<ReporteDis_ProyectoServicioBE> Listado(int Periodo, int IdDis_ProyectoServicio)
        {
            try
            {
                ReporteDis_ProyectoServicioDL ProyectoServicio = new ReporteDis_ProyectoServicioDL();
                return ProyectoServicio.Listado(Periodo, IdDis_ProyectoServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
