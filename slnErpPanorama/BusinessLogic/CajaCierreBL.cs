using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaCierreBL
    {
        public List<CajaCierreBE> ListaTodosActivo( int IdTienda)
        {
            try
            {
                CajaCierreDL CajaCierre = new CajaCierreDL();
                return CajaCierre.ListaTodosActivo( IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaCierreBE> ListaFechaCaja(DateTime FechaDesde, DateTime FechaHasta, int IdCaja)
        {
            try
            {
                CajaCierreDL CajaCierre = new CajaCierreDL();
                return CajaCierre.ListaFechaCaja(FechaDesde, FechaHasta, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaCierreBE pItem)
        {
            try
            {
                CajaCierreDL CajaCierre = new CajaCierreDL();
                CajaCierre.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaCierreBE pItem)
        {
            try
            {
                CajaCierreDL CajaCierre = new CajaCierreDL();
                CajaCierre.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaCierreBE pItem)
        {
            try
            {
                CajaCierreDL CajaCierre = new CajaCierreDL();
                CajaCierre.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaFecha(CajaCierreBE pItem)
        {
            try
            {
                CajaCierreDL CajaCierre = new CajaCierreDL();
                CajaCierre.EliminaFecha(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
