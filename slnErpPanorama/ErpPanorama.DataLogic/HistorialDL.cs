using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class HistorialDL
    {
        public HistorialDL() { }

        public void Inserta(HistorialBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Sp_upHistorialCese");

            db.AddInParameter(dbCommand, "pId", DbType.String, pItem.Id);
            db.AddInParameter(dbCommand, "pFec_Ing", DbType.String, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFec_Ces", DbType.String, pItem.FechaFin);

            db.ExecuteNonQuery(dbCommand);
        }


    }
}
