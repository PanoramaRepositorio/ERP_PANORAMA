using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMovimientoCajaDL
    {
        public List<ReporteMovimientoCajaBE> Listado(int IdEmpresa, int IdCaja, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCaja");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.CajaInicial = Decimal.Parse(reader["CajaInicial"].ToString());
                MovimientoCaja.TotalVisa = Decimal.Parse(reader["TotalVisa"].ToString());
                MovimientoCaja.TotalMastercard = Decimal.Parse(reader["TotalMastercard"].ToString());
                MovimientoCaja.TotalVisaPuntosVida = Decimal.Parse(reader["TotalVisaPuntosVida"].ToString());
                MovimientoCaja.TotalMastercardPuntosVida = Decimal.Parse(reader["TotalMastercardPuntosVida"].ToString());
                MovimientoCaja.TotalNotaCredito = Decimal.Parse(reader["TotalNotaCredito"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                MovimientoCaja.TotalCheques = Decimal.Parse(reader["TotalCheques"].ToString());
                MovimientoCaja.TotalCupon = Decimal.Parse(reader["TotalCupon"].ToString());
                MovimientoCaja.TotalPagos = Decimal.Parse(reader["TotalPagos"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.TotalIngresos = Decimal.Parse(reader["TotalIngresos"].ToString());
                MovimientoCaja.TotalEgresos = Decimal.Parse(reader["TotalEgresos"].ToString());
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.TotalVisaAgente = Decimal.Parse(reader["TotalVisaAgente"].ToString());
                MovimientoCaja.TotalMastercardAgente = Decimal.Parse(reader["TotalMastercardAgente"].ToString());
                MovimientoCaja.TotalIngresosAgente = Decimal.Parse(reader["TotalIngresosAgente"].ToString());
                MovimientoCaja.TotalEgresosAgente = Decimal.Parse(reader["TotalEgresosAgente"].ToString());
                MovimientoCaja.Estado = reader["estado"].ToString();
                MovimientoCaja.Doscientos = Decimal.Parse(reader["Doscientos"].ToString());
                MovimientoCaja.Cien = Decimal.Parse(reader["Cien"].ToString());
                MovimientoCaja.Cincuenta = Decimal.Parse(reader["Cincuenta"].ToString());
                MovimientoCaja.Veinte = Decimal.Parse(reader["Veinte"].ToString());
                MovimientoCaja.Diez = Decimal.Parse(reader["Diez"].ToString());
                MovimientoCaja.Cinco = Decimal.Parse(reader["Cinco"].ToString());
                MovimientoCaja.Dos = Decimal.Parse(reader["Dos"].ToString());
                MovimientoCaja.Un = Decimal.Parse(reader["Un"].ToString());
                MovimientoCaja.CincuentaCentimos = Decimal.Parse(reader["CincuentaCentimos"].ToString());
                MovimientoCaja.VeinteCentimos = Decimal.Parse(reader["VeinteCentimos"].ToString());
                MovimientoCaja.DiezCentimos = Decimal.Parse(reader["DiezCentimos"].ToString());
                MovimientoCaja.TipoCambioVenta = Decimal.Parse(reader["TipoCambioVenta"].ToString());
                MovimientoCaja.CienDolar = Decimal.Parse(reader["CienDolar"].ToString());
                MovimientoCaja.CincuentaDolar = Decimal.Parse(reader["CincuentaDolar"].ToString());
                MovimientoCaja.VeinteDolar = Decimal.Parse(reader["VeinteDolar"].ToString());
                MovimientoCaja.DiezDolar = Decimal.Parse(reader["DiezDolar"].ToString());
                MovimientoCaja.CincoDolar = Decimal.Parse(reader["CincoDolar"].ToString());
                MovimientoCaja.UnDolar = Decimal.Parse(reader["UnDolar"].ToString());
                MovimientoCaja.TotalVisaCredito = Decimal.Parse(reader["TotalVisaCredito"].ToString());
                MovimientoCaja.TotalVisaDebito = Decimal.Parse(reader["TotalVisaDebito"].ToString());
                MovimientoCaja.TotalMastercardCredito = Decimal.Parse(reader["TotalMastercardCredito"].ToString());
                MovimientoCaja.TotalMastercardDebito = Decimal.Parse(reader["TotalMastercardDebito"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoTienda(int IdEmpresa,int IdTienda, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaTienda");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.CajaInicial = Decimal.Parse(reader["CajaInicial"].ToString());
                MovimientoCaja.TotalVisa = Decimal.Parse(reader["TotalVisa"].ToString());
                MovimientoCaja.TotalMastercard = Decimal.Parse(reader["TotalMastercard"].ToString());
                MovimientoCaja.TotalVisaPuntosVida = Decimal.Parse(reader["TotalVisaPuntosVida"].ToString());
                MovimientoCaja.TotalMastercardPuntosVida = Decimal.Parse(reader["TotalMastercardPuntosVida"].ToString());
                MovimientoCaja.TotalNotaCredito = Decimal.Parse(reader["TotalNotaCredito"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                MovimientoCaja.TotalCheques = Decimal.Parse(reader["TotalCheques"].ToString());
                MovimientoCaja.TotalCupon = Decimal.Parse(reader["TotalCupon"].ToString());
                MovimientoCaja.TotalPagos = Decimal.Parse(reader["TotalPagos"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.TotalIngresos = Decimal.Parse(reader["TotalIngresos"].ToString());
                MovimientoCaja.TotalEgresos = Decimal.Parse(reader["TotalEgresos"].ToString());
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.TotalVisaAgente = Decimal.Parse(reader["TotalVisaAgente"].ToString());
                MovimientoCaja.TotalMastercardAgente = Decimal.Parse(reader["TotalMastercardAgente"].ToString());
                MovimientoCaja.TotalIngresosAgente = Decimal.Parse(reader["TotalIngresosAgente"].ToString());
                MovimientoCaja.TotalEgresosAgente = Decimal.Parse(reader["TotalEgresosAgente"].ToString());
                MovimientoCaja.Estado = reader["estado"].ToString();
                MovimientoCaja.Doscientos = Decimal.Parse(reader["Doscientos"].ToString());
                MovimientoCaja.Cien = Decimal.Parse(reader["Cien"].ToString());
                MovimientoCaja.Cincuenta = Decimal.Parse(reader["Cincuenta"].ToString());
                MovimientoCaja.Veinte = Decimal.Parse(reader["Veinte"].ToString());
                MovimientoCaja.Diez = Decimal.Parse(reader["Diez"].ToString());
                MovimientoCaja.Cinco = Decimal.Parse(reader["Cinco"].ToString());
                MovimientoCaja.Dos = Decimal.Parse(reader["Dos"].ToString());
                MovimientoCaja.Un = Decimal.Parse(reader["Un"].ToString());
                MovimientoCaja.CincuentaCentimos = Decimal.Parse(reader["CincuentaCentimos"].ToString());
                MovimientoCaja.VeinteCentimos = Decimal.Parse(reader["VeinteCentimos"].ToString());
                MovimientoCaja.DiezCentimos = Decimal.Parse(reader["DiezCentimos"].ToString());
                MovimientoCaja.TipoCambioVenta = Decimal.Parse(reader["TipoCambioVenta"].ToString());
                MovimientoCaja.CienDolar = Decimal.Parse(reader["CienDolar"].ToString());
                MovimientoCaja.CincuentaDolar = Decimal.Parse(reader["CincuentaDolar"].ToString());
                MovimientoCaja.VeinteDolar = Decimal.Parse(reader["VeinteDolar"].ToString());
                MovimientoCaja.DiezDolar = Decimal.Parse(reader["DiezDolar"].ToString());
                MovimientoCaja.CincoDolar = Decimal.Parse(reader["CincoDolar"].ToString());
                MovimientoCaja.UnDolar = Decimal.Parse(reader["UnDolar"].ToString());
                MovimientoCaja.TotalVisaCredito = Decimal.Parse(reader["TotalVisaCredito"].ToString());
                MovimientoCaja.TotalVisaDebito = Decimal.Parse(reader["TotalVisaDebito"].ToString());
                MovimientoCaja.TotalMastercardCredito = Decimal.Parse(reader["TotalMastercardCredito"].ToString());
                MovimientoCaja.TotalMastercardDebito = Decimal.Parse(reader["TotalMastercardDebito"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }

            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoTarjeta(int IdTienda, int IdCaja, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaTarjeta");

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoDocumento(int IdEmpresa,int IdCaja, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaPorDocumento");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.CajaInicial = Decimal.Parse(reader["CajaInicial"].ToString());
                MovimientoCaja.TotalVisa = Decimal.Parse(reader["TotalVisa"].ToString());
                MovimientoCaja.TotalMastercard = Decimal.Parse(reader["TotalMastercard"].ToString());
                MovimientoCaja.TotalVisaPuntosVida = Decimal.Parse(reader["TotalVisaPuntosVida"].ToString());

                MovimientoCaja.TotalDrinerclubPromocion = Decimal.Parse(reader["TotalDrinerclubPromocion"].ToString());
                MovimientoCaja.TotalTarjetasForaneas = Decimal.Parse(reader["TotalTarjetasForaneas"].ToString());

                MovimientoCaja.TotalMastercardPuntosVida = Decimal.Parse(reader["TotalMastercardPuntosVida"].ToString());
                MovimientoCaja.TotalNotaCredito = Decimal.Parse(reader["TotalNotaCredito"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                MovimientoCaja.TotalCupon = Decimal.Parse(reader["TotalCupon"].ToString());
                MovimientoCaja.TotalCheques = Decimal.Parse(reader["TotalCheques"].ToString());
                MovimientoCaja.TotalPagos = Decimal.Parse(reader["TotalPagos"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.TotalIngresos = Decimal.Parse(reader["TotalIngresos"].ToString());
                MovimientoCaja.TotalEgresos = Decimal.Parse(reader["TotalEgresos"].ToString());
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.TotalVisaAgente = Decimal.Parse(reader["TotalVisaAgente"].ToString());
                MovimientoCaja.TotalMastercardAgente = Decimal.Parse(reader["TotalMastercardAgente"].ToString());
                MovimientoCaja.TotalIngresosAgente = Decimal.Parse(reader["TotalIngresosAgente"].ToString());
                MovimientoCaja.TotalEgresosAgente = Decimal.Parse(reader["TotalEgresosAgente"].ToString());
                MovimientoCaja.Estado = reader["estado"].ToString();
                MovimientoCaja.Doscientos = Decimal.Parse(reader["Doscientos"].ToString());
                MovimientoCaja.Cien = Decimal.Parse(reader["Cien"].ToString());
                MovimientoCaja.Cincuenta = Decimal.Parse(reader["Cincuenta"].ToString());
                MovimientoCaja.Veinte = Decimal.Parse(reader["Veinte"].ToString());
                MovimientoCaja.Diez = Decimal.Parse(reader["Diez"].ToString());
                MovimientoCaja.Cinco = Decimal.Parse(reader["Cinco"].ToString());
                MovimientoCaja.Dos = Decimal.Parse(reader["Dos"].ToString());
                MovimientoCaja.Un = Decimal.Parse(reader["Un"].ToString());
                MovimientoCaja.CincuentaCentimos = Decimal.Parse(reader["CincuentaCentimos"].ToString());
                MovimientoCaja.VeinteCentimos = Decimal.Parse(reader["VeinteCentimos"].ToString());
                MovimientoCaja.DiezCentimos = Decimal.Parse(reader["DiezCentimos"].ToString());
                MovimientoCaja.TipoCambioVenta = Decimal.Parse(reader["TipoCambioVenta"].ToString());
                MovimientoCaja.CienDolar = Decimal.Parse(reader["CienDolar"].ToString());
                MovimientoCaja.CincuentaDolar = Decimal.Parse(reader["CincuentaDolar"].ToString());
                MovimientoCaja.VeinteDolar = Decimal.Parse(reader["VeinteDolar"].ToString());
                MovimientoCaja.DiezDolar = Decimal.Parse(reader["DiezDolar"].ToString());
                MovimientoCaja.CincoDolar = Decimal.Parse(reader["CincoDolar"].ToString());
                MovimientoCaja.UnDolar = Decimal.Parse(reader["UnDolar"].ToString());
                MovimientoCaja.TotalVisaCredito = Decimal.Parse(reader["TotalVisaCredito"].ToString());
                MovimientoCaja.TotalVisaDebito = Decimal.Parse(reader["TotalVisaDebito"].ToString());
                MovimientoCaja.TotalMastercardCredito = Decimal.Parse(reader["TotalMastercardCredito"].ToString());
                MovimientoCaja.TotalMastercardDebito = Decimal.Parse(reader["TotalMastercardDebito"].ToString());

                MovimientoCaja.TotalDinnersPromocion = Decimal.Parse(reader["TotalDinnersPromocion"].ToString());
                MovimientoCaja.TotalDinnersPromocionCredito = Decimal.Parse(reader["TotalDinnersPromocionCredito"].ToString());
                MovimientoCaja.TotalDinnersPromocionDebito = Decimal.Parse(reader["TotalDinnersPromocionDebito"].ToString());

                MovimientoCaja.TotalTarjForaneas = Decimal.Parse(reader["TotalTarjForaneas"].ToString());
                MovimientoCaja.TotalTarjForaneasCredito = Decimal.Parse(reader["TotalTarjForaneasCredito"].ToString());
                MovimientoCaja.TotalTarjForaneasDebito = Decimal.Parse(reader["TotalTarjForaneasDebito"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoDocumentoTienda(int IdEmpresa,int IdTienda, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaTiendaPorDocumento");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.CajaInicial = Decimal.Parse(reader["CajaInicial"].ToString());
                MovimientoCaja.TotalVisa = Decimal.Parse(reader["TotalVisa"].ToString());
                MovimientoCaja.TotalMastercard = Decimal.Parse(reader["TotalMastercard"].ToString());
                MovimientoCaja.TotalVisaPuntosVida = Decimal.Parse(reader["TotalVisaPuntosVida"].ToString());
                MovimientoCaja.TotalMastercardPuntosVida = Decimal.Parse(reader["TotalMastercardPuntosVida"].ToString());
                MovimientoCaja.TotalNotaCredito = Decimal.Parse(reader["TotalNotaCredito"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                MovimientoCaja.TotalCheques = Decimal.Parse(reader["TotalCheques"].ToString());
                MovimientoCaja.TotalCupon = Decimal.Parse(reader["TotalCupon"].ToString());
                MovimientoCaja.TotalPagos = Decimal.Parse(reader["TotalPagos"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.TotalIngresos = Decimal.Parse(reader["TotalIngresos"].ToString());
                MovimientoCaja.TotalEgresos = Decimal.Parse(reader["TotalEgresos"].ToString());
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.TotalVisaAgente = Decimal.Parse(reader["TotalVisaAgente"].ToString());
                MovimientoCaja.TotalMastercardAgente = Decimal.Parse(reader["TotalMastercardAgente"].ToString());
                MovimientoCaja.TotalIngresosAgente = Decimal.Parse(reader["TotalIngresosAgente"].ToString());
                MovimientoCaja.TotalEgresosAgente = Decimal.Parse(reader["TotalEgresosAgente"].ToString());
                MovimientoCaja.Estado = reader["estado"].ToString();
                MovimientoCaja.Doscientos = Decimal.Parse(reader["Doscientos"].ToString());
                MovimientoCaja.Cien = Decimal.Parse(reader["Cien"].ToString());
                MovimientoCaja.Cincuenta = Decimal.Parse(reader["Cincuenta"].ToString());
                MovimientoCaja.Veinte = Decimal.Parse(reader["Veinte"].ToString());
                MovimientoCaja.Diez = Decimal.Parse(reader["Diez"].ToString());
                MovimientoCaja.Cinco = Decimal.Parse(reader["Cinco"].ToString());
                MovimientoCaja.Dos = Decimal.Parse(reader["Dos"].ToString());
                MovimientoCaja.Un = Decimal.Parse(reader["Un"].ToString());
                MovimientoCaja.CincuentaCentimos = Decimal.Parse(reader["CincuentaCentimos"].ToString());
                MovimientoCaja.VeinteCentimos = Decimal.Parse(reader["VeinteCentimos"].ToString());
                MovimientoCaja.DiezCentimos = Decimal.Parse(reader["DiezCentimos"].ToString());
                MovimientoCaja.TipoCambioVenta = Decimal.Parse(reader["TipoCambioVenta"].ToString());
                MovimientoCaja.CienDolar = Decimal.Parse(reader["CienDolar"].ToString());
                MovimientoCaja.CincuentaDolar = Decimal.Parse(reader["CincuentaDolar"].ToString());
                MovimientoCaja.VeinteDolar = Decimal.Parse(reader["VeinteDolar"].ToString());
                MovimientoCaja.DiezDolar = Decimal.Parse(reader["DiezDolar"].ToString());
                MovimientoCaja.CincoDolar = Decimal.Parse(reader["CincoDolar"].ToString());
                MovimientoCaja.UnDolar = Decimal.Parse(reader["UnDolar"].ToString());
                MovimientoCaja.TotalVisaCredito = Decimal.Parse(reader["TotalVisaCredito"].ToString());
                MovimientoCaja.TotalVisaDebito = Decimal.Parse(reader["TotalVisaDebito"].ToString());
                MovimientoCaja.TotalMastercardCredito = Decimal.Parse(reader["TotalMastercardCredito"].ToString());
                MovimientoCaja.TotalMastercardDebito = Decimal.Parse(reader["TotalMastercardDebito"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoDocumentoResumen(int IdEmpresa, int IdCaja, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCaja_Resumen");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoMovimiento = reader["TipoMovimiento"].ToString();
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.CajaInicial = Decimal.Parse(reader["CajaInicial"].ToString());
                MovimientoCaja.TotalVisa = Decimal.Parse(reader["TotalVisa"].ToString());
                MovimientoCaja.TotalMastercard = Decimal.Parse(reader["TotalMastercard"].ToString());
                MovimientoCaja.TotalVisaPuntosVida = Decimal.Parse(reader["TotalVisaPuntosVida"].ToString());
                MovimientoCaja.TotalMastercardPuntosVida = Decimal.Parse(reader["TotalMastercardPuntosVida"].ToString());
                MovimientoCaja.TotalNotaCredito = Decimal.Parse(reader["TotalNotaCredito"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                MovimientoCaja.TotalCheques = Decimal.Parse(reader["TotalCheques"].ToString());
                MovimientoCaja.TotalCupon = Decimal.Parse(reader["TotalCupon"].ToString());
                MovimientoCaja.TotalPagos = Decimal.Parse(reader["TotalPagos"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.TotalIngresos = Decimal.Parse(reader["TotalIngresos"].ToString());
                MovimientoCaja.TotalEgresos = Decimal.Parse(reader["TotalEgresos"].ToString());
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.TotalVisaAgente = Decimal.Parse(reader["TotalVisaAgente"].ToString());
                MovimientoCaja.TotalMastercardAgente = Decimal.Parse(reader["TotalMastercardAgente"].ToString());
                MovimientoCaja.TotalIngresosAgente = Decimal.Parse(reader["TotalIngresosAgente"].ToString());
                MovimientoCaja.TotalEgresosAgente = Decimal.Parse(reader["TotalEgresosAgente"].ToString());
                MovimientoCaja.Estado = reader["estado"].ToString();
                MovimientoCaja.Doscientos = Decimal.Parse(reader["Doscientos"].ToString());
                MovimientoCaja.Cien = Decimal.Parse(reader["Cien"].ToString());
                MovimientoCaja.Cincuenta = Decimal.Parse(reader["Cincuenta"].ToString());
                MovimientoCaja.Veinte = Decimal.Parse(reader["Veinte"].ToString());
                MovimientoCaja.Diez = Decimal.Parse(reader["Diez"].ToString());
                MovimientoCaja.Cinco = Decimal.Parse(reader["Cinco"].ToString());
                MovimientoCaja.Dos = Decimal.Parse(reader["Dos"].ToString());
                MovimientoCaja.Un = Decimal.Parse(reader["Un"].ToString());
                MovimientoCaja.CincuentaCentimos = Decimal.Parse(reader["CincuentaCentimos"].ToString());
                MovimientoCaja.VeinteCentimos = Decimal.Parse(reader["VeinteCentimos"].ToString());
                MovimientoCaja.DiezCentimos = Decimal.Parse(reader["DiezCentimos"].ToString());
                MovimientoCaja.TipoCambioVenta = Decimal.Parse(reader["TipoCambioVenta"].ToString());
                MovimientoCaja.CienDolar = Decimal.Parse(reader["CienDolar"].ToString());
                MovimientoCaja.CincuentaDolar = Decimal.Parse(reader["CincuentaDolar"].ToString());
                MovimientoCaja.VeinteDolar = Decimal.Parse(reader["VeinteDolar"].ToString());
                MovimientoCaja.DiezDolar = Decimal.Parse(reader["DiezDolar"].ToString());
                MovimientoCaja.CincoDolar = Decimal.Parse(reader["CincoDolar"].ToString());
                MovimientoCaja.UnDolar = Decimal.Parse(reader["UnDolar"].ToString());
                MovimientoCaja.CantidadVisa = Int32.Parse(reader["CantidadVisa"].ToString());
                MovimientoCaja.CantidadMaster = Int32.Parse(reader["CantidadMaster"].ToString());
                MovimientoCaja.TotalVisaCredito = Decimal.Parse(reader["TotalVisaCredito"].ToString());
                MovimientoCaja.TotalVisaDebito = Decimal.Parse(reader["TotalVisaDebito"].ToString());
                MovimientoCaja.TotalMastercardCredito = Decimal.Parse(reader["TotalMastercardCredito"].ToString());
                MovimientoCaja.TotalMastercardDebito = Decimal.Parse(reader["TotalMastercardDebito"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoCuadreCaja(int IdEmpresa,int IdTienda, int IdCaja, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaTiendaDiferencia");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                //MovimientoCaja = new ReporteMovimientoCajaBE();
                //MovimientoCaja.Periodo = Int32.Parse(reader["Periodo"].ToString());
                //MovimientoCaja.Mes = Int32.Parse(reader["Mes"].ToString());
                //MovimientoCaja.NombreMes = reader["NombreMes"].ToString();
                //MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                //MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                //MovimientoCaja.TotalVenta = Decimal.Parse(reader["TotalVenta"].ToString());
                //MovimientoCaja.Diferencia = Decimal.Parse(reader["Diferencia"].ToString());
                //MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                //MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoDiferenciaDiario(int IdEmpresa, int IdTienda, int IdCaja, int IdTiempo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaTiendaDiferencia");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pIdTiempo", DbType.Int32, IdTiempo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.Diferencia = Decimal.Parse(reader["Diferencia"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());
                MovimientoCaja.TotalVisa = Decimal.Parse(reader["TotalVisa"].ToString());
                MovimientoCaja.TotalMastercard = Decimal.Parse(reader["TotalMastercard"].ToString());
                MovimientoCaja.TotalCheques = Decimal.Parse(reader["TotalCheques"].ToString());
                MovimientoCaja.TotalCajaFinal = Decimal.Parse(reader["TotalCajaFinal"].ToString());
                MovimientoCaja.TotalNotaCredito = Decimal.Parse(reader["TotalNotaCredito"].ToString());
                MovimientoCaja.TotalCajaFinal = Decimal.Parse(reader["TotalCajaFinal"].ToString());
                MovimientoCaja.TotalCajaFinalSoles = Decimal.Parse(reader["TotalCajaFinalSoles"].ToString());
                MovimientoCaja.TotalCajaFinalDolaresaSoles = Decimal.Parse(reader["TotalCajaFinalDolaresaSoles"].ToString());
                MovimientoCaja.TotalEgresosSoles = Decimal.Parse(reader["TotalEgresosSoles"].ToString());
                MovimientoCaja.TotalEgresosDolares = Decimal.Parse(reader["TotalEgresosDolares"].ToString());
                MovimientoCaja.TotalGeneral = Decimal.Parse(reader["TotalGeneral"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<ReporteMovimientoCajaBE> ListadoDiferenciaMensual(int IdEmpresa, int IdTienda, int IdCaja, int IdTiempo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoCajaTiendaDiferencia");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pIdTiempo", DbType.Int32, IdTiempo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoCajaBE> MovimientoCajalist = new List<ReporteMovimientoCajaBE>();
            ReporteMovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new ReporteMovimientoCajaBE();
                MovimientoCaja.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MovimientoCaja.Mes = Int32.Parse(reader["Mes"].ToString());
                MovimientoCaja.NombreMes = reader["NombreMes"].ToString();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.DescTienda = reader["DescTienda"].ToString();
                MovimientoCaja.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoCaja.Diferencia = Decimal.Parse(reader["Diferencia"].ToString());
                MovimientoCaja.TotalAnulados = Decimal.Parse(reader["TotalAnulados"].ToString());

                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

    }

}
