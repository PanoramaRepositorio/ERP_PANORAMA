using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class CuentaBancoDetalleCausalDL
	{
		public CuentaBancoDetalleCausalDL() { }

		public void Inserta(CuentaBancoDetalleCausalBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleCausal_Inserta");

			db.AddOutParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Actualiza(CuentaBancoDetalleCausalBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleCausal_Actualiza");

			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(CuentaBancoDetalleCausalBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleCausal_Elimina");

			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, pItem.IdCuentaBancoDetalleCausal);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public List<CuentaBancoDetalleCausalBE> ListaTodosActivo(string TipoMovimiento)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleCausal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<CuentaBancoDetalleCausalBE> CuentaBancoDetalleCausallist = new List<CuentaBancoDetalleCausalBE>();
			CuentaBancoDetalleCausalBE CuentaBancoDetalleCausal;
			while (reader.Read())
			{
				CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalBE();
				CuentaBancoDetalleCausal.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
				CuentaBancoDetalleCausal.TipoMovimiento = reader["TipoMovimiento"].ToString();
				CuentaBancoDetalleCausal.Descripcion = reader["Descripcion"].ToString();
				CuentaBancoDetalleCausal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				CuentaBancoDetalleCausallist.Add(CuentaBancoDetalleCausal);
			}
			reader.Close();
			reader.Dispose();
			return CuentaBancoDetalleCausallist;
		}

		public CuentaBancoDetalleCausalBE Selecciona(int IdCuentaBancoDetalleCausal)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_CuentaBancoDetalleCausal_Selecciona");
			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalleCausal", DbType.Int32, IdCuentaBancoDetalleCausal);

			IDataReader reader = db.ExecuteReader(dbCommand);
			CuentaBancoDetalleCausalBE CuentaBancoDetalleCausal = null;
			while (reader.Read())
			{
				CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalBE();
				CuentaBancoDetalleCausal.IdCuentaBancoDetalleCausal = Int32.Parse(reader["IdCuentaBancoDetalleCausal"].ToString());
				CuentaBancoDetalleCausal.TipoMovimiento = reader["TipoMovimiento"].ToString();
				CuentaBancoDetalleCausal.Descripcion = reader["Descripcion"].ToString();
				CuentaBancoDetalleCausal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return CuentaBancoDetalleCausal;
		}

	}
}
