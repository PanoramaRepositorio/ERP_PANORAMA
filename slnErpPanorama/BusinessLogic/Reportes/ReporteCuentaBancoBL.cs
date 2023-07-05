using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCuentaBancoBL
    {
        public List<ReporteCuentaBancoBE> Listado(int IdEmpresa, int IdBanco)
        {
            try
            {
                ReporteCuentaBancoDL CuentaBanco = new ReporteCuentaBancoDL();
                return CuentaBanco.Listado(IdEmpresa, IdBanco);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}