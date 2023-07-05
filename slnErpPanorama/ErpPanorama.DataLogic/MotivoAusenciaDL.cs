using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MotivoAusenciaDL
    {
        public MotivoAusenciaDL() { }

        public void Inserta(MotivoAusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MotivoAusencia_Inserta");

            db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescMotivoAusencia", DbType.String, pItem.DescMotivoAusencia);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MotivoAusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MotivoAusencia_Actualiza");

            db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescMotivoAusencia", DbType.String, pItem.DescMotivoAusencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MotivoAusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MotivoAusencia_Elimina");

            db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MotivoAusenciaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MotivoAusencia_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MotivoAusenciaBE> MotivoAusencialist = new List<MotivoAusenciaBE>();
            MotivoAusenciaBE MotivoAusencia;
            while (reader.Read())
            {
                MotivoAusencia = new MotivoAusenciaBE();
                MotivoAusencia.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MotivoAusencia.IdMotivoAusencia = Int32.Parse(reader["idMotivoAusencia"].ToString());
                MotivoAusencia.DescMotivoAusencia = reader["descMotivoAusencia"].ToString();
                MotivoAusencia.Abreviatura = reader["Abreviatura"].ToString();
                MotivoAusencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MotivoAusencialist.Add(MotivoAusencia);
            }
            reader.Close();
            reader.Dispose();
            return MotivoAusencialist;
        }
    }
}
