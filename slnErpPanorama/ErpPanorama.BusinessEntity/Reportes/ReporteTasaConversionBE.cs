using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReporteTasaConversionBE
    {
        #region "Atributos"
        [DataMember]
        public String DiaSemana { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public Decimal VisUcayali { get; set; }
        [DataMember]
        public Decimal VisAndahuaylas { get; set; }
        [DataMember]
        public Decimal VisPrescott { get; set; }
        [DataMember]
        public Decimal VisAviacion { get; set; }
        [DataMember]
        public Decimal VisAviacion2 { get; set; }
        [DataMember]
        public Decimal VisSanMiguel { get; set; }
        [DataMember]
        public Decimal VisMegaplaza { get; set; }

        [DataMember]
        public Decimal TraUcayali { get; set; }
        [DataMember]
        public Decimal TraAndahuaylas { get; set; }
        [DataMember]
        public Decimal TraPrescott { get; set; }
        [DataMember]
        public Decimal TraAviacion { get; set; }
        [DataMember]
        public Decimal TraAviacion2 { get; set; }
        [DataMember]
        public Decimal TraMegaplaza { get; set; }
        [DataMember]
        public Decimal TraSanMiguel { get; set; }

        [DataMember]
        public Decimal TasUcayali { get; set; }
        [DataMember]
        public Decimal TasAndahuaylas { get; set; }
        [DataMember]
        public Decimal TasPrescott { get; set; }
        [DataMember]
        public Decimal TasAviacion { get; set; }
        [DataMember]
        public Decimal TasAviacion2 { get; set; }
        [DataMember]
        public Decimal TasMegaplaza { get; set; }
        [DataMember]
        public Decimal TasSanMiguel { get; set; }

        [DataMember]
        public Decimal TotUcayali { get; set; }
        [DataMember]
        public Decimal TotAndahuaylas { get; set; }
        [DataMember]
        public Decimal TotPrescott { get; set; }
        [DataMember]
        public Decimal TotAviacion { get; set; }
        [DataMember]
        public Decimal TotAviacion2 { get; set; }
        [DataMember]
        public Decimal TotMegaplaza { get; set; }
        [DataMember]
        public Decimal TotSanMiguel { get; set; }

        [DataMember]
        public Decimal ProUcayali { get; set; }
        [DataMember]
        public Decimal ProAndahuaylas { get; set; }
        [DataMember]
        public Decimal ProPrescott { get; set; }
        [DataMember]
        public Decimal ProAviacion { get; set; }
        [DataMember]
        public Decimal ProAviacion2 { get; set; }
        [DataMember]
        public Decimal ProMegaplaza { get; set; }
        [DataMember]
        public Decimal ProSanMiguel { get; set; }


        #endregion
    }
}
