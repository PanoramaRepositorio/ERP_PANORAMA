using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClockingBL
    {
        public List<CocklingBE> ListaTodosActivo(String Dni)
        {
            try
            {
                ClockingDL Checkinout = new ClockingDL();
                return Checkinout.ListaMarcaciones (Dni);
            }
            catch (Exception ex)
            { throw ex; }
        }

      
    }
}
