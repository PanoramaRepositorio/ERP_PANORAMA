using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class MovimientoPedidoDespachoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdMovimientoPedidoDespacho { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 IdAgencia { get; set; }
        [DataMember]
        public String DescAgencia { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public Int32 IdPrioridad { get; set; }
        [DataMember]
        public String DescPrioridad { get; set; }
        [DataMember]
        public Int32 IdDestino { get; set; }
        [DataMember]
        public String DescDestino { get; set; }
        [DataMember]
        public Int32 IdPagoFlete { get; set; }
        [DataMember]
        public String DescPagoFlete { get; set; }
        [DataMember]
        public Int32 IdDespachador { get; set; }
        [DataMember]
        public String DescDespachador { get; set; }
        [DataMember]
        public Int32 IdEmbalador { get; set; }
        [DataMember]
        public String DescEmbalador { get; set; }
        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        #endregion
    }
}
