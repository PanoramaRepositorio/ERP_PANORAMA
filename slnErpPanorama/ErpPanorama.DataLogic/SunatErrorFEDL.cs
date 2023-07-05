using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class SunatErrorFEDL
	{
		public SunatErrorFEDL() { }

		public Int32 Inserta(SunatErrorFEBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatErrorFE_Inserta");

			db.AddOutParameter(dbCommand, "pIdSunatErrorFE", DbType.Int32, pItem.IdSunatErrorFE);
			db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
			db.AddInParameter(dbCommand, "pDescError", DbType.String, pItem.DescError);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdSunatErrorFE");

			return Id;
		}

		public void Actualiza(SunatErrorFEBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatErrorFE_Actualiza");

			db.AddInParameter(dbCommand, "pIdSunatErrorFE", DbType.Int32, pItem.IdSunatErrorFE);
			db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
			db.AddInParameter(dbCommand, "pDescError", DbType.String, pItem.DescError);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(SunatErrorFEBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatErrorFE_Elimina");

			db.AddInParameter(dbCommand, "pIdSunatErrorFE", DbType.Int32, pItem.IdSunatErrorFE);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<SunatErrorFEBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatErrorFE_ListaTodosActivo");

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<SunatErrorFEBE> SunatErrorFElist = new List<SunatErrorFEBE>();
			SunatErrorFEBE SunatErrorFE;
			while (reader.Read())
			{
				SunatErrorFE = new SunatErrorFEBE();
				SunatErrorFE.IdSunatErrorFE = Int32.Parse(reader["IdSunatErrorFE"].ToString());
				SunatErrorFE.Codigo = reader["Codigo"].ToString();
				SunatErrorFE.DescError = reader["DescError"].ToString();
				SunatErrorFE.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				SunatErrorFElist.Add(SunatErrorFE);
			}
			reader.Close();
			reader.Dispose();
			return SunatErrorFElist;
		}

		public SunatErrorFEBE Selecciona(string Codigo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatErrorFE_Selecciona");
			db.AddInParameter(dbCommand, "pCodigo", DbType.Int32, Codigo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			SunatErrorFEBE SunatErrorFE = null;
			while (reader.Read())
			{
				SunatErrorFE = new SunatErrorFEBE();
				SunatErrorFE.IdSunatErrorFE = Int32.Parse(reader["IdSunatErrorFE"].ToString());
				SunatErrorFE.Codigo = reader["Codigo"].ToString();
				SunatErrorFE.DescError = reader["DescError"].ToString();
				SunatErrorFE.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return SunatErrorFE;
		}

	}
}
