using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Marcaciones2BL
    {
        public List<Marcaciones2BE> ListaTodos(String fecha1,String fecha2)
        {
            try
            {
                Marcaciones2DL Marcaciones = new Marcaciones2DL();
                return Marcaciones.ListaTodos(fecha1 ,fecha2);
            }
            catch (Exception ex)
            { throw ex; }
        }

  

    }
}

