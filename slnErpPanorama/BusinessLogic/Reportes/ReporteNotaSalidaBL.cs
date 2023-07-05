using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteNotaSalidaBL
    {
        public List<ReporteNotaSalidaBE> Listado(int IdEmpresa, int IdNotaSalida)
        {
            try
            {
                ReporteNotaSalidaDL ReporteNotaSalida = new ReporteNotaSalidaDL();
                return ReporteNotaSalida.Listado(IdEmpresa, IdNotaSalida);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
