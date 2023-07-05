using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SolicitudPrestamoDL
    {
        public SolicitudPrestamoDL() { }

        public Int32 Inserta(SolicitudPrestamoBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_Inserta");

            db.AddOutParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaSolicitud", DbType.DateTime, pItem.FechaSolicitud);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
            db.AddInParameter(dbCommand, "pTotalPago", DbType.Decimal, pItem.TotalPago);
            db.AddInParameter(dbCommand, "pNumeroCuotas", DbType.Int32, pItem.NumeroCuotas);
            db.AddInParameter(dbCommand, "pTipoCuota", DbType.Int32, pItem.TipoCuota);
            db.AddInParameter(dbCommand, "pCuota", DbType.Decimal, pItem.Cuota);
            db.AddInParameter(dbCommand, "pMetodo", DbType.Int32, pItem.Metodo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersonaAprueba", DbType.Int32, pItem.IdPersonaAprueba);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, pItem.Motivo);
            db.AddInParameter(dbCommand, "pSaldoAnterior", DbType.Decimal, pItem.SaldoAnterior);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdSolicitudPrestamo");

            return Id;
        }

        public void Actualiza(SolicitudPrestamoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaSolicitud", DbType.DateTime, pItem.FechaSolicitud);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
            db.AddInParameter(dbCommand, "pTotalPago", DbType.Decimal, pItem.TotalPago);
            db.AddInParameter(dbCommand, "pNumeroCuotas", DbType.Int32, pItem.NumeroCuotas);
            db.AddInParameter(dbCommand, "pTipoCuota", DbType.Int32, pItem.TipoCuota);
            db.AddInParameter(dbCommand, "pCuota", DbType.Decimal, pItem.Cuota);
            db.AddInParameter(dbCommand, "pMetodo", DbType.Int32, pItem.Metodo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersonaAprueba", DbType.Int32, pItem.IdPersonaAprueba);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, pItem.Motivo);
            db.AddInParameter(dbCommand, "pSaldoAnterior", DbType.Decimal, pItem.SaldoAnterior);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SolicitudPrestamoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaPersonaAprueba(int IdSolicitudPrestamo, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_ActualizaPersonaAprueba");

            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<SolicitudPrestamoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudPrestamoBE> SolicitudPrestamolist = new List<SolicitudPrestamoBE>();
            SolicitudPrestamoBE SolicitudPrestamo;
            while (reader.Read())
            {
                SolicitudPrestamo = new SolicitudPrestamoBE();
                SolicitudPrestamo.IdSolicitudPrestamo = Int32.Parse(reader["IdSolicitudPrestamo"].ToString());
                SolicitudPrestamo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudPrestamo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                SolicitudPrestamo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudPrestamo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudPrestamo.Numero = reader["Numero"].ToString();
                SolicitudPrestamo.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudPrestamo.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudPrestamo.DescPersona = reader["DescPersona"].ToString();
                SolicitudPrestamo.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudPrestamo.Interes = Decimal.Parse(reader["Interes"].ToString());
                SolicitudPrestamo.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                SolicitudPrestamo.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                SolicitudPrestamo.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                SolicitudPrestamo.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                SolicitudPrestamo.Metodo = Int32.Parse(reader["Metodo"].ToString());
                SolicitudPrestamo.Observacion = reader["Observacion"].ToString();
                //SolicitudPrestamo.IdPersonaAprueba = Int32.Parse(reader["IdPersonaAprueba"].ToString());
                SolicitudPrestamo.IdPersonaAprueba = reader.IsDBNull(reader.GetOrdinal("IdPersonaAprueba")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaAprueba"));
                SolicitudPrestamo.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                SolicitudPrestamo.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                SolicitudPrestamo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudPrestamo.DescSituacion = reader["DescSituacion"].ToString();
                SolicitudPrestamo.Motivo = reader["Motivo"].ToString();
                SolicitudPrestamo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                SolicitudPrestamolist.Add(SolicitudPrestamo);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamolist;
        }

        public List<SolicitudPrestamoBE> ListaPersona(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_ListaPersona");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudPrestamoBE> SolicitudPrestamolist = new List<SolicitudPrestamoBE>();
            SolicitudPrestamoBE SolicitudPrestamo;
            while (reader.Read())
            {
                SolicitudPrestamo = new SolicitudPrestamoBE();
                SolicitudPrestamo.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudPrestamo.DescPersona = reader["DescPersona"].ToString();
                SolicitudPrestamo.Cargo = Decimal.Parse(reader["PrestamoCargo"].ToString());
                SolicitudPrestamo.Abono = Decimal.Parse(reader["PagoAbono"].ToString());
                SolicitudPrestamo.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                SolicitudPrestamo.Estado = reader["Estado"].ToString();
                SolicitudPrestamolist.Add(SolicitudPrestamo);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamolist;
        }

        public SolicitudPrestamoBE Selecciona(int IdEmpresa, int IdSolicitudPrestamo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, IdSolicitudPrestamo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudPrestamoBE SolicitudPrestamo = null;
            while (reader.Read())
            {
                SolicitudPrestamo = new SolicitudPrestamoBE();
                SolicitudPrestamo.IdSolicitudPrestamo = Int32.Parse(reader["IdSolicitudPrestamo"].ToString());
                SolicitudPrestamo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudPrestamo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                SolicitudPrestamo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudPrestamo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudPrestamo.Numero = reader["Numero"].ToString();
                SolicitudPrestamo.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudPrestamo.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudPrestamo.DescPersona = reader["DescPersona"].ToString();
                SolicitudPrestamo.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudPrestamo.Interes = Decimal.Parse(reader["Interes"].ToString());
                SolicitudPrestamo.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                SolicitudPrestamo.SaldoAnterior = Decimal.Parse(reader["SaldoAnterior"].ToString());
                SolicitudPrestamo.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                SolicitudPrestamo.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                SolicitudPrestamo.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                SolicitudPrestamo.Metodo = Int32.Parse(reader["Metodo"].ToString());
                SolicitudPrestamo.Observacion = reader["Observacion"].ToString();
                //SolicitudPrestamo.IdPersonaAprueba = Int32.Parse(reader["IdPersonaAprueba"].ToString());
                SolicitudPrestamo.IdPersonaAprueba = reader.IsDBNull(reader.GetOrdinal("IdPersonaAprueba")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaAprueba"));
                SolicitudPrestamo.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                SolicitudPrestamo.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                SolicitudPrestamo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudPrestamo.DescSituacion = reader["DescSituacion"].ToString();
                SolicitudPrestamo.Motivo = reader["Motivo"].ToString();
                SolicitudPrestamo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamo;
        }

        public SolicitudPrestamoBE SeleccionaNumero(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudPrestamoBE SolicitudPrestamo = null;
            while (reader.Read())
            {
                SolicitudPrestamo = new SolicitudPrestamoBE();
                SolicitudPrestamo.IdSolicitudPrestamo = Int32.Parse(reader["IdSolicitudPrestamo"].ToString());
                SolicitudPrestamo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudPrestamo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                SolicitudPrestamo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudPrestamo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudPrestamo.Numero = reader["Numero"].ToString();
                SolicitudPrestamo.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudPrestamo.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudPrestamo.DescPersona = reader["DescPersona"].ToString();
                SolicitudPrestamo.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudPrestamo.Interes = Decimal.Parse(reader["Interes"].ToString());
                SolicitudPrestamo.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                SolicitudPrestamo.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                SolicitudPrestamo.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                SolicitudPrestamo.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                SolicitudPrestamo.Metodo = Int32.Parse(reader["Metodo"].ToString());
                SolicitudPrestamo.Observacion = reader["Observacion"].ToString();
                //SolicitudPrestamo.IdPersonaAprueba = Int32.Parse(reader["IdPersonaAprueba"].ToString());
                SolicitudPrestamo.IdPersonaAprueba = reader.IsDBNull(reader.GetOrdinal("IdPersonaAprueba")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaAprueba"));
                SolicitudPrestamo.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                SolicitudPrestamo.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                SolicitudPrestamo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudPrestamo.DescSituacion = reader["DescSituacion"].ToString();
                SolicitudPrestamo.Motivo = reader["Motivo"].ToString();
                SolicitudPrestamo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamo;
        }

        public List<SolicitudPrestamoBE> ListaFecha(int IdEmpresa, int IdTipoDocumento,DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamo_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudPrestamoBE> SolicitudPrestamolist = new List<SolicitudPrestamoBE>();
            SolicitudPrestamoBE SolicitudPrestamo = null;
            while (reader.Read())
            {
                SolicitudPrestamo = new SolicitudPrestamoBE();
                SolicitudPrestamo.IdSolicitudPrestamo = Int32.Parse(reader["IdSolicitudPrestamo"].ToString());
                SolicitudPrestamo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudPrestamo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                SolicitudPrestamo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudPrestamo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudPrestamo.Numero = reader["Numero"].ToString();
                SolicitudPrestamo.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudPrestamo.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudPrestamo.DescPersona = reader["DescPersona"].ToString();
                SolicitudPrestamo.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudPrestamo.Interes = Decimal.Parse(reader["Interes"].ToString());
                SolicitudPrestamo.TotalPago = Decimal.Parse(reader["TotalPago"].ToString());
                SolicitudPrestamo.NumeroCuotas = Int32.Parse(reader["NumeroCuotas"].ToString());
                SolicitudPrestamo.TipoCuota = Int32.Parse(reader["TipoCuota"].ToString());
                SolicitudPrestamo.DescTipoCuota = reader["DescTipoCuota"].ToString();
                SolicitudPrestamo.Cuota = Decimal.Parse(reader["Cuota"].ToString());
                SolicitudPrestamo.Metodo = Int32.Parse(reader["Metodo"].ToString());
                SolicitudPrestamo.Observacion = reader["Observacion"].ToString();
                //SolicitudPrestamo.IdPersonaAprueba = Int32.Parse(reader["IdPersonaAprueba"].ToString());
                SolicitudPrestamo.IdPersonaAprueba = reader.IsDBNull(reader.GetOrdinal("IdPersonaAprueba")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaAprueba"));
                SolicitudPrestamo.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                SolicitudPrestamo.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                SolicitudPrestamo.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SolicitudPrestamo.DescSituacion = reader["DescSituacion"].ToString();
                SolicitudPrestamo.Motivo = reader["Motivo"].ToString();
                SolicitudPrestamo.NumeroEgreso = reader["NumeroEgreso"].ToString();
                SolicitudPrestamo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                SolicitudPrestamo.TipoPrestamo = reader["TipoPrestamo"].ToString();
                SolicitudPrestamo.DescTienda = reader["DescTienda"].ToString();
                SolicitudPrestamolist.Add(SolicitudPrestamo);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamolist;
        }

    }
}
