using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_ContratoFabricacionBL
    {
        public List<ReporteDis_ContratoFabricacionBE> Listado(int IdDis_ContratoFabricacion)
        {
            try
            {
                ReporteDis_ContratoFabricacionDL Dis_ContratoFabricacion = new ReporteDis_ContratoFabricacionDL();
                return Dis_ContratoFabricacion.Listado(IdDis_ContratoFabricacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
