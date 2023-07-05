using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EstadoCuentaHistorialBL
    {
        public List<EstadoCuentaHistorialBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta, int IdMotivo, string TipoRegistro)
        {
            try
            {
                EstadoCuentaHistorialDL EstadoCuentaHistorial = new EstadoCuentaHistorialDL();
                return EstadoCuentaHistorial.ListaFecha(FechaDesde, FechaHasta, IdMotivo, TipoRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaHistorialBE> ListaTodosActivo(int IdEmpresa, int IdMotivo, string TipoRegistro)
        {
            try
            {
                EstadoCuentaHistorialDL EstadoCuentaHistorial = new EstadoCuentaHistorialDL();
                return EstadoCuentaHistorial.ListaTodosActivo(IdEmpresa, IdMotivo, TipoRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EstadoCuentaHistorialBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaHistorialDL EstadoCuentaHistorial = new EstadoCuentaHistorialDL();
                    EstadoCuentaHistorial.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EstadoCuentaHistorialBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EstadoCuentaHistorialDL EstadoCuentaHistorial = new EstadoCuentaHistorialDL();
                    EstadoCuentaHistorial.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EstadoCuentaHistorialBE pItem)
        {
            try
            {
                EstadoCuentaHistorialDL EstadoCuentaHistorial = new EstadoCuentaHistorialDL();
                EstadoCuentaHistorial.Elimina(pItem);

                ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                if (pItem.TipoMovimiento == "C")
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, 0, pItem.Importe, pItem.IdMotivo);
                else
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Importe, 0, pItem.IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
