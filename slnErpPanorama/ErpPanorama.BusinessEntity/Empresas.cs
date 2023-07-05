using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Empresas
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCajaEmpresa { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32? IdTienda { get; set; }


        [DataMember]
        public String DescTienda { get; set; }

        [DataMember]
        public Int32 IdCaja { get; set; }

        [DataMember]
        public String DescCaja { get; set; }

        [DataMember]
        public Int32 IdTipoFormato { get; set; }

        [DataMember]
        public String DescTipoFormato { get; set; }

        [DataMember]
        public String SerieBoleta { get; set; }
        [DataMember]
        public String SerieFactura { get; set; }
        [DataMember]
        public Int32 IdRegimenTributo { get; set; }
        #endregion
    }
}
