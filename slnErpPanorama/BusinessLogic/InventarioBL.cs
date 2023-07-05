using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InventarioBL
    {
        public List<InventarioBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                return Inventario.ListaTodosActivo(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InventarioBE> ListaTodosActivoUsuario(int IdEmpresa, int IdTienda, int IdAlmacen, int IdPersona, DateTime Fecha)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                return Inventario.ListaTodosActivoUsuario(IdEmpresa, IdTienda, IdAlmacen, IdPersona, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InventarioBE Selecciona(int IdEmpresa, int IdInventario)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                return Inventario.Selecciona(IdEmpresa, IdInventario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InventarioBE pItem)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                Inventario.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InventarioBE pItem)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                Inventario.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InventarioBE pItem)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                Inventario.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaStockKardex(int IdEmpresa, bool StockCero, DateTime FechaDesdeBulto, DateTime FechaHastaBulto, DateTime FechaDesdeInventario, DateTime FechaHastaInventario)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                Inventario.ActualizaStockKardex(IdEmpresa, StockCero, FechaDesdeBulto, FechaHastaBulto, FechaDesdeInventario, FechaHastaInventario);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void InsertaBulto(int IdEmpresa)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                Inventario.InsertaBulto(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void InsertaAnaqueles(int IdEmpresa)
        {
            try
            {
                InventarioDL Inventario = new InventarioDL();
                Inventario.InsertaAnaqueles(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
