using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class InmueblePagoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInmueblePago { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public Int32 IdInmueble { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime? FechaPago { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public String Observacion { get; set; }

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
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Decimal CreditoCargo { get; set; }
        [DataMember]
        public Decimal PagoAbono { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }

        #endregion
    }
}
