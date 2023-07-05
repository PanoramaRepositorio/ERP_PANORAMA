using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PlanillaRHDL
    {
         public PlanillaRHDL() { }

       

        public List<PlanillaRHBE> PlanillaRH(int dias)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_upplanillasueldorh");
            db.AddInParameter(dbCommand, "tiempo", DbType.Int32, dias);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PlanillaRHBE> Planillalist = new List<PlanillaRHBE>();
            PlanillaRHBE PlanillaRH;
            while (reader.Read())
            {
                PlanillaRH = new PlanillaRHBE();
               PlanillaRH.NombresyApellidos = (reader["NombresyApellidos"].ToString());
              PlanillaRH.FechaIngreso  = reader["FechaIngreso"].ToString();
                PlanillaRH.Sueldo = Double.Parse(reader["Sueldo"].ToString());
                PlanillaRH.Dias  = Int32 .Parse(reader["Dias"].ToString());
                PlanillaRH.HorasExtras  = Double.Parse(reader["HoraExtras"].ToString());
                PlanillaRH.SBruto = Double.Parse(reader["SBruto"].ToString());
                Planillalist.Add(PlanillaRH);
            }
            reader.Close();
            reader.Dispose();
            return Planillalist;
        }

     


    }
}
