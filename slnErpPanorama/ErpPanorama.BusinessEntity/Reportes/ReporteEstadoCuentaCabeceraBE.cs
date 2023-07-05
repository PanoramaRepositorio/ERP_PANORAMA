using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteEstadoCuentaCabeceraBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String OtroTelefono { get; set; }
        [DataMember]
        public String TelefonoAdicional { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public Decimal LineaCredito { get; set; }
        [DataMember]
        public Decimal LineaCreditoUtilizada { get; set; }
        [DataMember]
        public Decimal LineaCreditoDisponible { get; set; }
        [DataMember]
        public Decimal SaldoAnterior { get; set; }
        #endregion
    }
}
