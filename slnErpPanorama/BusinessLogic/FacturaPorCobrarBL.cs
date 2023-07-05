using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class FacturaPorCobrarBL
    {
        public List<FacturaPorCobrarBE> ListaTodosActivo(int IdEmpresa, int IdSituacionContable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                FacturaPorCobrarDL listado = new FacturaPorCobrarDL();
                return listado.ListaTodosActivo(IdEmpresa, IdSituacionContable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
