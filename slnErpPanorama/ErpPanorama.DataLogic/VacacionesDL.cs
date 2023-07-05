using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class VacacionesDL
    {
        public VacacionesDL() { }

        public void Inserta(VacacionesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vacaciones_Inserta");

            db.AddInParameter(dbCommand, "pIdVacaciones", DbType.Int32, pItem.IdVacaciones);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdAutorizado", DbType.Int32, pItem.IdAutorizado);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFlagGozo", DbType.Boolean, pItem.FlagGozo);
            db.AddInParameter(dbCommand, "pFlagAdelantadas", DbType.Boolean, pItem.FlagAdelantadas);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(VacacionesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vacaciones_Actualiza");

            db.AddInParameter(dbCommand, "pIdVacaciones", DbType.Int32, pItem.IdVacaciones);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdAutorizado", DbType.Int32, pItem.IdAutorizado);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFlagGozo", DbType.Boolean, pItem.FlagGozo);
            db.AddInParameter(dbCommand, "pFlagAdelantadas", DbType.Boolean, pItem.FlagAdelantadas);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(VacacionesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vacaciones_Elimina");

            db.AddInParameter(dbCommand, "pIdVacaciones", DbType.Int32, pItem.IdVacaciones);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<VacacionesBE> ListaTodosActivo(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vacaciones_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<VacacionesBE> Vacacioneslist = new List<VacacionesBE>();
            VacacionesBE Vacaciones;
            while (reader.Read())
            {
                Vacaciones = new VacacionesBE();
                Vacaciones.IdVacaciones = Int32.Parse(reader["IdVacaciones"].ToString());
                Vacaciones.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Vacaciones.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Vacaciones.ApeNom = reader["ApeNom"].ToString();
                Vacaciones.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Vacaciones.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                Vacaciones.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                Vacaciones.Dias = Int32.Parse(reader["Dias"].ToString());
                Vacaciones.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Vacaciones.DescMoneda = reader["DescMoneda"].ToString();
                Vacaciones.Importe = Decimal.Parse(reader["Importe"].ToString());
                Vacaciones.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                Vacaciones.Autorizado = reader["Autorizado"].ToString();
                Vacaciones.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Vacaciones.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Vacaciones.FlagGozo = Boolean.Parse(reader["FlagGozo"].ToString());
                Vacaciones.FlagAdelantadas = Boolean.Parse(reader["FlagAdelantadas"].ToString());
                Vacaciones.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Vacaciones.DescSituacion = reader["DescSituacion"].ToString();
                Vacaciones.Observacion = reader["Observacion"].ToString();
                Vacaciones.DescTienda = reader["DescTienda"].ToString();
                Vacaciones.DescArea = reader["DescArea"].ToString();
                Vacaciones.DescCargo = reader["DescCargo"].ToString();
                Vacaciones.Usuario = reader["Usuario"].ToString();
                Vacaciones.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Vacacioneslist.Add(Vacaciones);
            }
            reader.Close();
            reader.Dispose();
            return Vacacioneslist;
        }

        public VacacionesBE Selecciona(int IdVacaciones)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Vacaciones_Selecciona");
            db.AddInParameter(dbCommand, "pIdVacaciones", DbType.Int32, IdVacaciones);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            VacacionesBE Vacaciones = null;
            while (reader.Read())
            {
                Vacaciones = new VacacionesBE();
                Vacaciones.IdVacaciones = Int32.Parse(reader["IdVacaciones"].ToString());
                Vacaciones.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Vacaciones.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Vacaciones.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                Vacaciones.ApeNom = reader["ApeNom"].ToString();
                Vacaciones.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Vacaciones.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                Vacaciones.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                Vacaciones.Dias = Int32.Parse(reader["Dias"].ToString());
                Vacaciones.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                Vacaciones.DescMoneda = reader["DescMoneda"].ToString();
                Vacaciones.Importe = Decimal.Parse(reader["Importe"].ToString());
                Vacaciones.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                Vacaciones.Autorizado = reader["Autorizado"].ToString();
                Vacaciones.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Vacaciones.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Vacaciones.FlagGozo = Boolean.Parse(reader["FlagGozo"].ToString());
                Vacaciones.FlagAdelantadas = Boolean.Parse(reader["FlagAdelantadas"].ToString());
                Vacaciones.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Vacaciones.DescSituacion = reader["DescSituacion"].ToString();
                Vacaciones.Observacion = reader["Observacion"].ToString();
                Vacaciones.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Vacaciones.FlagAdelantadas = Boolean.Parse(reader["FlagAdelantadas"].ToString());
                Vacaciones.Usuario = reader["Usuario"].ToString();
                Vacaciones.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Vacaciones;
        }
    }
}
