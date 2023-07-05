using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteInventarioBultoSectorBL
    {
        public List<ReporteInventarioBultoSectorBE> Listado(int IdEmpresa, int IdSector)
        {
            try
            {
                ReporteInventarioBultoSectorDL Bulto = new ReporteInventarioBultoSectorDL();
                return Bulto.Listado(IdEmpresa, IdSector);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInventarioBultoSectorBE> ListadoRecibido(int IdEmpresa, int IdSector)
        {
            try
            {
                ReporteInventarioBultoSectorDL Bulto = new ReporteInventarioBultoSectorDL();
                return Bulto.ListadoRecibido(IdEmpresa, IdSector);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInventarioBultoSectorBE> ListadoBultoAnaqueles(int IdEmpresa)
        {
            try
            {
                ReporteInventarioBultoSectorDL Bulto = new ReporteInventarioBultoSectorDL();
                return Bulto.ListadoBultoAnaqueles(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
