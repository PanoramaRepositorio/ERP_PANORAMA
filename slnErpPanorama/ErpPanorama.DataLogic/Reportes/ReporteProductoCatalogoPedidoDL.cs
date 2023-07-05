using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductoCatalogoPedidoDL
    {
        public List<ReporteProductoCatalogoPedidoBE> Listado(int IdEmpresa, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductoCatologoPedido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductoCatalogoPedidoBE> ProductoCatalogoPedidolist = new List<ReporteProductoCatalogoPedidoBE>();
            ReporteProductoCatalogoPedidoBE ProductoCatalogoPedido;
            while (reader.Read())
            {
                ProductoCatalogoPedido = new ReporteProductoCatalogoPedidoBE();
                ProductoCatalogoPedido.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoCatalogoPedido.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoCatalogoPedido.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoCatalogoPedido.CodigoPanorama = reader["CodigoPanorama"].ToString();
                ProductoCatalogoPedido.Abreviatura = reader["Abreviatura"].ToString();
                ProductoCatalogoPedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ProductoCatalogoPedido.DescModeloProducto = reader["DescModeloProducto"].ToString();
                ProductoCatalogoPedido.DescMaterial = reader["DescMaterial"].ToString();
                ProductoCatalogoPedido.DescMarca = reader["DescMarca"].ToString();
                ProductoCatalogoPedido.DescProcedencia = reader["DescProcedencia"].ToString();
                ProductoCatalogoPedido.NombreProducto = reader["NombreProducto"].ToString();
                ProductoCatalogoPedido.Descripcion = reader["Descripcion"].ToString();
                ProductoCatalogoPedido.Peso = Decimal.Parse(reader["Peso"].ToString());
                ProductoCatalogoPedido.Medida = reader["Medida"].ToString();
                ProductoCatalogoPedido.CodigoBarra = reader["CodigoBarra"].ToString();
                ProductoCatalogoPedido.Imagen = (byte[])reader["Imagen"];
                ProductoCatalogoPedido.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoCatalogoPedido.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoCatalogoPedido.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoCatalogoPedido.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                ProductoCatalogoPedido.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                ProductoCatalogoPedido.StockBultos = Int32.Parse(reader["StockBultos"].ToString());
                ProductoCatalogoPedido.FlagCompuesto = Boolean.Parse(reader["FlagCompuesto"].ToString());
                ProductoCatalogoPedido.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                ProductoCatalogoPedido.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoCatalogoPedido.Observacion = reader["Observacion"].ToString();
                ProductoCatalogoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ProductoCatalogoPedido.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ProductoCatalogoPedido.TipoCambioMinorista = Decimal.Parse(reader["TipoCambioMinorista"].ToString());
                ProductoCatalogoPedido.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ProductoCatalogoPedido.FlagEstado = Boolean.Parse(reader["Flagestado"].ToString());
                ProductoCatalogoPedidolist.Add(ProductoCatalogoPedido);
            }
            reader.Close();
            reader.Dispose();
            return ProductoCatalogoPedidolist;
        }
    }
}
