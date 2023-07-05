using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PersonaBE
    {
        #region "Atributos"
		[DataMember]
		public Int32 IdPersona { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
		[DataMember]
		public Int32 IdSexo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
		public String Dni { get; set; }
		[DataMember]
		public String Nombres { get; set; }
		[DataMember]
		public String Apellidos { get; set; }
		[DataMember]
		public String ApeNom { get; set; }
		[DataMember]
		public Int32 IdCargo { get; set; }
		[DataMember]
		public String Essalud { get; set; }
		[DataMember]
		public Boolean FlagEps { get; set; }
		[DataMember]
		public Boolean FlagSctr { get; set; }
        [DataMember]
        public Boolean FlagOnp { get; set; }
        [DataMember]
        public Int32 IdPlaAfp { get; set; }
        [DataMember]
        public String Cuspp { get; set; }
        [DataMember]
        public Boolean FlagPensionista { get; set; }
        [DataMember]
		public String Brevete { get; set; }
		[DataMember]
		public Int32 IdEstadoCivil { get; set; }
		[DataMember]
		public DateTime FechaNac { get; set; }
		[DataMember]
		public String IdUbigeo { get; set; }
		[DataMember]
		public String Direccion { get; set; }
		[DataMember]
		public String Telefono { get; set; }
		[DataMember]
		public String Celular { get; set; }
		[DataMember]
		public String TelefonoOtro { get; set; }
		[DataMember]
		public String Email { get; set; }
		[DataMember]
        public byte[] Foto { get; set; }
		[DataMember]
		public String Observacion { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String RutaCV { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime? FechaCese { get; set; }
        [DataMember]
        public String Descanso { get; set; }
        [DataMember]
        public Boolean FlagHoraExtra { get; set; }
        [DataMember]
        public Boolean FlagAsignacion { get; set; }
        [DataMember]
        public Boolean FlagApoyo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescSexo { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String DescEstadoCivil { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public Int32 IdDisponibilidad { get; set; }


        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String UsuarioSol { get; set; }
        [DataMember]
        public String ClaveSol { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public String MotivoCese { get; set; }
        [DataMember]
        public String DescTipoContrato { get; set; }
        [DataMember]
        public String DescTipoRenta { get; set; }
        [DataMember]
        public String NumeroCuenta { get; set; }
        [DataMember]
        public Int32 Edad { get; set; }

        [DataMember]
        public DateTime? FechaInicioContrato { get; set; }
        [DataMember]
        public DateTime? FechaFinContrato { get; set; }
        [DataMember]
        public Boolean FlagAsistencia { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public String Password { get; set; }

        [DataMember]
        public Int32 DiasVacaciones { get; set; }

        [DataMember]
        public Decimal Sueldo { get; set; }

        [DataMember]
        public Int32 Discapacidad { get; set; }
        [DataMember]
        public Int32 SituacionEspecial { get; set; }
        [DataMember]
        public Int32 ClasificaPuesto { get; set; }
        #endregion
    }
}
