using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TempListaPrecioDetalleBL
    {
        public List<TempListaPrecioDetalleBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdProducto)
        {
            try
            {
                TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
                return TempListaPrecioDetalle.ListaTodosActivo(IdEmpresa, IdTienda, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TempListaPrecioDetalleBE> ListaFecha(int IdTienda, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
                return TempListaPrecioDetalle.ListaFecha(IdTienda, FechaIni, FechaFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public int ListaBusquedaCount(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro)
        //{
        //    try
        //    {
        //        TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
        //        return TempListaPrecioDetalle.SeleccionaBusquedaCount(IdEmpresa, IdTienda, IdListaPrecio, pFiltro);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<TempListaPrecioDetalleBE> ListaBusqueda(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro, int Pagina, int CantidadRegistro)
        //{
        //    try
        //    {
        //        TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
        //        return TempListaPrecioDetalle.ListaBusqueda(IdEmpresa, IdTienda, IdListaPrecio, pFiltro, Pagina, CantidadRegistro);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Inserta(TempListaPrecioDetalleBE pItem)
        //{
        //    try
        //    {
        //        TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
        //        TempListaPrecioDetalle.Inserta(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Actualiza(TempListaPrecioDetalleBE pItem)
        //{
        //    try
        //    {
        //        TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
        //        TempListaPrecioDetalle.Actualiza(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Elimina(TempListaPrecioDetalleBE pItem)
        //{
        //    try
        //    {
        //        TempListaPrecioDetalleDL TempListaPrecioDetalle = new TempListaPrecioDetalleDL();
        //        TempListaPrecioDetalle.Elimina(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
    }
}
