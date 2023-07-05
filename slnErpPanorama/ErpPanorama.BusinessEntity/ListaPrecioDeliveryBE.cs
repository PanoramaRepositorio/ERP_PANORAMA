using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ListaPrecioDeliveryBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdListaPrecioDelivery { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String IdDepartamento { get; set; }
        [DataMember]
        public String IdProvincia { get; set; }
        [DataMember]
        public String IdDistrito { get; set; }
        [DataMember]
        public String DescUbigeo { get; set; }

        [DataMember]
        public Decimal TarifaEnvio { get; set; }
        [DataMember]
        public Decimal TarifaEnvioA { get; set; }
        [DataMember]
        public Decimal TarifaEnvioP { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String NomDist { get; set; }

        #endregion
    }
}
