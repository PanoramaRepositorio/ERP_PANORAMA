using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class BancoBL
    {
        public List<BancoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                BancoDL Banco = new BancoDL();
                return Banco.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(BancoBE pItem)
        {
            try
            {
                BancoDL Banco = new BancoDL();
                Banco.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(BancoBE pItem)
        {
            try
            {
                BancoDL Banco = new BancoDL();
                Banco.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(BancoBE pItem)
        {
            try
            {
                BancoDL Banco = new BancoDL();
                Banco.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<BancoBE> ListaFiltro(int IdEmpresa)
        {
            try
            {
                BancoDL Banco = new BancoDL();
                return Banco.ListaFiltro(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}

