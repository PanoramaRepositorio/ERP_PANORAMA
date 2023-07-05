using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PromocionTemporalDetalleBL
    {
        public List<PromocionTemporalDetalleBE> ListaTodosActivo(int IdPromocionTemporal)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                return PromocionTemporalDetalle.ListaTodosActivo(IdPromocionTemporal);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PromocionTemporalDetalleBE> ListaTipoClienteFormapago(int IdEmpresa, int IdTipoCliente, int IdFormaPago)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                return PromocionTemporalDetalle.ListaTipoClienteFormapago(IdEmpresa, IdTipoCliente, IdFormaPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PromocionTemporalDetalleBE Selecciona(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdTipoVenta, int IdProducto, bool TraerIdTemDet = false)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                return PromocionTemporalDetalle.Selecciona(IdEmpresa, IdTipoCliente, IdFormaPago, IdTienda, IdTipoVenta, IdProducto, TraerIdTemDet);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PromocionTemporalDetalleBE SeleccionaUltimo(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdProducto)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                return PromocionTemporalDetalle.SeleccionaUltimo(IdEmpresa, IdTipoCliente, IdFormaPago, IdTienda, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PromocionTemporalDetalleBE pItem)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                PromocionTemporalDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PromocionTemporalDetalleBE pItem)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                PromocionTemporalDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PromocionTemporalDetalleBE pItem)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                PromocionTemporalDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaTodo(PromocionTemporalDetalleBE pItem)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                PromocionTemporalDetalle.EliminaTodo(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PromocionTemporalDetalleBE> Selecciona_Lista(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdTipoVenta, int IdProducto)
        {
            try
            {
                PromocionTemporalDetalleDL PromocionTemporalDetalle = new PromocionTemporalDetalleDL();
                return PromocionTemporalDetalle.Selecciona_Lista(IdEmpresa, IdTipoCliente, IdFormaPago, IdTienda, IdTipoVenta, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
