using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DerechoHabienteBL
    {
        public List<DerechoHabienteBE> ListaTodosActivo(int IdPersona)
        {
            try
            {
                DerechoHabienteDL DerechoHabiente = new DerechoHabienteDL();
                return DerechoHabiente.ListaTodosActivo(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DerechoHabienteBE Selecciona(int IdPersona, int IdDerechoHabiente)
        {
            try
            {
                DerechoHabienteDL DerechoHabiente = new DerechoHabienteDL();
                return DerechoHabiente.Selecciona(IdPersona, IdDerechoHabiente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DerechoHabienteBE pItem)
        {
            try
            {
                DerechoHabienteDL DerechoHabiente = new DerechoHabienteDL();
                DerechoHabiente.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DerechoHabienteBE pItem)
        {
            try
            {
                DerechoHabienteDL DerechoHabiente = new DerechoHabienteDL();
                DerechoHabiente.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DerechoHabienteBE pItem)
        {
            try
            {
                DerechoHabienteDL EstadoCuenta = new DerechoHabienteDL();
                EstadoCuenta.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
