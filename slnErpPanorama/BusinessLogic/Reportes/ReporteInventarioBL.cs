using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteInventarioBL
    {
        public List<ReporteInventarioBE> Listado(int IdEmpresa, int IdTienda)
        {
            try
            {
                ReporteInventarioDL Inventario = new ReporteInventarioDL();
                return Inventario.Listado(IdEmpresa,IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
