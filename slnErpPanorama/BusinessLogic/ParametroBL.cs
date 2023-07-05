using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ParametroBL
    {
        public List<ParametroBE> ListaTodosActivo()
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                return Parametro.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ParametroBE> ListaNumero()
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                return Parametro.ListaNumero();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ParametroBE Selecciona(string IdParametro)
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                return Parametro.Selecciona(IdParametro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ParametroBE SeleccionaServidor()
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                return Parametro.SeleccionaServidor();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ParametroBE pItem)
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                Parametro.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ParametroBE pItem)
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                Parametro.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaLista(List<ParametroBE> pListaParametro)
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaParametro)
                    {
                        Parametro.Actualiza(item);
                    }

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEstado(ParametroBE pItem)
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                Parametro.ActualizaEstado(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ParametroBE pItem)
        {
            try
            {
                ParametroDL Parametro = new ParametroDL();
                Parametro.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
