using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoTransformacionDL
    {
        public ProductoTransformacionDL() { }

        public Int32 Inserta(ProductoTransformacionBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacion_Inserta");

            db.AddOutParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, pItem.IdProductoTransformacion);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCosto", DbType.Decimal, pItem.Costo);
            db.AddInParameter(dbCommand, "pMargen", DbType.Decimal, pItem.Margen);
            db.AddInParameter(dbCommand, "pPrecioSoles", DbType.Decimal, pItem.PrecioSoles);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pPrecioDolar", DbType.Decimal, pItem.PrecioDolar);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdProductoTransformacion");

            return intIdCliente;
        }

        public void Actualiza(ProductoTransformacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, pItem.IdProductoTransformacion);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCosto", DbType.Decimal, pItem.Costo);
            db.AddInParameter(dbCommand, "pMargen", DbType.Decimal, pItem.Margen);
            db.AddInParameter(dbCommand, "pPrecioSoles", DbType.Decimal, pItem.PrecioSoles);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pPrecioDolar", DbType.Decimal, pItem.PrecioDolar);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaProforma(int IdProductoTransformacion, int IdProforma)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacion_ActualizaProforma");

            db.AddInParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, IdProductoTransformacion);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);


            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProductoTransformacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacion_Elimina");

            db.AddInParameter(dbCommand, "pIdProductoTransformacion", DbType.Int32, pItem.IdProductoTransformacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoTransformacionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoTransformacionBE> ProductoTransformacionlist = new List<ProductoTransformacionBE>();
            ProductoTransformacionBE ProductoTransformacion;
            while (reader.Read())
            {
                ProductoTransformacion = new ProductoTransformacionBE();
                ProductoTransformacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoTransformacion.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ProductoTransformacion.DescTienda = reader["DescTienda"].ToString();
                ProductoTransformacion.IdProductoTransformacion = Int32.Parse(reader["idProductoTransformacion"].ToString());
                ProductoTransformacion.Codigo = reader["Codigo"].ToString();
                ProductoTransformacion.NombreProducto = reader["NombreProducto"].ToString();
                ProductoTransformacion.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                ProductoTransformacion.Abreviatura = reader["Abreviatura"].ToString();
                ProductoTransformacion.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ProductoTransformacion.Costo = Decimal.Parse(reader["Costo"].ToString());
                ProductoTransformacion.Margen = Decimal.Parse(reader["Margen"].ToString());
                ProductoTransformacion.PrecioSoles = Decimal.Parse(reader["PrecioSoles"].ToString());
                ProductoTransformacion.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                ProductoTransformacion.PrecioDolar = Decimal.Parse(reader["PrecioDolar"].ToString());
                ProductoTransformacion.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                ProductoTransformacion.IdProforma = Int32.Parse(reader["IdProforma"].ToString());
                ProductoTransformacion.NumeroProforma = reader["NumeroProforma"].ToString();
                ProductoTransformacion.NumeroFactura = reader["NumeroFactura"].ToString();
                ProductoTransformacion.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                ProductoTransformacion.DescSituacion = reader["DescSituacion"].ToString();
                ProductoTransformacion.Usuario = reader["Usuario"].ToString();
                ProductoTransformacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProductoTransformacionlist.Add(ProductoTransformacion);
            }
            reader.Close();
            reader.Dispose();
            return ProductoTransformacionlist;
        }

        public ProductoTransformacionBE SeleccionaProductoCorrelativo(int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoTransformacion_SeleccionaProductoCorrelativo");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoTransformacionBE ProductoTransformacion = null;
            while (reader.Read())
            {
                ProductoTransformacion = new ProductoTransformacionBE();
                ProductoTransformacion.Codigo = reader["Codigo"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return ProductoTransformacion;
        }

    }
}
