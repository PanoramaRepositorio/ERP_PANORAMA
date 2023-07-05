using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InmuebleAlquilerBL
    {
        public List<InmuebleAlquilerBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                InmuebleAlquilerDL InmuebleAlquiler = new InmuebleAlquilerDL();
                return InmuebleAlquiler.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InmuebleAlquilerBE> ListaInmuebleCliente(int IdCliente)
        {
            try
            {
                InmuebleAlquilerDL InmuebleAlquiler = new InmuebleAlquilerDL();
                return InmuebleAlquiler.ListaInmuebleCliente(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InmuebleAlquilerBE Selecciona(int IdInmuebleAlquiler)
        {
            try
            {
                InmuebleAlquilerDL InmuebleAlquiler = new InmuebleAlquilerDL();
                return InmuebleAlquiler.Selecciona(IdInmuebleAlquiler);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InmuebleAlquilerBE pItem)
        {
            try
            {
                InmuebleAlquilerDL InmuebleAlquiler = new InmuebleAlquilerDL();
                InmuebleAlquiler.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InmuebleAlquilerBE pItem)
        {
            try
            {
                InmuebleAlquilerDL InmuebleAlquiler = new InmuebleAlquilerDL();
                InmuebleAlquiler.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InmuebleAlquilerBE pItem)
        {
            try
            {
                InmuebleAlquilerDL InmuebleAlquiler = new InmuebleAlquilerDL();
                InmuebleAlquiler.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
