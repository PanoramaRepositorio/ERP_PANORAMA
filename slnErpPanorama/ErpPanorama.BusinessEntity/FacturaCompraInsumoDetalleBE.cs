using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class FacturaCompraInsumoDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdFacturaCompraInsumoDetalle { get; set; }
		[DataMember]
		public Int32 IdFacturaCompraInsumo { get; set; }
		[DataMember]
		public Int32 IdInsumo { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
		public Int32 Cantidad { get; set; }
		[DataMember]
		public Decimal PrecioUnitario { get; set; }
		[DataMember]
		public Decimal SubTotal { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Byte[] Imagen { get; set; }
        

        #endregion

    }
}


