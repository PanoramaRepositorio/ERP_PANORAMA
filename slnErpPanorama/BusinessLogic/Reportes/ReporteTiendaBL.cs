using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTiendaBL
    {
        public List<ReporteTiendaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteTiendaDL Tienda = new ReporteTiendaDL();
                return Tienda.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
