using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
   public class EstadoCuentaProveedorPagoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEstadoCuentaProveedorPago { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public Int32 DiasVencimiento { get; set; }
        [DataMember]
        public int IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public Int32? IdFacturaCompra { get; set; }
        [DataMember]
        public Int32? IdCuentaBancoDetalle { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }
        [DataMember]
        public Int32 IdEstadoCuentaProveedor { get; set; }
        [DataMember]
        public String GrupoPago { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
