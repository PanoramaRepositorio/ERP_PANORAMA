using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteEncuestaDL
    {
        public ClienteEncuestaDL() { }

        public Int32 Inserta(ClienteEncuestaBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteEncuesta_Inserta");

            db.AddOutParameter(dbCommand, "pIdClienteEncuesta", DbType.Int32, pItem.IdClienteEncuesta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pFacebook", DbType.Boolean, pItem.Facebook);
            db.AddInParameter(dbCommand, "pInstagram", DbType.Boolean, pItem.Instagram);
            db.AddInParameter(dbCommand, "pRadio", DbType.Boolean, pItem.Radio);
            db.AddInParameter(dbCommand, "pTelevision", DbType.Boolean, pItem.Television);
            db.AddInParameter(dbCommand, "pRevista", DbType.Boolean, pItem.Revista);
            db.AddInParameter(dbCommand, "pAmigo", DbType.Boolean, pItem.Amigo);
            db.AddInParameter(dbCommand, "pPanel", DbType.Boolean, pItem.Panel);
            db.AddInParameter(dbCommand, "pWeb", DbType.Boolean, pItem.Web);
            db.AddInParameter(dbCommand, "pCorreo", DbType.Boolean, pItem.Correo);
            db.AddInParameter(dbCommand, "pPeriodico", DbType.Boolean, pItem.Periodico);
            db.AddInParameter(dbCommand, "pSms", DbType.Boolean, pItem.Sms);
            db.AddInParameter(dbCommand, "pOtro", DbType.Boolean, pItem.Otro);
            db.AddInParameter(dbCommand, "pRespuestaOtro", DbType.String, pItem.RespuestaOtro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdClienteEncuesta");

            return Id;
        }

        public void Actualiza(ClienteEncuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteEncuesta_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteEncuesta", DbType.Int32, pItem.IdClienteEncuesta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pFacebook", DbType.Boolean, pItem.Facebook);
            db.AddInParameter(dbCommand, "pInstagram", DbType.Boolean, pItem.Instagram);
            db.AddInParameter(dbCommand, "pRadio", DbType.Boolean, pItem.Radio);
            db.AddInParameter(dbCommand, "pTelevision", DbType.Boolean, pItem.Television);
            db.AddInParameter(dbCommand, "pRevista", DbType.Boolean, pItem.Revista);
            db.AddInParameter(dbCommand, "pAmigo", DbType.Boolean, pItem.Amigo);
            db.AddInParameter(dbCommand, "pPanel", DbType.Boolean, pItem.Panel);
            db.AddInParameter(dbCommand, "pWeb", DbType.Boolean, pItem.Web);
            db.AddInParameter(dbCommand, "pCorreo", DbType.Boolean, pItem.Correo);
            db.AddInParameter(dbCommand, "pPeriodico", DbType.Boolean, pItem.Periodico);
            db.AddInParameter(dbCommand, "pSms", DbType.Boolean, pItem.Sms);
            db.AddInParameter(dbCommand, "pOtro", DbType.Boolean, pItem.Otro);
            db.AddInParameter(dbCommand, "pRespuestaOtro", DbType.String, pItem.RespuestaOtro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteEncuestaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteEncuesta_Elimina");

            db.AddInParameter(dbCommand, "pIdClienteEncuesta", DbType.Int32, pItem.IdClienteEncuesta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ClienteEncuestaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteEncuesta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteEncuestaBE> ClienteEncuestalist = new List<ClienteEncuestaBE>();
            ClienteEncuestaBE ClienteEncuesta;
            while (reader.Read())
            {
                ClienteEncuesta = new ClienteEncuestaBE();
                ClienteEncuesta.IdClienteEncuesta = Int32.Parse(reader["IdClienteEncuesta"].ToString());
                ClienteEncuesta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteEncuesta.Facebook = Boolean.Parse(reader["Facebook"].ToString());
                ClienteEncuesta.Instagram = Boolean.Parse(reader["Instagram"].ToString());
                ClienteEncuesta.Radio = Boolean.Parse(reader["Radio"].ToString());
                ClienteEncuesta.Television = Boolean.Parse(reader["Television"].ToString());
                ClienteEncuesta.Revista = Boolean.Parse(reader["Revista"].ToString());
                ClienteEncuesta.Amigo = Boolean.Parse(reader["Amigo"].ToString());
                ClienteEncuesta.Panel = Boolean.Parse(reader["Panel"].ToString());
                ClienteEncuesta.Web = Boolean.Parse(reader["Web"].ToString());
                ClienteEncuesta.Correo = Boolean.Parse(reader["Correo"].ToString());
                ClienteEncuesta.Periodico = Boolean.Parse(reader["Periodico"].ToString());
                ClienteEncuesta.Sms = Boolean.Parse(reader["Sms"].ToString());
                ClienteEncuesta.Otro = Boolean.Parse(reader["Otro"].ToString());
                ClienteEncuesta.RespuestaOtro = reader["RespuestaOtro"].ToString();
                ClienteEncuesta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                ClienteEncuestalist.Add(ClienteEncuesta);
            }
            reader.Close();
            reader.Dispose();
            return ClienteEncuestalist;
        }

        public List<ClienteEncuestaBE> ListaFecha(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteEncuesta_ListaFecha");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteEncuestaBE> ClienteEncuestalist = new List<ClienteEncuestaBE>();
            ClienteEncuestaBE ClienteEncuesta;
            while (reader.Read())
            {
                ClienteEncuesta = new ClienteEncuestaBE();
                ClienteEncuesta.IdClienteEncuesta = Int32.Parse(reader["IdClienteEncuesta"].ToString());
                ClienteEncuesta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteEncuesta.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                ClienteEncuesta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteEncuesta.DescCliente = reader["DescCliente"].ToString();
                ClienteEncuesta.Facebook = Boolean.Parse(reader["Facebook"].ToString());
                ClienteEncuesta.Instagram = Boolean.Parse(reader["Instagram"].ToString());
                ClienteEncuesta.Radio = Boolean.Parse(reader["Radio"].ToString());
                ClienteEncuesta.Television = Boolean.Parse(reader["Television"].ToString());
                ClienteEncuesta.Revista = Boolean.Parse(reader["Revista"].ToString());
                ClienteEncuesta.Amigo = Boolean.Parse(reader["Amigo"].ToString());
                ClienteEncuesta.Panel = Boolean.Parse(reader["Panel"].ToString());
                ClienteEncuesta.Web = Boolean.Parse(reader["Web"].ToString());
                ClienteEncuesta.Correo = Boolean.Parse(reader["Correo"].ToString());
                ClienteEncuesta.Periodico = Boolean.Parse(reader["Periodico"].ToString());
                ClienteEncuesta.Sms = Boolean.Parse(reader["Sms"].ToString());
                ClienteEncuesta.Otro = Boolean.Parse(reader["Otro"].ToString());
                ClienteEncuesta.RespuestaOtro = reader["RespuestaOtro"].ToString();
                ClienteEncuesta.NomDpto = reader["NomDpto"].ToString();
                ClienteEncuesta.NomProv = reader["NomProv"].ToString();
                ClienteEncuesta.NomDist = reader["NomDist"].ToString();
                ClienteEncuesta.DescVendedor = reader["DescVendedor"].ToString();
                ClienteEncuesta.DescTienda = reader["DescTienda"].ToString();
                ClienteEncuesta.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                ClienteEncuesta.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                ClienteEncuesta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ClienteEncuesta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                ClienteEncuestalist.Add(ClienteEncuesta);
            }
            reader.Close();
            reader.Dispose();
            return ClienteEncuestalist;
        }

        public ClienteEncuestaBE Selecciona(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteEncuesta_Selecciona");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteEncuestaBE ClienteEncuesta = null;
            while (reader.Read())
            {
                ClienteEncuesta = new ClienteEncuestaBE();
                ClienteEncuesta.IdClienteEncuesta = Int32.Parse(reader["IdClienteEncuesta"].ToString());
                ClienteEncuesta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteEncuesta.Facebook = Boolean.Parse(reader["Facebook"].ToString());
                ClienteEncuesta.Instagram = Boolean.Parse(reader["Instagram"].ToString());
                ClienteEncuesta.Radio = Boolean.Parse(reader["Radio"].ToString());
                ClienteEncuesta.Television = Boolean.Parse(reader["Television"].ToString());
                ClienteEncuesta.Revista = Boolean.Parse(reader["Revista"].ToString());
                ClienteEncuesta.Amigo = Boolean.Parse(reader["Amigo"].ToString());
                ClienteEncuesta.Panel = Boolean.Parse(reader["Panel"].ToString());
                ClienteEncuesta.Web = Boolean.Parse(reader["Web"].ToString());
                ClienteEncuesta.Correo = Boolean.Parse(reader["Correo"].ToString());
                ClienteEncuesta.Periodico = Boolean.Parse(reader["Periodico"].ToString());
                ClienteEncuesta.Sms = Boolean.Parse(reader["Sms"].ToString());
                ClienteEncuesta.Otro = Boolean.Parse(reader["Otro"].ToString());
                ClienteEncuesta.RespuestaOtro = reader["RespuestaOtro"].ToString();
                ClienteEncuesta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteEncuesta;
        }

    }
}
