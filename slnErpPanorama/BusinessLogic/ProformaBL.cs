using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProformaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ProformaBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                ProformaDL Proforma = new ProformaDL();
                return Proforma.ListaTodosActivo(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProformaBE Selecciona(int IdProforma)
        {
            try
            {
                ProformaDL Proforma = new ProformaDL();
                ProformaBE objAna = Proforma.Selecciona(IdProforma);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProformaBE SeleccionaNumero(int Periodo, string Numero, int IdSituacion)
        {
            try
            {
                ProformaDL Proforma = new ProformaDL();
                ProformaBE objAna = Proforma.SeleccionaNumero(Periodo, Numero, IdSituacion);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ProformaBE pItem, List<ProformaDetalleBE> pListaProformaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDL Proforma = new ProformaDL();
                    ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();

                    //Insertar en el Proforma
                    int IdProforma = 0;
                    IdProforma = Proforma.Inserta(pItem);

                    foreach (ProformaDetalleBE item in pListaProformaDetalle)
                    {
                        //Insertamos el detalle del Proforma
                        item.IdProforma = IdProforma;
                        ProformaDetalle.Inserta(item);
                    }

                    //Actualizamos el correlativo del Proforma
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Periodo);

                    ts.Complete();
                    return IdProforma;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProformaBE pItem, List<ProformaDetalleBE> pListaProformaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDL Proforma = new ProformaDL();
                    ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();

                    foreach (ProformaDetalleBE item in pListaProformaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del Proforma
                            item.IdProforma = pItem.IdProforma;
                            ProformaDetalle.Inserta(item);
                        }
                        else
                        {
                            ProformaDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el Proforma
                    Proforma.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdEmpresa, int IdProforma, int IdSituacion)
        {
            try
            {
                ProformaDL Proforma = new ProformaDL();
                Proforma.ActualizaSituacion(IdEmpresa, IdProforma, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProformaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDL Proforma = new ProformaDL();
                    ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();

                    List<ProformaDetalleBE> ListaProformaDetalle = null;
                    ListaProformaDetalle = new ProformaDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdProforma);
                    foreach (ProformaDetalleBE item in ListaProformaDetalle)
                    {
                        //Eliminanos el pago del documento de venta
                        ProformaDetalle.Elimina(item);
                    }

                    //Actualiza la anulación del Proforma
                    Proforma.ActualizaSituacion(pItem.IdEmpresa, pItem.IdProforma, Parametros.intPFAnulado);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
