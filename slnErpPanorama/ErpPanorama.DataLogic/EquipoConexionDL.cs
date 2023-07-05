using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EquipoConexionDL
    {
        public EquipoConexionDL() { }

        public void Inserta(EquipoConexionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoConexion_Inserta");

            db.AddInParameter(dbCommand, "pIdEquipoConexion", DbType.Int32, pItem.IdEquipoConexion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pHostName", DbType.String, pItem.HostName);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pIp", DbType.String, pItem.Ip);
            db.AddInParameter(dbCommand, "pUsuarioERP", DbType.String, pItem.UsuarioERP);
            db.AddInParameter(dbCommand, "pVersionERP", DbType.String, pItem.VersionERP);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EquipoConexionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoConexion_Actualiza");

            db.AddInParameter(dbCommand, "pIdEquipoConexion", DbType.Int32, pItem.IdEquipoConexion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pHostName", DbType.String, pItem.HostName);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pIp", DbType.String, pItem.Ip);
            db.AddInParameter(dbCommand, "pUsuarioERP", DbType.String, pItem.UsuarioERP);
            db.AddInParameter(dbCommand, "pVersionERP", DbType.String, pItem.VersionERP);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EquipoConexionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoConexion_Elimina");

            db.AddInParameter(dbCommand, "pIdEquipoConexion", DbType.Int32, pItem.IdEquipoConexion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EquipoConexionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoConexion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoConexionBE> EquipoConexionlist = new List<EquipoConexionBE>();
            EquipoConexionBE EquipoConexion;
            while (reader.Read())
            {
                EquipoConexion = new EquipoConexionBE();
                EquipoConexion.IdEquipoConexion = Int32.Parse(reader["idEquipoConexion"].ToString());
                EquipoConexion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                EquipoConexion.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                EquipoConexion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EquipoConexion.HostName = reader["HostName"].ToString();
                EquipoConexion.Mac = reader["Mac"].ToString();
                EquipoConexion.Ip = reader["Ip"].ToString();
                EquipoConexion.Usuario = reader["Usuario"].ToString();
                EquipoConexion.UsuarioERP = reader["UsuarioERP"].ToString();
                EquipoConexion.VersionERP = reader["VersionERP"].ToString();
                EquipoConexion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                EquipoConexionlist.Add(EquipoConexion);
            }
            reader.Close();
            reader.Dispose();
            return EquipoConexionlist;
        }

        public EquipoConexionBE Selecciona(int IdEquipoConexion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EquipoConexion_SeleccionaUltimoEquipoConexion");
            db.AddInParameter(dbCommand, "pIdEquipoConexion", DbType.Int32, IdEquipoConexion);
            IDataReader reader = db.ExecuteReader(dbCommand);
           
            EquipoConexionBE EquipoConexion=null;
            while (reader.Read())
            {
                EquipoConexion = new EquipoConexionBE();
                EquipoConexion.IdEquipoConexion = Int32.Parse(reader["idEquipoConexion"].ToString());
                EquipoConexion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                EquipoConexion.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                EquipoConexion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EquipoConexion.HostName = reader["HostName"].ToString();
                EquipoConexion.Mac = reader["Mac"].ToString();
                EquipoConexion.Ip = reader["Ip"].ToString();
                EquipoConexion.Usuario = reader["Usuario"].ToString();
                EquipoConexion.UsuarioERP = reader["UsuarioERP"].ToString();
                EquipoConexion.VersionERP = reader["VersionERP"].ToString();
                EquipoConexion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EquipoConexion;
        }
    }
}
