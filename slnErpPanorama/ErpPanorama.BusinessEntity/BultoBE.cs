using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class BultoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdBulto { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdSector { get; set; }
        [DataMember]
        public Int32 IdBloque { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String NumeroBulto { get; set; }
        [DataMember]
        public String Agrupacion { get; set; }
        [DataMember]
        public Int32 IdFacturaCompra { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public DateTime? FechaIngreso { get; set; }
        [DataMember]
        public DateTime? FechaSalida { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Int32? IdKardex { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public Boolean FlagTransito { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String DescBloque { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public Boolean FlagTransferencia { get; set; }
        [DataMember]
        public Int32 CantidadAnt { get; set; }

        [DataMember]
        public Boolean FlagInventario { get; set; }

        [DataMember]
        public DateTime? FechaChequeo { get; set; }
        [DataMember]
        public Int32? CantidadChequeo { get; set; }
        [DataMember]
        public Int32? IdChequeador { get; set; }
        [DataMember]
        public String DescChequeador { get; set; }
        [DataMember]
        public Decimal PorcentajeChequeo { get; set; }
        [DataMember]
        public String UsuarioSalida { get; set; }
        [DataMember]
        public DateTime? FechaRecepcion { get; set; }


        #endregion
    }
}
