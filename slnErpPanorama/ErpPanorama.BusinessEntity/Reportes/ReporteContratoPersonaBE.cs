using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteContratoPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public String DescTipoContrato { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Titulo { get; set; }
        [DataMember]
        public String Cuerpo { get; set; }
        [DataMember]
        public String Firma { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String NombreGerente { get; set; }
        [DataMember]
        public String DniGerente { get; set; }
        [DataMember]
        public String DireccionEmpresa { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public Decimal Sueldo { get; set; }
        [DataMember]
        public Decimal HoraExtra { get; set; }
        [DataMember]
        public Decimal BonSueldo { get; set; }
        
        [DataMember]
        public Decimal SueldoNeto { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public Int32 Meses { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime FechaVen { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String Horario { get; set; }

        [DataMember]
        public String Discapacidad { get; set; }
        [DataMember]
        public String SituacionEspecial { get; set; }
        [DataMember]
        public String ClasificacionPuesto { get; set; }
        [DataMember]
        public String EstadoCivil { get; set; }

        [DataMember]
        public String FechaContratoIni { get; set; }
        [DataMember]
        public String FechaContratoFin { get; set; }
        #endregion
    }
}
