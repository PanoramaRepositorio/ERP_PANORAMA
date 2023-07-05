using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AgenciaBL
    {
        public List<AgenciaBE> ListaTodosActivo()
        {
            try
            {
                AgenciaDL Agencia = new AgenciaDL();
                return Agencia.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AgenciaBE Selecciona(int IdAgencia)
        {
            try
            {
                AgenciaDL Agencia = new AgenciaDL();
                return Agencia.Selecciona(IdAgencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AgenciaBE pItem)
        {
            try
            {
                AgenciaDL Agencia = new AgenciaDL();
                Agencia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AgenciaBE pItem)
        {
            try
            {
                AgenciaDL Agencia = new AgenciaDL();
                Agencia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AgenciaBE pItem)
        {
            try
            {
                AgenciaDL Agencia = new AgenciaDL();
                Agencia.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
