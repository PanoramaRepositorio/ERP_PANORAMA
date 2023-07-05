using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteMinoristaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Int32 IdTipoDireccion { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String NumDireccion { get; set; }
        [DataMember]
        public String Urbanizacion { get; set; }
        [DataMember]
        public String IdUbigeoDom { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String OtroTelefono { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public DateTime? FechaNac { get; set; }
        [DataMember]
        public DateTime? FechaAniv { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        #endregion
    }
}

