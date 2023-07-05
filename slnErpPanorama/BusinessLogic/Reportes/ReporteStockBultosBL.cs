using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteStockBultosBL
    {
        public List<ReporteStockBultosBE> ListadoRegular(int Periodo)
        {
            try
            {
                ReporteStockBultosDL Bulto = new ReporteStockBultosDL();
                return Bulto.ListadoRegular(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteStockBultosBE> ListadoNavidad(int Periodo)
        {
            try
            {
                ReporteStockBultosDL Bulto = new ReporteStockBultosDL();
                return Bulto.ListadoNavidad(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
