using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDis_ProyectoServicioContratoFabricacionBE
    {
        #region "Atributos"


        [DataMember]
        public Int32 IdDis_ContratoFabricacion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String DniVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public DateTime FechaEntrega { get; set; }
        [DataMember]
        public String NumeroProyecto { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Ruc { get; set; }


        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String Modelo { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Material { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public byte[] Imagen { get; set; }
        [DataMember]
        public Boolean FlagModificado { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Tienda { get; set; }

        #endregion
    }
}
