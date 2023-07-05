using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DocumentoBultoBL
    {
        public List<DocumentoBultoBE> ListaTodosActivo(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            try
            {
                DocumentoBultoDL DocumentoBulto = new DocumentoBultoDL();
                return DocumentoBulto.ListaTodosActivo(IdEmpresa,Periodo,IdTipoDocumento,Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DocumentoBultoBE pItem)
        {
            try
            {
                DocumentoBultoDL DocumentoBulto = new DocumentoBultoDL();
                DocumentoBulto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DocumentoBultoBE pItem)
        {
            try
            {
                DocumentoBultoDL DocumentoBulto = new DocumentoBultoDL();
                DocumentoBulto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DocumentoBultoBE pItem)
        {
            try
            {
                DocumentoBultoDL DocumentoBulto = new DocumentoBultoDL();
                DocumentoBulto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
