using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteHorarioPersonaDL
    {
        public List<ReporteHorarioPersonaBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptHorarioPersona");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteHorarioPersonaBE> HorarioPersonalist = new List<ReporteHorarioPersonaBE>();
            ReporteHorarioPersonaBE HorarioPersona;
            while (reader.Read())
            {
                HorarioPersona = new ReporteHorarioPersonaBE();
                HorarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                HorarioPersona.ApeNom = reader["ApeNom"].ToString();
                HorarioPersona.DiaSemanaName = reader["DiaSemanaName"].ToString();
                HorarioPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HorarioPersona.FechaIngreso = reader["FechaIngreso"].ToString();
                HorarioPersona.FechaSalidaRef = reader["FechaSalidaRef"].ToString();
                HorarioPersona.FechaIngresoRef = reader["FechaIngresoRef"].ToString();
                HorarioPersona.FechaSalida = reader["FechaSalida"].ToString();
                HorarioPersona.TotalHorasRef = Decimal.Parse(reader["TotalHorasRef"].ToString());
                HorarioPersona.TotalHorasTrab = Decimal.Parse(reader["TotalHorasTrab"].ToString());
                HorarioPersona.Observacion = reader["Observacion"].ToString();
                HorarioPersona.DescTurno = reader["DescTurno"].ToString();
                HorarioPersonalist.Add(HorarioPersona);
            }
            reader.Close();
            reader.Dispose();
            return HorarioPersonalist;
        }
    }
}
