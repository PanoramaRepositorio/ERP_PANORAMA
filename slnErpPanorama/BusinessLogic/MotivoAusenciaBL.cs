using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;
namespace ErpPanorama.BusinessLogic
{
    public class MotivoAusenciaBL
    {
        public List<MotivoAusenciaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                MotivoAusenciaDL MotivoAusencia = new MotivoAusenciaDL();
                return MotivoAusencia.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MotivoAusenciaBE pItem)
        {
            try
            {
                MotivoAusenciaDL MotivoAusencia = new MotivoAusenciaDL();
                MotivoAusencia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MotivoAusenciaBE pItem)
        {
            try
            {
                MotivoAusenciaDL MotivoAusencia = new MotivoAusenciaDL();
                MotivoAusencia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MotivoAusenciaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MotivoAusenciaDL MotivoAusencia = new MotivoAusenciaDL();
                    MotivoAusencia.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
