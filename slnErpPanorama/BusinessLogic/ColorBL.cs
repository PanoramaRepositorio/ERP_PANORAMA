using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ColorBL
    {
        public List<ColorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ColorDL Material = new ColorDL();
                return Material.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public ColorBE SeleccionaMaterial(string Descripcion)
        //{
        //    try
        //    {
        //        ColorDL Material = new ColorDL();
        //        return Material.SelecionaMaterial(Descripcion);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Inserta(ColorBE pItem)
        //{
        //    try
        //    {
        //        ColorDL Material = new ColorDL();
        //        Material.Inserta(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Actualiza(ColorBE pItem)
        //{
        //    try
        //    {
        //        ColorDL Material = new ColorDL();
        //        Material.Actualiza(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public void Elimina(ColorBE pItem)
        //{
        //    try
        //    {
        //        ColorDL Material = new ColorDL();
        //        Material.Elimina(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
    }
}
