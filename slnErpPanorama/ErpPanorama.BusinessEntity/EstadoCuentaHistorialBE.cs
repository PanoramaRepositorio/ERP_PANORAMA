using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EstadoCuentaHistorialBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEstadoCuentaHistorial { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime FechaCredito { get; set; }
        [DataMember]
        public DateTime? FechaDeposito { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public Int32? IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32? IdCotizacion { get; set; }
        [DataMember]
        public Int32? IdPedido { get; set; }
        [DataMember]
        public Int32? IdMovimientoCaja { get; set; }

        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String ObservacionElimina { get; set; }
        [DataMember]
        public String ObservacionOrigen { get; set; }
        [DataMember]
        public DateTime FechaElimina { get; set; }

        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String NumeroDocumentoCliente { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String DescCliente { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Decimal ImporteAnt { get; set; }
        [DataMember]
        public Decimal CreditoCargo { get; set; }
        [DataMember]
        public Decimal PagoAbono { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }

        [DataMember]
        public String TipoRegistro { get; set; }


        #endregion
    }
}
