using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class AlmacenPisoBE
	{
        #region "Atributos"
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdAlmacenPiso { get; set; }
		[DataMember]
		public Int32 IdAlmacen { get; set; }
		[DataMember]
		public String DescAlmacenPiso { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        #endregion

    }
}

