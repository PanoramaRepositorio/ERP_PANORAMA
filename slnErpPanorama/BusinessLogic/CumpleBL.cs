using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CumpleBL
    {


        public List<CumpleBE> Mostrar()
        {
            try
            {
                CumpleDL listar = new CumpleDL();
                List<CumpleBE> lista = listar.Mostrar ();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}