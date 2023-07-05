using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteInventarioBultoBL
    {
        public List<ReporteInventarioBultoBE> Listado(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                 ReporteInventarioBultoDL Inventariobulto = new  ReporteInventarioBultoDL();
                 return Inventariobulto.Listado(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInventarioBultoBE> ListadoBloque(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                ReporteInventarioBultoDL Inventariobulto = new ReporteInventarioBultoDL();
                return Inventariobulto.ListadoBloque(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
