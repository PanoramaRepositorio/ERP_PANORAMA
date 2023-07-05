using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CuentaPorPagarBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCuentaPagar { get; set; }
        [DataMember]
        public Int32 indexcpp { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }

        [DataMember]
        public Int32 IdCentroCosto { get; set; }
        [DataMember]
        public Int32 IdAsignar { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String NumDoc { get; set; }

        [DataMember]
        public DateTime FechaDoc { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }

        [DataMember]
        public Int32 TipoDocProveedor { get; set; }

        [DataMember]
        public Int32 IdProveedor { get; set; }


        [DataMember]
        public String RucProveedor { get; set; }
        [DataMember]
        public String NombreProveedor { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }

        [DataMember]
        public Int32 IdBienServicio { get; set; }
        [DataMember]
        public String DescBienServicio { get; set; }

        [DataMember]
        public Int32 IdTipoOperacion { get; set; }

        [DataMember]
        public String DescTipoOperacion { get; set; }

        [DataMember]
        public Int32 IdSituacion { get; set; }

        [DataMember]
        public Int32 DescSituacion { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public Decimal Saldo { get; set; }

        // EDGAR 260123: AGREGAR ESTADO
        [DataMember]
        public Int32 Estado { get; set; }
        //

        [DataMember]
        public String IndiceBloque { get; set; }

        [DataMember]
        public DateTime fechaBloque { get; set; }

        [DataMember]
        public String CuentaBN { get; set; }

        [DataMember]
        public String NumeroBloque { get; set; }

        [DataMember]
        public String CuentaProv { get; set; }
        [DataMember]
        public Decimal ImporteDolares { get; set; }

        // LISTADO

        [DataMember]
        public String TipoProveedor { get; set; }
        [DataMember]
        public String Prof { get; set; }
        [DataMember]
        public String Periodo { get; set; }
        [DataMember]
        public String TipoDocumento { get; set; }
        [DataMember]
        public String AbBienServicio { get; set; }
        [DataMember]
        public String AbTipoOperacion { get; set; }
        [DataMember]
        public String AbTipoDocumento { get; set; }
        [DataMember]
        public Int32 cantbloque { get; set; }
        [DataMember]
        public String DesMoneda { get; set; }
        [DataMember]
        public String DesSituacion { get; set; }
        // LISTADO








        [DataMember]
        public Decimal MontoAbono { get; set; }

        [DataMember]
        public String UsuarioPago { get; set; }

        [DataMember]
        public String CuentaContable { get; set; }
        [DataMember]
        public Decimal TCambio { get; set; }

        #endregion
    }
}