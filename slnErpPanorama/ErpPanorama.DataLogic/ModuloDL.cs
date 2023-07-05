using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ModuloDL
    {
        public ModuloDL() { }

        public void Inserta(ModuloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Modulo_Inserta");

            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescModulo", DbType.String, pItem.DescModulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ModuloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Modulo_Actualiza");

            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescModulo", DbType.String, pItem.DescModulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ModuloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Modulo_Elimina");

            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ModuloBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Modulo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloBE> Modulolist = new List<ModuloBE>();
            ModuloBE Modulo;
            while (reader.Read())
            {
                Modulo = new ModuloBE();
                Modulo.IdModulo = Int32.Parse(reader["idModulo"].ToString());
                Modulo.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Modulo.DescModulo = reader["descModulo"].ToString();
                Modulo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Modulolist.Add(Modulo);
            }
            reader.Close();
            reader.Dispose();
            return Modulolist;
        }
    }
}

