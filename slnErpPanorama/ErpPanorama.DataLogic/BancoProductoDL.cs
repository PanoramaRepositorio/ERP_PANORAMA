using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class BancoProductoDL
	{
		public BancoProductoDL() { }

		public Int32 Inserta(BancoProductoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_BancoProducto_Inserta");

			db.AddOutParameter(dbCommand, "pIdBancoProducto", DbType.Int32, pItem.IdBancoProducto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdTipoProducto", DbType.Int32, pItem.IdTipoProducto);
			db.AddInParameter(dbCommand, "pLineaCredito", DbType.Decimal, pItem.LineaCredito);
			db.AddInParameter(dbCommand, "pMontoUtilizado", DbType.Decimal, pItem.MontoUtilizado);
			db.AddInParameter(dbCommand, "pDisponible", DbType.Decimal, pItem.Disponible);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdBancoProducto");

			return Id;
		}

		public void Actualiza(BancoProductoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_BancoProducto_Actualiza");

			db.AddInParameter(dbCommand, "pIdBancoProducto", DbType.Int32, pItem.IdBancoProducto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdTipoProducto", DbType.Int32, pItem.IdTipoProducto);
			db.AddInParameter(dbCommand, "pLineaCredito", DbType.Decimal, pItem.LineaCredito);
			db.AddInParameter(dbCommand, "pMontoUtilizado", DbType.Decimal, pItem.MontoUtilizado);
			db.AddInParameter(dbCommand, "pDisponible", DbType.Decimal, pItem.Disponible);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(BancoProductoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_BancoProducto_Elimina");

			db.AddInParameter(dbCommand, "pIdBancoProducto", DbType.Int32, pItem.IdBancoProducto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<BancoProductoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_BancoProducto_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<BancoProductoBE> BancoProductolist = new List<BancoProductoBE>();
			BancoProductoBE BancoProducto;
			while (reader.Read())
			{
				BancoProducto = new BancoProductoBE();
				BancoProducto.IdBancoProducto = Int32.Parse(reader["IdBancoProducto"].ToString());
				BancoProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				BancoProducto.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                BancoProducto.DescBanco = reader["DescBanco"].ToString();
                BancoProducto.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                BancoProducto.DescMoneda = reader["DescMoneda"].ToString();
                BancoProducto.IdTipoProducto = Int32.Parse(reader["IdTipoProducto"].ToString());
                BancoProducto.DescTipoProducto = reader["DescTipoProducto"].ToString();
                BancoProducto.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                BancoProducto.Prestamo = Decimal.Parse(reader["Prestamo"].ToString());
                BancoProducto.MontoUtilizado = Decimal.Parse(reader["MontoUtilizado"].ToString());
                BancoProducto.Disponible = Decimal.Parse(reader["Disponible"].ToString());
				BancoProducto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//BancoProducto.IdBancoProducto = reader.IsDBNull(reader.GetOrdinal("IdBancoProducto")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBancoProducto"));
				BancoProductolist.Add(BancoProducto);
			}
			reader.Close();
			reader.Dispose();
			return BancoProductolist;
		}

		public BancoProductoBE Selecciona(int IdBancoProducto)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_BancoProducto_Selecciona");
			db.AddInParameter(dbCommand, "pIdBancoProducto", DbType.Int32, IdBancoProducto);

			IDataReader reader = db.ExecuteReader(dbCommand);
			BancoProductoBE BancoProducto = null;
			while (reader.Read())
			{
				BancoProducto = new BancoProductoBE();
                BancoProducto.IdBancoProducto = Int32.Parse(reader["IdBancoProducto"].ToString());
                BancoProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                BancoProducto.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                BancoProducto.DescBanco = reader["DescBanco"].ToString();
                BancoProducto.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                BancoProducto.DescMoneda = reader["DescMoneda"].ToString();
                BancoProducto.IdTipoProducto = Int32.Parse(reader["IdTipoProducto"].ToString());
                BancoProducto.DescTipoProducto = reader["DescTipoProducto"].ToString();
                BancoProducto.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                BancoProducto.MontoUtilizado = Decimal.Parse(reader["MontoUtilizado"].ToString());
                BancoProducto.Disponible = Decimal.Parse(reader["Disponible"].ToString());
                BancoProducto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //BancoProducto.IdBancoProducto = reader.IsDBNull(reader.GetOrdinal("IdBancoProducto")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdBancoProducto"));
			}
			reader.Close();
			reader.Dispose();
			return BancoProducto;
		}

	}
}
