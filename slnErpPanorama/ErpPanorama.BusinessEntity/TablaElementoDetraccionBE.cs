using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    public class TablaElementoDetraccionBE
    {
        public Int32 IdEmpresa { get; set; }
        public Int32 IdTablaElemento { get; set; }
        public Int32 IdTabla { get; set; }
        public String DescTabla { get; set; }
        public String Abreviatura { get; set; }
        public String DescTablaElemento { get; set; }
        public Decimal Valor { get; set; }
        public Boolean FlagEstado { get; set; }
    }
}
