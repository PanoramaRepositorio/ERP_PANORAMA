using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePisoDL
    {
        public List<ReportePisoBE> Listado(int IdEmpresa, int IdUbicacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPiso");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, IdUbicacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePisoBE> Pisolist = new List<ReportePisoBE>();
            ReportePisoBE Piso;
            while (reader.Read())
            {
                Piso = new ReportePisoBE();
                Piso.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Piso.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                Piso.DescUbicacion = reader["DescUbicacion"].ToString();
                Piso.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                Piso.DescPiso = reader["descPiso"].ToString();
                Piso.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pisolist.Add(Piso);
            }
            reader.Close();
            reader.Dispose();
            return Pisolist;
        }
    }
}

