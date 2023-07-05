using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class SunatConsultaTicketDL
	{
		public SunatConsultaTicketDL() { }

		public Int32 Inserta(SunatConsultaTicketBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_Inserta");

			db.AddOutParameter(dbCommand, "pIdSunatConsultaTicket", DbType.Int32, pItem.IdSunatConsultaTicket);
			db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdGrupoBaja", DbType.Int32, pItem.IdGrupoBaja);
			db.AddInParameter(dbCommand, "pGrupoBaja", DbType.String, pItem.GrupoBaja);
			db.AddInParameter(dbCommand, "pNumeroTicket", DbType.String, pItem.NumeroTicket);
			db.AddInParameter(dbCommand, "pMensajeTicket", DbType.String, pItem.MensajeTicket);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdSunatConsultaTicket");

			return Id;
		}

		public void Actualiza(SunatConsultaTicketBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_Actualiza");

			db.AddInParameter(dbCommand, "pIdSunatConsultaTicket", DbType.Int32, pItem.IdSunatConsultaTicket);
			db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdGrupoBaja", DbType.Int32, pItem.IdGrupoBaja);
			db.AddInParameter(dbCommand, "pGrupoBaja", DbType.String, pItem.GrupoBaja);
			db.AddInParameter(dbCommand, "pNumeroTicket", DbType.String, pItem.NumeroTicket);
			db.AddInParameter(dbCommand, "pMensajeTicket", DbType.String, pItem.MensajeTicket);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void ActualizaMensaje(int IdSunatConsultaTicket, string MensajeTicket)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_ActualizaMensaje");

            db.AddInParameter(dbCommand, "pIdSunatConsultaTicket", DbType.Int32, IdSunatConsultaTicket);
            db.AddInParameter(dbCommand, "pMensajeTicket", DbType.String, MensajeTicket);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SunatConsultaTicketBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_Elimina");

			db.AddInParameter(dbCommand, "pIdSunatConsultaTicket", DbType.Int32, pItem.IdSunatConsultaTicket);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<SunatConsultaTicketBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<SunatConsultaTicketBE> SunatConsultaTicketlist = new List<SunatConsultaTicketBE>();
			SunatConsultaTicketBE SunatConsultaTicket;
			while (reader.Read())
			{
				SunatConsultaTicket = new SunatConsultaTicketBE();
                SunatConsultaTicket.IdSunatConsultaTicket = Int32.Parse(reader["IdSunatConsultaTicket"].ToString());
                SunatConsultaTicket.Ruc = reader["Ruc"].ToString();
                SunatConsultaTicket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SunatConsultaTicket.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SunatConsultaTicket.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                SunatConsultaTicket.GrupoBaja = reader["GrupoBaja"].ToString();
                SunatConsultaTicket.NumeroTicket = reader["NumeroTicket"].ToString();
                SunatConsultaTicket.MensajeTicket = reader["MensajeTicket"].ToString();
                SunatConsultaTicket.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SunatConsultaTicket.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                SunatConsultaTicketlist.Add(SunatConsultaTicket);
			}
			reader.Close();
			reader.Dispose();
			return SunatConsultaTicketlist;
		}

        public List<SunatConsultaTicketBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SunatConsultaTicketBE> SunatConsultaTicketlist = new List<SunatConsultaTicketBE>();
            SunatConsultaTicketBE SunatConsultaTicket;
            while (reader.Read())
            {
                SunatConsultaTicket = new SunatConsultaTicketBE();
                SunatConsultaTicket.IdSunatConsultaTicket = Int32.Parse(reader["IdSunatConsultaTicket"].ToString());
                SunatConsultaTicket.Ruc = reader["Ruc"].ToString();
                SunatConsultaTicket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SunatConsultaTicket.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SunatConsultaTicket.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                SunatConsultaTicket.GrupoBaja = reader["GrupoBaja"].ToString();
                SunatConsultaTicket.NumeroTicket = reader["NumeroTicket"].ToString();
                SunatConsultaTicket.MensajeTicket = reader["MensajeTicket"].ToString();
                SunatConsultaTicket.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SunatConsultaTicket.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                SunatConsultaTicketlist.Add(SunatConsultaTicket);
            }
            reader.Close();
            reader.Dispose();
            return SunatConsultaTicketlist;
        }

        public List<SunatConsultaTicketBE> ListaPendiente(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_ListaPendiente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SunatConsultaTicketBE> SunatConsultaTicketlist = new List<SunatConsultaTicketBE>();
            SunatConsultaTicketBE SunatConsultaTicket;
            while (reader.Read())
            {
                SunatConsultaTicket = new SunatConsultaTicketBE();
                SunatConsultaTicket.IdSunatConsultaTicket = Int32.Parse(reader["IdSunatConsultaTicket"].ToString());
                SunatConsultaTicket.Ruc = reader["Ruc"].ToString();
                SunatConsultaTicket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SunatConsultaTicket.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SunatConsultaTicket.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                SunatConsultaTicket.GrupoBaja = reader["GrupoBaja"].ToString();
                SunatConsultaTicket.NumeroTicket = reader["NumeroTicket"].ToString();
                SunatConsultaTicket.MensajeTicket = reader["MensajeTicket"].ToString();
                SunatConsultaTicket.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SunatConsultaTicket.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                SunatConsultaTicketlist.Add(SunatConsultaTicket);
            }
            reader.Close();
            reader.Dispose();
            return SunatConsultaTicketlist;
        }

        public SunatConsultaTicketBE Selecciona(int IdSunatConsultaTicket)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SunatConsultaTicket_Selecciona");
			db.AddInParameter(dbCommand, "pIdSunatConsultaTicket", DbType.Int32, IdSunatConsultaTicket);

            IDataReader reader = db.ExecuteReader(dbCommand);
			SunatConsultaTicketBE SunatConsultaTicket = null;
			while (reader.Read())
			{
				SunatConsultaTicket = new SunatConsultaTicketBE();
                SunatConsultaTicket.IdSunatConsultaTicket = Int32.Parse(reader["IdSunatConsultaTicket"].ToString());
                SunatConsultaTicket.Ruc = reader["Ruc"].ToString();
                SunatConsultaTicket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SunatConsultaTicket.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SunatConsultaTicket.IdGrupoBaja = Int32.Parse(reader["IdGrupoBaja"].ToString());
                SunatConsultaTicket.GrupoBaja = reader["GrupoBaja"].ToString();
                SunatConsultaTicket.NumeroTicket = reader["NumeroTicket"].ToString();
                SunatConsultaTicket.MensajeTicket = reader["MensajeTicket"].ToString();
                SunatConsultaTicket.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SunatConsultaTicket.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return SunatConsultaTicket;
		}

	}
}
