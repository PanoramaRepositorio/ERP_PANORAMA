using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTablaDL
    {
        public List<ReporteTablaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTabla");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTablaBE> Tablalist = new List<ReporteTablaBE>();
            ReporteTablaBE Tabla;
            while (reader.Read())
            {
                Tabla = new ReporteTablaBE();
                Tabla.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tabla.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                Tabla.DescTabla = reader["descTabla"].ToString();
                Tabla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }
    }
}
