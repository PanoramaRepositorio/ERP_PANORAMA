using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class DetalleCotizacionProductoBE
    {
        [DataMember]
        public int IdTablaElemento { get; set; }

        [DataMember]
        public int Item { get; set; }

        [DataMember]
        public string DescripcionGastos { get; set; }

        [DataMember]
        public bool FlagAprobacion { get; set; }

        [DataMember]
        public bool FlagEstado { get; set; }
        // Nueva propiedad para el costo
        [DataMember]
        public decimal Costo { get; set; }
    }
}
