using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_EstiloBL
    {
        public List<Dis_EstiloBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                Dis_EstiloDL Dis_Estilo = new Dis_EstiloDL();
                return Dis_Estilo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_EstiloBE pItem)
        {
            try
            {
                Dis_EstiloDL Dis_Estilo = new Dis_EstiloDL();
                Dis_Estilo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_EstiloBE pItem)
        {
            try
            {
                Dis_EstiloDL Dis_Estilo = new Dis_EstiloDL();
                Dis_Estilo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_EstiloBE pItem)
        {
            try
            {
                Dis_EstiloDL Dis_Estilo = new Dis_EstiloDL();
                Dis_Estilo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
