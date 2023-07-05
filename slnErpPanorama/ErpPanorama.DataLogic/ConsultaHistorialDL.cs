using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ConsultaHistorialDL
    {
        public ConsultaHistorialDL() { }


        public List<ConsultaHistorialBE> ListaHistorial(int idpersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_splistar_historial");


            db.AddInParameter(dbCommand, "idpersona", DbType.Int32, idpersona);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConsultaHistorialBE> ConsultaHistoriallist = new List<ConsultaHistorialBE>();
            ConsultaHistorialBE ConsultaHistorial;
            while (reader.Read())
            {
                ConsultaHistorial = new ConsultaHistorialBE();
                ConsultaHistorial.IdPersona =Int32.Parse( reader["IdPersona"].ToString());
                ConsultaHistorial.ApeNom = reader["ApeNom"].ToString();
                ConsultaHistorial.Apellidos = reader["Apellidos"].ToString();
                ConsultaHistorial.Dni = reader["Dni"].ToString();
                ConsultaHistorial.Descanso = reader["Descanso"].ToString();
                ConsultaHistorial.FechaIngreso = Convert.ToDateTime(reader["fec_Ing"].ToString());
                ConsultaHistorial.FechaCese  =Convert.ToDateTime ( reader["fec_Ces"].ToString());
                ConsultaHistoriallist.Add(ConsultaHistorial);
            }
            reader.Close();
            reader.Dispose();
            return ConsultaHistoriallist;
        }

       
    }
}
