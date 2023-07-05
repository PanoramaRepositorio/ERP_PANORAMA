using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProveedorBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPais { get; set; }
        [DataMember]
        public String DescPais { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String DireccionTienda { get; set; }
        [DataMember]
        public String Contacto { get; set; }
        [DataMember]
        public String ContactoCredito { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Email2 { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public Int32? IdBanco { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public Int32? IdBancoDolares { get; set; }
        [DataMember]
        public String DescBancoDolares { get; set; }
        [DataMember]
        public String CuentaBancoSoles { get; set; }
        [DataMember]
        public String CuentaBancoDolares { get; set; }
        [DataMember]
        public String CCISoles { get; set; }
        [DataMember]
        public String CCIDolares { get; set; }
        [DataMember]
        public Int32 IdProveedorReferencia { get; set; }
        [DataMember]
        public Int32 DiasCredito { get; set; }
        [DataMember]
        public String BancoIntermediario { get; set; }
        [DataMember]
        public String CodigoSwiftIntermediario { get; set; }
        [DataMember]
        public String DireccionIntermediario { get; set; }
        [DataMember]
        public String BancoPagador { get; set; }
        [DataMember]
        public String CodigoSwiftPagador { get; set; }
        [DataMember]
        public String DireccionPagador { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Acuerdos { get; set; }
        [DataMember]
        public Int32 TipoPago { get; set; }
        [DataMember]
        public String DescTipoPago { get; set; }
        [DataMember]
        public Int32 DiaSemMes { get; set; }
        [DataMember]
        public String NomDiaSemMes { get; set; }
        [DataMember]
        public DateTime? FechaPago { get; set; }

        [DataMember]
        public Boolean FlagNacional { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }


        [DataMember]
        public int Procedencia { get; set; }
        [DataMember]
        public String BeneficiarioNombre { get; set; }
        [DataMember]
        public String BeneficiarioAbono { get; set; }
        [DataMember]
        public String BeneficiarioDireccion { get; set; }
        [DataMember]
        public String BeneficiarioPais { get; set; }

        [DataMember]
        public String BancoSwift { get; set; }
        [DataMember]
        public String BancoNombre { get; set; }
        [DataMember]
        public String BancoDireccion { get; set; }
        [DataMember]
        public String BancoPais { get; set; }
        [DataMember]
        public String BancoCiudad { get; set; }
        [DataMember]
        public Boolean PCredito { get; set; }
        #endregion
    }
}
