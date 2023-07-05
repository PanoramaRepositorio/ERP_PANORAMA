using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MenuBL
    {
        public List<MenuBE> ListaTodosActivo()
        {
            try
            {
                MenuDL menu = new MenuDL();
                List<MenuBE> lista = menu.ListaTodosActivo();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
