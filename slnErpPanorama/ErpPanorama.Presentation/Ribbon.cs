using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation
{
    public class Ribbon
    {
        //DataTable _data;

        List<AccesoUsuarioBE> _objList = new List<AccesoUsuarioBE>();
        RibbonControl _objRibbon;

        public delegate void delegateRibbonClick(string menuCodigo, string ensamblado, string modoCarga, string titulo, string clase);
        public event delegateRibbonClick RibbonClick;

        public Ribbon(RibbonControl objRibbon, List<AccesoUsuarioBE> menu)
        {
            _objList = menu;
            _objRibbon = objRibbon;
        }

        public void Fill()
        {
            //Obtenemos un DataView filtrando todos o que tengan el tipo Tab
            //entonces el campo MenuTipoID debe ser igual a 1
            //DataView dvHijos = new DataView(_data);
            //dvHijos.RowFilter = "MenuTipoID=1";
            var ListHijos =
                from p in _objList
                where p.IdMenuTipo == 1
                select p;

            foreach (var Hijos in ListHijos)
            {
                RibbonPage rbTab = new RibbonPage();

                // Creamos el Tab
                rbTab.Text = Hijos.MenuDescripcion.ToString().Trim();
                _objRibbon.Pages.Add(rbTab);
                //DataView dvGroups = new DataView(_data);
                //dvGroups.RowFilter = "MenuPadreID=" + drvHijos["MenuID"].ToString().Trim();
                var ListGrupos =
                    from g in _objList
                    where g.IdMenuPadre == Hijos.IdMenu
                    select g;
                ListGrupos = ListGrupos.OrderBy(o => o.MenuCodigo);
                foreach (var Grupos in ListGrupos)
                {
                    RibbonPageGroup rbGroup = new RibbonPageGroup();
                    // Creamos el Grupo
                    rbGroup.Text = Grupos.MenuDescripcion.ToString().Trim();
                    rbTab.Groups.Add(rbGroup);
                    // Busquemos sus botones para agregar
                    //DataView dvItems = new DataView(_data);
                    //dvItems.RowFilter = "MenuPadreID=" + drvGroupItem["MenuID"].ToString().Trim();
                    var ListButtons =
                        from b in _objList
                        where b.IdMenuPadre == Grupos.IdMenu
                        select b;
                    ListButtons = ListButtons.OrderBy(o => o.MenuCodigo);
                    foreach (var Item in ListButtons)
                    {
                        if (Item.IdMenuTipo == 2)
                        {
                            // Creamos el Boton
                            BarButtonItem rbutton;
                            rbutton = new BarButtonItem();
                            rbutton.Caption = Item.MenuDescripcion.ToString().Trim();
                            rbutton.Name = Item.MenuCodigo.ToString().Trim() + ";" + Item.Ensamblado.ToString().Trim()+ ";" + Item.Clase.ToString().Trim();

                            // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                            // ResourceImage de la base de datos    
                            if (Item.Imagen.ToString().Trim() != "")
                            {
                                if (Item.LargeImage == true)
                                {
                                    rbutton.LargeGlyph = (Image)ErpPanorama.Presentation.Properties.Resources.ResourceManager.GetObject(Item.Imagen.ToString().Trim());
                                    //rbutton.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
                                }
                                else
                                    rbutton.Glyph = (Image)ErpPanorama.Presentation.Properties.Resources.ResourceManager.GetObject(Item.Imagen.ToString().Trim());
                            }
                            rbutton.Tag = Item.ModoCargaVentana.ToString().Trim();
                            rbGroup.ItemLinks.Add(rbutton);
                            // Asignamos el evento para saber cuando pulsamos el boton
                            rbutton.ItemClick += new ItemClickEventHandler(rbutton_Click);
                        }
                        else if (Item.IdMenuTipo == 5)
                        {
                            // Creamos el Boton
                            BarSubItem rSubButton;
                            rSubButton = new BarSubItem();
                            rSubButton.Caption = Item.MenuDescripcion.ToString().Trim();
                            rSubButton.Name = Item.MenuCodigo.ToString().Trim() + ";" + Item.Ensamblado.ToString().Trim() + ";" + Item.Clase.ToString().Trim();

                            // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                            // ResourceImage de la base de datos    
                            if (Item.Imagen.ToString().Trim() != "")
                            {
                                if (Item.LargeImage == true)
                                {
                                    rSubButton.LargeGlyph = (Image)ErpPanorama.Presentation.Properties.Resources.ResourceManager.GetObject(Item.Imagen.ToString().Trim());
                                    //rbutton.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
                                }
                                else
                                    rSubButton.Glyph = (Image)ErpPanorama.Presentation.Properties.Resources.ResourceManager.GetObject(Item.Imagen.ToString().Trim());
                            }
                            rSubButton.Tag = Item.ModoCargaVentana.ToString().Trim();
                            rbGroup.ItemLinks.Add(rSubButton);
                            // Asignamos el evento para saber cuando pulsamos el boton
                            //rSubButton.ItemClick += new ItemClickEventHandler(rbutton_Click);

                            //Verificamos si tiene sub elementos
                            var ListSubButtons =
                            from sb in _objList
                            where sb.IdMenuPadre == Item.IdMenu
                            select sb;
                            ListSubButtons = ListSubButtons.OrderBy(o => o.MenuCodigo);
                            foreach (var SubItem in ListSubButtons)
                            {
                                if (SubItem.IdMenuTipo == 6)
                                {
                                    // Creamos el Boton
                                    BarButtonItem rSubButtonItem;
                                    rSubButtonItem = new BarButtonItem();
                                    rSubButtonItem.Caption = SubItem.MenuDescripcion.ToString().Trim();
                                    rSubButtonItem.Name = SubItem.MenuCodigo.ToString().Trim() + ";" + SubItem.Ensamblado.ToString().Trim() + ";" + SubItem.Clase.ToString().Trim();

                                    // Debe se asegurarse que el nombre de la imagen sin extension sea exactamente el mismo al
                                    // ResourceImage de la base de datos    
                                    if (SubItem.Imagen.ToString().Trim() != "")
                                        rSubButtonItem.Glyph = (Image)ErpPanorama.Presentation.Properties.Resources.ResourceManager.GetObject(SubItem.Imagen.ToString().Trim());
                                    rSubButtonItem.Tag = SubItem.ModoCargaVentana.ToString().Trim();
                                    rSubButton.ItemLinks.Add(rSubButtonItem);
                                    // Asignamos el evento para saber cuando pulsamos el boton
                                    rSubButtonItem.ItemClick += new ItemClickEventHandler(rbutton_Click);
                                }
                            }

                        }
                    }

                }
            }
        }

        void rbutton_Click(object sender, ItemClickEventArgs e)
        {
            //Verificamos que se aya llamado al evento para luego invocarlo
            if (RibbonClick != null)
            {
                string[] _info = e.Item.Name.ToString().Split(';');
                RibbonClick(_info[0], _info[1], e.Item.Tag.ToString(), e.Item.Caption, _info[2]);
            }
        
        }
    }
}
