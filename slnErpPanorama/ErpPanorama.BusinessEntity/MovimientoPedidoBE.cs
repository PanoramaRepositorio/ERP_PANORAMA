using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class MovimientoPedidoBE
    {
        #region "Atributos"


        [DataMember]
        public Int32 IdMovimientoPedido { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public Int32 IdSituacionAlmacen { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String Estado { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String Departamento { get; set; }
        [DataMember]
        public String Provincia { get; set; }
        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public String DuracionPicking { get; set; }
        [DataMember]
        public String DuracionChequeo { get; set; }
        [DataMember]
        public String DuracionEmbalado { get; set; }


        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String FormaPago { get; set; }
        [DataMember]
        public String Destino { get; set; }
        [DataMember]
        public Boolean Aprobado { get; set; }
        [DataMember]
        public DateTimeOffset? FechaAprobado { get; set; }
        [DataMember]
        public Boolean Recibido { get; set; }
        [DataMember]
        public DateTimeOffset? FechaRecibido { get; set; }

        [DataMember]
        public String HoraRecepcion { get; set; }


        [DataMember]
        public Boolean Preparacion { get; set; }
        [DataMember]
        public DateTimeOffset? FechaPreparacion { get; set; }
        [DataMember]
        public Boolean Preparado { get; set; }
        [DataMember]
        public DateTimeOffset? FechaPreparado { get; set; }

        [DataMember]
        public Boolean Chequeo { get; set; }
        [DataMember]
        public DateTimeOffset? FechaChequeo { get; set; }
        [DataMember]
        public Boolean Chequeado { get; set; }
        [DataMember]
        public DateTimeOffset? FechaChequeado { get; set; }
        [DataMember]
        public Boolean EnPT { get; set; }
        [DataMember]
        public DateTimeOffset? FechaPT { get; set; }
        [DataMember]
        public Boolean Embalado { get; set; }
        [DataMember]
        public DateTimeOffset? FechaEmbalado { get; set; }
        [DataMember]
        public Boolean RecepcionDocumento { get; set; }
        [DataMember]
        public DateTimeOffset? FechaRD { get; set; }
        [DataMember]
        public Boolean Despachado { get; set; }
        [DataMember]
        public DateTimeOffset? FechaDespachado { get; set; }

        [DataMember]
        public String Despachador { get; set; }

        [DataMember]
        public DateTimeOffset? FechaAnulado { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Conductor { get; set; }
        [DataMember]
        public Int32 IdAuxiliar { get; set; }
        [DataMember]
        public Int32 IdEmbalador { get; set; }
        [DataMember]
        public Int32 IdDespachador { get; set; }
        [DataMember]
        public Int32 IdChequeador { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal CostoDelivery { get; set; }
        [DataMember]
        public Decimal TotalPeso { get; set; }

        [DataMember]
        public Int32 IdAgencia { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String IdUbigeoDelivery { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public Decimal PesoKg { get; set; }
        [DataMember]
        public Int32 IdPrioridad { get; set; }
        [DataMember]
        public Int32 IdDestino { get; set; }
        [DataMember]
        public Int32 IdPagoFlete { get; set; }
        [DataMember]
        public String NumeroDespacho { get; set; }
        [DataMember]
        public DateTime? FechaDespacho2 { get; set; }
        [DataMember]
        public Int32 NumeroPiso { get; set; }
        [DataMember]
        public String Observacion2 { get; set; }
        [DataMember]
        public String DescAgencia { get; set; }
        [DataMember]
        public String DescPrioridad { get; set; }
        [DataMember]
        public String DescDestino { get; set; }
        [DataMember]
        public String DescPagoFlete { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String ClaveEnvio { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }


        [DataMember]
        public String DescChequeador { get; set; }
        [DataMember]
        public String DescAuxiliar { get; set; }
        [DataMember]
        public String DescEmbalador { get; set; }
        [DataMember]
        public Boolean FlagCierre { get; set; }
        [DataMember]
        public DateTimeOffset FechaHoraServidor { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public Int32 CantidadPedido { get; set; }
        [DataMember]
        public String Disponible { get; set; }
        [DataMember]
        public String DescPersonaAprueba { get; set; }
        [DataMember]
        public Int32 Origen { get; set; }
        [DataMember]
        public Int32 IdPersonaCredito { get; set; }
        [DataMember]
        public Int32 IdConductor { get; set; }
        [DataMember]
        public Int32 IdCopiloto { get; set; }
        [DataMember]
        public String DescCopiloto { get; set; }
        [DataMember]
        public String OrigenDespacho { get; set; }
        [DataMember]
        public String Despachar { get; set; }

        [DataMember]
        public Boolean CambioFechaDelivery { get; set; }
        [DataMember]
        public String UsuarioCambioFecha { get; set; }
        [DataMember]
        public DateTimeOffset? FechaRegistroFacturacion { get; set; }

        [DataMember]
        public String Equipo { get; set; }

        [DataMember]
        public String Rucp { get; set; }
        [DataMember]
        public String RazonSocialP { get; set; }
        [DataMember]
        public String EstadoContribuyentep { get; set; }
        [DataMember]
        public String CondicionDomiciliop { get; set; }
        [DataMember]
        public Int32 IdVehiculo { get; set; }
        [DataMember]
        public String Placa { get; set; }
        //  Insertados 
        [DataMember]
        public Boolean FlagIniCalidad { get; set; }
        [DataMember]
        public DateTimeOffset? FechaIniCalidad { get; set; }
        [DataMember]
        public Boolean FlagFinCalidad { get; set; }
        [DataMember]
        public DateTimeOffset? FechaFinCalidad { get; set; }

        // Actualizado

        [DataMember]
        public Int32 IdPersonaCalidad { get; set; }
        [DataMember]
        public String DescPersonaCalidad { get; set; }
        [DataMember]
        public String DuracionCalidad { get; set; }
        [DataMember]
        public String CanalVenta { get; set; }
        [DataMember]
        public String MedioEntrega { get; set; }
        [DataMember]
        public String TiempoActividad { get; set; }
        [DataMember]
        public String TiempoEntrega { get; set; }

        [DataMember]
        public String PersonaRecoge { get; set; }

        #endregion
    }
}
