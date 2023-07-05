using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteCorreoDL
    {
        public ClienteCorreoDL() { }

        public void Inserta(ClienteCorreoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCorreo_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteCorreo", DbType.Int32, pItem.IdClienteCorreo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ClienteCorreoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCorreo_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteCorreo", DbType.Int32, pItem.IdClienteCorreo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteCorreoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCorreo_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClienteCorreo", DbType.Int32, pItem.IdClienteCorreo);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ClienteCorreoBE> ListaTodosActivo(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCorreo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCorreoBE> ClienteCorreolist = new List<ClienteCorreoBE>();
            ClienteCorreoBE ClienteCorreo;
            while (reader.Read())
            {
                ClienteCorreo = new ClienteCorreoBE();
                ClienteCorreo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClienteCorreo.IdClienteCorreo = Int32.Parse(reader["IdClienteCorreo"].ToString());
                ClienteCorreo.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteCorreo.Email = reader["email"].ToString();
                ClienteCorreo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCorreo.TipoOper = 4; //Consultar
                ClienteCorreolist.Add(ClienteCorreo);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCorreolist;
        }

        public List<ClienteCorreoBE> ListadoMailing(int IdEmpresa, int IdClienteCorreo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCorreo_ListaMailing");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClienteCorreo", DbType.Int32, IdClienteCorreo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCorreoBE> ClienteCorreolist = new List<ClienteCorreoBE>();
            ClienteCorreoBE ClienteCorreo;
            while (reader.Read())
            {
                ClienteCorreo = new ClienteCorreoBE();
                ClienteCorreo.IdClienteCorreo = Int32.Parse(reader["IdClienteCorreo"].ToString());
                ClienteCorreo.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteCorreo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCorreo.DescCliente = reader["DescCliente"].ToString();
                ClienteCorreo.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ClienteCorreo.Email = reader["email"].ToString();
                ClienteCorreo.DescTipoCliente = reader["DescTipoCliente"].ToString();
                ClienteCorreo.DescVendedor = reader["DescVendedor"].ToString();
                ClienteCorreo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ClienteCorreo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCorreo.TipoOper = 4; //Consultar
                ClienteCorreolist.Add(ClienteCorreo);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCorreolist;
        }

        public List<ClienteCorreoBE> ListadoMailingFiltro(int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCorreo_ListaMailingFiltro");
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCorreoBE> ClienteCorreolist = new List<ClienteCorreoBE>();
            ClienteCorreoBE ClienteCorreo;
            while (reader.Read())
            {
                ClienteCorreo = new ClienteCorreoBE();
                ClienteCorreo.IdClienteCorreo = Int32.Parse(reader["IdClienteCorreo"].ToString());
                ClienteCorreo.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteCorreo.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCorreo.DescCliente = reader["DescCliente"].ToString();
                ClienteCorreo.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                ClienteCorreo.Email = reader["email"].ToString();
                ClienteCorreo.DescTipoCliente = reader["DescTipoCliente"].ToString();
                ClienteCorreo.DescVendedor = reader["DescVendedor"].ToString();
                ClienteCorreo.Distrito = reader["Distrito"].ToString();
                ClienteCorreo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ClienteCorreo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCorreo.TipoOper = 4; //Consultar
                ClienteCorreolist.Add(ClienteCorreo);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCorreolist;
        }
    }
}

