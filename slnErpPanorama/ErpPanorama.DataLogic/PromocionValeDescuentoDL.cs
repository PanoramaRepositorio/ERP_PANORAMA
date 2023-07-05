using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PromocionValeDescuentoDL
	{
		public PromocionValeDescuentoDL() { }

		public Int32 Inserta(PromocionValeDescuentoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_Inserta");

			db.AddOutParameter(dbCommand, "pIdPromocionValeDescuento", DbType.Int32, pItem.IdPromocionValeDescuento);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
			db.AddInParameter(dbCommand, "pDescuentoDesde", DbType.Decimal, pItem.DescuentoDesde);
			db.AddInParameter(dbCommand, "pDescuentoHasta", DbType.Decimal, pItem.DescuentoHasta);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pDescuentoAdicional", DbType.Decimal, pItem.DescuentoAdicional);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdTipoPromocion", DbType.Int32, pItem.IdTipoPromocion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPromocionValeDescuento");

			return Id;
		}

		public void Actualiza(PromocionValeDescuentoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_Actualiza");

			db.AddInParameter(dbCommand, "pIdPromocionValeDescuento", DbType.Int32, pItem.IdPromocionValeDescuento);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
			db.AddInParameter(dbCommand, "pDescuentoDesde", DbType.Decimal, pItem.DescuentoDesde);
			db.AddInParameter(dbCommand, "pDescuentoHasta", DbType.Decimal, pItem.DescuentoHasta);
            db.AddInParameter(dbCommand, "pDescuentoAdicional", DbType.Decimal, pItem.DescuentoAdicional);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdTipoPromocion", DbType.Int32, pItem.IdTipoPromocion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PromocionValeDescuentoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_Elimina");

			db.AddInParameter(dbCommand, "pIdPromocionValeDescuento", DbType.Int32, pItem.IdPromocionValeDescuento);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PromocionValeDescuentoBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<PromocionValeDescuentoBE> PromocionValeDescuentolist = new List<PromocionValeDescuentoBE>();
			PromocionValeDescuentoBE PromocionValeDescuento;
			while (reader.Read())
			{
				PromocionValeDescuento = new PromocionValeDescuentoBE();
				PromocionValeDescuento.IdPromocionValeDescuento = Int32.Parse(reader["IdPromocionValeDescuento"].ToString());
				PromocionValeDescuento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PromocionValeDescuento.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionValeDescuento.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionValeDescuento.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionValeDescuento.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionValeDescuento.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionValeDescuento.DescTienda = reader["DescTienda"].ToString();
                PromocionValeDescuento.Descripcion = reader["Descripcion"].ToString();
				PromocionValeDescuento.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				PromocionValeDescuento.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				PromocionValeDescuento.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
				PromocionValeDescuento.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
				PromocionValeDescuento.DescuentoDesde = Decimal.Parse(reader["DescuentoDesde"].ToString());
				PromocionValeDescuento.DescuentoHasta = Decimal.Parse(reader["DescuentoHasta"].ToString());
                PromocionValeDescuento.DescuentoAdicional = Decimal.Parse(reader["DescuentoAdicional"].ToString());
                PromocionValeDescuento.Importe = Decimal.Parse(reader["Importe"].ToString());
                PromocionValeDescuento.Observacion = reader["Observacion"].ToString();
                PromocionValeDescuento.IdTipoPromocion = Int32.Parse(reader["IdTipoPromocion"].ToString());
                PromocionValeDescuento.DescTipoPromocion = reader["DescTipoPromocion"].ToString();
                PromocionValeDescuento.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PromocionValeDescuentolist.Add(PromocionValeDescuento);
			}
			reader.Close();
			reader.Dispose();
			return PromocionValeDescuentolist;
		}

        public List<PromocionValeDescuentoBE> ListaTodosActivo(int IdPromocionValeDescuento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_Selecciona");
            db.AddInParameter(dbCommand, "pIdPromocionValeDescuento", DbType.Int32, IdPromocionValeDescuento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionValeDescuentoBE> PromocionValeDescuentolist = new List<PromocionValeDescuentoBE>();
            PromocionValeDescuentoBE PromocionValeDescuento;
            while (reader.Read())
            {
                PromocionValeDescuento = new PromocionValeDescuentoBE();
                PromocionValeDescuento.IdPromocionValeDescuento = Int32.Parse(reader["IdPromocionValeDescuento"].ToString());
                PromocionValeDescuento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionValeDescuento.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionValeDescuento.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionValeDescuento.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionValeDescuento.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionValeDescuento.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionValeDescuento.DescTienda = reader["DescTienda"].ToString();
                PromocionValeDescuento.Descripcion = reader["Descripcion"].ToString();
                PromocionValeDescuento.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionValeDescuento.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionValeDescuento.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                PromocionValeDescuento.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionValeDescuento.DescuentoDesde = Decimal.Parse(reader["DescuentoDesde"].ToString());
                PromocionValeDescuento.DescuentoHasta = Decimal.Parse(reader["DescuentoHasta"].ToString());
                PromocionValeDescuento.DescuentoAdicional = Decimal.Parse(reader["DescuentoAdicional"].ToString());
                PromocionValeDescuento.Importe = Decimal.Parse(reader["Importe"].ToString());
                PromocionValeDescuento.Observacion = reader["Observacion"].ToString();
                PromocionValeDescuento.IdTipoPromocion = Int32.Parse(reader["IdTipoPromocion"].ToString());
                PromocionValeDescuento.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionValeDescuentolist.Add(PromocionValeDescuento);
            }
            reader.Close();
            reader.Dispose();
            return PromocionValeDescuentolist;
        }

        public List<PromocionValeDescuentoBE> ListaFecha(int IdEmpresa, int IdTienda, int Tipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pTipo", DbType.Int32, Tipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionValeDescuentoBE> PromocionValeDescuentolist = new List<PromocionValeDescuentoBE>();
            PromocionValeDescuentoBE PromocionValeDescuento;
            while (reader.Read())
            {
                PromocionValeDescuento = new PromocionValeDescuentoBE();
                PromocionValeDescuento.IdPromocionValeDescuento = Int32.Parse(reader["IdPromocionValeDescuento"].ToString());
                PromocionValeDescuento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionValeDescuento.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionValeDescuento.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionValeDescuento.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionValeDescuento.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionValeDescuento.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionValeDescuento.DescTienda = reader["DescTienda"].ToString();
                PromocionValeDescuento.Descripcion = reader["Descripcion"].ToString();
                PromocionValeDescuento.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionValeDescuento.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionValeDescuento.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                PromocionValeDescuento.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionValeDescuento.DescuentoDesde = Decimal.Parse(reader["DescuentoDesde"].ToString());
                PromocionValeDescuento.DescuentoHasta = Decimal.Parse(reader["DescuentoHasta"].ToString());
                PromocionValeDescuento.DescuentoAdicional = Decimal.Parse(reader["DescuentoAdicional"].ToString());
                PromocionValeDescuento.Importe = Decimal.Parse(reader["Importe"].ToString());
                PromocionValeDescuento.Observacion = reader["Observacion"].ToString();
                PromocionValeDescuento.IdTipoPromocion = Int32.Parse(reader["IdTipoPromocion"].ToString());
                PromocionValeDescuento.DescTipoPromocion = reader["DescTipoPromocion"].ToString();
                PromocionValeDescuento.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionValeDescuentolist.Add(PromocionValeDescuento);
            }
            reader.Close();
            reader.Dispose();
            return PromocionValeDescuentolist;
        }

        public PromocionValeDescuentoBE Selecciona(int IdPromocionValeDescuento)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionValeDescuento_Selecciona");
			db.AddInParameter(dbCommand, "pIdPromocionValeDescuento", DbType.Int32, IdPromocionValeDescuento);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PromocionValeDescuentoBE PromocionValeDescuento = null;
			while (reader.Read())
			{
				PromocionValeDescuento = new PromocionValeDescuentoBE();
                PromocionValeDescuento.IdPromocionValeDescuento = Int32.Parse(reader["IdPromocionValeDescuento"].ToString());
                PromocionValeDescuento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionValeDescuento.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionValeDescuento.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionValeDescuento.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionValeDescuento.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionValeDescuento.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionValeDescuento.DescTienda = reader["DescTienda"].ToString();
                PromocionValeDescuento.Descripcion = reader["Descripcion"].ToString();
                PromocionValeDescuento.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionValeDescuento.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionValeDescuento.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                PromocionValeDescuento.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionValeDescuento.DescuentoDesde = Decimal.Parse(reader["DescuentoDesde"].ToString());
                PromocionValeDescuento.DescuentoHasta = Decimal.Parse(reader["DescuentoHasta"].ToString());
                PromocionValeDescuento.DescuentoAdicional = Decimal.Parse(reader["DescuentoAdicional"].ToString());
                PromocionValeDescuento.Importe = Decimal.Parse(reader["Importe"].ToString());
                PromocionValeDescuento.Observacion = reader["Observacion"].ToString();
                PromocionValeDescuento.IdTipoPromocion = Int32.Parse(reader["IdTipoPromocion"].ToString());
                PromocionValeDescuento.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return PromocionValeDescuento;
		}


	}
}
