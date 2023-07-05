using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCentroCostoPorAreaBL
    {
        public List<ReporteCentroCostoPorAreaBE> Listado(int Periodo, int Mes, int TipoReporte)
        {
            try
            {
                ReporteCentroCostoPorAreaDL reporte = new ReporteCentroCostoPorAreaDL();
                return reporte.Listado(Periodo, Mes, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
