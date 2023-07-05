using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PaisDL
	{
		public PaisDL() { }

		public Int32 Inserta(PaisBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Pais_Inserta");

			db.AddOutParameter(dbCommand, "pIdPais", DbType.Int32, pItem.IdPais);
			db.AddInParameter(dbCommand, "pDescPais", DbType.String, pItem.DescPais);
			db.AddInParameter(dbCommand, "pCodigo", DbType.Int32, pItem.Codigo);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPais");

			return Id;
		}

		public void Actualiza(PaisBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Pais_Actualiza");

			db.AddInParameter(dbCommand, "pIdPais", DbType.Int32, pItem.IdPais);
			db.AddInParameter(dbCommand, "pDescPais", DbType.String, pItem.DescPais);
			db.AddInParameter(dbCommand, "pCodigo", DbType.Int32, pItem.Codigo);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PaisBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Pais_Elimina");

			db.AddInParameter(dbCommand, "pIdPais", DbType.Int32, pItem.IdPais);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PaisBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Pais_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PaisBE> Paislist = new List<PaisBE>();
			PaisBE Pais;
			while (reader.Read())
			{
				Pais = new PaisBE();
				Pais.IdPais = Int32.Parse(reader["IdPais"].ToString());
				Pais.DescPais = reader["DescPais"].ToString();
				Pais.Codigo = Int32.Parse(reader["Codigo"].ToString());
				Pais.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				Paislist.Add(Pais);
			}
			reader.Close();
			reader.Dispose();
			return Paislist;
		}

		public PaisBE Selecciona(int IdPais)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Pais_Selecciona");
			db.AddInParameter(dbCommand, "pIdPais", DbType.Int32, IdPais);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PaisBE Pais = null;
			while (reader.Read())
			{
				Pais = new PaisBE();
				Pais.IdPais = Int32.Parse(reader["IdPais"].ToString());
				Pais.DescPais = reader["DescPais"].ToString();
				Pais.Codigo = Int32.Parse(reader["Codigo"].ToString());
				Pais.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return Pais;
		}

	}
}
