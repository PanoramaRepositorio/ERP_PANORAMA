using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EstudioRealizadoBL
    {
        public List<EstudioRealizadoBE> ListaTodosActivo(int IdPersona)
        {
            try
            {
                EstudioRealizadoDL EstudioRealizado = new EstudioRealizadoDL();
                return EstudioRealizado.ListaTodosActivo(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstudioRealizadoBE Selecciona(int IdPersona, int IdEstudioRealizado)
        {
            try
            {
                EstudioRealizadoDL EstudioRealizado = new EstudioRealizadoDL();
                return EstudioRealizado.Selecciona(IdPersona, IdEstudioRealizado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EstudioRealizadoBE pItem)
        {
            try
            {
                EstudioRealizadoDL EstudioRealizado = new EstudioRealizadoDL();
                EstudioRealizado.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EstudioRealizadoBE pItem)
        {
            try
            {
                EstudioRealizadoDL EstudioRealizado = new EstudioRealizadoDL();
                EstudioRealizado.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EstudioRealizadoBE pItem)
        {
            try
            {
                EstudioRealizadoDL EstadoCuenta = new EstudioRealizadoDL();
                EstadoCuenta.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
