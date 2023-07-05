using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SolicitudProductoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<SolicitudProductoBE> ListaTodosActivo(int IdEmpresa,  int Periodo, int Mes)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                return SolicitudProducto.ListaTodosActivo(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudProductoBE Selecciona(int IdEmpresa, int IdSolicitudProducto)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                return SolicitudProducto.Selecciona(IdEmpresa, IdSolicitudProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudProductoBE SeleccionaVendedor(int Periodo, String DocReferencia)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                return SolicitudProducto.SeleccionaVendedor(Periodo, DocReferencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudProductoBE SeleccionaProductos(int Periodo, String DocReferencia)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                return SolicitudProducto.SeleccionaProductos(Periodo, DocReferencia);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SolicitudProductoBE SeleccionaNumero(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                return SolicitudProducto.SeleccionaNumero(IdEmpresa, Periodo, IdTipoDocumento, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(SolicitudProductoBE pItem, List<SolicitudProductoDetalleBE> pListaSolicitudProductoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                    SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();

                    int IdSolicitudProducto = 0;
                    IdSolicitudProducto= SolicitudProducto.Inserta(pItem);

                    foreach (SolicitudProductoDetalleBE item in pListaSolicitudProductoDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdSolicitudProducto = IdSolicitudProducto;
                        SolicitudProductoDetalle.Inserta(item);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Periodo);

                    ts.Complete();
                    return IdSolicitudProducto;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudProductoBE pItem, List<SolicitudProductoDetalleBE> pListaSolicitudProductoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                    SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();

                    foreach (SolicitudProductoDetalleBE item in pListaSolicitudProductoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdSolicitudProducto = pItem.IdSolicitudProducto;
                            SolicitudProductoDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            SolicitudProductoDetalle.Actualiza(item);
                        }
                    }

                    SolicitudProducto.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEnvio(SolicitudProductoBE pItem)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                SolicitudProducto.ActualizaEnvio(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaRecibido(SolicitudProductoBE pItem)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                SolicitudProducto.ActualizaRecibido(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFechaImpresion(SolicitudProductoBE pItem)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                SolicitudProducto.ActualizaFechaImpresion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAuxiliar(SolicitudProductoBE pItem)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                SolicitudProducto.ActualizaAuxiliar(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudProductoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                    SolicitudProductoDetalleDL SolicitudProductoDetalle = new SolicitudProductoDetalleDL();

                    List<SolicitudProductoDetalleBE> lstSolicitudProductoDetalle = null;
                    lstSolicitudProductoDetalle = SolicitudProductoDetalle.ListaTodosActivo(pItem.IdEmpresa, pItem.IdSolicitudProducto);

                    foreach (SolicitudProductoDetalleBE item in lstSolicitudProductoDetalle)
                    {
                        SolicitudProductoDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    SolicitudProducto.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudProductoBE SeleccionaSolProdPendiente(int IdEmpresa, int IdTienda)
        {
            try
            {
                SolicitudProductoDL SolicitudProducto = new SolicitudProductoDL();
                return SolicitudProducto.SeleccionaSolProdPendiente(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}



