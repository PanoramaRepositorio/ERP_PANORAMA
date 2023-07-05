using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePersonaTrabajoBL
    {
        public List<ReportePersonaTrabajoBE> Listado(int IdPersonaTrabajo, int IdUsuario)
        {
            try
            {
                ReportePersonaTrabajoDL PersonaTrabajo = new ReportePersonaTrabajoDL();
                return PersonaTrabajo.Listado(IdPersonaTrabajo, IdUsuario);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReportePersonaTrabajoBE> ListadoFecha(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            try
            {
                ReportePersonaTrabajoDL PersonaTrabajo = new ReportePersonaTrabajoDL();
                return PersonaTrabajo.ListadoFecha(FechaDesde, FechaHasta, IdPersona, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReportePersonaTrabajoBE> ListadoFechaPersona(int IdPersona, int pIdPersonaTrab, int pIdPersonaTrabDet)
        {
            try
            {
                ReportePersonaTrabajoDL PersonaTrabajo = new ReportePersonaTrabajoDL();
                return PersonaTrabajo.ListadoFechaPersona(IdPersona, pIdPersonaTrab, pIdPersonaTrabDet);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
