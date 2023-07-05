using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVentaTiendaTipoClientePorCargoBE
    {
        #region "Atributos"
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public Decimal ClienteFinal { get; set; }
        [DataMember]
        public Decimal ClienteMayorista { get; set; }
        [DataMember]
        public Int32 CantidadClienteFinal { get; set; }
        [DataMember]
        public Int32 CantidadClienteMayorista { get; set; }
        [DataMember]
        public Decimal CuotaDiario { get; set; }
        [DataMember]
        public Decimal CuotaMensual { get; set; }
        [DataMember]
        public Int32 CantidadPorCargo { get; set; }

        [DataMember]
        public Decimal Diferencia { get; set; }
        [DataMember]
        public Decimal Porcentaje { get; set; }
        [DataMember]
        public Decimal Total { get; set; }


        #endregion
    }
}
