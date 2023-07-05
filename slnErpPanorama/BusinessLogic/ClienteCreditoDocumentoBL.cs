using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ClienteCreditoDocumentoBL
    {
        public List<ClienteCreditoDocumentoBE> ListaTodosActivo(int IdClienteCreditoDocumento)
        {
            try
            {
                ClienteCreditoDocumentoDL ClienteCreditoDocumento = new ClienteCreditoDocumentoDL();
                return ClienteCreditoDocumento.ListaTodosActivo(IdClienteCreditoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ClienteCreditoDocumentoBE> SeleccionaTodos()
        {
            try
            {
                ClienteCreditoDocumentoDL ClienteCreditoDocumento = new ClienteCreditoDocumentoDL();
                List<ClienteCreditoDocumentoBE> lista = ClienteCreditoDocumento.SeleccionaTodos();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ClienteCreditoDocumentoBE Selecciona(int IdClienteCreditoDocumento)
        {
            try
            {
                ClienteCreditoDocumentoDL ClienteCreditoDocumento = new ClienteCreditoDocumentoDL();
                ClienteCreditoDocumentoBE objEmp = ClienteCreditoDocumento.Selecciona(IdClienteCreditoDocumento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ClienteCreditoDocumentoBE pItem)
        {
            try
            {
                ClienteCreditoDocumentoDL ClienteCreditoDocumento = new ClienteCreditoDocumentoDL();
                ClienteCreditoDocumento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ClienteCreditoDocumentoBE pItem)
        {
            try
            {
                ClienteCreditoDocumentoDL ClienteCreditoDocumento = new ClienteCreditoDocumentoDL();
                ClienteCreditoDocumento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ClienteCreditoDocumentoBE pItem)
        {
            try
            {
                ClienteCreditoDocumentoDL ClienteCreditoDocumento = new ClienteCreditoDocumentoDL();
                ClienteCreditoDocumento.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
