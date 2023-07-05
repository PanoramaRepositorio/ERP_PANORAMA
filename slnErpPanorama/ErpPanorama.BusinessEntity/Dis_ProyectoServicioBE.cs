using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Dis_ProyectoServicioBE
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
        public Int32 Piso { get; set; }
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
        public DateTime? FechaVisita { get; set; }


        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdDis_ContratoAsesoria { get; set; }
        [DataMember]
        public Int32 CantidadPago { get; set; }

        [DataMember]
        public Int32? IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public Decimal TotalPedido { get; set; }
        [DataMember]
        public DateTime? FechaPedido { get; set; }

        [DataMember]
        public Boolean FlagCerrado { get; set; }
        [DataMember]
        public Boolean FlagPlano { get; set; }
        [DataMember]
        public Boolean FlagVisita { get; set; }
        [DataMember]
        public Boolean FlagInstalaTermina { get; set; }
        [DataMember]
        public Boolean FlagEncuestaPostVenta { get; set; }
        [DataMember]
        public Boolean FlagConforme { get; set; }

        [DataMember]
        public decimal PagoAsesoria { get; set; }

        [DataMember]
        public int IdMotivo { get; set; }
        [DataMember]
        public string Motivo { get; set; }

        #endregion
    }
}
