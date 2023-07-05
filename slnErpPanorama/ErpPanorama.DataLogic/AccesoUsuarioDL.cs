using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AccesoUsuarioDL
    {
        public AccesoUsuarioDL() { }

        public void Inserta(AccesoUsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_Inserta");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pFlagLectura", DbType.Boolean, pItem.FlagLectura);
            db.AddInParameter(dbCommand, "pFlagAdicion", DbType.Boolean, pItem.FlagAdicion);
            db.AddInParameter(dbCommand, "pFlagActualizacion", DbType.Boolean, pItem.FlagActualizacion);
            db.AddInParameter(dbCommand, "pFlagEliminacion", DbType.Boolean, pItem.FlagEliminacion);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Boolean, pItem.FlagImpresion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AccesoUsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_Actualiza");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pFlagLectura", DbType.Boolean, pItem.FlagLectura);
            db.AddInParameter(dbCommand, "pFlagAdicion", DbType.Boolean, pItem.FlagAdicion);
            db.AddInParameter(dbCommand, "pFlagActualizacion", DbType.Boolean, pItem.FlagActualizacion);
            db.AddInParameter(dbCommand, "pFlagEliminacion", DbType.Boolean, pItem.FlagEliminacion);
            db.AddInParameter(dbCommand, "pFlagImpresion", DbType.Boolean, pItem.FlagImpresion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AccesoUsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_Elimina");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pIdMenu", DbType.Int32, pItem.IdMenu);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void InsertaPorPerfil(AccesoUsuarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_InsertaPorPerfil");

            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AccesoUsuarioBE> SeleccionaCriterioVarios(int IdUser, int IdPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_SeleccionaUserPerfil");
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, IdPerfil);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoUsuarioBE> accesousuariolist = new List<AccesoUsuarioBE>();
            AccesoUsuarioBE accesousuario;
            while (reader.Read())
            {
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                accesousuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                accesousuario.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                accesousuario.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                accesousuario.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                accesousuario.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                accesousuario.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                accesousuario.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                accesousuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                accesousuariolist.Add(accesousuario);
            }
            reader.Close();
            reader.Dispose();
            return accesousuariolist;
        }

        public List<AccesoUsuarioBE> SeleccionaUser(int IdUser)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_SeleccionaUser");
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, IdUser);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoUsuarioBE> accesousuariolist = new List<AccesoUsuarioBE>();
            AccesoUsuarioBE accesousuario;
            while (reader.Read())
            {
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                accesousuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                accesousuario.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                accesousuario.MenuCodigo = reader["menucodigo"].ToString();
                accesousuario.IdMenuPadre = Int32.Parse(reader["idmenupadre"].ToString());
                accesousuario.MenuDescripcion = reader["menudescripcion"].ToString();
                accesousuario.Imagen = reader["imagen"].ToString();
                accesousuario.LargeImage = Boolean.Parse(reader["largeimage"].ToString());
                accesousuario.Clase = reader["clase"].ToString();
                accesousuario.Ensamblado = reader["ensamblado"].ToString();
                accesousuario.IdMenuTipo = Int32.Parse(reader["idmenutipo"].ToString());
                accesousuario.ModoCargaVentana = Byte.Parse(reader["modocargaventana"].ToString());
                accesousuariolist.Add(accesousuario);
            }
            reader.Close();
            reader.Dispose();
            return accesousuariolist;
        }

        public List<AccesoUsuarioBE> SeleccionaPermisoAcceso(string Usuario, int IdPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_SeleccionaPermisoAcceso");
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, IdPerfil);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoUsuarioBE> accesousuariolist = new List<AccesoUsuarioBE>();
            AccesoUsuarioBE accesousuario;
            while (reader.Read())
            {
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                accesousuario.Usuario = reader["usuario"].ToString();
                accesousuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                accesousuario.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                accesousuario.Clase = reader["clase"].ToString();
                accesousuario.Ensamblado = reader["ensamblado"].ToString();
                accesousuario.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                accesousuario.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                accesousuario.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                accesousuario.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                accesousuario.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                accesousuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                accesousuariolist.Add(accesousuario);
            }
            reader.Close();
            reader.Dispose();
            return accesousuariolist;
        }

        public List<AccesoUsuarioBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoUsuarioBE> accesousuariolist = new List<AccesoUsuarioBE>();
            AccesoUsuarioBE accesousuario;
            while (reader.Read())
            {
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                accesousuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                accesousuario.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                accesousuario.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                accesousuario.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                accesousuario.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                accesousuario.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                accesousuario.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                accesousuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                accesousuariolist.Add(accesousuario);
            }
            reader.Close();
            reader.Dispose();
            return accesousuariolist;
        }

        public List<AccesoUsuarioBE> SeleccionaUserPerfil(int IdUser, int IdPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccesoUsuario_SeleccionaUserPerfil");
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, IdUser);
            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, IdPerfil);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccesoUsuarioBE> accesousuariolist = new List<AccesoUsuarioBE>();
            AccesoUsuarioBE accesousuario;
            while (reader.Read())
            {
                accesousuario = new AccesoUsuarioBE();
                accesousuario.IdUser = Int32.Parse(reader["iduser"].ToString());
                accesousuario.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                accesousuario.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                accesousuario.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                accesousuario.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                accesousuario.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                accesousuario.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                accesousuario.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                accesousuario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                accesousuario.TipoOper = 4;
                accesousuariolist.Add(accesousuario);
            }
            reader.Close();
            reader.Dispose();
            return accesousuariolist;
        }
    }
}
