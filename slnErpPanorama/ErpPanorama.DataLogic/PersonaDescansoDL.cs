using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PersonaDescansoDL
	{
		public PersonaDescansoDL() { }

		public Int32 Inserta(PersonaDescansoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaDescanso_Inserta");

			db.AddOutParameter(dbCommand, "pIdPersonaDescanso", DbType.Int32, pItem.IdPersonaDescanso);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPersonaDescanso");

			return Id;
		}

		public void Actualiza(PersonaDescansoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaDescanso_Actualiza");

			db.AddInParameter(dbCommand, "pIdPersonaDescanso", DbType.Int32, pItem.IdPersonaDescanso);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PersonaDescansoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaDescanso_Elimina");

			db.AddInParameter(dbCommand, "pIdPersonaDescanso", DbType.Int32, pItem.IdPersonaDescanso);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void Elimina(int IdPersona, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaDescanso_EliminaFecha");

            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PersonaDescansoBE> ListaTodosActivo(int IdPersona)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaDescanso_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PersonaDescansoBE> PersonaDescansolist = new List<PersonaDescansoBE>();
			PersonaDescansoBE PersonaDescanso;
			while (reader.Read())
			{
				PersonaDescanso = new PersonaDescansoBE();
				PersonaDescanso.IdPersonaDescanso = Int32.Parse(reader["IdPersonaDescanso"].ToString());
				PersonaDescanso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
				PersonaDescanso.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaDescanso.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//PersonaDescanso.IdPersonaDescanso = reader.IsDBNull(reader.GetOrdinal("IdPersonaDescanso")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaDescanso"));
				PersonaDescansolist.Add(PersonaDescanso);
			}
			reader.Close();
			reader.Dispose();
			return PersonaDescansolist;
		}

		public PersonaDescansoBE Selecciona(int IdPersonaDescanso)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaDescanso_Selecciona");
			db.AddInParameter(dbCommand, "pIdPersonaDescanso", DbType.Int32, IdPersonaDescanso);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PersonaDescansoBE PersonaDescanso = null;
			while (reader.Read())
			{
				PersonaDescanso = new PersonaDescansoBE();
				PersonaDescanso.IdPersonaDescanso = Int32.Parse(reader["IdPersonaDescanso"].ToString());
				PersonaDescanso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
				PersonaDescanso.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaDescanso.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//PersonaDescanso.IdPersonaDescanso = reader.IsDBNull(reader.GetOrdinal("IdPersonaDescanso")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersonaDescanso"));
			}
			reader.Close();
			reader.Dispose();
			return PersonaDescanso;
		}

	}
}
