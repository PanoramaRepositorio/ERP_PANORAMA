using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PersonaCuentaBancariaBL
    {

        public List<PersonaCuentaBancariaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                return PersonaCuentaBancaria.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaCuentaBancariaBE> ListaTodosPersona(int IdPersona)
        {
            try
            {
                PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                return PersonaCuentaBancaria.ListaTodosPersona(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaCuentaBancariaBE Selecciona(int IdPersonaCuentaBancaria)
        {
            try
            {
                PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                return PersonaCuentaBancaria.Selecciona(IdPersonaCuentaBancaria);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PersonaCuentaBancariaBE pItem)
        {
            try
            {
                PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                PersonaCuentaBancaria.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PersonaCuentaBancariaBE pItem)
        {
            try
            {
                PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                PersonaCuentaBancaria.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PersonaCuentaBancariaBE pItem)
        {
            try
            {
                PersonaCuentaBancariaDL PersonaCuentaBancaria = new PersonaCuentaBancariaDL();
                PersonaCuentaBancaria.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
