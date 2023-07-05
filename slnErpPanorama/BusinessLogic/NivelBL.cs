using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class NivelBL
    {
        public List<NivelBE> SeleccionaTodos()
        {
            try
            {
                NivelDL Nivel = new NivelDL();
                List<NivelBE> lista = Nivel.SeleccionaTodos();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
