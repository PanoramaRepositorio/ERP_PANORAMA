using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TipoCambioBL
    {
        public List<TipoCambioBE> ListaTodosActivo(int IdEmpresa, int IdMoneda)
        {
            try
            {
                TipoCambioDL TipoCambio = new TipoCambioDL();
                return TipoCambio.ListaTodosActivo(IdEmpresa, IdMoneda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoCambioBE Selecciona(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                TipoCambioDL TipoCambio = new TipoCambioDL();
                return TipoCambio.Selecciona(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoCambioBE BuscarFecha(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                TipoCambioDL TipoCambio = new TipoCambioDL();
                return TipoCambio.BuscarFecha(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoCambioBE pItem)
        {
            try
            {
                TipoCambioDL TipoCambio = new TipoCambioDL();
                TipoCambio.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoCambioBE pItem)
        {
            try
            {
                TipoCambioDL TipoCambio = new TipoCambioDL();
                TipoCambio.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoCambioBE pItem)
        {
            try
            {
                TipoCambioDL TipoCambio = new TipoCambioDL();
                TipoCambio.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
