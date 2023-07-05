using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CuentaBancoDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCuentaBancoDetalle { get; set; }
        [DataMember]
        public Int32 IdCuentaBanco { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroMovimiento  { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public Decimal ITF { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Int32 IdCuentaBancoDetalleCausal { get; set; }
        [DataMember]
        public Int32 IdCuentaBancoDetalleConcepto { get; set; }
        [DataMember]
        public Int32? IdCliente { get; set; }
        [DataMember]
        public Int32? IdProveedor { get; set; }
        [DataMember]
        public Int32? IdTienda { get; set; }
        [DataMember]
        public DateTime? FechaCuadre { get; set; }

        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Decimal CuentaCargo { get; set; }
        [DataMember]
        public Decimal PagoAbono { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String DescTienda { get; set; }

        #endregion
    }
}
