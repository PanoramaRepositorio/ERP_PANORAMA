using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CumpleDL
    {
        public CumpleDL() { }







         public List<CumpleBE> Mostrar()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_spCumpleTrabajador");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CumpleBE> Cumplelist = new List<CumpleBE>();
            CumpleBE Cumple;
            while (reader.Read())
            {
                Cumple = new CumpleBE();
                Cumple.dni  = (reader["dni"].ToString());
                Cumple.nombres  = (reader["nombres"].ToString());
                Cumple.apenom  = reader["apenom"].ToString();
               

                Cumplelist.Add(Cumple);
            }
            reader.Close();
            reader.Dispose();
            return Cumplelist;
        }


    }
}
