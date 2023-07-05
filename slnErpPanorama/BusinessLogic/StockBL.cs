using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class StockBL
    {
        public List<StockBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaTodosActivo(IdEmpresa, IdTienda, IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProducto(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProducto(IdEmpresa, IdTienda, IdAlmacen, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProductoTienda(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            try
            {
                StockDL Stock = new StockDL();

                return Stock.ListaProductoTienda(IdEmpresa, IdTienda, IdAlmacen, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProductoTiendaVenta(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, int IdFormaPago, int IdAlmacenPrincipal)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoTiendaVenta(IdEmpresa, IdTienda, IdAlmacen, IdProducto, IdFormaPago, IdAlmacenPrincipal);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<StockBE> ListaProductoTiendaAutoservicio(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, int IdFormaPago)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoTiendaAutoservicio(IdEmpresa, IdTienda, IdAlmacen, IdProducto, IdFormaPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProductoTransito(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoTransito(IdEmpresa, IdTienda, IdAlmacen, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProductoTransitov2(int IdEmpresa, int IdProducto)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoTransitoV2(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<StockBE> ListaProductoTransitoDetallev2(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoTransitoDetalleV2(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<StockBE> ListaProductoTransitoDetalle(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoTransitoDetalle(IdEmpresa, IdTienda, IdAlmacen, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, int IdAlmacen, string pFiltro)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoPrecioBusquedaCount(IdTienda, IdAlmacen, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProductoPrecio(int IdTienda, int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoPrecio(IdTienda, IdAlmacen, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaProductoCostoBusquedaCount(int IdAlmacen, string pFiltro)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoCostoBusquedaCount(IdAlmacen, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBE> ListaProductoCosto(int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.ListaProductoCosto(IdAlmacen, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StockBE SeleccionaProductoPrecio(int IdTienda, int IdAlmacen, string CodigoProveedor)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.SeleccionaProductoPrecio(IdTienda, IdAlmacen, CodigoProveedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StockBE SeleccionaIdProductoPrecio(int IdTienda, int IdAlmacen, int IdProducto)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.SeleccionaIdProductoPrecio(IdTienda, IdAlmacen, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StockBE SeleccionaProductoCodigoBarra(int IdTienda, int IdAlmacen, string CodigoBarra)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.SeleccionaProductoCodigoBarra(IdTienda, IdAlmacen, CodigoBarra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public StockBE SeleccionaCantidadIdProducto(int IdTienda, int IdAlmacen, int IdProducto)
        {
            try
            {
                StockDL Stock = new StockDL();
                return Stock.SeleccionaCantidadIdProducto(IdTienda, IdAlmacen, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(StockBE pItem)
        {
            try
            {
                StockDL Stock = new StockDL();
                Stock.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(StockBE pItem)
        {
            try
            {
                StockDL Stock = new StockDL();
                Stock.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(StockBE pItem)
        {
            try
            {
                StockDL Stock = new StockDL();
                Stock.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

