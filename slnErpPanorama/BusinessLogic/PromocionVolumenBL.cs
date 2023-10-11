using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Threading.Tasks;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PromocionVolumenBL
    {

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PromocionVolumenBE> ListaFecha(int IdEmpresa, bool FlagEstado, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PromocionVolumenDL PromocionTemporal = new PromocionVolumenDL();
                return PromocionTemporal.ListaFecha(IdEmpresa, FlagEstado, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(PromocionVolumenBE pItem, List<PromocionVolumenDetalleBE> pListaPromocionVolumenlDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionVolumenDL PromocionVolumen = new PromocionVolumenDL();
                    PromocionVolumenDetalleDL PromocionVolumenlDetalle = new PromocionVolumenDetalleDL();

                    int IdPromocionVolumen = 0;
                    IdPromocionVolumen = PromocionVolumen.Inserta(pItem);

                    foreach (PromocionVolumenDetalleBE item in pListaPromocionVolumenlDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPromocionVolumen = IdPromocionVolumen;
                        PromocionVolumenlDetalle.Inserta(item);
                    }

                    if (pItem.FlagWeb)
                    {
                        PromocionVolumen.ActualizaVistaWeb();
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }


        }

        public void Insertadt(PromocionVolumenDetalleBE pItem)
        {
            try
            {
                PromocionVolumenDetalleDL PromocionTemporalDetalle = new PromocionVolumenDetalleDL();
                PromocionTemporalDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Actualiza(PromocionVolumenBE pItem, List<PromocionVolumenDetalleBE> pListaPromocionVolumenDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionVolumenDL PromocionVolumen = new PromocionVolumenDL();
                    PromocionVolumenDetalleDL PromocionVolumenDetalle = new PromocionVolumenDetalleDL();

                    foreach (PromocionVolumenDetalleBE item in pListaPromocionVolumenDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPromocionVolumen = pItem.IdPromocionVolumen;
                            PromocionVolumenDetalle.Inserta(item);
                        }
                        else if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            PromocionVolumenDetalle.Actualiza(item);
                        }
                        //else
                        //{
                        //    //Actualizamos el detalle de la solicitud de producto
                        //    PromocionTemporalDetalle.Actualiza(item);
                        //}
                    }

                    PromocionVolumen.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<PromocionVolumenDetalleBE> ListaTodosActivo(int IdPromocionVolumen)
        {
            try
            {
                PromocionVolumenDetalleDL PromocionTemporalDetalle = new PromocionVolumenDetalleDL();
                return PromocionTemporalDetalle.ListaTodosActivo(IdPromocionVolumen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualizadt(PromocionVolumenDetalleBE pItem)
        {
            try
            {
                PromocionVolumenDetalleDL PromocionTemporalDetalle = new PromocionVolumenDetalleDL();
                PromocionTemporalDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Elimina(PromocionVolumenBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionVolumenDL PromocionVolumen = new PromocionVolumenDL();
                    PromocionVolumenDetalleDL PromocionVolumenDetalle = new PromocionVolumenDetalleDL();

                    PromocionVolumenDetalleBE ojbE_PromocionTemporalDetalle = new PromocionVolumenDetalleBE();
                    ojbE_PromocionTemporalDetalle.IdPromocionVolumen = pItem.IdPromocionVolumen;
                    ojbE_PromocionTemporalDetalle.IdEmpresa = pItem.IdEmpresa;
                    ojbE_PromocionTemporalDetalle.Maquina = pItem.Maquina;
                    ojbE_PromocionTemporalDetalle.Usuario = pItem.Usuario;

                    PromocionVolumenDetalle.EliminaTodo(ojbE_PromocionTemporalDetalle);

                    PromocionVolumen.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Eliminadt(PromocionVolumenDetalleBE pItem)
        {
            try
            {
                PromocionVolumenDetalleDL PromocionVolumenDetalle = new PromocionVolumenDetalleDL();
                PromocionVolumenDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaTodo(PromocionVolumenDetalleBE pItem)
        {
            try
            {
                PromocionVolumenDetalleDL PromocionVolumenDetalle = new PromocionVolumenDetalleDL();
                PromocionVolumenDetalle.EliminaTodo(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PromocionVolumenDetalleBE Selecciona(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdTipoVenta, int IdProducto, bool TraerIdTemDet = false)
        {
            try
            {
                PromocionVolumenDetalleDL PromocionVolumenDetalle = new PromocionVolumenDetalleDL();
                return PromocionVolumenDetalle.Selecciona(IdEmpresa, IdTipoCliente, IdFormaPago, IdTienda, IdTipoVenta, IdProducto, TraerIdTemDet);
            }
            catch (Exception ex)
            { throw ex; }
        }



    }
}
