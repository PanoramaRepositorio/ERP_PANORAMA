using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PromocionMarcaDL
	{
		public PromocionMarcaDL() { }

		public Int32 Inserta(PromocionMarcaBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarca_Inserta");

			db.AddOutParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, pItem.IdPromocionMarca);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
			db.AddInParameter(dbCommand, "pVale", DbType.Decimal, pItem.Vale);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPromocionMarca");

			return Id;
		}

		public void Actualiza(PromocionMarcaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarca_Actualiza");

			db.AddInParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, pItem.IdPromocionMarca);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdMarca", DbType.Int32, pItem.IdMarca);
			db.AddInParameter(dbCommand, "pMontoMin", DbType.Decimal, pItem.MontoMin);
			db.AddInParameter(dbCommand, "pMontoMax", DbType.Decimal, pItem.MontoMax);
			db.AddInParameter(dbCommand, "pVale", DbType.Decimal, pItem.Vale);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PromocionMarcaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarca_Elimina");

			db.AddInParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, pItem.IdPromocionMarca);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PromocionMarcaBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarca_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PromocionMarcaBE> PromocionMarcalist = new List<PromocionMarcaBE>();
			PromocionMarcaBE PromocionMarca;
			while (reader.Read())
			{
				PromocionMarca = new PromocionMarcaBE();
				PromocionMarca.IdPromocionMarca = Int32.Parse(reader["IdPromocionMarca"].ToString());
				PromocionMarca.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PromocionMarca.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
				PromocionMarca.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
				PromocionMarca.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
				PromocionMarca.Vale = Decimal.Parse(reader["Vale"].ToString());
				PromocionMarca.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//PromocionMarca.IdPromocionMarca = reader.IsDBNull(reader.GetOrdinal("IdPromocionMarca")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPromocionMarca"));
				PromocionMarcalist.Add(PromocionMarca);
			}
			reader.Close();
			reader.Dispose();
			return PromocionMarcalist;
		}

        public List<PromocionMarcaBE> ListaFecha(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarca_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionMarcaBE> PromocionMarcalist = new List<PromocionMarcaBE>();
            PromocionMarcaBE PromocionMarca;
            while (reader.Read())
            {
                PromocionMarca = new PromocionMarcaBE();
                PromocionMarca.IdPromocionMarca = Int32.Parse(reader["IdPromocionMarca"].ToString());
                PromocionMarca.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionMarca.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PromocionMarca.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
                PromocionMarca.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
                PromocionMarca.Vale = Decimal.Parse(reader["Vale"].ToString());
                PromocionMarca.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionMarca.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionMarca.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //PromocionMarca.IdPromocionMarca = reader.IsDBNull(reader.GetOrdinal("IdPromocionMarca")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPromocionMarca"));
                PromocionMarcalist.Add(PromocionMarca);
            }
            reader.Close();
            reader.Dispose();
            return PromocionMarcalist;
        }

        public PromocionMarcaBE Selecciona(int IdPromocionMarca)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionMarca_Selecciona");
			db.AddInParameter(dbCommand, "pIdPromocionMarca", DbType.Int32, IdPromocionMarca);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PromocionMarcaBE PromocionMarca = null;
			while (reader.Read())
			{
				PromocionMarca = new PromocionMarcaBE();
				PromocionMarca.IdPromocionMarca = Int32.Parse(reader["IdPromocionMarca"].ToString());
				PromocionMarca.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				PromocionMarca.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
				PromocionMarca.MontoMin = Decimal.Parse(reader["MontoMin"].ToString());
				PromocionMarca.MontoMax = Decimal.Parse(reader["MontoMax"].ToString());
				PromocionMarca.Vale = Decimal.Parse(reader["Vale"].ToString());
				PromocionMarca.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PromocionMarca;
		}

	}
}
