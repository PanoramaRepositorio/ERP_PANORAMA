using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PreventaDetalleBL
    {
        public List<PreventaDetalleBE> ListaTodosActivo(int IdPreventa)
        {
            try
            {
                PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();
                return PreventaDetalle.ListaTodosActivo(IdPreventa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PreventaDetalleBE pItem)
        {
            try
            {
                PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();
                PreventaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PreventaDetalleBE pItem)
        {
            try
            {
                PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();
                PreventaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PreventaDetalleBE pItem)
        {
            try
            {
                PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();
                PreventaDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PreventaDetalleBE Selecciona(int IdProducto)
        {
            try
            {
                PreventaDetalleDL Producto = new PreventaDetalleDL();
                return Producto.Selecciona(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, string pFiltro)
        {
            try
            {
                PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();
                return PreventaDetalle.ListaProductoPrecioBusquedaCount(IdTienda, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PreventaDetalleBE> ListaProductoPrecio(int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();
                return PreventaDetalle.ListaProductoPrecio(IdTienda, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }

}
