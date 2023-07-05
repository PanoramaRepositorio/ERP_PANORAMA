using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaVaciaDL
    {
        public CajaVaciaDL() { }

        public void Inserta(CajaVaciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_Inserta");

            db.AddInParameter(dbCommand, "pIdCajaVacia", DbType.Int32, pItem.IdCajaVacia);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, pItem.IdPiso);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaVaciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaVacia", DbType.Int32, pItem.IdCajaVacia);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, pItem.IdUbicacion);
            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, pItem.IdPiso);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaVaciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_Elimina");

            db.AddInParameter(dbCommand, "pIdCajaVacia", DbType.Int32, pItem.IdCajaVacia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaVaciaBE> ListaTodosActivo(int IdEmpresa, int IdUbicacion, int IdPiso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUbicacion", DbType.Int32, IdUbicacion);
            db.AddInParameter(dbCommand, "pIdPiso", DbType.Int32, IdPiso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaVaciaBE> CajaVacialist = new List<CajaVaciaBE>();
            CajaVaciaBE CajaVacia;
            while (reader.Read())
            {
                CajaVacia = new CajaVaciaBE();
                CajaVacia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaVacia.IdCajaVacia = Int32.Parse(reader["IdCajaVacia"].ToString());
                CajaVacia.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                CajaVacia.DescUbicacion = reader["DescUbicacion"].ToString();
                CajaVacia.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                CajaVacia.DescPiso = reader["descPiso"].ToString();
                CajaVacia.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CajaVacia.CodigoProveedor = reader["CodigoProveedor"].ToString();
                CajaVacia.NombreProducto = reader["NombreProducto"].ToString();
                CajaVacia.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                CajaVacia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                CajaVacia.Observacion = reader["Observacion"].ToString();
                CajaVacia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaVacialist.Add(CajaVacia);
            }
            reader.Close();
            reader.Dispose();
            return CajaVacialist;
        }

        public CajaVaciaBE Selecciona(int IdEmpresa, int IdCajaVacia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCajaVacia", DbType.Int32, IdCajaVacia);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            CajaVaciaBE CajaVacia=null;
            while (reader.Read())
            {
                CajaVacia = new CajaVaciaBE();
                CajaVacia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaVacia.IdCajaVacia = Int32.Parse(reader["IdCajaVacia"].ToString());
                CajaVacia.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                CajaVacia.DescUbicacion = reader["DescUbicacion"].ToString();
                CajaVacia.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                CajaVacia.DescPiso = reader["descPiso"].ToString();
                CajaVacia.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CajaVacia.CodigoProveedor = reader["CodigoProveedor"].ToString();
                CajaVacia.NombreProducto = reader["NombreProducto"].ToString();
                CajaVacia.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                CajaVacia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                CajaVacia.Observacion = reader["Observacion"].ToString();
                CajaVacia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CajaVacia;
        }

        public CajaVaciaBE SeleccionaCodigo(int IdEmpresa, int IdTienda, string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_SeleccionaCodigo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CajaVaciaBE CajaVacia = null;
            while (reader.Read())
            {
                CajaVacia = new CajaVaciaBE();
                CajaVacia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaVacia.IdCajaVacia = Int32.Parse(reader["IdCajaVacia"].ToString());
                CajaVacia.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                CajaVacia.DescUbicacion = reader["DescUbicacion"].ToString();
                CajaVacia.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                CajaVacia.DescPiso = reader["descPiso"].ToString();
                CajaVacia.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CajaVacia.CodigoProveedor = reader["CodigoProveedor"].ToString();
                CajaVacia.NombreProducto = reader["NombreProducto"].ToString();
                CajaVacia.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                CajaVacia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                CajaVacia.Observacion = reader["Observacion"].ToString();
                CajaVacia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return CajaVacia;
        }

        public List<CajaVaciaBE> ListaCodigo(int IdEmpresa, int IdTienda,string CodigoProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_ListaCodigo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, CodigoProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaVaciaBE> CajaVacialist = new List<CajaVaciaBE>();
            CajaVaciaBE CajaVacia;

            while (reader.Read())
            {
                CajaVacia = new CajaVaciaBE();
                CajaVacia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaVacia.IdCajaVacia = Int32.Parse(reader["IdCajaVacia"].ToString());
                CajaVacia.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                CajaVacia.DescUbicacion = reader["DescUbicacion"].ToString();
                CajaVacia.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                CajaVacia.DescPiso = reader["descPiso"].ToString();
                CajaVacia.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CajaVacia.CodigoProveedor = reader["CodigoProveedor"].ToString();
                CajaVacia.NombreProducto = reader["NombreProducto"].ToString();
                CajaVacia.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                CajaVacia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                CajaVacia.Observacion = reader["Observacion"].ToString();
                CajaVacia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaVacialist.Add(CajaVacia);
            }
            reader.Close();
            reader.Dispose();
            return CajaVacialist;
        }

        public List<CajaVaciaBE> ListaIdProducto(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaVacia_ListaIdProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaVaciaBE> CajaVacialist = new List<CajaVaciaBE>();
            CajaVaciaBE CajaVacia;

            while (reader.Read())
            {
                CajaVacia = new CajaVaciaBE();
                CajaVacia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaVacia.IdCajaVacia = Int32.Parse(reader["IdCajaVacia"].ToString());
                CajaVacia.IdUbicacion = Int32.Parse(reader["IdUbicacion"].ToString());
                CajaVacia.DescUbicacion = reader["DescUbicacion"].ToString();
                CajaVacia.IdPiso = Int32.Parse(reader["idPiso"].ToString());
                CajaVacia.DescPiso = reader["descPiso"].ToString();
                CajaVacia.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                CajaVacia.CodigoProveedor = reader["CodigoProveedor"].ToString();
                CajaVacia.NombreProducto = reader["NombreProducto"].ToString();
                CajaVacia.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                CajaVacia.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                CajaVacia.Observacion = reader["Observacion"].ToString();
                CajaVacia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaVacialist.Add(CajaVacia);
            }
            reader.Close();
            reader.Dispose();
            return CajaVacialist;
        }
    }
}