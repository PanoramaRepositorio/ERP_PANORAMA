using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PromocionProximaDL
	{
		public PromocionProximaDL() { }

		public Int32 Inserta(PromocionProximaBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionProxima_Inserta");

			db.AddOutParameter(dbCommand, "pIdPromocionProxima", DbType.Int32, pItem.IdPromocionProxima);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
			db.AddInParameter(dbCommand, "pMensaje", DbType.String, pItem.Mensaje);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPromocionProxima");

			return Id;
		}

		public void Actualiza(PromocionProximaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionProxima_Actualiza");

			db.AddInParameter(dbCommand, "pIdPromocionProxima", DbType.Int32, pItem.IdPromocionProxima);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
			db.AddInParameter(dbCommand, "pMensaje", DbType.String, pItem.Mensaje);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PromocionProximaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionProxima_Elimina");

			db.AddInParameter(dbCommand, "pIdPromocionProxima", DbType.Int32, pItem.IdPromocionProxima);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PromocionProximaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionProxima_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<PromocionProximaBE> PromocionProximalist = new List<PromocionProximaBE>();
			PromocionProximaBE PromocionProxima;
			while (reader.Read())
			{
				PromocionProxima = new PromocionProximaBE();
				PromocionProxima.IdPromocionProxima = Int32.Parse(reader["IdPromocionProxima"].ToString());
				PromocionProxima.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PromocionProxima.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionProxima.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionProxima.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionProxima.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionProxima.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionProxima.DescTienda = reader["DescTienda"].ToString();
                PromocionProxima.Descripcion = reader["Descripcion"].ToString();
				PromocionProxima.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				PromocionProxima.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				PromocionProxima.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
				PromocionProxima.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionProxima.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                PromocionProxima.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                PromocionProxima.Descuento = Decimal.Parse(reader["Descuento"].ToString());
				PromocionProxima.Mensaje = reader["Mensaje"].ToString();
				PromocionProxima.Observacion = reader["Observacion"].ToString();
				PromocionProxima.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//PromocionProxima.IdPromocionProxima = reader.IsDBNull(reader.GetOrdinal("IdPromocionProxima")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPromocionProxima"));
				PromocionProximalist.Add(PromocionProxima);
			}
			reader.Close();
			reader.Dispose();
			return PromocionProximalist;
		}

		public PromocionProximaBE Selecciona(int IdPromocionProxima)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionProxima_Selecciona");
			db.AddInParameter(dbCommand, "pIdPromocionProxima", DbType.Int32, IdPromocionProxima);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PromocionProximaBE PromocionProxima = null;
			while (reader.Read())
			{
				PromocionProxima = new PromocionProximaBE();
				PromocionProxima.IdPromocionProxima = Int32.Parse(reader["IdPromocionProxima"].ToString());
				PromocionProxima.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PromocionProxima.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
				PromocionProxima.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
				PromocionProxima.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
				PromocionProxima.Descripcion = reader["Descripcion"].ToString();
				PromocionProxima.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				PromocionProxima.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				PromocionProxima.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
				PromocionProxima.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionProxima.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                PromocionProxima.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                PromocionProxima.Descuento = Decimal.Parse(reader["Descuento"].ToString());
				PromocionProxima.Mensaje = reader["Mensaje"].ToString();
				PromocionProxima.Observacion = reader["Observacion"].ToString();
				PromocionProxima.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//PromocionProxima.IdPromocionProxima = reader.IsDBNull(reader.GetOrdinal("IdPromocionProxima")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPromocionProxima"));
			}
			reader.Close();
			reader.Dispose();
			return PromocionProxima;
		}

        public PromocionProximaBE SeleccionaActivo(int IdTienda, int IdFormaPago, int IdTipoCliente, Decimal Total)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionProxima_SeleccionaActivo");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "PTotal", DbType.Int32, Total);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PromocionProximaBE PromocionProxima = null;
            while (reader.Read())
            {
                PromocionProxima = new PromocionProximaBE();
                PromocionProxima.IdPromocionProxima = Int32.Parse(reader["IdPromocionProxima"].ToString());
                PromocionProxima.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionProxima.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionProxima.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionProxima.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionProxima.Descripcion = reader["Descripcion"].ToString();
                PromocionProxima.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionProxima.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionProxima.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                PromocionProxima.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionProxima.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                PromocionProxima.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                PromocionProxima.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionProxima.Mensaje = reader["Mensaje"].ToString();
                PromocionProxima.Observacion = reader["Observacion"].ToString();
                PromocionProxima.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //PromocionProxima.IdPromocionProxima = reader.IsDBNull(reader.GetOrdinal("IdPromocionProxima")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPromocionProxima"));
            }
            reader.Close();
            reader.Dispose();
            return PromocionProxima;
        }

    }
}
