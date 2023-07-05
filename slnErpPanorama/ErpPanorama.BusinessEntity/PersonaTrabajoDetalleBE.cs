using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PersonaTrabajoDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPersonaTrabajoDetalle { get; set; }
		[DataMember]
		public Int32 IdPersonaTrabajo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
		public Int32 IdArea { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Int32 IdAusencia { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public Boolean FlagApoyo { get; set; }
        [DataMember]
        public String Asistencia { get; set; }
        [DataMember]
        public String HoraIngreso { get; set; }
        [DataMember]
        public String HoraSalida { get; set; }
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

