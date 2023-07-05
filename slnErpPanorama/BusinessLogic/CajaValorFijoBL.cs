using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaValorFijoBL
    {
        public List<CajaValorFijoBE> ListaTodosActivo(int IdCaja, DateTime Fecha, string TipoValor, int IdMoneda)
        {
            try
            {
                CajaValorFijoDL CajaValorFijo = new CajaValorFijoDL();
                return CajaValorFijo.ListaTodosActivo(IdCaja, Fecha, TipoValor,IdMoneda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public void Inserta(CajaValorFijoBE pItem, List<CajaValorFijoBE> pListaDocumentoVentaDetalle)
        public void Inserta(List<CajaValorFijoBE> pListaCajaValorFijo)
        {
            try
            {
                //CajaValorFijoDL CajaValorFijo = new CajaValorFijoDL();
                //CajaValorFijo.Inserta(pItem);

                using (TransactionScope ts = new TransactionScope())
                {
                    CajaValorFijoDL CajaValorFijo = new CajaValorFijoDL();

                    foreach (CajaValorFijoBE item in pListaCajaValorFijo)
                    {
                        CajaValorFijo.Inserta(item);
                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<CajaValorFijoBE> pListaPedidoDetalle)
        {
            try
            {
                CajaValorFijoDL CajaValorFijo = new CajaValorFijoDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaPedidoDetalle)
                    {
                        CajaValorFijo.Actualiza(item);
                    }
                    
                    ts.Complete();
                }
                
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaValorFijoBE pItem)
        {
            try
            {
                CajaValorFijoDL CajaValorFijo = new CajaValorFijoDL();
                CajaValorFijo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
