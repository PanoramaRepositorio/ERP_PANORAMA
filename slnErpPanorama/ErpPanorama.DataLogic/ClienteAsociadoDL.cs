using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteAsociadoDL
    {
        public ClienteAsociadoDL() { }

        public void Inserta(ClienteAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ClienteAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdClienteAsociado);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteAsociadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, pItem.IdClienteAsociado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ClienteAsociadoBE> ListaTodosActivo(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteAsociadoBE> ClienteAsociadolist = new List<ClienteAsociadoBE>();
            ClienteAsociadoBE ClienteAsociado;
            while (reader.Read())
            {
                ClienteAsociado = new ClienteAsociadoBE();
                ClienteAsociado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClienteAsociado.IdClienteAsociado = Int32.Parse(reader["idClienteAsociado"].ToString());
                ClienteAsociado.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAsociado.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteAsociado.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteAsociado.NumeroDocumento = reader["numeroDocumento"].ToString();
                ClienteAsociado.DescCliente = reader["DescCliente"].ToString();
                ClienteAsociado.Direccion = reader["direccion"].ToString();
                ClienteAsociado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteAsociado.TipoOper = 4; //Consultar
                ClienteAsociadolist.Add(ClienteAsociado);
            }
            reader.Close();
            reader.Dispose();
            return ClienteAsociadolist;
        }

        public List<ClienteAsociadoBE> ListaTodosActivoConPrincipal(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_ListaTodosActivoConPrincipal");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteAsociadoBE> ClienteAsociadolist = new List<ClienteAsociadoBE>();
            ClienteAsociadoBE ClienteAsociado;
            while (reader.Read())
            {
                ClienteAsociado = new ClienteAsociadoBE();
                ClienteAsociado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClienteAsociado.IdClienteAsociado = Int32.Parse(reader["IdClienteAsociado"].ToString());
                ClienteAsociado.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAsociado.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteAsociado.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteAsociado.NumeroDocumento = reader["numeroDocumento"].ToString();
                ClienteAsociado.DescCliente = reader["DescCliente"].ToString();
                ClienteAsociado.Direccion = reader["direccion"].ToString();
                ClienteAsociado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteAsociado.TipoOper = 4; //Consultar
                ClienteAsociadolist.Add(ClienteAsociado);
            }
            reader.Close();
            reader.Dispose();
            return ClienteAsociadolist;
        }

        public ClienteAsociadoBE SeleccionaConPrincipal(int IdEmpresa, int IdCliente, int IdClienteAsociado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_SeleccionaConPrincipal");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdClienteAsociado", DbType.Int32, IdClienteAsociado);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteAsociadoBE ClienteAsociado = null;
            while (reader.Read())
            {
                ClienteAsociado = new ClienteAsociadoBE();
                ClienteAsociado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClienteAsociado.IdClienteAsociado = Int32.Parse(reader["IdClienteAsociado"].ToString());
                ClienteAsociado.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAsociado.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteAsociado.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteAsociado.NumeroDocumento = reader["numeroDocumento"].ToString();
                ClienteAsociado.DescCliente = reader["DescCliente"].ToString();
                ClienteAsociado.Direccion = reader["direccion"].ToString();
                ClienteAsociado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteAsociado.TipoOper = 4; //Consultar
            }
            reader.Close();
            reader.Dispose();
            return ClienteAsociado;
        }

        public ClienteAsociadoBE SeleccionaNumero(int IdEmpresa, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteAsociadoBE ClienteAsociado = null;
            while (reader.Read())
            {
                ClienteAsociado = new ClienteAsociadoBE();
                ClienteAsociado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClienteAsociado.IdClienteAsociado = Int32.Parse(reader["idClienteAsociado"].ToString());
                ClienteAsociado.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAsociado.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteAsociado.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteAsociado.NumeroDocumento = reader["numeroDocumento"].ToString();
                ClienteAsociado.DescCliente = reader["DescCliente"].ToString();
                ClienteAsociado.Direccion = reader["direccion"].ToString();
                ClienteAsociado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteAsociado;
        }

        public ClienteAsociadoBE SeleccionaDescripcion(int IdEmpresa, string DescCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteAsociado_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, DescCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ClienteAsociadoBE ClienteAsociado = null;
            while (reader.Read())
            {
                ClienteAsociado = new ClienteAsociadoBE();
                ClienteAsociado.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ClienteAsociado.IdClienteAsociado = Int32.Parse(reader["idClienteAsociado"].ToString());
                ClienteAsociado.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteAsociado.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ClienteAsociado.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteAsociado.NumeroDocumento = reader["numeroDocumento"].ToString();
                ClienteAsociado.DescCliente = reader["DescCliente"].ToString();
                ClienteAsociado.Direccion = reader["direccion"].ToString();
                ClienteAsociado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ClienteAsociado;
        }
    }
}
