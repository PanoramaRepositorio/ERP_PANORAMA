using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDis_ContratoFabricacionBE
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
        public Int32 IdCliente { get; set; }
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
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public DateTime? FechaEntrega { get; set; }
        [DataMember]
        public Int32? IdProyecto { get; set; }



        [DataMember]
        public Int32 IdDis_ContratoFabricacionDetalle { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Modelo { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Material { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }





        #endregion
    }
}
