using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteConexionSQLBL
    {
        public List<ReporteConexionSQLBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteConexionSQLDL ConexionSQL = new ReporteConexionSQLDL();
                return ConexionSQL.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
