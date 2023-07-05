using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteAreaDL
    {
        public List<ReporteAreaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptArea");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAreaBE> Lista = new List<ReporteAreaBE>();
            ReporteAreaBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteAreaBE();
                Reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Reporte.IdArea = Int32.Parse(reader["idArea"].ToString());
                Reporte.DescArea = reader["descArea"].ToString();
                Reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
