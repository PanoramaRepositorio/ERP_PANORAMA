using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class ClienteEncuestaBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdClienteEncuesta { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Boolean Facebook { get; set; }
        [DataMember]
        public Boolean Instagram { get; set; }
        [DataMember]
        public Boolean Radio { get; set; }
        [DataMember]
        public Boolean Television { get; set; }
        [DataMember]
        public Boolean Revista { get; set; }
        [DataMember]
        public Boolean Amigo { get; set; }
        [DataMember]
        public Boolean Panel { get; set; }
        [DataMember]
        public Boolean Web { get; set; }
        [DataMember]
        public Boolean Correo { get; set; }
        [DataMember]
        public Boolean Periodico { get; set; }
        [DataMember]
        public Boolean Sms { get; set; }
        [DataMember]
        public Boolean Otro { get; set; }
        [DataMember]
        public String RespuestaOtro { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescTienda { get; set; }

        [DataMember]
        public DateTime? FechaNac { get; set; }
        [DataMember]
        public DateTime? FechaAniv { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion

    }
}

