using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;
namespace ErpPanorama.DataLogic
{
    public class ProductoNavidadImportadoDL
    {
        public ProductoNavidadImportadoDL() { }

        public ProductoNavidadImportadoBE Selecciona(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoNavidadImportado_Selecciona");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoNavidadImportadoBE Producto = null;
            while (reader.Read())
            {
                Producto = new ProductoNavidadImportadoBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoNavidadImportado_ListaProductoPrecioBusCount");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<ProductoNavidadImportadoBE> ListaProductoPrecio(int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoNavidadImportado_ListaProductoPrecio");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoNavidadImportadoBE> ProductoNavidadImportadolist = new List<ProductoNavidadImportadoBE>();
            ProductoNavidadImportadoBE ProductoNavidadImportado;
            while (reader.Read())
            {
                ProductoNavidadImportado = new ProductoNavidadImportadoBE();
                ProductoNavidadImportado.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ProductoNavidadImportado.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                ProductoNavidadImportado.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                ProductoNavidadImportado.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoNavidadImportado.NombreProducto = reader["NombreProducto"].ToString();
                ProductoNavidadImportado.Abreviatura = reader["Abreviatura"].ToString();
                ProductoNavidadImportado.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ProductoNavidadImportado.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                ProductoNavidadImportado.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                ProductoNavidadImportado.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                ProductoNavidadImportado.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                ProductoNavidadImportado.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoNavidadImportado.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                ProductoNavidadImportado.DescUbicacion = reader["DescUbicacion"].ToString();
                ProductoNavidadImportadolist.Add(ProductoNavidadImportado);
            }
            reader.Close();
            reader.Dispose();
            return ProductoNavidadImportadolist;
        }


    }
}
