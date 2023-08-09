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

        public void RegistrarCotizacionYDetalle(CotizacionKiraBE cotizacion, List<DetalleCotizacionBE> detallesCotizacion, out int idCotizacion)
        {
            cotizacionKiraDL.RegistrarCotizacionYDetalle(cotizacion, detallesCotizacion, out idCotizacion);
        }

        public bool ValidarCodigoProducto(string codigoProducto)
        {
            return cotizacionKiraDL.ValidarCodigoProducto(codigoProducto);
        }

        public void EliminarCotizacionPorCodigoProducto(string codigoProducto)
        {
            cotizacionKiraDL.EliminarCotizacionPorCodigoProducto(codigoProducto);
        }

        public int ObtenerSiguienteNumeroCotizacion()
        {
            return cotizacionKiraDL.ObtenerSiguienteNumeroCotizacion();
        }

        public int ObtenerSiguienteNumeroCotizacionProductoTerminado()
        {
            return cotizacionKiraDL.ObtenerSiguienteNumeroCotizacionProductoTerminado();
        }


        public void ActualizarCotizacionPorId(int idCotizacion, string nuevoCodigoProducto, string nuevaDescripcion)
        {
            cotizacionKiraDL.ActualizarCotizacionPorId(idCotizacion, nuevoCodigoProducto, nuevaDescripcion);
        }



        // En CotizacionKiraBL
        public bool ExisteCodigoProducto(string nuevoCodigoProducto)
        {
            return cotizacionKiraDL.ExisteCodigoProducto(nuevoCodigoProducto);
        }

        public List<CotizacionKiraBE> FiltrarCotizacionesPorPeriodoYNumero(int periodo, int numeroCotizacion)
        {
            return cotizacionKiraDL.FiltrarCotizacionesPorPeriodoYNumero(periodo, numeroCotizacion);
        }

        public bool ExisteCodigoProductoDuplicado(int idCotizacion, string nuevoCodigoProducto)
        {
            // Verifica si existe otro registro con el mismo CodigoProducto excepto el registro actual
            return cotizacionKiraDL.ExisteCodigoProductoDuplicado(idCotizacion, nuevoCodigoProducto);
        }




    }
}
