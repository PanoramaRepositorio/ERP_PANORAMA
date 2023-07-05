using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteVentaProductoDL
    {
        public List<ReporteVentaProductoBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdTienda, int IdLineaProducto, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaProductos");//en Script Pedido
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "@pIdTipoCliente", DbType.Int32, IdTipoCliente);
            dbCommand.CommandTimeout = 350; 
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteVentaProductoBE> Pedidolist = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteVentaProductoBE();
                Pedido.Item = int.Parse(reader["Item"].ToString());
                Pedido.IdTienda = int.Parse(reader["IdTienda"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.CantidadComprada = int.Parse(reader["CantidadComprada"].ToString());
                Pedido.DescProveedor = reader["DescProveedor"].ToString();
                Pedido.CostoUnitario = decimal.Parse(reader["CostoUnitario"].ToString());
                Pedido.PrecioAB = decimal.Parse(reader["PrecioAB"].ToString());
                Pedido.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Pedido.Stock = int.Parse(reader["Stock"].ToString());
                //Pedido.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                //Pedido.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteVentaProductoBE> ListadoResumen(DateTime FechaDesde, DateTime FechaHasta, int IdTienda, int IdLineaProducto, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaProductosResumen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            
            //dbCommand.CommandTimeout = 250; 
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteVentaProductoBE> Pedidolist = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteVentaProductoBE();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.Mes = reader["Mes"].ToString();
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteVentaProductoBE> ListadoRentabilidad(DateTime FechaDesde, DateTime FechaHasta, int IdTienda, int IdLineaProducto, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaProductosRentabilidad");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            //dbCommand.CommandTimeout = 250; 
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteVentaProductoBE> Pedidolist = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteVentaProductoBE();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.Mes = reader["Mes"].ToString();
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.TotalCostoSoles = decimal.Parse(reader["TotalCostoSoles"].ToString());
                Pedido.UtilidadBruta = decimal.Parse(reader["UtilidadBruta"].ToString());
                Pedido.MargenBruto = decimal.Parse(reader["MargenBruto"].ToString());
                Pedido.FlagNacional = bool.Parse(reader["FlagNacional"].ToString());
                Pedido.Nacionalidad = reader["Nacionalidad"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }




        public List<ReporteVentaProductoBE> ListadoDias(int IdEmpresa ,DateTime FechaDesde, DateTime FechaHasta, int DiasVendidos, int IdLineaProducto, string IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaProductosDias");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pDiasVendidos", DbType.Int32, DiasVendidos);
            db.AddInParameter(dbCommand, "@pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "@pIdProducto", DbType.String, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteVentaProductoBE> Pedidolist = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteVentaProductoBE();
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Pedido.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                Pedido.CantidadComprada = int.Parse(reader["CantidadComprada"].ToString());
                Pedido.CostoUnitario = decimal.Parse(reader["CostoUnitario"].ToString());
                Pedido.PrecioAB = decimal.Parse(reader["PrecioAB"].ToString());
                Pedido.PrecioCD = decimal.Parse(reader["PrecioCD"].ToString());
                Pedido.Descuento = decimal.Parse(reader["Descuento"].ToString());
                Pedido.DescProveedor = reader["DescProveedor"].ToString();
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.Stock = int.Parse(reader["Stock"].ToString());
                Pedido.Ratio = decimal.Parse(reader["Ratio"].ToString());
                Pedido.Dias = int.Parse(reader["Dias"].ToString());
                Pedido.DiasVendidos = int.Parse(reader["DiasVendidos"].ToString());
                Pedido.DescuentoSugerido = decimal.Parse(reader["DescuentoSugerido"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReporteVentaProductoBE> ListadoDiasResumen(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int DiasVendidos, int IdLineaProducto, int IdFamiliaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaProductosDiasResumen");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pDiasVendidos", DbType.Int32, DiasVendidos);
            db.AddInParameter(dbCommand, "@pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "@pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteVentaProductoBE> Pedidolist = new List<ReporteVentaProductoBE>();
            ReporteVentaProductoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReporteVentaProductoBE();
                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Pedido.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                Pedido.CantidadComprada = int.Parse(reader["CantidadComprada"].ToString());
                Pedido.CostoUnitario = decimal.Parse(reader["CostoUnitario"].ToString());
                Pedido.PrecioAB = decimal.Parse(reader["PrecioAB"].ToString());
                Pedido.PrecioCD = decimal.Parse(reader["PrecioCD"].ToString());
                Pedido.Descuento = decimal.Parse(reader["Descuento"].ToString());
                Pedido.DescuentoSugerido = decimal.Parse(reader["DescuentoSugerido"].ToString());
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.Stock = int.Parse(reader["Stock"].ToString());
                Pedido.StockPedido = int.Parse(reader["StockPedido"].ToString());
                Pedido.StockNotaSalida = int.Parse(reader["StockNotaSalida"].ToString());
                Pedido.DescProveedor = reader["DescProveedor"].ToString();
                Pedido.NumeroFactura = reader["NumeroFactura"].ToString();
                Pedido.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Pedido.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
