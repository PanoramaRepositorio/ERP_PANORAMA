using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCajaBL
    {
        public List<ReporteCajaBE> Listado(int IdEmpresa, int IdTienda)
        {
            try
            {
                ReporteCajaDL Caja = new ReporteCajaDL();
                return Caja.Listado(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

