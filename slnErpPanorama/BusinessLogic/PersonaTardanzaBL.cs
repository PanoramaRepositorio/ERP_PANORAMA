using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PersonaTardanzaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PersonaTardanzaBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PersonaTardanzaDL PersonaTardanza = new PersonaTardanzaDL();
				return PersonaTardanza.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PersonaTardanzaBE Selecciona(int IdPersonaTardanza)
		{
			try
			{
				PersonaTardanzaDL PersonaTardanza = new PersonaTardanzaDL();
				return PersonaTardanza.Selecciona(IdPersonaTardanza);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PersonaTardanzaBE pItem)
		{
			try
			{
				PersonaTardanzaDL PersonaTardanza = new PersonaTardanzaDL();
				PersonaTardanza.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PersonaTardanzaBE pItem)
		{
			try
			{
				PersonaTardanzaDL PersonaTardanza = new PersonaTardanzaDL();
				PersonaTardanza.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PersonaTardanzaBE pItem)
		{
			try
			{
				PersonaTardanzaDL PersonaTardanza = new PersonaTardanzaDL();
				PersonaTardanza.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
