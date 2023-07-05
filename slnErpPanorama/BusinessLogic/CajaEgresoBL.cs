using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaEgresoBL
    {
        public List<CajaEgresoBE> ListaTodosActivo(DateTime pFechaDesde, DateTime pFechaHasta, int pIdEmpresa)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                return CajaCierre.ListaTodosActivo(pFechaDesde, pFechaHasta, pIdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoBE> ListaFechaCaja(DateTime FechaDesde, DateTime FechaHasta, int IdCaja)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                return CajaCierre.ListaFechaCaja(FechaDesde, FechaHasta, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void RevisionCaja(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.RevisionCaja(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaFecha(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.EliminaFecha(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoBE> Resumen(int pIdCajaEgreso)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                return CajaCierre.Resumen(pIdCajaEgreso);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
