using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ListaPrecioBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ListaPrecioBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                ListaPrecioDL ListaPrecio = new ListaPrecioDL();
                return ListaPrecio.ListaTodosActivo(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ListaPrecioBE pItem, List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Inserta Lista Precio
                    int IdListaPrecio = 0;
                    ListaPrecioDL ListaPrecio = new ListaPrecioDL();
                    ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();

                    IdListaPrecio = ListaPrecio.Inserta(pItem);

                    foreach (var item in pListaPrecioDetalle)
                    {
                        //Inserta Lista Precio Detalle
                        item.IdListaPrecio = IdListaPrecio;
                        ListaPrecioDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ListaPrecioBE pItem , List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                        {
                            //Inserta Lista Precio Detalle
                            item.IdListaPrecio = pItem.IdListaPrecio;
                            ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                            objDL_ListaPrecioDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualiza Lista Precio Detalle
                            ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                            objDL_ListaPrecioDetalle.Actualiza(item);
                        }
                    }

                    //Actualiza Lista precio
                    ListaPrecioDL ListaPrecio = new ListaPrecioDL();
                    ListaPrecio.Actualiza(pItem);

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ListaPrecioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar la lista de precio
                    ListaPrecioDL ListaPrecio = new ListaPrecioDL();
                    ListaPrecio.Elimina(pItem);

                    List<ListaPrecioDetalleBE> lstListaPrecioDetalle = null;
                    lstListaPrecioDetalle = new ListaPrecioDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdListaPrecio);

                    foreach (var item in lstListaPrecioDetalle)
                    {
                        // Eliminar los detalle de la lista de precio
                        ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        ListaPrecioDetalle.Elimina(item);
                    }
                    

                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
