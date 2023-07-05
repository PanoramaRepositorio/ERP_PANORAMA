using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class DescuentoTipoVentaDL
	{
		public DescuentoTipoVentaDL() { }

		public Int32 Inserta(DescuentoTipoVentaBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoTipoVenta_Inserta");

			db.AddOutParameter(dbCommand, "pIdDescuentoTipoVenta", DbType.Int32, pItem.IdDescuentoTipoVenta);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pPorDescuento", DbType.Decimal, pItem.PorDescuento);
			db.AddInParameter(dbCommand, "pFlagPreVenta", DbType.Boolean, pItem.FlagPreVenta);
			db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
			db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdDescuentoTipoVenta");

			return Id;
		}

		public void Actualiza(DescuentoTipoVentaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoTipoVenta_Actualiza");

			db.AddInParameter(dbCommand, "pIdDescuentoTipoVenta", DbType.Int32, pItem.IdDescuentoTipoVenta);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pPorDescuento", DbType.Decimal, pItem.PorDescuento);
			db.AddInParameter(dbCommand, "pFlagPreVenta", DbType.Boolean, pItem.FlagPreVenta);
			db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
			db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(DescuentoTipoVentaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoTipoVenta_Elimina");

			db.AddInParameter(dbCommand, "pIdDescuentoTipoVenta", DbType.Int32, pItem.IdDescuentoTipoVenta);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<DescuentoTipoVentaBE> ListaTodosActivo(int IdEmpresa, int IdFormaPago, int IdLineaProducto)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoTipoVenta_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<DescuentoTipoVentaBE> DescuentoTipoVentalist = new List<DescuentoTipoVentaBE>();
			DescuentoTipoVentaBE DescuentoTipoVenta;
			while (reader.Read())
			{
				DescuentoTipoVenta = new DescuentoTipoVentaBE();
                DescuentoTipoVenta.IdDescuentoTipoVenta = Int32.Parse(reader["IdDescuentoTipoVenta"].ToString());
                DescuentoTipoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescuentoTipoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DescuentoTipoVenta.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                DescuentoTipoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DescuentoTipoVenta.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                DescuentoTipoVenta.DescLineaProducto = reader["DescLineaProducto"].ToString();
                DescuentoTipoVenta.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                DescuentoTipoVenta.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                DescuentoTipoVenta.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                DescuentoTipoVenta.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescuentoTipoVenta.PorDescuento = Decimal.Parse(reader["PorDescuento"].ToString());
                DescuentoTipoVenta.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
                DescuentoTipoVenta.FlagVenta = Boolean.Parse(reader["FlagVenta"].ToString());
                DescuentoTipoVenta.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                DescuentoTipoVenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //DescuentoTipoVenta.IdDescuentoTipoVenta = reader.IsDBNull(reader.GetOrdinal("IdDescuentoTipoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDescuentoTipoVenta"));
                DescuentoTipoVentalist.Add(DescuentoTipoVenta);
			}
			reader.Close();
			reader.Dispose();
			return DescuentoTipoVentalist;
		}

		public DescuentoTipoVentaBE Selecciona(int IdDescuentoTipoVenta)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoTipoVenta_Selecciona");
			db.AddInParameter(dbCommand, "pIdDescuentoTipoVenta", DbType.Int32, IdDescuentoTipoVenta);

			IDataReader reader = db.ExecuteReader(dbCommand);
			DescuentoTipoVentaBE DescuentoTipoVenta = null;
			while (reader.Read())
			{
				DescuentoTipoVenta = new DescuentoTipoVentaBE();
				DescuentoTipoVenta.IdDescuentoTipoVenta = Int32.Parse(reader["IdDescuentoTipoVenta"].ToString());
				DescuentoTipoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				DescuentoTipoVenta.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
				DescuentoTipoVenta.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                DescuentoTipoVenta.DescFormaPago = reader["DescFormaPago"].ToString();
                DescuentoTipoVenta.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                DescuentoTipoVenta.DescLineaProducto = reader["DescLineaProducto"].ToString();
                DescuentoTipoVenta.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
				DescuentoTipoVenta.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
				DescuentoTipoVenta.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				DescuentoTipoVenta.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				DescuentoTipoVenta.PorDescuento = Decimal.Parse(reader["PorDescuento"].ToString());
				DescuentoTipoVenta.FlagPreVenta = Boolean.Parse(reader["FlagPreVenta"].ToString());
				DescuentoTipoVenta.FlagVenta = Boolean.Parse(reader["FlagVenta"].ToString());
				DescuentoTipoVenta.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
				DescuentoTipoVenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//DescuentoTipoVenta.IdDescuentoTipoVenta = reader.IsDBNull(reader.GetOrdinal("IdDescuentoTipoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDescuentoTipoVenta"));
			}
			reader.Close();
			reader.Dispose();
			return DescuentoTipoVenta;
		}

	}
}
