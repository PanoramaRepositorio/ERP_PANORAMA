using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteHoraExtraDL
    {
        public List<ReporteHoraExtraBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptHoraExtra");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteHoraExtraBE> HoraExtralist = new List<ReporteHoraExtraBE>();
            ReporteHoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new ReporteHoraExtraBE();
                HoraExtra.Dni = reader["Dni"].ToString();
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                HoraExtra.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                HoraExtra.TotalHoras = Decimal.Parse(reader["TotalHoras"].ToString());
                HoraExtra.TotalHorasFormato = reader["TotalHorasFormato"].ToString();
                HoraExtra.TotalHorasContadas = Decimal.Parse(reader["TotalHorasContadas"].ToString());
                HoraExtra.TotalExtraNormal = Decimal.Parse(reader["TotalExtraNormal"].ToString());
                HoraExtra.TotalExtraNocturno = Decimal.Parse(reader["TotalExtraNocturno"].ToString());
                HoraExtra.SueldoExtraNocturno = Decimal.Parse(reader["SueldoExtraNocturno"].ToString());
                HoraExtra.SueldoBruto = Decimal.Parse(reader["SueldoBruto"].ToString());
                HoraExtra.SueldoHora = Decimal.Parse(reader["SueldoHora"].ToString());
                HoraExtra.SueldoHoraNocturna = Decimal.Parse(reader["SueldoHoraNocturna"].ToString());
                HoraExtra.MontoPagar = Decimal.Parse(reader["MontoPagar"].ToString());
                HoraExtra.Autorizado = reader["Autorizado"].ToString();
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtra.DescTienda = reader["DescTienda"].ToString();
                HoraExtra.DescCaja = reader["DescCaja"].ToString();
                HoraExtra.FechaMovimientoCaja = DateTime.Parse(reader["FechaMovimientoCaja"].ToString());
                //HoraExtra.FechaMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("FechaMovimientoCaja")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaMovimientoCaja"));
                HoraExtra.NumeroEgreso = reader["NumeroEgreso"].ToString();
                HoraExtra.FlagCena = Boolean.Parse(reader["FlagCena"].ToString());
                HoraExtra.FlagDesayuno = Boolean.Parse(reader["FlagDesayuno"].ToString());
                HoraExtra.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                HoraExtra.FechaCompensacion = DateTime.Parse(reader["FechaMovimientoCaja"].ToString());
                //HoraExtra.FechaCompensacion = DateTime.Parse(reader["FechaCompensacion"].ToString());
                HoraExtra.Motivo = reader["Motivo"].ToString();
                HoraExtra.Observacion = reader["Observacion"].ToString();
                HoraExtra.DescCargo = reader["DescCargo"].ToString();
                HoraExtra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }

        public List<ReporteHoraExtraBE> ListadoResumen(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptHoraExtra");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteHoraExtraBE> HoraExtralist = new List<ReporteHoraExtraBE>();
            ReporteHoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new ReporteHoraExtraBE();
                HoraExtra.Dni = reader["Dni"].ToString();
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }
    }
}
