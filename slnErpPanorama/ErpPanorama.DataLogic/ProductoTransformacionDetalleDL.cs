using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoTransformacionDetalleDL
    {
        public ProductoTransformacionDetalleDL() { }

        public void Inserta(ProductoTransformacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacionDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoTransformacionDetalle", DbType.Int32, pItem.IdProductoTransformacionDetalle);
            db.AddInParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, pItem.IdProductoTransformacion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCosto", DbType.Decimal, pItem.Costo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ProductoTransformacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacionDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoTransformacionDetalle", DbType.Int32, pItem.IdProductoTransformacionDetalle);
            db.AddInParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, pItem.IdProductoTransformacion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCosto", DbType.Decimal, pItem.Costo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            ///db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProductoTransformacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacionDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdProductoTransformacionDetalle", DbType.Int32, pItem.IdProductoTransformacionDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoTransformacionDetalleBE> ListaTodosActivo(int IdProductoTransformacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, IdProductoTransformacion);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoTransformacionDetalleBE> ProductoTransformacionDetallelist = new List<ProductoTransformacionDetalleBE>();
            ProductoTransformacionDetalleBE ProductoTransformacionDetalle;
            while (reader.Read())
            {
                ProductoTransformacionDetalle = new ProductoTransformacionDetalleBE();
                ProductoTransformacionDetalle.IdProductoTransformacion = Int32.Parse(reader["IdProductoTransformacion"].ToString());
                ProductoTransformacionDetalle.IdProductoTransformacionDetalle = Int32.Parse(reader["idProductoTransformacionDetalle"].ToString());
                ProductoTransformacionDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoTransformacionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoTransformacionDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ProductoTransformacionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ProductoTransformacionDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ProductoTransformacionDetalle.Costo = Decimal.Parse(reader["Costo"].ToString());
                ProductoTransformacionDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ProductoTransformacionDetalle.TipoOper = 4; //Consultar
                ProductoTransformacionDetallelist.Add(ProductoTransformacionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ProductoTransformacionDetallelist;
        }
    }
}
