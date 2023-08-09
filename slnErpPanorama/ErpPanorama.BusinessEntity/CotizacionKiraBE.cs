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

        [DataMember]
        public int IdMoneda { get; set; }

        // Nuevas propiedades para los costos
        [DataMember]
        public decimal CostoMateriales { get; set; }

        [DataMember]
        public decimal CostoInsumos { get; set; }

        [DataMember]
        public decimal CostoAccesorios { get; set; }

        [DataMember]
        public decimal CostoManoObra { get; set; }

        [DataMember]
        public decimal CostoMovilidad { get; set; }

        [DataMember]
        public decimal CostoEquipos { get; set; }

        // Nueva propiedad para el FlagEstado
        [DataMember]
        public bool FlagEstado { get; set; }
        [DataMember]
        public string DescTablaElemento { get; set; }
        // Nuevas propiedades para el detalle
        [DataMember]
        public string DescripcionGastos { get; set; }

        [DataMember]
        public bool FlagAprobacion { get; set; }

        [DataMember]
        public bool FlagEstadoDetalle { get; set; }

        [DataMember]
        public decimal CostoDetalle { get; set; }
    }
}