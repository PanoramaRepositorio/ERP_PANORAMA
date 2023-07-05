using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PrestamoBancoDL
	{
		public PrestamoBancoDL() { }

		public Int32 Inserta(PrestamoBancoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBanco_Inserta");

			db.AddOutParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
			db.AddInParameter(dbCommand, "pNumeroPrestamo", DbType.String, pItem.NumeroPrestamo);
			db.AddInParameter(dbCommand, "pCuentaCargo", DbType.String, pItem.CuentaCargo);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pNumeroCuotas", DbType.Int32, pItem.NumeroCuotas);
            db.AddInParameter(dbCommand, "pPrestamo", DbType.Decimal, pItem.Prestamo);
			db.AddInParameter(dbCommand, "pSaldoPrestamo", DbType.Decimal, pItem.SaldoPrestamo);
			db.AddInParameter(dbCommand, "pSaldoInteres", DbType.Decimal, pItem.SaldoInteres);
			db.AddInParameter(dbCommand, "pTotalInteres", DbType.Decimal, pItem.TotalInteres);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pTEA", DbType.Decimal, pItem.TEA);
			db.AddInParameter(dbCommand, "pTasaIntMoratorio", DbType.Decimal, pItem.TasaIntMoratorio);
            db.AddInParameter(dbCommand, "pIdTipoPrestamo", DbType.Decimal, pItem.IdTipoPrestamo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Observacion);
            db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPrestamoBanco");

			return Id;
		}

		public void Actualiza(PrestamoBancoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBanco_Actualiza");

			db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdCuentaBanco", DbType.Int32, pItem.IdCuentaBanco);
			db.AddInParameter(dbCommand, "pNumeroPrestamo", DbType.String, pItem.NumeroPrestamo);
			db.AddInParameter(dbCommand, "pCuentaCargo", DbType.String, pItem.CuentaCargo);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pNumeroCuotas", DbType.Int32, pItem.NumeroCuotas);
            db.AddInParameter(dbCommand, "pPrestamo", DbType.Decimal, pItem.Prestamo);
			db.AddInParameter(dbCommand, "pSaldoPrestamo", DbType.Decimal, pItem.SaldoPrestamo);
			db.AddInParameter(dbCommand, "pSaldoInteres", DbType.Decimal, pItem.SaldoInteres);
			db.AddInParameter(dbCommand, "pTotalInteres", DbType.Decimal, pItem.TotalInteres);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pTEA", DbType.Decimal, pItem.TEA);
			db.AddInParameter(dbCommand, "pTasaIntMoratorio", DbType.Decimal, pItem.TasaIntMoratorio);
            db.AddInParameter(dbCommand, "pIdTipoPrestamo", DbType.Decimal, pItem.IdTipoPrestamo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Observacion);

            db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PrestamoBancoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBanco_Elimina");

			db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public List<PrestamoBancoBE> ListaTodosActivo(int IdEmpresa, int IdSituacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBanco_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PrestamoBancoBE> PrestamoBancolist = new List<PrestamoBancoBE>();
			PrestamoBancoBE PrestamoBanco;
			while (reader.Read())
			{
				PrestamoBanco = new PrestamoBancoBE();
                PrestamoBanco.IdPrestamoBanco = Int32.Parse(reader["IdPrestamoBanco"].ToString());
                PrestamoBanco.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PrestamoBanco.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                PrestamoBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                PrestamoBanco.DescBanco = reader["DescBanco"].ToString();
                PrestamoBanco.NumeroCuenta = reader["NumeroCuenta"].ToString();
                PrestamoBanco.Titular = reader["Titular"].ToString();
                PrestamoBanco.NumeroPrestamo = reader["NumeroPrestamo"].ToString();
                PrestamoBanco.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                PrestamoBanco.CuentaCargo = reader["CuentaCargo"].ToString();
                PrestamoBanco.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PrestamoBanco.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                PrestamoBanco.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                PrestamoBanco.Prestamo = Decimal.Parse(reader["Prestamo"].ToString());
                PrestamoBanco.SaldoPrestamo = Decimal.Parse(reader["SaldoPrestamo"].ToString());
                PrestamoBanco.SaldoInteres = Decimal.Parse(reader["SaldoInteres"].ToString());
                PrestamoBanco.TotalInteres = Decimal.Parse(reader["TotalInteres"].ToString());
                PrestamoBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PrestamoBanco.DescMoneda = reader["DescMoneda"].ToString();
                PrestamoBanco.TEA = Decimal.Parse(reader["TEA"].ToString());
                PrestamoBanco.TasaIntMoratorio = Decimal.Parse(reader["TasaIntMoratorio"].ToString());
                PrestamoBanco.IdTipoPrestamo = int.Parse(reader["IdTipoPrestamo"].ToString());
                PrestamoBanco.DescTipoPrestamo = reader["DescTipoPrestamo"].ToString();
                PrestamoBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PrestamoBanco.Observacion =  (reader["Obs"].ToString());
                PrestamoBancolist.Add(PrestamoBanco);
			}
			reader.Close();
			reader.Dispose();
			return PrestamoBancolist;
		}

        public List<PrestamoBancoBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBanco_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PrestamoBancoBE> PrestamoBancolist = new List<PrestamoBancoBE>();
            PrestamoBancoBE PrestamoBanco;
            while (reader.Read())
            {
                PrestamoBanco = new PrestamoBancoBE();
                PrestamoBanco.IdPrestamoBanco = Int32.Parse(reader["IdPrestamoBanco"].ToString());
                //PrestamoBanco.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ////PrestamoBanco.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                //PrestamoBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                PrestamoBanco.DescBanco = reader["DescBanco"].ToString();
                PrestamoBanco.Titular = reader["Titular"].ToString();
                PrestamoBanco.NumeroPrestamo = reader["NumeroPrestamo"].ToString();
                //PrestamoBanco.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                PrestamoBanco.CuentaCargo = reader["CuentaCargo"].ToString();
                PrestamoBanco.DescTipoPrestamo = reader["DescTipoPrestamo"].ToString();
                PrestamoBanco.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PrestamoBanco.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                PrestamoBanco.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                PrestamoBanco.Prestamo = Decimal.Parse(reader["Prestamo"].ToString());
                PrestamoBanco.SaldoPrestamo = Decimal.Parse(reader["SaldoPrestamo"].ToString());
                PrestamoBanco.SaldoInteres = Decimal.Parse(reader["SaldoInteres"].ToString());
                PrestamoBanco.TotalInteres = Decimal.Parse(reader["TotalInteres"].ToString());
                //PrestamoBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PrestamoBanco.DescMoneda = reader["DescMoneda"].ToString();
                PrestamoBanco.TEA = Decimal.Parse(reader["TEA"].ToString());
                PrestamoBanco.TasaIntMoratorio = Decimal.Parse(reader["TasaIntMoratorio"].ToString());
                //PrestamoBanco.IdTipoPrestamo = int.Parse(reader["IdTipoPrestamo"].ToString());
                //PrestamoBanco.DescTipoPrestamo = reader["DescTipoPrestamo"].ToString();

                PrestamoBanco.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                PrestamoBanco.SaldoPendiente = Decimal.Parse(reader["SaldoPendiente"].ToString());
                PrestamoBanco.Amortizacion = Decimal.Parse(reader["Amortizacion"].ToString());
                PrestamoBanco.Interes = Decimal.Parse(reader["Interes"].ToString());
                PrestamoBanco.TotalPagar = Decimal.Parse(reader["TotalPagar"].ToString());
                PrestamoBanco.DescSituacion = reader["DescSituacion"].ToString();
                PrestamoBanco.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                PrestamoBanco.UsuarioPago = reader["UsuarioPago"].ToString();

                PrestamoBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PrestamoBancolist.Add(PrestamoBanco);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public PrestamoBancoBE Selecciona(int IdPrestamoBanco)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBanco_Selecciona");
			db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, IdPrestamoBanco);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PrestamoBancoBE PrestamoBanco = null;
			while (reader.Read())
			{
				PrestamoBanco = new PrestamoBancoBE();
                PrestamoBanco.IdPrestamoBanco = Int32.Parse(reader["IdPrestamoBanco"].ToString());
                PrestamoBanco.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PrestamoBanco.IdCuentaBanco = Int32.Parse(reader["IdCuentaBanco"].ToString());
                PrestamoBanco.IdBanco = Int32.Parse(reader["IdBanco"].ToString());
                PrestamoBanco.DescBanco = reader["DescBanco"].ToString();
                PrestamoBanco.Titular = reader["Titular"].ToString();
                PrestamoBanco.NumeroPrestamo = reader["NumeroPrestamo"].ToString();
                PrestamoBanco.LineaCredito = Decimal.Parse(reader["LineaCredito"].ToString());
                PrestamoBanco.CuentaCargo = reader["CuentaCargo"].ToString();
                PrestamoBanco.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PrestamoBanco.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                PrestamoBanco.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                PrestamoBanco.Prestamo = Decimal.Parse(reader["Prestamo"].ToString());
                PrestamoBanco.SaldoPrestamo = Decimal.Parse(reader["SaldoPrestamo"].ToString());
                PrestamoBanco.SaldoInteres = Decimal.Parse(reader["SaldoInteres"].ToString());
                PrestamoBanco.TotalInteres = Decimal.Parse(reader["TotalInteres"].ToString());
                PrestamoBanco.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                PrestamoBanco.DescMoneda = reader["DescMoneda"].ToString();
                PrestamoBanco.TEA = Decimal.Parse(reader["TEA"].ToString());
                PrestamoBanco.TasaIntMoratorio = Decimal.Parse(reader["TasaIntMoratorio"].ToString());
                PrestamoBanco.IdTipoPrestamo = int.Parse(reader["IdTipoPrestamo"].ToString());
                PrestamoBanco.DescTipoPrestamo = reader["DescTipoPrestamo"].ToString();
                PrestamoBanco.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PrestamoBanco.Observacion = reader["Obs"].ToString();
            }
			reader.Close();
			reader.Dispose();
			return PrestamoBanco;
		}

        public List<PrestamoBancoBE> ListaTodosActivoAñoMes(int IdEmpresa,int Moneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPrestamoBanco_AñoMes");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pMoneda", DbType.Int32, Moneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PrestamoBancoBE> PrestamoBancolist = new List<PrestamoBancoBE>();
            PrestamoBancoBE PrestamoBanco;
            while (reader.Read())
            {
                PrestamoBanco = new PrestamoBancoBE();
                PrestamoBanco.Año = Int32.Parse(reader["Año"].ToString());
                PrestamoBanco.Enero = Decimal.Parse(reader["Enero"].ToString());
                PrestamoBanco.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                PrestamoBanco.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                PrestamoBanco.Abril = Decimal.Parse(reader["Abril"].ToString());
                PrestamoBanco.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                PrestamoBanco.Junio = Decimal.Parse(reader["Junio"].ToString());
                PrestamoBanco.Julio = Decimal.Parse(reader["Julio"].ToString());
                PrestamoBanco.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                PrestamoBanco.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                PrestamoBanco.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                PrestamoBanco.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                PrestamoBanco.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                PrestamoBanco.Importe = Decimal.Parse(reader["Importe"].ToString());
                PrestamoBancolist.Add(PrestamoBanco);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public List<PrestamoBancoBE> ListaTodosActivoPagos(int Moneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPrestamoBanco_Pagos");
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pMoneda", DbType.Int32, Moneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PrestamoBancoBE> PrestamoBancolist = new List<PrestamoBancoBE>();
            PrestamoBancoBE PrestamoBanco;
            while (reader.Read())
            {
                PrestamoBanco = new PrestamoBancoBE();
                PrestamoBanco.Año = Int32.Parse(reader["Año"].ToString());
                PrestamoBanco.Enero = Decimal.Parse(reader["Enero"].ToString());
                PrestamoBanco.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                PrestamoBanco.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                PrestamoBanco.Abril = Decimal.Parse(reader["Abril"].ToString());
                PrestamoBanco.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                PrestamoBanco.Junio = Decimal.Parse(reader["Junio"].ToString());
                PrestamoBanco.Julio = Decimal.Parse(reader["Julio"].ToString());
                PrestamoBanco.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                PrestamoBanco.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                PrestamoBanco.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                PrestamoBanco.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                PrestamoBanco.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                PrestamoBanco.Importe = Decimal.Parse(reader["Importe"].ToString());
                PrestamoBancolist.Add(PrestamoBanco);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

    }
}
