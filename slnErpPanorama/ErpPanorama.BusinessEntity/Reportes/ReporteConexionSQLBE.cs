using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteConexionSQLBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 session_id { get; set; }
        [DataMember]
        public Int32 most_recent_session_id { get; set; }
        [DataMember]
        public DateTime connect_time { get; set; }
        [DataMember]
        public String net_transport { get; set; }
        [DataMember]
        public String protocol_type { get; set; }
        [DataMember]
        public String protocol_version { get; set; }
        [DataMember]
        public Int32 endpoint_id { get; set; }
        [DataMember]
        public Boolean encrypt_option { get; set; }
        [DataMember]
        public String auth_scheme { get; set; }
        [DataMember]
        public Int32 node_affinity { get; set; }
        [DataMember]
        public Int32 num_reads { get; set; }
        [DataMember]
        public Int32 num_writes { get; set; }
        [DataMember]
        public DateTime last_read { get; set; }
        [DataMember]
        public DateTime last_write { get; set; }
        [DataMember]
        public Int32 net_packet_size { get; set; }
        [DataMember]
        public String client_net_address { get; set; }
        [DataMember]
        public String client_tcp_port { get; set; }
        [DataMember]
        public String local_net_address { get; set; }
        [DataMember]
        public String local_tcp_port { get; set; }
        [DataMember]
        public String connection_id { get; set; }
        [DataMember]
        public String parent_connection_id { get; set; }
        [DataMember]
        public String most_recent_sql_handle { get; set; }
        [DataMember]
        public Int32 spid { get; set; }
        [DataMember]
        public Int32 kpid { get; set; }
        [DataMember]
        public Int32 blocked { get; set; }
        [DataMember]
        public String waittype { get; set; }
        [DataMember]
        public Int32 waittime { get; set; }
        [DataMember]
        public String lastwaittype { get; set; }
        [DataMember]
        public String waitresource { get; set; }
        [DataMember]
        public Int32 dbid { get; set; }
        [DataMember]
        public Int32 uid { get; set; }
        [DataMember]
        public Int32 cpu { get; set; }
        [DataMember]
        public Int32 physical_io { get; set; }
        [DataMember]
        public Int32 memusage { get; set; }
        [DataMember]
        public DateTime login_time { get; set; }
        [DataMember]
        public DateTime last_batch { get; set; }
        [DataMember]
        public Int32 ecid { get; set; }
        [DataMember]
        public Int32 open_tran { get; set; }
        [DataMember]
        public String status { get; set; }
        [DataMember]
        public String sid { get; set; }
        [DataMember]
        public String hostname { get; set; }
        [DataMember]
        public String program_name { get; set; }
        [DataMember]
        public Int32 hostprocess { get; set; }
        [DataMember]
        public String cmd { get; set; }
        [DataMember]
        public String nt_domain { get; set; }
        [DataMember]
        public String nt_username { get; set; }
        [DataMember]
        public String net_address { get; set; }
        [DataMember]
        public String net_library { get; set; }
        [DataMember]
        public String loginame { get; set; }
        [DataMember]
        public String context_info { get; set; }
        [DataMember]
        public String sql_handle { get; set; }
        [DataMember]
        public Int32 stmt_start { get; set; }
        [DataMember]
        public Int32 stmt_end { get; set; }
        [DataMember]
        public Int32 request_id { get; set; }


        #endregion
    }
}
