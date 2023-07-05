using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDis_ProyectoServicioContratoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public String DniAsesor { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }


        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String RutaArchivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public DateTime FechaVisita { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Titulo { get; set; }
        [DataMember]
        public String CuerpoSustantivo { get; set; }
        [DataMember]
        public String Procedimiento { get; set; }
        [DataMember]
        public String PlazoCosto { get; set; }
        [DataMember]
        public String Publicidad { get; set; }
        [DataMember]
        public String Version { get; set; }

        [DataMember]
        public String DescAmbiente { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        //[DataMember]
        //public Boolean FlagEstado { get; set; }
        
                    [DataMember]
        public Decimal PagoAsesoria { get; set; }

        #endregion
    }
}
