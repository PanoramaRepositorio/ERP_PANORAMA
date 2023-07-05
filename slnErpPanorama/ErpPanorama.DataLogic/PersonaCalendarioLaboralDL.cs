using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PersonaCalendarioLaboralDL
	{
		public PersonaCalendarioLaboralDL() { }

		public Int32 Inserta(PersonaCalendarioLaboralBE pItem)
		{
            Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_Inserta");

            db.AddOutParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, pItem.IdPersonaCalendarioLaboral);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFechaOrigen", DbType.DateTime, pItem.FechaOrigen);
			db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
            Id = (int)db.GetParameterValue(dbCommand, "pIdPersonaCalendarioLaboral");
            return Id;
		}

		public void Actualiza(PersonaCalendarioLaboralBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_Actualiza");

			db.AddInParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, pItem.IdPersonaCalendarioLaboral);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pIdHorarioTipoIncidencia", DbType.Int32, pItem.IdHorarioTipoIncidencia);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFechaOrigen", DbType.DateTime, pItem.FechaOrigen);
			db.AddInParameter(dbCommand, "pIdMotivoAusencia", DbType.Int32, pItem.IdMotivoAusencia);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PersonaCalendarioLaboralBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_Elimina");

			db.AddInParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, pItem.IdPersonaCalendarioLaboral);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PersonaCalendarioLaboralBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PersonaCalendarioLaboralBE> PersonaCalendarioLaborallist = new List<PersonaCalendarioLaboralBE>();
			PersonaCalendarioLaboralBE PersonaCalendarioLaboral;
			while (reader.Read())
			{
				PersonaCalendarioLaboral = new PersonaCalendarioLaboralBE();
				PersonaCalendarioLaboral.IdPersonaCalendarioLaboral = Int32.Parse(reader["IdPersonaCalendarioLaboral"].ToString());
				PersonaCalendarioLaboral.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCalendarioLaboral.ApeNom = reader["ApeNom"].ToString();
                PersonaCalendarioLaboral.Periodo = Int32.Parse(reader["Periodo"].ToString());
				PersonaCalendarioLaboral.Mes = Int32.Parse(reader["Mes"].ToString());
				PersonaCalendarioLaboral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaCalendarioLaboral.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
				PersonaCalendarioLaboral.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PersonaCalendarioLaboral.IdHorarioTipoIncidencia = reader.IsDBNull(reader.GetOrdinal("IdHorarioTipoIncidencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioTipoIncidencia"));
				PersonaCalendarioLaboral.Observacion = reader["Observacion"].ToString();
                PersonaCalendarioLaboral.FechaOrigen = reader.IsDBNull(reader.GetOrdinal("FechaOrigen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaOrigen"));
                PersonaCalendarioLaboral.IdMotivoAusencia = reader.IsDBNull(reader.GetOrdinal("IdMotivoAusencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMotivoAusencia"));
				PersonaCalendarioLaboral.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PersonaCalendarioLaborallist.Add(PersonaCalendarioLaboral);
			}
			reader.Close();
			reader.Dispose();
			return PersonaCalendarioLaborallist;
		}

        public List<PersonaCalendarioLaboralBE> ListaRecuperacion(DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_ListaRecuperacion");
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaCalendarioLaboralBE> PersonaCalendarioLaborallist = new List<PersonaCalendarioLaboralBE>();
            PersonaCalendarioLaboralBE PersonaCalendarioLaboral;
            while (reader.Read())
            {
                PersonaCalendarioLaboral = new PersonaCalendarioLaboralBE();
                PersonaCalendarioLaboral.IdPersonaCalendarioLaboral = Int32.Parse(reader["IdPersonaCalendarioLaboral"].ToString());
                PersonaCalendarioLaboral.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCalendarioLaboral.ApeNom = reader["ApeNom"].ToString();
                PersonaCalendarioLaboral.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PersonaCalendarioLaboral.DescTienda = reader["DescTienda"].ToString();
                PersonaCalendarioLaboral.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PersonaCalendarioLaboral.Mes = Int32.Parse(reader["Mes"].ToString());
                PersonaCalendarioLaboral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaCalendarioLaboral.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PersonaCalendarioLaboral.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PersonaCalendarioLaboral.IdHorarioTipoIncidencia = reader.IsDBNull(reader.GetOrdinal("IdHorarioTipoIncidencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioTipoIncidencia"));
                PersonaCalendarioLaboral.Observacion = reader["Observacion"].ToString();
                PersonaCalendarioLaboral.FechaOrigen = reader.IsDBNull(reader.GetOrdinal("FechaOrigen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaOrigen"));
                PersonaCalendarioLaboral.IdMotivoAusencia = reader.IsDBNull(reader.GetOrdinal("IdMotivoAusencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMotivoAusencia"));
                PersonaCalendarioLaboral.DescCargo = reader["DescCargo"].ToString();
                PersonaCalendarioLaboral.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PersonaCalendarioLaborallist.Add(PersonaCalendarioLaboral);
            }
            reader.Close();
            reader.Dispose();
            return PersonaCalendarioLaborallist;
        }

        public PersonaCalendarioLaboralBE Selecciona(int IdPersonaCalendarioLaboral)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_Selecciona");
			db.AddInParameter(dbCommand, "pIdPersonaCalendarioLaboral", DbType.Int32, IdPersonaCalendarioLaboral);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PersonaCalendarioLaboralBE PersonaCalendarioLaboral = null;
			while (reader.Read())
			{
				PersonaCalendarioLaboral = new PersonaCalendarioLaboralBE();
				PersonaCalendarioLaboral.IdPersonaCalendarioLaboral = Int32.Parse(reader["IdPersonaCalendarioLaboral"].ToString());
                PersonaCalendarioLaboral.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCalendarioLaboral.ApeNom = reader["ApeNom"].ToString();
                PersonaCalendarioLaboral.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PersonaCalendarioLaboral.Mes = Int32.Parse(reader["Mes"].ToString());
                PersonaCalendarioLaboral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaCalendarioLaboral.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PersonaCalendarioLaboral.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PersonaCalendarioLaboral.IdHorarioTipoIncidencia = reader.IsDBNull(reader.GetOrdinal("IdHorarioTipoIncidencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioTipoIncidencia"));
                PersonaCalendarioLaboral.Observacion = reader["Observacion"].ToString();
                PersonaCalendarioLaboral.FechaOrigen = reader.IsDBNull(reader.GetOrdinal("FechaOrigen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaOrigen"));
                PersonaCalendarioLaboral.IdMotivoAusencia = reader.IsDBNull(reader.GetOrdinal("IdMotivoAusencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMotivoAusencia"));
                PersonaCalendarioLaboral.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PersonaCalendarioLaboral;
		}

        public PersonaCalendarioLaboralBE SeleccionaPersonaFecha(string Dni, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaCalendarioLaboral_SeleccionaPersonaFecha");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaCalendarioLaboralBE PersonaCalendarioLaboral = null;
            while (reader.Read())
            {
                PersonaCalendarioLaboral = new PersonaCalendarioLaboralBE();
                PersonaCalendarioLaboral.IdPersonaCalendarioLaboral = Int32.Parse(reader["IdPersonaCalendarioLaboral"].ToString());
                PersonaCalendarioLaboral.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaCalendarioLaboral.ApeNom = reader["ApeNom"].ToString();
                PersonaCalendarioLaboral.Periodo = Int32.Parse(reader["Periodo"].ToString());
                PersonaCalendarioLaboral.Mes = Int32.Parse(reader["Mes"].ToString());
                PersonaCalendarioLaboral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaCalendarioLaboral.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PersonaCalendarioLaboral.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PersonaCalendarioLaboral.IdHorarioTipoIncidencia = reader.IsDBNull(reader.GetOrdinal("IdHorarioTipoIncidencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHorarioTipoIncidencia"));
                PersonaCalendarioLaboral.Observacion = reader["Observacion"].ToString();
                PersonaCalendarioLaboral.FechaOrigen = reader.IsDBNull(reader.GetOrdinal("FechaOrigen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaOrigen"));
                PersonaCalendarioLaboral.IdMotivoAusencia = reader.IsDBNull(reader.GetOrdinal("IdMotivoAusencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMotivoAusencia"));
                PersonaCalendarioLaboral.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PersonaCalendarioLaboral;
        }
	}
}
