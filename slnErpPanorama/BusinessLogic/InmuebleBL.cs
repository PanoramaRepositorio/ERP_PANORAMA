using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class InmuebleBL
    {
        public List<InmuebleBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                InmuebleDL Inmueble = new InmuebleDL();
                return Inmueble.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InmuebleBE Selecciona(int IdInmueble)
        {
            try
            {
                InmuebleDL Inmueble = new InmuebleDL();
                return Inmueble.Selecciona(IdInmueble);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InmuebleBE pItem)
        {
            try
            {
                InmuebleDL Inmueble = new InmuebleDL();
                Inmueble.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InmuebleBE pItem)
        {
            try
            {
                InmuebleDL Inmueble = new InmuebleDL();
                Inmueble.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InmuebleBE pItem)
        {
            try
            {
                InmuebleDL Inmueble = new InmuebleDL();
                Inmueble.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
