using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteMinoristaBL
    {
        public List<ReporteClienteMinoristaBE> Listado(int IdEmpresa, int IdTipoCliente)
        {
            try
            {
                ReporteClienteMinoristaDL ClienteMinorista = new ReporteClienteMinoristaDL();
                return ClienteMinorista.Listado(IdEmpresa, IdTipoCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
