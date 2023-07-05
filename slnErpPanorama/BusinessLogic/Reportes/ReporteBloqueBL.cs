using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteBloqueBL
    {
        public List<ReporteBloqueBE> Listado(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            try
            {
                ReporteBloqueDL Bloque = new ReporteBloqueDL();
                return Bloque.Listado(IdEmpresa,IdTienda,IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
