using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class Promocion2x1DetalleBL
    {
        public List<Promocion2x1DetalleBE> ListaTodosActivo(int IdPromocion2x1)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                return Promocion2x1Detalle.ListaTodosActivo(IdPromocion2x1);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<Promocion2x1DetalleBE> ListaTipoClienteFormapago(int IdEmpresa, int IdTipoCliente, int IdFormaPago, string Tipo, DateTime Fecha)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                return Promocion2x1Detalle.ListaTipoClienteFormapago(IdEmpresa, IdTipoCliente, IdFormaPago, Tipo, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Promocion2x1DetalleBE SeleccionaProducto(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdProducto, string Tipo, DateTime Fecha)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                return Promocion2x1Detalle.SeleccionaProducto(IdEmpresa, IdTipoCliente, IdFormaPago, IdTienda, IdProducto, Tipo, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(Promocion2x1DetalleBE pItem)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                Promocion2x1Detalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(Promocion2x1DetalleBE pItem)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                Promocion2x1Detalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(Promocion2x1DetalleBE pItem)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                Promocion2x1Detalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaTodo(Promocion2x1DetalleBE pItem)
        {
            try
            {
                Promocion2x1DetalleDL Promocion2x1Detalle = new Promocion2x1DetalleDL();
                Promocion2x1Detalle.EliminaTodo(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
