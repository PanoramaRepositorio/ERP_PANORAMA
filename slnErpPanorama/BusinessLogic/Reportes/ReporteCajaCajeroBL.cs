using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCajaCajeroBL
    {
        public List<ReporteCajaCajeroBE> Listado(int IdCaja, int IdPersona)
        {
            try
            {
                ReporteCajaCajeroDL CajaCajero = new ReporteCajaCajeroDL();
                return CajaCajero.Listado(IdCaja, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}