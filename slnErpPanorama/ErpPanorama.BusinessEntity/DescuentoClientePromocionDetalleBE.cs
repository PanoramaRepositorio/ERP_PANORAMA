using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class DescuentoClientePromocionDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdDescuentoClientePromocionDetalle { get; set; }
		[DataMember]
		public Int32 IdDescuentoClientePromocion { get; set; }
		[DataMember]
		public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
		[DataMember]
		public Decimal Descuento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
		public Int32 TipoOper { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }


        [DataMember]
        public Int32 AlmacenCentral { get; set; }
        [DataMember]
        public Int32 AlmacenTienda { get; set; }
        [DataMember]
        public Int32 AlmacenAndahuaylas { get; set; }
        [DataMember]
        public Int32 AlmacenPrescott { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion { get; set; }
        [DataMember]
        public Int32 AlmacenMegaPlaza { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public Decimal DescuentoActual { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }

		#endregion

	}
}

