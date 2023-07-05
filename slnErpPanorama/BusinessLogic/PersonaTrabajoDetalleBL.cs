using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PersonaTrabajoDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PersonaTrabajoDetalleBE> ListaTodosActivo(int IdPersonaTrabajo)
		{
			try
			{
				PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();
				return PersonaTrabajoDetalle.ListaTodosActivo(IdPersonaTrabajo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PersonaTrabajoDetalleBE> ListaApoyo(int IdEmpresa)
        {
            try
            {
                PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();
                return PersonaTrabajoDetalle.ListaApoyo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaTrabajoDetalleBE Selecciona(int IdPersonaTrabajoDetalle)
		{
			try
			{
				PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();
				return PersonaTrabajoDetalle.Selecciona(IdPersonaTrabajoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PersonaTrabajoDetalleBE pItem)
		{
			try
			{
				PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();
				PersonaTrabajoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PersonaTrabajoDetalleBE pItem)
		{
			try
			{
				PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();
				PersonaTrabajoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PersonaTrabajoDetalleBE pItem)
		{
			try
			{
				PersonaTrabajoDetalleDL PersonaTrabajoDetalle = new PersonaTrabajoDetalleDL();
				PersonaTrabajoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
