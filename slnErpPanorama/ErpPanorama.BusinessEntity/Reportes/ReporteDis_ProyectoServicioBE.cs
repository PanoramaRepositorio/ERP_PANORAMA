using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDis_ProyectoServicioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDis_ProyectoServicio { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public Int32 IdAsesor { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String RutaArchivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        [DataMember]
        public String DescTipoCasa { get; set; }
        [DataMember]
        public String DescAmbiente { get; set; }
        [DataMember]
        public String Objetivos { get; set; }
        [DataMember]
        public String Iluminacion { get; set; }
        [DataMember]
        public String Acustica { get; set; }
        [DataMember]
        public String Area { get; set; }
        [DataMember]
        public Int32 IdDis_Forma { get; set; }
        [DataMember]
        public Int32 IdDis_Estilo { get; set; }
        [DataMember]
        public String DescDis_Forma { get; set; }
        [DataMember]
        public String DescDis_Estilo { get; set; }


        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
