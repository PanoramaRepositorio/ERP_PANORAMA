using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PromocionBultoDL
	{
		public PromocionBultoDL() { }

		public Int32 Inserta(PromocionBultoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBulto_Inserta");

			db.AddOutParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, pItem.IdPromocionBulto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescPromocionBulto", DbType.String, pItem.DescPromocionBulto);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPromocionBulto");

			return Id;
		}

		public void Actualiza(PromocionBultoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBulto_Actualiza");

			db.AddInParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, pItem.IdPromocionBulto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescPromocionBulto", DbType.String, pItem.DescPromocionBulto);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PromocionBultoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBulto_Elimina");

			db.AddInParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, pItem.IdPromocionBulto);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PromocionBultoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBulto_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PromocionBultoBE> PromocionBultolist = new List<PromocionBultoBE>();
			PromocionBultoBE PromocionBulto;
			while (reader.Read())
			{
				PromocionBulto = new PromocionBultoBE();
                PromocionBulto.IdPromocionBulto = Int32.Parse(reader["IdPromocionBulto"].ToString());
                PromocionBulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionBulto.RazonSocial = reader["RazonSocial"].ToString();
                PromocionBulto.DescPromocionBulto = reader["DescPromocionBulto"].ToString();
                PromocionBulto.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionBulto.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionBulto.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionBulto.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionBulto.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionBulto.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionBulto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PromocionBultolist.Add(PromocionBulto);
			}
			reader.Close();
			reader.Dispose();
			return PromocionBultolist;
		}

		public PromocionBultoBE Selecciona(int IdPromocionBulto)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBulto_Selecciona");
			db.AddInParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, IdPromocionBulto);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PromocionBultoBE PromocionBulto = null;
			while (reader.Read())
			{
				PromocionBulto = new PromocionBultoBE();
				PromocionBulto.IdPromocionBulto = Int32.Parse(reader["IdPromocionBulto"].ToString());
				PromocionBulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionBulto.RazonSocial = reader["RazonSocial"].ToString();
				PromocionBulto.DescPromocionBulto = reader["DescPromocionBulto"].ToString();
				PromocionBulto.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionBulto.DescTipoCliente = reader["DescTipoCliente"].ToString();
				PromocionBulto.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionBulto.DescFormaPago = reader["DescFormaPago"].ToString();
				PromocionBulto.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				PromocionBulto.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				PromocionBulto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PromocionBulto;
		}

	}
}
