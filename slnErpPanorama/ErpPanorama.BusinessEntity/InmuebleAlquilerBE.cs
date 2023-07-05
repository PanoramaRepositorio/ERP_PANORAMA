using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class InmuebleAlquilerBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInmuebleAlquiler { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdInmueble { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal PrecioAlquiler { get; set; }
        [DataMember]
        public Decimal Adelanto { get; set; }
        [DataMember]
        public Decimal Garantia { get; set; }
        [DataMember]
        public Int32 DiaPago { get; set; }
        [DataMember]
        public Decimal Mora { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String DescInmueble { get; set; }
        [DataMember]
        public String DescTipoInmueble { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }

        #endregion
    }
}
