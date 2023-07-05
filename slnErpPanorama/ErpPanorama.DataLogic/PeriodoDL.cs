using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PeriodoDL
    {
        public PeriodoDL() { }

        public void Inserta(PeriodoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Periodo_Inserta");

            db.AddInParameter(dbCommand, "pIdPeriodo", DbType.Int32, pItem.IdPeriodo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(PeriodoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Periodo_Actualiza");

            db.AddInParameter(dbCommand, "pIdPeriodo", DbType.Int32, pItem.IdPeriodo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PeriodoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Periodo_Elimina");

            db.AddInParameter(dbCommand, "pIdPeriodo", DbType.Int32, pItem.IdPeriodo);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PeriodoBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Periodo_ListaTodosActivo");
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PeriodoBE> Periodolist = new List<PeriodoBE>();
            PeriodoBE Periodo;
            while (reader.Read())
            {
                Periodo = new PeriodoBE();
                Periodo.IdPeriodo = Int32.Parse(reader["idPeriodo"].ToString());
                Periodo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Periodo.Mes = Int32.Parse(reader["Mes"].ToString());
                Periodo.NombreMes = reader["NombreMes"].ToString();
                Periodo.Estatus = reader["Estatus"].ToString();
                Periodo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Periodolist.Add(Periodo);
            }
            reader.Close();
            reader.Dispose();
            return Periodolist;
        }

        public PeriodoBE Selecciona(int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Periodo_Selecciona");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PeriodoBE Periodos = null;
            while (reader.Read())
            {
                Periodos = new PeriodoBE();
                Periodos.IdPeriodo = Int32.Parse(reader["IdPeriodo"].ToString());
                Periodos.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Periodos.Mes = Int32.Parse(reader["Mes"].ToString());
                Periodos.NombreMes = reader["NombreMes"].ToString();
                Periodos.Estatus = reader["Estatus"].ToString();
                Periodos.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Periodos;
        }

    }
}
