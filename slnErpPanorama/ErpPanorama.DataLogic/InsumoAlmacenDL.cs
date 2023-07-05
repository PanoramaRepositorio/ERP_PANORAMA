using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class InsumoAlmacenDL
	{
		public InsumoAlmacenDL() { }

		public Int32 Inserta(InsumoAlmacenBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoAlmacen_Inserta");

			db.AddOutParameter(dbCommand, "pIdInsumoAlmacen", DbType.Int32, pItem.IdInsumoAlmacen);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescInsumoAlmacen", DbType.String, pItem.DescInsumoAlmacen);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdInsumoAlmacen");

			return Id;
		}

		public void Actualiza(InsumoAlmacenBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoAlmacen_Actualiza");

			db.AddInParameter(dbCommand, "pIdInsumoAlmacen", DbType.Int32, pItem.IdInsumoAlmacen);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescInsumoAlmacen", DbType.String, pItem.DescInsumoAlmacen);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(InsumoAlmacenBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoAlmacen_Elimina");

			db.AddInParameter(dbCommand, "pIdInsumoAlmacen", DbType.Int32, pItem.IdInsumoAlmacen);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<InsumoAlmacenBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoAlmacen_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<InsumoAlmacenBE> InsumoAlmacenlist = new List<InsumoAlmacenBE>();
			InsumoAlmacenBE InsumoAlmacen;
			while (reader.Read())
			{
				InsumoAlmacen = new InsumoAlmacenBE();
				InsumoAlmacen.IdInsumoAlmacen = Int32.Parse(reader["IdInsumoAlmacen"].ToString());
				InsumoAlmacen.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				InsumoAlmacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
				InsumoAlmacen.DescInsumoAlmacen = reader["DescInsumoAlmacen"].ToString();
				InsumoAlmacen.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//InsumoAlmacen.IdInsumoAlmacen = reader.IsDBNull(reader.GetOrdinal("IdInsumoAlmacen")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumoAlmacen"));
				InsumoAlmacenlist.Add(InsumoAlmacen);
			}
			reader.Close();
			reader.Dispose();
			return InsumoAlmacenlist;
		}

		public InsumoAlmacenBE Selecciona(int IdInsumoAlmacen)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_InsumoAlmacen_Selecciona");
			db.AddInParameter(dbCommand, "pIdInsumoAlmacen", DbType.Int32, IdInsumoAlmacen);

			IDataReader reader = db.ExecuteReader(dbCommand);
			InsumoAlmacenBE InsumoAlmacen = null;
			while (reader.Read())
			{
				InsumoAlmacen = new InsumoAlmacenBE();
				InsumoAlmacen.IdInsumoAlmacen = Int32.Parse(reader["IdInsumoAlmacen"].ToString());
				InsumoAlmacen.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				InsumoAlmacen.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
				InsumoAlmacen.DescInsumoAlmacen = reader["DescInsumoAlmacen"].ToString();
				InsumoAlmacen.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//InsumoAlmacen.IdInsumoAlmacen = reader.IsDBNull(reader.GetOrdinal("IdInsumoAlmacen")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumoAlmacen"));
			}
			reader.Close();
			reader.Dispose();
			return InsumoAlmacen;
		}

	}
}
