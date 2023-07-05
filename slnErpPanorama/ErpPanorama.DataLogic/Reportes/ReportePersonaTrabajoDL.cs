using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePersonaTrabajoDL
    {
        public List<ReportePersonaTrabajoBE> Listado(int IdPersonaTrabajo, int IdUsuario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPersonaTrabajo");
            db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, IdPersonaTrabajo);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, IdUsuario);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePersonaTrabajoBE> PersonaTrabajolist = new List<ReportePersonaTrabajoBE>();
            ReportePersonaTrabajoBE PersonaTrabajo;
            while (reader.Read())
            {
                PersonaTrabajo = new ReportePersonaTrabajoBE();
                PersonaTrabajo.Item = reader["Item"].ToString();
                PersonaTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajo.HoraInicio = DateTime.Parse(reader["HoraInicio"].ToString());
                PersonaTrabajo.HoraFin = DateTime.Parse(reader["HoraFin"].ToString());
                PersonaTrabajo.Observacion = reader["Observacion"].ToString();
                PersonaTrabajo.DiaSemana = reader["DiaSemana"].ToString();
                PersonaTrabajo.DiaFeriado = reader["DiaFeriado"].ToString();
                PersonaTrabajo.ApeNom = reader["ApeNom"].ToString();
                PersonaTrabajo.DescTienda = reader["DescTienda"].ToString();
                PersonaTrabajo.DescArea = reader["DescArea"].ToString();
                PersonaTrabajo.Importe = Decimal.Parse(reader["Importe"].ToString());
                PersonaTrabajo.ObservacionDetalle = reader["ObservacionDetalle"].ToString();
                PersonaTrabajo.Apoyo = reader["Apoyo"].ToString();
                PersonaTrabajolist.Add(PersonaTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return PersonaTrabajolist;
        }

        public List<ReportePersonaTrabajoBE> ListadoFecha(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPersonaTrabajoFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePersonaTrabajoBE> PersonaTrabajolist = new List<ReportePersonaTrabajoBE>();
            ReportePersonaTrabajoBE PersonaTrabajo;
            while (reader.Read())
            {
                PersonaTrabajo = new ReportePersonaTrabajoBE();
                PersonaTrabajo.Item = reader["Item"].ToString();
                PersonaTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //PersonaTrabajo.HoraInicio = DateTime.Parse(reader["HoraInicio"].ToString());
                //PersonaTrabajo.HoraFin = DateTime.Parse(reader["HoraFin"].ToString());
                PersonaTrabajo.Observacion = reader["Observacion"].ToString();
                PersonaTrabajo.DiaSemana = reader["DiaSemana"].ToString();
                PersonaTrabajo.DiaFeriado = reader["DiaFeriado"].ToString();
                PersonaTrabajo.ApeNom = reader["ApeNom"].ToString();
                PersonaTrabajo.DescTienda = reader["DescTienda"].ToString();
                PersonaTrabajo.DescArea = reader["DescArea"].ToString();
                PersonaTrabajo.Importe = Decimal.Parse(reader["Importe"].ToString());
                PersonaTrabajo.ObservacionDetalle = reader["ObservacionDetalle"].ToString();
                PersonaTrabajo.Apoyo = reader["Apoyo"].ToString();
                PersonaTrabajolist.Add(PersonaTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return PersonaTrabajolist;
        }

        public List<ReportePersonaTrabajoBE> ListadoFechaPersona(int IdPersona, int pIdPersonaTrab, int pIdPersonaTrabDet)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPersonaTrabajoFechaSel");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, pIdPersonaTrab);
            db.AddInParameter(dbCommand, "pIdPersonaTrabajoDetalle", DbType.Int32, pIdPersonaTrabDet);

            //db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            //db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            //db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);
            //db.AddInParameter(dbCommand, "pHoraIni", DbType.DateTime, pHoraIni);
            //db.AddInParameter(dbCommand, "pHoraFin", DbType.DateTime, pHoraFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePersonaTrabajoBE> PersonaTrabajolist = new List<ReportePersonaTrabajoBE>();
            ReportePersonaTrabajoBE PersonaTrabajo;
            while (reader.Read())
            {
                //PersonaTrabajo.IdPersonaTrabajoDetalle = Int32.Parse(reader["IdPersonaTrabajoDetalle"].ToString());
                //PersonaTrabajoDetalle.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
                //PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //PersonaTrabajoDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                //PersonaTrabajoDetalle.ApeNom = reader["ApeNom"].ToString();
                //PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //PersonaTrabajoDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                //PersonaTrabajoDetalle.DescTienda = reader["DescTienda"].ToString();
                //PersonaTrabajoDetalle.IdArea = Int32.Parse(reader["IdArea"].ToString());
                //PersonaTrabajoDetalle.DescArea = reader["DescArea"].ToString();
                //PersonaTrabajoDetalle.DescCargo = reader["DescCargo"].ToString();
                //PersonaTrabajoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                //PersonaTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                //PersonaTrabajoDetalle.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                //PersonaTrabajoDetalle.Asistencia = reader["Asistencia"].ToString();
                //PersonaTrabajoDetalle.HoraIngreso = reader["HoraIngreso"].ToString();
                //PersonaTrabajoDetalle.HoraSalida = reader["HoraSalida"].ToString();
                //PersonaTrabajoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //PersonaTrabajoDetalle.TipoOper = 4;

                PersonaTrabajo = new ReportePersonaTrabajoBE();
                PersonaTrabajo.Item = reader["Item"].ToString();
                PersonaTrabajo.ApeNom = reader["ApeNom"].ToString();
                PersonaTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajo.DescTienda = reader["DescTienda"].ToString();
                PersonaTrabajo.DescArea = reader["DescArea"].ToString();
                PersonaTrabajo.DescArea = reader["DescCargo"].ToString();
                PersonaTrabajo.Importe = Decimal.Parse(reader["Importe"].ToString());
                PersonaTrabajo.Observacion = reader["Observacion"].ToString();
                PersonaTrabajo.Apoyo = reader["Apoyo"].ToString();
                PersonaTrabajo.Apoyo = reader["Asistencia"].ToString();
                PersonaTrabajo.HoraInicio = DateTime.Parse(reader["HoraIngreso"].ToString());
                PersonaTrabajo.HoraFin = DateTime.Parse(reader["HoraSalida"].ToString());

                PersonaTrabajo.DiaSemana = reader["DiaSemana"].ToString();
                //PersonaTrabajo.DiaFeriado = reader["DiaFeriado"].ToString();                
                PersonaTrabajo.ObservacionDetalle = reader["ObservacionDetalle"].ToString();

                PersonaTrabajolist.Add(PersonaTrabajo);
            }
            reader.Close();
            reader.Dispose();
            return PersonaTrabajolist;
        }


    }
}
