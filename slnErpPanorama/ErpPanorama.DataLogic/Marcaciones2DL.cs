using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Marcaciones2DL
    {
        public Marcaciones2DL() { }


        public List<Marcaciones2BE> ListaTodos(String fecha1, String fecha2)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_splistarmarcaciones");

            db.AddInParameter(dbCommand, "pfechaini", DbType.String, fecha1);
            db.AddInParameter(dbCommand, "pfechafin", DbType.String, fecha2);
         

            db.ExecuteNonQuery(dbCommand);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Marcaciones2BE> Marcacioneslist = new List<Marcaciones2BE>();
            Marcaciones2BE Marcaciones;
            while (reader.Read())
            {
                Marcaciones = new Marcaciones2BE();
                Marcaciones.Dni = (reader["Dni"].ToString());
                Marcaciones.ApeNom = (reader["ApeNom"].ToString());
                Marcaciones.Fecha = reader["Fecha"].ToString();
                Marcaciones.Ingreso = (reader["Ingreso"].ToString());
                Marcaciones.SalidaAlmuerzo = (reader["SalidaAlmuerzo"].ToString());
                Marcaciones.IngresoAlmuerzo = (reader["IngresoAlmuerzo"].ToString());
                Marcaciones.Ingreso = (reader["Salida"].ToString());
                Marcaciones.PrimerPeriodo = (reader["PrimerPeriodo"].ToString());
                Marcaciones.SegundoPeriodo = (reader["SegundoPeriodo"].ToString());
                Marcaciones.TotalPeriodoTrabajado = (reader["TotalPeriodoTrabajado"].ToString());
                Marcacioneslist.Add(Marcaciones);
            }
            reader.Close();
            reader.Dispose();
            return Marcacioneslist;
        }
    }
}
