using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Promocion2x1BL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<Promocion2x1BE> ListaTodosActivo(int IdEmpresa, string Tipo)
        {
            try
            {
                Promocion2x1DL Promocion2x1 = new Promocion2x1DL();
                return Promocion2x1.ListaTodosActivo(IdEmpresa, Tipo);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<Promocion2x1BE> ListaVigente(int IdEmpresa)
        {
            try
            {
                Promocion2x1DL Promocion2x1 = new Promocion2x1DL();
                return Promocion2x1.ListaVigente(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Promocion2x1BE pItem,List<Promocion2x1DetalleBE> pListaPromocion2x1Detalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Promocion2x1DL Promocion2x1 = new Promocion2x1DL();
                    Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();

                    int IdPromocion2x1 = 0;
                    IdPromocion2x1 = Promocion2x1.Inserta(pItem);

                    foreach (Promocion2x1DetalleBE item in pListaPromocion2x1Detalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPromocion2x1 = IdPromocion2x1;
                        Promocion2x1Detalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Promocion2x1BE pItem, List<Promocion2x1DetalleBE> pListaPromocion2x1Detalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Promocion2x1DL Promocion2x1 = new Promocion2x1DL();
                    Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();


                    foreach (Promocion2x1DetalleBE item in pListaPromocion2x1Detalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPromocion2x1 = pItem.IdPromocion2x1;
                            Promocion2x1Detalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            Promocion2x1Detalle.Actualiza(item);
                        }
                    }

                    Promocion2x1.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Promocion2x1BE pItem)
        {
            try
            {
                Promocion2x1DL Promocion2x1 = new Promocion2x1DL();
                Promocion2x1.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<Promocion2x1BE> ListaSolPendiente(int IdEmpresa, int IdTienda)
        {
            try
            {
                Promocion2x1DL Promocion2x1 = new Promocion2x1DL();
                return Promocion2x1.ListaSolPendiente(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
