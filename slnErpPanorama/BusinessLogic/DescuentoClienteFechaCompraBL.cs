using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DescuentoClienteFechaCompraBL
    {
        public List<DescuentoClienteFechaCompraBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                DescuentoClienteFechaCompraDL DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraDL();
                return DescuentoClienteFechaCompra.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public DescuentoClienteFechaCompraBE SeleccionaCodigo(int IdEmpresa, int IdProducto)
        //{
        //    try
        //    {
        //        DescuentoClienteFechaCompraDL DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraDL();
        //        return DescuentoClienteFechaCompra.SeleccionaCodigo(IdEmpresa, IdProducto);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public void Inserta(DescuentoClienteFechaCompraBE pItem)
        {
            try
            {
                DescuentoClienteFechaCompraDL DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraDL();
                DescuentoClienteFechaCompra.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescuentoClienteFechaCompraBE pItem)
        {
            try
            {
                DescuentoClienteFechaCompraDL DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraDL();
                DescuentoClienteFechaCompra.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DescuentoClienteFechaCompraBE pItem)
        {
            try
            {
                DescuentoClienteFechaCompraDL DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraDL();
                DescuentoClienteFechaCompra.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
