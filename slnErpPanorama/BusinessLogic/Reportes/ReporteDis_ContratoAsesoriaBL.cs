using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_ContratoAsesoriaBL
    {
        public List<ReporteDis_ContratoAsesoriaBE> Listado(int IdDis_ContratoAsesoria)
        {
            try
            {
                ReporteDis_ContratoAsesoriaDL Cotizacion = new ReporteDis_ContratoAsesoriaDL();
                return Cotizacion.Listado(IdDis_ContratoAsesoria);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
