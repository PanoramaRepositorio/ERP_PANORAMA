using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InventarioVisualBloqueBL
    {
        public List<InventarioVisualBloqueBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                InventarioVisualBloqueDL InventarioVisualBloque = new InventarioVisualBloqueDL();
                return InventarioVisualBloque.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InventarioVisualBloqueBE> ListaTodosActivoTienda(int IdTienda)
        {
            try
            {
                InventarioVisualBloqueDL InventarioVisualBloque = new InventarioVisualBloqueDL();
                return InventarioVisualBloque.ListaTodosActivoTienda(IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }
         //public InventarioVisualBloqueBE Selecciona(int IdEmpresa, int IdInventarioVisualBloque)
         //{
         //    try
         //    {
         //        InventarioVisualBloqueDL InventarioVisualBloque = new InventarioVisualBloqueDL();
         //        return InventarioVisualBloque.Selecciona(IdEmpresa, IdInventarioVisualBloque);
         //    }
         //    catch (Exception ex)
         //    { throw ex; }
         //}

         public void Inserta(InventarioVisualBloqueBE pItem)
         {
             try
             {
                 InventarioVisualBloqueDL InventarioVisualBloque = new InventarioVisualBloqueDL();
                 InventarioVisualBloque.Inserta(pItem);
             }
             catch (Exception ex)
             { throw ex; }
         }

         public void Actualiza(InventarioVisualBloqueBE pItem)
         {
             try
             {
                 InventarioVisualBloqueDL InventarioVisualBloque = new InventarioVisualBloqueDL();
                 InventarioVisualBloque.Actualiza(pItem);
             }
             catch (Exception ex)
             { throw ex; }
         }

         public void Elimina(InventarioVisualBloqueBE pItem)
         {
             try
             {
                 InventarioVisualBloqueDL InventarioVisualBloque = new InventarioVisualBloqueDL();
                 InventarioVisualBloque.Elimina(pItem);
             }
             catch (Exception ex)
             { throw ex; }
         }
    }
}
