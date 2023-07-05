using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCambioBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCambio { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescTipoCambio { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String NumeroDocumentoVenta { get; set; }
        [DataMember]
        public DateTime FechaVenta { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String NumeroCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescSupervisor { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String NumeroNotaCredito { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal ValorVentaSoles { get; set; }
        [DataMember]
        public Decimal ValorVentaDolares { get; set; }
        [DataMember]
        public Decimal TotalDolares { get; set; }
        [DataMember]
        public String ObservacionDetalle { get; set; }
        [DataMember]
        public Int32 IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Boolean FlagCumpleanios { get; set; }
        [DataMember]
        public Decimal TotalDscCumpleanios { get; set; }
        #endregion
    }
}
