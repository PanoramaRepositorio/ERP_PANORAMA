using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class MetaTiendaMesDL
	{
		public MetaTiendaMesDL() { }

		public Int32 Inserta(MetaTiendaMesBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_Inserta");

			db.AddOutParameter(dbCommand, "pIdMetaTiendaMes", DbType.Int32, pItem.IdMetaTiendaMes);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdMetaTiendaMes");

			return Id;
		}

		public void Actualiza(MetaTiendaMesBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_Actualiza");

			db.AddInParameter(dbCommand, "pIdMetaTiendaMes", DbType.Int32, pItem.IdMetaTiendaMes);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(MetaTiendaMesBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_Elimina");

			db.AddInParameter(dbCommand, "pIdMetaTiendaMes", DbType.Int32, pItem.IdMetaTiendaMes);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<MetaTiendaMesBE> ListaTodosActivo(int IdEmpresa, int Periodo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<MetaTiendaMesBE> MetaTiendaMeslist = new List<MetaTiendaMesBE>();
			MetaTiendaMesBE MetaTiendaMes;
			while (reader.Read())
			{
				MetaTiendaMes = new MetaTiendaMesBE();
				MetaTiendaMes.IdMetaTiendaMes = Int32.Parse(reader["IdMetaTiendaMes"].ToString());
				MetaTiendaMes.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				MetaTiendaMes.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetaTiendaMes.DescTienda = reader["DescTienda"].ToString();
                MetaTiendaMes.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                MetaTiendaMes.DescTipoCliente = reader["DescTipoCliente"].ToString();
                MetaTiendaMes.Periodo = Int32.Parse(reader["Periodo"].ToString());
				MetaTiendaMes.Mes = Int32.Parse(reader["Mes"].ToString());
                MetaTiendaMes.NombreMes = reader["NombreMes"].ToString();
                MetaTiendaMes.Importe = Decimal.Parse(reader["Importe"].ToString());
				MetaTiendaMes.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MetaTiendaMes.IdMetaTiendaMes = reader.IsDBNull(reader.GetOrdinal("IdMetaTiendaMes")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMetaTiendaMes"));
				MetaTiendaMeslist.Add(MetaTiendaMes);
			}
			reader.Close();
			reader.Dispose();
			return MetaTiendaMeslist;
		}

        public List<MetaTiendaMesBE> ListaTodosActivoHorizontal(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_ListaTodosActivoHorizontal");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MetaTiendaMesBE> MetaTiendaMeslist = new List<MetaTiendaMesBE>();
            MetaTiendaMesBE MetaTiendaMes;
            while (reader.Read())
            {
                MetaTiendaMes = new MetaTiendaMesBE();
                //MetaTiendaMes.IdMetaTiendaMes = Int32.Parse(reader["IdMetaTiendaMes"].ToString());
                MetaTiendaMes.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MetaTiendaMes.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetaTiendaMes.DescTienda = reader["DescTienda"].ToString();
                MetaTiendaMes.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                MetaTiendaMes.DescTipoCliente = reader["DescTipoCliente"].ToString();
                MetaTiendaMes.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetaTiendaMes.Enero = Decimal.Parse(reader["Enero"].ToString());
                MetaTiendaMes.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                MetaTiendaMes.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                MetaTiendaMes.Abril = Decimal.Parse(reader["Abril"].ToString());
                MetaTiendaMes.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                MetaTiendaMes.Junio = Decimal.Parse(reader["Junio"].ToString());
                MetaTiendaMes.Julio = Decimal.Parse(reader["Julio"].ToString());
                MetaTiendaMes.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                MetaTiendaMes.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                MetaTiendaMes.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                MetaTiendaMes.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                MetaTiendaMes.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                //MetaTiendaMes.IdMetaTiendaMes = reader.IsDBNull(reader.GetOrdinal("IdMetaTiendaMes")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMetaTiendaMes"));
                MetaTiendaMeslist.Add(MetaTiendaMes);
            }
            reader.Close();
            reader.Dispose();
            return MetaTiendaMeslist;
        }

        public MetaTiendaMesBE Selecciona(int IdMetaTiendaMes)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_Selecciona");
			db.AddInParameter(dbCommand, "pIdMetaTiendaMes", DbType.Int32, IdMetaTiendaMes);

			IDataReader reader = db.ExecuteReader(dbCommand);
			MetaTiendaMesBE MetaTiendaMes = null;
			while (reader.Read())
			{
				MetaTiendaMes = new MetaTiendaMesBE();
                MetaTiendaMes.IdMetaTiendaMes = Int32.Parse(reader["IdMetaTiendaMes"].ToString());
                MetaTiendaMes.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MetaTiendaMes.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetaTiendaMes.DescTienda = reader["DescTienda"].ToString();
                MetaTiendaMes.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                MetaTiendaMes.DescTipoCliente = reader["DescTipoCliente"].ToString();
                MetaTiendaMes.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetaTiendaMes.Mes = Int32.Parse(reader["Mes"].ToString());
                MetaTiendaMes.Importe = Decimal.Parse(reader["Importe"].ToString());
                MetaTiendaMes.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //MetaTiendaMes.IdMetaTiendaMes = reader.IsDBNull(reader.GetOrdinal("IdMetaTiendaMes")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMetaTiendaMes"));
			}
			reader.Close();
			reader.Dispose();
			return MetaTiendaMes;
		}

        public MetaTiendaMesBE SeleccionaTiendaTipoCliente(int IdTienda, int IdTipoCliente, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetaTiendaMes_SeleccionaTiendaTipoCliente");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MetaTiendaMesBE MetaTiendaMes = null;
            while (reader.Read())
            {
                MetaTiendaMes = new MetaTiendaMesBE();
                MetaTiendaMes.IdMetaTiendaMes = Int32.Parse(reader["IdMetaTiendaMes"].ToString());
                MetaTiendaMes.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MetaTiendaMes.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetaTiendaMes.DescTienda = reader["DescTienda"].ToString();
                MetaTiendaMes.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                MetaTiendaMes.DescTipoCliente = reader["DescTipoCliente"].ToString();
                MetaTiendaMes.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetaTiendaMes.Mes = Int32.Parse(reader["Mes"].ToString());
                MetaTiendaMes.Importe = Decimal.Parse(reader["Importe"].ToString());
                MetaTiendaMes.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //MetaTiendaMes.IdMetaTiendaMes = reader.IsDBNull(reader.GetOrdinal("IdMetaTiendaMes")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMetaTiendaMes"));
            }
            reader.Close();
            reader.Dispose();
            return MetaTiendaMes;
        }

    }
}
