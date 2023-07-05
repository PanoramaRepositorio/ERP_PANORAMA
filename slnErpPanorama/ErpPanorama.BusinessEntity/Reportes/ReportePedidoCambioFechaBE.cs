﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoCambioFechaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String Observaciones { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 CantidadDevuelto { get; set; }
        [DataMember]
        public Int32 Saldo { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String FechaDevolucion { get; set; }
        
        #endregion
    }
}
