using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class InsumoClasificacionDL
	{
		public InsumoClasificacionDL() { }

		public Int32 Inserta(InsumoClasificacionBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoClasificacion_Inserta");

			db.AddOutParameter(dbCommand, "pIdInsumoClasificacion", DbType.Int32, pItem.IdInsumoClasificacion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescInsumoClasificacion", DbType.String, pItem.DescInsumoClasificacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdInsumoClasificacion");

			return Id;
		}

		public void Actualiza(InsumoClasificacionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoClasificacion_Actualiza");

			db.AddInParameter(dbCommand, "pIdInsumoClasificacion", DbType.Int32, pItem.IdInsumoClasificacion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescInsumoClasificacion", DbType.String, pItem.DescInsumoClasificacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(InsumoClasificacionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoClasificacion_Elimina");

			db.AddInParameter(dbCommand, "pIdInsumoClasificacion", DbType.Int32, pItem.IdInsumoClasificacion);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<InsumoClasificacionBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoClasificacion_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<InsumoClasificacionBE> InsumoClasificacionlist = new List<InsumoClasificacionBE>();
			InsumoClasificacionBE InsumoClasificacion;
			while (reader.Read())
			{
				InsumoClasificacion = new InsumoClasificacionBE();
				InsumoClasificacion.IdInsumoClasificacion = Int32.Parse(reader["IdInsumoClasificacion"].ToString());
				InsumoClasificacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				InsumoClasificacion.DescInsumoClasificacion = reader["DescInsumoClasificacion"].ToString();
				InsumoClasificacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//InsumoClasificacion.IdInsumoClasificacion = reader.IsDBNull(reader.GetOrdinal("IdInsumoClasificacion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumoClasificacion"));
				InsumoClasificacionlist.Add(InsumoClasificacion);
			}
			reader.Close();
			reader.Dispose();
			return InsumoClasificacionlist;
		}

		public InsumoClasificacionBE Selecciona(int IdInsumoClasificacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoClasificacion_Selecciona");
			db.AddInParameter(dbCommand, "pIdInsumoClasificacion", DbType.Int32, IdInsumoClasificacion);

			IDataReader reader = db.ExecuteReader(dbCommand);
			InsumoClasificacionBE InsumoClasificacion = null;
			while (reader.Read())
			{
				InsumoClasificacion = new InsumoClasificacionBE();
				InsumoClasificacion.IdInsumoClasificacion = Int32.Parse(reader["IdInsumoClasificacion"].ToString());
				InsumoClasificacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				InsumoClasificacion.DescInsumoClasificacion = reader["DescInsumoClasificacion"].ToString();
				InsumoClasificacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//InsumoClasificacion.IdInsumoClasificacion = reader.IsDBNull(reader.GetOrdinal("IdInsumoClasificacion")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumoClasificacion"));
			}
			reader.Close();
			reader.Dispose();
			return InsumoClasificacion;
		}

	}
}
