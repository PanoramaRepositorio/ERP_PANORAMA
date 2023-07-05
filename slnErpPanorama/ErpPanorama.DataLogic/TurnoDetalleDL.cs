using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class TurnoDetalleDL
	{
		public TurnoDetalleDL() { }

		public Int32 Inserta(TurnoDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TurnoDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdTurnoDetalle", DbType.Int32, pItem.IdTurnoDetalle);
			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pDiaSemana", DbType.Int32, pItem.DiaSemana);
			db.AddInParameter(dbCommand, "pHoraIngreso", DbType.DateTime, pItem.HoraIngreso);
			db.AddInParameter(dbCommand, "pHoraSalidaRef", DbType.DateTime, pItem.HoraSalidaRef);
			db.AddInParameter(dbCommand, "pHoraIngresoRef", DbType.DateTime, pItem.HoraIngresoRef);
			db.AddInParameter(dbCommand, "pHoraSalida", DbType.DateTime, pItem.HoraSalida);
			db.AddInParameter(dbCommand, "pHorasRef", DbType.Decimal, pItem.HorasRef);
			db.AddInParameter(dbCommand, "pHorasTrab", DbType.Decimal, pItem.HorasTrab);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdTurnoDetalle");

			return Id;
		}

		public void Actualiza(TurnoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TurnoDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdTurnoDetalle", DbType.Int32, pItem.IdTurnoDetalle);
			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, pItem.IdTurno);
			db.AddInParameter(dbCommand, "pDiaSemana", DbType.Int32, pItem.DiaSemana);
			db.AddInParameter(dbCommand, "pHoraIngreso", DbType.DateTime, pItem.HoraIngreso);
			db.AddInParameter(dbCommand, "pHoraSalidaRef", DbType.DateTime, pItem.HoraSalidaRef);
			db.AddInParameter(dbCommand, "pHoraIngresoRef", DbType.DateTime, pItem.HoraIngresoRef);
			db.AddInParameter(dbCommand, "pHoraSalida", DbType.DateTime, pItem.HoraSalida);
			db.AddInParameter(dbCommand, "pHorasRef", DbType.Decimal, pItem.HorasRef);
			db.AddInParameter(dbCommand, "pHorasTrab", DbType.Decimal, pItem.HorasTrab);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(TurnoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TurnoDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdTurnoDetalle", DbType.Int32, pItem.IdTurnoDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<TurnoDetalleBE> ListaTodosActivo(int IdTurno)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TurnoDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdTurno", DbType.Int32, IdTurno);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<TurnoDetalleBE> TurnoDetallelist = new List<TurnoDetalleBE>();
			TurnoDetalleBE TurnoDetalle;
			while (reader.Read())
			{
				TurnoDetalle = new TurnoDetalleBE();
				TurnoDetalle.IdTurnoDetalle = Int32.Parse(reader["IdTurnoDetalle"].ToString());
				TurnoDetalle.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
				TurnoDetalle.DiaSemana = Int32.Parse(reader["DiaSemana"].ToString());
				TurnoDetalle.DiaSemanaName = reader["DiaSemanaName"].ToString();
				TurnoDetalle.HoraIngreso = DateTime.Parse(reader["HoraIngreso"].ToString());
				TurnoDetalle.HoraSalidaRef = DateTime.Parse(reader["HoraSalidaRef"].ToString());
				TurnoDetalle.HoraIngresoRef = DateTime.Parse(reader["HoraIngresoRef"].ToString());
				TurnoDetalle.HoraSalida = DateTime.Parse(reader["HoraSalida"].ToString());
				TurnoDetalle.HorasRef = Decimal.Parse(reader["HorasRef"].ToString());
				TurnoDetalle.HorasTrab = Decimal.Parse(reader["HorasTrab"].ToString());
				TurnoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//TurnoDetalle.IdTurnoDetalle = reader.IsDBNull(reader.GetOrdinal("IdTurnoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTurnoDetalle"));
				TurnoDetallelist.Add(TurnoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return TurnoDetallelist;
		}


		public List<TurnoDetalleBE> ListaFormato()
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TurnoDetalle_ListaFormato");

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<TurnoDetalleBE> TurnoDetallelist = new List<TurnoDetalleBE>();
			TurnoDetalleBE TurnoDetalle;
			while (reader.Read())
			{
				TurnoDetalle = new TurnoDetalleBE();
				TurnoDetalle.IdTurnoDetalle = Int32.Parse(reader["IdTurnoDetalle"].ToString());
				TurnoDetalle.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
				TurnoDetalle.DiaSemana = Int32.Parse(reader["DiaSemana"].ToString());
				TurnoDetalle.DiaSemanaName = reader["DiaSemanaName"].ToString();
				TurnoDetalle.HoraIngreso = DateTime.Parse(reader["HoraIngreso"].ToString());
				TurnoDetalle.HoraSalidaRef = DateTime.Parse(reader["HoraSalidaRef"].ToString());
				TurnoDetalle.HoraIngresoRef = DateTime.Parse(reader["HoraIngresoRef"].ToString());
				TurnoDetalle.HoraSalida = DateTime.Parse(reader["HoraSalida"].ToString());
				TurnoDetalle.HorasRef = Decimal.Parse(reader["HorasRef"].ToString());
				TurnoDetalle.HorasTrab = Decimal.Parse(reader["HorasTrab"].ToString());
				TurnoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//TurnoDetalle.IdTurnoDetalle = reader.IsDBNull(reader.GetOrdinal("IdTurnoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTurnoDetalle"));
				TurnoDetallelist.Add(TurnoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return TurnoDetallelist;
		}

		public TurnoDetalleBE Selecciona(int IdTurnoDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TurnoDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdTurnoDetalle", DbType.Int32, IdTurnoDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			TurnoDetalleBE TurnoDetalle = null;
			while (reader.Read())
			{
				TurnoDetalle = new TurnoDetalleBE();
				TurnoDetalle.IdTurnoDetalle = Int32.Parse(reader["IdTurnoDetalle"].ToString());
				TurnoDetalle.IdTurno = Int32.Parse(reader["IdTurno"].ToString());
				TurnoDetalle.DiaSemana = Int32.Parse(reader["DiaSemana"].ToString());
				TurnoDetalle.DiaSemanaName = reader["DiaSemanaName"].ToString();
				TurnoDetalle.HoraIngreso = DateTime.Parse(reader["HoraIngreso"].ToString());
				TurnoDetalle.HoraSalidaRef = DateTime.Parse(reader["HoraSalidaRef"].ToString());
				TurnoDetalle.HoraIngresoRef = DateTime.Parse(reader["HoraIngresoRef"].ToString());
				TurnoDetalle.HoraSalida = DateTime.Parse(reader["HoraSalida"].ToString());
				TurnoDetalle.HorasRef = Decimal.Parse(reader["HorasRef"].ToString());
				TurnoDetalle.HorasTrab = Decimal.Parse(reader["HorasTrab"].ToString());
				TurnoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//TurnoDetalle.IdTurnoDetalle = reader.IsDBNull(reader.GetOrdinal("IdTurnoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTurnoDetalle"));
			}
			reader.Close();
			reader.Dispose();
			return TurnoDetalle;
		}

	}
}
