using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDocumentoVentaEmpresaSerieBE
    {
        #region "Atributos"

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Inicio { get; set; }
        [DataMember]
        public String Fin { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Decimal BaseImponible { get; set; }
        [DataMember]
        public Decimal IGV { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }


        #endregion
    }
}
