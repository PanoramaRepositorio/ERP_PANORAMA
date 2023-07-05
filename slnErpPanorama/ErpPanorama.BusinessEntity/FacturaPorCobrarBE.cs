using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class FacturaPorCobrarBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32? IdPedido { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Int32 IdSituacionPedido { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32? IdDocumentoReferencia { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Int32 DiasVencimiento { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }

        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public Int32 IdClasificacionCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Int32 IdSituacionPSE { get; set; }
        [DataMember]
        public String DescSituacionPSE { get; set; }

        [DataMember]
        public Int32 IdSituacionContable { get; set; }
        [DataMember]
        public String DescSituacionContable { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }


        #endregion
    }
}
