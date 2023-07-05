using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PromocionBultoDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPromocionBultoDetalle { get; set; }
		[DataMember]
		public Int32 IdPromocionBulto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
		[DataMember]
		public Decimal Descuento { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }


        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public Int32 CantidadBultos { get; set; }
        [DataMember]
        public Int32 CantidadPedida { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }

		#endregion

	}
}

