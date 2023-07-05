using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CajaEgresoDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Empresa { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String De { get; set; }
        [DataMember]
        public Int32 IdCajaEgreso { get; set; }
        [DataMember]
        public Int32 IdCajaEgresoDetalle { get; set; }
        [DataMember]
        public Int32 IdCajaEgresoDetalleDocumentos { get; set; }
        [DataMember]
        public Int32 TipoOperacion { get; set; }
        [DataMember]
        public String Operacion { get; set; }
        [DataMember]
        public DateTime ?Fecha { get; set; }
        [DataMember]
        public Int32 Numero { get; set; }
        [DataMember]
        public String NumRecibo { get; set; }
        [DataMember]
        public Int32 TipoPersona { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String NumDocumento { get; set; }
        [DataMember]
        public String Recibio { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal ImporteIngreso { get; set; }
        [DataMember]
        public Decimal ImporteEgreso { get; set; }
        [DataMember]
        public Decimal Importe  { get; set; }
        [DataMember]
        public String ImporteTexto { get; set; }
        [DataMember]
        public Decimal ImporteRendicion { get; set; }
        [DataMember]
        public Decimal ImporteDevuelto { get; set; }
        [DataMember]
        public Decimal EAdicional { get; set; }
        [DataMember]
        public Decimal PorRendir { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String UsuarioCreacion { get; set; }
        [DataMember]
        public Int32  FlagEstado { get; set; }

        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Boolean FlagEAdicional { get; set; }
        [DataMember]
        public String NombreCaja { get; set; }
        [DataMember]
        public Boolean FlagRevisa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdTipoEgreso { get; set; }

        #endregion
    }
}
