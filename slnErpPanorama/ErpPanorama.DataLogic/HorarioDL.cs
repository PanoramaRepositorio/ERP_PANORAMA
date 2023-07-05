using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class HorarioDL
    {
        public HorarioDL() { }

        public void Inserta(HorarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Horario_Inserta");

            db.AddInParameter(dbCommand, "pIdHorario", DbType.Int32, pItem.IdHorario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescHorario", DbType.String, pItem.DescHorario);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(HorarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Horario_Actualiza");

            db.AddInParameter(dbCommand, "pIdHorario", DbType.Int32, pItem.IdHorario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescHorario", DbType.String, pItem.DescHorario);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(HorarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Horario_Elimina");

            db.AddInParameter(dbCommand, "pIdHorario", DbType.Int32, pItem.IdHorario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public HorarioBE Selecciona(int IdEmpresa, int IdHorario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Horario_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdHorario", DbType.Int32, IdHorario);

            IDataReader reader = db.ExecuteReader(dbCommand);
            HorarioBE Horario = null;
            while (reader.Read())
            {
                Horario = new HorarioBE();
                Horario.IdHorario = Int32.Parse(reader["idHorario"].ToString());
                Horario.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Horario.DescHorario = reader["DescHorario"].ToString();
                Horario.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Horario.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Horario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Horario;
        }

        public List<HorarioBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Horario_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HorarioBE> Horariolist = new List<HorarioBE>();
            HorarioBE Horario;
            while (reader.Read())
            {
                Horario = new HorarioBE();
                Horario.IdHorario = Int32.Parse(reader["idHorario"].ToString());
                Horario.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Horario.DescHorario = reader["DescHorario"].ToString();
                Horario.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Horario.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Horario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Horariolist.Add(Horario);
            }
            reader.Close();
            reader.Dispose();
            return Horariolist;
        }
    }
}
