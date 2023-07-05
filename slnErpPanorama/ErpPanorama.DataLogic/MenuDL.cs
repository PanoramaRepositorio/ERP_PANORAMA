using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MenuDL
    {
         public MenuDL() { }

         public List<MenuBE> ListaTodosActivo()
         {
             Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
             DbCommand dbCommand = db.GetStoredProcCommand("usp_Menu_SeleccionaTodosActivo");
             IDataReader reader = db.ExecuteReader(dbCommand);
             List<MenuBE> menulist = new List<MenuBE>();
             MenuBE menu;
             while (reader.Read())
             {
                 menu = new MenuBE();
                 menu.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                 menu.MenuCodigo = reader["menucodigo"].ToString();
                 menu.IdMenuPadre = Int32.Parse(reader["idmenupadre"].ToString());
                 menu.MenuDescripcion = reader["menudescripcion"].ToString();
                 menu.Imagen = reader["imagen"].ToString();
                 menu.LargeImage = Boolean.Parse(reader["largeimage"].ToString());
                 menu.Clase = reader["clase"].ToString();
                 menu.Ensamblado = reader["ensamblado"].ToString();
                 menu.IdMenuTipo = Int32.Parse(reader["idmenutipo"].ToString());
                 menu.ModoCargaVentana = reader["modocargaventana"].ToString();
                 menu.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                 menulist.Add(menu);
             }
             reader.Close();
             reader.Dispose();
             return menulist;
         }
    }
}
