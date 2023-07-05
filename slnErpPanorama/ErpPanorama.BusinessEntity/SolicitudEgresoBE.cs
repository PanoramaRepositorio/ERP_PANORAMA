using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudEgresoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdSolicitudEgreso { get; set; }
        [DataMember]
        public String NumSolicitudEgreso { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public DateTime FechaSolicitudEgreso { get; set; }
        [DataMember]
        public String DescSolicitudEgreso { get; set; }

        [DataMember]
        public DateTime FechaAPagar { get; set; }
        [DataMember]
        public DateTime? FechaDeposito { get; set; }

        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public Int32? IdMoneda { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }

        [DataMember]
        public String NumOCompra { get; set; }

        [DataMember]
        public String NroAbonos { get; set; }

        [DataMember]
        public String TipoEgreso { get; set; }

        [DataMember]
        public String Tienda { get; set; }


        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Recibo { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String RucProveedor { get; set; }

        [DataMember]
        public String DescBanco { get; set; }

        [DataMember]
        public String Cuenta { get; set; }

        [DataMember]
        public String CCI { get; set; }

        [DataMember]
        public String Moneda { get; set; }

        [DataMember]
        public String Solicita { get; set; }

        [DataMember]
        public Int32? NroAbonoInicio { get; set; }
        [DataMember]
        public Int32 NroAbonoFin { get; set; }
        [DataMember]
        public Int32 IdTipoEgreso { get; set; }

        [DataMember]
        public Int32 IdTienda { get; set; }

        [DataMember]
        public Int32 IdCliente { get; set; }

        [DataMember]
        public String RazonSocialFactura { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        


        [DataMember]
        public String CentroCosto { get; set; }
        [DataMember]
        public String Asignar { get; set; }
        [DataMember]
        public Int32 IdCentroCosto { get; set; }
        [DataMember]
        public Int32 IdDetalleCentroCosto { get; set; }

        [DataMember]
        public String Obs { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String Situacion { get; set; }

        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Correo { get; set; }

        [DataMember]
        public Decimal Panorama { get; set; }
        [DataMember]
        public Decimal Decoratex { get; set; }
        [DataMember]
        public Decimal PanoramaD { get; set; }
        [DataMember]
        public Decimal DecoratexD { get; set; }

        [DataMember]
        public Decimal MontoAbono { get; set; }

        [DataMember]
        public String UsuarioPago { get; set; }

        [DataMember]
        public String CuentaContable { get; set; }
        [DataMember]
        public Decimal TCambio { get; set; }

        [DataMember]
        public Int32 Procedencia { get; set; }

        [DataMember]
        public String DescProcedencia { get; set; }

        [DataMember]
        public String NombreCaja { get; set; }
        [DataMember]
        public String TipoDocumento { get; set; }
        #endregion
    }
}