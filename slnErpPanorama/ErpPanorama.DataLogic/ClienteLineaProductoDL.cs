using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ClienteLineaProductoDL
    {
        public ClienteLineaProductoDL() { }

        public void Inserta(ClienteLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteLineaProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdClienteLineaProducto", DbType.Int32, pItem.IdClienteLineaProducto);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ClienteLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteLineaProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdClienteLineaProducto", DbType.Int32, pItem.IdClienteLineaProducto);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ClienteLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteLineaProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdClienteLineaProducto", DbType.Int32, pItem.IdClienteLineaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ClienteLineaProductoBE> ListaTodosActivo(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ClienteLineaProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ClienteLineaProductoBE> ClienteLineaProductolist = new List<ClienteLineaProductoBE>();
            ClienteLineaProductoBE ClienteLineaProducto;
            while (reader.Read())
            {
                ClienteLineaProducto = new ClienteLineaProductoBE();
                ClienteLineaProducto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ClienteLineaProducto.IdClienteLineaProducto = Int32.Parse(reader["IdClienteLineaProducto"].ToString());
                ClienteLineaProducto.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ClienteLineaProducto.IdLineaProducto = Int32.Parse(reader["idLineaProducto"].ToString());
                ClienteLineaProducto.Numero = Int32.Parse(reader["Numero"].ToString());
                ClienteLineaProducto.DescLineaProducto = reader["descLineaProducto"].ToString();
                ClienteLineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ClienteLineaProducto.TipoOper = 4; //Consultar
                ClienteLineaProductolist.Add(ClienteLineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return ClienteLineaProductolist;
        }
    }
}
