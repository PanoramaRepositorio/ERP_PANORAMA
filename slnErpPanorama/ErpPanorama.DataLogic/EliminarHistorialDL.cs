using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EliminarHistorialDL
    {
        public EliminarHistorialDL() { }

        public void Elimina(EliminarHistorialBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_speliminaHcese");

            db.AddInParameter(dbCommand, "id", DbType.Int32, pItem.Id );
            db.AddInParameter(dbCommand, "fec_ing", DbType.String , pItem.FechaInicio);
            db.AddInParameter(dbCommand, "fec_ces", DbType.String, pItem.FechaFin);
    
            db.ExecuteNonQuery(dbCommand);
        }

      
    }
}
