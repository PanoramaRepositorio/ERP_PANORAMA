using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class CajaChicaDL
	{
		public CajaChicaDL() { }

		public Int32 Inserta(CajaChicaBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaChica_Inserta");

			db.AddOutParameter(dbCommand, "pIdCajaChica", DbType.Int32, pItem.IdCajaChica);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescCajaChica", DbType.String, pItem.DescCajaChica);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pSaldoSoles", DbType.Decimal, pItem.SaldoSoles);
			db.AddInParameter(dbCommand, "pSaldoDolares", DbType.Decimal, pItem.SaldoDolares);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdCajaChica");

			return Id;
		}

		public void Actualiza(CajaChicaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaChica_Actualiza");

			db.AddInParameter(dbCommand, "pIdCajaChica", DbType.Int32, pItem.IdCajaChica);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescCajaChica", DbType.String, pItem.DescCajaChica);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pSaldoSoles", DbType.Decimal, pItem.SaldoSoles);
			db.AddInParameter(dbCommand, "pSaldoDolares", DbType.Decimal, pItem.SaldoDolares);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(CajaChicaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaChica_Elimina");

			db.AddInParameter(dbCommand, "pIdCajaChica", DbType.Int32, pItem.IdCajaChica);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<CajaChicaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaChica_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<CajaChicaBE> CajaChicalist = new List<CajaChicaBE>();
			CajaChicaBE CajaChica;
			while (reader.Read())
			{
				CajaChica = new CajaChicaBE();
				CajaChica.IdCajaChica = Int32.Parse(reader["IdCajaChica"].ToString());
				CajaChica.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
				CajaChica.DescCajaChica = reader["DescCajaChica"].ToString();
				CajaChica.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CajaChica.DescPersona = reader["DescPersona"].ToString();
                CajaChica.SaldoSoles = Decimal.Parse(reader["SaldoSoles"].ToString());
				CajaChica.SaldoDolares = Decimal.Parse(reader["SaldoDolares"].ToString());
				CajaChica.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//CajaChica.IdCajaChica = reader.IsDBNull(reader.GetOrdinal("IdCajaChica")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCajaChica"));
				CajaChicalist.Add(CajaChica);
			}
			reader.Close();
			reader.Dispose();
			return CajaChicalist;
		}

		public CajaChicaBE Selecciona(int IdCajaChica)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaChica_Selecciona");
			db.AddInParameter(dbCommand, "pIdCajaChica", DbType.Int32, IdCajaChica);

			IDataReader reader = db.ExecuteReader(dbCommand);
			CajaChicaBE CajaChica = null;
			while (reader.Read())
			{
				CajaChica = new CajaChicaBE();
				CajaChica.IdCajaChica = Int32.Parse(reader["IdCajaChica"].ToString());
				CajaChica.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
				CajaChica.DescCajaChica = reader["DescCajaChica"].ToString();
				CajaChica.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CajaChica.DescPersona = reader["DescPersona"].ToString();
                CajaChica.SaldoSoles = Decimal.Parse(reader["SaldoSoles"].ToString());
				CajaChica.SaldoDolares = Decimal.Parse(reader["SaldoDolares"].ToString());
				CajaChica.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//CajaChica.IdCajaChica = reader.IsDBNull(reader.GetOrdinal("IdCajaChica")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCajaChica"));
			}
			reader.Close();
			reader.Dispose();
			return CajaChica;
		}

	}
}
