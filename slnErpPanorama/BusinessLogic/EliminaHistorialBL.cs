using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EliminaHistorialBL
    {


        public void Elimina(EliminarHistorialBE pItem)
        {
            try
            {
                EliminarHistorialDL Historial = new EliminarHistorialDL();
                Historial.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
