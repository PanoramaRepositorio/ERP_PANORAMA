using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;

namespace ErpPanorama.BusinessLogic
{
    public class ComboTipoCotizacionBL
    {
        public List<ComboTipoCotizacionBE> ObtenerComboTipoCotizacion()
        {
            ComboTipoCotizacionDL comboTipoCotizacionDL = new ComboTipoCotizacionDL();
            return comboTipoCotizacionDL.ObtenerComboTipoCotizacion();
        }
    }
}
