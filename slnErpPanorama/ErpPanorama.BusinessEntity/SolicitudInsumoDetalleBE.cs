using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class SolicitudInsumoDetalleBE
	{
        #region "Atributos"
        
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdSolicitudInsumoDetalle { get; set; }
		[DataMember]
		public Int32 IdSolicitudInsumo { get; set; }
		[DataMember]
		public Int32 Item { get; set; }
		[DataMember]
		public Int32 IdInsumo { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
		public Int32 Cantidad { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Decimal CostoUnitario { get; set; }
		[DataMember]
		public Decimal MontoTotal { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        

        #endregion

    }
}

