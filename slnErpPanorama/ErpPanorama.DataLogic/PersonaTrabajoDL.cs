using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PersonaTrabajoDL
	{
		public PersonaTrabajoDL() { }

		public Int32 Inserta(PersonaTrabajoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajo_Inserta");

			db.AddOutParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, pItem.IdPersonaTrabajo);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pHoraInicio", DbType.DateTime, pItem.HoraInicio);
			db.AddInParameter(dbCommand, "pHoraFin", DbType.DateTime, pItem.HoraFin);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPersonaTrabajo");

			return Id;
		}

		public void Actualiza(PersonaTrabajoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajo_Actualiza");

			db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, pItem.IdPersonaTrabajo);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pHoraInicio", DbType.DateTime, pItem.HoraInicio);
			db.AddInParameter(dbCommand, "pHoraFin", DbType.DateTime, pItem.HoraFin);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PersonaTrabajoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajo_Elimina");

			db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, pItem.IdPersonaTrabajo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PersonaTrabajoBE> ListaTodosActivo(int Periodo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PersonaTrabajoBE> PersonaTrabajolist = new List<PersonaTrabajoBE>();
			PersonaTrabajoBE PersonaTrabajo;
			while (reader.Read())
			{
				PersonaTrabajo = new PersonaTrabajoBE();
                PersonaTrabajo.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
				PersonaTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaTrabajo.HoraInicio = DateTime.Parse(reader["HoraInicio"].ToString());
				PersonaTrabajo.HoraFin = DateTime.Parse(reader["HoraFin"].ToString());
                PersonaTrabajo.DiaFeriado = reader["DiaFeriado"].ToString();
                PersonaTrabajo.DiaSemana = reader["DiaSemana"].ToString();
                PersonaTrabajo.Observacion = reader["Observacion"].ToString();
                PersonaTrabajo.Usuario = reader["Usuario"].ToString();
                PersonaTrabajo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PersonaTrabajolist.Add(PersonaTrabajo);
			}
			reader.Close();
			reader.Dispose();
			return PersonaTrabajolist;
		}

		public PersonaTrabajoBE Selecciona(int IdPersonaTrabajo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajo_Selecciona");
			db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, IdPersonaTrabajo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PersonaTrabajoBE PersonaTrabajo = null;
			while (reader.Read())
			{
				PersonaTrabajo = new PersonaTrabajoBE();
                PersonaTrabajo.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
                PersonaTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajo.HoraInicio = DateTime.Parse(reader["HoraInicio"].ToString());
                PersonaTrabajo.HoraFin = DateTime.Parse(reader["HoraFin"].ToString());
                PersonaTrabajo.Observacion = reader["Observacion"].ToString();
                PersonaTrabajo.Usuario = reader["Usuario"].ToString();
                PersonaTrabajo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return PersonaTrabajo;
		}

        public PersonaTrabajoBE SeleccionaFecha(DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajo_SeleccionaFecha");
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PersonaTrabajoBE PersonaTrabajo = null;
            while (reader.Read())
            {
                PersonaTrabajo = new PersonaTrabajoBE();
                PersonaTrabajo.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
                PersonaTrabajo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajo.HoraInicio = DateTime.Parse(reader["HoraInicio"].ToString());
                PersonaTrabajo.HoraFin = DateTime.Parse(reader["HoraFin"].ToString());
                PersonaTrabajo.Observacion = reader["Observacion"].ToString();
                PersonaTrabajo.Usuario = reader["Usuario"].ToString();
                PersonaTrabajo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PersonaTrabajo;
        }

    }
}
