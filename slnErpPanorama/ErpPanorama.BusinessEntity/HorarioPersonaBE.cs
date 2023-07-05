using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class HorarioPersonaBE
	{
		#region "Atributos"

		[DataMember]
		public Int32 IdHorarioPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DiaSemanaName { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 Mes { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaSalidaRef { get; set; }
        [DataMember]
        public DateTime FechaIngresoRef { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }



        [DataMember]
        public Int32 IdHorarioTipoIncidencia { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescTurno { get; set; }
        [DataMember]
        public Boolean FlagObligatorio { get; set; }
        [DataMember]
        public Boolean FlagApoyo { get; set; }
        [DataMember]
        public Boolean FlagPagado { get; set; }

        [DataMember]
        public Decimal Sueldo { get; set; }

        [DataMember]
        public Decimal SueldoHora { get; set; }


        [DataMember]
        public Decimal TotalHorasRef { get; set; }
        [DataMember]
        public Decimal TotalHorasTrab { get; set; }
        [DataMember]
        public Int32 ToleranciaTarde { get; set; }
        [DataMember]
        public Boolean FlagCerrado { get; set; }
        [DataMember]
        public Int32 IdPersonaRegistro { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public Int32 IdPersonaModifica { get; set; }
        [DataMember]
        public DateTime FechaModifica { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
		public DateTime? FechaInicio { get; set; }
		[DataMember]
		public DateTime? FechaFin { get; set; }
		[DataMember]
		public Int32 Refrigerio { get; set; }


    
        #endregion

    }
}

