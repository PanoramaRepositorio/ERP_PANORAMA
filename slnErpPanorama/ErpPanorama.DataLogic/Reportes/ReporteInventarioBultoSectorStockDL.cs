using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteInventarioBultoSectorStockDL
    {
        public List<ReporteInventarioBultoSectorStockBE> Listado(int IdEmpresa, int IdSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBultoSectorStock");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInventarioBultoSectorStockBE> Lista = new List<ReporteInventarioBultoSectorStockBE>();
            ReporteInventarioBultoSectorStockBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteInventarioBultoSectorStockBE();
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                Reporte.StockInicial = Int32.Parse(reader["StockInicial"].ToString());
                Reporte.StockActual = Int32.Parse(reader["StockActual"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
