using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class SolicitudInsumoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdSolicitudInsumo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
		public String Numero { get; set; }
		[DataMember]
		public DateTime FechaSolicitud { get; set; }
		[DataMember]
		public Int32 IdInsumoAlmacenOrigen { get; set; }
        [DataMember]
        public String DescInsumoAlmacen { get; set; }
		[DataMember]
		public Int32 IdInsumoAlmacenDestino { get; set; }
        [DataMember]
        public String DescInsumoAlmacenDestino { get; set; }
        [DataMember]
		public Int32 IdSolicitante { get; set; }
		[DataMember]
		public Boolean FlagEnviado { get; set; }
		[DataMember]
		public Boolean FlagRecibido { get; set; }
		[DataMember]
		public DateTime FechaDelivery { get; set; }
		[DataMember]
		public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        
        #endregion

    }
}

