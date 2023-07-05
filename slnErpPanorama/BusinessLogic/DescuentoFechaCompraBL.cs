using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DescuentoFechaCompraBL
    {
        public List<DescuentoFechaCompraBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                DescuentoFechaCompraDL DescuentoFechaCompra = new DescuentoFechaCompraDL();
                return DescuentoFechaCompra.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DescuentoFechaCompraBE SeleccionaCodigo(int IdEmpresa, int IdProducto)
        {
            try
            {
                DescuentoFechaCompraDL DescuentoFechaCompra = new DescuentoFechaCompraDL();
                return DescuentoFechaCompra.SeleccionaCodigo(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DescuentoFechaCompraBE pItem)
        {
            try
            {
                DescuentoFechaCompraDL DescuentoFechaCompra = new DescuentoFechaCompraDL();
                DescuentoFechaCompra.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescuentoFechaCompraBE pItem)
        {
            try
            {
                DescuentoFechaCompraDL DescuentoFechaCompra = new DescuentoFechaCompraDL();
                DescuentoFechaCompra.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DescuentoFechaCompraBE pItem)
        {
            try
            {
                DescuentoFechaCompraDL DescuentoFechaCompra = new DescuentoFechaCompraDL();
                DescuentoFechaCompra.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
