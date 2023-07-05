using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PromocionMarcaDetalleDL
	{
		public PromocionMarcaDetalleDL() { }

		public Int32 Inserta(PromocionMarcaDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarcaDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdPromocionMarcaDetalle", DbType.Int32, pItem.IdPromocionMarcaDetalle);
			db.AddInParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, pItem.IdPromocionMarca);
			db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
			db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
			db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
			db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPromocionMarcaDetalle");

			return Id;
		}

		public void Actualiza(PromocionMarcaDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarcaDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdPromocionMarcaDetalle", DbType.Int32, pItem.IdPromocionMarcaDetalle);
			db.AddInParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, pItem.IdPromocionMarca);
			db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
			db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
			db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
			db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
			db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
			db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PromocionMarcaDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarcaDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdPromocionMarcaDetalle", DbType.Int32, pItem.IdPromocionMarcaDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PromocionMarcaDetalleBE> ListaTodosActivo(int IdPromocionMarca)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarcaDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, IdPromocionMarca);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PromocionMarcaDetalleBE> PromocionMarcaDetallelist = new List<PromocionMarcaDetalleBE>();
			PromocionMarcaDetalleBE PromocionMarcaDetalle;
			while (reader.Read())
			{
				PromocionMarcaDetalle = new PromocionMarcaDetalleBE();
				PromocionMarcaDetalle.IdPromocionMarcaDetalle = Int32.Parse(reader["IdPromocionMarcaDetalle"].ToString());
				PromocionMarcaDetalle.IdPromocionMarca = Int32.Parse(reader["IdPromocionMarca"].ToString());
				PromocionMarcaDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
				PromocionMarcaDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
				PromocionMarcaDetalle.NombreProducto = reader["NombreProducto"].ToString();
				PromocionMarcaDetalle.Abreviatura = reader["Abreviatura"].ToString();
				PromocionMarcaDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				PromocionMarcaDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
				PromocionMarcaDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//PromocionMarcaDetalle.IdPromocionMarcaDetalle = reader.IsDBNull(reader.GetOrdinal("IdPromocionMarcaDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPromocionMarcaDetalle"));
				PromocionMarcaDetallelist.Add(PromocionMarcaDetalle);
			}
			reader.Close();
			reader.Dispose();
			return PromocionMarcaDetallelist;
		}

		public PromocionMarcaDetalleBE Selecciona(int IdPromocionMarcaDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarcaDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdPromocionMarcaDetalle", DbType.Int32, IdPromocionMarcaDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PromocionMarcaDetalleBE PromocionMarcaDetalle = null;
			while (reader.Read())
			{
				PromocionMarcaDetalle = new PromocionMarcaDetalleBE();
				PromocionMarcaDetalle.IdPromocionMarcaDetalle = Int32.Parse(reader["IdPromocionMarcaDetalle"].ToString());
				PromocionMarcaDetalle.IdPromocionMarca = Int32.Parse(reader["IdPromocionMarca"].ToString());
				PromocionMarcaDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
				PromocionMarcaDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
				PromocionMarcaDetalle.NombreProducto = reader["NombreProducto"].ToString();
				PromocionMarcaDetalle.Abreviatura = reader["Abreviatura"].ToString();
				PromocionMarcaDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
				PromocionMarcaDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
				PromocionMarcaDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PromocionMarcaDetalle;
		}

	}
}
