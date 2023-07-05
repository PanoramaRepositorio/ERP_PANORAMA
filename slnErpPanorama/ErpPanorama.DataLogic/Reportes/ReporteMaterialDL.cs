using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMaterialDL
    {
        public List<ReporteMaterialBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMaterial");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMaterialBE> Materiallist = new List<ReporteMaterialBE>();
            ReporteMaterialBE Material;
            while (reader.Read())
            {
                Material = new ReporteMaterialBE();
                Material.IdMaterial = Int32.Parse(reader["idMaterial"].ToString());
                Material.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Material.DescMaterial = reader["descMaterial"].ToString();
                Material.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Materiallist.Add(Material);
            }
            reader.Close();
            reader.Dispose();
            return Materiallist;
        }
    }
}

