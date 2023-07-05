using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ChequeBL
    {
        public void Inserta(ChequeBE pItem)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                Cheque.Inserta(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(ChequeBE pItem)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                Cheque.Actualiza(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Elimina(ChequeBE pItem)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                Cheque.Elimina(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AnulaCheque(ChequeBE pItem)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                Cheque.AnulaCheque(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChequeBE> ListaTodosActivo(int IdEmpresa, DateTime pFecDesde, DateTime pFecHasta)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                return Cheque.ListaTodosActivo(IdEmpresa, pFecDesde, pFecHasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChequeBE Consulta(int IdCheque)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                return Cheque.Consulta(IdCheque);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChequeBE> GetMoneda(int IdEmpresa, int IdBanco)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                return Cheque.GetMoneda(IdEmpresa, IdBanco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChequeBancoBE NumeroCheque(int IdEmpresa, int IdBanco, int IdMoneda)
        {
            try
            {
                ChequeDL Cheque = new ChequeDL();
                return Cheque.NumeroCheque(IdEmpresa, IdBanco, IdMoneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
