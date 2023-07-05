using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AlertaContratoBL
    {


        public List<AlertaContratoBE> ListaContratos()
        {
            try
            {
                AlertaContratoDL muestra= new AlertaContratoDL();
                return muestra.ListaContratos();
            }
            catch (Exception ex)
            { throw ex; }
        }

       
    }
}
