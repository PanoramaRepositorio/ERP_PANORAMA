using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteNovioRegaloBL
    {
        public List<ReporteNovioRegaloBE> Listado(int IdNovioRegalo, int TipoReporte)
        {
            try
            {
                ReporteNovioRegaloDL NovioRegalo = new ReporteNovioRegaloDL();
                return NovioRegalo.Listado(IdNovioRegalo, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
