using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TempDescuentoVentaProductoBL
    {
        public List<TempDescuentoVentaProductoBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdProducto)
        {
            try
            {
                TempDescuentoVentaProductoDL TempDescuentoVentaProducto = new TempDescuentoVentaProductoDL();
                return TempDescuentoVentaProducto.ListaTodosActivo(IdEmpresa, IdTienda, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TempDescuentoVentaProductoBE> ListaFecha(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                TempDescuentoVentaProductoDL TempDescuentoVentaProducto = new TempDescuentoVentaProductoDL();
                return TempDescuentoVentaProducto.ListaFecha(IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaBusquedaCount(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro)
        {
            try
            {
                TempDescuentoVentaProductoDL TempDescuentoVentaProducto = new TempDescuentoVentaProductoDL();
                return TempDescuentoVentaProducto.SeleccionaBusquedaCount(IdEmpresa, IdTienda, IdListaPrecio, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TempDescuentoVentaProductoBE pItem)
        {
            try
            {
                TempDescuentoVentaProductoDL TempDescuentoVentaProducto = new TempDescuentoVentaProductoDL();
                TempDescuentoVentaProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TempDescuentoVentaProductoBE pItem)
        {
            try
            {
                TempDescuentoVentaProductoDL TempDescuentoVentaProducto = new TempDescuentoVentaProductoDL();
                TempDescuentoVentaProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TempDescuentoVentaProductoBE pItem)
        {
            try
            {
                TempDescuentoVentaProductoDL TempDescuentoVentaProducto = new TempDescuentoVentaProductoDL();
                TempDescuentoVentaProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
