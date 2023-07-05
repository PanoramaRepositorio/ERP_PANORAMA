using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Dis_FormaBL
    {
        public List<Dis_FormaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                Dis_FormaDL Dis_Forma = new Dis_FormaDL();
                return Dis_Forma.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Dis_FormaBE pItem)
        {
            try
            {
                Dis_FormaDL Dis_Forma = new Dis_FormaDL();
                Dis_Forma.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Dis_FormaBE pItem)
        {
            try
            {
                Dis_FormaDL Dis_Forma = new Dis_FormaDL();
                Dis_Forma.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Dis_FormaBE pItem)
        {
            try
            {
                Dis_FormaDL Dis_Forma = new Dis_FormaDL();
                Dis_Forma.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
