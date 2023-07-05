using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteCreditoDocumentoDL
    {
        public ClienteCreditoDocumentoDL() { }

        public void Inserta(ClienteCreditoDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCreditoDocumento_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteCreditoDocumento", DbType.Int32, pItem.IdClienteCreditoDocumento);
            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, pItem.IdClienteCredito);
            db.AddInParameter(dbCommand, "pDocumento", DbType.String, pItem.Documento);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ClienteCreditoDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCreditoDocumento_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteCreditoDocumento", DbType.Int32, pItem.IdClienteCreditoDocumento);
            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, pItem.IdClienteCredito);
            db.AddInParameter(dbCommand, "pDocumento", DbType.String, pItem.Documento);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteCreditoDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCreditoDocumento_Elimina");

            db.AddInParameter(dbCommand, "pIdClienteCredito", DbType.Int32, pItem.IdClienteCredito);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public ClienteCreditoDocumentoBE Selecciona(int IdClienteCreditoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCreditoDocumento_Selecciona");

            db.AddInParameter(dbCommand, "pIdClienteCreditoDocumento", DbType.Int32, IdClienteCreditoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteCreditoDocumentoBE ClienteCreditoDocumento = null;
            while (reader.Read())
            {
                ClienteCreditoDocumento = new ClienteCreditoDocumentoBE();
                ClienteCreditoDocumento.IdClienteCreditoDocumento = Int32.Parse(reader["IdClienteCreditoDocumento"].ToString());
                ClienteCreditoDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteCreditoDocumento;
        }

        public List<ClienteCreditoDocumentoBE> SeleccionaTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteCreditoDocumento_Selecciona");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCreditoDocumentoBE> ClienteCreditoDocumentolist = new List<ClienteCreditoDocumentoBE>();
            ClienteCreditoDocumentoBE ClienteCreditoDocumento;
            while (reader.Read())
            {
                ClienteCreditoDocumento = new ClienteCreditoDocumentoBE();
                ClienteCreditoDocumento.IdClienteCreditoDocumento = Int32.Parse(reader["IdClienteCreditoDocumento"].ToString());
                ClienteCreditoDocumento.IdClienteCredito = Int32.Parse(reader["idClienteCredito"].ToString());
                ClienteCreditoDocumento.Documento = reader["documento"].ToString();
                ClienteCreditoDocumento.FlagAprobado = Boolean.Parse(reader["flagAprobado"].ToString());
                ClienteCreditoDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCreditoDocumentolist.Add(ClienteCreditoDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCreditoDocumentolist;
        }

        public List<ClienteCreditoDocumentoBE> ListaTodosActivo(int IdClienteCreditoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdClienteCreditoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteCreditoDocumentoBE> ClienteCreditoDocumentolist = new List<ClienteCreditoDocumentoBE>();
            ClienteCreditoDocumentoBE ClienteCreditoDocumento;
            while (reader.Read())
            {
                ClienteCreditoDocumento = new ClienteCreditoDocumentoBE();
                ClienteCreditoDocumento.IdClienteCreditoDocumento = Int32.Parse(reader["idClienteCreditoDocumento"].ToString());
                ClienteCreditoDocumento.IdClienteCredito = Int32.Parse(reader["idClienteCredito"].ToString());
                ClienteCreditoDocumento.Documento = reader["documento"].ToString();
                ClienteCreditoDocumento.FlagAprobado = Boolean.Parse(reader["flagAprobado"].ToString());
                ClienteCreditoDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteCreditoDocumentolist.Add(ClienteCreditoDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCreditoDocumentolist;
        }
    }
}

