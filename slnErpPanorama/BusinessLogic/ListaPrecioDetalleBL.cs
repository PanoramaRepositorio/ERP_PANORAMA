using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ListaPrecioDetalleBL
    {
        public List<ListaPrecioDetalleBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdListaPrecio)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                return ListaPrecioDetalle.ListaTodosActivo(IdEmpresa, IdTienda, IdListaPrecio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ListaPrecioDetalleBE> ListaTodosAutoservicio(int IdEmpresa, int IdTienda, int IdListaPrecio)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                return ListaPrecioDetalle.ListaTodosAutoservicio(IdEmpresa, IdTienda, IdListaPrecio);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<ListaPrecioDetalleBE> ListaAutoservicio(int IdEmpresa, int IdTienda, int IdListaPrecio)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                return ListaPrecioDetalle.ListaAutoservicio(IdEmpresa, IdTienda, IdListaPrecio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaBusquedaCount(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                return ListaPrecioDetalle.SeleccionaBusquedaCount(IdEmpresa, IdTienda, IdListaPrecio, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ListaPrecioDetalleBE> ListaBusqueda(int IdEmpresa, int IdTienda, int IdListaPrecio, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                return ListaPrecioDetalle.ListaBusqueda(IdEmpresa, IdTienda, IdListaPrecio, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ListaPrecioDetalleBE pItem)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                ListaPrecioDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ListaPrecioDetalleBE pItem)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                ListaPrecioDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public void ActualizaMasivo(List<ListaPrecioDetalleBE> pListaPrecioDetalle, bool FlagTodo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (FlagTodo)//add 100116
                    {
                        List<ListaPrecioBE> lst_ListaPrecio = new List<ListaPrecioBE>();
                        lst_ListaPrecio = new ListaPrecioBL().ListaTodosActivo(Parametros.intEmpresaId,0);

                        foreach (var itemTienda in lst_ListaPrecio)
                        {
                            foreach (var item in pListaPrecioDetalle)
                            {
                                item.IdListaPrecio = itemTienda.IdListaPrecio;
                                ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                                objDL_ListaPrecioDetalle.ActualizaMasivo(item);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in pListaPrecioDetalle)
                        {
                            ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                            objDL_ListaPrecioDetalle.ActualizaMasivo(item);
                        }
                    }


                    ts.Complete();
                }
            }

            catch (Exception ex)
            {throw ex;

            }
        }

        public void ActualizaDescuento(List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        objDL_ListaPrecioDetalle.ActualizaDescuento(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaProductoDescuento(List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        objDL_ListaPrecioDetalle.ActualizaProductoDescuento(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaProductoDescuentoOutlet(List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        objDL_ListaPrecioDetalle.ActualizaProductoDescuentoOutlet(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAutoservicio(List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        objDL_ListaPrecioDetalle.ActualizaAutoservicio(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAutoservicio(ListaPrecioDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {

                    ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                    objDL_ListaPrecioDetalle.ActualizaAutoservicio(pItem);

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaProductoAutoservicio(List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        objDL_ListaPrecioDetalle.ActualizaProductoAutoservicio(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaProductoDescuentoHangTag(List<ListaPrecioDetalleBE> pListaPrecioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPrecioDetalle)
                    {
                        ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                        objDL_ListaPrecioDetalle.ActualizaDescuento(item);
                    }

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDescuentoMayorista()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    
                    ListaPrecioDetalleDL objDL_ListaPrecioDetalle = new ListaPrecioDetalleDL();
                    objDL_ListaPrecioDetalle.ActualizaDescuentoMayorista();
                  

                    ts.Complete();
                }
            }

            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ListaPrecioDetalleBE pItem)
        {
            try
            {
                ListaPrecioDetalleDL ListaPrecioDetalle = new ListaPrecioDetalleDL();
                ListaPrecioDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
