using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_ProyectoServicioContratoFabricacionBL
    {
        public List<ReporteDis_ProyectoServicioContratoFabricacionBE> Listado(int IdDis_ContratoFabricacion, int TipoReporte)
        {
            try
            {
                ReporteDis_ProyectoServicioContratoFabricacionDL reporte = new ReporteDis_ProyectoServicioContratoFabricacionDL();
                return reporte.Listado(IdDis_ContratoFabricacion, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
