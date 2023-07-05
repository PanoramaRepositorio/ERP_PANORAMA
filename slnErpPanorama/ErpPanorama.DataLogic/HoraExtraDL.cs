using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class HoraExtraDL
    {
        public HoraExtraDL() { }

        public void Inserta(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_Inserta");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pIngreso", DbType.DateTime, pItem.Ingreso);
            db.AddInParameter(dbCommand, "pSalida", DbType.DateTime, pItem.Salida);
            db.AddInParameter(dbCommand, "pIdAutorizado", DbType.Int32, pItem.IdAutorizado);
            db.AddInParameter(dbCommand, "pSueldoHora", DbType.Decimal, pItem.SueldoHora);
            db.AddInParameter(dbCommand, "pSueldoHoraNocturna", DbType.Decimal, pItem.SueldoHoraNocturna);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pFlagCena", DbType.Boolean, pItem.FlagCena);
            db.AddInParameter(dbCommand, "pFlagDesayuno", DbType.Boolean, pItem.FlagDesayuno);
            db.AddInParameter(dbCommand, "pFlagCompensacion", DbType.Boolean, pItem.FlagCompensacion);
            db.AddInParameter(dbCommand, "pFechaCompensacion", DbType.DateTime, pItem.FechaCompensacion);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, pItem.Motivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_Actualiza");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pIngreso", DbType.DateTime, pItem.Ingreso);
            db.AddInParameter(dbCommand, "pSalida", DbType.DateTime, pItem.Salida);
            db.AddInParameter(dbCommand, "pIdAutorizado", DbType.Int32, pItem.IdAutorizado);
            db.AddInParameter(dbCommand, "pSueldoHora", DbType.Decimal, pItem.SueldoHora);
            db.AddInParameter(dbCommand, "pSueldoHoraNocturna", DbType.Decimal, pItem.SueldoHoraNocturna);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pFlagCena", DbType.Boolean, pItem.FlagCena);
            db.AddInParameter(dbCommand, "pFlagDesayuno", DbType.Boolean, pItem.FlagDesayuno);
            db.AddInParameter(dbCommand, "pFlagCompensacion", DbType.Boolean, pItem.FlagCompensacion);
            db.AddInParameter(dbCommand, "pFechaCompensacion", DbType.DateTime, pItem.FechaCompensacion);
            db.AddInParameter(dbCommand, "pMotivo", DbType.String, pItem.Motivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_Elimina");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCalculo(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ActualizaCalculo");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza_Totales(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_Actualiza_Totales");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pTotal25", DbType.Decimal, pItem.Total25);
            db.AddInParameter(dbCommand, "pTotal35", DbType.Decimal, pItem.Total35);
            db.AddInParameter(dbCommand, "pTotal100", DbType.Decimal, pItem.Total100);
            db.AddInParameter(dbCommand, "pSueldoHora", DbType.Decimal, pItem.SueldoHora);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pHoras25", DbType.Decimal, pItem.Horas25);
            db.AddInParameter(dbCommand, "pHoras35", DbType.Decimal, pItem.Horas35);
            db.AddInParameter(dbCommand, "pTotalHoras", DbType.Decimal, pItem.TotalHoras);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaAprobado(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ActualizaAprobado2");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pUsuarioAprobado", DbType.String, pItem.UsuarioAprobado);
            db.AddInParameter(dbCommand, "pPeriodoPlanilla", DbType.Int32, pItem.PeriodoPlanilla);
            db.AddInParameter(dbCommand, "pMesPlanilla", DbType.Int32, pItem.MesPlanilla);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaMovimientoCaja(int IdHoraExtra, int IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ActualizaMovimientoCaja");

            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, IdHoraExtra);
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEliminaMovimientoCaja(int IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ActualizaEliminaMovimientoCaja");

            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            db.ExecuteNonQuery(dbCommand);
        }

        public void InsertaMarcacion(HoraExtraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_InsertaMarcacion");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<HoraExtraBE> ListaTodosActivo(int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HoraExtraBE> HoraExtralist = new List<HoraExtraBE>();
            HoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                HoraExtra.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HoraExtra.Mes = Int32.Parse(reader["Mes"].ToString());
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                HoraExtra.Ingreso = reader.IsDBNull(reader.GetOrdinal("Ingreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Ingreso"));
                HoraExtra.Salida = reader.IsDBNull(reader.GetOrdinal("Salida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Salida"));
                HoraExtra.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                HoraExtra.Autorizado = reader["Autorizado"].ToString();
                HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtra.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                HoraExtra.DescCaja = reader["DescCaja"].ToString();
                HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                HoraExtra.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                HoraExtra.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                HoraExtra.DescSituacion = reader["DescSituacion"].ToString();
                HoraExtra.FechaCompensacion = reader.IsDBNull(reader.GetOrdinal("FechaCompensacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompensacion"));
                HoraExtra.Motivo = reader["Motivo"].ToString();
                HoraExtra.Observacion = reader["Observacion"].ToString();
                HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }

        public List<HoraExtraBE> ListaFecha(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ListaFecha");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HoraExtraBE> HoraExtralist = new List<HoraExtraBE>();
            HoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                HoraExtra.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HoraExtra.RazonSocial = reader["RazonSocial"].ToString();
                HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HoraExtra.Mes = Int32.Parse(reader["Mes"].ToString());
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                //HoraExtra.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                HoraExtra.IngresoNormal = reader.IsDBNull(reader.GetOrdinal("IngresoNormal")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("IngresoNormal"));
                HoraExtra.SalidaNormal = reader.IsDBNull(reader.GetOrdinal("SalidaNormal")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SalidaNormal"));
                HoraExtra.Ingreso = reader.IsDBNull(reader.GetOrdinal("Ingreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Ingreso"));
                HoraExtra.Salida = reader.IsDBNull(reader.GetOrdinal("Salida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Salida"));
                HoraExtra.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                HoraExtra.Autorizado = reader["Autorizado"].ToString();
                HoraExtra.Motivo = reader["Motivo"].ToString();
                HoraExtra.Observacion = reader["Observacion"].ToString();
                HoraExtra.TotalHoras = Decimal.Parse(reader["TotalHoras"].ToString());
                HoraExtra.TotalHorasFormato = reader["TotalHorasFormato"].ToString();
                HoraExtra.TotalHorasContadas = Decimal.Parse(reader["TotalHorasContadas"].ToString());
                HoraExtra.SueldoBruto = Decimal.Parse(reader["SueldoBruto"].ToString());
                HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                HoraExtra.MontoPagar = Decimal.Parse(reader["MontoPagar"].ToString());
                HoraExtra.Horas25 = Decimal.Parse(reader["Horas25"].ToString());
                HoraExtra.Horas35 = Decimal.Parse(reader["Horas35"].ToString());
                HoraExtra.Horas100 = Decimal.Parse(reader["Horas100"].ToString());
                HoraExtra.HorasComp = Decimal.Parse(reader["HorasComp"].ToString());
                HoraExtra.Total25 = Decimal.Parse(reader["Total25"].ToString());
                HoraExtra.Total35 = Decimal.Parse(reader["Total35"].ToString());
                HoraExtra.Total100 = Decimal.Parse(reader["Total100"].ToString());
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtra.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                HoraExtra.DescTienda = reader["DescTienda"].ToString();
                HoraExtra.DescCaja = reader["DescCaja"].ToString();
                HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                HoraExtra.NumeroEgreso = reader["NumeroEgreso"].ToString();
                HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                HoraExtra.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                HoraExtra.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                HoraExtra.DescSituacion = reader["DescSituacion"].ToString();
                HoraExtra.FechaCompensacion = reader.IsDBNull(reader.GetOrdinal("FechaCompensacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompensacion"));
                HoraExtra.UsuarioAprobado = reader["UsuarioAprobado"].ToString();
                HoraExtra.PeriodoPlanilla = reader.IsDBNull(reader.GetOrdinal("PeriodoPlanilla")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("PeriodoPlanilla"));
                HoraExtra.MesPlanilla = reader.IsDBNull(reader.GetOrdinal("MesPlanilla")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("MesPlanilla"));
                HoraExtra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }

        public List<HoraExtraBE> ListaPersonaFecha(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ListaPersonaFecha");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HoraExtraBE> HoraExtralist = new List<HoraExtraBE>();
            HoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                HoraExtra.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HoraExtra.Mes = Int32.Parse(reader["Mes"].ToString());
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                //HoraExtra.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                HoraExtra.IngresoNormal = reader.IsDBNull(reader.GetOrdinal("IngresoNormal")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("IngresoNormal"));
                HoraExtra.SalidaNormal = reader.IsDBNull(reader.GetOrdinal("SalidaNormal")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SalidaNormal"));
                HoraExtra.Ingreso = reader.IsDBNull(reader.GetOrdinal("Ingreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Ingreso"));
                HoraExtra.Salida = reader.IsDBNull(reader.GetOrdinal("Salida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Salida"));
                HoraExtra.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                HoraExtra.Autorizado = reader["Autorizado"].ToString();
                HoraExtra.Motivo = reader["Motivo"].ToString();
                HoraExtra.Observacion = reader["Observacion"].ToString();
                HoraExtra.TotalHoras = Decimal.Parse(reader["TotalHoras"].ToString());
                HoraExtra.TotalHorasFormato = reader["TotalHorasFormato"].ToString();
                HoraExtra.TotalHorasContadas = Decimal.Parse(reader["TotalHorasContadas"].ToString());
                HoraExtra.SueldoBruto = Decimal.Parse(reader["SueldoBruto"].ToString());
                HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                HoraExtra.MontoPagar = Decimal.Parse(reader["MontoPagar"].ToString());
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtra.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                HoraExtra.DescTienda = reader["DescTienda"].ToString();
                HoraExtra.DescCaja = reader["DescCaja"].ToString();
                HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                HoraExtra.NumeroEgreso = reader["NumeroEgreso"].ToString();
                HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                HoraExtra.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                HoraExtra.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                HoraExtra.DescSituacion = reader["DescSituacion"].ToString();
                HoraExtra.FechaCompensacion = reader.IsDBNull(reader.GetOrdinal("FechaCompensacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompensacion"));
                HoraExtra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }

        public List<HoraExtraBE> ListaValida(int IdHoraExtra, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ListaValida");
            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, IdHoraExtra);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HoraExtraBE> HoraExtralist = new List<HoraExtraBE>();
            HoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }

        public List<HoraExtraBE> ListaPersonaPendientePago(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_ListaPersonaPendientePago");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HoraExtraBE> HoraExtralist = new List<HoraExtraBE>();
            HoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                HoraExtra.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HoraExtra.Mes = Int32.Parse(reader["Mes"].ToString());
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                //HoraExtra.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                HoraExtra.IngresoNormal = reader.IsDBNull(reader.GetOrdinal("IngresoNormal")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("IngresoNormal"));
                HoraExtra.SalidaNormal = reader.IsDBNull(reader.GetOrdinal("SalidaNormal")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("SalidaNormal"));
                HoraExtra.Ingreso = reader.IsDBNull(reader.GetOrdinal("Ingreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Ingreso"));
                HoraExtra.Salida = reader.IsDBNull(reader.GetOrdinal("Salida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Salida"));
                HoraExtra.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                HoraExtra.Autorizado = reader["Autorizado"].ToString();
                HoraExtra.Motivo = reader["Motivo"].ToString();
                HoraExtra.Observacion = reader["Observacion"].ToString();
                HoraExtra.TotalHoras = Decimal.Parse(reader["TotalHoras"].ToString());
                HoraExtra.TotalHorasFormato = reader["TotalHorasFormato"].ToString();
                HoraExtra.TotalHorasContadas = Decimal.Parse(reader["TotalHorasContadas"].ToString());
                HoraExtra.SueldoBruto = Decimal.Parse(reader["SueldoBruto"].ToString());
                HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                HoraExtra.MontoPagar = Decimal.Parse(reader["MontoPagar"].ToString());
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtra.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                HoraExtra.DescTienda = reader["DescTienda"].ToString();
                HoraExtra.DescCaja = reader["DescCaja"].ToString();
                HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                HoraExtra.NumeroEgreso = reader["NumeroEgreso"].ToString();
                HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                HoraExtra.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                HoraExtra.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                HoraExtra.DescSituacion = reader["DescSituacion"].ToString();
                HoraExtra.FechaCompensacion = reader.IsDBNull(reader.GetOrdinal("FechaCompensacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompensacion"));
                HoraExtra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }

        public HoraExtraBE Selecciona(int IdHoraExtra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_Selecciona");
            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, IdHoraExtra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            HoraExtraBE HoraExtra = null;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                HoraExtra.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Periodo = Int32.Parse(reader["Periodo"].ToString());
                HoraExtra.Mes = Int32.Parse(reader["Mes"].ToString());
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                //HoraExtra.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                HoraExtra.Ingreso = reader.IsDBNull(reader.GetOrdinal("Ingreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Ingreso"));
                HoraExtra.Salida = reader.IsDBNull(reader.GetOrdinal("Salida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Salida"));
                HoraExtra.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                HoraExtra.Autorizado = reader["Autorizado"].ToString();
                HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtra.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                HoraExtra.DescCaja = reader["DescCaja"].ToString();
                HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                HoraExtra.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                HoraExtra.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                HoraExtra.DescSituacion = reader["DescSituacion"].ToString();
                HoraExtra.FechaCompensacion = reader.IsDBNull(reader.GetOrdinal("FechaCompensacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompensacion"));
                HoraExtra.Motivo = reader["Motivo"].ToString();
                HoraExtra.Observacion = reader["Observacion"].ToString();
                HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return HoraExtra;
        }

        public HoraExtraBE ValidaExisteRegistro(int IdPersona, DateTime pFecInicio, DateTime pFecFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraExtra_SeleccionaExiste");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFecInicio", DbType.DateTime, pFecInicio);
            db.AddInParameter(dbCommand, "pFecFin", DbType.DateTime, pFecFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            HoraExtraBE HoraExtra = null;
            while (reader.Read())
            {
                HoraExtra = new HoraExtraBE();
                HoraExtra.IdHoraExtra = Int32.Parse(reader["IdHoraExtra"].ToString());
                //HoraExtra.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                //HoraExtra.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                //HoraExtra.ApeNom = reader["ApeNom"].ToString();
                //HoraExtra.Periodo = Int32.Parse(reader["Periodo"].ToString());
                //HoraExtra.Mes = Int32.Parse(reader["Mes"].ToString());
                //HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                ////HoraExtra.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                //HoraExtra.FechaHasta = reader.IsDBNull(reader.GetOrdinal("FechaHasta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaHasta"));
                //HoraExtra.Ingreso = reader.IsDBNull(reader.GetOrdinal("Ingreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Ingreso"));
                //HoraExtra.Salida = reader.IsDBNull(reader.GetOrdinal("Salida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Salida"));
                //HoraExtra.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                //HoraExtra.Autorizado = reader["Autorizado"].ToString();
                //HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                //HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                //HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                //HoraExtra.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                //HoraExtra.DescCaja = reader["DescCaja"].ToString();
                //HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                //HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                //HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                //HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                //HoraExtra.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                //HoraExtra.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                //HoraExtra.DescSituacion = reader["DescSituacion"].ToString();
                //HoraExtra.FechaCompensacion = reader.IsDBNull(reader.GetOrdinal("FechaCompensacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCompensacion"));
                //HoraExtra.Motivo = reader["Motivo"].ToString();
                //HoraExtra.Observacion = reader["Observacion"].ToString();
                //HoraExtra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return HoraExtra;
        }


    }
}
