using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{

    [DataContract]
    public class CotizacionKiraBE
    {
        [DataMember]
        public int IdCotizacion { get; set; }

        [DataMember]
        public int IdTablaElemento { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string CodigoProducto { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Caracteristicas { get; set; }

        [DataMember]
        public string Imagen { get; set; }

        [DataMember]
        public decimal TotalGastos { get; set; }

        [DataMember]
        public decimal PrecioVenta { get; set; }
    }
}
