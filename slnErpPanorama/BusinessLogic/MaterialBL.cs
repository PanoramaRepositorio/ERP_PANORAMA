using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MaterialBL
    {
        public List<MaterialBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MaterialDL Material = new MaterialDL();
                return Material.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MaterialBE SeleccionaMaterial(string Descripcion)
        {
            try
            {
                MaterialDL Material = new MaterialDL();
                return Material.SelecionaMaterial(Descripcion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MaterialBE pItem)
        {
            try
            {
                MaterialDL Material = new MaterialDL();
                Material.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MaterialBE pItem)
        {
            try
            {
                MaterialDL Material = new MaterialDL();
                Material.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MaterialBE pItem)
        {
            try
            {
                MaterialDL Material = new MaterialDL();
                Material.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
