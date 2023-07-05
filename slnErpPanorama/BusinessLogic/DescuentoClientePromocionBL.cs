using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DescuentoClientePromocionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }


        public List<DescuentoClientePromocionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
                return DescuentoClientePromocion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DescuentoClientePromocionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
                return DescuentoClientePromocion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DescuentoClientePromocionBE Selecciona(int IdEmpresa, int IdDescuentoClientePromocion)
        {
            try
            {
                DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
                return DescuentoClientePromocion.Selecciona(IdEmpresa, IdDescuentoClientePromocion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public void Inserta(DescuentoClientePromocionBE pItem)
        //{
        //    try
        //    {
        //        DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
        //        DescuentoClientePromocion.Inserta(pItem);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public void Inserta(DescuentoClientePromocionBE pItem, List<DescuentoClientePromocionDetalleBE> pListaDescuentoClientePromocionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
                    DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();

                    int IdDescuentoClientePromocion = 0;
                    IdDescuentoClientePromocion = DescuentoClientePromocion.Inserta(pItem);

                    foreach (DescuentoClientePromocionDetalleBE item in pListaDescuentoClientePromocionDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdDescuentoClientePromocion = IdDescuentoClientePromocion;
                        DescuentoClientePromocionDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescuentoClientePromocionBE pItem, List<DescuentoClientePromocionDetalleBE> pListaDescuentoClientePromocionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
                    DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();


                    foreach (DescuentoClientePromocionDetalleBE item in pListaDescuentoClientePromocionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdDescuentoClientePromocion = pItem.IdDescuentoClientePromocion;
                            DescuentoClientePromocionDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            DescuentoClientePromocionDetalle.Actualiza(item);
                        }
                    }

                    DescuentoClientePromocion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Elimina(DescuentoClientePromocionBE pItem)
        {
            try
            {
                DescuentoClientePromocionDL DescuentoClientePromocion = new DescuentoClientePromocionDL();
                DescuentoClientePromocion.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
