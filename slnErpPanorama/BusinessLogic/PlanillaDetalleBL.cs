using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PlanillaDetalleBL
    {
        public List<PlanillaDetalleBE> ListaTodosActivo(int IdPlanilla)
        {
            try
            {
                PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();
                return PlanillaDetalle.ListaTodosActivo(IdPlanilla);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PlanillaDetalleBE> ListaCalculo(int IdPlanilla, int IdEmpresa, int Periodo, int Mes, int DiasEfectivoTrabajo, decimal HoraOrdinaria, decimal HoraExtraDiaria , decimal RMV, decimal AporteSeguroMinimo,DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();
                return PlanillaDetalle.ListaCalculo(IdPlanilla, IdEmpresa, Periodo, Mes, DiasEfectivoTrabajo, HoraOrdinaria, HoraExtraDiaria, RMV, AporteSeguroMinimo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PlanillaDetalleBE pItem)
        {
            try
            {
                PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();
                PlanillaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PlanillaDetalleBE pItem)
        {
            try
            {
                PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();
                PlanillaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PlanillaDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el detalle del Planilla
                    PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();
                    PlanillaDetalle.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
