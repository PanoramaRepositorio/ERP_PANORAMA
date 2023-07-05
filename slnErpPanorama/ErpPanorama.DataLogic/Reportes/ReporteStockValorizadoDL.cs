using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;
namespace ErpPanorama.DataLogic
{
    public class ReporteStockValorizadoDL
    {
        public List<ReporteStockValorizadoBE> Listado(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptStock_Valorizado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteStockValorizadoBE> Lista = new List<ReporteStockValorizadoBE>();
            ReporteStockValorizadoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteStockValorizadoBE();
                Reporte.Tipo = reader["Tipo"].ToString();
                Reporte.DescAlmacen = reader["DescAlmacen"].ToString();
                Reporte.TotalCostoPromedio = Decimal.Parse(reader["TotalCostoPromedio"].ToString());
                Reporte.TotalCostoUltimo= Decimal.Parse(reader["TotalCostoUltimo"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
