using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class NovioRegaloBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdNovioRegalo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
		public Int32 IdNovio { get; set; }
        [DataMember]
        public String DescNovio { get; set; }
        [DataMember]
		public Int32 IdNovia { get; set; }
        [DataMember]
        public String DescNovia { get; set; }
        [DataMember]
		public String Telefono { get; set; }
		[DataMember]
		public String Celular { get; set; }
        [DataMember]
        public String Celular2 { get; set; }
        [DataMember]
		public String Email { get; set; }
		[DataMember]
		public String Email2 { get; set; }
		[DataMember]
		public String Direccion { get; set; }
		[DataMember]
		public DateTime? FechaBoda { get; set; }
		[DataMember]
		public Int32 IdAsesor { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }


        [DataMember]
		public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }

        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String DniNovio { get; set; }
        [DataMember]
        public String DniNovia { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Decimal TotalInvitados { get; set; }
        [DataMember]
        public Decimal TotalNovios { get; set; }


        #endregion

    }
}

