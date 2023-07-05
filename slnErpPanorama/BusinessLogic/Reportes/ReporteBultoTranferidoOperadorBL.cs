using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteBultoTranferidoOperadorBL
    {
        public List<ReporteBultoTranferidoOperadorBE> Listado(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteBultoTranferidoOperadorDL Bulto = new ReporteBultoTranferidoOperadorDL();
                return Bulto.Listado(IdEmpresa, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
