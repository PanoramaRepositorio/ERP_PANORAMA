using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DocumentoVentaPagoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<DocumentoVentaPagoBE> ListaTodosActivo(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                return DocumentoVentaPago.ListaTodosActivo(IdEmpresa, IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaPagoBE> ListaGrupoPago(int IdEmpresa, string GrupoPago, int IdEstadoCuentaCliente)
        {
            try
            {
                DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                return DocumentoVentaPago.ListaGrupoPago(IdEmpresa, GrupoPago, IdEstadoCuentaCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<DocumentoVentaPagoBE> pListaDocumentoVentaPago, DocumentoVentaBE pItem)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaPagoBL DocumentoVentaPago = new DocumentoVentaPagoBL();
                foreach(DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                {
                    if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                    {
                        DocumentoVentaPago.Inserta(item);
                    }
                    else if(item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                    {
                        DocumentoVentaPago.Actualiza(item);
                    }
                }

                DocumentoVenta.ActualizaSituacionContable(pItem.IdEmpresa,pItem.IdDocumentoVenta, pItem.IdSituacionContable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DocumentoVentaPagoBE pItem)
        {
            try
            {
                DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                DocumentoVentaPago.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DocumentoVentaPagoBE pItem)
        {
            try
            {
                DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                DocumentoVentaPago.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DocumentoVentaPagoBE pItem)
        {
            try
            {
                DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                DocumentoVentaPago.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
