using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoAsociadoDL
    {
        public ProductoAsociadoDL() { }

        public void Inserta(ProductoAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoAsociado", DbType.Int32, pItem.IdProductoAsociado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdProductoReferencia", DbType.Int32, pItem.IdProductoReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Inserta2(ProductoAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoAsociado", DbType.Int32, pItem.IdProductoAsociado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdProductoReferencia", DbType.Int32, pItem.IdProductoReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ProductoAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoAsociado", DbType.Int32, pItem.IdProductoAsociado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdProductoReferencia", DbType.Int32, pItem.IdProductoReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza2(ProductoAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoAsociado", DbType.Int32, pItem.IdProductoAsociado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdProductoReferencia", DbType.Int32, pItem.IdProductoReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaProforma(ProductoAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoAsociado", DbType.Int32, pItem.IdProductoAsociado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdProductoReferencia", DbType.Int32, pItem.IdProductoReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(ProductoAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_Elimina");

            db.AddInParameter(dbCommand, "pIdProductoAsociado", DbType.Int32, pItem.IdProductoAsociado);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoAsociadoBE> ListaTodosActivo(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoAsociado_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoAsociadoBE> ProductoAsociadolist = new List<ProductoAsociadoBE>();
            ProductoAsociadoBE ProductoAsociado;
            while (reader.Read())
            {
                ProductoAsociado = new ProductoAsociadoBE();
                ProductoAsociado.IdProductoAsociado = Int32.Parse(reader["idProductoAsociado"].ToString());
                ProductoAsociado.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoAsociado.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoAsociado.NombreProducto = reader["nombreProducto"].ToString();
                ProductoAsociado.Abreviatura = reader["Abreviatura"].ToString();
                ProductoAsociado.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ProductoAsociado.Precio = Decimal.Parse(reader["Precio"].ToString());
                ProductoAsociado.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoAsociado.IdProductoReferencia = Int32.Parse(reader["IdProductoReferencia"].ToString());
                ProductoAsociado.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ProductoAsociado.TipoOper = 4; //Consultar
                ProductoAsociadolist.Add(ProductoAsociado);
            }
            reader.Close();
            reader.Dispose();
            return ProductoAsociadolist;
        }

        public List<ProductoComponenteBE> ListaTodosActivoComponente(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoComponente_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoComponenteBE> ProductoComponentelist = new List<ProductoComponenteBE>();
            ProductoComponenteBE ProductoComponente;
            while (reader.Read())
            {
                ProductoComponente = new ProductoComponenteBE();

                ProductoComponente.IdProductoComponente = Int32.Parse(reader["IdProductoComponente"].ToString());
                ProductoComponente.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                ProductoComponente.DescComponente = reader["DescComponente"].ToString();
                ProductoComponente.IdMaterial = Int32.Parse(reader["IdMaterial"].ToString());
                ProductoComponente.DescMaterial = reader["DescMaterial"].ToString();
                ProductoComponente.IdColor = Int32.Parse(reader["IdColor"].ToString());
                ProductoComponente.DescColor = reader["DescColor"].ToString();

                ProductoComponente.cAncho = Int32.Parse(reader["Ancho"].ToString());
                ProductoComponente.cLargo = Int32.Parse(reader["Largo"].ToString());
                ProductoComponente.cAlto = Int32.Parse(reader["Alto"].ToString());
                ProductoComponente.cProfundidad = Int32.Parse(reader["Profundidad"].ToString());
                ProductoComponente.Cantidad = Int32.Parse(reader["Cantidad"].ToString());

                ProductoComponente.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                ProductoComponente.DescUnidadMedida = reader["DescUnidadMedida"].ToString();

               ProductoComponente.TipoOper = 4; //Consultar

                ProductoComponentelist.Add(ProductoComponente);
    }
            reader.Close();
            reader.Dispose();
            return ProductoComponentelist;
        }

    }
}
