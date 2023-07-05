using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AsistenciaDL
    {
        public AsistenciaDL() { }

        public List<AsistenciaBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Clocking_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AsistenciaBE> Asistencialist = new List<AsistenciaBE>();
            AsistenciaBE Asistencia;
            while (reader.Read())
            {
                Asistencia = new AsistenciaBE();
                Asistencia.Dni = reader["Dni"].ToString();
                Asistencia.ApeNom = reader["ApeNom"].ToString();
                Asistencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Asistencia.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Asistencia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
               
                Asistencialist.Add(Asistencia);
            }
            reader.Close();
            reader.Dispose();
            return Asistencialist;
        }

        //------------------------------------------------------------------------------------------------------------
        public List<AsistenciaBE> ListaDni(String Dni, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_uplistarDni");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AsistenciaBE> Asistencialist = new List<AsistenciaBE>();
            AsistenciaBE Asistencia;
            while (reader.Read())
            {
                Asistencia = new AsistenciaBE();
                Asistencia.Dni = reader["Dni"].ToString();
                Asistencia.ApeNom = reader["ApeNom"].ToString();
                Asistencia.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Asistencia.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Asistencia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));

                Asistencialist.Add(Asistencia);
            }
            reader.Close();
            reader.Dispose();
            return Asistencialist;
        }

    }
}
