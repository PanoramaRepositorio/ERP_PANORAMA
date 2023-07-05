using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PlanillaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PlanillaBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                PlanillaDL Planilla = new PlanillaDL();
                return Planilla.ListaTodosActivo(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PlanillaBE Selecciona(int IdPlanilla)
        {
            try
            {
                PlanillaDL Planilla = new PlanillaDL();
                PlanillaBE objAna = Planilla.Selecciona(IdPlanilla);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PlanillaBE pItem, List<PlanillaDetalleBE> pListaPlanillaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanillaDL Planilla = new PlanillaDL();
                    PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();

                    //Insertar en el Planilla
                    int IdPlanilla = 0;
                    IdPlanilla = Planilla.Inserta(pItem);

                    foreach (PlanillaDetalleBE item in pListaPlanillaDetalle)
                    {
                        item.IdPlanilla = IdPlanilla;
                        PlanillaDetalle.Inserta(item);
                    }
                           
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PlanillaBE pItem, List<PlanillaDetalleBE> pListaPlanillaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanillaDL Planilla = new PlanillaDL();
                    PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();

                    foreach (PlanillaDetalleBE item in pListaPlanillaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPlanilla = pItem.IdPlanilla;
                            PlanillaDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            PlanillaDetalle.Actualiza(item);
                        }
                    }

                    Planilla.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PlanillaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanillaDL Planilla = new PlanillaDL();
                    PlanillaDetalleDL PlanillaDetalle = new PlanillaDetalleDL();

                    List<PlanillaDetalleBE> ListaPlanillaDetalle = null;
                    ListaPlanillaDetalle = new PlanillaDetalleDL().ListaTodosActivo(pItem.IdPlanilla);

                    foreach (PlanillaDetalleBE item in ListaPlanillaDetalle)
                    {
                        //Eliminanos el detalle del Planilla
                        PlanillaDetalle.Elimina(item);
                    }

                    //Actualiza la anulación del Planilla
                    Planilla.Elimina(pItem);
                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
