using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class FacturaCompraGastoBL
    {

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<FacturaCompraGastoBE> ListaTodosActivo(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                FacturaCompraGastoDL FacturaCompraGasto = new FacturaCompraGastoDL();
                return FacturaCompraGasto.ListaTodosActivo(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<FacturaCompraGastoBE> pListaFacturaCompraGasto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //FacturaCompraGastoDL Proforma = new FacturaCompraGastoDL();
                    FacturaCompraGastoDL FacuraCompraGasto = new FacturaCompraGastoDL();
//                FacturaCompraGastoDL ProformaDetalle = new FacturaCompraGastoDL();

                    foreach (FacturaCompraGastoBE item in pListaFacturaCompraGasto)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del Proforma
                         //   item.IdProforma = pItem.IdProforma;
                            FacuraCompraGasto.Inserta(item);
                        }
                        else
                        {
                            FacuraCompraGasto.Actualiza(item);
                        }
                    }

                    //Actualizamos el Proforma
                    //Proforma.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FacturaCompraGastoBE pItem)
        {
            try
            {
                FacturaCompraGastoDL FacturaCompraGasto = new FacturaCompraGastoDL();
                FacturaCompraGasto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta( List<FacturaCompraGastoBE> pListaFacturaCompraGasto)
        {
            try
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                    ProformaDL Proforma = new ProformaDL();
                    FacturaCompraGastoDL FacturaCompraGasto = new FacturaCompraGastoDL();

                    //Insertar en el Proforma
                    //int IdProforma = 0;
                    //IdProforma = Proforma.Inserta(pItem);

                    foreach (FacturaCompraGastoBE item in pListaFacturaCompraGasto)
                    {
                    //Insertamos el detalle del Proforma
                    // item.IdProforma = IdProforma;
                    FacturaCompraGasto.Inserta(item);
                    }

                    //Actualizamos el correlativo del Proforma
                    //NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Periodo);

                   // ts.Complete();
                    //return IdProforma;
              //  }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
