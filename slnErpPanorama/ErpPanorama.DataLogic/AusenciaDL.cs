using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AusenciaDL
    {
        public AusenciaDL() { }

        public void Inserta(AusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_Inserta");

            db.AddInParameter(dbCommand, "pIdAusencia", DbType.Int32, pItem.IdAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
            db.AddInParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, pItem.IdPersonaCalendarioLaboral);
            db.AddInParameter(dbCommand, "pIdAutorizado", DbType.Int32, pItem.IdAutorizado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_Actualiza");

            db.AddInParameter(dbCommand, "pIdAusencia", DbType.Int32, pItem.IdAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
            db.AddInParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, pItem.IdPersonaCalendarioLaboral);
            db.AddInParameter(dbCommand, "pIdAutorizado", DbType.Int32, pItem.IdAutorizado);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCalendario(int IdAusencia, int IdIdPersonaCalendarioLaboral, string Observacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_ActualizaCalendario");

            db.AddInParameter(dbCommand, "pIdAusencia", DbType.Int32, IdAusencia);
            db.AddInParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, IdIdPersonaCalendarioLaboral);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, Observacion);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_Elimina");

            db.AddInParameter(dbCommand, "pIdAusencia", DbType.Int32, pItem.IdAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaCalendario(AusenciaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_EliminaCalendario");

            db.AddInParameter(dbCommand, "pIdAusencia", DbType.Int32, pItem.IdAusencia);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AusenciaBE> ListaTodosActivo(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AusenciaBE> Ausencialist = new List<AusenciaBE>();
            AusenciaBE Ausencia;
            while (reader.Read())
            {
                Ausencia = new AusenciaBE();
                Ausencia.IdAusencia = Int32.Parse(reader["IdAusencia"].ToString());
                Ausencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ausencia.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Ausencia.Dni = reader["Dni"].ToString();
                Ausencia.ApeNom = reader["ApeNom"].ToString();
                Ausencia.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Ausencia.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                Ausencia.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                Ausencia.Dias = Int32.Parse(reader["Dias"].ToString());
                Ausencia.IdMotivoAusencia = Int32.Parse(reader["IdMotivoAusencia"].ToString());
                Ausencia.DescMotivoAusencia = reader["DescMotivoAusencia"].ToString();
                Ausencia.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                Ausencia.IdPersonaCalendarioLaboral = reader.IsDBNull(reader.GetOrdinal("IdPersonaCalendarioLaboral")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaCalendarioLaboral"));
                Ausencia.FechaRecupera = reader.IsDBNull(reader.GetOrdinal("FechaRecupera")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecupera"));
                Ausencia.AsistenciaRecupera = reader["AsistenciaRecupera"].ToString();
                Ausencia.Autorizado = reader["Autorizado"].ToString();
                Ausencia.Observacion = reader["Observacion"].ToString();
                Ausencia.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Ausencialist.Add(Ausencia);
            }
            reader.Close();
            reader.Dispose();
            return Ausencialist;
        }

        public AusenciaBE Selecciona(int IdAusencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_Selecciona");
            db.AddInParameter(dbCommand, "pIdAusencia", DbType.Int32, IdAusencia);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            AusenciaBE Ausencia = null;
            while (reader.Read())
            {
                Ausencia = new AusenciaBE();
                Ausencia.IdAusencia = Int32.Parse(reader["IdAusencia"].ToString());
                Ausencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ausencia.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Ausencia.ApeNom = reader["ApeNom"].ToString();
                Ausencia.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Ausencia.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                Ausencia.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                Ausencia.Dias = Int32.Parse(reader["Dias"].ToString());
                Ausencia.IdMotivoAusencia = Int32.Parse(reader["IdMotivoAusencia"].ToString());
                Ausencia.DescMotivoAusencia = reader["DescMotivoAusencia"].ToString();
                Ausencia.IdPersonaCalendarioLaboral = reader.IsDBNull(reader.GetOrdinal("IdPersonaCalendarioLaboral")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaCalendarioLaboral"));
                Ausencia.FechaRecupera = reader.IsDBNull(reader.GetOrdinal("FechaRecupera")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecupera"));
                Ausencia.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                Ausencia.Autorizado = reader["Autorizado"].ToString();
                Ausencia.Observacion = reader["Observacion"].ToString();
                Ausencia.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Ausencia;
        }

        public AusenciaBE SeleccionaFechaDni(DateTime Fecha, string Dni)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ausencia_SeleccionaFechaDni");
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pDni", DbType.Int32, Dni);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AusenciaBE Ausencia = null;
            while (reader.Read())
            {
                Ausencia = new AusenciaBE();
                Ausencia.IdAusencia = Int32.Parse(reader["IdAusencia"].ToString());
                Ausencia.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ausencia.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Ausencia.ApeNom = reader["ApeNom"].ToString();
                Ausencia.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Ausencia.FechaDesde = DateTime.Parse(reader["FechaDesde"].ToString());
                Ausencia.FechaHasta = DateTime.Parse(reader["FechaHasta"].ToString());
                Ausencia.Dias = Int32.Parse(reader["Dias"].ToString());
                Ausencia.IdMotivoAusencia = Int32.Parse(reader["IdMotivoAusencia"].ToString());
                Ausencia.DescMotivoAusencia = reader["DescMotivoAusencia"].ToString();
                Ausencia.IdPersonaCalendarioLaboral = reader.IsDBNull(reader.GetOrdinal("IdPersonaCalendarioLaboral")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaCalendarioLaboral"));
                Ausencia.FechaRecupera = reader.IsDBNull(reader.GetOrdinal("FechaRecupera")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecupera"));
                Ausencia.IdAutorizado = Int32.Parse(reader["IdAutorizado"].ToString());
                Ausencia.Autorizado = reader["Autorizado"].ToString();
                Ausencia.Observacion = reader["Observacion"].ToString();
                Ausencia.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Ausencia;
        }
    }
}
