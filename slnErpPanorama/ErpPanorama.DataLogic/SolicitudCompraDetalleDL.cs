using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class SolicitudCompraDetalleDL
	{
		public SolicitudCompraDetalleDL() { }

		public Int32 Inserta(SolicitudCompraDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompraDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdSolicitudCompraDetalle", DbType.Int32, pItem.IdSolicitudCompraDetalle);
			db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
			db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
			db.AddInParameter(dbCommand, "pNumeroBultos", DbType.Int32, pItem.NumeroBultos);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
			db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
			db.AddInParameter(dbCommand, "pCBM", DbType.String, pItem.CBM);
			db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdSolicitudCompraDetalle");

			return Id;
		}

		public void Actualiza(SolicitudCompraDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompraDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdSolicitudCompraDetalle", DbType.Int32, pItem.IdSolicitudCompraDetalle);
			db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
			db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
			db.AddInParameter(dbCommand, "pNumeroBultos", DbType.Int32, pItem.NumeroBultos);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
			db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
			db.AddInParameter(dbCommand, "pCBM", DbType.String, pItem.CBM);
			db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.Peso);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(SolicitudCompraDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompraDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdSolicitudCompraDetalle", DbType.Int32, pItem.IdSolicitudCompraDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public List<SolicitudCompraDetalleBE> ListaTodosActivo(int IdEmpresa, int IdSolicitudCompra)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompraDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, IdSolicitudCompra);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<SolicitudCompraDetalleBE> SolicitudCompraDetallelist = new List<SolicitudCompraDetalleBE>();
			SolicitudCompraDetalleBE SolicitudCompraDetalle;
			while (reader.Read())
			{
				SolicitudCompraDetalle = new SolicitudCompraDetalleBE();
				SolicitudCompraDetalle.IdSolicitudCompraDetalle = Int32.Parse(reader["IdSolicitudCompraDetalle"].ToString());
				SolicitudCompraDetalle.IdSolicitudCompra = Int32.Parse(reader["IdSolicitudCompra"].ToString());
                SolicitudCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                SolicitudCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                SolicitudCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                SolicitudCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
				SolicitudCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
				SolicitudCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				SolicitudCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
				SolicitudCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
				SolicitudCompraDetalle.CBM = reader["CBM"].ToString();
				SolicitudCompraDetalle.Peso = Decimal.Parse(reader["Peso"].ToString());
				SolicitudCompraDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//SolicitudCompraDetalle.IdSolicitudCompraDetalle = reader.IsDBNull(reader.GetOrdinal("IdSolicitudCompraDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdSolicitudCompraDetalle"));
				SolicitudCompraDetallelist.Add(SolicitudCompraDetalle);
			}
			reader.Close();
			reader.Dispose();
			return SolicitudCompraDetallelist;
		}

		public SolicitudCompraDetalleBE Selecciona(int IdSolicitudCompraDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompraDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdSolicitudCompraDetalle", DbType.Int32, IdSolicitudCompraDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			SolicitudCompraDetalleBE SolicitudCompraDetalle = null;
			while (reader.Read())
			{
				SolicitudCompraDetalle = new SolicitudCompraDetalleBE();
                SolicitudCompraDetalle.IdSolicitudCompraDetalle = Int32.Parse(reader["IdSolicitudCompraDetalle"].ToString());
                SolicitudCompraDetalle.IdSolicitudCompra = Int32.Parse(reader["IdSolicitudCompra"].ToString());
                SolicitudCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                SolicitudCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                SolicitudCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                SolicitudCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                SolicitudCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                SolicitudCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                SolicitudCompraDetalle.CBM = reader["CBM"].ToString();
                SolicitudCompraDetalle.Peso = Decimal.Parse(reader["Peso"].ToString());
                SolicitudCompraDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return SolicitudCompraDetalle;
		}

	}
}
