using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CajaEgresoDetalleDocumentosBE
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
        public Int32 IdCajaEgreso  { get; set; }
        [DataMember]
        public Int32 IdCajaEgresoDetalle { get; set; }
        [DataMember]
        public Int32 IdCajaEgresoDetalleDocumentos { get; set; }
        [DataMember]
        public Int32 IdCentroCosto { get; set; }
        [DataMember]
        public String CentroCosto { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public String Area { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 TipoOperacion { get; set; }
        [DataMember]
        public DateTime ?Fecha { get; set; }
        [DataMember]
        public DateTime Fecha2 { get; set; }
        [DataMember]
        public DateTime? FechaFactura { get; set; }
        [DataMember]
        public Int32 Numero { get; set; }
        [DataMember]
        public String NumDocProv { get; set; }
        [DataMember]
        public String DescProv { get; set; }
        [DataMember]
        public String NumRecibo { get; set; }
        [DataMember]
        public String NumRecIndice { get; set; }
        [DataMember]
        public Int32 TipoPersona { get; set; }
        [DataMember]
        public Int32 TipoDocumentoProv { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public String SerieFactura { get; set; }
        [DataMember]
        public String NumeroFactura { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String Moneda { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String NumDocumento { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public Decimal ImporteIngreso { get; set; }
        [DataMember]
        public Decimal ImporteEgreso { get; set; }
        [DataMember]
        public Decimal ImporteFactura  { get; set; }
        [DataMember]
        public Decimal ImporteCuarta { get; set; }
        [DataMember]
        public Decimal ImporteDetraccion { get; set; }
        [DataMember]
        public Decimal ImporteDevuelto { get; set; }
        [DataMember]
        public Decimal? ImporteDevuelto2 { get; set; }
        [DataMember]
        public String UsuarioCreacion { get; set; }
        [DataMember]
        public Int32 FlagEstado { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String Recibio { get; set; }
        [DataMember]
        public Decimal MontoEgreso { get; set; }
        [DataMember]
        public Decimal? MontoEgreso2 { get; set; }
        [DataMember]
        public Decimal ImporteAdicional { get; set; }
        [DataMember]
        public Decimal? ImporteAdicional2 { get; set; }

        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }

        [DataMember]
        public Int32 IdTipoEgreso { get; set; }
        [DataMember]
        public String DescTipoEgreso { get; set; }
        #endregion
    }
}
