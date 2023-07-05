using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteInventarioBultoDL
    {
        public List< ReporteInventarioBultoBE> Listado(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBulto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List< ReporteInventarioBultoBE> Lista = new List< ReporteInventarioBultoBE>();
             ReporteInventarioBultoBE Reporte;
            while (reader.Read())
            {
                Reporte = new  ReporteInventarioBultoBE();
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Reporte.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Reporte.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.StockCantidades = Int32.Parse(reader["StockCantidades"].ToString());
                Reporte.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Reporte.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Reporte.DescProveedor = reader["DescProveedor"].ToString();
                Reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //Reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        public List<ReporteInventarioBultoBE> ListadoBloque(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBultoBloque");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInventarioBultoBE> Lista = new List<ReporteInventarioBultoBE>();
            ReporteInventarioBultoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteInventarioBultoBE();
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.DescBloque = reader["DescBloque"].ToString();
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Reporte.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Reporte.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.StockCantidades = Int32.Parse(reader["StockCantidades"].ToString());
                Reporte.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Reporte.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Reporte.DescProveedor = reader["DescProveedor"].ToString();
                Reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
