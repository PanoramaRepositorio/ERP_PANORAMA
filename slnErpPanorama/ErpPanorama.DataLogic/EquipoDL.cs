using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EquipoDL
    {
        public EquipoDL() { }

        public Int32 Inserta(EquipoBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Inserta");

            db.AddOutParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pHostName", DbType.String, pItem.HostName);
            db.AddInParameter(dbCommand, "pSistemaOperativo", DbType.String, pItem.SistemaOperativo);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFechaCreacion", DbType.DateTime, pItem.FechaCreacion);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);
            db.AddInParameter(dbCommand, "pFechaModificacion", DbType.DateTime, pItem.FechaModificacion);
            db.AddInParameter(dbCommand, "pUsuarioModificacion", DbType.String, pItem.UsuarioModificacion);
            db.AddInParameter(dbCommand, "pFlagAcceso", DbType.Boolean, pItem.FlagAcceso);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdEquipo");

            return Id;
        }

        public void Actualiza(EquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Actualiza");

            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pHostName", DbType.String, pItem.HostName);
            db.AddInParameter(dbCommand, "pSistemaOperativo", DbType.String, pItem.SistemaOperativo);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFechaCreacion", DbType.DateTime, pItem.FechaCreacion);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);
            db.AddInParameter(dbCommand, "pFechaModificacion", DbType.DateTime, pItem.FechaModificacion);
            db.AddInParameter(dbCommand, "pUsuarioModificacion", DbType.String, pItem.UsuarioModificacion);
            db.AddInParameter(dbCommand, "pFlagAcceso", DbType.Boolean, pItem.FlagAcceso);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Elimina");

            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EquipoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoBE> Equipolist = new List<EquipoBE>();
            EquipoBE Equipo;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Equipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Equipo.RazonSocial = reader["RazonSocial"].ToString();
                Equipo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Equipo.DescTienda = reader["DescTienda"].ToString();
                Equipo.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Equipo.DescAlmacen = reader["DescAlmacen"].ToString();
                Equipo.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Equipo.DescCaja = reader["DescCaja"].ToString();
                Equipo.HostName = reader["HostName"].ToString();
                Equipo.SistemaOperativo = reader["SistemaOperativo"].ToString();
                Equipo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Equipo.IdEquipoConexion = reader.IsDBNull(reader.GetOrdinal("IdEquipoConexion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdEquipoConexion"));
                Equipo.FechaCreacion = reader.IsDBNull(reader.GetOrdinal("FechaCreacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCreacion"));
                Equipo.UsuarioCreacion = reader["UsuarioCreacion"].ToString();
                Equipo.FechaModificacion = reader.IsDBNull(reader.GetOrdinal("FechaModificacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModificacion"));
                Equipo.UsuarioModificacion = reader["UsuarioModificacion"].ToString();
                //Equipo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Equipo.FechaConexion = reader.IsDBNull(reader.GetOrdinal("FechaConexion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaConexion"));
                Equipo.Mac = reader["Mac"].ToString();
                Equipo.Ip = reader["Ip"].ToString();
                Equipo.Usuario = reader["Usuario"].ToString();
                Equipo.UsuarioERP = reader["UsuarioERP"].ToString();
                Equipo.VersionERP = reader["VersionERP"].ToString();
                Equipo.FlagAcceso = Boolean.Parse(reader["FlagAcceso"].ToString());
                Equipo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Equipolist.Add(Equipo);
            }
            reader.Close();
            reader.Dispose();
            return Equipolist;
        }

        public List<EquipoBE> ListaTodosConexion(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_ListaTodosConexion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoBE> Equipolist = new List<EquipoBE>();
            EquipoBE Equipo;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Equipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Equipo.RazonSocial = reader["RazonSocial"].ToString();
                Equipo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Equipo.DescTienda = reader["DescTienda"].ToString();
                Equipo.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Equipo.DescAlmacen = reader["DescAlmacen"].ToString();
                Equipo.HostName = reader["HostName"].ToString();
                Equipo.SistemaOperativo = reader["SistemaOperativo"].ToString();
                Equipo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Equipo.IdEquipoConexion = reader.IsDBNull(reader.GetOrdinal("IdEquipoConexion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdEquipoConexion"));
                Equipo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Equipo.Mac = reader["Mac"].ToString();
                Equipo.Ip = reader["Ip"].ToString();
                Equipo.Usuario = reader["Usuario"].ToString();
                Equipo.UsuarioERP = reader["UsuarioERP"].ToString();
                Equipo.VersionERP = reader["VersionERP"].ToString();
                Equipo.FlagAcceso = Boolean.Parse(reader["FlagAcceso"].ToString());
                Equipo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Equipolist.Add(Equipo);
            }
            reader.Close();
            reader.Dispose();
            return Equipolist;
        }

        public List<EquipoBE> ListaCaja(int IdEmpresa, int IdTienda, int IdEquipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_ListaCaja");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, IdEquipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoBE> Equipolist = new List<EquipoBE>();
            EquipoBE Equipo;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Equipo.DescCaja = reader["DescCaja"].ToString();
                Equipolist.Add(Equipo);
            }
            reader.Close();
            reader.Dispose();
            return Equipolist;
        }

        public EquipoBE Selecciona(int IdEquipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Selecciona");
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, IdEquipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EquipoBE Equipo = null;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Equipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Equipo.RazonSocial = reader["RazonSocial"].ToString();
                Equipo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Equipo.DescTienda = reader["DescTienda"].ToString();
                Equipo.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Equipo.DescAlmacen = reader["DescAlmacen"].ToString();
                Equipo.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Equipo.DescCaja = reader["DescCaja"].ToString();
                Equipo.HostName = reader["HostName"].ToString();
                Equipo.SistemaOperativo = reader["SistemaOperativo"].ToString();
                Equipo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Equipo.FechaCreacion = reader.IsDBNull(reader.GetOrdinal("FechaCreacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCreacion"));
                Equipo.UsuarioCreacion = reader["UsuarioCreacion"].ToString();
                Equipo.FechaModificacion = reader.IsDBNull(reader.GetOrdinal("FechaModificacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModificacion"));
                Equipo.UsuarioModificacion = reader["UsuarioModificacion"].ToString();
                Equipo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Equipo.Mac = reader["Mac"].ToString();
                Equipo.Ip = reader["Ip"].ToString();
                Equipo.Usuario = reader["Usuario"].ToString();
                Equipo.UsuarioERP = reader["UsuarioERP"].ToString();
                Equipo.VersionERP = reader["VersionERP"].ToString();
                Equipo.FlagAcceso = Boolean.Parse(reader["FlagAcceso"].ToString());
                Equipo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Equipo;
        }

        public EquipoBE SeleccionaHostName(string HostName)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_SeleccionaHostName");
            db.AddInParameter(dbCommand, "pHostName", DbType.String, HostName);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EquipoBE Equipo = null;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                Equipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Equipo.RazonSocial = reader["RazonSocial"].ToString();
                Equipo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Equipo.DescTienda = reader["DescTienda"].ToString();
                Equipo.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Equipo.DescAlmacen = reader["DescAlmacen"].ToString();
                Equipo.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Equipo.DescCaja = reader["DescCaja"].ToString();
                Equipo.HostName = reader["HostName"].ToString();
                Equipo.SistemaOperativo = reader["SistemaOperativo"].ToString();
                Equipo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Equipo.IdEquipoConexion = reader.IsDBNull(reader.GetOrdinal("IdEquipoConexion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdEquipoConexion"));
                Equipo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Equipo.Mac = reader["Mac"].ToString();
                Equipo.Ip = reader["Ip"].ToString();
                Equipo.Usuario = reader["Usuario"].ToString();
                Equipo.UsuarioERP = reader["UsuarioERP"].ToString();
                Equipo.VersionERP = reader["VersionERP"].ToString();
                Equipo.FlagAcceso = Boolean.Parse(reader["FlagAcceso"].ToString());
                Equipo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Equipo;
        }

    }
}
