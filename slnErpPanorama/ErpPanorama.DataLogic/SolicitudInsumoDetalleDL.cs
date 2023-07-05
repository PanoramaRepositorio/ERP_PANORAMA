using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class SolicitudInsumoDetalleDL
	{
		public SolicitudInsumoDetalleDL() { }

		public Int32 Inserta(SolicitudInsumoDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumoDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdSolicitudInsumoDetalle", DbType.Int32, pItem.IdSolicitudInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
			db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdSolicitudInsumoDetalle");

			return Id;
		}

		public void Actualiza(SolicitudInsumoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumoDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdSolicitudInsumoDetalle", DbType.Int32, pItem.IdSolicitudInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
			db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(SolicitudInsumoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumoDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdSolicitudInsumoDetalle", DbType.Int32, pItem.IdSolicitudInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<SolicitudInsumoDetalleBE> ListaTodosActivo(int IdSolicitudInsumo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumoDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, IdSolicitudInsumo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<SolicitudInsumoDetalleBE> SolicitudInsumoDetallelist = new List<SolicitudInsumoDetalleBE>();
			SolicitudInsumoDetalleBE SolicitudInsumoDetalle;
			while (reader.Read())
			{
				SolicitudInsumoDetalle = new SolicitudInsumoDetalleBE();
				SolicitudInsumoDetalle.IdSolicitudInsumoDetalle = Int32.Parse(reader["IdSolicitudInsumoDetalle"].ToString());
				SolicitudInsumoDetalle.IdSolicitudInsumo = Int32.Parse(reader["IdSolicitudInsumo"].ToString());
				SolicitudInsumoDetalle.Item = Int32.Parse(reader["Item"].ToString());
				SolicitudInsumoDetalle.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
                SolicitudInsumoDetalle.Descripcion = reader["Descripcion"].ToString();
                SolicitudInsumoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudInsumoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				SolicitudInsumoDetalle.Observacion = reader["Observacion"].ToString();
				SolicitudInsumoDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
				SolicitudInsumoDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
				SolicitudInsumoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				SolicitudInsumoDetallelist.Add(SolicitudInsumoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return SolicitudInsumoDetallelist;
		}

		public SolicitudInsumoDetalleBE Selecciona(int IdSolicitudInsumoDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumoDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdSolicitudInsumoDetalle", DbType.Int32, IdSolicitudInsumoDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			SolicitudInsumoDetalleBE SolicitudInsumoDetalle = null;
			while (reader.Read())
			{
				SolicitudInsumoDetalle = new SolicitudInsumoDetalleBE();
                SolicitudInsumoDetalle.IdSolicitudInsumoDetalle = Int32.Parse(reader["IdSolicitudInsumoDetalle"].ToString());
                SolicitudInsumoDetalle.IdSolicitudInsumo = Int32.Parse(reader["IdSolicitudInsumo"].ToString());
                SolicitudInsumoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudInsumoDetalle.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
                SolicitudInsumoDetalle.Descripcion = reader["Descripcion"].ToString();
                SolicitudInsumoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudInsumoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudInsumoDetalle.Observacion = reader["Observacion"].ToString();
                SolicitudInsumoDetalle.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                SolicitudInsumoDetalle.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                SolicitudInsumoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return SolicitudInsumoDetalle;
		}

	}
}
