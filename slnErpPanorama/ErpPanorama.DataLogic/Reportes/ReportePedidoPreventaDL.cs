using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoPreventaDL
    {
        public List<ReportePedidoPreventaBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoPreventa");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoPreventaBE> Pedidolist = new List<ReportePedidoPreventaBE>();
            ReportePedidoPreventaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoPreventaBE();

                Pedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescSituacion = reader["DescSituacion"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
    
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoPreventaBE> ListadoPedidoCodigo(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoPreventaPedidoCodigo");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoPreventaBE> Pedidolist = new List<ReportePedidoPreventaBE>();
            ReportePedidoPreventaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoPreventaBE();

                Pedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();

                Pedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Pedido.NombreProducto = reader["NombreProducto"].ToString();
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Pedido.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Pedido.PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString());
                Pedido.Cantidad = int.Parse(reader["Cantidad"].ToString());
                Pedido.PrecioAB = decimal.Parse(reader["PrecioAB"].ToString());
                Pedido.Descuento = decimal.Parse(reader["Descuento"].ToString());
                Pedido.ValorVenta = decimal.Parse(reader["ValorVenta"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
