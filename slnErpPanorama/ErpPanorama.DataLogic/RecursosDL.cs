using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class RecursosDL
    {
        public RecursosDL() { }

        public List<RecursosBE> Listado(DateTime FechaDesde, DateTime FechaHasta, String Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Clocking_ListaFecha_mod");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RecursosBE> Recursoslist = new List<RecursosBE>();
            RecursosBE Recursos;
            while (reader.Read())
            {
                Recursos = new RecursosBE();
                Recursos.Dni = reader["Dni"].ToString();
                Recursos.ApeNom = reader["ApeNom"].ToString();
                Recursos.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Recursos.FechaDesde = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Recursos.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                Recursos.TiempoTrabajado = reader["TiempoTrabajado"].ToString();
                Recursoslist.Add(Recursos);
            }
            reader.Close();
            reader.Dispose();
            return Recursoslist;
        }




    }
}