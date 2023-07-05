using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PersonaDescansoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PersonaDescansoBE> ListaTodosActivo(int IdPersona)
		{
			try
			{
				PersonaDescansoDL PersonaDescanso = new PersonaDescansoDL();
				return PersonaDescanso.ListaTodosActivo(IdPersona);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PersonaDescansoBE Selecciona(int IdPersonaDescanso)
		{
			try
			{
				PersonaDescansoDL PersonaDescanso = new PersonaDescansoDL();
				return PersonaDescanso.Selecciona(IdPersonaDescanso);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PersonaDescansoBE pItem)
		{
			try
			{
				PersonaDescansoDL PersonaDescanso = new PersonaDescansoDL();
				PersonaDescanso.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PersonaDescansoBE pItem)
		{
			try
			{
				PersonaDescansoDL PersonaDescanso = new PersonaDescansoDL();
				PersonaDescanso.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PersonaDescansoBE pItem)
		{
			try
			{
				PersonaDescansoDL PersonaDescanso = new PersonaDescansoDL();
				PersonaDescanso.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
        }
        public void Elimina(int IdPersona, DateTime Fecha)
        {
            try
            {
                PersonaDescansoDL PersonaDescanso = new PersonaDescansoDL();
                PersonaDescanso.Elimina(IdPersona, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }
        

	}
}
