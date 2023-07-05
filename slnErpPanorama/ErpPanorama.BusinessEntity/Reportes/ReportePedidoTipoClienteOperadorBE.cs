using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoTipoClienteOperadorBE
    {
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String Destino { get; set; }
        [DataMember]
        public Boolean Aprobado { get; set; }
        [DataMember]
        public String FechaAprobado { get; set; }
        [DataMember]
        public Boolean Recibido { get; set; }
        [DataMember]
        public String FechaRecibido { get; set; }
        [DataMember]
        public Boolean Preparacion { get; set; }
        [DataMember]
        public String FechaPreparacion { get; set; }
        [DataMember]
        public Boolean Chequeo { get; set; }
        [DataMember]
        public String FechaChequeo { get; set; }
        [DataMember]
        public Boolean EnPT { get; set; }
        [DataMember]
        public String FechaPT { get; set; }
        [DataMember]
        public Boolean RecepcionDocumento { get; set; }
        [DataMember]
        public String FechaRD { get; set; }
        [DataMember]
        public Boolean Despachado { get; set; }
        [DataMember]
        public String FechaDespachado { get; set; }
        [DataMember]
        public String FechaAnulado { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Conductor { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Int32 TotalCantidadInicial { get; set; }
        [DataMember]
        public Int32 TotalItemsInicial { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Int32 TotalItems { get; set; }



        //date
        //public Boolean Recibido { get; set; }
        //[DataMember]
        //public DateTime FechaRecibido { get; set; }
        //[DataMember]
        //public Boolean Preparacion { get; set; }
        //[DataMember]
        //public DateTime FechaPreparacion { get; set; }
        //[DataMember]
        //public Boolean Chequeo { get; set; }
        //[DataMember]
        //public DateTime FechaChequeo { get; set; }
        //[DataMember]
        //public Boolean EnPT { get; set; }
        //[DataMember]
        //public DateTime FechaPT { get; set; }
        //[DataMember]
        //public Boolean RecepcionDocumento { get; set; }
        //[DataMember]
        //public DateTime FechaRD { get; set; }
        //[DataMember]
        //public Boolean Despachado { get; set; }
        //[DataMember]
        //public DateTime FechaDespachado { get; set; }
        //[DataMember]
        //public DateTime FechaAnulado { get; set; }


    }
}
