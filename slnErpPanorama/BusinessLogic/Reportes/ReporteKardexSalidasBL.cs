using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteKardexSalidasBL
    {
        public List< ReporteKardexSalidasBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                 ReporteKardexSalidasDL kardexbulto = new  ReporteKardexSalidasDL();
                return kardexbulto.Listado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
