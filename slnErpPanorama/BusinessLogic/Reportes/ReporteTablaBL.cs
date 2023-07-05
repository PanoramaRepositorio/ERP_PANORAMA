using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTablaBL
    {
        public List<ReporteTablaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteTablaDL Tabla = new ReporteTablaDL();
                return Tabla.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}