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

        public void RegistrarCotizacionYDetalleProductos(CotizacionKiraProductoTerminadoBE cotizacion, List<DetalleCotizacionProductoBE> detallesCotizacion, out int idCotizacion)
        {
            cotizacionKiraDL.RegistrarCotizacionYDetalleProducto(cotizacion, detallesCotizacion, out idCotizacion);
        }

        public bool ValidarCodigoProducto(string codigoProducto)
        {
            return cotizacionKiraDL.ValidarCodigoProducto(codigoProducto);
        }

        public bool ValidarCodigoProductoproducto(string codigoProducto)
        {
            return cotizacionKiraDL.ValidarCodigoProductoproducto(codigoProducto);
        }

        public void EliminarCotizacionPorCodigoProducto(string codigoProducto)
        {
            cotizacionKiraDL.EliminarCotizacionPorCodigoProducto(codigoProducto);
        }

        public void EliminarCotizacionProductoPorCodigoProducto(string codigoProducto)
        {
            cotizacionKiraDL.EliminarCotizacionProductoPorCodigoProducto(codigoProducto);
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

        public List<CotizacionKiraProductoTerminadoBE> FiltrarCotizacionesPorPeriodoYNumeroproducto(int periodo, int numeroCotizacion)
        {
            return cotizacionKiraDL.FiltrarCotizacionesPorPeriodoYNumeroproducto(periodo, numeroCotizacion);
        }

        public bool ExisteCodigoProductoDuplicado(int idCotizacion, string nuevoCodigoProducto)
        {
            // Verifica si existe otro registro con el mismo CodigoProducto excepto el registro actual
            return cotizacionKiraDL.ExisteCodigoProductoDuplicado(idCotizacion, nuevoCodigoProducto);
        }

        // Método para actualizar una cotización
        public void ActualizarCotizacion(CotizacionKiraBE cotizacion)
        {
            cotizacionKiraDL.ActualizarCotizacion(cotizacion);
        }

        public void ActualizarCotizacionDetalle(CotizacionKiraBE cotizacion)
        {
            cotizacionKiraDL.ActualizarCotizacion(cotizacion);
        }

        public void ActualizarCotizacionProductos(CotizacionKiraProductoTerminadoBE cotizacion)
        {
            cotizacionKiraDL.ActualizarCotizacionProductos(cotizacion);
        }


        public List<DetalleCotizacionBE> ObtenerDetallesCotizacionPorId(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerDetallesCotizacionPorId(idCotizacion);
        }

        public CotizacionKiraBE ObtenerCotizacionPorId(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionPorId(idCotizacion);
        }

        public List<CotizacionKiraBE> ObtenerCotizacionPorId2(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionPorId2(idCotizacion);
        }
        public CotizacionKiraProductoTerminadoBE ObtenerCotizacionProductoPorId(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionProductoPorId(idCotizacion);
        }


        public List<CotizacionKiraProductoTerminadoBE> ObtenerCotizacionproductoPorId2(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionProductoPorId2(idCotizacion);
        }
        public List<DetalleCotizacionBE> ObtenerDetelaleCotizacionMateriales(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleMaterialesPorid(idCotizacion);
        }

        public List<DetalleCotizacionProductoBE> ObtenerDetelaleCotizacionCostoProducto(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleCostoProductoPorid(idCotizacion);
        }

        public List<DetalleCotizacionBE> ObtenerDetelaleCotizacionInsumos(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleInsumosPorid(idCotizacion);
        }

        public List<DetalleCotizacionBE> ObtenerDetelaleCotizacionAccesorios(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleAccesoriosPorid(idCotizacion);
        }

        public List<DetalleCotizacionBE> ObtenerDetelaleCotizacionManoObra(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleManoObraPorid(idCotizacion);
        }

        public List<DetalleCotizacionBE> ObtenerDetelaleCotizacionMovilidad(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleMovilidadid(idCotizacion);
        }

        public List<DetalleCotizacionBE> ObtenerDetelaleEquipos(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerCotizacionDetalleEquiposid(idCotizacion);
        }

        public void ActualizarDetalleCotizacion(List<DetalleCotizacionBE> detallesCotizacion)
        {
            try
            {
                cotizacionKiraDL.ActualizarDetalleCotizacion(detallesCotizacion);
            }
            catch (Exception ex)
            {
                // Manejar el error o propagarlo si es necesario
                throw ex;
            }
        }

        public void ActualizarDetalleCotizacionProducto(List<DetalleCotizacionProductoBE> detallesCotizacion)
        {
            try
            {
                cotizacionKiraDL.ActualizarDetalleCotizacionProducto(detallesCotizacion);
            }
            catch (Exception ex)
            {
                // Manejar el error o propagarlo si es necesario
                throw ex;
            }
        }


        public void AgregarDetalleCotizacion(int idCotizacion, int idTablaElemento, string descripcionGastos, decimal costo)
        {
            cotizacionKiraDL.AgregarDetalleCotizacion(idCotizacion, idTablaElemento, descripcionGastos, costo);
        }

        public void AgregarDetalleCotizacionProducto(int idCotizacion, int idTablaElemento, string descripcionGastos, decimal costo)
        {
            cotizacionKiraDL.AgregarDetalleCotizacionProducto(idCotizacion, idTablaElemento, descripcionGastos, costo);
        }

        public void EliminarDetalleCotizacion(int idCotizacionDetalle)
        {
            cotizacionKiraDL.EliminarDetalleCotizacion(idCotizacionDetalle);
        }

        public void EliminarDetalleCotizacionProducto(int idCotizacionDetalle)
        {
            cotizacionKiraDL.EliminarDetalleCotizacionProducto(idCotizacionDetalle);
        }

        public DetalleCotizacionBE ObtenerUltimoDetalleCotizacion(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerUltimoDetalleCotizacion(idCotizacion);
        }

        public DetalleCotizacionProductoBE ObtenerUltimoDetalleCotizacionProducto(int idCotizacion)
        {
            return cotizacionKiraDL.ObtenerUltimoDetalleCotizacionProducto(idCotizacion);
        }

        public List<CotizacionKiraBE> Listado(int IdCotizacion)
        {
            try
            {
                CotizacionKiraDL reporteCotizacion = new CotizacionKiraDL();
                return reporteCotizacion.Listado(IdCotizacion);

            }
            catch (Exception ex)
            { throw ex; }
        }

        //public List<CotizacionKiraBE> ListadoAll()
        //{
        //    try
        //    {
        //        CotizacionKiraDL reporteCotizacion = new CotizacionKiraDL();
        //        return reporteCotizacion.Listadoall();

        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public List<CotizacionKiraBE> ListadoAll(List<int> idCotizaciones)
{
    try
    {
        CotizacionKiraDL reporteCotizacion = new CotizacionKiraDL();
        return reporteCotizacion.Listadoall(idCotizaciones);
    }
    catch (Exception ex)
    {
        // Manejo de excepciones
        throw ex;
    }
}


        public List<CotizacionKiraProductoTerminadoBE> ListadoProducto(int IdCotizacion)
        {
            try
            {
                CotizacionKiraDL reporteCotizacion = new CotizacionKiraDL();
                return reporteCotizacion.ListadoProducto(IdCotizacion);

            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
