using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class UbicacionProductoBL
    {
        public List<UbicacionProductoBE> ListaTodosActivo(int IdEmpresa, int IdAlmacen, int IdTienda)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                return UbicacionProducto.ListaTodosActivo(IdEmpresa, IdAlmacen, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbicacionProductoBE> ListaCodigo(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                return UbicacionProducto.ListaCodigo(IdEmpresa,IdTienda, IdAlmacen, IdProducto); ;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbicacionProductoBE> ListaUbicacion(int IdEmpresa, int IdTienda, int IdAlmacen, string DescUbicacion)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                return UbicacionProducto.ListaUbicacion(IdEmpresa,IdTienda, IdAlmacen, DescUbicacion); ;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<UbicacionProductoBE> SeleccionaBusqueda(int IdEmpresa, int IdTienda, int IdAlmacen, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                return UbicacionProducto.SeleccionaBusqueda(IdEmpresa, IdTienda, IdAlmacen, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdTienda, int IdAlmacen, string pFiltro)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                return UbicacionProducto.SeleccionaBusquedaCount(IdEmpresa, IdTienda, IdAlmacen, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(UbicacionProductoBE pItem)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                UbicacionProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(UbicacionProductoBE pItem)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                UbicacionProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(UbicacionProductoBE pItem)
        {
            try
            {
                UbicacionProductoDL UbicacionProducto = new UbicacionProductoDL();
                UbicacionProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
