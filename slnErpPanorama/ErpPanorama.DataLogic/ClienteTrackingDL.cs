using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteTrackingDL
    {
        public ClienteTrackingDL() { }

        public void Inserta(ClienteTrackingBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteTracking_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteTracking", DbType.Int32, pItem.IdClienteTracking);
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

        public void Actualiza(ClienteTrackingBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteTracking_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteTracking", DbType.Int32, pItem.IdClienteTracking);
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

        public void Elimina(ClienteTrackingBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteTracking_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClienteTracking", DbType.Int32, pItem.IdClienteTracking);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ClienteTrackingBE> ListaTodosActivo(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteTracking_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteTrackingBE> ClienteTrackinglist = new List<ClienteTrackingBE>();
            ClienteTrackingBE ClienteTracking;
            while (reader.Read())
            {
                ClienteTracking = new ClienteTrackingBE();
                ClienteTracking.IdClienteTracking = Int32.Parse(reader["idClienteTracking"].ToString());
                ClienteTracking.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteTracking.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ClienteTracking.Numero = reader["Numero"].ToString();
                ClienteTracking.Comentario = reader["Comentario"].ToString();
                ClienteTracking.FechaProxima = DateTime.Parse(reader["FechaProxima"].ToString());
                ClienteTracking.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ClienteTracking.DescSituacion = reader["DescSituacion"].ToString();
                ClienteTracking.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteTracking.TipoOper = 4; //Consultar
                ClienteTrackinglist.Add(ClienteTracking);
            }
            reader.Close();
            reader.Dispose();
            return ClienteTrackinglist;
        }

        public ClienteTrackingBE Selecciona(int IdClienteTracking)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteTracking_Selecciona");
            db.AddInParameter(dbCommand, "pIdClienteTracking", DbType.Int32, IdClienteTracking);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteTrackingBE ClienteTracking = null;
            while (reader.Read())
            {
                ClienteTracking = new ClienteTrackingBE();
                ClienteTracking.IdClienteTracking = Int32.Parse(reader["idClienteTracking"].ToString());
                ClienteTracking.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteTracking.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                ClienteTracking.Numero = reader["Numero"].ToString();
                ClienteTracking.Comentario = reader["Comentario"].ToString();
                ClienteTracking.FechaProxima = DateTime.Parse(reader["FechaProxima"].ToString());
                ClienteTracking.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ClienteTracking.DescSituacion = reader["DescSituacion"].ToString();
                ClienteTracking.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteTracking;
        }

    }
}
