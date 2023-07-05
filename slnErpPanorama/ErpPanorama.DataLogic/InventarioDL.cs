using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InventarioDL
    {
        public void Inserta(InventarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_Inserta");

            db.AddInParameter(dbCommand, "pIdInventario", DbType.Int32, pItem.IdInventario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdAlmacenPiso", DbType.Int32, pItem.IdAlmacenPiso);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pUbicacion", DbType.String, pItem.Ubicacion);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdPersona2", DbType.Int32, pItem.IdPersona2);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(InventarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_Actualiza");

            db.AddInParameter(dbCommand, "pIdInventario", DbType.Int32, pItem.IdInventario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdAlmacenPiso", DbType.Int32, pItem.IdAlmacenPiso);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pUbicacion", DbType.String, pItem.Ubicacion);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(InventarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_Elimina");

            db.AddInParameter(dbCommand, "pIdInventario", DbType.Int32, pItem.IdInventario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public InventarioBE Selecciona(int IdEmpresa, int IdInventario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdInventario", DbType.Int32, IdInventario);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InventarioBE Inventario = null;
            while (reader.Read())
            {
                Inventario = new InventarioBE();
                Inventario.IdInventario = Int32.Parse(reader["idInventario"].ToString());
                Inventario.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Inventario.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Inventario.DescTienda = reader["DescTienda"].ToString();
                Inventario.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Inventario.DescAlmacen = reader["DescAlmacen"].ToString();
                Inventario.IdAlmacenPiso = Int32.Parse(reader["IdAlmacenPiso"].ToString());
                Inventario.DescAlmacenPiso = reader["DescAlmacenPiso"].ToString();
                Inventario.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Inventario.CodigoProveedor = reader["codigoProveedor"].ToString();
                Inventario.NombreProducto = reader["nombreProducto"].ToString();
                Inventario.Abreviatura = reader["Abreviatura"].ToString();
                Inventario.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Inventario.Ubicacion = reader["Ubicacion"].ToString();
                Inventario.Observacion = reader["Observacion"].ToString();
                Inventario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Inventario;
        }

        public List<InventarioBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioBE> Inventariolist = new List<InventarioBE>();
            InventarioBE Inventario;
            while (reader.Read())
            {
                Inventario = new InventarioBE();
                Inventario.IdInventario = Int32.Parse(reader["idInventario"].ToString());
                Inventario.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Inventario.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Inventario.DescTienda = reader["DescTienda"].ToString();
                Inventario.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Inventario.DescAlmacen = reader["DescAlmacen"].ToString();
                Inventario.IdAlmacenPiso = Int32.Parse(reader["IdAlmacenPiso"].ToString());
                Inventario.DescAlmacenPiso = reader["DescAlmacenPiso"].ToString();
                Inventario.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Inventario.CodigoProveedor = reader["codigoProveedor"].ToString();
                Inventario.NombreProducto = reader["nombreProducto"].ToString();
                Inventario.Abreviatura = reader["Abreviatura"].ToString();
                Inventario.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Inventario.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Inventario.Ubicacion = reader["Ubicacion"].ToString();
                Inventario.DescVendedor = reader["DescVendedor"].ToString();
                Inventario.ApeNom2 = reader["ApeNom2"].ToString();
                Inventario.Observacion = reader["Observacion"].ToString();
                Inventario.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Inventario.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Inventario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Inventariolist.Add(Inventario);
            }
            reader.Close();
            reader.Dispose();
            return Inventariolist;
        }

        public List<InventarioBE> ListaTodosActivoUsuario(int IdEmpresa, int IdTienda, int IdAlmacen, int IdPersona, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_ListaTodosActivoUsuario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioBE> Inventariolist = new List<InventarioBE>();
            InventarioBE Inventario;
            while (reader.Read())
            {
                Inventario = new InventarioBE();
                Inventario.IdInventario = Int32.Parse(reader["idInventario"].ToString());
                Inventario.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Inventario.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Inventario.DescTienda = reader["DescTienda"].ToString();
                Inventario.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Inventario.DescAlmacen = reader["DescAlmacen"].ToString();
                Inventario.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Inventario.CodigoProveedor = reader["codigoProveedor"].ToString();
                Inventario.NombreProducto = reader["nombreProducto"].ToString();
                Inventario.Abreviatura = reader["Abreviatura"].ToString();
                Inventario.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Inventario.Ubicacion = reader["Ubicacion"].ToString();
                Inventario.Observacion = reader["Observacion"].ToString();
                Inventario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Inventariolist.Add(Inventario);
            }
            reader.Close();
            reader.Dispose();
            return Inventariolist;
        }

        public void ActualizaStockKardex(int IdEmpresa, bool StockCero, DateTime FechaDesdeBulto, DateTime FechaHastaBulto, DateTime FechaDesdeInventario, DateTime FechaHastaInventario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inventario_ActualizaStockKardex");
            dbCommand.CommandTimeout = 500;

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesdeBulto", DbType.DateTime, FechaDesdeBulto);
            db.AddInParameter(dbCommand, "pFechaHastaBulto", DbType.DateTime, FechaHastaBulto);
            db.AddInParameter(dbCommand, "pFechaDesdeInventario", DbType.DateTime, FechaDesdeInventario);
            db.AddInParameter(dbCommand, "pFechaHastaInventario", DbType.DateTime, FechaHastaInventario);
            db.AddInParameter(dbCommand, "pStockCero", DbType.Boolean, StockCero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void InsertaBulto(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InsertaInventarioBulto");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }
        public void InsertaAnaqueles(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InsertaInventarioAnaqueles");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
