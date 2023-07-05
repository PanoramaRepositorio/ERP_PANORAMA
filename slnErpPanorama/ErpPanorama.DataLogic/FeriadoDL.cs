using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class FeriadoDL
	{
		public FeriadoDL() { }

		public Int32 Inserta(FeriadoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Feriado_Inserta");

			db.AddOutParameter(dbCommand, "pIdFeriado", DbType.Int32, pItem.IdFeriado);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pDescFeriado", DbType.String, pItem.DescFeriado);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdFeriado");

			return Id;
		}

		public void Actualiza(FeriadoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Feriado_Actualiza");

			db.AddInParameter(dbCommand, "pIdFeriado", DbType.Int32, pItem.IdFeriado);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pDescFeriado", DbType.String, pItem.DescFeriado);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(FeriadoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Feriado_Elimina");

			db.AddInParameter(dbCommand, "pIdFeriado", DbType.Int32, pItem.IdFeriado);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<FeriadoBE> ListaTodosActivo(int Periodo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Feriado_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<FeriadoBE> Feriadolist = new List<FeriadoBE>();
			FeriadoBE Feriado;
			while (reader.Read())
			{
				Feriado = new FeriadoBE();
				Feriado.IdFeriado = Int32.Parse(reader["IdFeriado"].ToString());
				Feriado.Periodo = Int32.Parse(reader["Periodo"].ToString());
				Feriado.Mes = Int32.Parse(reader["Mes"].ToString());
                Feriado.DescMes = reader["DescMes"].ToString();
                Feriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				Feriado.DescFeriado = reader["DescFeriado"].ToString();
				Feriado.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				Feriadolist.Add(Feriado);
			}
			reader.Close();
			reader.Dispose();
			return Feriadolist;
		}

		public FeriadoBE Selecciona(int IdFeriado)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Feriado_Selecciona");
			db.AddInParameter(dbCommand, "pIdFeriado", DbType.Int32, IdFeriado);

			IDataReader reader = db.ExecuteReader(dbCommand);
			FeriadoBE Feriado = null;
			while (reader.Read())
			{
				Feriado = new FeriadoBE();
				Feriado.IdFeriado = Int32.Parse(reader["IdFeriado"].ToString());
				Feriado.Periodo = Int32.Parse(reader["Periodo"].ToString());
				Feriado.Mes = Int32.Parse(reader["Mes"].ToString());
                Feriado.DescMes = reader["DescMes"].ToString();
                Feriado.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				Feriado.DescFeriado = reader["DescFeriado"].ToString();
				Feriado.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return Feriado;
		}

	}
}
