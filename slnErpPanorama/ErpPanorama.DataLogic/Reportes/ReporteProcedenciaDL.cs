using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProcedenciaDL
    {
        public List<ReporteProcedenciaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProcedencia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProcedenciaBE> Procedencialist = new List<ReporteProcedenciaBE>();
            ReporteProcedenciaBE Procedencia;
            while (reader.Read())
            {
                Procedencia = new ReporteProcedenciaBE();
                Procedencia.IdProcedencia = Int32.Parse(reader["idProcedencia"].ToString());
                Procedencia.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Procedencia.DescProcedencia = reader["descProcedencia"].ToString();
                Procedencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Procedencialist.Add(Procedencia);
            }
            reader.Close();
            reader.Dispose();
            return Procedencialist;
        }
    }
}
