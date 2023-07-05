using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class UsuarioDL
    {
        public UsuarioDL() { }

        public Int32 Inserta(UsuarioBE pItem)
        {
            Int32 intIdUser = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_Inserta");

            db.AddOutParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, pItem.Password);
            db.AddInParameter(dbCommand, "pFlagMaster", DbType.Boolean, pItem.FlagMaster);
            db.AddInParameter(dbCommand, "pFlagAutorizaEliminaDocumentoVenta", DbType.Boolean, pItem.FlagAutorizaEliminaDocumentoVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuarioCrea", DbType.String, pItem.UsuarioCrea);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdUser = (int)db.GetParameterValue(dbCommand, "pIdUser");

            return intIdUser;
        }

        public void Actualiza(UsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_Actualiza");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, pItem.Password);
            db.AddInParameter(dbCommand, "pFlagMaster", DbType.Boolean, pItem.FlagMaster);
            db.AddInParameter(dbCommand, "pFlagAutorizaEliminaDocumentoVenta", DbType.Boolean, pItem.FlagAutorizaEliminaDocumentoVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuarioCrea", DbType.String, pItem.UsuarioCrea);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            
        }

        public void ActualizaEmpresa(UsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_ActualizaEmpresa");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);

            db.ExecuteNonQuery(dbCommand);
        }


        public void ActualizaPassword(UsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_ActualizaPassword");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, pItem.Password);
            db.AddInParameter(dbCommand, "pUsuarioCrea", DbType.String, pItem.UsuarioCrea);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }



        public void Elimina(UsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_Elimina");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);


        }

        public UsuarioBE Selecciona(int idUsuario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_Selecciona");
            db.AddInParameter(dbCommand, "piduser", DbType.Int32, idUsuario);
            IDataReader reader = db.ExecuteReader(dbCommand);
            UsuarioBE usuario = null;
            while (reader.Read())
            {
                usuario = new UsuarioBE();
                usuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                usuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                usuario.DescPerfil = reader["descperfil"].ToString();
                usuario.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                usuario.RazonSocial = reader["RazonSocial"].ToString();
                usuario.IdPersona = Int32.Parse(reader["idpersona"].ToString());
                usuario.Usuario = reader["usuario"].ToString();
                usuario.Descripcion = reader["descripcion"].ToString();
                usuario.Password = reader["password"].ToString();
                usuario.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                usuario.FlagAutorizaEliminaDocumentoVenta = Boolean.Parse(reader["FlagAutorizaEliminaDocumentoVenta"].ToString());
                usuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return usuario;
        }

        public UsuarioBE SeleccionaUsuario(string Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_SeleccionaUsuario");
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            IDataReader reader = db.ExecuteReader(dbCommand);
            UsuarioBE usuario = null;
            while (reader.Read())
            {
                usuario = new UsuarioBE();
                usuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                usuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                usuario.DescPerfil = reader["descperfil"].ToString();
                usuario.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                usuario.RazonSocial = reader["RazonSocial"].ToString();
                usuario.IdPersona = Int32.Parse(reader["idpersona"].ToString());
                usuario.Usuario = reader["usuario"].ToString();
                usuario.Descripcion = reader["descripcion"].ToString();
                usuario.Password = reader["password"].ToString();
                usuario.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                usuario.FlagAutorizaEliminaDocumentoVenta = Boolean.Parse(reader["FlagAutorizaEliminaDocumentoVenta"].ToString());
                usuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return usuario;
        }

        public UsuarioBE LogOnUser(string Usuario, string Password)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_LogOn");
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            db.AddInParameter(dbCommand, "pPassword", DbType.String, Password);
            IDataReader reader = db.ExecuteReader(dbCommand);
            UsuarioBE usuario = null;
            while (reader.Read())
            {
                usuario = new UsuarioBE();
                usuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                usuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                usuario.DescPerfil = reader["descperfil"].ToString();
                usuario.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                usuario.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                usuario.DescTienda = reader["DescTienda"].ToString();
                usuario.IdPersona = Int32.Parse(reader["idpersona"].ToString());
                usuario.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                usuario.Usuario = reader["usuario"].ToString();
                usuario.Descripcion = reader["descripcion"].ToString();
                usuario.Password = reader["password"].ToString();
                usuario.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                usuario.FlagAutorizaEliminaDocumentoVenta = Boolean.Parse(reader["FlagAutorizaEliminaDocumentoVenta"].ToString());
                usuario.DB = reader["DB"].ToString();
                usuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return usuario;
        }

        public List<UsuarioBE> SeleccionaEmpresa(int IdEmpresa, string Descripcion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_SeleccionaEmpresa");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, Descripcion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UsuarioBE> usuariolist = new List<UsuarioBE>();
            UsuarioBE usuario;
            while (reader.Read())
            {
                usuario = new UsuarioBE();
                usuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                usuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                usuario.DescPerfil = reader["nomperfil"].ToString();
                usuario.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                usuario.RazonSocial = reader["RazonSocial"].ToString();
                usuario.IdPersona = Int32.Parse(reader["idpersona"].ToString());
                usuario.Usuario = reader["usuario"].ToString();
                usuario.Descripcion = reader["descripcion"].ToString();
                usuario.Password = reader["password"].ToString();
                usuario.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                usuario.FlagAutorizaEliminaDocumentoVenta = Boolean.Parse(reader["FlagAutorizaEliminaDocumentoVenta"].ToString());
                usuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                usuariolist.Add(usuario);
            }
            reader.Close();
            reader.Dispose();
            return usuariolist;
        }

        public List<UsuarioBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Usuario_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UsuarioBE> usuariolist = new List<UsuarioBE>();
            UsuarioBE usuario;
            while (reader.Read())
            {
                usuario = new UsuarioBE();
                usuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                usuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                usuario.DescPerfil = reader["descperfil"].ToString();
                usuario.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                usuario.IdPersona = Int32.Parse(reader["idpersona"].ToString());
                usuario.Usuario = reader["usuario"].ToString();
                usuario.Descripcion = reader["descripcion"].ToString();
                usuario.Password = reader["password"].ToString();
                usuario.FlagMaster = Boolean.Parse(reader["flagmaster"].ToString());
                usuario.FlagAutorizaEliminaDocumentoVenta = Boolean.Parse(reader["FlagAutorizaEliminaDocumentoVenta"].ToString());
                usuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                usuariolist.Add(usuario);
            }
            reader.Close();
            reader.Dispose();
            return usuariolist;
        }

    }
}
