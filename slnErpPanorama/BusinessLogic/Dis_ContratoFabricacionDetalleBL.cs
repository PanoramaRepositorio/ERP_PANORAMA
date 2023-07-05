using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_ContratoFabricacionDetalleBL
    {
        public List<Dis_ContratoFabricacionDetalleBE> ListaTodosActivo(int IdDis_ContratoFabricacion)
        {
            try
            {
                Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
                return Dis_ContratoFabricacionDetalle.ListaTodosActivo(IdDis_ContratoFabricacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<Dis_ContratoFabricacionDetalleBE> ListaSinFoto(int IdDis_ContratoFabricacion)
        {
            try
            {
                Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
                return Dis_ContratoFabricacionDetalle.ListaSinFoto(IdDis_ContratoFabricacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_ContratoFabricacionDetalleBE pItem)
        {
            try
            {
                Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
                Dis_ContratoFabricacionDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_ContratoFabricacionDetalleBE pItem)
        {
            try
            {
                Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
                Dis_ContratoFabricacionDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_ContratoFabricacionDetalleBE pItem)
        {
            try
            {
                Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
                Dis_ContratoFabricacionDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public Dis_ContratoFabricacionDetalleBE Selecciona(int IdProducto)
        //{
        //    try
        //    {
        //        Dis_ContratoFabricacionDetalleDL Producto = new Dis_ContratoFabricacionDetalleDL();
        //        return Producto.Selecciona(IdProducto);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public int ListaProductoPrecioBusquedaCount(int IdTienda, string pFiltro)
        //{
        //    try
        //    {
        //        Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
        //        return Dis_ContratoFabricacionDetalle.ListaProductoPrecioBusquedaCount(IdTienda, pFiltro);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<Dis_ContratoFabricacionDetalleBE> ListaProductoPrecio(int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        //{
        //    try
        //    {
        //        Dis_ContratoFabricacionDetalleDL Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleDL();
        //        return Dis_ContratoFabricacionDetalle.ListaProductoPrecio(IdTienda, pFiltro, Pagina, CantidadRegistro);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

    }
}
