using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MarcacionesGeneralBL
    {
        public List<MarcacionesGeneralBE> ListaTodos(int op, String dni, String pnom, String pfechini, String pfechfin,int area)
        {
            try
            {
                MarcacionesGeneralDL Marcaciones = new MarcacionesGeneralDL();
                return Marcaciones.ListaTodos(op, dni, pnom, pfechini, pfechfin,area);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MarcacionesGeneralBE> Listacombo()
        {
            try
            {
                MarcacionesGeneralDL Marcaciones = new MarcacionesGeneralDL();
                return Marcaciones.Listacombo();
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}

