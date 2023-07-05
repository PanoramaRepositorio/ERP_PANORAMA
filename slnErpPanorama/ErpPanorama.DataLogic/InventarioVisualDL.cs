using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InventarioVisualDL
    {
        public void Inserta(InventarioVisualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_Inserta");

            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, pItem.IdInventarioVisual);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pDescuentoActual", DbType.Decimal, pItem.DescuentoActual);
            db.AddInParameter(dbCommand, "pDescuentoSugerido", DbType.Decimal, pItem.DescuentoSugerido);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
            db.AddInParameter(dbCommand, "pCantidadCompra", DbType.Int32, pItem.CantidadCompra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(InventarioVisualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_Actualiza");

            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, pItem.IdInventarioVisual);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pDescuentoActual", DbType.Decimal, pItem.DescuentoActual);
            db.AddInParameter(dbCommand, "pDescuentoSugerido", DbType.Decimal, pItem.DescuentoSugerido);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
            db.AddInParameter(dbCommand, "pCantidadCompra", DbType.Int32, pItem.CantidadCompra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InventarioVisualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_Elimina");

            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, pItem.IdInventarioVisual);

            db.ExecuteNonQuery(dbCommand);

        }

        public InventarioVisualBE Selecciona(int IdInventarioVisual)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_Selecciona");
            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, IdInventarioVisual);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InventarioVisualBE InventarioVisual = null;
            while (reader.Read())
            {
                InventarioVisual = new InventarioVisualBE();
                InventarioVisual.IdInventarioVisual = Int32.Parse(reader["idInventarioVisual"].ToString());
                InventarioVisual.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioVisual.DescTienda = reader["DescTienda"].ToString();
                InventarioVisual.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                InventarioVisual.DescBloque = reader["DescBloque"].ToString();
                InventarioVisual.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                InventarioVisual.DescModulo = reader["DescModulo"].ToString();
                InventarioVisual.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioVisual.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioVisual.NombreProducto = reader["nombreProducto"].ToString();
                InventarioVisual.Abreviatura = reader["Abreviatura"].ToString();
                InventarioVisual.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InventarioVisual.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioVisual.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                InventarioVisual.DescuentoSugerido = Decimal.Parse(reader["DescuentoSugerido"].ToString());
                InventarioVisual.Observacion = reader["Observacion"].ToString();
                InventarioVisual.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                InventarioVisual.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                InventarioVisual.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return InventarioVisual;
        }

        public List<InventarioVisualBE> ListaTodosActivo(int IdTienda, int IdModulo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioVisualBE> InventarioVisuallist = new List<InventarioVisualBE>();
            InventarioVisualBE InventarioVisual;
            while (reader.Read())
            {
                InventarioVisual = new InventarioVisualBE();
                InventarioVisual.IdInventarioVisual = Int32.Parse(reader["idInventarioVisual"].ToString());
                InventarioVisual.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioVisual.DescTienda = reader["DescTienda"].ToString();
                InventarioVisual.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                InventarioVisual.DescBloque = reader["DescBloque"].ToString();
                InventarioVisual.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                InventarioVisual.DescModulo = reader["DescModulo"].ToString();
                InventarioVisual.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioVisual.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioVisual.NombreProducto = reader["nombreProducto"].ToString();
                InventarioVisual.Abreviatura = reader["Abreviatura"].ToString();
                InventarioVisual.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InventarioVisual.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioVisual.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                InventarioVisual.DescuentoSugerido = Decimal.Parse(reader["DescuentoSugerido"].ToString());
                InventarioVisual.Observacion = reader["Observacion"].ToString();
                InventarioVisual.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                InventarioVisual.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                InventarioVisual.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioVisuallist.Add(InventarioVisual);
            }
            reader.Close();
            reader.Dispose();
            return InventarioVisuallist;
        }

        public List<InventarioVisualBE> Lista(int IdTienda, int IdModulo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_Lista");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioVisualBE> InventarioVisuallist = new List<InventarioVisualBE>();
            InventarioVisualBE InventarioVisual;
            while (reader.Read())
            {
                InventarioVisual = new InventarioVisualBE();
                InventarioVisual.IdInventarioVisual = Int32.Parse(reader["idInventarioVisual"].ToString());
                InventarioVisual.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioVisual.DescTienda = reader["DescTienda"].ToString();
                InventarioVisual.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                InventarioVisual.DescBloque = reader["DescBloque"].ToString();
                InventarioVisual.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                InventarioVisual.DescModulo = reader["DescModulo"].ToString();
                InventarioVisual.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioVisual.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioVisual.NombreProducto = reader["nombreProducto"].ToString();
                InventarioVisual.Abreviatura = reader["Abreviatura"].ToString();
                InventarioVisual.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InventarioVisual.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioVisual.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                InventarioVisual.DescuentoSugerido = Decimal.Parse(reader["DescuentoSugerido"].ToString());
                InventarioVisual.Observacion = reader["Observacion"].ToString();
                InventarioVisual.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                InventarioVisual.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                InventarioVisual.Stock = Int32.Parse(reader["Stock"].ToString());
                InventarioVisual.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioVisuallist.Add(InventarioVisual);
            }
            reader.Close();
            reader.Dispose();
            return InventarioVisuallist;
        }

        public List<InventarioVisualBE> ListaBuscaProducto(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ListaBuscaProducto");
            db.AddInParameter(dbCommand, "pIdProducto ", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioVisualBE> InventarioVisuallist = new List<InventarioVisualBE>();
            InventarioVisualBE InventarioVisual;
            while (reader.Read())
            {
                InventarioVisual = new InventarioVisualBE();
                InventarioVisual.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InventarioVisual.DescBloque = reader["DescBloque"].ToString();
                InventarioVisual.DescModulo = reader["DescModulo"].ToString();
                InventarioVisual.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioVisual.DescuentoSugerido = Decimal.Parse(reader["DescuentoSugerido"].ToString());
                InventarioVisual.Observacion = reader["Observacion"].ToString();
                InventarioVisuallist.Add(InventarioVisual);
            }
            reader.Close();
            reader.Dispose();
            return InventarioVisuallist;
        }

        public void ActualizaDescuentoListaPrecio(int IdInventarioVisual)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaDescuento_ListaPrecio");
            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, IdInventarioVisual);

            dbCommand.CommandTimeout = 250; 

            db.ExecuteNonQuery(dbCommand);

        }

        public void RestableceDescuentoListaPrecio(int IdInventarioVisual)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_RestableceDescuento_ListaPrecio");
            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, IdInventarioVisual);

            dbCommand.CommandTimeout = 250; 

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaCompra(int IdTienda, int IdModulo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaCompra");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaDescuento(int IdInventarioVisual, decimal DescuentoSugerido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaDescuento");

            db.AddInParameter(dbCommand, "pIdInventarioVisual", DbType.Int32, IdInventarioVisual);
            db.AddInParameter(dbCommand, "pDescuentoSugerido", DbType.Decimal, DescuentoSugerido);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaDescuentoPorLinea(int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaDescuentoPorLinea");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaDescuentoPorCodigo(int IdTienda, int IdProducto, decimal DescuentoSugerido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaDescuentoPorCodigo");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pDescuentoSugerido", DbType.Int32, DescuentoSugerido);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCodigo(InventarioVisualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaCodigo");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCodigoIdProducto(InventarioVisualBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisual_ActualizaIdProducto");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


    }
}
