using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteLineaProductoDL
    {
        public List<ReporteLineaProductoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptLineaProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteLineaProductoBE> Lista = new List<ReporteLineaProductoBE>();
            ReporteLineaProductoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteLineaProductoBE();
                Reporte.IdLineaProducto = Int32.Parse(reader["idLineaProducto"].ToString());
                Reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Reporte.Numero = Int32.Parse(reader["numero"].ToString());
                Reporte.DescLineaProducto = reader["descLineaProducto"].ToString();
                Reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
