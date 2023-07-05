using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CuentaBancoDetalleBL
    {
        public List<CuentaBancoDetalleBE> ListaTodosActivo(int IdCuentaBanco)
        {
            try
            {
                CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                return CuentaBancoDetalle.ListaTodosActivo(IdCuentaBanco);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaBancoDetalleBE> ListaCuentaBanco(DateTime FechaDesde, DateTime FechaHasta, int IdCuentaBanco)
        {
            try
            {
                CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                return CuentaBancoDetalle.ListaCuentaBanco(FechaDesde, FechaHasta, IdCuentaBanco);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CuentaBancoDetalleBE Selecciona(int IdCuentaBancoDetalle)
        {
            try
            {
                CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                return CuentaBancoDetalle.Selecciona(IdCuentaBancoDetalle);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CuentaBancoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                    CuentaBancoDetalle.Inserta(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CuentaBancoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                    CuentaBancoDetalle.Actualiza(pItem);
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCliente(CuentaBancoDetalleBE pItem)
        {
            try
            {
                CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                CuentaBancoDetalle.ActualizaCliente(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaProveedor(CuentaBancoDetalleBE pItem)
        {
            try
            {
                CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                CuentaBancoDetalle.ActualizaProveedor(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Elimina(CuentaBancoDetalleBE pItem)
        {
            try
            {
                CuentaBancoDetalleDL CuentaBancoDetalle = new CuentaBancoDetalleDL();
                CuentaBancoDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
