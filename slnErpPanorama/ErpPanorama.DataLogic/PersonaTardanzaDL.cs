using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PersonaTardanzaDL
	{
		public PersonaTardanzaDL() { }

		public Int32 Inserta(PersonaTardanzaBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTardanza_Inserta");

			db.AddOutParameter(dbCommand, "pIdPersonaTardanza", DbType.Int32, pItem.IdPersonaTardanza);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagDescuento", DbType.Boolean, pItem.FlagDescuento);
			db.AddInParameter(dbCommand, "pIdPersonaJustifica", DbType.Int32, pItem.IdPersonaJustifica);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdPersonaTardanza");

			return Id;
		}

		public void Actualiza(PersonaTardanzaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTardanza_Actualiza");

			db.AddInParameter(dbCommand, "pIdPersonaTardanza", DbType.Int32, pItem.IdPersonaTardanza);
			db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagDescuento", DbType.Boolean, pItem.FlagDescuento);
			db.AddInParameter(dbCommand, "pIdPersonaJustifica", DbType.Int32, pItem.IdPersonaJustifica);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(PersonaTardanzaBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTardanza_Elimina");

			db.AddInParameter(dbCommand, "pIdPersonaTardanza", DbType.Int32, pItem.IdPersonaTardanza);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<PersonaTardanzaBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTardanza_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<PersonaTardanzaBE> PersonaTardanzalist = new List<PersonaTardanzaBE>();
			PersonaTardanzaBE PersonaTardanza;
			while (reader.Read())
			{
				PersonaTardanza = new PersonaTardanzaBE();
				PersonaTardanza.IdPersonaTardanza = Int32.Parse(reader["IdPersonaTardanza"].ToString());
				PersonaTardanza.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
				PersonaTardanza.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaTardanza.Tipo = reader["Tipo"].ToString();
				PersonaTardanza.Importe = Decimal.Parse(reader["Importe"].ToString());
				PersonaTardanza.Observacion = reader["Observacion"].ToString();
				PersonaTardanza.FlagDescuento = Boolean.Parse(reader["FlagDescuento"].ToString());
				PersonaTardanza.IdPersonaJustifica = Int32.Parse(reader["IdPersonaJustifica"].ToString());
				PersonaTardanza.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				PersonaTardanzalist.Add(PersonaTardanza);
			}
			reader.Close();
			reader.Dispose();
			return PersonaTardanzalist;
		}

		public PersonaTardanzaBE Selecciona(int IdPersonaTardanza)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_PersonaTardanza_Selecciona");
			db.AddInParameter(dbCommand, "pIdPersonaTardanza", DbType.Int32, IdPersonaTardanza);

			IDataReader reader = db.ExecuteReader(dbCommand);
			PersonaTardanzaBE PersonaTardanza = null;
			while (reader.Read())
			{
				PersonaTardanza = new PersonaTardanzaBE();
				PersonaTardanza.IdPersonaTardanza = Int32.Parse(reader["IdPersonaTardanza"].ToString());
				PersonaTardanza.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
				PersonaTardanza.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				PersonaTardanza.Tipo = reader["Tipo"].ToString();
				PersonaTardanza.Importe = Decimal.Parse(reader["Importe"].ToString());
				PersonaTardanza.Observacion = reader["Observacion"].ToString();
				PersonaTardanza.FlagDescuento = Boolean.Parse(reader["FlagDescuento"].ToString());
				PersonaTardanza.IdPersonaJustifica = Int32.Parse(reader["IdPersonaJustifica"].ToString());
				PersonaTardanza.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return PersonaTardanza;
		}

	}
}
