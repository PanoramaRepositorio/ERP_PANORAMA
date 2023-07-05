using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TipoDocumentoBL
    {
        public List<TipoDocumentoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoDocumentoDL TipoDocumento = new TipoDocumentoDL();
                return TipoDocumento.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoDocumentoBE pItem)
        {
            try
            {
                TipoDocumentoDL TipoDocumento = new TipoDocumentoDL();
                TipoDocumento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoDocumentoBE pItem)
        {
            try
            {
                TipoDocumentoDL TipoDocumento = new TipoDocumentoDL();
                TipoDocumento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoDocumentoBE pItem)
        {
            try
            {
                TipoDocumentoDL TipoDocumento = new TipoDocumentoDL();
                TipoDocumento.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
