using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ContratoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdContrato { get; set; }
        [DataMember]
        public Int32 IdTipoContrato { get; set; }
        [DataMember]
        public Int32 IdTipoTrabajador { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public Int32 IdHorario { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime? FechaVen { get; set; }
        [DataMember]
        public Int32 IdTipoRenta { get; set; }
        [DataMember]
        public Decimal Sueldo { get; set; }
        [DataMember]
        public Decimal HoraExtra { get; set; }
        [DataMember]
        public Decimal BonSueldo { get; set; }
        [DataMember]
        public Decimal Movilidad { get; set; }
        [DataMember]
        public Decimal SueldoNeto { get; set; }
        [DataMember]
        public Int32 IdClasificacionTrabajador { get; set; }
        [DataMember]
        public String RutaContrato { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Boolean Continuidad { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescTipoContrato { get; set; }
        [DataMember]
        public String DescTipoTrabajador { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public String DescHorario { get; set; }
        [DataMember]
        public String DescTipoRenta { get; set; }
        [DataMember]
        public String DescClasificacionTrabajador { get; set; }
        [DataMember]
        public Boolean FlagHoraExtra { get; set; }

        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public String NumeroCuenta { get; set; }
        [DataMember]
        public String Descanso { get; set; }
        [DataMember]
        public String SistemaPension { get; set; }

        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String UsuarioSol { get; set; }
        [DataMember]
        public String ClaveSol { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public Int32 Meses { get; set; }
        [DataMember]
        public Int32 Numero { get; set; }
        [DataMember]
        public String HorarioInicio { get; set; }
        [DataMember]
        public String HorarioFin { get; set; }

        [DataMember]
        public String UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String DescSexo { get; set; }
        

        #endregion
    }
}
