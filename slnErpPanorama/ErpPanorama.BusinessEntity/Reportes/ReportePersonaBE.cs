using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public Int32 IdSexo { get; set; }
        [DataMember]
        public String DescSexo { get; set; }
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
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
        public String DescPlaAfp { get; set; }
        [DataMember]
        public String Brevete { get; set; }
        [DataMember]
        public Int32 IdEstadoCivil { get; set; }
        [DataMember]
        public String DescEstadoCivil { get; set; }
        [DataMember]
        public DateTime FechaNac { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
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
        public Int32 IdArea { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        
        #endregion
    }
}