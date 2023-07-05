using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEmpresaBL
    {
        public List<ReporteEmpresaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteEmpresaDL Empresa = new ReporteEmpresaDL();
                return Empresa.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
