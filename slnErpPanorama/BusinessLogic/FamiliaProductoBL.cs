using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class FamiliaProductoBL
    {
        public List<FamiliaProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                FamiliaProductoDL FamiliaProducto = new FamiliaProductoDL();
                return FamiliaProducto.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FamiliaProductoBE pItem)
        {
            try
            {
                FamiliaProductoDL FamiliaProducto = new FamiliaProductoDL();
                FamiliaProducto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FamiliaProductoBE pItem)
        {
            try
            {
                FamiliaProductoDL FamiliaProducto = new FamiliaProductoDL();
                FamiliaProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FamiliaProductoBE pItem)
        {
            try
            {
                FamiliaProductoDL FamiliaProducto = new FamiliaProductoDL();
                FamiliaProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
