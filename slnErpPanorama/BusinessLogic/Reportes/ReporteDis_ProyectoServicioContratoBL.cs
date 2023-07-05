using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDis_ProyectoServicioContratoBL
    {
        public List<ReporteDis_ProyectoServicioContratoBE> Listados(int IdDis_ProyectoServicio, int IdMotivo)
        {
            try
            {
                ReporteDis_ProyectoServicioContratoDL reporte = new ReporteDis_ProyectoServicioContratoDL();
                return reporte.Listado(IdDis_ProyectoServicio, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteDis_ProyectoServicioContratoBE> Listado(int IdDis_ProyectoServicio, int IdDis_ContratoAsesoria)
        {
            try
            {
                ReporteDis_ProyectoServicioContratoDL reporte = new ReporteDis_ProyectoServicioContratoDL();
                return reporte.ListadoContrato(IdDis_ProyectoServicio, IdDis_ContratoAsesoria);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
