using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class MetaConversionDL
	{
		public MetaConversionDL() { }

		public Int32 Inserta(MetaConversionBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaConversion_Inserta");

			db.AddOutParameter(dbCommand, "pIdMetaConversion", DbType.Int32, pItem.IdMetaConversion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdMetaConversion");

			return Id;
		}

		public void Actualiza(MetaConversionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaConversion_Actualiza");

			db.AddInParameter(dbCommand, "pIdMetaConversion", DbType.Int32, pItem.IdMetaConversion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(MetaConversionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaConversion_Elimina");

			db.AddInParameter(dbCommand, "pIdMetaConversion", DbType.Int32, pItem.IdMetaConversion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<MetaConversionBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaConversion_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<MetaConversionBE> MetaConversionlist = new List<MetaConversionBE>();
			MetaConversionBE MetaConversion;
			while (reader.Read())
			{
				MetaConversion = new MetaConversionBE();
				MetaConversion.IdMetaConversion = Int32.Parse(reader["IdMetaConversion"].ToString());
				MetaConversion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				MetaConversion.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetaConversion.DescTienda = reader["DescTienda"].ToString();
                MetaConversion.Periodo = Int32.Parse(reader["Periodo"].ToString());
				MetaConversion.Mes = Int32.Parse(reader["Mes"].ToString());
                MetaConversion.NombreMes = reader["NombreMes"].ToString();
                MetaConversion.Importe = Decimal.Parse(reader["Importe"].ToString());
				MetaConversion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MetaConversion.IdMetaConversion = reader.IsDBNull(reader.GetOrdinal("IdMetaConversion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMetaConversion"));
				MetaConversionlist.Add(MetaConversion);
			}
			reader.Close();
			reader.Dispose();
			return MetaConversionlist;
		}

		public MetaConversionBE Selecciona(int IdMetaConversion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaConversion_Selecciona");
			db.AddInParameter(dbCommand, "pIdMetaConversion", DbType.Int32, IdMetaConversion);

			IDataReader reader = db.ExecuteReader(dbCommand);
			MetaConversionBE MetaConversion = null;
			while (reader.Read())
			{
				MetaConversion = new MetaConversionBE();
				MetaConversion.IdMetaConversion = Int32.Parse(reader["IdMetaConversion"].ToString());
				MetaConversion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				MetaConversion.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetaConversion.DescTienda = reader["DescTienda"].ToString();
                MetaConversion.Periodo = Int32.Parse(reader["Periodo"].ToString());
				MetaConversion.Mes = Int32.Parse(reader["Mes"].ToString());
                MetaConversion.NombreMes = reader["NombreMes"].ToString();
                MetaConversion.Importe = Decimal.Parse(reader["Importe"].ToString());
				MetaConversion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MetaConversion.IdMetaConversion = reader.IsDBNull(reader.GetOrdinal("IdMetaConversion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMetaConversion"));
			}
			reader.Close();
			reader.Dispose();
			return MetaConversion;
		}

	}
}
