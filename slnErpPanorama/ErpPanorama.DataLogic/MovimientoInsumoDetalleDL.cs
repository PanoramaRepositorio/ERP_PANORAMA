using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class MovimientoInsumoDetalleDL
	{
		public MovimientoInsumoDetalleDL() { }

		public Int32 Inserta(MovimientoInsumoDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumoDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdMovimientoInsumoDetalle", DbType.Int32, pItem.IdMovimientoInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdMovimientoInsumo", DbType.Int32, pItem.IdMovimientoInsumo);
			db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
			db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pIdMovimientoInsumoDetalleReferencia", DbType.Int32, pItem.IdMovimientoInsumoDetalleReferencia);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdMovimientoInsumoDetalle");

			return Id;
		}

		public void Actualiza(MovimientoInsumoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumoDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdMovimientoInsumoDetalle", DbType.Int32, pItem.IdMovimientoInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdMovimientoInsumo", DbType.Int32, pItem.IdMovimientoInsumo);
			db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
			db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pIdMovimientoInsumoDetalleReferencia", DbType.Int32, pItem.IdMovimientoInsumoDetalleReferencia);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(MovimientoInsumoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumoDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdMovimientoInsumoDetalle", DbType.Int32, pItem.IdMovimientoInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<MovimientoInsumoDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumoDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<MovimientoInsumoDetalleBE> MovimientoInsumoDetallelist = new List<MovimientoInsumoDetalleBE>();
			MovimientoInsumoDetalleBE MovimientoInsumoDetalle;
			while (reader.Read())
			{
				MovimientoInsumoDetalle = new MovimientoInsumoDetalleBE();
				MovimientoInsumoDetalle.IdMovimientoInsumoDetalle = Int32.Parse(reader["IdMovimientoInsumoDetalle"].ToString());
				MovimientoInsumoDetalle.IdMovimientoInsumo = Int32.Parse(reader["IdMovimientoInsumo"].ToString());
				MovimientoInsumoDetalle.Item = Int32.Parse(reader["Item"].ToString());
				MovimientoInsumoDetalle.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
				MovimientoInsumoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				MovimientoInsumoDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
				MovimientoInsumoDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
				MovimientoInsumoDetalle.Observacion = reader["Observacion"].ToString();
				MovimientoInsumoDetalle.IdMovimientoInsumoDetalleReferencia = Int32.Parse(reader["IdMovimientoInsumoDetalleReferencia"].ToString());
				MovimientoInsumoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MovimientoInsumoDetalle.IdMovimientoInsumoDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoInsumoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoInsumoDetalle"));
				MovimientoInsumoDetallelist.Add(MovimientoInsumoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return MovimientoInsumoDetallelist;
		}

		public MovimientoInsumoDetalleBE Selecciona(int IdMovimientoInsumoDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumoDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdMovimientoInsumoDetalle", DbType.Int32, IdMovimientoInsumoDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			MovimientoInsumoDetalleBE MovimientoInsumoDetalle = null;
			while (reader.Read())
			{
				MovimientoInsumoDetalle = new MovimientoInsumoDetalleBE();
				MovimientoInsumoDetalle.IdMovimientoInsumoDetalle = Int32.Parse(reader["IdMovimientoInsumoDetalle"].ToString());
				MovimientoInsumoDetalle.IdMovimientoInsumo = Int32.Parse(reader["IdMovimientoInsumo"].ToString());
				MovimientoInsumoDetalle.Item = Int32.Parse(reader["Item"].ToString());
				MovimientoInsumoDetalle.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
				MovimientoInsumoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				MovimientoInsumoDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
				MovimientoInsumoDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
				MovimientoInsumoDetalle.Observacion = reader["Observacion"].ToString();
				MovimientoInsumoDetalle.IdMovimientoInsumoDetalleReferencia = Int32.Parse(reader["IdMovimientoInsumoDetalleReferencia"].ToString());
				MovimientoInsumoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MovimientoInsumoDetalle.IdMovimientoInsumoDetalle = reader.IsDBNull(reader.GetOrdinal("IdMovimientoInsumoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoInsumoDetalle"));
			}
			reader.Close();
			reader.Dispose();
			return MovimientoInsumoDetalle;
		}

	}
}
