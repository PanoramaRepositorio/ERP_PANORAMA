using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class LiquidacionProductoBL
    {
        public List<LiquidacionProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();
                return LiquidacionProducto.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<LiquidacionProductoBE> ListaModeloProducto(int IdModeloProducto)
        {
            try
            {
                LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();
                return LiquidacionProducto.ListaModeloProducto(IdModeloProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public LiquidacionProductoBE Selecciona(int IdLiquidacionProducto)
        {
            try
            {
                LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();
                return LiquidacionProducto.Selecciona(IdLiquidacionProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<LiquidacionProductoBE> pListaProductoLiquidacion, int IdModeloProducto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();

                    //Eliminar todos los registros y actualizar Todo
                    LiquidacionProducto.EliminaModelo(IdModeloProducto);

                    foreach (LiquidacionProductoBE item in pListaProductoLiquidacion)
                    {
                        LiquidacionProducto.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(LiquidacionProductoBE pItem)
        {
            try
            {
                LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();
                LiquidacionProducto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(LiquidacionProductoBE pItem)
        {
            try
            {
                LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();
                LiquidacionProducto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaModelo(int IdModeloProducto)
        {
            try
            {
                LiquidacionProductoDL LiquidacionProducto = new LiquidacionProductoDL();
                LiquidacionProducto.EliminaModelo(IdModeloProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
