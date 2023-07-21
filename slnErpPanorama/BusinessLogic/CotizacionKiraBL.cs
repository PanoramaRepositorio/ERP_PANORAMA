using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;

namespace ErpPanorama.BusinessLogic
{

    public class CotizacionKiraBL
    {
        private CotizacionKiraDL cotizacionKiraDL;

        public CotizacionKiraBL()
        {
            cotizacionKiraDL = new CotizacionKiraDL();
        }

        public void RegistrarCotizacionYDetalle(CotizacionKiraBE cotizacion, List<DetalleCotizacionBE> detallesCotizacion)
        {
            cotizacionKiraDL.RegistrarCotizacionYDetalle(cotizacion, detallesCotizacion);
        }

        public bool ValidarCodigoProducto(string codigoProducto)
        {
            return cotizacionKiraDL.ValidarCodigoProducto(codigoProducto);
        }
    }
}
