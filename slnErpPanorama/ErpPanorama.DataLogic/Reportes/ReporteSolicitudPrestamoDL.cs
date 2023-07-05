using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteSolicitudPrestamoDL
    {
        public List<ReporteSolicitudPrestamoBE> Listado(int IdEmpresa, int IdSolicitudPrestamo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudPrestamo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, IdSolicitudPrestamo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudPrestamoBE> lista = new List<ReporteSolicitudPrestamoBE>();
            ReporteSolicitudPrestamoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteSolicitudPrestamoBE();
                reporte.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                reporte.Numero = reader["Numero"].ToString();
                reporte.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                reporte.DescPersona = reader["DescPersona"].ToString();
                reporte.Dni = reader["Dni"].ToString();
                reporte.DescArea = reader["DescArea"].ToString();
                reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                reporte.ImportePrestamo = Decimal.Parse(reader["ImportePrestamo"].ToString());
                reporte.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                reporte.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                reporte.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                reporte.DescTipoCuota = reader["DescTipoCuota"].ToString();
                reporte.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                reporte.Metodo = Int32.Parse(reader["Metodo"].ToString());
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.Motivo = reader["Motivo"].ToString();
                reporte.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                reporte.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                reporte.Concepto = reader["Concepto"].ToString();
                reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                reporte.Capital = Decimal.Parse(reader["Capital"].ToString());
                reporte.Interes = Decimal.Parse(reader["Interes"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                reporte.SaldoAnterior = Decimal.Parse(reader["SaldoAnterior"].ToString());
                reporte.DescSituacion = reader["DescSituacion"].ToString();
                reporte.TipoMovimiento = reader["TipoMovimiento"].ToString();
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

        public List<ReporteSolicitudPrestamoBE> ListadoFecha(int IdEmpresa, int IdTipoDocumento, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudPrestamoFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudPrestamoBE> lista = new List<ReporteSolicitudPrestamoBE>();
            ReporteSolicitudPrestamoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteSolicitudPrestamoBE();
                reporte.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                reporte.Numero = reader["Numero"].ToString();
                reporte.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                reporte.DescPersona = reader["DescPersona"].ToString();
                reporte.DescArea = reader["DescArea"].ToString();
                reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                reporte.ImportePrestamo = Decimal.Parse(reader["ImportePrestamo"].ToString());
                reporte.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                reporte.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                reporte.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                reporte.DescTipoCuota = reader["DescTipoCuota"].ToString();
                reporte.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                reporte.Metodo = Int32.Parse(reader["Metodo"].ToString());
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.Motivo = reader["Motivo"].ToString();
                reporte.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                reporte.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                reporte.Concepto = reader["Concepto"].ToString();
                reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                reporte.Capital = Decimal.Parse(reader["Capital"].ToString());
                reporte.Interes = Decimal.Parse(reader["Interes"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                reporte.SaldoAnterior = Decimal.Parse(reader["SaldoAnterior"].ToString());
                reporte.DescSituacion = reader["DescSituacion"].ToString();
                reporte.TipoMovimiento = reader["TipoMovimiento"].ToString();
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

        public List<ReporteSolicitudPrestamoBE> ListadoVencido(int IdEmpresa, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudPrestamo_ListaVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudPrestamoBE> lista = new List<ReporteSolicitudPrestamoBE>();
            ReporteSolicitudPrestamoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteSolicitudPrestamoBE();
                reporte.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                reporte.Numero = reader["Numero"].ToString();
                reporte.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                reporte.DescPersona = reader["DescPersona"].ToString();
                reporte.DescArea = reader["DescArea"].ToString();
                reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                reporte.ImportePrestamo = Decimal.Parse(reader["ImportePrestamo"].ToString());
                reporte.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                reporte.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                reporte.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                reporte.DescTipoCuota = reader["DescTipoCuota"].ToString();
                reporte.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                reporte.Metodo = Int32.Parse(reader["Metodo"].ToString());
                reporte.Observacion = reader["Observacion"].ToString();
                reporte.Motivo = reader["Motivo"].ToString();
                reporte.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                reporte.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                reporte.Concepto = reader["Concepto"].ToString();
                reporte.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                reporte.Capital = Decimal.Parse(reader["Capital"].ToString());
                reporte.Interes = Decimal.Parse(reader["Interes"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                reporte.DescSituacion = reader["DescSituacion"].ToString();
                reporte.TipoMovimiento = reader["TipoMovimiento"].ToString();
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

        public List<ReporteSolicitudPrestamoBE> ListadoVencidoResumen(int IdEmpresa, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSolicitudPrestamo_ListaVencidoResumen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSolicitudPrestamoBE> lista = new List<ReporteSolicitudPrestamoBE>();
            ReporteSolicitudPrestamoBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteSolicitudPrestamoBE();
                reporte.Dni = reader["Dni"].ToString();
                reporte.DescPersona = reader["DescPersona"].ToString();
                reporte.ImportePrestamo = Decimal.Parse(reader["ImportePrestamo"].ToString());
                reporte.Concepto = reader["Concepto"].ToString();
                reporte.Capital = Decimal.Parse(reader["Capital"].ToString());
                reporte.Interes = Decimal.Parse(reader["Interes"].ToString());
                reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

    }
}
