using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteConexionSQLDL
    {
        public List<ReporteConexionSQLBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConexionesSQL_ListaTodosActivo");
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            //db.AddInParameter(dbCommand, "pIdConexionSQL", DbType.Int32, IdConexionSQL);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteConexionSQLBE> ConexionSQLlist = new List<ReporteConexionSQLBE>();
            ReporteConexionSQLBE ConexionSQL;
            while (reader.Read())
            {
                ConexionSQL = new ReporteConexionSQLBE();
                ConexionSQL.session_id = Int32.Parse(reader["session_id"].ToString());
                ConexionSQL.most_recent_session_id = Int32.Parse(reader["most_recent_session_id"].ToString());
                ConexionSQL.connect_time = DateTime.Parse(reader["connect_time"].ToString());
                ConexionSQL.net_transport = reader["net_transport"].ToString();
                ConexionSQL.protocol_type = reader["protocol_type"].ToString();
                ConexionSQL.protocol_version = reader["protocol_version"].ToString();
                ConexionSQL.endpoint_id = Int32.Parse(reader["endpoint_id"].ToString());
                ConexionSQL.encrypt_option = Boolean.Parse(reader["encrypt_option"].ToString());
                ConexionSQL.auth_scheme = reader["auth_scheme"].ToString();
                ConexionSQL.node_affinity = Int32.Parse(reader["node_affinity"].ToString());
                ConexionSQL.num_reads = Int32.Parse(reader["num_reads"].ToString());
                ConexionSQL.num_writes = Int32.Parse(reader["num_writes"].ToString());
                ConexionSQL.last_read = DateTime.Parse(reader["last_read"].ToString());
                ConexionSQL.last_write = DateTime.Parse(reader["last_write"].ToString());
                ConexionSQL.net_packet_size = Int32.Parse(reader["net_packet_size"].ToString());
                ConexionSQL.client_net_address = reader["client_net_address"].ToString();
                ConexionSQL.client_tcp_port = reader["client_tcp_port"].ToString();
                ConexionSQL.local_net_address = reader["local_net_address"].ToString();
                ConexionSQL.local_tcp_port = reader["local_tcp_port"].ToString();
                ConexionSQL.connection_id = reader["connection_id"].ToString();
                ConexionSQL.parent_connection_id = reader["parent_connection_id"].ToString();
                ConexionSQL.most_recent_sql_handle = reader["most_recent_sql_handle"].ToString();
                ConexionSQL.spid = Int32.Parse(reader["spid"].ToString());
                ConexionSQL.kpid = Int32.Parse(reader["kpid"].ToString());
                ConexionSQL.blocked = Int32.Parse(reader["blocked"].ToString());
                ConexionSQL.waittype = reader["waittype"].ToString();
                ConexionSQL.waittime = Int32.Parse(reader["waittime"].ToString());
                ConexionSQL.lastwaittype = reader["lastwaittype"].ToString();
                ConexionSQL.waitresource = reader["waitresource"].ToString();
                ConexionSQL.dbid = Int32.Parse(reader["dbid"].ToString());
                ConexionSQL.uid = Int32.Parse(reader["uid"].ToString());
                ConexionSQL.cpu = Int32.Parse(reader["cpu"].ToString());
                ConexionSQL.physical_io = Int32.Parse(reader["physical_io"].ToString());
                ConexionSQL.memusage = Int32.Parse(reader["memusage"].ToString());
                ConexionSQL.login_time = DateTime.Parse(reader["login_time"].ToString());
                ConexionSQL.last_batch = DateTime.Parse(reader["last_batch"].ToString());
                ConexionSQL.ecid = Int32.Parse(reader["ecid"].ToString());
                ConexionSQL.open_tran = Int32.Parse(reader["open_tran"].ToString());
                ConexionSQL.status = reader["status"].ToString();
                ConexionSQL.sid = reader["sid"].ToString();
                ConexionSQL.hostname = reader["hostname"].ToString();
                ConexionSQL.program_name = reader["program_name"].ToString();
                ConexionSQL.hostprocess = Int32.Parse(reader["hostprocess"].ToString());
                ConexionSQL.cmd = reader["cmd"].ToString();
                ConexionSQL.nt_domain = reader["nt_domain"].ToString();
                ConexionSQL.nt_username = reader["nt_username"].ToString();
                ConexionSQL.net_address = reader["net_address"].ToString();
                ConexionSQL.net_library = reader["net_library"].ToString();
                ConexionSQL.loginame = reader["loginame"].ToString();
                ConexionSQL.context_info = reader["context_info"].ToString();
                ConexionSQL.sql_handle = reader["sql_handle"].ToString();
                ConexionSQL.stmt_start = Int32.Parse(reader["stmt_start"].ToString());
                ConexionSQL.stmt_end = Int32.Parse(reader["stmt_end"].ToString());
                ConexionSQL.request_id = Int32.Parse(reader["request_id"].ToString());

                ConexionSQLlist.Add(ConexionSQL);
            }
            reader.Close();
            reader.Dispose();
            return ConexionSQLlist;
        }
    }
}
