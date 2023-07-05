using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CheckinoutBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCheckinout { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Tipo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Boolean flagManual { get; set; }
        [DataMember]
        public DateTimeOffset FechaHora { get; set; }

        [DataMember]
        public String Ingreso { get; set; }
        [DataMember]
        public String SalidaRefrigerio { get; set; }
        [DataMember]
        public String IngresoRefrigerio { get; set; }
        [DataMember]
        public String Salida { get; set; }
        [DataMember]
        public Int32 Horas { get; set; }
        [DataMember]
        public Int32 Minutos { get; set; }
        [DataMember]
        public Int32 Refrigerio { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public Int32 Tardanza { get; set; }
        [DataMember]
        public Int32 HoraExtra { get; set; }
        [DataMember]
        public String HorarioIngreso { get; set; }
        [DataMember]
        public String HorarioSalida { get; set; }
        [DataMember]
        public Int32 Updates { get; set; }
        [DataMember]
        public String UsuarioModifica { get; set; }
        [DataMember]
        public String Descanso { get; set; }
        [DataMember]
        public Boolean FlagApoyo { get; set; }

        [DataMember]
        public Decimal Descuento { get; set; }

        [DataMember]
        public Decimal Sueldo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }



        #endregion
    }
}
