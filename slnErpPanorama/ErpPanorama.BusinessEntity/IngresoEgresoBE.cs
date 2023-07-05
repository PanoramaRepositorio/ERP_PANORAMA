using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class IngresoEgresoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdIngresoEgreso { get; set; }
        [DataMember]
        public String NumIngresoEgreso { get; set; }
        [DataMember]
        public DateTime FecIngresoEgreso { get; set; }
        [DataMember]
        public Decimal tCambio { get; set; }
        [DataMember]
        public Int32 IdTablaTipoGestion { get; set; }
        [DataMember]
        public Int32 IdTablaElementoTipoGestion { get; set; }

        [DataMember]
        public Int32 IdTablaTipoCuentaBanco { get; set; }
        [DataMember]
        public Int32 IdTablaElementoTipoCuentaBanco { get; set; }

        [DataMember]
        public Int32 IdTablaTipoDocumento { get; set; }
        [DataMember]
        public Int32 IdTablaElementoTipoDocumento { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }

        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public string Proveedor { get; set; }

        [DataMember]
        public String NumDocumento { get; set; }

        [DataMember]
        public Int32 IdTablaLocal { get; set; }
        [DataMember]
        public Int32 IdTablaElementoLocal { get; set; }
        [DataMember]
        public string Local { get; set; }

        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public string DescBanco { get; set; }

        [DataMember]
        public Int32 IdTablaTipoCuenta { get; set; }
        [DataMember]
        public Int32 IdTablaElementoTipoCuenta { get; set; }

        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public String TipoGestion { get; set; }
        [DataMember]
        public Int32 IdTipificacion { get; set; }
        [DataMember]
        public String DescTipificacion { get; set; }
        [DataMember]
        public Int32 IdSubTipificacion { get; set; }
        [DataMember]
        public String DescSubTipificacion { get; set; }


        [DataMember]
        public Int32 IdMoneda { get; set; }

        [DataMember]
        public string Moneda { get; set; }

        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public decimal Igv { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public decimal Detraccion { get; set; }
        [DataMember]
        public Boolean Estado { get; set; }
        [DataMember]
        public string DescEstado { get; set; }
        #endregion

    }
}
