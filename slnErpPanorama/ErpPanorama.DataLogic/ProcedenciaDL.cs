using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProcedenciaDL
    {
        public ProcedenciaDL() { }

        public void Inserta(ProcedenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Procedencia_Inserta");

            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescProcedencia", DbType.String, pItem.DescProcedencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ProcedenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Procedencia_Actualiza");

            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescProcedencia", DbType.String, pItem.DescProcedencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProcedenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Procedencia_Elimina");

            db.AddInParameter(dbCommand, "pIdProcedencia", DbType.Int32, pItem.IdProcedencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProcedenciaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Procedencia_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProcedenciaBE> Procedencialist = new List<ProcedenciaBE>();
            ProcedenciaBE Procedencia;
            while (reader.Read())
            {
                Procedencia = new ProcedenciaBE();
                Procedencia.IdProcedencia = Int32.Parse(reader["idProcedencia"].ToString());
                Procedencia.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Procedencia.DescProcedencia = reader["descProcedencia"].ToString();
                Procedencia.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Procedencialist.Add(Procedencia);
            }
            reader.Close();
            reader.Dispose();
            return Procedencialist;
        }
    }
}
