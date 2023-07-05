using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PersonaCalendarioLaboralBL
	{
		public List<PersonaCalendarioLaboralBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
				return PersonaCalendarioLaboral.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PersonaCalendarioLaboralBE> ListaRecuperacion(DateTime Fecha)
        {
            try
            {
                PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
                return PersonaCalendarioLaboral.ListaRecuperacion(Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaCalendarioLaboralBE Selecciona(int IdPersonaCalendarioLaboral)
		{
			try
			{
				PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
				return PersonaCalendarioLaboral.Selecciona(IdPersonaCalendarioLaboral);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public PersonaCalendarioLaboralBE SeleccionaPersonaFecha(string Dni, DateTime Fecha)
		{
			try
			{
				PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
                return PersonaCalendarioLaboral.SeleccionaPersonaFecha(Dni,Fecha);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        
		public Int32 Inserta(PersonaCalendarioLaboralBE pItem)
		{
			try
			{
                int Id=0;
				PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
                Id = PersonaCalendarioLaboral.Inserta(pItem);
                return Id;

			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PersonaCalendarioLaboralBE pItem)
		{
			try
			{
				PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
				PersonaCalendarioLaboral.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PersonaCalendarioLaboralBE pItem)
		{
			try
			{
				PersonaCalendarioLaboralDL PersonaCalendarioLaboral = new PersonaCalendarioLaboralDL();
				PersonaCalendarioLaboral.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
