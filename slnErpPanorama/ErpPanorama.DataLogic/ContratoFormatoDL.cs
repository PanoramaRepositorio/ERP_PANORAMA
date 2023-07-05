using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class ContratoFormatoDL
	{
		public ContratoFormatoDL() { }

		public Int32 Inserta(ContratoFormatoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ContratoFormato_Inserta");

			db.AddOutParameter(dbCommand, "pIdContratoFormato", DbType.Int32, pItem.IdContratoFormato);
			db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pTitulo", DbType.String, pItem.Titulo);
			db.AddInParameter(dbCommand, "pCuerpo", DbType.String, pItem.Cuerpo);
			db.AddInParameter(dbCommand, "pFirma", DbType.String, pItem.Firma);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdContratoFormato");

			return Id;
		}

		public void Actualiza(ContratoFormatoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ContratoFormato_Actualiza");

			db.AddInParameter(dbCommand, "pIdContratoFormato", DbType.Int32, pItem.IdContratoFormato);
			db.AddInParameter(dbCommand, "pIdTipoContrato", DbType.Int32, pItem.IdTipoContrato);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pTitulo", DbType.String, pItem.Titulo);
			db.AddInParameter(dbCommand, "pCuerpo", DbType.String, pItem.Cuerpo);
			db.AddInParameter(dbCommand, "pFirma", DbType.String, pItem.Firma);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(ContratoFormatoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ContratoFormato_Elimina");

			db.AddInParameter(dbCommand, "pIdContratoFormato", DbType.Int32, pItem.IdContratoFormato);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<ContratoFormatoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ContratoFormato_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<ContratoFormatoBE> ContratoFormatolist = new List<ContratoFormatoBE>();
			ContratoFormatoBE ContratoFormato;
			while (reader.Read())
			{
				ContratoFormato = new ContratoFormatoBE();
				ContratoFormato.IdContratoFormato = Int32.Parse(reader["IdContratoFormato"].ToString());
				ContratoFormato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                ContratoFormato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ContratoFormato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				ContratoFormato.Descripcion = reader["Descripcion"].ToString();
				ContratoFormato.Titulo = reader["Titulo"].ToString();
				ContratoFormato.Cuerpo = reader["Cuerpo"].ToString();
				ContratoFormato.Firma = reader["Firma"].ToString();
				ContratoFormato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//ContratoFormato.IdContratoFormato = reader.IsDBNull(reader.GetOrdinal("IdContratoFormato")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratoFormato"));
				ContratoFormatolist.Add(ContratoFormato);
			}
			reader.Close();
			reader.Dispose();
			return ContratoFormatolist;
		}

        public List<ContratoFormatoBE> ListaFormato(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ContratoFormato_ListaFormato");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ContratoFormatoBE> ContratoFormatolist = new List<ContratoFormatoBE>();
            ContratoFormatoBE ContratoFormato;
            while (reader.Read())
            {
                ContratoFormato = new ContratoFormatoBE();
                ContratoFormato.IdContratoFormato = Int32.Parse(reader["IdContratoFormato"].ToString());
                ContratoFormato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                ContratoFormato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ContratoFormato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ContratoFormato.Descripcion = reader["Descripcion"].ToString();
                ContratoFormato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //ContratoFormato.IdContratoFormato = reader.IsDBNull(reader.GetOrdinal("IdContratoFormato")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdContratoFormato"));
                ContratoFormato.FechaCreacion = reader.IsDBNull(reader.GetOrdinal("FechaCreacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCreacion"));
				ContratoFormato.FechaActualiza = reader.IsDBNull(reader.GetOrdinal("FechaActualiza")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaActualiza"));
				ContratoFormatolist.Add(ContratoFormato);
            }
            reader.Close();
            reader.Dispose();
            return ContratoFormatolist;
        }

        public ContratoFormatoBE Selecciona(int IdContratoFormato)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ContratoFormato_Selecciona");
			db.AddInParameter(dbCommand, "pIdContratoFormato", DbType.Int32, IdContratoFormato);

			IDataReader reader = db.ExecuteReader(dbCommand);
			ContratoFormatoBE ContratoFormato = null;
			while (reader.Read())
			{
				ContratoFormato = new ContratoFormatoBE();
				ContratoFormato.IdContratoFormato = Int32.Parse(reader["IdContratoFormato"].ToString());
				ContratoFormato.IdTipoContrato = Int32.Parse(reader["IdTipoContrato"].ToString());
                ContratoFormato.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ContratoFormato.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				ContratoFormato.Descripcion = reader["Descripcion"].ToString();
				ContratoFormato.Titulo = reader["Titulo"].ToString();
				ContratoFormato.Cuerpo = reader["Cuerpo"].ToString();
				ContratoFormato.Firma = reader["Firma"].ToString();
				ContratoFormato.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
			}
			reader.Close();
			reader.Dispose();
			return ContratoFormato;
		}

	}
}
