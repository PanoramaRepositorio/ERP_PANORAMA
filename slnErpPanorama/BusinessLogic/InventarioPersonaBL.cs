using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InventarioPersonaBL
    {
    //    public List<InventarioPersonaBE> ListaTodosActivo()
    //    {
    //        try
    //        {
    //            InventarioPersonaDL InventarioPersona = new InventarioPersonaDL();
    //            return InventarioPersona.ListaTodosActivo();
    //        }
    //        catch (Exception ex)
    //        { throw ex; }
    //    }

        public InventarioPersonaBE Selecciona(int IdPersona)
        {
            try
            {
                InventarioPersonaDL InventarioPersona = new InventarioPersonaDL();
                return InventarioPersona.Selecciona(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public void Inserta(InventarioPersonaBE pItem)
        //{
        //    try
        //    {
        //        InventarioPersonaDL InventarioPersona = new InventarioPersonaDL();
        //        InventarioPersona.Inserta(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Actualiza(InventarioPersonaBE pItem)
        //{
        //    try
        //    {
        //        InventarioPersonaDL InventarioPersona = new InventarioPersonaDL();
        //        InventarioPersona.Actualiza(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Elimina(InventarioPersonaBE pItem)
        //{
        //    try
        //    {
        //        InventarioPersonaDL InventarioPersona = new InventarioPersonaDL();
        //        InventarioPersona.Elimina(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
    }
}
