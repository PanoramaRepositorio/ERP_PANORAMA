using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteAlmacenBL
    {
        public List<ReporteAlmacenBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteAlmacenDL Almacen = new ReporteAlmacenDL();
                return Almacen.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

