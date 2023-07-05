using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PagoServicioDetalleDL
	{
		public PagoServicioDetalleDL() { }

		public Int32 Inserta(PagoServicioDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicioDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdPagoServicioDetalle", DbType.Int32, pItem.IdPagoServicioDetalle);
			db.AddInParameter(dbCommand, "pIdPagoServicio", DbType.Int32, pItem.IdPagoServicio);
			db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
			db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPagoServicioDetalle");

			return Id;
		}

		public void Actualiza(PagoServicioDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicioDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdPagoServicioDetalle", DbType.Int32, pItem.IdPagoServicioDetalle);
			db.AddInParameter(dbCommand, "pIdPagoServicio", DbType.Int32, pItem.IdPagoServicio);
			db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
			db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PagoServicioDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicioDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdPagoServicioDetalle", DbType.Int32, pItem.IdPagoServicioDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PagoServicioDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicioDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PagoServicioDetalleBE> PagoServicioDetallelist = new List<PagoServicioDetalleBE>();
			PagoServicioDetalleBE PagoServicioDetalle;
			while (reader.Read())
			{
				PagoServicioDetalle = new PagoServicioDetalleBE();
				PagoServicioDetalle.IdPagoServicioDetalle = Int32.Parse(reader["IdPagoServicioDetalle"].ToString());
				PagoServicioDetalle.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
				PagoServicioDetalle.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                PagoServicioDetalle.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                PagoServicioDetalle.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
				PagoServicioDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
				PagoServicioDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
				PagoServicioDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PagoServicioDetallelist.Add(PagoServicioDetalle);
			}
			reader.Close();
			reader.Dispose();
			return PagoServicioDetallelist;
		}

		public PagoServicioDetalleBE Selecciona(int IdPagoServicioDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PagoServicioDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdPagoServicioDetalle", DbType.Int32, IdPagoServicioDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PagoServicioDetalleBE PagoServicioDetalle = null;
			while (reader.Read())
			{
				PagoServicioDetalle = new PagoServicioDetalleBE();
                PagoServicioDetalle.IdPagoServicioDetalle = Int32.Parse(reader["IdPagoServicioDetalle"].ToString());
                PagoServicioDetalle.IdPagoServicio = Int32.Parse(reader["IdPagoServicio"].ToString());
                PagoServicioDetalle.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                PagoServicioDetalle.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                PagoServicioDetalle.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                PagoServicioDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                PagoServicioDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                PagoServicioDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PagoServicioDetalle;
		}

	}
}
