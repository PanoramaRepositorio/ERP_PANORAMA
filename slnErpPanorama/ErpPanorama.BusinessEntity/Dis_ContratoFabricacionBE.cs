using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Dis_ContratoFabricacionBE
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
        public Int32? IdVendedor2 { get; set; }
        [DataMember]
        public String DescVendedor2 { get; set; }
        [DataMember]
        public DateTime? FechaEntrega { get; set; }
        [DataMember]
        public DateTime? FechaProduccion { get; set; }
        [DataMember]
        public Int32? IdProyecto { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String NumeroProyecto { get; set; }

        [DataMember]
        public Int32 Piso { get; set; }
        [DataMember]
        public String RutaArchivo { get; set; }

        [DataMember]
        public Boolean FlagCerrado { get; set; }


        [DataMember]
        public DateTime? FechaProyecto { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        [DataMember]
        public DateTime? FechaVisita { get; set; }
        [DataMember]
        public DateTime? FechaContrato { get; set; }
        [DataMember]
        public DateTime? FechaAprueba { get; set; }
        [DataMember]
        public DateTime? FechaPresupuesto { get; set; }
        [DataMember]
        public DateTime? FechaApPresupuesto { get; set; }
        [DataMember]
        public DateTime? FechaFabricacion { get; set; }

        [DataMember]
        public Decimal PorcentajeAvance { get; set; }
        [DataMember]
        public DateTime? FechaCotizacion { get; set; }
        [DataMember]
        public DateTime? FechaPrimerAbono { get; set; }
        [DataMember]
        public DateTime? FechaAtencion { get; set; }
        

        [DataMember]
        public String EncuestaFinal { get; set; }
        [DataMember]
        public String EncuestaVisita { get; set; }
        [DataMember]
        public String NumeroContrato { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String UsuarioAtencion { get; set; }
        [DataMember]
        public String Distrito { get; set; }
        [DataMember]
        public Decimal TotalPedido { get; set; }
        [DataMember]
        public Decimal TotalContrato { get; set; }
        [DataMember]
        public DateTime? FechaPedido { get; set; }

        [DataMember]
        public Boolean FlagInstalaTermina { get; set; }
        [DataMember]
        public Boolean FlagEncuestaPostVenta { get; set; }
        [DataMember]
        public Boolean FlagConforme { get; set; }
        [DataMember]
        public Boolean FlagEncuestaCerrada { get; set; }
        #endregion
    }
}

