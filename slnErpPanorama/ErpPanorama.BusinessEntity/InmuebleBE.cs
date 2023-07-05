using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class InmuebleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInmueble { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdTipoInmueble { get; set; }
        [DataMember]
        public String DescTipoInmueble { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String DescInmueble { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal PrecioAlquiler { get; set; }
        [DataMember]
        public byte[] Imagen { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
