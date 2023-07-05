using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProformaBL
    {
        public List<ReporteProformaBE> Listado(int IdProforma)
        {
            try
            {
                ReporteProformaDL Proforma = new ReporteProformaDL();
                return Proforma.Listado(IdProforma);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
