using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AgenciaOficinaBL
    {
        public List<AgenciaOficinaBE> ListaTodosActivo(int IdAgencia)
        {
            try
            {
                AgenciaOficinaDL AgenciaOficina = new AgenciaOficinaDL();
                return AgenciaOficina.ListaTodosActivo(IdAgencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AgenciaOficinaBE Selecciona(int IdAgenciaOficina)
        {
            try
            {
                AgenciaOficinaDL AgenciaOficina = new AgenciaOficinaDL();
                return AgenciaOficina.Selecciona(IdAgenciaOficina);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AgenciaOficinaBE pItem)
        {
            try
            {
                AgenciaOficinaDL AgenciaOficina = new AgenciaOficinaDL();
                AgenciaOficina.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AgenciaOficinaBE pItem)
        {
            try
            {
                AgenciaOficinaDL AgenciaOficina = new AgenciaOficinaDL();
                AgenciaOficina.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AgenciaOficinaBE pItem)
        {
            try
            {
                AgenciaOficinaDL AgenciaOficina = new AgenciaOficinaDL();
                AgenciaOficina.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
