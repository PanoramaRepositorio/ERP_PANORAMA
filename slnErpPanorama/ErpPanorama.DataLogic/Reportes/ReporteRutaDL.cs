using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteRutaDL
    {
        public List<ReporteRutaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptRuta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteRutaBE> Rutalist = new List<ReporteRutaBE>();
            ReporteRutaBE Ruta;
            while (reader.Read())
            {
                Ruta = new ReporteRutaBE();
                Ruta.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Ruta.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                Ruta.DescRuta = reader["DescRuta"].ToString();
                Ruta.IdRuta = Int32.Parse(reader["idRuta"].ToString());
                Ruta.DescRuta = reader["descRuta"].ToString();
                Ruta.IdUbigeo = reader["IdUbigeo"].ToString();
                Ruta.NomDpto = reader["NomDpto"].ToString();
                Ruta.NomProv = reader["NomProv"].ToString();
                Ruta.NomDist = reader["NomDist"].ToString();
                Ruta.Dia = reader["dia"].ToString();
                Ruta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Rutalist.Add(Ruta);
            }
            reader.Close();
            reader.Dispose();
            return Rutalist;
        }
    }
}
