using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TicketDL
    {
        public TicketDL() { }

        public void Inserta(TicketBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_Inserta");

            db.AddInParameter(dbCommand, "pIdTicket", DbType.Int32, pItem.IdTicket);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
            db.AddInParameter(dbCommand, "pRequerimiento", DbType.String, pItem.Requerimiento);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaCierre", DbType.DateTime, pItem.FechaCierre);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdEstado", DbType.Int32, pItem.IdEstado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TicketBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_Actualiza");

            db.AddInParameter(dbCommand, "pIdTicket", DbType.Int32, pItem.IdTicket);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
            db.AddInParameter(dbCommand, "pRequerimiento", DbType.String, pItem.Requerimiento);
            db.AddInParameter(dbCommand, "pIdResponsable", DbType.Int32, pItem.IdResponsable);
            db.AddInParameter(dbCommand, "pFechaCierre", DbType.DateTime, pItem.FechaCierre);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdEstado", DbType.Int32, pItem.IdEstado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TicketBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_Elimina");

            db.AddInParameter(dbCommand, "pIdTicket", DbType.Int32, pItem.IdTicket);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TicketBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TicketBE> Ticketlist = new List<TicketBE>();
            TicketBE Ticket;
            while (reader.Read())
            {
                Ticket = new TicketBE();
                Ticket.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Ticket.IdTicket = Int32.Parse(reader["IdTicket"].ToString());
                Ticket.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ticket.Numero = reader["Numero"].ToString();
                Ticket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Ticket.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Ticket.Solicitante = reader["Solicitante"].ToString();
                Ticket.DescArea = reader["DescArea"].ToString();
                Ticket.Requerimiento = reader["Requerimiento"].ToString();
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.Responsable = reader["Responsable"].ToString();
                Ticket.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Ticket.DescPrioridad = reader["DescPrioridad"].ToString();
                Ticket.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Ticket.DescEstado = reader["DescEstado"].ToString();
                Ticket.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Ticketlist.Add(Ticket);
            }
            reader.Close();
            reader.Dispose();
            return Ticketlist;
        }

        public List<TicketBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TicketBE> Ticketlist = new List<TicketBE>();
            TicketBE Ticket;
            while (reader.Read())
            {
                Ticket = new TicketBE();
                Ticket.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Ticket.IdTicket = Int32.Parse(reader["IdTicket"].ToString());
                Ticket.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ticket.Numero = reader["Numero"].ToString();
                Ticket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Ticket.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Ticket.Solicitante = reader["Solicitante"].ToString();
                Ticket.DescArea = reader["DescArea"].ToString();
                Ticket.Requerimiento = reader["Requerimiento"].ToString();
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.Responsable = reader["Responsable"].ToString();
                Ticket.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Ticket.DescPrioridad = reader["DescPrioridad"].ToString();
                Ticket.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Ticket.DescEstado = reader["DescEstado"].ToString();
                Ticket.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Ticketlist.Add(Ticket);
            }
            reader.Close();
            reader.Dispose();
            return Ticketlist;
        }

        public List<TicketBE> ListaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TicketBE> Ticketlist = new List<TicketBE>();
            TicketBE Ticket;
            while (reader.Read())
            {
                Ticket = new TicketBE();
                //Ticket.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Ticket.IdTicket = Int32.Parse(reader["IdTicket"].ToString());
                Ticket.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ticket.Numero = reader["Numero"].ToString();
                Ticket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Ticket.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Ticket.Solicitante = reader["Solicitante"].ToString();
                Ticket.DescArea = reader["DescArea"].ToString();
                Ticket.Requerimiento = reader["Requerimiento"].ToString();
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.Responsable = reader["Responsable"].ToString();
                Ticket.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Ticket.DescPrioridad = reader["DescPrioridad"].ToString();
                Ticket.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Ticket.DescEstado = reader["DescEstado"].ToString();
                Ticket.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Ticketlist.Add(Ticket);
            }
            reader.Close();
            reader.Dispose();
            return Ticketlist;
        }

        public TicketBE Selecciona(int IdTicket)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ticket_Selecciona");
            db.AddInParameter(dbCommand, "pIdTicket", DbType.Int32, IdTicket);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TicketBE Ticket = null;
            while (reader.Read())
            {
                Ticket = new TicketBE();
                //Ticket.RowNumber = Int32.Parse(reader["RowNumber"].ToString());
                Ticket.IdTicket = Int32.Parse(reader["IdTicket"].ToString());
                Ticket.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Ticket.Numero = reader["Numero"].ToString();
                Ticket.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Ticket.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                Ticket.Solicitante = reader["Solicitante"].ToString();
                Ticket.DescArea = reader["DescArea"].ToString();
                Ticket.Requerimiento = reader["Requerimiento"].ToString();
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.Responsable = reader["Responsable"].ToString();
                Ticket.FechaCierre = reader.IsDBNull(reader.GetOrdinal("FechaCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCierre"));
                Ticket.IdResponsable = Int32.Parse(reader["IdResponsable"].ToString());
                Ticket.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                Ticket.DescPrioridad = reader["DescPrioridad"].ToString();
                Ticket.IdEstado = Int32.Parse(reader["IdEstado"].ToString());
                Ticket.DescEstado = reader["DescEstado"].ToString();
                Ticket.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Ticket;
        }
    }
}
