using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TransferenciaBultoDetalleBL
    {
        public List<TransferenciaBultoDetalleBE> ListaTodosActivo(int IdEmpresa, int IdTransferenciaBulto)
        {
            try
            {
                TransferenciaBultoDetalleDL TransferenciaBultoDetalle = new TransferenciaBultoDetalleDL();
                return TransferenciaBultoDetalle.ListaTodosActivo(IdEmpresa, IdTransferenciaBulto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TransferenciaBultoDetalleBE pItem)
        {
            try
            {
                TransferenciaBultoDetalleDL TransferenciaBultoDetalle = new TransferenciaBultoDetalleDL();
                TransferenciaBultoDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TransferenciaBultoDetalleBE pItem)
        {
            try
            {
                TransferenciaBultoDetalleDL TransferenciaBultoDetalle = new TransferenciaBultoDetalleDL();
                TransferenciaBultoDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TransferenciaBultoDetalleBE pItem)
        {
            try
            {
                TransferenciaBultoDetalleDL TransferenciaBultoDetalle = new TransferenciaBultoDetalleDL();
                TransferenciaBultoDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
