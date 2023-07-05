using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class StockBultoBL
    {
        public List<StockBultoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                StockBultoDL StockBulto = new StockBultoDL();
                return StockBulto.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<StockBultoBE> ListaProducto(int IdEmpresa, int IdAlmacen, int IdProducto)
        {
            try
            {
                StockBultoDL StockBulto = new StockBultoDL();
                return StockBulto.ListaProducto(IdEmpresa, IdAlmacen, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(StockBultoBE pItem)
        {
            try
            {
                StockBultoDL StockBulto = new StockBultoDL();
                StockBulto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(StockBultoBE pItem)
        {
            try
            {
                StockBultoDL StockBulto = new StockBultoDL();
                StockBulto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCantidades(StockBultoBE pItem)
        {
            try
            {
                StockBultoDL StockBulto = new StockBultoDL();
                StockBulto.ActualizaCantidades(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(StockBultoBE pItem)
        {
            try
            {
                StockBultoDL StockBulto = new StockBultoDL();
                StockBulto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
