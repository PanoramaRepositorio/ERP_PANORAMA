using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MetasCarteraBL
    {
        public List<MetasCarteraBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MetasCarteraDL MetasCartera = new MetasCarteraDL();
                return MetasCartera.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MetasCarteraBE Selecciona(int IdEmpresa, int IdMetasCartera)
        {
            try
            {
                MetasCarteraDL MetasCartera = new MetasCarteraDL();
                return MetasCartera.Selecciona(IdEmpresa, IdMetasCartera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MetasCarteraBE pItem)
        {
            try
            {
                MetasCarteraDL MetasCartera = new MetasCarteraDL();
                MetasCartera.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MetasCarteraBE pItem)
        {
            try
            {
                MetasCarteraDL MetasCartera = new MetasCarteraDL();
                MetasCartera.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MetasCarteraBE pItem)
        {
            try
            {
                MetasCarteraDL MetasCartera = new MetasCarteraDL();
                MetasCartera.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
