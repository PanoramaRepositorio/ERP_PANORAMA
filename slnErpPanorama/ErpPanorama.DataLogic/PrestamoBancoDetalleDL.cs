using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PrestamoBancoDetalleDL
	{
		public PrestamoBancoDetalleDL() { }

		public Int32 Inserta(PrestamoBancoDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdPrestamoBancoDetalle", DbType.Int32, pItem.IdPrestamoBancoDetalle);
			db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
			db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
			db.AddInParameter(dbCommand, "pSaldoPendiente", DbType.Decimal, pItem.SaldoPendiente);
			db.AddInParameter(dbCommand, "pAmortizacion", DbType.Decimal, pItem.Amortizacion);
			db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
			db.AddInParameter(dbCommand, "pEnvioInformacion", DbType.Decimal, pItem.EnvioInformacion);
			db.AddInParameter(dbCommand, "pDesgravamen", DbType.Decimal, pItem.Desgravamen);
			db.AddInParameter(dbCommand, "pSeguro", DbType.Decimal, pItem.Seguro);
			db.AddInParameter(dbCommand, "pTotalPagar", DbType.Decimal, pItem.TotalPagar);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPrestamoBancoDetalle");

			return Id;
		}

		public void Actualiza(PrestamoBancoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdPrestamoBancoDetalle", DbType.Int32, pItem.IdPrestamoBancoDetalle);
			db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
			db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
			db.AddInParameter(dbCommand, "pSaldoPendiente", DbType.Decimal, pItem.SaldoPendiente);
			db.AddInParameter(dbCommand, "pAmortizacion", DbType.Decimal, pItem.Amortizacion);
			db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
			db.AddInParameter(dbCommand, "pEnvioInformacion", DbType.Decimal, pItem.EnvioInformacion);
			db.AddInParameter(dbCommand, "pDesgravamen", DbType.Decimal, pItem.Desgravamen);
			db.AddInParameter(dbCommand, "pSeguro", DbType.Decimal, pItem.Seguro);
			db.AddInParameter(dbCommand, "pTotalPagar", DbType.Decimal, pItem.TotalPagar);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PrestamoBancoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdPrestamoBancoDetalle", DbType.Int32, pItem.IdPrestamoBancoDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void ActualizaSituacion(PrestamoBancoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
            db.AddInParameter(dbCommand, "pIdPrestamoBancoDetalle", DbType.Int32, pItem.IdPrestamoBancoDetalle);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PrestamoBancoDetalleBE> ListaTodosActivo(int IdPrestamoBanco, int IdSituacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, IdPrestamoBanco);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<PrestamoBancoDetalleBE> PrestamoBancoDetallelist = new List<PrestamoBancoDetalleBE>();
			PrestamoBancoDetalleBE PrestamoBancoDetalle;
			while (reader.Read())
			{
				PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
				PrestamoBancoDetalle.IdPrestamoBancoDetalle = Int32.Parse(reader["IdPrestamoBancoDetalle"].ToString());
				PrestamoBancoDetalle.IdPrestamoBanco = Int32.Parse(reader["IdPrestamoBanco"].ToString());
				PrestamoBancoDetalle.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
				PrestamoBancoDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
				PrestamoBancoDetalle.SaldoPendiente = Decimal.Parse(reader["SaldoPendiente"].ToString());
				PrestamoBancoDetalle.Amortizacion = Decimal.Parse(reader["Amortizacion"].ToString());
				PrestamoBancoDetalle.Interes = Decimal.Parse(reader["Interes"].ToString());
				PrestamoBancoDetalle.EnvioInformacion = Decimal.Parse(reader["EnvioInformacion"].ToString());
				PrestamoBancoDetalle.Desgravamen = Decimal.Parse(reader["Desgravamen"].ToString());
				PrestamoBancoDetalle.Seguro = Decimal.Parse(reader["Seguro"].ToString());
				PrestamoBancoDetalle.TotalPagar = Decimal.Parse(reader["TotalPagar"].ToString());
                PrestamoBancoDetalle.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PrestamoBancoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                PrestamoBancoDetalle.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                PrestamoBancoDetalle.UsuarioPago = reader["UsuarioPago"].ToString();
                PrestamoBancoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				
				PrestamoBancoDetallelist.Add(PrestamoBancoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return PrestamoBancoDetallelist;
		}

		public PrestamoBancoDetalleBE Selecciona(int IdPrestamoBancoDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdPrestamoBancoDetalle", DbType.Int32, IdPrestamoBancoDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PrestamoBancoDetalleBE PrestamoBancoDetalle = null;
			while (reader.Read())
			{
				PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                PrestamoBancoDetalle.IdPrestamoBancoDetalle = Int32.Parse(reader["IdPrestamoBancoDetalle"].ToString());
                PrestamoBancoDetalle.IdPrestamoBanco = Int32.Parse(reader["IdPrestamoBanco"].ToString());
                PrestamoBancoDetalle.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                PrestamoBancoDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                PrestamoBancoDetalle.SaldoPendiente = Decimal.Parse(reader["SaldoPendiente"].ToString());
                PrestamoBancoDetalle.Amortizacion = Decimal.Parse(reader["Amortizacion"].ToString());
                PrestamoBancoDetalle.Interes = Decimal.Parse(reader["Interes"].ToString());
                PrestamoBancoDetalle.EnvioInformacion = Decimal.Parse(reader["EnvioInformacion"].ToString());
                PrestamoBancoDetalle.Desgravamen = Decimal.Parse(reader["Desgravamen"].ToString());
                PrestamoBancoDetalle.Seguro = Decimal.Parse(reader["Seguro"].ToString());
                PrestamoBancoDetalle.TotalPagar = Decimal.Parse(reader["TotalPagar"].ToString());
                PrestamoBancoDetalle.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                PrestamoBancoDetalle.DescSituacion = reader["DescSituacion"].ToString();
                PrestamoBancoDetalle.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                PrestamoBancoDetalle.UsuarioPago = reader["UsuarioPago"].ToString();
                PrestamoBancoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return PrestamoBancoDetalle;
		}

	}
}
