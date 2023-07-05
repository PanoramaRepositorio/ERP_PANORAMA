using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InventarioAnaquelesDL
    {
        public void Inserta(InventarioAnaquelesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_Inserta");

            db.AddInParameter(dbCommand, "pIdInventarioAnaqueles", DbType.Int32, pItem.IdInventarioAnaqueles);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
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

        public void Actualiza(InventarioAnaquelesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_Actualiza");

            db.AddInParameter(dbCommand, "pIdInventarioAnaqueles", DbType.Int32, pItem.IdInventarioAnaqueles);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
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

        public void Elimina(InventarioAnaquelesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_Elimina");

            db.AddInParameter(dbCommand, "pIdInventarioAnaqueles", DbType.Int32, pItem.IdInventarioAnaqueles);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public InventarioAnaquelesBE Selecciona(int IdEmpresa, int IdInventarioAnaqueles)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdInventarioAnaqueles", DbType.Int32, IdInventarioAnaqueles);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InventarioAnaquelesBE InventarioAnaqueles = null;
            while (reader.Read())
            {
                InventarioAnaqueles = new InventarioAnaquelesBE();
                InventarioAnaqueles.IdInventarioAnaqueles = Int32.Parse(reader["idInventarioAnaqueles"].ToString());
                InventarioAnaqueles.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InventarioAnaqueles.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioAnaqueles.DescTienda = reader["DescTienda"].ToString();
                InventarioAnaqueles.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                InventarioAnaqueles.DescAlmacen = reader["DescAlmacen"].ToString();
                InventarioAnaqueles.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioAnaqueles.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioAnaqueles.NombreProducto = reader["nombreProducto"].ToString();
                InventarioAnaqueles.Abreviatura = reader["Abreviatura"].ToString();
                InventarioAnaqueles.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioAnaqueles.Ubicacion = reader["Ubicacion"].ToString();
                InventarioAnaqueles.Observacion = reader["Observacion"].ToString();
                InventarioAnaqueles.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return InventarioAnaqueles;
        }

        public InventarioAnaquelesBE SeleccionaProducto(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_SeleccionaProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InventarioAnaquelesBE InventarioAnaqueles = null;
            while (reader.Read())
            {
                InventarioAnaqueles = new InventarioAnaquelesBE();
                InventarioAnaqueles.IdInventarioAnaqueles = Int32.Parse(reader["idInventarioAnaqueles"].ToString());
                InventarioAnaqueles.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InventarioAnaqueles.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioAnaqueles.DescTienda = reader["DescTienda"].ToString();
                InventarioAnaqueles.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                InventarioAnaqueles.DescAlmacen = reader["DescAlmacen"].ToString();
                InventarioAnaqueles.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioAnaqueles.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioAnaqueles.NombreProducto = reader["nombreProducto"].ToString();
                InventarioAnaqueles.Abreviatura = reader["Abreviatura"].ToString();
                InventarioAnaqueles.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioAnaqueles.Ubicacion = reader["Ubicacion"].ToString();
                InventarioAnaqueles.Observacion = reader["Observacion"].ToString();
                InventarioAnaqueles.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return InventarioAnaqueles;
        }

        public List<InventarioAnaquelesBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioAnaquelesBE> InventarioAnaqueleslist = new List<InventarioAnaquelesBE>();
            InventarioAnaquelesBE InventarioAnaqueles;
            while (reader.Read())
            {
                InventarioAnaqueles = new InventarioAnaquelesBE();
                InventarioAnaqueles.IdInventarioAnaqueles = Int32.Parse(reader["idInventarioAnaqueles"].ToString());
                InventarioAnaqueles.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InventarioAnaqueles.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioAnaqueles.DescTienda = reader["DescTienda"].ToString();
                InventarioAnaqueles.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                InventarioAnaqueles.DescAlmacen = reader["DescAlmacen"].ToString();
                InventarioAnaqueles.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioAnaqueles.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioAnaqueles.NombreProducto = reader["nombreProducto"].ToString();
                InventarioAnaqueles.Abreviatura = reader["Abreviatura"].ToString();
                InventarioAnaqueles.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioAnaqueles.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                InventarioAnaqueles.Ubicacion = reader["Ubicacion"].ToString();
                InventarioAnaqueles.DescVendedor = reader["DescVendedor"].ToString();
                InventarioAnaqueles.Observacion = reader["Observacion"].ToString();
                InventarioAnaqueles.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                InventarioAnaqueles.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioAnaqueleslist.Add(InventarioAnaqueles);
            }
            reader.Close();
            reader.Dispose();
            return InventarioAnaqueleslist;
        }

        public List<InventarioAnaquelesBE> ListaTodosActivoUsuario(int IdEmpresa, int IdTienda, int IdAlmacen, int IdPersona, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioAnaqueles_ListaTodosActivoUsuario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioAnaquelesBE> InventarioAnaqueleslist = new List<InventarioAnaquelesBE>();
            InventarioAnaquelesBE InventarioAnaqueles;
            while (reader.Read())
            {
                InventarioAnaqueles = new InventarioAnaquelesBE();
                InventarioAnaqueles.IdInventarioAnaqueles = Int32.Parse(reader["idInventarioAnaqueles"].ToString());
                InventarioAnaqueles.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                InventarioAnaqueles.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioAnaqueles.DescTienda = reader["DescTienda"].ToString();
                InventarioAnaqueles.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                InventarioAnaqueles.DescAlmacen = reader["DescAlmacen"].ToString();
                InventarioAnaqueles.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                InventarioAnaqueles.CodigoProveedor = reader["codigoProveedor"].ToString();
                InventarioAnaqueles.NombreProducto = reader["nombreProducto"].ToString();
                InventarioAnaqueles.Abreviatura = reader["Abreviatura"].ToString();
                InventarioAnaqueles.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                InventarioAnaqueles.Ubicacion = reader["Ubicacion"].ToString();
                InventarioAnaqueles.Observacion = reader["Observacion"].ToString();
                InventarioAnaqueles.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioAnaqueleslist.Add(InventarioAnaqueles);
            }
            reader.Close();
            reader.Dispose();
            return InventarioAnaqueleslist;
        }


    }
}
