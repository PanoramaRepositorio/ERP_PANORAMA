using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class GuiaRemisionDetalleBL
    {
        public List<GuiaRemisionDetalleBE> ListaTodosActivo(int IdEmpresa, int IdGuiaRemision)
        {
            try
            {
                GuiaRemisionDetalleDL GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                return GuiaRemisionDetalle.ListaTodosActivo(IdEmpresa, IdGuiaRemision);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<GuiaRemisionDetalleBE> ListaNumero(int IdEmpresa, int Periodo, string Numero)
        {
            try
            {
                GuiaRemisionDetalleDL GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                return GuiaRemisionDetalle.ListaNumero(IdEmpresa, Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(GuiaRemisionDetalleBE pItem)
        {
            try
            {
                GuiaRemisionDetalleDL GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                GuiaRemisionDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(GuiaRemisionDetalleBE pItem)
        {
            try
            {
                GuiaRemisionDetalleDL GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                GuiaRemisionDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(GuiaRemisionDetalleBE pItem, int IdAlmacen)
        {
            try
            {
                //Eliminar el detalle del movimiento de almacen
                GuiaRemisionDetalleDL GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                GuiaRemisionDetalle.Elimina(pItem);

                //Eliminar el kardex
                KardexBE objE_Kardex = new KardexBE();
                KardexDL objDL_Kardex = new KardexDL();

                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                objE_Kardex.IdKardex = Convert.ToInt32(pItem.IdKardex);
                objE_Kardex.Usuario = pItem.Usuario;
                objE_Kardex.Maquina = pItem.Maquina;
                objDL_Kardex.Elimina(objE_Kardex);

                //Actualizar Stock
                StockBE objE_Stock = new StockBE();
                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                objE_Stock.IdAlmacen = IdAlmacen;
                objE_Stock.IdProducto = pItem.IdProducto;
                objE_Stock.ValorIncrementa = pItem.Cantidad;
                objE_Stock.ValorDescuenta = 0;
                objE_Stock.Usuario = pItem.Usuario;
                objE_Stock.Maquina = pItem.Maquina;

                StockDL objDL_Stock = new StockDL();
                objDL_Stock.ActualizaCantidades(objE_Stock);
                
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
