using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMarcaDL
    {
        public List<ReporteMarcaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMarca");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMarcaBE> Marcalist = new List<ReporteMarcaBE>();
            ReporteMarcaBE Marca;
            while (reader.Read())
            {
                Marca = new ReporteMarcaBE();
                Marca.IdMarca = Int32.Parse(reader["idMarca"].ToString());
                Marca.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Marca.DescMarca = reader["descMarca"].ToString();
                Marca.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Marcalist.Add(Marca);
            }
            reader.Close();
            reader.Dispose();
            return Marcalist;
        }
    }
}
