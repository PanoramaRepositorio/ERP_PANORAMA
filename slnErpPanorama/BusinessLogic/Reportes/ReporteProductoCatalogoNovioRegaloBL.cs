using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoNovioRegaloBL
    {
        public List<ReporteProductoCatalogoNovioRegaloBE> Listado(int IdNovioRegalo)
        {
            try
            {
                ReporteProductoCatalogoNovioRegaloDL ProductoCatalogoPedido = new ReporteProductoCatalogoNovioRegaloDL();
                return ProductoCatalogoPedido.Listado(IdNovioRegalo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
