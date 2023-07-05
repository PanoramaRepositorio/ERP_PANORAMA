using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class RecursosBL
    {
        public List<RecursosBE> Listado(DateTime FechaDesde, DateTime FechaHasta, string Dni)
        {
            try
            {
                RecursosDL Recursos = new RecursosDL();
                return Recursos.Listado(FechaDesde, FechaHasta,Dni);
            }
            catch (Exception ex)
            { throw ex; }
        }

       
    }
}
