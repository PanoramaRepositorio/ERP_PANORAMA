using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteMovimientoPedidoBE
    {
        #region "Atributos"
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescAgencia { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String DireccionCliente { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public String DescPrioridad { get; set; }
        [DataMember]
        public String DescDestino { get; set; }
        [DataMember]
        public String DescPagoFlete { get; set; }
        [DataMember]
        public String NumeroDespacho { get; set; }
        [DataMember]
        public DateTime FechaDespacho2 { get; set; }
        [DataMember]
        public Int32 NumeroPiso { get; set; }
        [DataMember]
        public String Observacion2 { get; set; }
        [DataMember]
        public String DescMoneeda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String NumeroCliente { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescEmbalador { get; set; }
        [DataMember]
        public DateTime FechaEmbalado { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public String NumeroComprobante { get; set; }

        [DataMember]
        public String DeliveryDep { get; set; }

        [DataMember]
        public String DeliveryProv { get; set; }
        [DataMember]
        public String DeliveryDist { get; set; }
        [DataMember]
        public String PersonaRecoge { get; set; }

        [DataMember]
        public String Conductor { get; set; }

        [DataMember]
        public String Copiloto { get; set; }
        [DataMember]
        public String Placa { get; set; }

        #endregion
    }
}
