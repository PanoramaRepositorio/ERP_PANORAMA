using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DescuentoClienteMayoristaFeriaBL
    {
        public List<DescuentoClienteMayoristaFeriaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                DescuentoClienteMayoristaFeriaDL DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaDL();
                return DescuentoClienteMayoristaFeria.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DescuentoClienteMayoristaFeriaBE Selecciona(int IdProducto)
        {
            try
            {
                DescuentoClienteMayoristaFeriaDL DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaDL();
                return DescuentoClienteMayoristaFeria.Selecciona(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DescuentoClienteMayoristaFeriaBE pItem)
        {
            try
            {
                DescuentoClienteMayoristaFeriaDL DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaDL();
                DescuentoClienteMayoristaFeria.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescuentoClienteMayoristaFeriaBE pItem)
        {
            try
            {
                DescuentoClienteMayoristaFeriaDL DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaDL();
                DescuentoClienteMayoristaFeria.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DescuentoClienteMayoristaFeriaBE pItem)
        {
            try
            {
                DescuentoClienteMayoristaFeriaDL DescuentoClienteMayoristaFeria = new DescuentoClienteMayoristaFeriaDL();
                DescuentoClienteMayoristaFeria.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
