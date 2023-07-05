using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteHojaInstalacionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdHojaInstalacion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DiaSemana { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTurno { get; set; }
        [DataMember]
        public String DescTurno { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public Boolean FlagReserva { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        

        #endregion
    }
}
