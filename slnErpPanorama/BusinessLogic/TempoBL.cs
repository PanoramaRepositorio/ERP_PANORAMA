using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TempoBL
    {
      
    
        public void Inserta(TempoBE  pItem)
        {
            try
            {
                TempoDL Temp = new TempoDL();
                Temp.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

      
        public void Elimina()
        {
            try
            {
                TempoDL temp = new TempoDL();
                temp.Elimina();
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<TempoBE> Listar()
        {
            try
            {
                TempoDL Temp = new TempoDL();
                return Temp.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}

