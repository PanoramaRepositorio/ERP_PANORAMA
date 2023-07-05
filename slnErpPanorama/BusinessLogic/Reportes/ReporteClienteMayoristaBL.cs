using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteMayoristaBL
    {
        public List<ReporteClienteMayoristaBE> Listado(int IdEmpresa, int IdTipoCliente)
        {
            try
            {
                ReporteClienteMayoristaDL ClienteMayorista = new ReporteClienteMayoristaDL();
                return ClienteMayorista.Listado(IdEmpresa, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
