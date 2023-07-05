using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PromocionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PromocionBE> ListaTodosActivo(int IdPromocion)
        {
            try
            {
                PromocionDL Promocion = new PromocionDL();
                return Promocion.ListaTodosActivo(IdPromocion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PromocionBE pItem, List<PromocionDetalleBE> pListaPromocionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionDL Promocion = new PromocionDL();
                    PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();

                    int IdPromocion = 0;
                    IdPromocion = Promocion.Inserta(pItem);

                    foreach (PromocionDetalleBE item in pListaPromocionDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPromocion = IdPromocion;
                        PromocionDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PromocionBE pItem, List<PromocionDetalleBE> pListaPromocionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionDL Promocion = new PromocionDL();
                    PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();

                    foreach (PromocionDetalleBE item in pListaPromocionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPromocion = pItem.IdPromocion;
                            PromocionDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            PromocionDetalle.Actualiza(item);
                        }
                    }

                    Promocion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PromocionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionDL Promocion = new PromocionDL();
                    PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();

                    List<PromocionDetalleBE> lstPromocionDetalle = null;
                    lstPromocionDetalle = PromocionDetalle.ListaTodosActivo(pItem.IdPromocion);

                    foreach (PromocionDetalleBE item in lstPromocionDetalle)
                    {
                        PromocionDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    Promocion.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public int ListaProductoPrecioBusquedaCount(int IdTienda, int IdFormaPago, int IdTipoCliente, decimal Total, string pFiltro)
        {
            try
            {
                PromocionDL Promocion = new PromocionDL();
                return Promocion.ListaProductoPrecioBusquedaCount(IdTienda, IdFormaPago, IdTipoCliente, Total, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PromocionBE> ListaProductoPrecio(int IdTienda, int IdFormaPago, int IdTipoCliente, decimal Total, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                PromocionDL Promocion = new PromocionDL();
                return Promocion.ListaProductoPrecio(IdTienda, IdFormaPago, IdTipoCliente, Total, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
