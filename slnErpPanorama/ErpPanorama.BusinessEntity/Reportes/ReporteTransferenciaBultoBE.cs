using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTransferenciaBultoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTransferenciaBulto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime FechaMovimiento { get; set; }
        [DataMember]
        public Int32 IdAlmacenOrigen { get; set; }
        [DataMember]
        public String AlmacenOrigen { get; set; }
        [DataMember]
        public Int32 IdAlmacenDestino { get; set; }
        [DataMember]
        public String AlmacenDestino { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdMovimientoAlmacenIngreso { get; set; }
        [DataMember]
        public String NumeroDocumentoIngreso { get; set; }
        [DataMember]
        public Int32 IdMovimientoAlmacenSalida { get; set; }
        [DataMember]
        public String NumeroDocumentoSalida { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdBulto { get; set; }
        [DataMember]
        public String NumeroBulto { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        #endregion
    }
}
