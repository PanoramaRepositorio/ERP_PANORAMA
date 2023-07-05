using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InventarioVisualModuloBL
    {
        public List<InventarioVisualModuloBE> ListaTodosActivo(int IdTienda, int IdInventarioVisualBloque)
        {
            try
            {
                InventarioVisualModuloDL InventarioVisualModulo = new InventarioVisualModuloDL();
                return InventarioVisualModulo.ListaTodosActivo(IdTienda, IdInventarioVisualBloque);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public InventarioVisualModuloBE Selecciona(int IdEmpresa, int IdInventarioVisualModulo)
        //{
        //    try
        //    {
        //        InventarioVisualModuloDL InventarioVisualModulo = new InventarioVisualModuloDL();
        //        return InventarioVisualModulo.Selecciona(IdEmpresa, IdInventarioVisualModulo);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public void Inserta(InventarioVisualModuloBE pItem)
        {
            try
            {
                InventarioVisualModuloDL InventarioVisualModulo = new InventarioVisualModuloDL();
                InventarioVisualModulo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InventarioVisualModuloBE pItem)
        {
            try
            {
                InventarioVisualModuloDL InventarioVisualModulo = new InventarioVisualModuloDL();
                InventarioVisualModulo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InventarioVisualModuloBE pItem)
        {
            try
            {
                InventarioVisualModuloDL InventarioVisualModulo = new InventarioVisualModuloDL();
                InventarioVisualModulo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
