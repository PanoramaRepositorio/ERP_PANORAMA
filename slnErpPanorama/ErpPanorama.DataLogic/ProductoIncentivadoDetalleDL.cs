using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoIncentivadoDetalleDL
    {
        public ProductoIncentivadoDetalleDL() { }

        public void Inserta(ProductoIncentivadoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoIncentivadoDetalle", DbType.Int32, pItem.IdProductoIncentivadoDetalle);
            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIncentivo", DbType.Decimal, pItem.Incentivo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ProductoIncentivadoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoIncentivadoDetalle", DbType.Int32, pItem.IdProductoIncentivadoDetalle);
            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pIncentivo", DbType.Decimal, pItem.Incentivo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProductoIncentivadoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdProductoIncentivadoDetalle", DbType.Int32, pItem.IdProductoIncentivadoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoIncentivadoDetalleBE> ListaTodosActivo(int IdProductoIncentivado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, IdProductoIncentivado);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoIncentivadoDetalleBE> ProductoIncentivadoDetallelist = new List<ProductoIncentivadoDetalleBE>();
            ProductoIncentivadoDetalleBE ProductoIncentivadoDetalle;
            while (reader.Read())
            {
                ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleBE();
                ProductoIncentivadoDetalle.IdProductoIncentivado = Int32.Parse(reader["IdProductoIncentivado"].ToString());
                ProductoIncentivadoDetalle.IdProductoIncentivadoDetalle = Int32.Parse(reader["IdProductoIncentivadoDetalle"].ToString());
                ProductoIncentivadoDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                ProductoIncentivadoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductoIncentivadoDetalle.NombreProducto = reader["NombreProducto"].ToString();
                ProductoIncentivadoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ProductoIncentivadoDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                ProductoIncentivadoDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ProductoIncentivadoDetalle.Costo = Decimal.Parse(reader["Costo"].ToString());
                ProductoIncentivadoDetalle.Incentivo = Decimal.Parse(reader["Incentivo"].ToString());
                ProductoIncentivadoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //ProductoIncentivadoDetalle.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                //ProductoIncentivadoDetalle.Usuario = reader["Usuario"].ToString();
                //ProductoIncentivadoDetalle.Maquina = reader["Maquina"].ToString();
                ProductoIncentivadoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProductoIncentivadoDetallelist.Add(ProductoIncentivadoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ProductoIncentivadoDetallelist;
        }
    }
}
