using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class UnidadMedidaBL
    {
        public List<UnidadMedidaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                UnidadMedidaDL UnidadMedida = new UnidadMedidaDL();
                return UnidadMedida.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(UnidadMedidaBE pItem)
        {
            try
            {
                UnidadMedidaDL UnidadMedida = new UnidadMedidaDL();
                UnidadMedida.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(UnidadMedidaBE pItem)
        {
            try
            {
                UnidadMedidaDL UnidadMedida = new UnidadMedidaDL();
                UnidadMedida.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(UnidadMedidaBE pItem)
        {
            try
            {
                UnidadMedidaDL UnidadMedida = new UnidadMedidaDL();
                UnidadMedida.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}