using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PromocionTemporalBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PromocionTemporalBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                return PromocionTemporal.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PromocionTemporalBE> ListaFecha(int IdEmpresa, bool FlagEstado, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                return PromocionTemporal.ListaFecha(IdEmpresa, FlagEstado, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PromocionTemporalBE> ListaFechaProducto(int IdEmpresa, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                return PromocionTemporal.ListaFechaProducto(IdEmpresa, IdProducto, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PromocionTemporalBE Selecciona(int IdPromocionTemporal)
        {
            try
            {
                PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                return PromocionTemporal.Selecciona(IdPromocionTemporal);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PromocionTemporalBE pItem, List<PromocionTemporalDetalleBE> pListaPromocionTemporalDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                    PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();

                    int IdPromocionTemporal = 0;
                    IdPromocionTemporal = PromocionTemporal.Inserta(pItem);

                    foreach (PromocionTemporalDetalleBE item in pListaPromocionTemporalDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPromocionTemporal = IdPromocionTemporal;
                        PromocionTemporalDetalle.Inserta(item);
                    }

                    if(pItem.FlagWeb)
                    {
                        PromocionTemporal.ActualizaVistaWeb();
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }


        }

        public void Actualiza(PromocionTemporalBE pItem, List<PromocionTemporalDetalleBE> pListaPromocionTemporalDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                    PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();

                    foreach (PromocionTemporalDetalleBE item in pListaPromocionTemporalDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPromocionTemporal = pItem.IdPromocionTemporal;
                            PromocionTemporalDetalle.Inserta(item);
                        }
                        else if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            PromocionTemporalDetalle.Actualiza(item);
                        }
                        //else
                        //{
                        //    //Actualizamos el detalle de la solicitud de producto
                        //    PromocionTemporalDetalle.Actualiza(item);
                        //}
                    }

                    PromocionTemporal.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PromocionTemporalBE pItem)
        {
            try
            {
                using(TransactionScope  ts = new TransactionScope())  
                {
                    PromocionTemporalDL PromocionTemporal = new PromocionTemporalDL();
                    PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();

                    PromocionTemporalDetalleBE ojbE_PromocionTemporalDetalle = new PromocionTemporalDetalleBE();
                    ojbE_PromocionTemporalDetalle.IdPromocionTemporal = pItem.IdPromocionTemporal;
                    ojbE_PromocionTemporalDetalle.IdEmpresa = pItem.IdEmpresa;
                    ojbE_PromocionTemporalDetalle.Maquina = pItem.Maquina;
                    ojbE_PromocionTemporalDetalle.Usuario = pItem.Usuario;

                    PromocionTemporalDetalle.EliminaTodo(ojbE_PromocionTemporalDetalle);

                    PromocionTemporal.Elimina(pItem);   
             
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
