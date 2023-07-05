using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCajaVaciaBL
    {
        public List<ReporteCajaVaciaBE> Listado(int IdEmpresa, int IdUbicacion, int IdPiso)
        {
            try
            {
                ReporteCajaVaciaDL CajaVacia = new ReporteCajaVaciaDL();
                return CajaVacia.Listado(IdEmpresa, IdUbicacion, IdPiso);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}