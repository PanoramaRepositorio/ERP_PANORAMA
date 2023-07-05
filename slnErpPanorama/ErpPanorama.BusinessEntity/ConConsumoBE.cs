using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ConConsumoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdConConsumo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }

        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String Cuo { get; set; }
        [DataMember]
        public String NumeroCuo { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public String IdConTipoComprobantePago { get; set; }
        [DataMember]
        public String DescTipoComprobantePago { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public Int32? PeriodoDua { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String NumeroInicial { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public Int32 IdConPlanContable { get; set; }
        [DataMember]
        public String DescConPlanContable { get; set; }

        [DataMember]
        public Decimal BaseImponible { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal BaseImponible2 { get; set; }
        [DataMember]
        public Decimal Igv2 { get; set; }
        [DataMember]
        public Decimal BaseImponibleSCF { get; set; }
        [DataMember]
        public Decimal IgvSCF { get; set; }
        [DataMember]
        public Decimal ImporteANG { get; set; }
        [DataMember]
        public Decimal Isc { get; set; }
        [DataMember]
        public Decimal OtroCargo { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal ImporteDolares { get; set; }
        [DataMember]
        public Int32? IdConsumoReferencia { get; set; }
        [DataMember]
        public DateTime? FechaReferencia { get; set; }
        [DataMember]
        public Decimal? IdConTipoComprobantePagoReferencia { get; set; }
        [DataMember]
        public String SerieReferencia { get; set; }
        [DataMember]
        public String Cda { get; set; }
        [DataMember]
        public String NumeroReferencia { get; set; }
        [DataMember]
        public DateTime? FechaDeposito { get; set; }
        [DataMember]
        public String NumeroDeposito { get; set; }
        [DataMember]
        public Boolean FlagRetencion { get; set; }
        [DataMember]
        public Int32 IdEstado { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
