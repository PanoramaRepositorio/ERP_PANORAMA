using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PromocionTemporalBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPromocionTemporal { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescPromocionTemporal { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdTipoVenta { get; set; }
        [DataMember]
        public String DescTipoVenta { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }

        [DataMember]
        public DateTime FechaInicioImpresion { get; set; }
        [DataMember]
        public DateTime FechaFinImpresion { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }


        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Boolean FlagContado { get; set; }
        [DataMember]
        public Boolean FlagCredito { get; set; }
        [DataMember]
        public Boolean FlagConsignacion { get; set; }
        [DataMember]
        public Boolean FlagSeparacion { get; set; }
        [DataMember]
        public Boolean FlagContraentrega { get; set; }
        [DataMember]
        public Boolean FlagCopagan { get; set; }
        [DataMember]
        public Boolean FlagObsequio { get; set; }
        [DataMember]
        public Boolean FlagAsaf { get; set; }
        [DataMember]
        public Boolean FlagClienteMayorista { get; set; }
        [DataMember]
        public Boolean FlagClienteFinal { get; set; }
        [DataMember]
        public Boolean FlagWeb { get; set; }


        [DataMember]
        public Boolean FlagUcayali { get; set; }
        [DataMember]
        public Boolean FlagAndahuaylas { get; set; }
        [DataMember]
        public Boolean FlagPrescott { get; set; }
        [DataMember]
        public Boolean FlagAviacion { get; set; }
        [DataMember]
        public Boolean FlagMegaplaza { get; set; }
        [DataMember]
        public Boolean FlagAviacion2 { get; set; }
        [DataMember]
        public Boolean FlagSanMiguel { get; set; }
        #endregion
    }
}

