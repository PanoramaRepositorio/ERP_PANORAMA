using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class TarjetaRegaloDL
	{
		public TarjetaRegaloDL() { }

		public Int32 Inserta(TarjetaRegaloBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_Inserta");

			db.AddOutParameter(dbCommand, "pIdTarjetaRegalo", DbType.Int32, pItem.IdTarjetaRegalo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pImporteTotal", DbType.Decimal, pItem.ImporteTotal);
			db.AddInParameter(dbCommand, "pImporteDisponible", DbType.Decimal, pItem.ImporteDisponible);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdTarjetaRegalo");

			return Id;
		}

		public void Actualiza(TarjetaRegaloBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_Actualiza");

			db.AddInParameter(dbCommand, "pIdTarjetaRegalo", DbType.Int32, pItem.IdTarjetaRegalo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pImporteTotal", DbType.Decimal, pItem.ImporteTotal);
			db.AddInParameter(dbCommand, "pImporteDisponible", DbType.Decimal, pItem.ImporteDisponible);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void ActualizaDisponible(TarjetaRegaloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_ActualizaDisponible");

            db.AddInParameter(dbCommand, "pIdTarjetaRegalo", DbType.Int32, pItem.IdTarjetaRegalo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pImporteTotal", DbType.Decimal, pItem.ImporteTotal);
            db.AddInParameter(dbCommand, "pImporteDisponible", DbType.Decimal, pItem.ImporteDisponible);
            db.AddInParameter(dbCommand, "pImporteUtilizado", DbType.Decimal, pItem.ImporteUtilizado);
            //db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            //db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(TarjetaRegaloBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_Elimina");

			db.AddInParameter(dbCommand, "pIdTarjetaRegalo", DbType.Int32, pItem.IdTarjetaRegalo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<TarjetaRegaloBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<TarjetaRegaloBE> TarjetaRegalolist = new List<TarjetaRegaloBE>();
			TarjetaRegaloBE TarjetaRegalo;
			while (reader.Read())
			{
				TarjetaRegalo = new TarjetaRegaloBE();
				TarjetaRegalo.IdTarjetaRegalo = Int32.Parse(reader["IdTarjetaRegalo"].ToString());
				TarjetaRegalo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				TarjetaRegalo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                TarjetaRegalo.DescTienda = reader["DescTienda"].ToString();
                TarjetaRegalo.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                TarjetaRegalo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TarjetaRegalo.DescCliente = reader["DescCliente"].ToString();
                TarjetaRegalo.Numero = reader["Numero"].ToString();
				TarjetaRegalo.ImporteTotal = Decimal.Parse(reader["ImporteTotal"].ToString());
				TarjetaRegalo.ImporteDisponible = Decimal.Parse(reader["ImporteDisponible"].ToString());
				TarjetaRegalo.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				TarjetaRegalo.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
				TarjetaRegalo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TarjetaRegalo.DescSituacion = reader["DescSituacion"].ToString();
                TarjetaRegalo.Observacion = reader["Observacion"].ToString();
				TarjetaRegalo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//TarjetaRegalo.IdTarjetaRegalo = reader.IsDBNull(reader.GetOrdinal("IdTarjetaRegalo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTarjetaRegalo"));
				TarjetaRegalolist.Add(TarjetaRegalo);
			}
			reader.Close();
			reader.Dispose();
			return TarjetaRegalolist;
		}

		public TarjetaRegaloBE Selecciona(int IdTarjetaRegalo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_Selecciona");
			db.AddInParameter(dbCommand, "pIdTarjetaRegalo", DbType.Int32, IdTarjetaRegalo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			TarjetaRegaloBE TarjetaRegalo = null;
			while (reader.Read())
			{
				TarjetaRegalo = new TarjetaRegaloBE();
                TarjetaRegalo.IdTarjetaRegalo = Int32.Parse(reader["IdTarjetaRegalo"].ToString());
                TarjetaRegalo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TarjetaRegalo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                TarjetaRegalo.DescTienda = reader["DescTienda"].ToString();
                TarjetaRegalo.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                TarjetaRegalo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TarjetaRegalo.DescCliente = reader["DescCliente"].ToString();
                TarjetaRegalo.Numero = reader["Numero"].ToString();
                TarjetaRegalo.ImporteTotal = Decimal.Parse(reader["ImporteTotal"].ToString());
                TarjetaRegalo.ImporteDisponible = Decimal.Parse(reader["ImporteDisponible"].ToString());
                TarjetaRegalo.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                TarjetaRegalo.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                TarjetaRegalo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TarjetaRegalo.DescSituacion = reader["DescSituacion"].ToString();
                TarjetaRegalo.Observacion = reader["Observacion"].ToString();
                TarjetaRegalo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TarjetaRegalo.IdTarjetaRegalo = reader.IsDBNull(reader.GetOrdinal("IdTarjetaRegalo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTarjetaRegalo"));
            }
			reader.Close();
			reader.Dispose();
			return TarjetaRegalo;
		}

        public TarjetaRegaloBE SeleccionaNumero(string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TarjetaRegalo_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TarjetaRegaloBE TarjetaRegalo = null;
            while (reader.Read())
            {
                TarjetaRegalo = new TarjetaRegaloBE();
                TarjetaRegalo.IdTarjetaRegalo = Int32.Parse(reader["IdTarjetaRegalo"].ToString());
                TarjetaRegalo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TarjetaRegalo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                TarjetaRegalo.DescTienda = reader["DescTienda"].ToString();
                TarjetaRegalo.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                TarjetaRegalo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TarjetaRegalo.DescCliente = reader["DescCliente"].ToString();
                TarjetaRegalo.Numero = reader["Numero"].ToString();
                TarjetaRegalo.ImporteTotal = Decimal.Parse(reader["ImporteTotal"].ToString());
                TarjetaRegalo.ImporteDisponible = Decimal.Parse(reader["ImporteDisponible"].ToString());
                TarjetaRegalo.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                TarjetaRegalo.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                TarjetaRegalo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TarjetaRegalo.DescSituacion = reader["DescSituacion"].ToString();
                TarjetaRegalo.Observacion = reader["Observacion"].ToString();
                TarjetaRegalo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TarjetaRegalo.IdTarjetaRegalo = reader.IsDBNull(reader.GetOrdinal("IdTarjetaRegalo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTarjetaRegalo"));
            }
            reader.Close();
            reader.Dispose();
            return TarjetaRegalo;
        }

    }
}
