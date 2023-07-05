using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;


namespace ErpPanorama.DataLogic
{
    public class ClienteAgendaDL
    {
        public ClienteAgendaDL() { }

        public void Inserta(ClienteAgendaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAgenda_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteAgenda", DbType.Int32, pItem.IdClienteAgenda);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pComentario", DbType.String, pItem.Comentario);
            db.AddInParameter(dbCommand, "pFechaProxima", DbType.DateTime, pItem.FechaProxima);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ClienteAgendaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAgenda_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteAgenda", DbType.Int32, pItem.IdClienteAgenda);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pComentario", DbType.String, pItem.Comentario);
            db.AddInParameter(dbCommand, "pFechaProxima", DbType.DateTime, pItem.FechaProxima);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteAgendaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAgenda_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClienteAgenda", DbType.Int32, pItem.IdClienteAgenda);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ClienteAgendaBE> ListaTodosActivo(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAgenda_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteAgendaBE> ClienteAgendalist = new List<ClienteAgendaBE>();
            ClienteAgendaBE ClienteAgenda;
            while (reader.Read())
            {
                ClienteAgenda = new ClienteAgendaBE();
                ClienteAgenda.IdClienteAgenda = Int32.Parse(reader["idClienteAgenda"].ToString());
                ClienteAgenda.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAgenda.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ClienteAgenda.Numero = reader["Numero"].ToString();
                ClienteAgenda.Comentario = reader["Comentario"].ToString();
                ClienteAgenda.FechaProxima = DateTime.Parse(reader["FechaProxima"].ToString());
                ClienteAgenda.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ClienteAgenda.DescSituacion = reader["DescSituacion"].ToString();
                ClienteAgenda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteAgenda.TipoOper = 4; //Consultar
                ClienteAgendalist.Add(ClienteAgenda);
            }
            reader.Close();
            reader.Dispose();
            return ClienteAgendalist;
        }

        public ClienteAgendaBE Selecciona(int IdClienteAgenda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAgenda_Selecciona");
            db.AddInParameter(dbCommand, "pIdClienteAgenda", DbType.Int32, IdClienteAgenda);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteAgendaBE ClienteAgenda = null;
            while (reader.Read())
            {
                ClienteAgenda = new ClienteAgendaBE();
                ClienteAgenda.IdClienteAgenda = Int32.Parse(reader["idClienteAgenda"].ToString());
                ClienteAgenda.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAgenda.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ClienteAgenda.Numero = reader["Numero"].ToString();
                ClienteAgenda.Comentario = reader["Comentario"].ToString();
                ClienteAgenda.FechaProxima = DateTime.Parse(reader["FechaProxima"].ToString());
                ClienteAgenda.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ClienteAgenda.DescSituacion = reader["DescSituacion"].ToString();
                ClienteAgenda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteAgenda;
        }

        public List<ClienteAgendaBE> ListaVendedorSituacion(int IdVendedor, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAgenda_ListaVendedorSituacion");
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteAgendaBE> ClienteAgendalist = new List<ClienteAgendaBE>();
            ClienteAgendaBE ClienteAgenda;
            while (reader.Read())
            {
                ClienteAgenda = new ClienteAgendaBE();
                ClienteAgenda.IdClienteAgenda = Int32.Parse(reader["idClienteAgenda"].ToString());
                ClienteAgenda.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                ClienteAgenda.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAgenda.DescCliente = reader["DescCliente"].ToString();
                ClienteAgenda.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ClienteAgenda.Numero = reader["Numero"].ToString();
                ClienteAgenda.Comentario = reader["Comentario"].ToString();
                ClienteAgenda.FechaProxima = DateTime.Parse(reader["FechaProxima"].ToString());
                ClienteAgenda.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ClienteAgenda.DescSituacion = reader["DescSituacion"].ToString();
                ClienteAgenda.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteAgendalist.Add(ClienteAgenda);
            }
            reader.Close();
            reader.Dispose();
            return ClienteAgendalist;
        }
    }
}
