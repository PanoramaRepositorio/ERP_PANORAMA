using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MarcaBL
    {
        public List<MarcaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MarcaDL Marca = new MarcaDL();
                return Marca.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MarcaBE pItem)
        {
            try
            {
                MarcaDL Marca = new MarcaDL();
                Marca.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MarcaBE pItem)
        {
            try
            {
                MarcaDL Marca = new MarcaDL();
                Marca.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MarcaBE pItem)
        {
            try
            {
                MarcaDL Marca = new MarcaDL();
                Marca.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

