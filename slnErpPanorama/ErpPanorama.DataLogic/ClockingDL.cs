using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClockingDL
    {
        public ClockingDL() { }

        public List<CocklingBE> ListaMarcaciones(String Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_listarClocking");
            db.AddInParameter(dbCommand, "pDni", DbType.Int32, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CocklingBE> Checkinoutlist = new List<CocklingBE>();
            CocklingBE Checkinout;
            while (reader.Read())
            {
                Checkinout = new CocklingBE();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.Apellidos = reader["Apellidos"].ToString();
                Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Marcacion = reader["Marcacion"].ToString();
             
                Checkinoutlist.Add(Checkinout);
            }
            reader.Close();
            reader.Dispose();
            return Checkinoutlist;
        }
    }
}
