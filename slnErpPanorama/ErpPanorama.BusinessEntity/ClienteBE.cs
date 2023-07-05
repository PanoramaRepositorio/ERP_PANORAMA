using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }
        [DataMember]
        public String ApeMaterno { get; set; }
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String TipoPersona { get; set; }
        [DataMember]
        public Int32 IdSexo { get; set; }
        [DataMember]
        public String Representante { get; set; }
        [DataMember]
        public String Contacto { get; set; }
        [DataMember]
        public Int32 IdTipoDireccion { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String NumDireccion { get; set; }
        [DataMember]
        public String Urbanizacion { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String IdUbigeoDom { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String Correo { get; set; }
 
        [DataMember]
        public String OtroTelefono { get; set; }
        [DataMember]
        public String TelefonoAdicional { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String EmailFE { get; set; }
        [DataMember]
        public DateTime? FechaNac { get; set; }
        [DataMember]
        public DateTime? FechaAniv { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public Int32 IdClasificacionCliente { get; set; }
        [DataMember]
        public Int32 IdCategoria { get; set; }
        [DataMember]
        public Int32 IdUbicacionEstrategica { get; set; }
        [DataMember]
        public Int32 IdTamanoLocal { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public Int32 IdRuta { get; set; }
        [DataMember]
        public Int32 IdTipoLocal { get; set; }
        [DataMember]
        public Int32 IdCondicion { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Int32 IdAgencia { get; set; }
        [DataMember]
        public Int32 IdDestino { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Agencia { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String AbrevDomicilio { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String DescClasificacionCliente { get; set; }
        [DataMember]
        public String DescCategoria { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public String DescTamanoLocal { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public String DescTipoLocal { get; set; }
        [DataMember]
        public String DescCondicion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String DescAgencia { get; set; }
        [DataMember]
        public String DescDestino { get; set; }

        [DataMember]
        public String Telefonos { get; set; }


        [DataMember]
        public String DescTipoDireccion { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
        [DataMember]
        public Decimal LineaCredito { get; set; }
        [DataMember]
        public Int32 NumeroDias { get; set; }
        [DataMember]
        public DateTime? FechaCompra { get; set; }

        [DataMember]
        public Decimal Ninguno { get; set; }
        [DataMember]
        public Decimal Textiles { get; set; }
        [DataMember]
        public Decimal Religioso { get; set; }
        [DataMember]
        public Decimal CocinaMenaje { get; set; }
        [DataMember]
        public Decimal FloresArtificiales { get; set; }
        [DataMember]
        public Decimal SalaTerraza { get; set; }
        [DataMember]
        public Decimal Oficina { get; set; }
        [DataMember]
        public Decimal LineaInfantil { get; set; }
        [DataMember]
        public Decimal Carteras { get; set; }
        [DataMember]
        public Decimal Accesorios { get; set; }
        [DataMember]
        public Decimal Navidad { get; set; }
        [DataMember]
        public Decimal DormitorioBano { get; set; }
        [DataMember]
        public Decimal TotalLinea { get; set; }
        [DataMember]
        public Int32 LineaUnica{ get; set; }
        [DataMember]
        public Decimal TotalPreVenta { get; set; }
        [DataMember]
        public String DescLineaUnica { get; set; }

        [DataMember]
        public Boolean FlagSuspendido { get; set; }
        [DataMember]
        public Decimal TotalVenta { get; set; }
        [DataMember]
        public DateTime FechaRegistroTipoCliente { get; set; }

        [DataMember]
        public Int32 IdMotivoSituacion { get; set; }
        [DataMember]
        public String DescMotivoSituacion { get; set; }
        [DataMember]
        public Boolean FlagAsesorExterno { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 Procede { get; set; }

        [DataMember]
        public String EstadoContribuyente { get; set; }
        [DataMember]
        public String CondicionDomicilio { get; set; }

        [DataMember]
        public Int32 IdPersona { get; set; }

        [DataMember]
        public Int32 IdPerfil { get; set; }

        [DataMember]
        public Boolean FlagComercio { get; set; }
        #endregion
    }
}
