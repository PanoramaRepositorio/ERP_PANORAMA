using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteBancoDL
    {
        public List<ReporteBancoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptBanco");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteBancoBE> Lista = new List<ReporteBancoBE>();
            ReporteBancoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteBancoBE();
                Reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Reporte.IdBanco = Int32.Parse(reader["idBanco"].ToString());
                Reporte.DescBanco = reader["descBanco"].ToString();
                Reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
