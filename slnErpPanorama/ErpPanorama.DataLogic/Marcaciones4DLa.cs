using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Marcaciones4DL
    {
        public Marcaciones4DL() { }


        public List<Marcaciones4BE> ListaTodos(String fecha1)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_splistarmarcaciones");

            db.AddInParameter(dbCommand, "pfechaini", DbType.String, fecha1);
          
         

            db.ExecuteNonQuery(dbCommand);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Marcaciones4BE> Marcacioneslist = new List<Marcaciones4BE>();
            Marcaciones4BE Marcaciones;
            while (reader.Read())
            {
                Marcaciones = new Marcaciones4BE();
                Marcaciones.dni = (reader["dni"].ToString());
                Marcaciones.ApeNom = (reader["ApeNom"].ToString());
                Marcaciones.Fecha = (reader["Fecha"].ToString());
                Marcaciones.Ingreso  = (reader["Ingreso"].ToString());
                Marcaciones.SalidaAlmuerzo = (reader["SalidaAlmuerzo"].ToString());
                Marcaciones.IngresoAlmuerzo = (reader["IngresoAlmuerzo"].ToString());
                Marcaciones.Salida = (reader["Salida"].ToString());
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
