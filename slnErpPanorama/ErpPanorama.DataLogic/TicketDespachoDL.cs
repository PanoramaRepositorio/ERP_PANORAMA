using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class TicketDespachoDL
	{
		public TicketDespachoDL() { }

		public Int32 Inserta(TicketDespachoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_Inserta");

			db.AddOutParameter(dbCommand, "pIdTicketDespacho", DbType.Int32, pItem.IdTicketDespacho);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pNumeroPedido", DbType.String, pItem.NumeroPedido);
			db.AddInParameter(dbCommand, "pIdModuloDespacho", DbType.Int32, pItem.IdModuloDespacho);
			db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
			db.AddInParameter(dbCommand, "pFlagDelivery", DbType.Boolean, pItem.FlagDelivery);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdTicketDespacho");

			return Id;
		}

		public void Actualiza(TicketDespachoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_Actualiza");

			db.AddInParameter(dbCommand, "pIdTicketDespacho", DbType.Int32, pItem.IdTicketDespacho);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pNumeroPedido", DbType.String, pItem.NumeroPedido);
			db.AddInParameter(dbCommand, "pIdModuloDespacho", DbType.Int32, pItem.IdModuloDespacho);
			db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
			db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
			db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
			db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
			db.AddInParameter(dbCommand, "pFlagDelivery", DbType.Boolean, pItem.FlagDelivery);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(TicketDespachoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_Elimina");

			db.AddInParameter(dbCommand, "pIdTicketDespacho", DbType.Int32, pItem.IdTicketDespacho);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<TicketDespachoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<TicketDespachoBE> TicketDespacholist = new List<TicketDespachoBE>();
			TicketDespachoBE TicketDespacho;
			while (reader.Read())
			{
				TicketDespacho = new TicketDespachoBE();
                TicketDespacho.IdTicketDespacho = Int32.Parse(reader["IdTicketDespacho"].ToString());
                TicketDespacho.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TicketDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                TicketDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TicketDespacho.Numero = reader["Numero"].ToString();
                TicketDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                TicketDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                TicketDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                TicketDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                TicketDespacho.DescDespachador = reader["DescDespachador"].ToString();
                TicketDespacho.FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                TicketDespacho.FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFin"));
                TicketDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TicketDespacho.DescSituacion = reader["DescSituacion"].ToString();
                TicketDespacho.FlagDelivery = Boolean.Parse(reader["FlagDelivery"].ToString());
                TicketDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TicketDespacho.IdTicketDespacho = reader.IsDBNull(reader.GetOrdinal("IdTicketDespacho")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTicketDespacho"));
                TicketDespacholist.Add(TicketDespacho);
			}
			reader.Close();
			reader.Dispose();
			return TicketDespacholist;
		}

        public List<TicketDespachoBE> ListaFecha(int IdEmpresa, DateTime FechaInicio, DateTime FechaFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, FechaFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TicketDespachoBE> TicketDespacholist = new List<TicketDespachoBE>();
            TicketDespachoBE TicketDespacho;
            while (reader.Read())
            {
                TicketDespacho = new TicketDespachoBE();
                TicketDespacho.IdTicketDespacho = Int32.Parse(reader["IdTicketDespacho"].ToString());
                TicketDespacho.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TicketDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                TicketDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TicketDespacho.Numero = reader["Numero"].ToString();
                TicketDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                TicketDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                TicketDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                TicketDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                TicketDespacho.DescDespachador = reader["DescDespachador"].ToString();
                TicketDespacho.FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                TicketDespacho.FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFin"));
                TicketDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TicketDespacho.DescSituacion = reader["DescSituacion"].ToString();
                TicketDespacho.FlagDelivery = Boolean.Parse(reader["FlagDelivery"].ToString());
                TicketDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TicketDespacho.IdTicketDespacho = reader.IsDBNull(reader.GetOrdinal("IdTicketDespacho")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTicketDespacho"));
                TicketDespacholist.Add(TicketDespacho);
            }
            reader.Close();
            reader.Dispose();
            return TicketDespacholist;
        }

        public List<TicketDespachoBE> ListaFecha(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_ListaDiario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TicketDespachoBE> TicketDespacholist = new List<TicketDespachoBE>();
            TicketDespachoBE TicketDespacho;
            while (reader.Read())
            {
                TicketDespacho = new TicketDespachoBE();
                TicketDespacho.IdTicketDespacho = Int32.Parse(reader["IdTicketDespacho"].ToString());
                TicketDespacho.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TicketDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                TicketDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TicketDespacho.Numero = reader["Numero"].ToString();
                TicketDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                TicketDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                TicketDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                TicketDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                TicketDespacho.DescDespachador = reader["DescDespachador"].ToString();
                TicketDespacho.FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                TicketDespacho.FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFin"));
                TicketDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TicketDespacho.DescSituacion = reader["DescSituacion"].ToString();
                TicketDespacho.FlagDelivery = Boolean.Parse(reader["FlagDelivery"].ToString());
                TicketDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TicketDespacho.IdTicketDespacho = reader.IsDBNull(reader.GetOrdinal("IdTicketDespacho")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTicketDespacho"));
                TicketDespacholist.Add(TicketDespacho);
            }
            reader.Close();
            reader.Dispose();
            return TicketDespacholist;
        }


        public TicketDespachoBE Selecciona(int IdTicketDespacho)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_Selecciona");
			db.AddInParameter(dbCommand, "pIdTicketDespacho", DbType.Int32, IdTicketDespacho);

			IDataReader reader = db.ExecuteReader(dbCommand);
			TicketDespachoBE TicketDespacho = null;
			while (reader.Read())
			{
				TicketDespacho = new TicketDespachoBE();
                TicketDespacho.IdTicketDespacho = Int32.Parse(reader["IdTicketDespacho"].ToString());
                TicketDespacho.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TicketDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                TicketDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TicketDespacho.Numero = reader["Numero"].ToString();
                TicketDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                TicketDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                TicketDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                TicketDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                TicketDespacho.DescDespachador = reader["DescDespachador"].ToString();
                TicketDespacho.FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                TicketDespacho.FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFin"));
                TicketDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TicketDespacho.DescSituacion = reader["DescSituacion"].ToString();
                TicketDespacho.FlagDelivery = Boolean.Parse(reader["FlagDelivery"].ToString());
                TicketDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TicketDespacho.IdTicketDespacho = reader.IsDBNull(reader.GetOrdinal("IdTicketDespacho")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTicketDespacho"));
            }
			reader.Close();
			reader.Dispose();
			return TicketDespacho;
		}

        public TicketDespachoBE SeleccionaPedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TicketDespacho_SeleccionaPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TicketDespachoBE TicketDespacho = null;
            while (reader.Read())
            {
                TicketDespacho = new TicketDespachoBE();
                TicketDespacho.IdTicketDespacho = Int32.Parse(reader["IdTicketDespacho"].ToString());
                TicketDespacho.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TicketDespacho.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                TicketDespacho.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TicketDespacho.Numero = reader["Numero"].ToString();
                TicketDespacho.NumeroPedido = reader["NumeroPedido"].ToString();
                TicketDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                TicketDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                TicketDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                TicketDespacho.DescDespachador = reader["DescDespachador"].ToString();
                TicketDespacho.FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                TicketDespacho.FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFin"));
                TicketDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                TicketDespacho.DescSituacion = reader["DescSituacion"].ToString();
                TicketDespacho.FlagDelivery = Boolean.Parse(reader["FlagDelivery"].ToString());
                TicketDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //TicketDespacho.IdTicketDespacho = reader.IsDBNull(reader.GetOrdinal("IdTicketDespacho")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTicketDespacho"));
            }
            reader.Close();
            reader.Dispose();
            return TicketDespacho;
        }
    }
}
