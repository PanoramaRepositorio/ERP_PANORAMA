using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ConsultaHistorialBL
    {
        public List<ConsultaHistorialBE> ListaTodosActivo(int IdPersona)
        {
            try
            {
                ConsultaHistorialDL ConsultaHistorial = new ConsultaHistorialDL();
                return ConsultaHistorial.ListaHistorial(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

     
    }
}
