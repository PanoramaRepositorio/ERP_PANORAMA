using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EliminaBL
    {
              public void Elimina(DateTime FechaDesde)
        {
            try
            {
                EliminaDL elimina = new EliminaDL();
                elimina.Elimina(FechaDesde);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
