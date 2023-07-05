using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteVacacionesVendidasBL
    {
        public List<ReporteVacacionesVendidasBE> Listado(int IdVacaciones)
        {
            try
            {
                ReporteVacacionesVendidasDL Reporte = new ReporteVacacionesVendidasDL();
                return Reporte.Listado(IdVacaciones);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
