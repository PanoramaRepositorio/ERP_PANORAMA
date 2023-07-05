using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class FacturaCompraInsumoDetalleDL
	{
		public FacturaCompraInsumoDetalleDL() { }

		public Int32 Inserta(FacturaCompraInsumoDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumoDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdFacturaCompraInsumoDetalle", DbType.Int32, pItem.IdFacturaCompraInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, pItem.IdFacturaCompraInsumo);
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
			db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdFacturaCompraInsumoDetalle");

			return Id;
		}

		public void Actualiza(FacturaCompraInsumoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumoDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumoDetalle", DbType.Int32, pItem.IdFacturaCompraInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, pItem.IdFacturaCompraInsumo);
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
			db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(FacturaCompraInsumoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumoDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumoDetalle", DbType.Int32, pItem.IdFacturaCompraInsumoDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<FacturaCompraInsumoDetalleBE> ListaTodosActivo(int IdFacturaCompraInsumo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumoDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumo", DbType.Int32, IdFacturaCompraInsumo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<FacturaCompraInsumoDetalleBE> FacturaCompraInsumoDetallelist = new List<FacturaCompraInsumoDetalleBE>();
			FacturaCompraInsumoDetalleBE FacturaCompraInsumoDetalle;
			while (reader.Read())
			{
				FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleBE();
				FacturaCompraInsumoDetalle.IdFacturaCompraInsumoDetalle = Int32.Parse(reader["IdFacturaCompraInsumoDetalle"].ToString());
				FacturaCompraInsumoDetalle.IdFacturaCompraInsumo = Int32.Parse(reader["IdFacturaCompraInsumo"].ToString());
				FacturaCompraInsumoDetalle.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
                FacturaCompraInsumoDetalle.Descripcion = reader["Descripcion"].ToString();
                FacturaCompraInsumoDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraInsumoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraInsumoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				FacturaCompraInsumoDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
				FacturaCompraInsumoDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
				FacturaCompraInsumoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				FacturaCompraInsumoDetallelist.Add(FacturaCompraInsumoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return FacturaCompraInsumoDetallelist;
		}

		public FacturaCompraInsumoDetalleBE Selecciona(int IdFacturaCompraInsumoDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraInsumoDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdFacturaCompraInsumoDetalle", DbType.Int32, IdFacturaCompraInsumoDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			FacturaCompraInsumoDetalleBE FacturaCompraInsumoDetalle = null;
			while (reader.Read())
			{
				FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleBE();
                FacturaCompraInsumoDetalle.IdFacturaCompraInsumoDetalle = Int32.Parse(reader["IdFacturaCompraInsumoDetalle"].ToString());
                FacturaCompraInsumoDetalle.IdFacturaCompraInsumo = Int32.Parse(reader["IdFacturaCompraInsumo"].ToString());
                FacturaCompraInsumoDetalle.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
                FacturaCompraInsumoDetalle.Descripcion = reader["Descripcion"].ToString();
                FacturaCompraInsumoDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraInsumoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraInsumoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraInsumoDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompraInsumoDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompraInsumoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return FacturaCompraInsumoDetalle;
		}

	}
}
