using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class KardexBL
    {
        public List<KardexBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaTodosActivo(IdEmpresa, IdTienda, IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> ListaTransito(int IdEmpresa, int IdTienda, int IdAlmacen, int IdProducto)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaTransito(IdEmpresa, IdTienda, IdAlmacen, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> Selecciona(int IdEmpresa, int IdKardex)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.Selecciona(IdEmpresa, IdKardex);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> ListaInventario(int IdEmpresa, int IdAlmacen, int IdProducto, int Almacen2, DateTime Fecha)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaInventario(IdEmpresa, IdAlmacen, IdProducto, Almacen2, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> ListaInventarioDetalle(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaInventarioDetalle(IdEmpresa,IdAlmacen, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<KardexBE> ListaInventarioDetalle20(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                return Kardex.ListaInventarioDetalle20(IdEmpresa, IdAlmacen, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(KardexBE pItem)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                Kardex.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(KardexBE pItem)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                Kardex.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(KardexBE pItem)
        {
            try
            {
                KardexDL Kardex = new KardexDL();
                Kardex.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}


