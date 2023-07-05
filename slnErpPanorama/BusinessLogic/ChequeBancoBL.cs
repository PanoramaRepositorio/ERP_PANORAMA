using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ChequeBancoBL
    {
        public void Inserta(ChequeBancoBE pItem)
        {
            try
            {
                ChequeBancoDL ChequeBanco = new ChequeBancoDL();
                ChequeBanco.Inserta(pItem);
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
        }

        public void Actualiza(ChequeBancoBE pItem)
        {
            try
            {
                ChequeBancoDL ChequeBanco = new ChequeBancoDL();
                ChequeBanco.Actualiza(pItem);
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
        }

        public void Elimina(ChequeBancoBE pItem)
        {
            try
            {
                ChequeBancoDL ChequeBanco = new ChequeBancoDL();
                ChequeBanco.Elimina(pItem);
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
        }

        public List<ChequeBancoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ChequeBancoDL ChequeBanco = new ChequeBancoDL();
                return ChequeBanco.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
        }

        public ChequeBancoBE Consulta(int IdChequeBanco)
        {
            try
            {
                ChequeBancoDL ChequeBanco = new ChequeBancoDL();
                return ChequeBanco.Consulta(IdChequeBanco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Valida(ChequeBancoBE pItem)
        {
            try
            {
                ChequeBancoDL ChequeBanco = new ChequeBancoDL();
                return ChequeBanco.Valida(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
