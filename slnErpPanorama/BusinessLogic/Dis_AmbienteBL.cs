using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_AmbienteBL
    {
        public List<Dis_AmbienteBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                Dis_AmbienteDL Dis_Ambiente = new Dis_AmbienteDL();
                return Dis_Ambiente.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_AmbienteBE pItem)
        {
            try
            {
                Dis_AmbienteDL Dis_Ambiente = new Dis_AmbienteDL();
                Dis_Ambiente.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_AmbienteBE pItem)
        {
            try
            {
                Dis_AmbienteDL Dis_Ambiente = new Dis_AmbienteDL();
                Dis_Ambiente.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_AmbienteBE pItem)
        {
            try
            {
                Dis_AmbienteDL Dis_Ambiente = new Dis_AmbienteDL();
                Dis_Ambiente.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
