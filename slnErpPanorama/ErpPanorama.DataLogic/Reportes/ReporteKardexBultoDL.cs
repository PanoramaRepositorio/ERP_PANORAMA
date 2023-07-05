using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteKardexBultoDL
    {
        public List<ReporteKardexBultoBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptKardexBulto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteKardexBultoBE> Lista = new List<ReporteKardexBultoBE>();
            ReporteKardexBultoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteKardexBultoBE();
                Reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Reporte.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.StockCantidades = Int32.Parse(reader["StockCantidades"].ToString());
                Reporte.CantidadComprada = Int32.Parse(reader["CantidadComprada"].ToString());
                Reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Reporte.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                Reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Reporte.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Reporte.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Reporte.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Reporte.DescProveedor = reader["DescProveedor"].ToString();
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        public List<ReporteKardexBultoBE> KardexBulto_Listado(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto, int IdModeloProducto, int IdMaterial)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_KardexBulto_Listado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, IdMaterial);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteKardexBultoBE> Productolist = new List<ReporteKardexBultoBE>();
            ReporteKardexBultoBE Producto;
            while (reader.Read())
            {
                Producto = new ReporteKardexBultoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Abreviatura = reader["Abreviatura"].ToString();
                Producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Producto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                Producto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Producto.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Producto.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Producto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Producto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Producto.DescMaterial = reader["DescMaterial"].ToString();
                Producto.StockCantidades = Int32.Parse(reader["StockCantidades"].ToString());
                Productolist.Add(Producto);
            }
            reader.Close();
            reader.Dispose();
            return Productolist;
        }

    }
}
