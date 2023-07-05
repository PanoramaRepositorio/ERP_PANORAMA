using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PlanillaDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPlanillaDetalle { get; set; }
        [DataMember]
        public Int32 IdPlanilla { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Decimal SueldoBruto { get; set; }
        [DataMember]
        public Int32 HorasLaboradas { get; set; }
        [DataMember]
        public Decimal HorasExtras25 { get; set; }
        [DataMember]
        public Decimal RemuneracionBasica { get; set; }
        [DataMember]
        public Decimal HorasExtras250105 { get; set; }
        [DataMember]
        public Decimal AsignacionFamiliar { get; set; }
        [DataMember]
        public Decimal RemuneracionVacacional { get; set; }
        [DataMember]
        public Decimal RemuneracionTrunca { get; set; }
        [DataMember]
        public Decimal BonificacionEspecial0306 { get; set; }
        [DataMember]
        public Decimal IngresosComisiones { get; set; }
        [DataMember]
        public Decimal BonificacionExtraordinaria { get; set; }
        [DataMember]
        public Decimal Movilidad { get; set; }
        [DataMember]
        public Decimal Gratificaciones { get; set; }
        [DataMember]
        public Decimal BonificacionEspecial { get; set; }
        [DataMember]
        public Decimal RepartoUtilidad { get; set; }
        [DataMember]
        public Decimal Cts { get; set; }
        [DataMember]
        public Decimal TotalRemuneraciones { get; set; }
        [DataMember]
        public Decimal FaltasTardanzas { get; set; }
        [DataMember]
        public Int32 IdPlaAfp { get; set; }
        [DataMember]
        public Decimal Onp { get; set; }
        [DataMember]
        public Decimal FondoPensiones { get; set; }
        [DataMember]
        public Decimal PrimaSeguros { get; set; }
        [DataMember]
        public Decimal ComisionAFP { get; set; }
        [DataMember]
        public Decimal Pacifico { get; set; }
        [DataMember]
        public Decimal Retencion5Categoria { get; set; }
        [DataMember]
        public Decimal TotalDescuento { get; set; }
        [DataMember]
        public Decimal NetoPagar { get; set; }
        [DataMember]
        public Decimal Aportacion75 { get; set; }
        [DataMember]
        public Decimal Aportacion25 { get; set; }
        [DataMember]
        public Decimal Aportacion9 { get; set; }
        [DataMember]
        public Decimal AporteEps { get; set; }
        [DataMember]
        public Int32 DiasNoLaboradoVacaciones { get; set; }
        [DataMember]
        public Int32 DiasNoLaboradoJustificados { get; set; }
        [DataMember]
        public Int32 DiasNoLaboradoFaltas { get; set; }
        [DataMember]
        public Int32 DiasNoLaboradoDm { get; set; }
        [DataMember]
        public Int32 TotalDias { get; set; }
        [DataMember]
        public DateTime? FechaCese { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
