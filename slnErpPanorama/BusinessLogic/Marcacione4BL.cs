using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Marcaciones4BL
    {
        public List<Marcaciones4BE> ListaTodos(String fecha1)
        {
            try
            {
                Marcaciones4DL Marcaciones = new Marcaciones4DL();
                return Marcaciones.ListaTodos (fecha1);
            }
            catch (Exception ex)
            { throw ex; }
        }

  

    }
}

