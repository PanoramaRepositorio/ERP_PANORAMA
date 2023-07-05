using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PerfilDL
    {
        public PerfilDL() { }

        public Int32 Inserta(PerfilBE pItem)
        {
            Int32 intIdPerfil = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Perfil_Inserta");

            db.AddOutParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pDescPerfil", DbType.String, pItem.DescPerfil);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

            intIdPerfil = (int)db.GetParameterValue(dbCommand, "pIdPerfil");

            return intIdPerfil;
        }

        public void Actualiza(PerfilBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Perfil_Actualiza");

            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pDescPerfil", DbType.String, pItem.DescPerfil);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PerfilBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Perfil_Elimina");

            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaUsuario(PerfilBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Perfil_ActualizaUsuario");

            db.AddInParameter(dbCommand, "pIdPerfil", DbType.Int32, pItem.IdPerfil);
            db.AddInParameter(dbCommand, "pDescPerfil", DbType.String, pItem.DescPerfil);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public PerfilBE Selecciona(int idPerfil)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Perfil_Selecciona");
            db.AddInParameter(dbCommand, "pidPerfil", DbType.Int32, idPerfil);
            IDataReader reader = db.ExecuteReader(dbCommand);
            PerfilBE perfil = null;
            while (reader.Read())
            {
                perfil = new PerfilBE();
                perfil.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                perfil.DescPerfil = reader["descperfil"].ToString();
                perfil.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return perfil;
        }

        public List<PerfilBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Perfil_ListaTodosActivo");
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PerfilBE> perfillist = new List<PerfilBE>();
            PerfilBE perfil;
            while (reader.Read())
            {
                perfil = new PerfilBE();
                perfil.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                perfil.DescPerfil = reader["descperfil"].ToString();
                perfil.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                perfillist.Add(perfil);
            }
            reader.Close();
            reader.Dispose();
            return perfillist;
        }
    }
}
