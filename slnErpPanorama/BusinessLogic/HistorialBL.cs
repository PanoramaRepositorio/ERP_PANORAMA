using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class HistorialBL
    {
  
        public void Inserta(HistorialBE pItem)
        {
            try
            {
                HistorialDL Historial = new HistorialDL();
                Historial.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

      
    }
}
