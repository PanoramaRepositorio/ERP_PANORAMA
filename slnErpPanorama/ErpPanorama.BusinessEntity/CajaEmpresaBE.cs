using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CajaEmpresaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCajaEmpresa { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Int32 IdTipoFormato { get; set; }
        [DataMember]
        public String DescTipoFormato { get; set; }

        [DataMember]
        public String SerieBoleta { get; set; }
        [DataMember]
        public String SerieFactura { get; set; }

        #endregion
    }
}
