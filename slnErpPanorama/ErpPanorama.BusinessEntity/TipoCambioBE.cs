using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TipoCambioBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdTipoCambio { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Decimal Compra { get; set; }
        [DataMember]
        public Decimal Venta { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public Decimal CompraSunat { get; set; }
        [DataMember]
        public Decimal VentaSunat { get; set; }

        #endregion
    }
}
