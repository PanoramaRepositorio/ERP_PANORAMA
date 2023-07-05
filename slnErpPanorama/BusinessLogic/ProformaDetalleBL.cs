using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProformaDetalleBL
    {
        public List<ProformaDetalleBE> ListaTodosActivo(int IdEmpresa, int IdProforma)
        {
            try
            {
                ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();
                return ProformaDetalle.ListaTodosActivo(IdEmpresa, IdProforma);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProformaDetalleBE pItem)
        {
            try
            {
                ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();
                ProformaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProformaDetalleBE pItem)
        {
            try
            {
                ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();
                ProformaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProformaDetalleBE pItem)
        {
            try
            {
                ProformaDetalleDL ProformaDetalle = new ProformaDetalleDL();
                ProformaDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
