using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCampanaDL
    {
        public List<ReporteCampanaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCampana");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCampanaBE> lista = new List<ReporteCampanaBE>();
            ReporteCampanaBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteCampanaBE();
                reporte.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                reporte.IdCampana = Int32.Parse(reader["IdCampana"].ToString());
                reporte.DescCampana = reader["DescCampana"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
