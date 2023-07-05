using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AsistenciaHoraDL
    {
        public AsistenciaHoraDL() { }

        public List<AsistenciaHoraBE> ListaHoras(int Periodo, int Mes )
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Clocking_ListaHoras");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AsistenciaHoraBE> AsistenciaHoralist = new List<AsistenciaHoraBE>();
            AsistenciaHoraBE AsistenciaHora;
            while (reader.Read())
            {
                AsistenciaHora = new AsistenciaHoraBE();
                
                AsistenciaHora.ApeNom = reader["ApeNom"].ToString();
                AsistenciaHora.Horas = Convert.ToInt32(reader["Horas"].ToString());
                AsistenciaHoralist.Add(AsistenciaHora);
            }
            reader.Close();
            reader.Dispose();
            return AsistenciaHoralist;
        }
    }
}
