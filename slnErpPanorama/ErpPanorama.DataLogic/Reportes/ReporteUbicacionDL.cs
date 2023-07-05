using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteUbicacionDL
    {
        public List<ReporteUbicacionBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptUbicacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteUbicacionBE> Ubicacionlist = new List<ReporteUbicacionBE>();
            ReporteUbicacionBE Ubicacion;
            while (reader.Read())
            {
                Ubicacion = new ReporteUbicacionBE();
                Ubicacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Ubicacion.IdUbicacion = Int32.Parse(reader["idUbicacion"].ToString());
                Ubicacion.DescUbicacion = reader["descUbicacion"].ToString();
                Ubicacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Ubicacionlist.Add(Ubicacion);
            }
            reader.Close();
            reader.Dispose();
            return Ubicacionlist;
        }
    }
}
