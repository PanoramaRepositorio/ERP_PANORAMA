using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoProformaBL
    {
        public List<ReporteProductoCatalogoProformaBE> Listado(int IdEmpresa, int IdProforma, int IdTipoCliente)
        {
            try
            {
                ReporteProductoCatalogoProformaDL ProductoCatalogoProforma = new ReporteProductoCatalogoProformaDL();
                return ProductoCatalogoProforma.Listado(IdEmpresa, IdProforma, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
