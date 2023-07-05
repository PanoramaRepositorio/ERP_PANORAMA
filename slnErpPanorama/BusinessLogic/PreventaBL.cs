using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PreventaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PreventaBE> ListaTodosActivo(int IdPreventa)
        {
            try
            {
                PreventaDL Preventa = new PreventaDL();
                return Preventa.ListaTodosActivo(IdPreventa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PreventaBE pItem, List<PreventaDetalleBE> pListaPreventaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PreventaDL Preventa = new PreventaDL();
                    PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();

                    int IdPreventa = 0;
                    IdPreventa = Preventa.Inserta(pItem);

                    foreach (PreventaDetalleBE item in pListaPreventaDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPreventa = IdPreventa;
                        PreventaDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PreventaBE pItem, List<PreventaDetalleBE> pListaPreventaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PreventaDL Preventa = new PreventaDL();
                    PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();


                    foreach (PreventaDetalleBE item in pListaPreventaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPreventa = pItem.IdPreventa;
                            PreventaDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            PreventaDetalle.Actualiza(item);
                        }
                    }

                    Preventa.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PreventaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PreventaDL Preventa = new PreventaDL();
                    PreventaDetalleDL PreventaDetalle = new PreventaDetalleDL();

                    List<PreventaDetalleBE> lstPreventaDetalle = null;
                    lstPreventaDetalle = PreventaDetalle.ListaTodosActivo(pItem.IdPreventa);

                    foreach (PreventaDetalleBE item in lstPreventaDetalle)
                    {
                        PreventaDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    Preventa.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
