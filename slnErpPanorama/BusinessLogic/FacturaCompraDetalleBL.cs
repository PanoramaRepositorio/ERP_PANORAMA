using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class FacturaCompraDetalleBL
    {
        public List<FacturaCompraDetalleBE> ListaTodosActivo(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                return FacturaCompraDetalle.ListaTodosActivo(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraDetalleBE> ListaTodosImagen(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                return FacturaCompraDetalle.ListaTodosImagen(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraDetalleBE> ListaTodosStock(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                return FacturaCompraDetalle.ListaTodosStock(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraDetalleBE> ListaNumero(int IdEmpresa, string Numero)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                return FacturaCompraDetalle.ListaNumero(IdEmpresa, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FacturaCompraDetalleBE> ListaNumeroPrecioABCD(int IdEmpresa, string Numero)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                return FacturaCompraDetalle.ListaNumeroPrecioABCD(IdEmpresa, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FacturaCompraDetalleBE pItem)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                FacturaCompraDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FacturaCompraDetalleBE pItem)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                FacturaCompraDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FacturaCompraDetalleBE pItem)
        {
            try
            {
                FacturaCompraDetalleDL FacturaCompraDetalle = new FacturaCompraDetalleDL();
                FacturaCompraDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
