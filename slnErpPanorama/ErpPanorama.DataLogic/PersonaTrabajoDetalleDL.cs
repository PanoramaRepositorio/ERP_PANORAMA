using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PersonaTrabajoDetalleDL
	{
		public PersonaTrabajoDetalleDL() { }

		public void Inserta(PersonaTrabajoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajoDetalle_Inserta");

			db.AddInParameter(dbCommand, "pIdPersonaTrabajoDetalle", DbType.Int32, pItem.IdPersonaTrabajoDetalle);
			db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, pItem.IdPersonaTrabajo);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Actualiza(PersonaTrabajoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajoDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdPersonaTrabajoDetalle", DbType.Int32, pItem.IdPersonaTrabajoDetalle);
			db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, pItem.IdPersonaTrabajo);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
			db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PersonaTrabajoDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajoDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdPersonaTrabajoDetalle", DbType.Int32, pItem.IdPersonaTrabajoDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PersonaTrabajoDetalleBE> ListaTodosActivo(int IdPersonaTrabajo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajoDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdPersonaTrabajo", DbType.Int32, IdPersonaTrabajo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PersonaTrabajoDetalleBE> PersonaTrabajoDetallelist = new List<PersonaTrabajoDetalleBE>();
			PersonaTrabajoDetalleBE PersonaTrabajoDetalle;
			while (reader.Read())
			{
				PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
				PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = Int32.Parse(reader["IdPersonaTrabajoDetalle"].ToString());
				PersonaTrabajoDetalle.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
                PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajoDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaTrabajoDetalle.ApeNom = reader["ApeNom"].ToString();
                PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaTrabajoDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PersonaTrabajoDetalle.DescTienda = reader["DescTienda"].ToString();
                PersonaTrabajoDetalle.IdArea = Int32.Parse(reader["IdArea"].ToString());
                PersonaTrabajoDetalle.DescArea = reader["DescArea"].ToString();
                PersonaTrabajoDetalle.DescCargo = reader["DescCargo"].ToString();
                PersonaTrabajoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
				PersonaTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                PersonaTrabajoDetalle.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                PersonaTrabajoDetalle.Asistencia = reader["Asistencia"].ToString();
                PersonaTrabajoDetalle.HoraIngreso = reader["HoraIngreso"].ToString();
                PersonaTrabajoDetalle.HoraSalida = reader["HoraSalida"].ToString();
                PersonaTrabajoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PersonaTrabajoDetalle.TipoOper = 4;
                PersonaTrabajoDetallelist.Add(PersonaTrabajoDetalle);
			}
			reader.Close();
			reader.Dispose();
			return PersonaTrabajoDetallelist;
		}

        public List<PersonaTrabajoDetalleBE> ListaApoyo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajoDetalle_ListaApoyo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaTrabajoDetalleBE> PersonaTrabajoDetallelist = new List<PersonaTrabajoDetalleBE>();
            PersonaTrabajoDetalleBE PersonaTrabajoDetalle;
            while (reader.Read())
            {
                PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
                //PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = Int32.Parse(reader["IdPersonaTrabajoDetalle"].ToString());
                //PersonaTrabajoDetalle.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
                //PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajoDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaTrabajoDetalle.ApeNom = reader["ApeNom"].ToString();
                //PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajoDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PersonaTrabajoDetalle.DescTienda = reader["DescTienda"].ToString();
                PersonaTrabajoDetalle.IdArea = Int32.Parse(reader["IdArea"].ToString());
                PersonaTrabajoDetalle.DescArea = reader["DescArea"].ToString();
                PersonaTrabajoDetalle.DescCargo = reader["DescCargo"].ToString();
                PersonaTrabajoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                PersonaTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                PersonaTrabajoDetalle.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                PersonaTrabajoDetalle.Telefono = reader["Telefono"].ToString();
                PersonaTrabajoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PersonaTrabajoDetallelist.Add(PersonaTrabajoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PersonaTrabajoDetallelist;
        }

        public PersonaTrabajoDetalleBE Selecciona(int IdPersonaTrabajoDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTrabajoDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdPersonaTrabajoDetalle", DbType.Int32, IdPersonaTrabajoDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PersonaTrabajoDetalleBE PersonaTrabajoDetalle = null;
			while (reader.Read())
			{
				PersonaTrabajoDetalle = new PersonaTrabajoDetalleBE();
                PersonaTrabajoDetalle.IdPersonaTrabajoDetalle = Int32.Parse(reader["IdPersonaTrabajoDetalle"].ToString());
                PersonaTrabajoDetalle.IdPersonaTrabajo = Int32.Parse(reader["IdPersonaTrabajo"].ToString());
                PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajoDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                PersonaTrabajoDetalle.ApeNom = reader["ApeNom"].ToString();
                PersonaTrabajoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PersonaTrabajoDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PersonaTrabajoDetalle.DescTienda = reader["DescTienda"].ToString();
                PersonaTrabajoDetalle.IdArea = Int32.Parse(reader["IdArea"].ToString());
                PersonaTrabajoDetalle.DescArea = reader["DescArea"].ToString();
                PersonaTrabajoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                PersonaTrabajoDetalle.Observacion = reader["Observacion"].ToString();
                PersonaTrabajoDetalle.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                PersonaTrabajoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return PersonaTrabajoDetalle;
		}

	}
}
