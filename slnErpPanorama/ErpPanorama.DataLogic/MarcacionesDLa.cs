using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MarcacionesDL
    {
        public MarcacionesDL() { }


        public List<MarcacionesBE> ListaTodos(String dni, String fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_spmacaciones");

            db.AddInParameter(dbCommand, "pdni", DbType.String,dni);
            db.AddInParameter(dbCommand, "fecha", DbType.String , fecha);
         

            db.ExecuteNonQuery(dbCommand);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MarcacionesBE> Marcacioneslist = new List<MarcacionesBE>();
            MarcacionesBE Marcaciones;
            while (reader.Read())
            {
                Marcaciones = new MarcacionesBE();
                Marcaciones.dni = (reader["dni"].ToString());
                Marcaciones.ApeNom = (reader["ApeNom"].ToString());
                Marcaciones.Apellidos = reader["Apellidos"].ToString();
                Marcaciones.Fecha = (reader["Fecha"].ToString());
                Marcaciones.Marcacion = (reader["Marcacion"].ToString());
                Marcacioneslist.Add(Marcaciones);
            }
            reader.Close();
            reader.Dispose();
            return Marcacioneslist;
        }


        public void InsertaHE(MarcacionesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_sphoraextrapersonal");

            db.AddInParameter(dbCommand, "dni", DbType.String , pItem.dni );

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MarcacionesBE> ListaMarcaciones(String dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_uplistarmarcaextras");
            db.AddInParameter(dbCommand, "dni", DbType.String, dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MarcacionesBE> Marcalist = new List<MarcacionesBE>();
            MarcacionesBE Marca;
            while (reader.Read())
            {
                Marca = new MarcacionesBE();
                Marca.Idhoraextra = Int32.Parse(reader["Idhoraextra"].ToString());
                Marca.dni  = (reader["dni"].ToString());
                Marca.ApeNom = (reader["ApeNom"].ToString());
                Marca.FechaDesde = reader["FechaDesde"].ToString();
                Marca.Ingreso = reader["Ingreso"].ToString();
                Marca.FechaHasta = reader["FechaHasta"].ToString();
                Marca.Salida = reader["Salida"].ToString();
                Marca.Tipo = Int32.Parse(reader["Tipo"].ToString());
                Marca.Observacion = reader["Observacion"].ToString();
                Marcalist.Add(Marca);
            }
            reader.Close();
            reader.Dispose();
            return Marcalist;
        }



    }
}
