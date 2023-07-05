using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class UbicacionProductoDL
    {
        public UbicacionProductoDL() { }

        public void Inserta(UbicacionProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdUbicacionProducto", DbType.Int32, pItem.IdUbicacionProducto);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescUbicacion", DbType.String, pItem.DescUbicacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(UbicacionProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdUbicacionProducto", DbType.Int32, pItem.IdUbicacionProducto);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescUbicacion", DbType.String, pItem.DescUbicacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(UbicacionProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdUbicacionProducto", DbType.Int32, pItem.IdUbicacionProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<UbicacionProductoBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbicacionProductoBE> UbicacionProductolist = new List<UbicacionProductoBE>();
            UbicacionProductoBE UbicacionProducto;
            while (reader.Read())
            {
                UbicacionProducto = new UbicacionProductoBE();
                UbicacionProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UbicacionProducto.IdUbicacionProducto = Int32.Parse(reader["IdUbicacionProducto"].ToString());
                UbicacionProducto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                UbicacionProducto.DescTienda = reader["DescTienda"].ToString();
                UbicacionProducto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                UbicacionProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                UbicacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                UbicacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                UbicacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                UbicacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                UbicacionProducto.DescUbicacion = reader["DescUbicacion"].ToString();
                UbicacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UbicacionProductolist.Add(UbicacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return UbicacionProductolist;
        }

        public List<UbicacionProductoBE> ListaCodigo(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_ListaCodigo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
           

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbicacionProductoBE> UbicacionProductolist = new List<UbicacionProductoBE>();
            UbicacionProductoBE UbicacionProducto;
            while (reader.Read())
            {
                UbicacionProducto = new UbicacionProductoBE();
                UbicacionProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UbicacionProducto.IdUbicacionProducto = Int32.Parse(reader["IdUbicacionProducto"].ToString());
                UbicacionProducto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                UbicacionProducto.DescTienda = reader["DescTienda"].ToString();
                UbicacionProducto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                UbicacionProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                UbicacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                UbicacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                UbicacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                UbicacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                UbicacionProducto.DescUbicacion = reader["DescUbicacion"].ToString();
                UbicacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UbicacionProductolist.Add(UbicacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return UbicacionProductolist;
        }

        public List<UbicacionProductoBE> ListaUbicacion(int IdEmpresa, int IdTienda, int IdAlmacen, string DescUbicacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_ListaUbicacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pDescUbicacion", DbType.String, DescUbicacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbicacionProductoBE> UbicacionProductolist = new List<UbicacionProductoBE>();
            UbicacionProductoBE UbicacionProducto;
            while (reader.Read())
            {
                UbicacionProducto = new UbicacionProductoBE();
                UbicacionProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UbicacionProducto.IdUbicacionProducto = Int32.Parse(reader["IdUbicacionProducto"].ToString());
                UbicacionProducto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                UbicacionProducto.DescTienda = reader["DescTienda"].ToString();
                UbicacionProducto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                UbicacionProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                UbicacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                UbicacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                UbicacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                UbicacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                UbicacionProducto.DescUbicacion = reader["DescUbicacion"].ToString();
                UbicacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UbicacionProductolist.Add(UbicacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return UbicacionProductolist;
        }

        public List<UbicacionProductoBE> SeleccionaBusqueda(int IdEmpresa, int IdTienda, int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_SeleccionaBus");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbicacionProductoBE> UbicacionProductolist = new List<UbicacionProductoBE>();
            UbicacionProductoBE UbicacionProducto;
            while (reader.Read())
            {
                UbicacionProducto = new UbicacionProductoBE();
                UbicacionProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UbicacionProducto.IdUbicacionProducto = Int32.Parse(reader["IdUbicacionProducto"].ToString());
                UbicacionProducto.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                UbicacionProducto.DescTienda = reader["DescTienda"].ToString();
                UbicacionProducto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                UbicacionProducto.DescAlmacen = reader["DescAlmacen"].ToString();
                UbicacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                UbicacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                UbicacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                UbicacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                UbicacionProducto.DescUbicacion = reader["DescUbicacion"].ToString();
                UbicacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UbicacionProductolist.Add(UbicacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return UbicacionProductolist;
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTienda, int IdAlmacen, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UbicacionProducto_SeleccionaBusCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }
    }
}
