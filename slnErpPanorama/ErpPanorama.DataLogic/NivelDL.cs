using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class NivelDL
    {
        public List<NivelBE> SeleccionaTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Niveles_Selecciona");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NivelBE> Nivellist = new List<NivelBE>();
            NivelBE Nivel;
            while (reader.Read())
            {
                Nivel = new NivelBE();
                Nivel.IdNivel = Int32.Parse(reader["idNivel"].ToString());
                Nivel.DescNivel = reader["DescNivel"].ToString();
                Nivel.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Nivellist.Add(Nivel);
            }
            reader.Close();
            reader.Dispose();
            return Nivellist;
        }
    }
}
