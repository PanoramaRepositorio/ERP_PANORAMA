using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteStockBultosDL
    {
        public List<ReporteStockBultosBE> ListadoRegular(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBultoRegular");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteStockBultosBE> Lista = new List<ReporteStockBultosBE>();
            ReporteStockBultosBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteStockBultosBE();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.SubLineaProducto = reader["SubLineaProducto"].ToString();
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.AnioRecep = Int32.Parse(reader["AnioRecep"].ToString());
                Reporte.MesRecep = Int32.Parse(reader["MesRecep"].ToString());
                Reporte.DescProveedor = reader["DescProveedor"].ToString();
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        public List<ReporteStockBultosBE> ListadoNavidad(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBultoNavidad");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteStockBultosBE> Lista = new List<ReporteStockBultosBE>();
            ReporteStockBultosBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteStockBultosBE();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.SubLineaProducto = reader["SubLineaProducto"].ToString();
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.AnioRecep = Int32.Parse(reader["AnioRecep"].ToString());
                Reporte.MesRecep = Int32.Parse(reader["MesRecep"].ToString());
                Reporte.DescProveedor = reader["DescProveedor"].ToString();
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
