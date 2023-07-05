using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class TurnoDL
	{
		public TurnoDL() { }

		public Int32 Inserta(TurnoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Turno_Inserta");

			db.AddOutParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescTurno", DbType.String, pItem.DescTurno);
			db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
			db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdTurno");

			return Id;
		}

		public void Actualiza(TurnoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Turno_Actualiza");

			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescTurno", DbType.String, pItem.DescTurno);
			db.AddInParameter(dbCommand, "pTotalHorasRef", DbType.Decimal, pItem.TotalHorasRef);
			db.AddInParameter(dbCommand, "pTotalHorasTrab", DbType.Decimal, pItem.TotalHorasTrab);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(TurnoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Turno_Elimina");

			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<TurnoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Turno_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<TurnoBE> Turnolist = new List<TurnoBE>();
			TurnoBE Turno;
			while (reader.Read())
			{
				Turno = new TurnoBE();
				Turno.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
				Turno.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				Turno.DescTurno = reader["DescTurno"].ToString();
				Turno.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
				Turno.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
				Turno.Observacion = reader["Observacion"].ToString();
				Turno.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//Turno.IdTurno = reader.IsDBNull(reader.GetOrdinal("IdTurno")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTurno"));
				Turnolist.Add(Turno);
			}
			reader.Close();
			reader.Dispose();
			return Turnolist;
		}

		public TurnoBE Selecciona(int IdTurno)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Turno_Selecciona");
			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, IdTurno);

			IDataReader reader = db.ExecuteReader(dbCommand);
			TurnoBE Turno = null;
			while (reader.Read())
			{
				Turno = new TurnoBE();
				Turno.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
				Turno.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				Turno.DescTurno = reader["DescTurno"].ToString();
				Turno.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
				Turno.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
				Turno.Observacion = reader["Observacion"].ToString();
				Turno.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//Turno.IdTurno = reader.IsDBNull(reader.GetOrdinal("IdTurno")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTurno"));
			}
			reader.Close();
			reader.Dispose();
			return Turno;
		}

	}
}
